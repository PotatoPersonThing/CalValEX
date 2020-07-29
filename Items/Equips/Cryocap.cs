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
          public virtual void DrawHair(ref bool drawHair, ref bool drawAltHair) 
            {
                drawHair = true;
                drawAltHair = true;
         } 
    }
}
