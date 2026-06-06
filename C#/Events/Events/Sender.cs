namespace Events
{
    public class Sender
    {
        private event Action<string> OnMessage;

        public void Subscribe(Action<string> handler)
        {
            OnMessage += handler;
        }

        public void Unsubscribe(Action<string> handler)
        {
            OnMessage -= handler;
        }

        public void SendMessage(string message)
        {
            OnMessage?.Invoke(message);
        }
    }
}
