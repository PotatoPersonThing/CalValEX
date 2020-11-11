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

namespace CalValEX.Items.Equips.Shirts
{
	[AutoloadEquip(EquipType.Body)]
	public class PerennialDress : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Perennial Dress");
			Tooltip.SetDefault("Flowering out");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 28;
			item.value = Item.sellPrice(0, 2, 20, 0);
			item.rare = 6;
            item.vanity = true;
		}
	}
}
