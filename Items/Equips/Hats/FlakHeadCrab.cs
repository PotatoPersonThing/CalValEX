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

namespace CalValEX.Items.Equips.Hats
{
	[AutoloadEquip(EquipType.Head)]
	public class FlakHeadCrab : ModItem
	{
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Flak Head Crab");
            Tooltip.SetDefault("It appears you have a parasite");
		}
		public override void SetDefaults() {
			item.width = 28;
			item.height = 20;
			item.rare = 5;
			item.vanity = true;
			item.value = Item.sellPrice(0, 1, 0, 0);
		}
	}
}