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
	[AutoloadEquip(EquipType.Face)]
	public class PerennialFlower : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Perennial Tulip");
			Tooltip.SetDefault("Am I a pretty girl?");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 28;
			item.value = Item.sellPrice(0, 1, 10, 0);
			item.rare = 6;
			item.accessory = true;
            item.vanity = true;
		}
	}
}
