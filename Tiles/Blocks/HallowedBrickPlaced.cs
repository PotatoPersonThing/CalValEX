using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX;
using CalValEX.Items.Tiles;
using CalValEX.Items.Tiles.Blocks;

namespace CalValEX.Tiles.Blocks
{
	public class HallowedBrickPlaced : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = false;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			soundType = SoundID.Tink;
			drop = ModContent.ItemType<HallowedBrick>();
			AddMapEntry(new Color(200, 209, 157));
		}
	}
}