using ServiceLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;

namespace ServiceLayer.CommonHelpers
{
    public class CommonHelper
    {
        private readonly IConfiguration _configuration;

        public CommonHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<CommonResponse> SendLinkEmail(string email, int id)
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

        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }

        public string EncryptString(string plainText)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["EncryptionKeys:EncryptionSecurityKey"].ToString());
            var iv = Encoding.UTF8.GetBytes(_configuration["EncryptionKeys:EncryptionSecurityIV"].ToString());

            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException("plainText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("iv");
            }

            byte[] encrypted;
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 128;
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }
                        encrypted = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encrypted);
        }

        public string DecryptString(string cipherText)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["EncryptionKeys:EncryptionSecurityKey"].ToString());
            var iv = Encoding.UTF8.GetBytes(_configuration["EncryptionKeys:EncryptionSecurityIV"].ToString());
            var encrypted = Convert.FromBase64String(cipherText);

            string plaintext = string.Empty;

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 128;
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                try
                {
                    using (MemoryStream memoryStream = new MemoryStream(encrypted))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                            {
                                plaintext = streamReader.ReadToEnd();
                            }
                        }
                    }
                }
                catch
                {
                    plaintext = "keyError";
                }
            }
            return plaintext;
        }
    }
}
