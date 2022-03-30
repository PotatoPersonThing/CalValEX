using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Equips.Legs
{
    [AutoloadEquip(EquipType.Legs)]
    public class FallenPaladinsGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fallen Paladin's Greaves");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 22;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 7;
            Item.vanity = true;
        }
        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
           
            recipe.AddIngredient(calamityMod.ItemType("CalamityDust"), 2);
            recipe.AddIngredient(calamityMod.ItemType("CoreofChaos"), 1);
            recipe.AddIngredient(calamityMod.ItemType("CruptixBar"), 2);
            recipe.AddIngredient((ItemID.HallowedBar), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}