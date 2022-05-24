using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats.Draedon
{
    [AutoloadEquip(EquipType.Head)]
    public class DraedonHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arsenal Soldier Helmet");
            Tooltip.SetDefault("Changes appearance depending on held item damage type");
            ArmorIDs.Head.Sets.DrawHead[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Head)] = false;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
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