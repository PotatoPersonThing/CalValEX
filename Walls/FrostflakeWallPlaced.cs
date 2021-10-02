using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CalValEX.Items.Walls;

namespace CalValEX.Walls
{
    public class FrostflakeWallPlaced : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = ModContent.ItemType<FrostflakeWall>();
            AddMapEntry(new Color(7, 99, 133));
            dustType = 92;
        }
    }
}