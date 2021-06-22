﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using TradeUpHelper.Constants;
using TradeUpHelper.Models;

namespace TradeUpHelper.Controllers
{
    class SettingController
    {
        public static string UserProfileId { get { return setting.UserProfileId; } }
        public static string UserInventoryURL { get { return setting.UserInventoryURL; } set {
                setting.UserInventoryURL = value;
                setting.UserProfileId = value.Split('/')[2];
                File.WriteAllText(FilePath.settingFile, JsonSerializer.Serialize(setting));
            } }

        private static Setting setting;

        public static void Load()
        {
            try
            {
                setting = JsonSerializer.Deserialize<Setting>(File.ReadAllText(FilePath.settingFile));
            }
            catch
            {
                // TODO: Добавить локализацию
                MessageBox.Show("error with loading setting");
                setting = new Setting();
                File.WriteAllText(FilePath.settingFile, JsonSerializer.Serialize(setting));
            }
        }

       
    }
}