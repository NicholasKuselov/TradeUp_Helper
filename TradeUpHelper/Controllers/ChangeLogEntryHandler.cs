using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TradeUpHelper.Constants;
using TradeUpHelper.Models;

namespace TradeUpHelper.Controllers
{
    class ChangeLogEntryHandler
    {
        public List<ChangeLogEntry> changeLogEntries { get; set; }
        
        public ChangeLogEntryHandler()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<ChangeLogEntry>));

            using (FileStream fs = new FileStream(FilePath.ChangeLogFilePath, FileMode.OpenOrCreate))
            {
                changeLogEntries = (List<ChangeLogEntry>)formatter.Deserialize(fs);
            }

            changeLogEntries.Reverse();
        }
    }
}
