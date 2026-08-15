using EF_Relationships_seeder;
using EF_Relationships_seeder.Entities;

namespace EF_tracking_data_loading
{
    public class UserService
    {
        private List<User> _users;
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
            _users = context.Users.ToList();
        }

        public List<ProgramLanguage> GetLanguages(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);

            if(user != null)
            {
                // Explicit loading collection
                _context.Entry(user).Collection(u => u.ProgramLanguages).Load();
                return user.ProgramLanguages;
            }

            return [];
        }

        public string PassportNumber(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);

            if(user != null)
            {
                // Explicit loading
                _context.Entry(user).Reference(u => u.Passport).Load();

                return user.Passport != null
                    ? user.Passport.Number
                    : "Passport not found";
            }

            return "User not found";
        }
    }
}
