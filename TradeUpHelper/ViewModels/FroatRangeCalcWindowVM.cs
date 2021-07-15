using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TradeUpHelper.Controllers;
using TradeUpHelper.DataConverters;
using TradeUpHelper.Models;

namespace TradeUpHelper.ViewModels
{
    class FroatRangeCalcWindowVM : ViewModelBase
    {

        public string ScinName { get; set; } = "";
        //TODO : Local
        public string ScinImageUrl { get; set; }

        private double _FloatFN { get; set; } 
        private double _FloatMW { get; set; }
        private double _FloatFT { get; set; } 
        private double _FloatWW { get; set; } 
        private double _FloatBS { get; set; } 

        public double FloatFN
        {
            get {
               
                return _FloatFN; }
            set
            {
                //if (value[0].Equals('-'))
                //{
                //    _FloatFN = (string)Application.Current.Resources["FRWearImpossible"];
                //}
                if (value < 0) return;
                    _FloatFN = value;
            }
        }
        public double FloatMW
        {
            get { return _FloatMW; }
            set
            {
                if (value < 0) return;
                _FloatMW = value;
            }
        }
        public double FloatFT
        {
            get { return _FloatFT; }
            set
            {
                if (value < 0) return;
                _FloatFT = value;
            }
        }
        public double FloatWW
        {
            get { return _FloatWW; }
            set
            {
                if (value < 0) return;
                _FloatWW = value;
            }
        }
        public double FloatBS
        {
            get { return _FloatBS; }
            set
            {
                if (value < 0) return;
                _FloatBS = value;
                
            }
        }

        public string ScinUrl { get; set; } = "";



        public ICommand bSelect
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Start();
                });
            }
        }

        private void Start()
        {
            ScinFloatData floatData = JsonSerializer.Deserialize<ScinFloatData>(WebController.GetItemProp(ScinUrl));
            ScinName = floatData.full_item_name.Split('(')[0];
            ScinImageUrl = floatData.imageurl;
            FloatFN = FloatOperations.GetFloatThresholdForTradeUp(Wears.FactoryNew, floatData);
            FloatMW = FloatOperations.GetFloatThresholdForTradeUp(Wears.MinimalWear, floatData);
            FloatFT = FloatOperations.GetFloatThresholdForTradeUp(Wears.FieldTested, floatData);
            FloatWW = FloatOperations.GetFloatThresholdForTradeUp(Wears.WellWorn, floatData);
            FloatBS = FloatOperations.GetFloatThresholdForTradeUp(Wears.BattleScared, floatData);
        }
    }
}
