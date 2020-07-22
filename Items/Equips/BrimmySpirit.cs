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
	[AutoloadEquip(EquipType.Legs)]
	internal class BrimmySpirit : ModItem
	{
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Brimstone Flames");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 14;
			item.rare = 5;
			item.vanity = true;
			item.value = Item.sellPrice(0, 1, 0, 0);
		}

        public override bool DrawLegs() {
			return false;
		}
	}
}