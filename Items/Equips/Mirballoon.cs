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
	[AutoloadEquip(EquipType.Balloon)]
	public class Mirballoon : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Mirage Balloon");
			Tooltip.SetDefault("Keep away from sharp objects!");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 28;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = 6;
			item.accessory = true;
            item.vanity = true;
		}
	}
}
