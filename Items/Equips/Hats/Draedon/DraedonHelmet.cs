using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats.Draedon
{
	[AutoloadEquip(EquipType.Head)]
	public class DraedonHelmet : ModItem
	{
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Draedon's Helmet");
			Tooltip.SetDefault("Changes appearance depending on held item damage type");
        }

        public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
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