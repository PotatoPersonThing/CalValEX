using Terraria;
using Terraria.ModLoader;
using CalValEX.Dusts;
using Terraria.ObjectData;

namespace CalValEX.Tiles.AstralMisc
{
    public class AstralPilesBig : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoFail[Type] = true;
            Main.tileObsidianKill[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.addTile(Type);
            DustType = ModContent.DustType<AstralDust>();
            AddMapEntry(new Color(217, 36, 64));
            base.SetStaticDefaults();
        }

        /*public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height)
        {
            offsetY = 2;
        }*/
    }
}
