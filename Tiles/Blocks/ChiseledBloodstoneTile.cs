using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Tiles.Blocks
{
    public class ChiseledBloodstoneTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            //ItemDrop = ModContent.ItemType<ChiseledBloodstone>();
            AddMapEntry(new Color(126, 94, 87));
            HitSound = SoundID.Tink;
        }
    }
}