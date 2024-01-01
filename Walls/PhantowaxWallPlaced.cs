using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Walls
{
    public class PhantowaxWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            //ItemDrop = ModContent.ItemType<PhantowaxWall>();
            AddMapEntry(new Color(232, 39, 30));
        }
    }
}