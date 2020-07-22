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

namespace CalValEX.Items.Mounts
{
	public class FloatyCarpetItem : ModItem
	{
		public override void SetStaticDefaults() {
			 DisplayName.SetDefault("Floaty Carpet");
			Tooltip.SetDefault("A floating carpet made out of a Floaty!");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.value = Item.sellPrice(0, 1, 10, 0);
			item.rare = 2;
			//item.UseSound = SoundID.Item23;
			item.noMelee = true;
			item.mountType = mod.MountType("FloatyCarpet");
		}
	}
}