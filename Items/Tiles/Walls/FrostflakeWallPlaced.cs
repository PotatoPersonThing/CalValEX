using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Walls
{
    public class FrostflakeWallPlaced : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = ModContent.ItemType<FrostflakeWall>();
            AddMapEntry(new Color(66, 242, 245));
            dustType = 92;
        }
    }
}