using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeUpHelper.Models.TradeUpHelperAPI;
using TradeUpHelper.Views;

namespace TradeUpHelper.Controllers
{
    class UserMessagesController
    {
        private static List<MessageForUser> Querry = new List<MessageForUser>();
        private static MessageWindow messageWindow = null;

        public static void Show()
        {
            if (Querry.Count == 0)
            {
                return;
            }
            if (messageWindow != null)
            {
                messageWindow.Close();
            }
            messageWindow = new MessageWindow(Querry);
            messageWindow.Show();
           // Querry.Clear();
        }



        public static void Clear()
        {
            Querry.Clear();
        }

        public static void AddMessageInQuerry(string title,string text)
        {
            Querry.Add(new MessageForUser() {Title = title, Text = text });
        }

        public static void AddMessageInQuerry(MessageForUser messageForUser)
        {
            Querry.Add(messageForUser);
        }

        public static void AddMessageInQuerry(List<MessageForUser> messagesForUser)
        {
            Querry.AddRange(messagesForUser);
        }
    }
}
