using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Astral
{
    public class XenostoneWallPlaced : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = false;
            AddMapEntry(new Color(37, 10, 38));
            WallID.Sets.Conversion.Stone[Type] = true;
            dustType = ModContent.DustType<AstralDust>();
        }
    }
}