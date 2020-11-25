using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class Cryocap : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryocap");
            Tooltip.SetDefault("Brain Freeze!");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 14;
            item.value = Item.sellPrice(0, 0, 3, 0);
            item.rare = 5;
            item.accessory = true;
            item.vanity = true;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawAltHair = true;
        }
    }
}