using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TradeUpHelper.ViewModels
{
    class MainWindowVM : ViewModelBase
    {
        public ICommand Save
        {
            get
            {
                return new RelayCommand(() =>
                {
                    t();
                });
            }
        }

        void t() { }
    }
}
