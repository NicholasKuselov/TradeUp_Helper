using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TradeUpHelper.Controllers;
using TradeUpHelper.Models;

namespace TradeUpHelper.ViewModels
{
    class InventoryPageVM : ViewModelBase
    {
        public List<Scin> Scins { get; set; } = InventoryHandler.items;

        public int ScinOverlayWidth { get; set; } = 0;

        public Scin SelectedItem { get; set; } = null;
        public string InventoryLoadingDate { get; set; } = InventoryHandler.CacheWritingTime;

        public string InventoryPrice
        {
            get
            {
                double pr = 0.0;
                for (int i = 0; i < Scins.Count; i++)
                {
                    if (Scins[i].price > 0)
                    {
                        pr += Scins[i].price;
                    }
                }
                return pr.ToString();
            }
        }

        public string InventoryCount
        {
            get
            {
                
                return Scins.Count.ToString();
            }
        }


        public InventoryPageVM()
        {
            SelectedItem = Scins[0];
        }
        public ICommand UpdateInventory
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Update();

                });
            }
        }

        public ICommand SwitchScinOverlay
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Switch();

                });
            }
        }

        private void Update()
        {
            InventoryHandler.LoadItems();
            Scins = InventoryHandler.items;
            InventoryLoadingDate = InventoryHandler.CacheWritingTime;
            MessageBox.Show((string)Application.Current.Resources["OperationEndSuccessfuly"],"",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void Switch()
        {
            if (ScinOverlayWidth == 0) ScinOverlayWidth = 250;
            else ScinOverlayWidth = 0;
        }
    }
}
