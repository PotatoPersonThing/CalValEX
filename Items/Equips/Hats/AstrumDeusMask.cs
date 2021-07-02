using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class AstrumDeusMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blighted Deus Mask");
            Tooltip.SetDefault("'A faded star reignited.'");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.vanity = true;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = false;
        }
    }
}