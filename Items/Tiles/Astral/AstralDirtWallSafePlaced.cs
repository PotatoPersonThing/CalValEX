using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Astral
{
    public class AstralDirtWallSafePlaced : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = ModContent.ItemType<AstralDirtWall>();
            AddMapEntry(new Color(37, 10, 38));
            dustType = ModContent.DustType<AstralDust>();
        }
    }
}