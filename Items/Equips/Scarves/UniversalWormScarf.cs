using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX;
using CalValEX.Items.Pets;
using CalValEX.Items.Equips.Scarves;
using CalValEX.Items.Hooks;

namespace CalValEX.Items.Equips.Scarves
{
	[AutoloadEquip(EquipType.Neck)]
	public class UniversalWormScarf : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Universal Worm Scarf");
			Tooltip.SetDefault("'Eat it all, without bending reality.'");
		}

		public override void SetDefaults() {
			item.width = 36;
			item.height = 38;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = 10;
			item.accessory = true;
            item.vanity = true;
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

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
		recipe.AddIngredient(ModContent.ItemType<RapturedWormScarf>());
                recipe.AddIngredient(calamityMod.ItemType("ArmoredShell"), 2);
                recipe.AddIngredient(calamityMod.ItemType("DarkPlasma"), 2);
                recipe.AddIngredient(calamityMod.ItemType("TwistedNether"), 2);
                recipe.AddTile(calamityMod.TileType("DraedonsForge"));  
			    recipe.SetResult(this);
			    recipe.AddRecipe();
            }
        }

	}
}
