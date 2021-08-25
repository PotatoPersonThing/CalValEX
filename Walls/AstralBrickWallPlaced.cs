using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Walls;
using CalValEX.Dusts;

namespace CalValEX.Walls
{
    public class AstralBrickWallPlaced : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = false;
            AddMapEntry(new Color(37, 10, 38));
            dustType = ModContent.DustType<AstralDust>();
            drop = ModContent.ItemType<AstralBrickWall>();
        }
    }
}