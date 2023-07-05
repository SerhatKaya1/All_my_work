using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid06_DependencyInversion.After
{
    public class HotmailServer : IMailServer
    {
        public void Send(string to, string body)
        {
            throw new NotImplementedException();
        }
    }
}
