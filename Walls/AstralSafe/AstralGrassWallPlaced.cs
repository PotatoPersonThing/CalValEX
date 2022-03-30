using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Walls.Astral;
using CalValEX.Dusts;

namespace CalValEX.Walls.AstralSafe
{
    public class AstralGrassWallPlaced : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            ItemDrop = ModContent.ItemType<AstralGrassWall>();
            AddMapEntry(new Color(207, 85, 192));
            DustType = ModContent.DustType<AstralDust>();
            SoundType = SoundID.Grass;
        }
    }
}