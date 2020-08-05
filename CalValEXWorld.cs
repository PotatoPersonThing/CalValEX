using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Tiles;
using CalValEX.Items.Tiles.Astral;

namespace CalValEX
{
	public class CalValEXWorld : ModWorld
	{
		public static int astralTiles;




public override void ResetNearbyTileEffects() {
			CalValEXPlayer modPlayer = Main.LocalPlayer.GetModPlayer<CalValEXPlayer>();
			astralTiles = 0;
		}

		public override void TileCountsAvailable(int[] tileCounts) {
			// Here we count various tiles towards ZoneAstral
			astralTiles = tileCounts[TileType<Helplaced>()] + tileCounts[TileType<HesfinePlaced>()] + + tileCounts[TileType<AstralDirtPlaced>()];
        }
    }
}
