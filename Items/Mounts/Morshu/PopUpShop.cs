using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.Morshu
{
    public class PopUpShop : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pop-up Shop");
            Tooltip.SetDefault("Summons a rideable super-sonic morshu");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 26;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item79;
            item.noMelee = true;
            item.mountType = ModContent.MountType<MorshuMount>();
        }

        public override void AddRecipes()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(calamityMod.ItemType("ThiefsDime"));
            recipe.AddIngredient(ItemID.LargeRuby);
            recipe.AddIngredient(ItemID.RopeCoil, 5);
            recipe.AddIngredient(ItemID.Bomb, 10);
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
