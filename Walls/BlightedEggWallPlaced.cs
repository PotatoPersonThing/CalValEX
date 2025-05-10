using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Walls
{
    public class BlightedEggWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            //ItemDrop = ModContent.ItemType<BlightedEggWall>();
            AddMapEntry(new Color(176, 39, 160));
        }
    }
}