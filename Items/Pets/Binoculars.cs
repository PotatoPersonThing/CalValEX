using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using CalValEX;

namespace CalValEX.Items.Pets {
	public class Binoculars : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Astral Binoculars");
			Tooltip.SetDefault("You can see something in the distance");
		}

		public override void SetDefaults() {
		item.CloneDefaults(ItemID.ZephyrFish);
		item.UseSound = SoundID.Item4;
		item.shoot = mod.ProjectileType("SeerS");
		item.value = Item.sellPrice(0, 10, 0, 0);
		item.rare = ItemRarityID.Lime;
		item.buffType = mod.BuffType("SeerBuff");
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}

		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
                type = mod.ProjectileType("SeerS");
		    	return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
                type = mod.ProjectileType("SeerM");
                return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
                type = mod.ProjectileType("SeerL");
                return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
	}
}
