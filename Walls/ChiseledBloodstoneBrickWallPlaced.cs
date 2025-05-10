using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Walls
{
    public class ChiseledBloodstoneBrickWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            //ItemDrop = ModContent.ItemType<ChiseledBloodstoneBrickWall>();
            AddMapEntry(new Color(54, 14, 12));
        }
    }
}