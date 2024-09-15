using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YemekTarifiApp.Business.Abstract;
using YemekTarifiApp.Business.Concrate;
using YemekTarifiApp.Data.Abstract;
using YemekTarifiApp.Data.Concrete;
using YemekTarifiApp.Data.Concrete.EfCore.Contexts;
using YemekTarifiApp.Entity.Concrate.Identity;
using YemekTarifiApp.Web.EmailServices.Abstract;
using YemekTarifiApp.Web.EmailServices.Concrete;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<YemekTarifiAppContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<YemekTarifiAppContext>()
    .AddDefaultTokenProviders();


builder.Services.Configure<IdentityOptions>(options =>
{
    #region PasswordSettings
    options.Password.RequireDigit = true;//�ifre i�inde mutlaka rakam bulunsun
    options.Password.RequireLowercase = true;//�ifre i�inde mutlaka k���k harf bulunsun
    options.Password.RequireUppercase = true;//�ifre i�inde mutlaka b�y�k harf bulunsun
    options.Password.RequiredLength = 6; //�ifre en az 6 karakter olsun
    options.Password.RequireNonAlphanumeric = true; //�ifre i�inde en az bir alfan�merik karakter(.,/*)& gibi) bulunmas� zorunlu olsun.
    #endregion
    #region LoginSettings
    options.Lockout.MaxFailedAccessAttempts = 3; //Ba�ar�s�z giri� deneme say�s� en fazla 5 olsun. E�er 5 kez hatal� giri� denemesi yaparsa, hesap kilitlensin.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(15); //Kilitlenmi� hesab�n, tekrar giri� deneme yapmas� i�in 5 dakika beklemesi gerekir.
    #endregion
    #region UserSettings
    options.User.RequireUniqueEmail = true;//Benzersiz email adresi ile kay�t olunabilir. Yani daha �nceden kay�t olunmu� bir mail adresi ile yeniden kay�t olunamaz.
    #endregion
    #region SignInSettings
    options.SignIn.RequireConfirmedEmail = false;//true ise email onay� aktiftir.
    options.SignIn.RequireConfirmedPhoneNumber = false;//true ise telefon numaras� onay� aktiftir.
    #endregion
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";//E�er a��labilmesi i�in login olman�n zorunlu oldu�u bir istekte bulunulursa, kullan�c�n�n y�nlendirilece�i sayfa buras� olacak. (account controllerindaki login action methodu)
    options.LogoutPath = "/account/logout";//Kullan�c� ��k�� yapt���nda y�nlendirilecek sayfa
    options.AccessDeniedPath = "/account/accessdenied";//Yetkisiz giri� s�ras�nda y�nlendirilecek sayfa
    options.SlidingExpiration = true;//Varsay�lan cookie ya�am s�resinin(20dk) ya da ayarlanan ya�am s�resinin her yeni istek s�ras�nda s�f�rlanarak yeniden ba�lamas�n� sa�lar.
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);//Ya�am s�resini ayarlar.
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = ".YemekTarifiApp.Security.Cookie",
        SameSite = SameSiteMode.Strict
    };
});


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IFoodService, FoodManager>();

builder.Services.AddScoped<IEmailSender, SmtpEmailSender>(x => new SmtpEmailSender(
    builder.Configuration["EmailSender:Host"],
    builder.Configuration.GetValue<int>("EmailSender:Port"),
    builder.Configuration.GetValue<bool>("EmailSender:EnableSSL"),
    builder.Configuration["EmailSender:UserName"],
    builder.Configuration["EmailSender:Password"]
    ));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "foods",
    pattern: "kategori/{categoryurl?}",
    defaults: new { controller = "YemekTarifi", action = "FoodList" }
    );

app.MapControllerRoute(
    name: "fooddetails",
    pattern: "yemekler/{foodurl}",
    defaults: new { controller = "YemekTarifi", action = "FoodDetails" }
    );

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
