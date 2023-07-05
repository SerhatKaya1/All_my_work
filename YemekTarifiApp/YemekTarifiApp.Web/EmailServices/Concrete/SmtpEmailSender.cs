using System.Net.Mail;
using System.Net;
using YemekTarifiApp.Web.EmailServices.Abstract;

namespace YemekTarifiApp.Web.EmailServices.Concrete
{
	public class SmtpEmailSender : IEmailSender
	{
		private readonly string _host;
		private readonly int _port;
		private readonly bool _enableSSL;
		private readonly string _userName;
		private readonly string _password;

		public SmtpEmailSender(string host, int port, bool enableSSL, string userName, string password)
		{
			_host = host;
			_port = port;
			_enableSSL = enableSSL;
			_userName = userName;
			_password = password;
		}

		public Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			var client = new SmtpClient(_host, _port)
			{
				Credentials = new NetworkCredential(_userName, _password),
				EnableSsl = _enableSSL
			};
			return client.SendMailAsync(
				new MailMessage(_userName, email, subject, htmlMessage)
				{
					IsBodyHtml = true
				});
		}
	}
}
