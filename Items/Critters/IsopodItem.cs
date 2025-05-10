using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.NPCs.Critters;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.Critters
{
    public class IsopodItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GlowingSnail);
            Item.makeNPC = (short)NPCType<Isopod>();
            Item.rare = CalamityID.CalRarityID.PureGreen;
        }
    }
}