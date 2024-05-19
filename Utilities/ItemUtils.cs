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
        /// <summary>
        ///     Does the dirty work for the item name color. You use this in ModifyTooltips (Check BloodstoneBrick.cs for an
        ///     example)
        /// </summary>
        /// <param name="rare">Use CalamityRarity.[rarity name]</param>
        /// <param name="tooltips">tooltips</param>
        public static void CheckRarity(int rare, List<TooltipLine> tooltips)
        {
            //rarity 12 (Turquoise)
            //rarity 13 (Pure Green)
            //rarity 14 (Dark Blue)
            //rarity 15 (Violet)
            //rarity 16 (Hot Pink/Developer)
            //rarity 17 rainbow (no expert tag on item)
            //rarity 18 rare variant
            //rarity 19 dedicated(patron items)
            //look at https://calamitymod.gamepedia.com/Rarity to know where to use the colors

            //rarity 20 Our Dev things (dedicated??)

            //rarity 21 Draedon's Arsenal (Dark Orange)
            if (rare <= 11)
            {
                return;
            }

            Color color;

            switch (rare)
            {
                case CalamityRarity.Turquoise:
                    color = new Color(0, 255, 200); //Turquoise
                    break;

                case CalamityRarity.PureGreen:
                    color = new Color(0, 255, 0); //Pure Green
                    break;

                case CalamityRarity.DarkBlue:
                    color = new Color(43, 96, 222); //Dark Blue
                    break;

                case CalamityRarity.Violet:
                    color = new Color(108, 45, 199); //Violet
                    break;

                case 16:
                    color = new Color(255, 0, 255); //Hot Pink/Developer
                    break;

                case CalamityRarity.Rainbow:
                    color = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB); //rainbow (no expert tag on item)
                    break;

                case CalamityRarity.RareVariant:
                    color = new Color(255, 140, 0); //rare variant
                    break;

                case CalamityRarity.DedicatedCal:
                    color = new Color(139, 0, 0); //dedicated(patron items) (calamity)
                    break;

                case CalamityRarity.DedicatedEX:
                    color = new Color(107, 240, 255); //dedicated (CalValEX)
                    break;

                case CalamityRarity.DraedonsArsenal:
                    color = new Color(204, 71, 35); //Draedon's Arsenal (Dark Orange)
                    break;

                default:
                    color = Color.White;
                    break;
            }

            foreach (TooltipLine tooltipLine in tooltips)
                if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.OverrideColor = color;
                }
        }
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