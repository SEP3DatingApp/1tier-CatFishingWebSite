using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatFishingWebSite.Model
{
    public class MatchModel
    {
        public int PrimeId { get; set; }

        public int OtherId { get; set; }

        public string Token { get; set; }

        public int likeDislikeId { get; set; }
    }
}
