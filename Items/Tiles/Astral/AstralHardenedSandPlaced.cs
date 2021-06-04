using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Astral
{
    public class AstralHardenedSandPlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            dustType = ModContent.DustType<AstralDust>();
            TileID.Sets.Conversion.HardenedSand[Type] = true; 
            drop = ModContent.ItemType<AstralHardenedSand>();
            AddMapEntry(new Color(88, 93, 134));
            Main.tileBlendAll[this.Type] = true;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void ChangeWaterfallStyle(ref int style) {
			style = mod.GetWaterfallStyleSlot("AstralWaterfallStyle");
		}
    }
}