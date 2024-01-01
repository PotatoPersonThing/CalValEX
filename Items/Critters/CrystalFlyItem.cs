using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.NPCs.Critters;

namespace CalValEX.Items.Critters
{
    public class CrystalFlyItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Purple;
            Item.CloneDefaults(ItemID.JuliaButterfly);
            Item.makeNPC = (short)NPCType<CrystalFly>();
            Item.bait = 45;
        }
    }
}