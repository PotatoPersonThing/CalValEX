using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Monoliths;

namespace CalValEX.Items.Tiles.Monoliths
{
    public class PlagueMonolith : ModItem
    {
        public override void SetStaticDefaults()
        {
            SacrificeTotal = 1;
            Tooltip.SetDefault("Emits harmless plague gas when activated\n" + "Cannot be used if any other Calamity monoliths are currently active");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 32;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.buyPrice(0, 10, 0, 0);
            Item.createTile = ModContent.TileType<PlagueMonolithPlaced>();
        }

        /*public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("InfectedArmorPlating"), 15);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}