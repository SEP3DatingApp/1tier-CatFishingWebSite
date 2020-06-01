using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatFishingWebSite.Model
{
    public class History
    {
        public int fisher1Id { get; set; }

        public int fisher2Id { get; set; }

        public int InteractionsId { get; set; }

        public History(int fisher1Id, int fisher2Id, int InteractionsId)
        {
            this.fisher1Id = fisher1Id;
            this.fisher2Id = fisher2Id;
            this.InteractionsId = InteractionsId;
        }
    }
}
