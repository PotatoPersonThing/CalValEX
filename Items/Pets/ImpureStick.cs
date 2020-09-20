using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using CalValEX;

namespace CalValEX.Items.Pets 
{
	public class ImpureStick : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Slime Deity's Soul");
			Tooltip.SetDefault("'Power hungry for rot'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4,6));
		    ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults() {
	    item.width = 30;
	    item.height = 34;
		item.UseSound = SoundID.Item81;
		item.shoot = mod.ProjectileType("SlimeDemi");
		item.value = Item.sellPrice(0, 5, 10, 0);
		item.rare = 3;
		item.buffType = mod.BuffType("SlimeBuff");
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}

		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        	{
                type = mod.ProjectileType("SlimeDemi");
		    	return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            	}
	}
}
