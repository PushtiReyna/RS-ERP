using ServiceLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ServiceLayer.CommonHelpers
{
    public class CommonHelper
    {
        private readonly IConfiguration _configuration;
        public CommonHelper(IConfiguration configuration)
        {

            _configuration = configuration;

        }

        public async Task<CommonResponse> SendLinkEmail(string email,int id)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var resetPasswordLink = "https://localhost:7189/swagger/index.html"; /*+ id;*/

                var fromEmail = new MailAddress(_configuration.GetSection("SiteEmailConfigration:FromEmail").Value);
                var toEmail = new MailAddress(email);
                var fromEmailPassword = _configuration.GetSection("SiteEmailConfigration:MailPassword").Value;

                string subject = "Reset Password";
                string body = "Hello,<br/><br/>We got request for reset your account password. Please click on the below link to reset your password" +
                       "<br/><br/><a href=" + resetPasswordLink + ">Reset Password</a>";

                var smtp = new SmtpClient
                {
                    Host = _configuration.GetSection("SiteEmailConfigration:Host").Value,
                    Port = Convert.ToInt32(_configuration.GetSection("SiteEmailConfigration:Port").Value),
                    EnableSsl = Convert.ToBoolean(_configuration.GetSection("SiteEmailConfigration:EnableSSL").Value),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
                };

                using (var message = new MailMessage(fromEmail, toEmail)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                    smtp.Send(message);
                response.Message = "reset password link send";
                response.Status = true;
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch { throw; }
            return response;
        }
    }
}
