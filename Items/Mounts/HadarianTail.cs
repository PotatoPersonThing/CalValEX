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
	public class HadarianTail : ModItem
	{
		public override void SetStaticDefaults() {
			 DisplayName.SetDefault("Hadarian Tail");
			Tooltip.SetDefault("An infected scavenger may aid you for this");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.value = Item.sellPrice(0, 10, 50, 0);
			item.rare = 7;
			//item.UseSound = SoundID.Item23;
			item.noMelee = true;
			item.mountType = mod.MountType("HadarianMount");
		}
	}
}