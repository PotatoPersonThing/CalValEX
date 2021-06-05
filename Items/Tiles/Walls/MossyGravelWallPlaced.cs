using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Walls
{
    public class MossyGravelWallPlaced : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = ModContent.ItemType<MossyGravelWall>();
            AddMapEntry(new Color(0, 0, 0));
        }
    }
}