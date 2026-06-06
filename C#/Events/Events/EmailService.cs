namespace Events
{
    public class EmailService
    {
        private event Action<string> OnEmailSent;

        public void Subscribe(Action<string> handler)
        {
            OnEmailSent += handler;
        }

        public void Unsubscribe(Action<string> handler)
        {
            OnEmailSent -= handler;
        }

        public void SendEmail(string email)
        {
            OnEmailSent?.Invoke(email);
        }
    }
}
