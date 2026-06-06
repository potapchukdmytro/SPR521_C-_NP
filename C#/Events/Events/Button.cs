namespace Events
{
    public class Button
    {
        private event Action OnClick;

        public void Subscribe(Action handler)
        {
            OnClick += handler;
        }

        public void Unsubscribe()
        {
            OnClick -= OnClick;
        }

        public void Click()
        {
            OnClick?.Invoke();
        }
    }
}
