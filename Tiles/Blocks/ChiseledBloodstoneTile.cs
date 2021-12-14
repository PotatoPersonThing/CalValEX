using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Items.Tiles.Blocks;

namespace CalValEX.Tiles.Blocks
{
    public class ChiseledBloodstoneTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = ModContent.ItemType<ChiseledBloodstone>();
            AddMapEntry(new Color(126, 94, 87));
            soundType = SoundID.Tink;
        }
    }
}