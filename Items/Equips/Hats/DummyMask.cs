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
	public class DummyMask : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Dummy Mask");
			Tooltip.SetDefault("The only dummy here is you.");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 20;
			item.value = Item.sellPrice(0, 3, 30, 0);
			item.rare = 3;
			item.accessory = true;
            item.vanity = true;
		}
	}
}
