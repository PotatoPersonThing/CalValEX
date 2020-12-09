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

namespace CalValEX.Items.Equips.Wings
{
	[AutoloadEquip(EquipType.Wings)]
	public class AeroWings : ModItem
	{

		public override void SetStaticDefaults() {
			Tooltip.SetDefault("It's a windy day");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 20;
			item.value = 10000;
			item.rare = 4;
			item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.wingTimeMax = 30;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 0.65f;
			ascentWhenRising = 0.10f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 1.3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 4f;
			acceleration *= 1.0f;
		}
	}
}
