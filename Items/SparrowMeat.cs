using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items
{
	public class SparrowMeat : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sparrow Meat");
            Tooltip.SetDefault("There's a bit of pink cloth in it");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item2;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = 10;
            item.value = Item.sellPrice(0, 30, 20, 0);
            item.buffType = BuffID.WellFed; //Specify an existing buff to be applied when used.
            item.buffTime = 3600; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
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
            tooltipLine.overrideColor = new Color(0, 255, 200); //change the color accordingly to above
        }
    }
}

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("CosmicDischarge"), 1);
				recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("HolyCollider"), 1);
				recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("BansheeHook"), 1);
				recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("StreamGouge"), 1);
				recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("SoulEdge"), 1);
				recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("Valediction"), 1);
                recipe.SetResult(this);
                recipe.AddRecipe();
				
			}
        }
    }
}