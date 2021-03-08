using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX;
using CalValEX.Items.Tiles;

namespace CalValEX.Items.Tiles.FurnitureSets.Wulfrum
{
	public class WulfrumPlatingPlaced : ModTile
	{
		public override void SetDefaults() 
        {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = false;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			soundType = SoundID.Tink;
			drop = ModContent.ItemType<WulfrumPlating>();
			AddMapEntry(new Color(149, 222, 168));
		}
	}
}