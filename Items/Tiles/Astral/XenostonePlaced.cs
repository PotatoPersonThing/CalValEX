using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Astral
{
    public class XenostonePlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            TileID.Sets.Conversion.Stone[Type] = true; 
            TileID.Sets.Stone[Type] = true;
            drop = ModContent.ItemType<Xenostone>();
            dustType = ModContent.DustType<AstralDust>();
            soundType = SoundID.Tink;
            AddMapEntry(new Color(83, 55, 109));
            Main.tileMerge[Type][TileID.Dirt] = true;
            Main.tileMerge[Type][TileID.Stone] = true;
            Main.tileMerge[Type][TileID.Sand] = true;
            Main.tileMerge[Type][TileID.HardenedSand] = true;
            Main.tileMerge[Type][TileID.Sandstone] = true;
            Main.tileMerge[Type][TileID.Copper] = true;
            Main.tileMerge[Type][TileID.Tin] = true;
            Main.tileMerge[Type][TileID.Silver] = true;
            Main.tileMerge[Type][TileID.Lead] = true;
            Main.tileMerge[Type][TileID.Iron] = true;
            Main.tileMerge[Type][TileID.Tungsten] = true;
            Main.tileMerge[Type][TileID.Gold] = true;
            TileID.Sets.ChecksForMerge[Type] = true;
            Main.tileMerge[Type][TileID.Platinum] = true;
            Main.tileMerge[Type][TileID.Cobalt] = true;
            Main.tileMerge[Type][TileID.Palladium] = true;
            Main.tileMerge[Type][TileID.Mythril] = true;
            Main.tileMerge[Type][TileID.Orichalcum] = true;
            Main.tileMerge[Type][TileID.Adamantite] = true;
            Main.tileMerge[Type][TileID.Titanium] = true;
            Main.tileMerge[Type][TileID.Obsidian] = true;
            Main.tileMerge[Type][TileID.LivingWood] = true;
            Main.tileMerge[Type][TileID.LeafBlock] = true;
            Main.tileMerge[Type][TileID.Mud] = true;
            Main.tileMerge[Type][mod.TileType("AstralDirtPlaced")] = true;
            Main.tileMerge[Type][mod.TileType("AstralClayPlaced")] = true;
            Main.tileMerge[Type][mod.TileType("XenostonePlaced")] = true;
            Main.tileMerge[Type][mod.TileType("AstralSandPlaced")] = true;
            Main.tileMerge[Type][mod.TileType("AstralSandstonePlaced")] = true;
            Main.tileMerge[Type][mod.TileType("AstralIcePlaced")] = true;
            Main.tileMerge[Type][mod.TileType("AstralHardenedSandPlaced")] = true;
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