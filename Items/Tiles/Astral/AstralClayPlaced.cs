using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Tiles.Astral
{
    public class AstralClayPlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            dustType = ModContent.DustType<AstralDust>();
            drop = ModContent.ItemType<AstralClay>();
            AddMapEntry(new Color(78, 45, 91));
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