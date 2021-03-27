using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Astral
{
    public class AstralSandstonePlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            TileID.Sets.Conversion.Sandstone[Type] = true;
            dustType = ModContent.DustType<AstralDust>();
            drop = ModContent.ItemType<AstralSandstone>();
            AddMapEntry(new Color(78, 45, 91));
            Main.tileMerge[Type][TileID.Dirt] = true;
            Main.tileMerge[Type][TileID.FossilOre] = true;
            Main.tileMerge[Type][TileID.Sand] = true;
            Main.tileMerge[Type][TileID.HardenedSand] = true;
            Main.tileMerge[Type][TileID.Sandstone] = true;
            Main.tileMerge[Type][mod.TileType("AstralDirtPlaced")] = true;
            Main.tileMerge[Type][mod.TileType("XenostonePlaced")] = true;
            Main.tileMerge[Type][mod.TileType("AstralClayPlaced")] = true;
            Main.tileMerge[Type][mod.TileType("AstralSandPlaced")] = true;
            Main.tileMerge[Type][mod.TileType("AstralHardenedSandPlaced")] = true;
            Main.tileMerge[Type][mod.TileType("AstralIcePlaced")] = true;
            Main.tileMerge[Type][ModLoader.GetMod("CalamityMod").TileType("AstralClay")] = true;
            Main.tileMerge[Type][ModLoader.GetMod("CalamityMod").TileType("AstralDirt")] = true;
            Main.tileMerge[Type][ModLoader.GetMod("CalamityMod").TileType("AstralStone")] = true;
            Main.tileMerge[Type][ModLoader.GetMod("CalamityMod").TileType("AstralSand")] = true;
            Main.tileMerge[Type][ModLoader.GetMod("CalamityMod").TileType("AstralSandstone")] = true;
            Main.tileMerge[Type][ModLoader.GetMod("CalamityMod").TileType("HardenedAstralSand")] = true;
            Main.tileMerge[Type][ModLoader.GetMod("CalamityMod").TileType("AstralGrass")] = true;
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