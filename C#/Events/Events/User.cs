namespace Events
{
    public class User
    {
        public string Email { get; set; }

        public void SendEmail(string message)
        {
            Console.WriteLine($"Send email to {Email}. Message: {message}");
        }
    }
}
