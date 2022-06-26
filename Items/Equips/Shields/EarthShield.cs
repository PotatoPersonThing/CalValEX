using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Shields
{
    [AutoloadEquip(EquipType.Shield)]
    public class EarthShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tower Shield of the Elemental");
            Tooltip.SetDefault("Looks to be a sturdy, but is actually made of soft, useless stone!");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 4;
            Item.accessory = true;
            Item.vanity = true;
        }
    }
}