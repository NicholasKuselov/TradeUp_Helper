using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeUpHelper.Constants;
using TradeUpHelper.Models.TradeUpHelperAPI;

namespace TradeUpHelper.Controllers
{
    class UserMessagesFromAPIController
    {
        List<MessageForUser> MessagesForUsers;
        List<MessageForUser> UnreadMessagesForUsers;

        public UserMessagesFromAPIController()
        {
            MessagesForUsers = TradeUpHelperAPI.GetMessagesForUser().messages;
            UnreadMessagesForUsers = new List<MessageForUser>();
        }

        public bool IsUnreadMessagesEnable()
        {
            UnreadMessagesForUsers = MessagesForUsers.FindAll(message => message.Id > SettingController.LastReadMessageId);
            if (UnreadMessagesForUsers.Count>0)
            {
                UserMessagesController.AddMessageInQuerry(UnreadMessagesForUsers);
                SettingController.LastReadMessageId = MessagesForUsers.Last().Id;
                return true;
            }
            return false;
        }

        
    }
}
