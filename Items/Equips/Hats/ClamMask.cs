using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class ClamMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clamitous Hat");
            Tooltip.SetDefault("Wait a second, thats a typo right?");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            //Item.height = 28;
            Item.height = 50;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 2;
            Item.vanity = true;
        }
    }
}