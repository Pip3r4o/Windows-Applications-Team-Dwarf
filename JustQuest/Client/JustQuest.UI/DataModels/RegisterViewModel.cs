using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustQuest.UI.DataModels
{
    public class RegisterViewModel : ViewModelBase, IPageViewModel
    {
        public RegisterViewModel(IContentViewModel contentViewModel)
        {
            this.ContentViewModel = contentViewModel;
        }

        public string Title
        {
            get
            {
                return "Dwarf Quest";
            }
        }

        public IContentViewModel ContentViewModel { get; set; }
    }
}
