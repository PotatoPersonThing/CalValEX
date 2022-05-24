using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Items.Tiles.Blocks;

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
            ItemDrop = ModContent.ItemType<PolishedAstralMonolith>();
            //Mod calamityMod = ModLoader.GetMod("CalamityMod");
            //DustType = calamityMod.DustType("AstralBlue");
            AddMapEntry(new Color(260, 42, 24));
            Main.tileBlendAll[this.Type] = true;
            HitSound = SoundID.Item;
        }
    }
}