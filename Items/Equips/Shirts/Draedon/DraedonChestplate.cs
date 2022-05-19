using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Shirts.Draedon
{
    [AutoloadEquip(EquipType.Body)]
    public class DraedonChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arsenal Soldier Chestplate");
            Tooltip.SetDefault("Changes appearance depending on held item damage type");
            ArmorIDs.Body.Sets.HidesArms[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body)] = true;
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
            recipe.AddIngredient(calamityMod.ItemType("DubiousPlating"), 12);
            recipe.AddIngredient(calamityMod.ItemType("MysteriousCircuitry"), 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}