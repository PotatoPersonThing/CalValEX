using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CalValEX.Items.Equips.Shirts
{
    [AutoloadEquip(EquipType.Body)]
    internal class DraedonBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Draedon Thorax");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 14;
            item.rare = 1;
            item.vanity = true;
            item.value = Item.sellPrice(0, 3, 0, 0);
        }

        public override void DrawHands(ref bool drawHands, ref bool drawArms)
        {
            drawHands = false;
        }
    }
}