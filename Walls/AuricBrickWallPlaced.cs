using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CalValEX.Items.Walls;

namespace CalValEX.Walls
{
    public class AuricBrickWallPlaced : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = ModContent.ItemType<AuricBrickWall>();
            AddMapEntry(new Color(117, 122, 23));
        }
    }
}