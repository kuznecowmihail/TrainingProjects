using System;

namespace AccountLogInApplication
{
    public class UserNotes
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}