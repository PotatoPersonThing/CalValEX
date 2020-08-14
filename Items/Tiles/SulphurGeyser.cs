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

namespace CalValEX.Items.Tiles
{
	internal class SulphurGeyser : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Steam Geyser");
            Tooltip.SetDefault("Hazardous! Be careful!");
		}
		public override void SetDefaults() {
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 99;
			item.consumable = true;
			item.width = 16;
			item.height = 28;
            item.rare = 4;
			Mod calamityMod = ModLoader.GetMod("CalamityMod");
			if (calamityMod != null)
			{
				item.createTile = (calamityMod.TileType("SteamGeyser"));
			}
		}
	}
}