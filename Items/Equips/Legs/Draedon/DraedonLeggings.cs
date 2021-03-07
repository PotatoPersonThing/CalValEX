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
            item.width = 36;
            item.height = 24;
            item.rare = ItemRarityID.Blue;
            item.vanity = true;
        }

        public override void AddRecipes()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(calamityMod.ItemType("DubiousPlating"), 8);
            recipe.AddIngredient(calamityMod.ItemType("MysteriousCircuitry"), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}