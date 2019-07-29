using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

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

        public void AddUser(User user, UserProfile userProfile)
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

        public bool IsTrueData(string login, string password)
        {
            if(login == string.Empty || password == string.Empty)
            {
                return false;
            }

            using (UserContext db = new UserContext())
            {
                foreach(var user in db.Users.ToList())
                {
                    if(user.Login == login && user.Password == password)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public User GetInformationAboutUser(int id)
        {
            using (UserContext db = new UserContext())
            {
                return db.Users.Include(t => t.UserProfile).Include(t => t.UserNotes).Where(t => t.ID == id).FirstOrDefault();
            }
        }

        public List<User> GetAllusers()
        {
            List<User> users = new List<User>();

            using (UserContext db = new UserContext())
            {
                foreach(var i in db.Users.Include(t => t.UserProfile).Include(t => t.UserNotes).ToList())
                {
                    User once = i;
                    users.Add(once);
                }
            }

            return users;
        }

        public List<UserNotes> GetAllNotes()
        {
            List<UserNotes> usersNotes = new List<UserNotes>();

            using (UserContext db = new UserContext())
            {
                foreach (var i in db.UserNotes.Include(t => t.User).Include(t => t.User.UserProfile).ToList())
                {
                    UserNotes once = i;
                    usersNotes.Add(once);
                }
            }

            return usersNotes;
        }

        public bool AddText(string text, string login)
        {
            if(text ==string.Empty)
            {
                return false;
            }

            using (UserContext db = new UserContext())
            {
                int id = db.Users.Where(t => t.Login == login).FirstOrDefault().ID;
                UserNotes userNotes = new UserNotes()
                {
                    Text = text,
                    DateTime = DateTime.Now,
                    UserID = id
                };
                db.UserNotes.Add(userNotes);
                db.SaveChanges();

                return true;
            }
        }

        public void DeleteText(int id)
        {
            using (UserContext db = new UserContext())
            {
                var text = db.UserNotes.Where(t => t.ID == id).FirstOrDefault();
                db.UserNotes.Remove(text);
                db.SaveChanges();
            }
        }
    }
}