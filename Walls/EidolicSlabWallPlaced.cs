using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Walls
{
    public class EidolicSlabWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            //ItemDrop = ModContent.ItemType<EidolicSlabWall>();
            AddMapEntry(new Color(3, 1, 33));
        }
    }
}