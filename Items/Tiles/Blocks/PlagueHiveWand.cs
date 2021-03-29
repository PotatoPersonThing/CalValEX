using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.Tiles.Blocks
{
    public class PlagueHiveWand : ModItem
    {
        // The tooltip for this item is automatically assigned from .lang files
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Places Plague Hives");
        }

        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 24;
            item.maxStack = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = false;
            item.rare = 7;
            item.value = Item.buyPrice(0, 0, 50, 0);
            item.tileWand = 1124;
            item.createTile = TileType<PlagueHivePlaced>();
            item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
                recipe.AddIngredient(calamityMod.ItemType("PlagueCellCluster"), 20);
                recipe.AddIngredient(ItemID.HiveWand);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}