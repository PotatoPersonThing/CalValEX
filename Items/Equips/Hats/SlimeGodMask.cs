using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class SlimeGodMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slime God Core Mask");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 20;
            item.rare = 3;
            item.vanity = true;
            item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override bool DrawHead()
        {
            return false;
        }
    }
}