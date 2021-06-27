﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TradeUpHelper.Controllers.MarketChecker;
using TradeUpHelper.Models;
using TradeUpHelper.Models.MarketChecker;

namespace TradeUpHelper.ViewModels
{
    class MarketCheckerPageVM : ViewModelBase
    {
        public MarketCheckerPageVM()
        {
            ScinsNameWithRarityPaintSeeds.Insert(0, (string)Application.Current.Resources["MCSelectScin"]);

        }

        public double CheckProgressCountStages = 1;

        public double CheckProgress { get; set; } = 0.0;
        public List<string> ScinsNameWithRarityPaintSeeds { get; set; } = new List<string>(RarityPaintSeedsHandler.seeds.Keys.ToArray());
        public string SelectedWeapon { get; set; } = (string)Application.Current.Resources["MCSelectScin"];

        public bool IsStickerNeed { get; set; } = false;
        public bool IsPaintSeedNeed { get; set; } = true;
        public string Data { get; set; } = "";

        public List<MarketCheckerScin> Scins { get; set; } 

        public List<MarketCheckerScin> ScinsWithRarityPaintSeeds { get; set; }

        public List<MarketCheckerScin> ScinsWithStickers { get; set; }

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

        public void Check()
        {
            if(IsPaintSeedNeed && SelectedWeapon == null)
            {
                MessageBox.Show((string)Application.Current.Resources["MCSelectScinError"]);
                return;
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
                
                
                
                Scins = MarketChecker.GetScins(Data,IsStickerNeed);
                if(IsPaintSeedNeed) ScinsWithRarityPaintSeeds = MarketChecker.CheckPaintSeed(Scins, SelectedWeapon);
                if(IsStickerNeed) ScinsWithStickers = MarketChecker.GetStickerPrice(MarketChecker.GetScinsWithSticker(Scins));
                CheckProgress += 10.0;
            });
        }
    }
}
