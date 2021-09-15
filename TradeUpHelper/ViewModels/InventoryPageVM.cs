using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public BindingList<Scin> Scins { get; set; }

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
            Scins = new BindingList<Scin>(InventoryHandler.items);
            SelectedItem = null;
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
            Scins = new BindingList<Scin>(InventoryHandler.items);
            InventoryLoadingDate = InventoryHandler.CacheWritingTime;
            MessageBox.Show((string)Application.Current.Resources["OperationEndSuccessfuly"],"",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void Switch()
        {
            if (SelectedItem == null) return;
            if (ScinOverlayWidth == 0) ScinOverlayWidth = 250;
            else ScinOverlayWidth = 0;
        }
    }
}
