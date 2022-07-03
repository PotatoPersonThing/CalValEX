using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Tiles.Blocks;

namespace CalValEX.Items.Tiles.Blocks
{
    public class PlagueHiveWand : ModItem
    {
        // The tooltip for this item is automatically assigned from .lang files
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Places Plague Hives");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = false;
            Item.rare = 7;
            Item.value = Item.buyPrice(0, 0, 50, 0);
            Item.tileWand = 1124;
            Item.createTile = TileType<PlagueHivePlaced>();
            Item.placeStyle = 0;
        }

        /*
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
        }*/
    }
}