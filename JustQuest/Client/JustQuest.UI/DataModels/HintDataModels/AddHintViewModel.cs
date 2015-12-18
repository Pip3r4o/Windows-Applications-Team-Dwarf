using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustQuest.UI.DataModels
{
    public class AddHintViewModel : ViewModelBase, IPageViewModel
    {
        public AddHintViewModel(IContentViewModel contentViewModel)
        {
            this.ContentViewModel = contentViewModel;
        }

        public string Title
        {
            get
            {
                return "Add new Hint to the current Quest";
            }
        }

        public IContentViewModel ContentViewModel { get; set; }
    }
}
