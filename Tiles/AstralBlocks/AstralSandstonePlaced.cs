using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Dusts;

namespace CalValEX.Tiles.AstralBlocks
{
    public class AstralSandstonePlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            TileID.Sets.Conversion.Sandstone[Type] = true;
            DustType = ModContent.DustType<AstralDust>();
            //ItemDrop = ModContent.ItemType<AstralSandstone>();
            AddMapEntry(new Color(78, 45, 91));
            Main.tileMerge[Type][ModContent.TileType<AstralSandPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<AstralHardenedSandPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<XenostonePlaced>()] = true;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        /*public override void ChangeWaterfallStyle(ref int style) {
			style = mod.GetWaterfallStyleSlot("AstralWaterfallStyle");
		}*/
    }
}