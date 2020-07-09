using System.Drawing;
using System.Linq;

namespace AmeisenBotX.Rcon.Utils
{
    public class RconUtils
    {
        private static readonly Color dkPrimaryBrush = Color.FromArgb(255, 196, 30, 59);
        private static readonly Color dkSecondaryBrush = Color.FromArgb(255, 0, 209, 255);

        private static readonly Color druidPrimaryBrush = Color.FromArgb(255, 255, 125, 10);
        private static readonly Color druidSecondaryBrush = Color.FromArgb(255, 0, 0, 255);

        private static readonly Color hunterPrimaryBrush = Color.FromArgb(255, 171, 212, 115);
        private static readonly Color hunterSecondaryBrush = Color.FromArgb(255, 0, 0, 255);

        private static readonly Color magePrimaryBrush = Color.FromArgb(255, 105, 204, 240);
        private static readonly Color mageSecondaryBrush = Color.FromArgb(255, 0, 0, 255);

        private static readonly Color paladinPrimaryBrush = Color.FromArgb(255, 245, 140, 186);
        private static readonly Color paladinSecondaryBrush = Color.FromArgb(255, 0, 0, 255);

        private static readonly Color priestPrimaryBrush = Color.FromArgb(255, 255, 255, 255);
        private static readonly Color priestSecondaryBrush = Color.FromArgb(255, 0, 0, 255);

        private static readonly Color roguePrimaryBrush = Color.FromArgb(255, 255, 245, 105);
        private static readonly Color rogueSecondaryBrush = Color.FromArgb(255, 255, 255, 0);

        private static readonly Color shamanPrimaryBrush = Color.FromArgb(255, 0, 112, 222);
        private static readonly Color shamanSecondaryBrush = Color.FromArgb(255, 0, 0, 255);

        private static readonly Color warlockPrimaryBrush = Color.FromArgb(255, 148, 130, 201);
        private static readonly Color warlockSecondaryBrush = Color.FromArgb(255, 0, 0, 255);

        private static readonly Color warriorPrimaryBrush = Color.FromArgb(255, 199, 156, 110);
        private static readonly Color warriorSecondaryBrush = Color.FromArgb(255, 255, 0, 0);

        public static string Capitalize(string input)
        {
            return input == null ? string.Empty : input.First().ToString().ToUpper() + input.Substring(1);
        }

        public static string GetPrimaryColorByClass(string className)
        {
            return className.ToUpper() switch
            {
                "DEATHKNIGHT" => ColorTranslator.ToHtml(dkPrimaryBrush),
                "DRUID" => ColorTranslator.ToHtml(druidPrimaryBrush),
                "HUNTER" => ColorTranslator.ToHtml(hunterPrimaryBrush),
                "MAGE" => ColorTranslator.ToHtml(magePrimaryBrush),
                "PALADIN" => ColorTranslator.ToHtml(paladinPrimaryBrush),
                "PRIEST" => ColorTranslator.ToHtml(priestPrimaryBrush),
                "ROGUE" => ColorTranslator.ToHtml(roguePrimaryBrush),
                "SHAMAN" => ColorTranslator.ToHtml(shamanPrimaryBrush),
                "WARLOCK" => ColorTranslator.ToHtml(warlockPrimaryBrush),
                "WARRIOR" => ColorTranslator.ToHtml(warriorPrimaryBrush),
                null => "#fff",
                _ => "#fff"
            };
        }

        public static string GetSecondaryColorByClass(string className)
        {
            return className.ToUpper() switch
            {
                "DEATHKNIGHT" => ColorTranslator.ToHtml(dkSecondaryBrush),
                "DRUID" => ColorTranslator.ToHtml(druidSecondaryBrush),
                "HUNTER" => ColorTranslator.ToHtml(hunterSecondaryBrush),
                "MAGE" => ColorTranslator.ToHtml(mageSecondaryBrush),
                "PALADIN" => ColorTranslator.ToHtml(paladinSecondaryBrush),
                "PRIEST" => ColorTranslator.ToHtml(priestSecondaryBrush),
                "ROGUE" => ColorTranslator.ToHtml(rogueSecondaryBrush),
                "SHAMAN" => ColorTranslator.ToHtml(shamanSecondaryBrush),
                "WARLOCK" => ColorTranslator.ToHtml(warlockSecondaryBrush),
                "WARRIOR" => ColorTranslator.ToHtml(warriorSecondaryBrush),
                null => "#fff",
                _ => "#fff"
            };
        }
    }
}