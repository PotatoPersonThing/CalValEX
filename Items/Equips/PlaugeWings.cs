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
    [AutoloadEquip(EquipType.Wings)]
    public class PlaugeWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plaguebringer Wings");
            Tooltip.SetDefault("Nanomachines not included");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 26;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.rare = 8;
            item.accessory = true;
	    
	    
	  }
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.wingTimeMax = 180;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 0.5f;
			ascentWhenRising = 0.1f;
			maxCanAscendMultiplier = 0.5f;
			maxAscentMultiplier = 1.5f;
			constantAscend = 0.1f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 7.75f;
			acceleration *= 1.5f;
		}
	}
}

        
