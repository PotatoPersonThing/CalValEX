using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CalValEX.Items.Tiles.Blocks;

namespace CalValEX.Tiles.Blocks
{
    public class AstralPlatingPlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = ModContent.ItemType<AstralPlating>();
            AddMapEntry(new Color(101, 171, 167));
            dustType = 173;
        }
    }
}