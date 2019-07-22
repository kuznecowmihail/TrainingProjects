using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountLogInApplication
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("User")]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string LeavingPlace { get; set; }
        public string Career { get; set; }

        public virtual User User { get; set; }
    }
}