using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Deployment;
using System.Deployment.Application;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Net;
using System.ComponentModel;
using TradeUpHelper.Views;
using TradeUpHelper.Controllers;
using TradeUpHelper.DataConverters;
using TradeUpHelper.Models;

namespace TradeUpHelper.ViewModels
{
    class MainWindowVM : ViewModelBase
    {

        private double _float1 = 0.0;
        private double _float2 = 0.0;
        private double _float3 = 0.0;
        private double _float4 = 0.0;
        private double _float5 = 0.0;
        private double _float6 = 0.0;
        private double _float7 = 0.0;
        private double _float8 = 0.0;
        private double _float9 = 0.0;
        private double _float10 = 0.0;

        private double _price1 = 0.0;
        private double _price2 = 0.0;
        private double _price3 = 0.0;
        private double _price4 = 0.0;
        private double _price5 = 0.0;
        private double _price6 = 0.0;
        private double _price7 = 0.0;
        private double _price8 = 0.0;
        private double _price9 = 0.0;
        private double _price10 = 0.0;

        public string wear1 { get; set; }
        public string wear2 { get; set; }
        public string wear3 { get; set; }
        public string wear4 { get; set; }
        public string wear5 { get; set; }
        public string wear6 { get; set; }
        public string wear7 { get; set; }
        public string wear8 { get; set; }
        public string wear9 { get; set; }
        public string wear10 { get; set; }

        public string float1
        {
            get
            {
                if (_float1.Equals(0.0)) return "";
                return _float1.ToString();
            }
            set
            {
                _float1 = ConvertFloatToDouble(value);
                OnFloatUpdate();
            }
        }

        public string float2
        {
            get
            {
                if (_float2.Equals(0.0)) return "";
                return _float2.ToString();
            }
            set
            {
                _float2 = ConvertFloatToDouble(value);
                OnFloatUpdate();
            }
        }

        public string float3
        {
            get
            {
                if (_float3.Equals(0.0)) return "";
                return _float3.ToString();
            }
            set
            {
                _float3 = ConvertFloatToDouble(value);
                OnFloatUpdate();
            }
        }

        public string float4
        {
            get
            {
                if (_float4.Equals(0.0)) return "";
                return _float4.ToString();
            }
            set
            {
                _float4 = ConvertFloatToDouble(value);
                OnFloatUpdate();
            }
        }

        public string float5
        {
            get
            {
                if (_float5.Equals(0.0)) return "";
                return _float5.ToString();
            }
            set
            {
                _float5 = ConvertFloatToDouble(value);
                OnFloatUpdate();
            }
        }

        public string float6
        {
            get
            {
                if (_float6.Equals(0.0)) return "";
                return _float6.ToString();
            }
            set
            {
                _float6 = ConvertFloatToDouble(value);
                OnFloatUpdate();
            }
        }

        public string float7
        {
            get
            {
                if (_float7.Equals(0.0)) return "";
                return _float7.ToString();
            }
            set
            {
                _float7 = ConvertFloatToDouble(value);
                OnFloatUpdate();
            }
        }

        public string float8
        {
            get
            {
                if (_float8.Equals(0.0)) return "";
                return _float8.ToString();
            }
            set
            {
                _float8 = ConvertFloatToDouble(value);
                OnFloatUpdate();
            }
        }

        public string float9
        {
            get
            {
                if (_float9.Equals(0.0)) return "";
                return _float9.ToString();
            }
            set
            {
                _float9 = ConvertFloatToDouble(value);
                OnFloatUpdate();
            }
        }

        public string float10
        {
            get
            {
                if (_float10.Equals(0.0)) return "";
                return _float10.ToString();
            }
            set
            {
                _float10 = ConvertFloatToDouble(value);
                OnFloatUpdate();
            }
        }

        public string price1
        {
            get
            {
                if (_price1.Equals(0.0)) return "";
                return _price1.ToString();
            }
            set
            {
                _price1 = ConvertFloatToDouble(value);
                OnPriceUpdate();
            }
        }

        public string price2
        {
            get
            {
                if (_price2.Equals(0.0)) return "";
                return _price2.ToString();
            }
            set
            {
                _price2 = ConvertFloatToDouble(value);
                OnPriceUpdate();
            }
        }

