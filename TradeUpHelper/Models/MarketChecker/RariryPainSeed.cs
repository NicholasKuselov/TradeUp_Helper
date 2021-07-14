
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TradeUpHelper.Models.MarketChecker
{
    class RariryPainSeed
    {
        public string Name { get; set; }
        public int[] Seeds { get; set; }

        //TODO: Локализация
        [JsonIgnore]
        public string GetSeedRarity { get { return "Редкость : " + (Seeds.Length / 10.0).ToString() + "%"; } }
    }
}
