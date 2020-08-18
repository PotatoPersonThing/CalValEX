using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX;
using CalValEX.Items;
using CalValEX.Items.Tiles;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;

namespace CalValEX.Items
{
	public class Termipebbles : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Termipebbles");
			Tooltip.SetDefault("Used to craft Terminus-themed vanitites\n" + "'Do NOT eat.'");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
			ItemID.Sets.ItemNoGravity[item.type] = true;
			ItemID.Sets.ItemIconPulse[item.type] = false;
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 36;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.maxStack = 999;
			item.rare = ItemRarityID.Blue;
		}
	}
}
