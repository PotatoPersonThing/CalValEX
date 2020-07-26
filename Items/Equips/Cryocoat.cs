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
	[AutoloadEquip(EquipType.Body)]
	internal class Cryocoat : ModItem
	{
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Cryocoat");
		}
		public override void SetDefaults() {
			item.width = 32;
			item.height = 14;
			item.rare = 5;
			item.vanity = true;
			item.value = Item.sellPrice(0, 0, 3, 0);
		}

		public override void DrawHands(ref bool drawHands, ref bool drawArms)
		{
			drawHands = true;
		}
	}
}