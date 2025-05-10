using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Dusts;

namespace CalValEX.Walls.AstralUnsafe
{
    public class AstralSandstoneWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = false;
            AddMapEntry(new Color(37, 10, 38));
            WallID.Sets.Conversion.Sandstone[Type] = true;
            DustType = ModContent.DustType<AstralDust>();
        }
    }
}