using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUpHelper.Models
{
    class Wear
    {
        public string LongName;
        public string ShortName;
        public double FloatFrom;
        public double FloatTo;

        public Wear(string longName, string shortName, double floatFrom, double floatTo)
        {
            LongName = longName;
            ShortName = shortName;
            FloatFrom = floatFrom;
            FloatTo = floatTo;
        }
    }
}
