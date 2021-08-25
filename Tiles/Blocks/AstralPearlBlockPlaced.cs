using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Items.Tiles.Blocks;

namespace CalValEX.Tiles.Blocks
{
    public class AstralPearlBlockPlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = ModContent.ItemType<AstralPearlBlock>();
            dustType = 173;
            AddMapEntry(new Color(183, 69, 60));
            Main.tileBlendAll[this.Type] = true;
            soundType = SoundID.Item;
            soundStyle = 50;
        }
    }
}