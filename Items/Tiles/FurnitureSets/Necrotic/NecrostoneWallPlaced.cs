using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.FurnitureSets.Necrotic
{
    public class NecrostoneWallPlaced : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = ModContent.ItemType<NecrostoneWall>();
            AddMapEntry(new Color(108, 59, 16));
        }
    }
}