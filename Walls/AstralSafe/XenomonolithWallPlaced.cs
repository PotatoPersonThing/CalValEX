using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Walls.AstralSafe
{
    public class XenomonolithWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            //ItemDrop = ModContent.ItemType<XenomonolithWall>();
            AddMapEntry(new Color(22, 11, 26));
        }
    }
}