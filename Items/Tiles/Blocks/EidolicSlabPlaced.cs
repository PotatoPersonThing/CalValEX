using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX;
using CalValEX.Items.Tiles;

namespace CalValEX.Items.Tiles.Blocks
{
	public class EidolicSlabPlaced : ModTile
	{
		public override void SetDefaults() 
        {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = false;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			drop = ModContent.ItemType<EidolicSlab>();
			AddMapEntry(new Color(0, 76, 82));
            dustType = 187;
			minPick = 275;
		}
	}
}