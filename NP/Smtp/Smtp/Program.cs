namespace Smtp
{
    internal class Program
    {
        static string GetHtml(string toEmail)
        {
            string html = File.ReadAllText("mail.html");
            html = html.Replace("{{username}}", toEmail);
            html = html.Replace("{{site_name}}", "SPR521");
            html = html.Replace("{{year}}", DateTime.Now.Year.ToString());

            return html;
        }

        static void Main(string[] args)
        {
            string fromEmail = "";
            string password = "";

            using (GmailService gmailService = new GmailService(fromEmail, password))
            {
                // Відправка текстового листа
                // gmailService.SendTextEmail(["test@mail.com"], "Second mail", "Це друге повідомлення через MailMessage");


                // Відправка HTML листа
                //string to = "";
                //string html = GetHtml(to);
                //gmailService.SendHtmlEmail(to, "Вітаємо на нашому сайті", html);


                // Відправка листа з вкладенням
                string to = "";

                string image1 = @"M:\funnyImages\avatar.png";
                string image2 = @"M:\funnyImages\bookDefault.png";
                string image3 = @"M:\funnyImages\default.png";
                string image4 = @"M:\funnyImages\noimage.png";

                gmailService.SendEmailWithAttachment(to, "Лист з файлами", "Ось тобі файл", image1, image2, image3, image4);
            }
        }
    }
}
