using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Walls
{
    public class FrostflakeWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            //ItemDrop = ModContent.ItemType<FrostflakeWall>();
            AddMapEntry(new Color(7, 99, 133));
            DustType = 92;
        }
    }
}