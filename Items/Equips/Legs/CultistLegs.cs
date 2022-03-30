using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Legs
{
    [AutoloadEquip(EquipType.Legs)]
    public class CultistLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cultist Assassin Pants");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 14;
            Item.rare = 4;
            Item.vanity = true;
            Item.value = Item.sellPrice(0, 2, 0, 0);
        }
    }
}