        public string price3
        {
            get
            {
                if (_price3.Equals(0.0)) return "";
                return _price3.ToString();
            }
            set
            {
                _price3 = ConvertFloatToDouble(value);
                OnPriceUpdate();
            }
        }

        public string price4
        {
            get
            {
                if (_price4.Equals(0.0)) return "";
                return _price4.ToString();
            }
            set
            {
                _price4 = ConvertFloatToDouble(value);
                OnPriceUpdate();
            }
        }

        public string price5
        {
            get
            {
                if (_price5.Equals(0.0)) return "";
                return _price5.ToString();
            }
            set
            {
                _price5 = ConvertFloatToDouble(value);
                OnPriceUpdate();
            }
        }

        public string price6
        {
            get
            {
                if (_price6.Equals(0.0)) return "";
                return _price6.ToString();
            }
            set
            {
                _price6 = ConvertFloatToDouble(value);
                OnPriceUpdate();
            }
        }

        public string price7
        {
            get
            {
                if (_price7.Equals(0.0)) return "";
                return _price7.ToString();
            }
            set
            {
                _price7 = ConvertFloatToDouble(value);
                OnPriceUpdate();
            }
        }

        public string price8
        {
            get
            {
                if (_price8.Equals(0.0)) return "";
                return _price8.ToString();
            }
            set
            {
                _price8 = ConvertFloatToDouble(value);
                OnPriceUpdate();
            }
        }

        public string price9
        {
            get
            {
                if (_price9.Equals(0.0)) return "";
                return _price9.ToString();
            }
            set
            {
                _price9 = ConvertFloatToDouble(value);
                OnPriceUpdate();
            }
        }

        public string price10
        {
            get
            {
                if (_price10.Equals(0.0)) return "";
                return _price10.ToString();
            }
            set
            {
                _price10 = ConvertFloatToDouble(value);
                OnPriceUpdate();
            }
        }

        private double _resultFloat = 0.0;
        public string resultFloat { get; set; }

        private double _resultPrice = 0.0;
        public string resultPrice { get; set; }

        public string NeedFloat { get; set; }

        public string resultWear { get; set; }

        public Brush ThresholdResultColor { get; set; } = Brushes.Gray;

        private double _outcomePrice = 0.0;

        public string outcomePrice
        {
            get
            {
                return _outcomePrice.ToString();
            }
            set
            {
                _outcomePrice = Convert.ToDouble(value);
            }
        }

        private double _threshold = 0.0;
        public string threshold
        {
            get
            {
                return _threshold.ToString();
            }
            set
            {
                OnThresholdUpdate(value);
            }
        }

