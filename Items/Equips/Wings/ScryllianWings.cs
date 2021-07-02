using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Wings
{
    [AutoloadEquip(EquipType.Wings)]
    public class ScryllianWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scryllian Wings");
            Tooltip.SetDefault("RISE!\n" + "Inflicts intense burns when worn before the flesh wall falls\n" + "Horizontal speed: 6.5\n" + "Flight time: 60");
        }

        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 26;
            item.rare = 3;
            item.accessory = true;
            item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 60;
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (!Main.hardMode)
                player.AddBuff(calamityMod.BuffType("BrimstoneFlames"), 2);
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.5f;
            ascentWhenRising = 0.1f;
            maxCanAscendMultiplier = 0.5f;
            maxAscentMultiplier = 1.5f;
            constantAscend = 0.1f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 6.5f;
        }
    }
}