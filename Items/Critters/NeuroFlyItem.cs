using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.NPCs.Critters;

namespace CalValEX.Items.Critters {
    public class NeuroFlyItem : ModItem {
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 5;

        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.GlowingSnail);
            Item.bait = 5;
            Item.makeNPC = (short)NPCType<NeuroFly>();
            Item.rare = ItemRarityID.Orange;
        }
    }
}