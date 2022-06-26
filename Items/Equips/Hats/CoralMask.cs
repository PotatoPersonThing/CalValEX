using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class CoralMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Belching Coral Mask");
            Tooltip.SetDefault("Oh yeah its big brain time");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 20;
            Item.rare = 5;
            Item.vanity = true;
            Item.value = Item.sellPrice(0, 2, 0, 0);
        }
    }
}