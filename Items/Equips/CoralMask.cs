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
	[AutoloadEquip(EquipType.Head)]
	public class CoralMask : ModItem
	{
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Belching Coral Mask");
            Tooltip.SetDefault("Oh yeah its big brain time");
		}
		public override void SetDefaults() {
			item.width = 28;
			item.height = 20;
			item.rare = 5;
			item.vanity = true;
			item.value = Item.sellPrice(0, 1, 0, 0);
		}

		public override bool DrawHead() {
			return false;
		}
	}
}