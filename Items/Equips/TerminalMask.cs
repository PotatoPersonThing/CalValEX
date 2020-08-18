using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using CalValEX;

namespace CalValEX.Items.Equips
{
    [AutoloadEquip(EquipType.Head)]
    public class TerminalMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terminal Facemask");
            Tooltip.SetDefault("Through bloodshed and turmoil new sight is attained, \nthrough eyes of a God forgotten");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 5));
           // ItemID.Sets.AnimatesAsSoul[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = false;
            ItemID.Sets.ItemNoGravity[item.type] = false;

        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.sellPrice(1, 0, 0, 0);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            item.rare = 10;
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
            tooltipLine.overrideColor = new Color(255, 0, 255); //change the color accordingly to above
        }
    }
    }
                public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
               Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
		recipe.AddIngredient(ModContent.ItemType<Termipebbles>(), 5);
                recipe.AddIngredient(calamityMod.ItemType("Rock"));
                recipe.AddTile(calamityMod.TileType("DraedonsForge"));
			    recipe.SetResult(this);
			    recipe.AddRecipe();
            }
        }
    }
}
