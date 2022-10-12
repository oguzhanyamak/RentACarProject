using Microsoft.Extensions.Configuration;
using RentACarProject.Application.Abstraction.Services;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Services
{
    public class MailService :IMailService
    {
        private readonly IConfiguration _config;

        public MailService(IConfiguration config)
        {
            _config = config;
        }

        public bool sendEmail(string email, string body)
        {
            RestClient client = new RestClient( baseUrl:"https://api.mailgun.net/v3") { Authenticator = new HttpBasicAuthenticator("api",_config.GetSection("EmailService:Key").Value)  };
            //client.BaseUrl = "https://api.mailgun.net/v3";
            
            var request = new RestRequest() { Method = Method.Post };
            request.AddParameter("domain", "sandboxb7f9685f0daa4978903c7affdcb611f0.mailgun.org", ParameterType.UrlSegment);
            request.Resource ="{domain}/messages";
            request.AddParameter("from", "Excited User <Rental@sandboxb7f9685f0daa4978903c7affdcb611f0.mailgun.org>");
            request.AddParameter("to", email);
            //request.AddParameter("to", "YOU@YOUR_DOMAIN_NAME");
            request.AddParameter("subject", "Verification Email");
            request.AddParameter("text", body);
            var response = client.Execute(request);

            return response.IsSuccessful;
        }
    }
}
