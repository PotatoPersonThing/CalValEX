using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Tiles.Astral
{
    public class AstralTreeWoodPlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            dustType = ModContent.DustType<AstralDust>();
            drop = ModContent.ItemType<AstralTreeWood>();
            AddMapEntry(new Color(78, 45, 91));
            Main.tileMerge[Type][mod.TileType("AstralDirtPlaced")] = true;
            Main.tileMerge[Type][mod.TileType("XenostonePlaced")] = true;
            Main.tileMerge[Type][mod.TileType("AstralSandPlaced")] = true;
            Main.tileMerge[Type][mod.TileType("AstralIcePlaced")] = true;
            Main.tileMerge[Type][ModLoader.GetMod("CalamityMod").TileType("AstralClay")] = true;
            Main.tileMerge[Type][ModLoader.GetMod("CalamityMod").TileType("AstralDirt")] = true;
            Main.tileMerge[Type][ModLoader.GetMod("CalamityMod").TileType("AstralStone")] = true;
            Main.tileMerge[Type][ModLoader.GetMod("CalamityMod").TileType("AstralSand")] = true;
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
            Main.tileMerge[Type][TileID.Platinum] = true;
            Main.tileMerge[Type][TileID.Cobalt] = true;
            Main.tileMerge[Type][TileID.Palladium] = true;
            Main.tileMerge[Type][TileID.LivingWood] = true;
            Main.tileMerge[Type][TileID.LeafBlock] = true;
            Main.tileMerge[Type][TileID.Mud] = true;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void ChangeWaterfallStyle(ref int style)
        {
            style = mod.GetWaterfallStyleSlot("AstralWaterfallStyle");
        }
    }
}