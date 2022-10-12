using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Abstraction.Services
{
    public interface IMailService
    {
        public bool sendEmail(string email, string body);
    }
}
