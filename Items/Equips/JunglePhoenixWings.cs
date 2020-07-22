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

namespace CalValEX.Items.Equips
{
	[AutoloadEquip(EquipType.Wings)]
	public class JunglePhoenixWings : ModItem
	{

		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Chicken Wings");
			Tooltip.SetDefault("Hot");
		}

		public override void SetDefaults() {
			item.value = 10000;
			item.rare = 11;
			item.accessory = true;
			item.value = Item.sellPrice(3, 50, 0, 0);
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.wingTimeMax = 140;
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
{
    //rarity 12 (Turquoise) = new Color(0, 255, 200)
    //rarity 13 (Pure Green) = new Color(0, 255, 0)
    //rarity 14 (Dark Blue) = new Color(43, 96, 222)
    //rarity 15 (Violet) = new Color(108, 45, 199)
    //rarity 16 (Hot Pink/Developer) = new Color(255, 0, 255)
    //rarity rainbow (no expert tag on item) = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB)
    //rarity rare variant = new Color(255, 140, 0)
    //rarity dedicated(patron items) = new Color(139, 0, 0)
    //look at https://calamitymod.gamepedia.com/Rarity to know where to use the colors
    foreach (TooltipLine tooltipLine in tooltips)
    {
        if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
        {
            tooltipLine.overrideColor = new Color(43, 96, 222); //change the color accordingly to above
        }
    }
}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 0.95f;
			ascentWhenRising = 0.35f;
			maxCanAscendMultiplier = 4f;
			maxAscentMultiplier = 6f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 11.5f;
			acceleration *= 2.9f;
		}
	}
}
