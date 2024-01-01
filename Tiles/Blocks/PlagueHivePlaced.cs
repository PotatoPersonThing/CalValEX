using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Tiles.Blocks
{
    public class PlagueHivePlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            AddMapEntry(new Color(0, 76, 82));
            RegisterItemDrop(Terraria.ID.ItemID.HoneyBlock);
            DustType = 214;
        }
    }
}