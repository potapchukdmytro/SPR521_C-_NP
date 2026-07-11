using System.Net;
using System.Net.Mail;

namespace Smtp
{
    public class GmailService : IDisposable
    {
        // Gmail settings
        private string host = "smtp.gmail.com";
        private int port = 587;
        private string fromEmail;
        private string password;

        private SmtpClient smtpClient;

        public GmailService(string fromEmail, string password)
        {
            this.fromEmail = fromEmail;
            this.password = password;

            smtpClient = new SmtpClient(host, port);
            var credentials = new NetworkCredential(fromEmail, password);
            smtpClient.Credentials = credentials;
            // ssl сертифікат використовується для шифрування даних, що передаються між клієнтом та сервером.
            // Це забезпечує безпеку передачі даних, таких як логіни, паролі та інша конфіденційна інформація.
            // У випадку з SMTP, SSL сертифікат гарантує, що електронні листи не можуть бути перехоплені або змінені під час передачі.
            smtpClient.EnableSsl = true;


        }

        public void SendTextEmail(string[] to, string subject, string body)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.Body = body;
            mailMessage.Subject = subject;
            mailMessage.From = new MailAddress(fromEmail);

            foreach (string t in to)
            {
                mailMessage.To.Add(t);
            }

            smtpClient.SendMailAsync(mailMessage).Wait();
        }

        public void SendHtmlEmail(string to, string subject, string bodyHtml)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.Body = bodyHtml;
            mailMessage.Subject = subject;
            mailMessage.From = new MailAddress(fromEmail);
            mailMessage.To.Add(to);
            mailMessage.IsBodyHtml = true;

            smtpClient.SendMailAsync(mailMessage).Wait();
        }

        public void SendEmailWithAttachment(string to, string subject, string body, params string[] filesPath)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.Body = body;
            mailMessage.Subject = subject;
            mailMessage.From = new MailAddress(fromEmail);
            mailMessage.To.Add(to);

            foreach (var path in filesPath)
            {
                Attachment attachment = new Attachment(path);
                mailMessage.Attachments.Add(attachment);
            }
            
            smtpClient.SendMailAsync(mailMessage).Wait();


            // Додавання через Stream
            // Дозволяє вказати будь яку назву для файлу
            //using (var stream = File.OpenRead(filePath))
            //{

            //    Attachment attachment = new Attachment(stream, "enot.png");
            //    mailMessage.Attachments.Add(attachment);

            //    smtpClient.SendMailAsync(mailMessage).Wait();
            //}
        }

        public void Dispose()
        {
            smtpClient.Dispose();
        }
    }
}
