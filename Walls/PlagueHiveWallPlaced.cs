using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Walls
{
    public class PlagueHiveWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            //ItemDrop = ModContent.ItemType<PlagueHiveWall>();
            AddMapEntry(new Color(1, 92, 30));
        }
    }
}