using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Legs.Draedon
{
    [AutoloadEquip(EquipType.Legs)]
    public class DraedonLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arsenal Soldier Leggings");
        }

        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 24;
            Item.rare = ItemRarityID.Blue;
            Item.vanity = true;
        }

        /*public override void AddRecipes()
        {
           
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(calamityMod.ItemType("DubiousPlating"), 8);
            recipe.AddIngredient(calamityMod.ItemType("MysteriousCircuitry"), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}