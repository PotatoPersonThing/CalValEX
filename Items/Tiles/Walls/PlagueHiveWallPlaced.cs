using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Walls
{
    public class PlagueHiveWallPlaced : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = ModContent.ItemType<PlagueHiveWall>();
            AddMapEntry(new Color(1, 92, 30));
        }
    }
}