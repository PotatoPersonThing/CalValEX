using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Astral
{
    public class AstralGrassWallPlaced : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = ModContent.ItemType<AstralGrassWall>();
            AddMapEntry(new Color(207, 85, 192));
            dustType = ModContent.DustType<AstralDust>();
            soundType = SoundID.Grass;
        }
    }
}