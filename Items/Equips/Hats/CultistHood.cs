using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class CultistHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cultist Assassin Hood");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 20;
            item.rare = 4;
            item.vanity = true;
            item.value = Item.sellPrice(0, 2, 0, 0);
        }

        public override bool DrawHead()
        {
            return false;
        }
    }
}