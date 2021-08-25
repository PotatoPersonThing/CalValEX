using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Items.Tiles.Blocks;
using CalValEX.Dusts;

namespace CalValEX.Tiles.AstralBlocks
{
    public class PolishedXenomonolithPlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = ModContent.ItemType<PolishedXenomonolith>();
            dustType = ModContent.DustType<AstralDust>();
            AddMapEntry(new Color(271, 49, 42));
            Main.tileBlendAll[this.Type] = true;
            soundType = SoundID.Item;
        }

        public override void ChangeWaterfallStyle(ref int style)
        {
            style = mod.GetWaterfallStyleSlot("AstralWaterfallStyle");
        }
    }
}