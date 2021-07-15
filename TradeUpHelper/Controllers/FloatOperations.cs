using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeUpHelper.DataConverters;
using TradeUpHelper.Models;

namespace TradeUpHelper.Controllers
{
    class FloatOperations
    {
        public static double GetFloatThresholdForTradeUp(Wear needWear,ScinFloatData floatData)
        {
            return (needWear.FloatTo - floatData.min) / (floatData.max - floatData.min);
        }

    }
}
