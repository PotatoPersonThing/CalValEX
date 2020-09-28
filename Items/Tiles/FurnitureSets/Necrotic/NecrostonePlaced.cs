using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX;
using CalValEX.Items.Tiles;

namespace CalValEX.Items.Tiles.FurnitureSets.Necrotic
{
	public class NecrostonePlaced : ModTile
	{
		public override void SetDefaults() 
        {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = false;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			drop = ModContent.ItemType<Necrostone>();
			AddMapEntry(new Color(108, 59, 16));
			//SetModTree(new Trees.ExampleTree());
		}


		//public override int SaplingGrowthType(ref int style) {
			//style = 0;
			//return TileType<ExampleSapling>();
		//}
	}
}