using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
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
            item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawAltHair = true;
        }
    }
}