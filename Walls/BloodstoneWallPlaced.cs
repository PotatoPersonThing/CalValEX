using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Walls
{
    public class BloodstoneWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            //ItemDrop = ModContent.ItemType<BloodstoneWall>();
            AddMapEntry(new Color(108, 59, 16));
        }
    }
}