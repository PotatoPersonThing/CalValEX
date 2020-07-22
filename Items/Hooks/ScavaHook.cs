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
	internal class ScavaHook : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ancient Scavenger Claw");
            Tooltip.SetDefault("Here to gouge out your eyes, runic style!");
		}

		public override void SetDefaults() {
			
			item.CloneDefaults(ItemID.BatHook);
			item.shootSpeed = 19f; 
			item.shoot = ProjectileType<ScavaClaw>();
			item.rare = 9;
		}
	}
}

	