using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Legs
{
    [AutoloadEquip(EquipType.Legs)]
    internal class CultistLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cultist Assassin Pants");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 14;
            item.rare = 4;
            item.vanity = true;
            item.value = Item.sellPrice(0, 2, 0, 0);
        }
    }
}