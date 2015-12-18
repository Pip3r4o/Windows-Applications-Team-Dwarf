using JustQuest.UI.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace JustQuest.UI.Pages
{
    using Windows.System;
    using Helpers;
    using DataModels;
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddQuest : Page
    {
        

        public AddQuest()
        {
            this.InitializeComponent();

            var contentViewModel = new QuestViewModel();
            this.DataContext = new AddQuestViewModel(contentViewModel);


        }

        private void Add_Hint(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddHint));
        }
    }
}
