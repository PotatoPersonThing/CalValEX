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

namespace CalValEX.Items.Tiles.Balloons
{
    internal class TiedMirageBalloon : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Tied Mirage Balloon");
		}

		public override void SetDefaults() {
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 99;
			item.consumable = true;
			item.createTile = ModContent.TileType<TiedMirageBalloonPlaced>();
			item.width = 16;
			item.height = 40;
            item.rare = 4;
		}
}}