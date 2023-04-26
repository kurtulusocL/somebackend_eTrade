using eTrade.Business.Abstract.Services;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace eTrade.Business.Concrete.ServiceManager
{
    public class MailManager : IMailService
    {
        readonly IConfiguration _configuration;

        public MailManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMailAsync(new[] { to }, subject, body, isBodyHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;
            foreach (var to in tos)
                mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new(_configuration["Mail:Username"], "etrade", Encoding.UTF8);

            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = _configuration["Mail:Host"];
            await smtp.SendMailAsync(mail);
        }

        public async Task SendPasswordResetMailAsync(string to, string userId, string resetToken)
        {
            StringBuilder mail = new();
            mail.AppendLine("Hi<br>If you request a new password you can refresh to your current password after click to this url.<br><strong><a target=\"_blank\" href=\"");
            mail.AppendLine(_configuration["ClientUrl"]);
            mail.AppendLine("/update-password/");
            mail.AppendLine(userId);
            mail.AppendLine("/");
            mail.AppendLine(resetToken);
            mail.AppendLine("\">Click for new password...</a></strong><br><br><span style=\"font-size:12px;\">NOT : If to did not request you can delete to this email.</span><br>Have a good day...<br><br><br>NG - e-trade");

            await SendMailAsync(to, "Reset Password", mail.ToString());
        }

        public async Task SendCompletedOrderMailAsync(string to, string orderCode, DateTime orderDate, string userName)
        {
            string mail = $"Dear {userName} Hi, <br>" +
                $"The order with {orderCode} QR code that you got at {orderDate} is ready..<br>Enjoy with your order....";

            await SendMailAsync(to, $"The order that number {orderCode} is ready.", mail);

        }
    }
}
