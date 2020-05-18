using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatFishingWebSite.Services
{
    [Serializable]
    public class Request
    {
        public RequestTypes Type { get; set; }
        public Object Arg { get; set; }
    }
}
