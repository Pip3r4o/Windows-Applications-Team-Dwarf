using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustQuest.UI.DataModels
{
    public class User : ViewModelBase
    {
        public User()
        : this(string.Empty, string.Empty, string.Empty, string.Empty)
    {
        }


        public User(User user)
      : this(user.Username, user.Email, user.Password, user.ConfirmPassword)
    {

        }

        public User(string username, string email, string password, string confirmPassword)
        {
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.ConfirmPassword = confirmPassword;
        }
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
