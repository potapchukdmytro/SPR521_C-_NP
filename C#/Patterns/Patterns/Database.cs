namespace Patterns
{
    // Singleton патерн
    public sealed class Database
    {
        private static Database _instance = null;

        private Database() { }

        public static Database GetInstance()
        {
            if(_instance == null)
            {
                _instance = new Database();
            }

            return _instance;
        }
    }
}
