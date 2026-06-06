using System.Text;

namespace Events
{
    internal class Program
    {
        static void SendEmail(string message)
        {
            Console.WriteLine($"Send email. Message: {message}");
        }

        static void SendSMS(string message)
        {
            Console.WriteLine($"Send SMS. Message: {message}");
        }

        static void SendViber(string message)
        {
            Console.WriteLine($"Send Viber. Message: {message}");
        }

        static void DrawRectangle()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }

        static void DrawTriangle()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //Sender sender = new Sender();
            //sender.Subscribe(SendEmail);
            //sender.Subscribe(SendSMS);
            //sender.Subscribe(SendViber);

            //sender.SendMessage("Hello my friend");

            //Console.WriteLine();
            //sender.Unsubscribe(SendEmail);
            //sender.SendMessage("Hello my friend");


            Button btn = new Button();
            btn.Subscribe(DrawRectangle);
            btn.Subscribe(DrawTriangle);
            btn.Click();

            User admin = new User { Email = "admin@example.com" };
            User john = new User { Email = "john@example.com" };
            User angela = new User { Email = "angela@example.com" };
            User michel = new User { Email = "michel@example.com" };

            EmailService emailService = new EmailService();

            emailService.Subscribe(john.SendEmail);
            emailService.Subscribe(angela.SendEmail);

            emailService.SendEmail("В наявності нові черевики. Сезон зима-осінь. Шалені знижки до 100%");

            emailService.Unsubscribe(john.SendEmail);

            Console.WriteLine();
            emailService.SendEmail("Нові сорочки та знижки до 99%. Поспішай");
        }
    }
}
