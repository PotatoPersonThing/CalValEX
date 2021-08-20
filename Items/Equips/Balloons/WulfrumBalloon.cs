using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Balloons
{
    [AutoloadEquip(EquipType.Balloon)]
    public class WulfrumBalloon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wulfrum Gyro Balloon");
            Tooltip.SetDefault("'I'm Using Tilt Controls!'");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.sellPrice(0, 0, 0, 80);
            item.rare = ItemRarityID.Blue;
            item.accessory = true;
            item.vanity = true;
        }
    }
}