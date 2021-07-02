using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class UnloadedHelm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unloaded Helm");
            Tooltip.SetDefault("Still reeks");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 20;
            item.rare = 1;
            item.vanity = true;
            item.value = Item.sellPrice(0, 2, 0, 0);
        }

        public override bool DrawHead()
        {
            return false;
        }
    }
}