using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustQuest.UI.DataModels
{
    public class Hint : ViewModelBase
    {
        public Hint()
        : this(string.Empty, string.Empty, string.Empty)
        {

        }


        public Hint(Hint hint)
      : this(hint.Description, hint.Latitude, hint.Longitude)
        {

        }

        public Hint(string description, string latitude, string longitude)
        {
            this.Description = description;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public string Description { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}
