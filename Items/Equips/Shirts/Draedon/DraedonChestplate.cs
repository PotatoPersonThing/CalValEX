using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Shirts.Draedon
{
    [AutoloadEquip(EquipType.Body)]
    public class DraedonChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Draedon's Chestplate");
            Tooltip.SetDefault("Changes appearance depending on held item damage type");
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
            recipe.AddIngredient(calamityMod.ItemType("DubiousPlating"), 12);
            recipe.AddIngredient(calamityMod.ItemType("MysteriousCircuitry"), 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
