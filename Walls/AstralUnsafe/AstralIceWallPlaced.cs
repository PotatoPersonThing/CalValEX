using Terraria;
using Terraria.ModLoader;
using CalValEX.Dusts;

namespace CalValEX.Walls.AstralUnsafe
{
    public class AstralIceWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = false;
            AddMapEntry(new Color(37, 10, 38));
            DustType = ModContent.DustType<AstralDust>();
        }
    }
}