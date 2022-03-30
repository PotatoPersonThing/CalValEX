using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Wings
{
    [AutoloadEquip(EquipType.Wings)]
    public class LeviWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leviathan Fin Wings");
            Tooltip.SetDefault("Flip flop\n" + "Horizontal speed: 6.75\n" + "Acceleration multiplier: 1.4\n" + "Flight time: 120");
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 7;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 120;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.4f;
            ascentWhenRising = 0.3f;
            maxCanAscendMultiplier = 0.5f;
            maxAscentMultiplier = 1.4f;
            constantAscend = 0.2f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 6.75f;
            acceleration *= 1.4f;
        }
    }
}