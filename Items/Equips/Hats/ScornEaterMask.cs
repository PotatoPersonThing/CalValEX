using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class ScornEaterMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scorn Eater Mask");
            Tooltip
                .SetDefault("The searing fire blazes fiercly");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 20;
            item.rare = 11;
            item.vanity = true;
            item.value = Item.sellPrice(0, 3, 0, 0);
        }

        public override bool DrawHead()
        {
            return false;
        }
    }
}