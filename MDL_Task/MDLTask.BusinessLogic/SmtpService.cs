using System.Net.Mail;
using System.Net;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Configuration;
using MDLTask.Domain;

namespace MDLTask.BusinessLogic
{
    public class SmtpService : ISmtpService
    {
        private readonly IConfiguration _configuration;

        public SmtpService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Method for sending a message.
        /// </summary>
        /// <returns>Result operation.</returns>
        public async Task<Result<bool>> SendEmail(string[] recipients, string subject, string body)
        {
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);

            MailAddress from = new MailAddress("testtask601mail.com@mail.ru", "Some");

            MailMessage m = new MailMessage();

            m.From = from;

            foreach (var recipient in recipients)
            {
                try
                {
                    m.To.Add(recipient);
                }
                catch (Exception e)
                {
                    return Result.Failure<bool>(e.Message);
                }
            }

            m.Subject = subject;

            m.SubjectEncoding = System.Text.Encoding.UTF8;

            m.Body = body;

            m.BodyEncoding = System.Text.Encoding.UTF8;

            smtp.Credentials = new NetworkCredential(_configuration["login"], _configuration["password"]);

            smtp.EnableSsl = true;

            try
            {
                await smtp.SendMailAsync(m);
            }
            catch (Exception e)
            {
                return Result.Failure<bool>(e.Message);
            }

            return true;
        }
    }
}
