using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Business.Abstract;
using ShoppingApp.Business.Concrete;
using ShoppingApp.Data.Abstract;
using ShoppingApp.Data.Concrete;
using ShoppingApp.Data.Concrete.EfCore.Contexts;
using ShoppingApp.Entity.Concrete.Identity;
using ShoppingApp.Web.EmailServices.Abstract;
using ShoppingApp.Web.EmailServices.Concrete;
using ShoppingApp.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<ShopAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlConnection")));
builder.Services.AddDbContext<ShopAppContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<ShopAppContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    #region PasswordSettings
    options.Password.RequireDigit= true;//Þifre içinde mutlaka rakam bulunsun
    options.Password.RequireLowercase= true;//Þifre içinde mutlaka küçük harf bulunsun
    options.Password.RequireUppercase = true;//Þifre içinde mutlaka büyük harf bulunsun
    options.Password.RequiredLength= 6; //Þifre en az 6 karakter olsun
    options.Password.RequireNonAlphanumeric= true; //Þifre içinde en az bir alfanümerik karakter(.,/*)& gibi) bulunmasý zorunlu olsun.
    #endregion
    #region LoginSettings
    options.Lockout.MaxFailedAccessAttempts = 3; //Baþarýsýz giriþ deneme sayýsý en fazla 5 olsun. Eðer 5 kez hatalý giriþ denemesi yaparsa, hesap kilitlensin.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(15); //Kilitlenmiþ hesabýn, tekrar giriþ deneme yapmasý için 5 dakika beklemesi gerekir.
    #endregion
    #region UserSettings
    options.User.RequireUniqueEmail = true;//Benzersiz email adresi ile kayýt olunabilir. Yani daha önceden kayýt olunmuþ bir mail adresi ile yeniden kayýt olunamaz.
    #endregion
    #region SignInSettings
    options.SignIn.RequireConfirmedEmail = false;//true ise email onayý aktiftir.
    options.SignIn.RequireConfirmedPhoneNumber= false;//true ise telefon numarasý onayý aktiftir.
    #endregion
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";//Eðer açýlabilmesi için login olmanýn zorunlu olduðu bir istekte bulunulursa, kullanýcýnýn yönlendirileceði sayfa burasý olacak. (account controllerindaki login action methodu)
    options.LogoutPath = "/account/logout";//Kullanýcý çýkýþ yaptýðýnda yönlendirilecek sayfa
    options.AccessDeniedPath = "/account/accessdenied";//Yetkisiz giriþ sýrasýnda yönlendirilecek sayfa
    options.SlidingExpiration = true;//Varsayýlan cookie yaþam süresinin(20dk) ya da ayarlanan yaþam süresinin her yeni istek sýrasýnda sýfýrlanarak yeniden baþlamasýný saðlar.
    options.ExpireTimeSpan= TimeSpan.FromDays(10);//Yaþam süresini ayarlar.
    options.Cookie = new CookieBuilder
    {
        HttpOnly=true,
        Name=".ShoppingApp.Security.Cookie",
        SameSite=SameSiteMode.Strict
    };
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICardService, CardManager>();
builder.Services.AddScoped<ICardItemService, CardItemManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();

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
    name: "products",
    pattern: "kategori/{categoryurl?}",
    defaults: new { controller = "Shop", action = "ProductList" }
    );

app.MapControllerRoute(
    name:"productdetails",
    pattern:"urunler/{producturl}",
    defaults: new {controller="Shop", action="ProductDetails"}
    );


app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"); ;

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UpdateDatabase().Run();
