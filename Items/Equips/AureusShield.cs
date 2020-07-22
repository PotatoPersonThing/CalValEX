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
	[AutoloadEquip(EquipType.Shield)]
	public class AureusShield : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Aureus Plating");
			Tooltip.SetDefault("Smaller in execution");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 28;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = 7;
			item.accessory = true;
            item.vanity = true;
		}
	}
}
