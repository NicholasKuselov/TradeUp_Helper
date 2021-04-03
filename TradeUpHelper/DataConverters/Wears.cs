using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TradeUpHelper.Models;

namespace TradeUpHelper.DataConverters
{
    class Wears
    {
        public static Wear FactoryNew = new Wear((string)Application.Current.Resources["WearFactoryNew"], (string)Application.Current.Resources["WearFactoryNewShort"], 0.0, 0.07);
        public static Wear MinimalWear = new Wear((string)Application.Current.Resources["WearMinimalWear"], (string)Application.Current.Resources["WearMinimalWearShort"], 0.07, 0.15);
        public static Wear FieldTested = new Wear((string)Application.Current.Resources["WearFieldTested"], (string)Application.Current.Resources["WearFieldTestedShort"], 0.15, 0.38);
        public static Wear WellWorn = new Wear((string)Application.Current.Resources["WearWellWorn"], (string)Application.Current.Resources["WearWellWornShort"], 0.38, 0.45);
        public static Wear BattleScared = new Wear((string)Application.Current.Resources["WearBattleScared"], (string)Application.Current.Resources["WearBattleScaredShort"], 0.45, 1.0);


        public static Wear GetWearByFloat(double value)
        {
            if (value > FactoryNew.FloatFrom && value <= FactoryNew.FloatTo) return FactoryNew;
            else if (value > MinimalWear.FloatFrom && value <= MinimalWear.FloatTo) return MinimalWear;
            else if (value > FieldTested.FloatFrom && value <= FieldTested.FloatTo) return FieldTested;
            else if (value > WellWorn.FloatFrom && value <= WellWorn.FloatTo) return WellWorn;
            else return BattleScared;
            
        }
    }
}
