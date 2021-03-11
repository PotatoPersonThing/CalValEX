using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Astral
{
	public class AstralGrassPlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = true;
            drop = ModContent.ItemType<AstralDirt>();
            AddMapEntry(new Color(40, 0, 50));
            TileID.Sets.Grass[Type] = true;
            TileID.Sets.Conversion.Grass[Type] = true;
            TileID.Sets.NeedsGrassFraming[Type] = true;
            TileID.Sets.NeedsGrassFramingDirt[Type] = mod.TileType("AstralDirtPlaced");
            //SetModTree(new AstralTree());
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            Main.tile[i, j].type = (ushort)ModContent.TileType<AstralDirtPlaced>();
        }

        /*public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<AstralTreeSapling>();
        }*/
    }
}
