using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Walls
{
    public class PolishedXenomonolithWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            //ItemDrop = ModContent.ItemType<PolishedXenomonolithWall>();
            AddMapEntry(new Color(54, 13, 71));
        }
    }
}