using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips
{
    [AutoloadEquip(EquipType.Balloon)]
    public class Mirballoon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mirage Balloon");
            Tooltip.SetDefault("The Party Girl can tie this for you\n'Keep away from sharp objects!'");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 44;
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.rare = ItemRarityID.LightPurple;
            item.accessory = true;
            item.vanity = true;
        }
    }
}