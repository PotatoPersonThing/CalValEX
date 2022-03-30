using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using CalValEX.Dusts;
using Terraria.ModLoader;

namespace CalValEX.Tiles.AstralMisc
{
    public class AstralStalactites : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoFail[Type] = true;
            Main.tileObsidianKill[Type] = true;
            Main.tileBlockLight[Type] = true;



            DustType = ModContent.DustType<AstralDust>();
            AddMapEntry(new Color(217, 36, 64));
            base.SetStaticDefaults();
        }

        /*public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height)
        {
            Tile tile = Main.tile[i, j];
            if (tile.frameY <= 18 || tile.frameY == 72)
            {
                offsetY = -2;
            }
            else if ((tile.frameY >= 36 && tile.frameY <= 54) || tile.frameY == 90)
            {
                offsetY = 2;
            }
        }*/

        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            WorldGen.CheckTight(i, j);
            return false;
        }
    }
}
