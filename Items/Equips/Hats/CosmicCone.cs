using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class CosmicCone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Cosmic Cone");
            Tooltip.SetDefault("A hat so pointy it could pierce the heavens.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 4;
            item.vanity = true;
        }
    }
}