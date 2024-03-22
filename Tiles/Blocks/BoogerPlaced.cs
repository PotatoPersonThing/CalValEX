using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;

namespace CalValEX.Tiles.Blocks
{
    public class BoogerPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMergeDirt[Type] = true;
            AddMapEntry(new Color(52, 235, 100));
            DustType = DustID.GreenBlood;
            HitSound = SoundID.NPCDeath1;
        }
    }
}