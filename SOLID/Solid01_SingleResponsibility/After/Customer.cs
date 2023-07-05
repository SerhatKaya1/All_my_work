using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid01_SingleResponsibility.After
{
    public class Customer
    {
        void Login(string username, string password)
        {

        }
        void Register(string username, string password, string mail)
        { 
            EmailSender emailSender= new EmailSender();
            emailSender.SendEmail("Kaydınız başarıyla gerçekleşmiştir.");
        }
    }
}
