using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.NPCs.Critters;

namespace CalValEX.Items.Critters
{
    public class GoldViolemurItem : ModItem
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
            Item.height = 18;
            Item.noUseGraphic = true;
            Item.rare = ItemRarityID.LightRed;
            Item.makeNPC = (short)NPCType<GoldViolemur>();
            Item.value = Item.sellPrice(0, 10, 0, 0);
        }
    }
}