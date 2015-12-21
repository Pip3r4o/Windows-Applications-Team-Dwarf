using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustQuest.UI.Helpers
{
    using Newtonsoft.Json.Linq;
   
    public class BadRequestHandler
    {
        public static IList<string> GetModelState(string json)
        {
            var text = JObject.Parse(json);

            var res = text["ModelState"][""].Children().Select(x => x.ToString()).ToList();

            return res;
        }
    }
}
