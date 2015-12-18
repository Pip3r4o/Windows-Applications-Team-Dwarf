using JustQuest.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JustQuest.UI.DataModels
{
    public class HintViewModel : ViewModelBase, IContentViewModel
    {
        private ICommand addHintCommand;
        private readonly Quest quest;

        public ICommand AddHint
        {
            get
            {
                if (this.addHintCommand == null)
                {

                    this.addHintCommand = new DelegateCommand<Hint>((hint) =>
                    {
                        //TODO: take the current quest and put this hint somehow
                        //quest.Hints.Add(hint);
                    });
                }
                return this.addHintCommand;
            }

        }

    }
}
