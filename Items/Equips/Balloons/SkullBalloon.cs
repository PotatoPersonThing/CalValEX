using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Balloons
{
    [AutoloadEquip(EquipType.Balloon)]
    public class SkullBalloon : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Looks like there's still a brain inside this one.'");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 44;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 8;
            Item.accessory = true;
            Item.vanity = true;
        }
    }
}