using Terraria;
using Terraria.ModLoader;
using CalValEX.Dusts;
using Terraria.ObjectData;

namespace CalValEX.Tiles.AstralMisc
{
    public class AstralPilesSmall : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoFail[Type] = true;
            Main.tileObsidianKill[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.addTile(Type);
            DustType = ModContent.DustType<AstralDust>();
            AddMapEntry(new Color(217, 36, 64));
            base.SetStaticDefaults();
        }
    }
}
