using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CalValEX.Items.Tiles.Blocks;
using Microsoft.Xna.Framework.Graphics;

namespace CalValEX.Tiles.Blocks
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
        }
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            CalValEXGlobalTile.TileGlowmask(i, j, ModContent.GetTexture("CalValEX/Tiles/Blocks/EidolicSlabPlaced_Glow"), spriteBatch);
        }
    }
}