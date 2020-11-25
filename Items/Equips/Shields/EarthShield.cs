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
	public class EarthShield : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Tower Shield of the Elemental");
			Tooltip.SetDefault("Looks to be a sturdy, but is actually made of soft, useless stone!");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 28;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 4;
			item.accessory = true;
            item.vanity = true;
		}
	}
}
