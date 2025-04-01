using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.FurnitureSets.Necrotic;

namespace CalValEX.Items.Tiles.FurnitureSets.Necrotic
{
    public class Ravamper : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Necrotic Bonfire");
            /* Tooltip
                .SetDefault("Praise the sun!"); */
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<RavamperPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = ItemRarityID.Cyan;
        }

        /*public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.ItemType("Necrostone"), 20);
                recipe.AddIngredient(mod.ItemType("NecroticTorch"), 5);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}