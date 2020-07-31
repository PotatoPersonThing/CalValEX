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
    internal class BelchingCoral : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sulphuric Coral");
            Tooltip
                .SetDefault("Don't put your bare hand into it");
		}

		public override void SetDefaults() {
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 99;
			item.consumable = true;
			item.createTile = ModContent.TileType<BelchingCoralPlaced>();
			item.width = 12;
			item.height = 12;
            item.rare = 5;
		}
}}