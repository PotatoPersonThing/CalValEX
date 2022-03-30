using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Balloons
{
    [AutoloadEquip(EquipType.Balloon)]
    public class ShuttleBalloon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shuttle Balloon");
            Tooltip.SetDefault("'Marketable Martian'");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 22;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.vanity = true;
        }
    }
}