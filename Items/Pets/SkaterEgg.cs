using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using CalValEX;

namespace CalValEX.Items.Pets {
	public class SkaterEgg : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Acid Lamp");
			Tooltip.SetDefault("'There seems to be an egg inside'");
		}

		public override void SetDefaults() {
		item.CloneDefaults(ItemID.ZephyrFish);
		item.UseSound = SoundID.Item112;
		item.shoot = mod.ProjectileType("SkaterPet");
		item.value = Item.sellPrice(0, 0, 10, 0);
		item.rare = 5;
		item.buffType = mod.BuffType("SkaterBuff");
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}