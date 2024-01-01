using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class SpectralstormHat : ModItem
    {
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 1;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Cyan;
            Item.vanity = true;
            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<CalValEXPlayer>().specan = true;
        }

        public override void UpdateVanity(Player player)
        {
            player.GetModPlayer<CalValEXPlayer>().specan = true;
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
           
            recipe.AddIngredient((ItemID.FragmentVortex), 5);
            recipe.AddIngredient((ItemID.Ectoplasm), 5);
            recipe.AddIngredient(ModContent.ItemType<Aestheticrown>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}
