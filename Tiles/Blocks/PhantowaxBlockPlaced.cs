using Terraria;
using Terraria.GameContent.Metadata;
using Terraria.ModLoader;

namespace CalValEX.Tiles.Blocks
{
    public class PhantowaxBlockPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            //ItemDrop = ModContent.ItemType<PhantowaxBlock>();
            AddMapEntry(new Color(94, 39, 93));
            TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Sticky"]);
        }
    }
}