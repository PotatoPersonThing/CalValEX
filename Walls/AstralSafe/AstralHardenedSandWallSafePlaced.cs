using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CalValEX.Dusts;

namespace CalValEX.Walls.AstralSafe
{
    public class AstralHardenedSandWallSafePlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            //ItemDrop = ModContent.ItemType<AstralHardenedSandWall>();
            AddMapEntry(new Color(37, 10, 38));
            DustType = ModContent.DustType<AstralDust>();
        }
    }
}