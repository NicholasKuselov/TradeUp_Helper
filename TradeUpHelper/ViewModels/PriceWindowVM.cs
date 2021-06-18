using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TradeUpHelper.DataConverters;

namespace TradeUpHelper.ViewModels
{
    class PriceWindowVM : ViewModelBase
    {
        private double _priceBefore = 0.0;
        //private double _priceAfter = 0.0;

        public string PriceBefore {
            get
            {
                
                if (_priceBefore.Equals(0.0)) return "";
             
                return _priceBefore.ToString();
            }
            set
            {
                _priceBefore = DataConverters.StringConverter.ConvertStringToDouble(value);
                OnPriceUpdate();
            }
        }

        public string PriceAfter { get; set; }
        

        private void OnPriceUpdate()
        {
            
            if(_priceBefore!=0.0)
            {
                PriceAfter = (_priceBefore * 0.87).ToString();
            }
            else
            {
                PriceAfter = "";
            }
        }

    }
}
