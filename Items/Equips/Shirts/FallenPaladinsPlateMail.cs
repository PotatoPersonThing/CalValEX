using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Equips.Shirts
{
    [AutoloadEquip(EquipType.Body)]
    public class FallenPaladinsPlateMail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fallen Paladin's Plate Mail");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 22;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 7;
            Item.vanity = true;
        }
       /* public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
           
            recipe.AddIngredient(calamityMod.ItemType("CalamityDust"), 2);
            recipe.AddIngredient(calamityMod.ItemType("CoreofChaos"), 2);
            recipe.AddIngredient(calamityMod.ItemType("CruptixBar"), 3);
            recipe.AddIngredient((ItemID.HallowedBar), 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}