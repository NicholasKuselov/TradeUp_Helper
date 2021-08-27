using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUpHelper.Constants
{
    class TradeUpHelperAPICalls
    {
        public static string FirstStart { get; } = "helper_pc_first_start";
        public static string AddSticker { get; } = "AddSticker";
        public static string GetStickerByRus { get; } = "get_sticker_by_rus";
        public static string RegisterProgram { get; } = "register_program";
        public static string CheckProgramKey { get; } = "check_program_key";
        public static string GetRarityPaintSeeds { get; } = "get_seeds";
        public static string GetUserMessages { get; } = "get_messages_for_users";
    }
}
