using Terraria;
using Terraria.ModLoader;
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
