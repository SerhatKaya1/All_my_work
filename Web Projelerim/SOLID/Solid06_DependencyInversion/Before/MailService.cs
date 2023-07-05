using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid06_DependencyInversion.Before
{
    public class MailService
    {
        //public void SendMail(GmailServer server)
        //{
        //    server.Send();
        //}
        public void SendMail(HotmailServer server)
        {
            server.SendMail();
        }
    }
}
