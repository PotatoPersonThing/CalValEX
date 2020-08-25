using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Equips
{
    [AutoloadEquip(EquipType.Head)]
    public class Calacirclet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Calamity Circlet");
            Tooltip.SetDefault("Ring of Fire!");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 14;
            item.value = Item.sellPrice(0, 0, 3, 0);
            item.rare = ItemRarityID.Lime;
            item.vanity = true;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawAltHair = true;
        }
    }
}