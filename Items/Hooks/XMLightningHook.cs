using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.Hooks
{
    internal class XMLightningHook : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("XM-Lightning Hook");
            Tooltip.SetDefault("Snap at lightning speed!\nCannot be used while Chaos State is active\nReach: 60\nLaunch Velocity: 62\nPull Velocity: 35");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.StaticHook);
            item.shootSpeed = 62f;
            item.shoot = ProjectileType<THanosHook>();
            item.rare = 11;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.HasBuff(BuffID.ChaosState))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override bool UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            player.AddBuff(BuffID.ChaosState, 300);
            return true;
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
                    tooltipLine.overrideColor = new Color(108, 45, 199); //change the color accordingly to above
                }
            }
        }
    }
}