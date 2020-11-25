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

namespace CalValEX.Items.Equips.Legs
{
	[AutoloadEquip(EquipType.Legs)]
	internal class CultistLegs : ModItem
	{
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Cultist Assassin Pants");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 14;
			item.rare = 4;
			item.vanity = true;
			item.value = Item.sellPrice(0, 1, 0, 0);
		}
	}
}