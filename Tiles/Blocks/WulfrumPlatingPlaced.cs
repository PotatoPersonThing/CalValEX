using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;

namespace CalValEX.Tiles.Blocks
{
    public class WulfrumPlatingPlaced : ModTile {
		public override void SetStaticDefaults()  {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = false;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			
			HitSound = SoundID.Tink;
			//ItemDrop = ItemType<WulfrumPlating>();
			
			AddMapEntry(new Color(149, 222, 168));
		}

		public override void PostDraw(int i, int j, SpriteBatch spriteBatch) =>
			CalValEXGlobalTile.TileGlowmask(i, j, Request<Texture2D>("CalValEX/Tiles/Blocks/WulfrumPlatingPlaced_Glow").Value, spriteBatch);
	}
}