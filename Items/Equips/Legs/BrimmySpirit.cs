using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Legs
{
    [AutoloadEquip(EquipType.Legs)]
    internal class BrimmySpirit : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brimstone Flames");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 14;
            item.rare = 5;
            item.vanity = true;
            item.value = Item.sellPrice(0, 2, 0, 0);
        }

        public override bool DrawLegs()
        {
            return false;
        }
    }
}