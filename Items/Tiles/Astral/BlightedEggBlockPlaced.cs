using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Tiles.Astral
{
    public class BlightedEggBlockPlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = ModContent.ItemType<BlightedEggBlock>();
            dustType = ModContent.DustType<AstralDust>();
            AddMapEntry(new Color(57, 69, 100));
            Main.tileBlendAll[this.Type] = true;
            soundType = SoundID.Item;
            soundStyle = 50;
        }

        public override void ChangeWaterfallStyle(ref int style)
        {
            style = mod.GetWaterfallStyleSlot("AstralWaterfallStyle");
        }
    }
}