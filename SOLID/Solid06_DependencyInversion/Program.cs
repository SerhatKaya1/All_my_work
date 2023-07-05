//using Solid06_DependencyInversion.Before;
using Solid06_DependencyInversion.After;

namespace Solid06_DependencyInversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Before
            //MailService mailService = new MailService();
            //mailService.SendMail(new GmailServer());
            #endregion

            #region After
            MailService mailService = new MailService();
            mailService.SendMail(new GmailServer(), "engin@gmail.com", "selam");
            mailService.SendMail(new HotmailServer(), "enginniyazi@hotmail.com", "selammmmmm");
            #endregion
        }
    }
}