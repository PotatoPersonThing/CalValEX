using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Walls
{
    public class AstralPearlWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            //ItemDrop = ModContent.ItemType<AstralPearlWall>();
            AddMapEntry(new Color(34, 102, 89));
        }
    }
}