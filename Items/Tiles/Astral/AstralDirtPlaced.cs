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
            //SetModTree(new Trees.ExampleTree());
            Main.tileMerge[Type][mod.TileType("AstralGrassPlaced")] = true;
        }

        //public override int SaplingGrowthType(ref int style) {
        //style = 0;
        //return TileType<ExampleSapling>();
        //}
    }
}