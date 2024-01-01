using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items
{
    public class SparrowMeat : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sparrow Meat");
            // Tooltip.SetDefault("There's a bit of pink cloth in it");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item2;
            Item.rare = ItemRarityID.Purple;
            Item.value = Item.sellPrice(0, 30, 20, 0);
            Item.buffType = BuffID.WellFed; //Specify an existing buff to be applied when used.
            Item.buffTime = 300; //The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }

        /*public override void AddRecipes()
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
        }*/
    }
}