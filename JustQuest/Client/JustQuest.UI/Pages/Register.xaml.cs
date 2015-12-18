using JustQuest.UI.DataModels;
using JustQuest.UI.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Windows;
using Windows.UI.Popups;
using System.Threading.Tasks;
using System.Net.Http;
using JustQuest.UI.Data;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace JustQuest.UI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register : Page
    {
        public Register()
        {
            this.InitializeComponent();
            var contentViewModel = new UserViewModel();
            this.DataContext = new RegisterViewModel(contentViewModel);
        }
        private void scrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //UserName Validation   

            if (Username.Text.Length < 5)
            {

                var dialog = new MessageDialog("Username length should be minimum of 5 characters!");
                await dialog.ShowAsync();

            }
            
            //Password length Validation   

            else if (Password.Password.Length < 6)
            {

                var dialog = new MessageDialog("Password length should be minimum of 6 characters!");
                await dialog.ShowAsync();
            }

            //Confirm Password length Validation   

            else if (ConfirmPassword.Password != Password.Password)
            {

                var dialog = new MessageDialog("Confirm password should equal the password");
                await dialog.ShowAsync();
            }

            //EmailID validation   

            else if (!Regex.IsMatch(Email.Text.Trim(), @"^([a-zA-Z_])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$"))
            {
                var dialog = new MessageDialog("Invalid Email");
                await dialog.ShowAsync();

            }
            else
            {
                bool isSuccessfulRequest = false;
                string registerResponse = string.Empty;

                using (var client = new HttpClient())
                {
                    var formContent = new Dictionary<string, string>
                            {
                                {"Username", Username.Text },
                                {"Email", Email.Text },
                                {"Password", Password.Password },
                                {"ConfirmPassword", ConfirmPassword.Password }
                            };
                    var content = new FormUrlEncodedContent(formContent);

                    var response = await client.PostAsync("http://localhost:17888/api/account/register", content);

                    isSuccessfulRequest = response.IsSuccessStatusCode;

                    if (!isSuccessfulRequest)
                    {
                        registerResponse = await response.Content.ReadAsStringAsync();
                    }
                }
                if (isSuccessfulRequest)
                {
                    isSuccessfulRequest = false;

                    using (var client = new HttpClient())
                    {
                        var formContent = new Dictionary<string, string>
                            {
                                {"Username", Username.Text },
                                {"Password", Password.Password },
                                {"grant_type", "password" }
                            };
                        var content = new FormUrlEncodedContent(formContent);

                        var response = await client.PostAsync("http://localhost:17888/api/account/login", content);

                        var responseText = await response.Content.ReadAsStringAsync();
                        
                        var regex = new Regex("[a-zA-z0-9-_]+");
                        
                        isSuccessfulRequest = response.IsSuccessStatusCode;

                        if (isSuccessfulRequest)
                        {
                            var match = regex.Matches(responseText)[1].Value.TrimStart('{').TrimEnd('}');

                            SQLiteData.InitAsync();

                            SQLiteData.AddUserCredentials(new UserCredentials()
                            {
                                Name = Username.Text,
                                Token = match
                            });

                            //List<UserCredentials> users = await connection
                            //    .QueryAsync<UserCredentials>("SELECT * FROM UserCredentials");

                            this.Frame.Navigate(typeof (MainPage));
                        }
                    }
                }
                else
                {
                    var messages = BadRequestHandler.GetModelState(registerResponse);

                    foreach (var message in messages)
                    {
                        var dialog = new MessageDialog(message, "Something went wrong");
                        await dialog.ShowAsync();
                    }
                }
            }
        }
    }
}
