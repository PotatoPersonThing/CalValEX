using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX;
using CalValEX.Items.Pets;
using CalValEX.Items.Hooks;

namespace CalValEX.Items.Equips
{
    [AutoloadEquip(EquipType.Head)]
    public class AureicFedora : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aureic Fedora");
            Tooltip.SetDefault("Just don't directly tip it on someone");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 7;
            item.accessory = true;
            item.vanity = true;
        }
    }
}
