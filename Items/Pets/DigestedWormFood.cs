using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using CalValEX;

namespace CalValEX.Items.Pets {
	public class DigestedWormFood : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Digested Worm Food");
			Tooltip.SetDefault("May contain worms");
		}

		public override void SetDefaults() {
		item.CloneDefaults(ItemID.ZephyrFish);
		item.UseSound = SoundID.NPCHit9;
		item.shoot = mod.ProjectileType("Fistuloid");
		item.value = Item.sellPrice(0, 1, 0, 0);
		item.rare = 3;
		item.buffType = mod.BuffType("FistuloidBuff");
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}