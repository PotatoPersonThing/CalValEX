using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Astral
{
    public class AstralDirtPlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = ModContent.ItemType<AstralDirt>();
            AddMapEntry(new Color(40, 0, 50));
            Main.tileMerge[Type][mod.TileType("AstralGrassPlaced")] = true;
            Main.tileMerge[Type][mod.TileType("XenostonePlaced")] = true;
            Main.tileMerge[Type][mod.TileType("AstralClayPlaced")] = true;
            Main.tileMerge[Type][mod.TileType("AstralSandPlaced")] = true;
            Main.tileMerge[Type][mod.TileType("AstralHardenedSandPlaced")] = true;
            Main.tileMerge[Type][mod.TileType("AstralSandstonePlaced")] = true;
            Main.tileMerge[Type][ModLoader.GetMod("CalamityMod").TileType("AstralClay")] = true;
            Main.tileMerge[Type][ModLoader.GetMod("CalamityMod").TileType("AstralDirt")] = true;
            Main.tileMerge[Type][ModLoader.GetMod("CalamityMod").TileType("AstralStone")] = true;
            Main.tileMerge[Type][ModLoader.GetMod("CalamityMod").TileType("AstralSand")] = true;
            Main.tileMerge[Type][ModLoader.GetMod("CalamityMod").TileType("AstralSandstone")] = true;
            Main.tileMerge[Type][ModLoader.GetMod("CalamityMod").TileType("HardenedAstralSand")] = true;
            Main.tileMerge[Type][ModLoader.GetMod("CalamityMod").TileType("AstralGrass")] = true;
        }

        public override void ChangeWaterfallStyle(ref int style) {
			style = mod.GetWaterfallStyleSlot("AstralWaterfallStyle");
		}
    }
}