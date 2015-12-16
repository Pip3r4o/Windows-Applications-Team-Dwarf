using JustQuest.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JustQuest.UI.DataModels
{
    public class UserViewModel : ViewModelBase, IContentViewModel
    {
        private ICommand registerCommand;

        public ICommand Register
        {
            get
            {
                if (this.registerCommand == null)
                {
                    this.registerCommand = new DelegateCommand<User>(async (user) =>
                    {
                        using (var client = new HttpClient())
                        {
                            var formContent = new Dictionary<string, string>
                            {
                                {"Username", user.Username },
                                {"Email", user.Email },
                                {"Password", user.Password },
                                {"ConfirmPassword", user.ConfirmPassword }
                            };
                            var content = new FormUrlEncodedContent(formContent);

                            var response = await client.PostAsync("http://localhost:17888/api/account/register", content);
                        }
                    });
                }
                return this.registerCommand;
            }
        }
    }
}
