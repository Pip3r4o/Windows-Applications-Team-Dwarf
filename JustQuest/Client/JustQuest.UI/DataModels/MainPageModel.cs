using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustQuest.UI.DataModels
{
    public class MainPageModel : ViewModelBase, IContentViewModel
    {
        public int ActiveQuests { get; set; }
    }
}
