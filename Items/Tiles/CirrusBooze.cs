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
    internal class CirrusBooze : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("A Fine Chalice");
            Tooltip
                .SetDefault("'TimerFun'\n+" "A fine chalice indeed");
		}

		public override void SetDefaults() {
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 99;
			item.consumable = true;
			item.createTile = ModContent.TileType<CirrusBoozePlaced>();
			item.width = 12;
			item.height = 12;
            item.rare = 4;
		}
}}
