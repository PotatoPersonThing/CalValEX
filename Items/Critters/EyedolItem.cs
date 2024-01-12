using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.NPCs.Critters;
using Terraria.ID;

namespace CalValEX.Items.Critters
{
    public class EyedolItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.width = 22;
            Item.height = 22;
            Item.noUseGraphic = true;
            Item.rare = ItemRarityID.Orange;
            Item.makeNPC = (short)NPCType<Eyedol>();
        }
    }
}