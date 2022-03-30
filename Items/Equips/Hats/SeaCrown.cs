using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class SeaCrown : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sea Empress Crown");
            Tooltip.SetDefault("Wearing this will make you feel royal");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 20;
            Item.rare = ItemRarityID.Green;
            Item.vanity = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Terraria.ID.ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }

       /* public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("SeaPrism"), 5);
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("PrismShard"), 30);
            recipe.AddIngredient(ItemID.PlatinumCrown, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("SeaPrism"), 5);
            recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("PrismShard"), 30);
            recipe.AddIngredient(ItemID.GoldCrown, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}