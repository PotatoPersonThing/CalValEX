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
    public class CosmicCone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Cosmic Cone");
            Tooltip.SetDefault("A hat so pointy it could pierce the heavens.");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.rare = 4;
            item.accessory = true;
            item.vanity = true;
        }
    }
}
