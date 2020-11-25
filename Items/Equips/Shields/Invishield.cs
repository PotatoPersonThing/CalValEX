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

namespace CalValEX.Items.Equips.Shields
{
	[AutoloadEquip(EquipType.Shield)]
	public class Invishield : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Compensation");
			Tooltip.SetDefault("Can be sold");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 28;
			item.value = Item.sellPrice(0, 0, 0, 5);
			item.rare = -1;
		}
	}
}
