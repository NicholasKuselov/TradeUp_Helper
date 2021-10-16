using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TradeUpHelper.Constants;
using TradeUpHelper.Controllers;
using TradeUpHelper.Models;


namespace TradeUpHelper.ViewModels
{
    class ChangeLogWindowVM : ViewModelBase
    {
        public ChangeLogWindowVM()
        {
            SelectedEntry = ChangeLogEntryHandler.changeLogEntries.First();
        }

        public string UpdateIcoPath { get; set; }

        public ChangeLogEntryHandler ChangeLogEntryHandler { get; set; } = new ChangeLogEntryHandler();

        private ChangeLogEntry selectedEntry;

        public ChangeLogEntry SelectedEntry
        {
            get => selectedEntry;
            set
            {
                string path = WebPath.UPDATES_ICONS_PATH + value.Version + ".png";
                //if (!WebController.IsFileExist(path)) UpdateIcoPath = WebPath.UPDATES_ICONS_PATH + "nn.png";
                UpdateIcoPath = path;
                selectedEntry = value;
            }
        }

        public void SetNNIcon()
        {
            UpdateIcoPath = WebPath.UPDATES_ICONS_PATH + "nn.png";
        }
    }
}
