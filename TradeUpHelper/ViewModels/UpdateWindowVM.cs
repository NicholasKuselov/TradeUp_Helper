using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TradeUpHelper.Constants;
using TradeUpHelper.Models;

namespace TradeUpHelper.ViewModels
{
    class UpdateWindowVM : ViewModelBase
    {
        public string UpdateIcoPath { get; set; }
        public ChangeLogEntry ChangeLog { get; set; }

        public UpdateWindowVM(ChangeLogEntry changeLog)
        {
            ChangeLog = changeLog;
            UpdateIcoPath = WebPath.UPDATES_ICONS_PATH + ChangeLog.Version + ".png";
        }

        public UpdateWindowVM()
        {
            ChangeLog = new ChangeLogEntry() { Version = "error", Description = "error" };
            SetNNIcon();
        }

        public void SetNNIcon()
        {
            UpdateIcoPath = WebPath.UPDATES_ICONS_PATH + "nn.png";
        }

        
    }
}
