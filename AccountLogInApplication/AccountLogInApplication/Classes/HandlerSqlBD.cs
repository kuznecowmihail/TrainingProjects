using System.Collections.Generic;
using System.Linq;

namespace AccountLogInApplication
{
    public class HandlerSqlBD
    {
        private static HandlerSqlBD _handler;

        private HandlerSqlBD() { }

        public static HandlerSqlBD GetHandler()
        {
            if(_handler == null)
            {
                _handler = new HandlerSqlBD();
            }

            return _handler;
        }

        public void AddInformation(User user, UserProfile userProfile)
        {
            using(UserContext db = new UserContext())
            {
                db.Users.Add(user);
                db.SaveChanges();

                userProfile.ID = user.ID;
                db.UserProfiles.Add(userProfile);
                db.SaveChanges();
            }
        }

        public bool IsNotExist(string login)
        {
            if(login == null || login.Length < 5)
            {
                return false;
            }

            using (UserContext db = new UserContext())
            {
                if(db.Users.Where(t => t.Login == login).Count() == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public (bool, int) IsTrueData(string login, string password)
        {
            if(login == string.Empty || password == string.Empty)
            {
                return (false, 0);
            }

            using (UserContext db = new UserContext())
            {
                foreach(var user in db.Users)
                {
                    if(user.Login == login && user.Password == password)
                    {
                        return (true, user.ID);
                    }
                }
            }

            return (false, 0);
        }

        public UserProfile GetInformation(int id)
        {
            using (UserContext db = new UserContext())
            {
                return db.UserProfiles.Where(t => t.ID == id).FirstOrDefault();
            }
        }

        public List<(UserProfile, string)> GetAllusers()
        {
            using (UserContext db = new UserContext())
            {
                List<(UserProfile, string)> users = new List<(UserProfile, string)>();
                
                foreach(var i in db.Users.ToList())
                {
                    (UserProfile, string) once = (i.UserProfile, i.Login);
                    users.Add(once);
                }
                return users;
            }
        }
    }
}