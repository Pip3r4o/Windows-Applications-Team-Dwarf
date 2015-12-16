using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustQuest.Server.Web.Models
{
    using Contracts;
    using Data.Models;

    public class HintResponseModel : IMapFrom<Hint>
    {
        public string Description { get; set; }

        public string GeoLocationString { get; set; }
    }
}