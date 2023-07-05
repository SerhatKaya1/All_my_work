using ShoppingApp.Web.EmailServices.Abstract;

namespace ShoppingApp.Web.EmailServices.Concrete
{
    public class Pop3EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}
