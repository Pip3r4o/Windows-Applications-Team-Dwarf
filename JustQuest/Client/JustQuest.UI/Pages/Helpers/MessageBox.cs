using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustQuest.UI.Helpers
{
    public interface IMessageBox
    {
        DialogResult Show(string text);
    }
}
