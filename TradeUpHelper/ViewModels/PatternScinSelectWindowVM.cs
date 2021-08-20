using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TradeUpHelper.Controllers.MarketChecker;

namespace TradeUpHelper.ViewModels
{
    class PatternScinSelectWindowVM : ViewModelBase
    {
        public RarityPainSeedScin SelectedItem { get; set; }
        public List<RarityPainSeedScin> Scins { get; set; } = RarityPaintSeedsHandler.Scins;

        public ICommand Select
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MarketChecker.SelectedScin = SelectedItem;
                    ((MarketCheckerPageVM)((MainWindowVM)App.Current.MainWindow.DataContext).MarketCheckerPage.DataContext).patternScinSelectWindow.Close();
                });
            }
        }
    }
}
