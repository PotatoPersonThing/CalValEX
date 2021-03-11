using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Astral
{
    public class XenostonePlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = ModContent.ItemType<Xenostone>();
            soundType = SoundID.Tink;
            AddMapEntry(new Color(79, 49, 76));
            Main.tileMerge[Type][mod.TileType("AstralDirtPlaced")] = true;
        }
    }
}