using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustQuest.UI.DataModels
{
    public class AddQuestViewModel : ViewModelBase, IPageViewModel
    {
        public AddQuestViewModel(IContentViewModel contentViewModel)
        {
            this.ContentViewModel = contentViewModel;
        }

        public string Title
        {
            get
            {
                return "Add new Quest";
            }
        }

        public IContentViewModel ContentViewModel { get; set; }
    }
}
