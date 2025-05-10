using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;

namespace CalValEX.Tiles.Blocks
{
    public class DarklightMushroomCapPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            AddMapEntry(new Color(2, 19, 46));
            DustType = DustID.GlowingMushroom;
            Main.tileMerge[Type][TileID.MushroomBlock] = true;
            Main.tileMerge[TileID.MushroomBlock][Type] = true;
            Main.tileMerge[Type][ModContent.TileType<MushroomCapPlaced>()] = true;
        }
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            CalValEXGlobalTile.TileGlowmask(i, j, ModContent.Request<Texture2D>("CalValEX/Tiles/Blocks/MushroomCapPlacedGlow").Value, spriteBatch);
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Color painted = CalValEXGlobalTile.GetDrawColour(i, j, new Color(0, 0, 1));
            r = painted.R;
            g = painted.G;
            b = painted.B;
        }
    }
}