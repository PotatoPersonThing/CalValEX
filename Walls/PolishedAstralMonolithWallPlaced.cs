using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Walls
{
    public class PolishedAstralMonolithWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            //ItemDrop = ModContent.ItemType<PolishedAstralMonolithWall>();
            AddMapEntry(new Color(47, 30, 54));
        }
    }
}