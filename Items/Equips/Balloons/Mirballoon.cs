using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Balloons
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
            Item.width = 26;
            Item.height = 44;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.LightPurple;
            Item.accessory = true;
            Item.vanity = true;
        }
    }
}