using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Items.Tiles.Blocks.Astral;
using CalValEX.Tiles.AstralMisc;
using CalValEX.Dusts;

namespace CalValEX.Tiles.AstralBlocks
{
    public class AstralSnowPlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = ModContent.ItemType<AstralSnow>();
            dustType = ModContent.DustType<AstralDust>();
            AddMapEntry(new Color(243, 213, 245));
            Main.tileBlendAll[this.Type] = true;
            soundType = SoundID.Item;
            soundStyle = 50;
            SetModTree(new SnowAstralTree());
            TileID.Sets.IcesSnow[Type] = true;
            TileID.Sets.ChecksForMerge[Type] = true;
        }

        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<SnowAstralSapling>();
        }

        public override void ChangeWaterfallStyle(ref int style)
        {
            style = mod.GetWaterfallStyleSlot("AstralWaterfallStyle");
        }
    }
}