using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class FallenPaladinsHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fallen Paladin's Helmet");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 7;
            item.vanity = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            recipe.AddIngredient(calamityMod.ItemType("CalamityDust"), 1);
            recipe.AddIngredient(calamityMod.ItemType("CoreofChaos"), 1);
            recipe.AddIngredient(calamityMod.ItemType("CruptixBar"), 2);
            recipe.AddIngredient((ItemID.HallowedBar), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}