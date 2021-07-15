using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeUpHelper.Controllers;
using TradeUpHelper.Models;

namespace TradeUpHelper.ViewModels
{
    class ChangeLogWindowVM : ViewModelBase
    {
        public ChangeLogWindowVM()
        {
            SelectedEntry = ChangeLogEntryHandler.changeLogEntries.Last();
        }

        public ChangeLogEntryHandler ChangeLogEntryHandler { get; set; } = new ChangeLogEntryHandler();

        public ChangeLogEntry SelectedEntry { get; set; }
    }
}
