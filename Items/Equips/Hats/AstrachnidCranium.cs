using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class AstrachnidCranium : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astrachnid Cranium");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 22;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 7;
            Item.vanity = true;
        }
    }
}