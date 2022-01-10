using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CalValEX.Items.Hooks
{
    public class MawHook : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cragmaw Spinehook");
            Tooltip.SetDefault("Prehistoric pull power!\nReach: 31\nLaunch Velocity: 18\nPull Velocity: 17");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.BatHook);
            item.shootSpeed = 18f;
            item.shoot = ProjectileType<MawTeeth>();
            item.rare = 5;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            //rarity 12 (Turquoise) = new Color(0, 255, 200)
            //rarity 13 (Pure Green) = new Color(0, 255, 0)
            //rarity 14 (Dark Blue) = new Color(43, 96, 222)
            //rarity 15 (Violet) = new Color(108, 45, 199)
            //rarity 16 (Hot Pink/Developer) = new Color(255, 0, 255)
            //rarity rainbow (no expert tag on item) = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB)
            //rarity rare variant = new Color(255, 140, 0)
            //rarity dedicated(patron items) = new Color(139, 0, 0)
            //look at https://calamitymod.gamepedia.com/Rarity to know where to use the colors
            foreach (TooltipLine tooltipLine in tooltips)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(0, 255, 0); //change the color accordingly to above
                }
            }
        }
    }
}