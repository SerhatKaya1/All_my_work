namespace ShoppingApp.Web.EmailServices.Abstract
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
