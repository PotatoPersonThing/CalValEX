using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Dusts;

namespace CalValEX.Tiles.AstralBlocks
{
    public class AstralDirtPlaced : ModTile
    {
        [JITWhenModsEnabled("CalamityMod")]
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            //ItemDrop = ModContent.ItemType<AstralDirt>();
            DustType = ModContent.DustType<AstralDust>();
            AddMapEntry(new Color(40, 0, 50));
            TileID.Sets.CanBeDugByShovel[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<AstralGrassPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<XenostonePlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<AstralClayPlaced>()] = true;
        }

        /*public override void ChangeWaterfallStyle(ref int style) {
			style = mod.GetWaterfallStyleSlot("AstralWaterfallStyle");
		}*/
    }
}