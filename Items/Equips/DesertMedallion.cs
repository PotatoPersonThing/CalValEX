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
	[AutoloadEquip(EquipType.Neck)]
	public class DesertMedallion : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Budget Desert Medallion");
			Tooltip.SetDefault("Because the other one is too cursed to wear");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 28;
			item.value = Item.sellPrice(0, 0, 10, 0);
			item.rare = 2;
			item.accessory = true;
            item.vanity = true;
		}
	}
}
