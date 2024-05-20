using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX
{
    public class CalamityRarity
    {
        public const int Turquoise = 12;
        public const int PureGreen = 13;
        public const int DarkBlue = 14;
        public const int Violet = 15;
        public const int HotPink = 16;
        public const int Developer = 16;
        public const int Rainbow = 17;
        public const int RareVariant = 18;
        public const int DedicatedCal = 19;
        public const int DedicatedEX = 20;
        public const int DraedonsArsenal = 21;
    }

    public class ItemUtils
    {
        public static int BossRarity(string type)
        {
            switch (type)
            {
                case "Preboss":
                case "Pre-Hardmode":
                case "Prehardmode":
                    return 1;
                case "DesertScourge":
                case "Desert Scourge":
                case "DS":
                    return 2;
                case "Crabulon":
                case "Crab":
                    return 2;
                case "HiveMind":
                case "Hive Mind":
                case "The Hive Mind":
                case "TheHiveMind":
                    return 3;
                case "Perforators":
                case "Perforator":
                    return 3;
                case "SlimeGod":
                case "TheSlimeGod":
                case "SG":
                    return 4;
                case "Hardmode":
                case "Hard Mode":
                    return 5;
                case "Cryogen":
                    return 5;
                case "AquaticScourge":
                case "Aquatic Scourge":
                case "AS":
                    return 5;
                case "BrimstoneElemental":
                case "Brimstone Elemental":
                case "Brimmy":
                    return 5;
                case "Clonelamitas":
                case "Calamitas":
                case "Calamitas Clone":
                case "Cal":
                    return 7;
                case "AstrumAureus":
                case "Astrum Aureus":
                case "Aureus":
                    return 7;
                case "Leviathan":
                case "Anahita":
                case "Levi":
                case "Ana":
                case "Siren":
                    return 7;
                case "PBG":
                case "PlaguebringerGoliath":
                case "ThePlaguebringerGoliath":
                case "The Plaguebringer Goliath":
                case "Plaguebringer Goliath":
                    return 8;
                case "Ravager":
                    return 8;
                case "AstrumDeus":
                case "Astrum Deus":
                case "Deus":
                case "AD":
                    return 9;
                default: 
                    return 11;
            }
        }
    }
}