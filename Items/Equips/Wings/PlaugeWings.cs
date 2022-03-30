using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Wings
{
    [AutoloadEquip(EquipType.Wings)]
    public class PlaugeWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plaguebringer Wings");
            Tooltip.SetDefault("Nanomachines not included\n" + "Horizontal speed: 7.75\n" + "Acceleration multiplier: 1.5\n" + "Flight time: 150"); ;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 8;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 150;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.5f;
            ascentWhenRising = 0.1f;
            maxCanAscendMultiplier = 0.5f;
            maxAscentMultiplier = 1.5f;
            constantAscend = 0.1f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 7.75f;
            acceleration *= 1.5f;
        }
    }
}