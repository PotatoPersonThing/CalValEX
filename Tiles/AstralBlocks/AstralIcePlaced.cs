using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Dusts;

namespace CalValEX.Tiles.AstralBlocks
{
    public class AstralIcePlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            //ItemDrop = ModContent.ItemType<AstralIce>();
            DustType = ModContent.DustType<AstralDust>();
            AddMapEntry(new Color(232, 135, 249));
            Main.tileBlendAll[this.Type] = true;
            HitSound = SoundID.Item50;
            TileID.Sets.Ices[Type] = true;
            TileID.Sets.IcesSlush[Type] = true;
            TileID.Sets.IcesSnow[Type] = true;
            TileID.Sets.ChecksForMerge[Type] = true;
            TileID.Sets.Conversion.Ice[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<AstralSnowPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<AstralDirtPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<AstralGrassPlaced>()] = true;
        }

        /*public override void ChangeWaterfallStyle(ref int style)
        {
            style = mod.GetWaterfallStyleSlot("AstralWaterfallStyle");
        }*/
    }
}