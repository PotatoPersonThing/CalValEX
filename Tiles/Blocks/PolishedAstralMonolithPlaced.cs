using Terraria;
using Terraria.GameContent.Metadata;
using Terraria.ModLoader;

namespace CalValEX.Tiles.Blocks
{
    public class PolishedAstralMonolithPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            //ItemDrop = ModContent.ItemType<PolishedAstralMonolith>();
            //Mod calamityMod = ModLoader.GetMod("CalamityMod");
            //DustType = calamityMod.DustType("AstralBlue");
            AddMapEntry(new Color(260, 42, 24));
            Main.tileBlendAll[this.Type] = true;
            TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Wood"]);
        }
    }
}