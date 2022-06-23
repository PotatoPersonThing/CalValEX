using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CalValEX.Items.Walls;

namespace CalValEX.Walls
{
    public class PolishedXenomonolithWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            ItemDrop = ModContent.ItemType<PolishedXenomonolithWall>();
            AddMapEntry(new Color(54, 13, 71));
        }
    }
}