        public ICommand bClear
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Clear();
                });
            }
        }

        public ICommand bCraftOk
        {
            get
            {
                return new RelayCommand(() =>
                {
                    WriteCraftToHistory();
                });
            }
        }

        public ICommand bShowHistory
        {
            get
            {
                return new RelayCommand(() =>
                {
                    new CraftHistoryWindow().Show();
                });
            }
        }

        public ICommand OpenPriceCalcWindow
        {
            get
            {
                return new RelayCommand(() =>
                {
                    new PriceCalcWindow().Show();
                });
            }
        }


        public ICommand UpdateProgram
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Updater.checkUpdates();

                });
            }
        }

        public ICommand ShowChangeLog
        {
            get
            {
                return new RelayCommand(() =>
                {
                    new ChangeLogWindow().Show();
                   // MessageBox.Show(((string)Application.Current.Resources["ChangeLog"]).Replace('|', '\n').Replace('/',' '), (string)Application.Current.Resources["bChangeLog"], MessageBoxButton.OK, MessageBoxImage.Information);
                });
            }
        }

        public ICommand CloseWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (MessageBox.Show("Tochno?", "Zakrit okno", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Application.Current.MainWindow.Close();
                    }


                });
            }
        }

        public ICommand MaximizeWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                    {
                        Application.Current.MainWindow.WindowState = WindowState.Normal;
                    }
                    else
                    {
                        Application.Current.MainWindow.WindowState = WindowState.Maximized;
                    }

                });
            }
        }

        public ICommand MinimizeWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Application.Current.MainWindow.WindowState = WindowState.Minimized;
                });
            }
        }

        void OnThresholdUpdate(string value)
        {
            _threshold = ConvertFloatToDouble(value);
            OnFloatUpdate();
        }

        void WriteCraftToHistory ()
        {
            Craft craft = new Craft(_resultPrice, _outcomePrice, _resultFloat);
            CraftHistoryHandler.AddCraft(craft);
            CraftHistoryHandler.Save();
        }

        void OnFloatUpdate()
        {
            List<double> floats = new List<double>() { _float1, _float2, _float3, _float4, _float5, _float6, _float7, _float8, _float9, _float10 };

            int floatCount = 0;
            double totalFloat = 0.0;
            double floatSum;
            foreach (double item in floats)
            {
                if (item.Equals(0.0) || item > 1)
                {
                    continue;
                }
                floatCount++;
                totalFloat += item;
            }
            if (totalFloat == 0.0)
            {
                resultFloat = "";
                return;
            }
            floatSum = totalFloat;
            totalFloat = totalFloat / floatCount;
            _resultFloat = totalFloat;
            resultFloat = totalFloat.ToString();

            if (_threshold > 0.0 && floatCount != 0)
            {
                CalcNeedFloat(floatCount, floatSum);
                if (_resultFloat < _threshold) ThresholdResultColor = Brushes.LightGreen;
                else ThresholdResultColor = Brushes.Red;
            }
            else
            {
                ThresholdResultColor = Brushes.Gray;
            }
        }

        void OnPriceUpdate()
        {
            List<double> prices = new List<double>() { _price1, _price2, _price3, _price4, _price5, _price6, _price7, _price8, _price9, _price10 };


            double totalPrice = 0.0;

            foreach (double item in prices)
            {
                totalPrice += item;
            }


            _resultPrice = totalPrice;
            if (totalPrice == 0.0) resultPrice = "";
            else resultPrice = totalPrice.ToString();
        }

        double ConvertFloatToDouble(string Float)
        {
            Float = Float.Replace('.', ',');
            string newFloat = "";
            for (int i = 0; i < Float.Length; i++)
            {
                if (Char.IsDigit(Float[i]) || Float[i].Equals(','))
                {
                    newFloat = newFloat + Float[i];
                }
            }
            if (newFloat.Length == 0) return 0.0;
            return Convert.ToDouble(newFloat);
        }

        void Clear()
        {
            price1 = ""; price2 = ""; price3 = ""; price4 = ""; price5 = ""; price6 = ""; price7 = ""; price8 = ""; price9 = ""; price10 = "";
            float1 = ""; float2 = ""; float3 = ""; float4 = ""; float5 = ""; float6 = ""; float7 = ""; float8 = ""; float9 = ""; float10 = "";
            NeedFloat = "";
        }

        private void InstallUpdateSyncWithInfo()
        {
            UpdateCheckInfo info = null;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();

                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    return;
                }

                if (info.UpdateAvailable)
                {
                    Boolean doUpdate = true;

                    if (!info.IsUpdateRequired)
                    {
                        MessageBoxResult dr = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButton.OKCancel);
                        if (!(MessageBoxResult.OK == dr))
                        {
                            doUpdate = false;
                        }
                    }
                    else
                    {
                        // Display a message that the app MUST reboot. Display the minimum required version.
                        MessageBox.Show("This application has detected a mandatory update from your current " +
                            "version to version " + info.MinimumRequiredVersion.ToString() +
                            ". The application will now install the update and restart.",
                            "Update Available", MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            ad.Update();
                            MessageBox.Show("The application has been upgraded, and will now restart.");
                            Application.Current.Shutdown();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
                            return;
                        }
                    }
                }
            }
        }

       
        private void CalcNeedFloat(int floatCount,double totalFloat)
        {
            if (floatCount == 10)
            {
                NeedFloat = (string)Application.Current.Resources["NeedFloatMinus"];
                return;
            }
            if (_resultFloat == 0.0)
            {
                NeedFloat = "";
                return;
            }
            double needFloat = 0.0;

            needFloat = ((_threshold * 10) - totalFloat) / (10 - floatCount);
            if(needFloat<0)
            {
                NeedFloat = (string)Application.Current.Resources["NeedFloatMinus"];
                return;
            }
            NeedFloat = Wears.GetWearByFloat(needFloat).ShortName + " " + needFloat.ToString();
        }
    }
}
