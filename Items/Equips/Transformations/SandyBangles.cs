using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Transformations
{
    public class SandyBangles : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.accessory = true;
            item.rare = ItemRarityID.Pink;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            CalValEXPlayer p = player.GetModPlayer<CalValEXPlayer>();

            p.sandT = true;
            if (hideVisual)
                p.sandHide = true;
        }
    }
}
