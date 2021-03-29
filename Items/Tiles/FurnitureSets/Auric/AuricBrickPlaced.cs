using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.FurnitureSets.Auric
{
    public class AuricBrickPlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = ModContent.ItemType<AuricBrick>();
            soundType = SoundID.Tink;
            AddMapEntry(new Color(242, 202, 39));
            dustType = 159;
            minPick = 275;
        }
    }
}