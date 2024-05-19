using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Plushies
{
    public class CalamitasFumo : ModItem
    {
        public override string Texture => "CalValEX/Items/Plushies/CalamitasPlush";
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 1;

        public override void SetDefaults()
        {
            Item.width = 44;
            Item.height = 44;
            Item.rare = ItemRarityID.Gray;
            Item.value = 40;
            Item.maxStack = 99;
        }

        public override void UpdateInventory(Player player)
        {
            Item.SetDefaults(PlushManager.PlushItems["Calamitas"]);
        }
    }
}