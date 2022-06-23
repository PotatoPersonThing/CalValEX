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
            Item.width = 28;
            Item.height = 20;
            Item.rare = 11;
            Item.vanity = true;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Terraria.ID.ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
        }
    }
}