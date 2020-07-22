using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX;
using CalValEX.Items;
using CalValEX.Items.Hooks;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;

namespace CalValEX.Items.Hooks
{
	internal class MawHook : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cragmaw Spinehook");
            Tooltip.SetDefault("Prehistoric pull power!");
		}

		public override void SetDefaults() {
			
			item.CloneDefaults(ItemID.BatHook);
			item.shootSpeed = 18f; 
			item.shoot = ProjectileType<MawTeeth>();
			item.rare = 5;
		}
	}
}

	