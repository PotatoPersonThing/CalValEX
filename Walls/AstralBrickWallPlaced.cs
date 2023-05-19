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
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = false;
            AddMapEntry(new Color(37, 10, 38));
            DustType = ModContent.DustType<AstralDust>();
            //ItemDrop = ModContent.ItemType<AstralBrickWall>();
        }
    }
}