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
    public class Calacirclet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Calamity Circlet");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 14;
            item.value = Item.sellPrice(0, 0, 3, 0);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            item.rare = 7;
            item.accessory = true;
            item.vanity = true;
        }
    }
}
