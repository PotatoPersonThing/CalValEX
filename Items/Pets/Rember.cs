using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using CalValEX;
using CalValEX.Items.Pets;
using CalValEX.Items;

namespace CalValEX.Items.Pets 
{
	public class Rember : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault(":Sirember:");
			Tooltip.SetDefault("Alway Rember...");
		}

		public override void SetDefaults() {
		item.CloneDefaults(ItemID.ZephyrFish);
		item.UseSound = SoundID.NPCHit57;
		item.shoot = mod.ProjectileType("Sirember");
		item.value = Item.sellPrice(0, 60, 30, 0);
		item.rare = 10;
		item.buffType = mod.BuffType("Rembuff");
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
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

		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        	{
                type = mod.ProjectileType("Sirember");
		    	return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            	}

                public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CorrodedCleaver>(), 1);
            recipe.AddIngredient(ModContent.ItemType<NuclearFumes>(), 30);
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("CosmiliteBar"), 40);
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("EndothermicEnergy"), 20);
            recipe.AddTile(ModLoader.GetMod("CalamityMod").TileType("DraedonsForge"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        }
	}
}
