using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            token = cancelTokenSource.Token;
        }

        public bool IsRuning { get; set; } = false;

        Task marketChecker = new Task(()=> { });
        public int StickersFounded { get; set; } = 0;
        public double CheckProgressCountStages = 1;
        public int TotalScanedScinCount { get; set; } = 0;

        public string NeedScinCount { get; set; } = "";
        public double CheckProgress { get; set; } = 0.0;
        //public List<string> ScinsNameWithRarityPaintSeeds { get; set; } = new List<string>(RarityPaintSeedsHandler.seeds.Keys.ToArray());
        public RarityPainSeedScin SelectedWeapon { get; set; } = new RarityPainSeedScin() { ImageUrl = "", Name = (string)Application.Current.Resources["MCSelectScin"], Seeds = new List<RariryPainSeed>() };

        public bool IsStickerNeed { get; set; } = false;
        public bool IsPaintSeedNeed { get; set; } = true;
        public string Data { get; set; } = "";

        public List<MarketCheckerScin> Scins { get; set; }

        public List<MarketCheckerScin> ScinsWithRarityPaintSeeds { get; set; } = new List<MarketCheckerScin>();

        public List<MarketCheckerScin> ScinsWithStickers { get; set; } = new List<MarketCheckerScin>();

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

        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        CancellationToken token;


        public void Check()
        {
            if (marketChecker.Status == TaskStatus.Running)
            {
                if (MessageBoxResult.No.Equals(MessageBox.Show((string)Application.Current.Resources["MCCancelCheckText"], (string)Application.Current.Resources["MCCancelCheckTitle"], MessageBoxButton.YesNo, MessageBoxImage.Question)))
                {
                    IsRuning = true;
                    return;
                }
                
                cancelTokenSource.Cancel();
                CheckProgress += 100;
                return;
            }

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

            if (Data.Contains("Powered by CSGOFloat") && IsStickerNeed)
            {
                if (MessageBoxResult.No.Equals(MessageBox.Show((string)Application.Current.Resources["WarningFloatMarketCheckerEnable"], (string)Application.Current.Resources["Warning"], MessageBoxButton.YesNo, MessageBoxImage.Warning)))
                {
                    return;
                }
                IsStickerNeed = false;
            }

            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;

            CheckProgress = 0.0;
            CheckProgressCountStages = 1;
            CheckProgress += 1.0;
            Scins?.Clear();
            ScinsWithRarityPaintSeeds?.Clear();
            ScinsWithStickers?.Clear();
            if (IsPaintSeedNeed) CheckProgressCountStages++;
            if (IsStickerNeed) CheckProgressCountStages++;
            MarketChecker.parent = this;
            StickersFounded = 0;
            TotalScanedScinCount = 0;
            IsRuning = true;
            marketChecker = new Task(() =>
            {

                try
                {
                    if (Data.StartsWith("https://steamcommunity.com/market/listings/"))
                    {
                        Scins = MarketChecker.GetScinsFromSteamUrl(Data, NeedScinCount, token);
                        if (Scins.Count == 0)
                        {
                            MessageBox.Show((string)Application.Current.Resources["ErrorMarketCheckerDataUncorrect"], (string)Application.Current.Resources["ErrorTitle"], MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (IsPaintSeedNeed) ScinsWithRarityPaintSeeds = MarketChecker.CheckPaintSeed(Scins, SelectedWeapon, token);
                        if (IsStickerNeed) ScinsWithStickers = MarketChecker.GetScinsWithStickerScinsFromSteamURL(Scins, token);

                    }
                    else
                    {
                        Scins = MarketChecker.GetScinsAlternative(Data, IsStickerNeed, token);
                        if (Scins.Count == 0)
                        {
                            MessageBox.Show((string)Application.Current.Resources["ErrorMarketCheckerDataUncorrect"], (string)Application.Current.Resources["ErrorTitle"], MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (IsPaintSeedNeed) ScinsWithRarityPaintSeeds = MarketChecker.CheckPaintSeed(Scins, SelectedWeapon, token);
                        if (IsStickerNeed) ScinsWithStickers = MarketChecker.GetStickerPrice(MarketChecker.GetScinsWithSticker(Scins, token), token);
                    }

                    foreach (MarketCheckerScin item in ScinsWithStickers)
                    {
                        if (item.stickers != null)
                        {
                            StickersFounded += item.stickers.Length;
                        }
                    }



                    CheckProgress += 10.0;
                    IsRuning = false;
                    
                    MessageBox.Show((string)Application.Current.Resources["OperationEndSuccessfuly"], "", MessageBoxButton.OK, MessageBoxImage.Information,MessageBoxResult.OK,MessageBoxOptions.DefaultDesktopOnly);
                }
                catch (Exception e)
                {
                    ErrorHandler.WriteErrorLog(e);
                    MessageBox.Show((string)Application.Current.Resources["ErrorMarketCheckerDataUncorrect"], (string)Application.Current.Resources["ErrorTitle"], MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }, cancelTokenSource.Token);
            
            IsRuning = true;
            marketChecker.Start();
            

        }
    }
}
