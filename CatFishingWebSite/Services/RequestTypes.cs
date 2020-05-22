using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatFishingWebSite.Services
{
    public enum RequestTypes
    {
        GETALLUSERS,
        GETUSER,
        LOGIN,
        LOGOUT,
        CREATEUSER,
        //edit
        EDITFISHER,
        GETFISHER
    }
}
