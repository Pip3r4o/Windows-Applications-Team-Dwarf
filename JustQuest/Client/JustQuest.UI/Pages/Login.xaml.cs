using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace JustQuest.UI.Pages
{
    using System.Net.Http;
    using System.Text.RegularExpressions;
    using Windows.UI.Popups;
    using Data;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private void scrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isSuccessfulRequest;

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

                    this.Frame.Navigate(typeof (MainPage));
                }
                else
                {
                    var dialog = new MessageDialog("Something went wrong", "Please try again");
                    await dialog.ShowAsync();
                }
            }
        }
    }
}
