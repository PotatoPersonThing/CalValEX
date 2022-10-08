using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.Hooks
{
    public class XMLightningHook : ModItem
    {
        public override void SetStaticDefaults() => SacrificeTotal = 1;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.StaticHook);
            Item.shootSpeed = 62f;
            Item.shoot = ProjectileType<THanosHook>();
            Item.rare = 11;
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

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.whoAmI == Main.myPlayer)
                player.AddBuff(BuffID.ChaosState, 300);
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
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
                if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.OverrideColor = new Color(108, 45, 199); //change the color accordingly to above
                }
            }
        }
    }
}