using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Dusts;
using Terraria.GameContent.Metadata;

namespace CalValEX.Tiles.AstralBlocks
{
    public class AstralSnowPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            //ItemDrop = ModContent.ItemType<AstralSnow>();
            DustType = ModContent.DustType<AstralDust>();
            AddMapEntry(new Color(243, 213, 245));
            Main.tileBlendAll[this.Type] = true;
            HitSound = SoundID.Item50;
            TileID.Sets.IcesSnow[Type] = true;
            TileID.Sets.ChecksForMerge[Type] = true;
            TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Snow"]);
            Main.tileMerge[Type][ModContent.TileType<AstralIcePlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<AstralDirtPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<AstralGrassPlaced>()] = true;
        }

        /*public override void ChangeWaterfallStyle(ref int style)
        {
            style = mod.GetWaterfallStyleSlot("AstralWaterfallStyle");
        }*/
    }
}