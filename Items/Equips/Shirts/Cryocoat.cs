using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Shirts
{
    [AutoloadEquip(EquipType.Body)]
    public class Cryocoat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryocoat");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 14;
            item.rare = 5;
            item.vanity = true;
            item.value = Item.sellPrice(0, 2, 0, 0);
        }

        public override void DrawHands(ref bool drawHands, ref bool drawArms)
        {
            drawHands = true;
        }
    }
}