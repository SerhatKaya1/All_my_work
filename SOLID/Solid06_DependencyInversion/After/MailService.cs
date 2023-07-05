using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid06_DependencyInversion.After
{
    public class MailService
    {
        public void SendMail(IMailServer mailServer, string to, string body)
        {
            mailServer.Send(to, body);
        }
    }
}
