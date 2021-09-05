using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUpHelper.Models
{
    class Setting
    {
        public string UserInventoryURL { get; set; } = "";
        public string UserProfileId { get; set; } = "";
        public bool IsFirstStart { get; set; } = true;
        public bool IsFirstStartAfterUpdate { get; set; } = false;
        public int LastReadMessageId { get; set; } = 0;
        public int NeedNewsCount { get; set; } = 10;
    }
}
