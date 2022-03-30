using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Walls.Astral;
using CalValEX.Dusts;

namespace CalValEX.Walls.AstralUnsafe
{
    public class XenostoneWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = false;
            AddMapEntry(new Color(37, 10, 38));
            WallID.Sets.Conversion.Stone[Type] = true;
            DustType = ModContent.DustType<AstralDust>();
        }
    }
}