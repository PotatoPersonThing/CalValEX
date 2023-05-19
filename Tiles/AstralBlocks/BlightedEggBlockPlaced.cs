using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Items.Tiles.Blocks;
using CalValEX.Dusts;

namespace CalValEX.Tiles.AstralBlocks
{
    public class BlightedEggBlockPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            //ItemDrop = ModContent.ItemType<BlightedEggBlock>();
            DustType = ModContent.DustType<AstralDust>();
            AddMapEntry(new Color(57, 69, 100));
            Main.tileBlendAll[this.Type] = true;
            HitSound = SoundID.Item50;
        }

        /*public override void ChangeWaterfallStyle(ref int style)
        {
            style = mod.GetWaterfallStyleSlot("AstralWaterfallStyle");
        }*/
    }
}