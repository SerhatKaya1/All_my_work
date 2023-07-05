using YemekTarifiApp.Web.EmailServices.Abstract;

namespace YemekTarifiApp.Web.EmailServices.Concrete
{
	public class Pop3EmailSender : IEmailSender
	{
		public Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			throw new NotImplementedException();
		}
	}
}
