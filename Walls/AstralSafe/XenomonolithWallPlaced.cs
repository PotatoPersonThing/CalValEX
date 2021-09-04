using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CalValEX.Items.Walls.Astral;

namespace CalValEX.Walls.AstralSafe
{
    public class XenomonolithWallPlaced : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = ModContent.ItemType<XenomonolithWall>();
            AddMapEntry(new Color(22, 11, 26));
        }
    }
}