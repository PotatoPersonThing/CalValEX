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
    internal class AstrumAureusLog : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Astrum Aureus Blueprint");
            Tooltip
                .SetDefault("Do Not Distribute");
		}

		public override void SetDefaults() {
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 99;
			item.consumable = true;
			item.createTile = ModContent.TileType<AstrumAureusLogPlaced>();
			item.width = 46;
			item.height = 32;
            item.rare = 7;
		}
	}
}