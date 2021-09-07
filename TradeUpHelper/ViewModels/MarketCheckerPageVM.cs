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
using TradeUpHelper.Controllers.MarketChecker;
using TradeUpHelper.Models;
using TradeUpHelper.Models.MarketChecker;
using TradeUpHelper.Views;

namespace TradeUpHelper.ViewModels
{
    class MarketCheckerPageVM : ViewModelBase
    {
        public MarketCheckerPageVM()
        {
            // ScinsNameWithRarityPaintSeeds.Insert(0, (string)Application.Current.Resources["MCSelectScin"]);
            MarketChecker.parent = this;

        }

        public double CheckProgressCountStages = 1;

        public double CheckProgress { get; set; } = 0.0;
        //public List<string> ScinsNameWithRarityPaintSeeds { get; set; } = new List<string>(RarityPaintSeedsHandler.seeds.Keys.ToArray());
        public RarityPainSeedScin SelectedWeapon { get; set; } = new RarityPainSeedScin() { ImageUrl = "", Name = (string)Application.Current.Resources["MCSelectScin"], Seeds = new List<RariryPainSeed>() };

        public bool IsStickerNeed { get; set; } = false;
        public bool IsPaintSeedNeed { get; set; } = true;
        public string Data { get; set; } = "";

        public List<MarketCheckerScin> Scins { get; set; }

        public List<MarketCheckerScin> ScinsWithRarityPaintSeeds { get; set; }

        public List<MarketCheckerScin> ScinsWithStickers { get; set; }

        public PatternScinSelectWindow patternScinSelectWindow;

        public ICommand ShowFAQ
        {
            get
            {
                return new RelayCommand(() =>
                {
                    UserMessagesController.AddMessageInQuerry("FAQ", ((string)Application.Current.Resources["FAQMarketChecker"]).Replace('|', '\n'));
                    UserMessagesController.Show();
                    //MessageBox.Show(((string)Application.Current.Resources["FAQMarketChecker"]).Replace('|', '\n'));
                });
            }
        }

        public ICommand StartChecking
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Check();
                });
            }
        }

        public ICommand OpenPatternScinWindow
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (patternScinSelectWindow != null)
                    {
                        patternScinSelectWindow.Show();
                    }
                    else
                    {
                        patternScinSelectWindow = new PatternScinSelectWindow();
                        patternScinSelectWindow.Show();
                    }
                });
            }
        }

        public void Check()
        {
            if (IsPaintSeedNeed && SelectedWeapon == null)
            {
                MessageBox.Show((string)Application.Current.Resources["MCSelectScinError"]);
                return;
            }
            else if (Data.Length < 10)
            {
                MessageBox.Show((string)Application.Current.Resources["ErrorMarketCheckerDataEmpty"], (string)Application.Current.Resources["Warning"], MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            //if (Data.Contains("Купить") && IsStickerNeed)
            //{
            //if(MessageBoxResult.No.Equals(MessageBox.Show((string) Application.Current.Resources["WarningRussianSteam"], (string)Application.Current.Resources["Warning"],MessageBoxButton.YesNo,MessageBoxImage.Warning)))
            //{
            //    return;
            //}
            //IsStickerNeed = false;

            //}
            if (Data.Contains("Powered by CSGOFloat") && IsStickerNeed)
            {
                if (MessageBoxResult.No.Equals(MessageBox.Show((string)Application.Current.Resources["WarningFloatMarketCheckerEnable"], (string)Application.Current.Resources["Warning"], MessageBoxButton.YesNo, MessageBoxImage.Warning)))
                {
                    return;
                }
                IsStickerNeed = false;
            }
            CheckProgress = 0.0;
            CheckProgressCountStages = 1;
            CheckProgress += 1.0;
            Scins?.Clear();
            ScinsWithRarityPaintSeeds?.Clear();
            ScinsWithStickers?.Clear();
            if (IsPaintSeedNeed) CheckProgressCountStages++;
            if (IsStickerNeed) CheckProgressCountStages++;
            MarketChecker.parent = this;
            Task.Run(() =>
            {
                try
                {
                    Scins = MarketChecker.GetScinsAlternative(Data, IsStickerNeed);
                    if (Scins.Count == 0)
                    {
                        MessageBox.Show((string)Application.Current.Resources["ErrorMarketCheckerDataUncorrect"], (string)Application.Current.Resources["ErrorTitle"], MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (IsPaintSeedNeed) ScinsWithRarityPaintSeeds = MarketChecker.CheckPaintSeed(Scins, SelectedWeapon);
                    if (IsStickerNeed) ScinsWithStickers = MarketChecker.GetStickerPrice(MarketChecker.GetScinsWithSticker(Scins));
                    CheckProgress += 10.0;
                    MessageBox.Show((string)Application.Current.Resources["OperationEndSuccessfuly"], "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show((string)Application.Current.Resources["ErrorMarketCheckerDataUncorrect"], (string)Application.Current.Resources["ErrorTitle"], MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });



        }
    }
}
