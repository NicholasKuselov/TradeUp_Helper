using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUpHelper.Models
{
    public class ChangeLogEntry
    {
        public ChangeLogEntry()
        {
        }

        public string Version { get; set; }
        public string Description { get; set; }
    }
}
