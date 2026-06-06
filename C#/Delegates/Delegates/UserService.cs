using System;
using System.Collections.Generic;
namespace Delegates
{
    public delegate bool UserDelegate(User user);

    internal class UserService
    {
        private User[] users;

        public UserService()
        {
            users = new User[]
                {
                new User() { Email = "user1@example.com", Name = "John Doe", IsPremium = true },
                new User() { Email = "user2@example.com", Name = "Jane Smith", IsPremium = false },
                new User() { Email = "user3@example.com", Name = "Bob Johnson", IsPremium = true },
                new User() { Email = "user4@example.com", Name = "Alice Brown", IsPremium = false },
                new User() { Email = "user5@example.com", Name = "Charlie Wilson", IsPremium = true }
                };
        }

        public User FindUser(UserDelegate pred)
        {
            foreach (var user in users)
            {
                if(pred(user))
                {
                    return user;
                }
            }

            return null;
        }
    }
}
