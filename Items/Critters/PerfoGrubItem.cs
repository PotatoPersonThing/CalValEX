using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.NPCs.Critters;

namespace CalValEX.Items.Critters {
    public class PerfoGrubItem : ModItem {
        public override void SetStaticDefaults() => SacrificeTotal = 5;

        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.Snail);
            Item.bait = 5;
            Item.makeNPC = (short)NPCType<PerfoGrub>();
            Item.rare = ItemRarityID.Orange;
        }
    }
}