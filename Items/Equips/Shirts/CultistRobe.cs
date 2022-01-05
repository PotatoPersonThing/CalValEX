using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Shirts
{
    [AutoloadEquip(EquipType.Body)]
    public class CultistRobe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cultist Assassin Robe");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 14;
            item.rare = 4;
            item.vanity = true;
            item.value = Item.sellPrice(0, 2, 0, 0);
        }

        public override void DrawHands(ref bool drawHands, ref bool drawArms)
        {
            drawHands = false;
        }
    }
}