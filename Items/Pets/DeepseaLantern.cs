using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX;
using CalValEX.Items;
using CalValEX.Items.Hooks;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;
using CalValEX.Items.Pets;

namespace CalValEX.Items.Pets
{
    public class DeepseaLantern : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deep Sea Lantern");
            Tooltip.SetDefault("'Might call upon a creature looking for food'");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit13;
            item.shoot = mod.ProjectileType("FathomEelHead");
            item.value = Item.sellPrice(0, 0, 10, 0);
            item.rare = 6;
            item.buffType = mod.BuffType("FathomEelBuff");
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine tooltipLine in tooltips) 
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName") 
                    tooltipLine.overrideColor = new Color(107, 240, 255);
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
                type = mod.ProjectileType("FathomEelHead");
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            }
		}
    }

