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
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 22;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 4;
            Item.vanity = true;
        }
    }
}