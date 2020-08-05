using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX;
using CalValEX.Items.Tiles.Astral;

namespace CalValEX.Items.Tiles.Astral
{
	public class AstralDirtPlaced : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			drop = ModContent.ItemType<AstralDirt>();
			AddMapEntry(new Color(40, 0, 50));
			//SetModTree(new Trees.ExampleTree());
		}


		//public override int SaplingGrowthType(ref int style) {
			//style = 0;
			//return TileType<ExampleSapling>();
		//}
	}
}