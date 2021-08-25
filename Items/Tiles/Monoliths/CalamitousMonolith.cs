using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Tiles.Monoliths;

namespace CalValEX.Items.Tiles.Monoliths
{
    public class CalamitousMonolith : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Infuses the nearby air with harmless Brimstone magic when activated\n" + "Cannot be used if two Monoliths are currently active");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 32;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.rare = ItemRarityID.Yellow;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.createTile = ModContent.TileType<CalamitousMonolithPlaced>();
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("CalamityDust"), 15);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("EssenceofChaos"), 5);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}