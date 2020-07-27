using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX;
using CalValEX.Items;
using CalValEX.Items.Tiles;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;
using CalValEX.Items.Critters;

namespace CalValEX.Items.Critters
{
internal class SwearshroomItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Swearshroom");
		}

		public override void SetDefaults() {
			item.useStyle = 1;
			item.autoReuse = true;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.maxStack = 999;
			item.consumable = true;
			item.width = 22;
			item.height = 22;
			item.noUseGraphic = true;
			item.rare = 2;

			Mod mod = ModLoader.GetMod("CalamityMod");
            if (mod == null)
            {
                return;
            }
			item.makeNPC = (short)NPCType<Swearshroom>();
		}
	}
}