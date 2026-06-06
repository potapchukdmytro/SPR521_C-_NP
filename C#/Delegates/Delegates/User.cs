namespace Delegates
{
    public class User
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public bool IsPremium { get; set; }

        public override string ToString()
        {
            return $"Email: {Email}; Name: {Name}; IsPremium: {IsPremium}";
        }
    }
}
