using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Equips
{
    [AutoloadEquip(EquipType.Head)]
    public class BanditHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bandit's Hat");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 12;
            item.rare = ItemRarityID.Orange;
            item.vanity = true;
            item.value = Item.sellPrice(0, 3, 0, 0);
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = true;
            drawAltHair = true;
        }
    }
}