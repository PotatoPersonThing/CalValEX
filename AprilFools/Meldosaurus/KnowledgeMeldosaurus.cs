//using CalamityMod.Items.Materials;
//using CalamityMod.Items.LoreItems;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.AprilFools.Meldosaurus
{
    public class KnowledgeMeldosaurus : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Meldosaurus");
            //Tooltip.SetDefault("The Meldosaurus...\n" +
             //   "A dreaded creature birthed from the wills of decay. Nobody knows why it exists, and what it wants...\n"+"HUGH! Glad he's gone now!!! Him being inside me was making me itchy!");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = 9;
            Item.consumable = false;
        }

        public override bool CanUseItem(Player player)
        {
            return false; //Idk why this is even here ngl
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddTile(TileID.Bookcases);
            recipe.AddIngredient(ModContent.ItemType<MeldosaurusTrophy>());
            recipe.AddIngredient(ModContent.ItemType<VictoryShard>(), 10);
            recipe.AddRecipe();
        }*/
    }
}
