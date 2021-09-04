using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CalValEX.Items.Walls;

namespace CalValEX.Walls
{
    public class ChiseledBloodstoneBrickWallPlaced : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = ModContent.ItemType<ChiseledBloodstoneBrickWall>();
            AddMapEntry(new Color(54, 14, 12));
        }
    }
}