using CalValEX.Items.Critters;
using CalValEX.Items.Pets;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.LightPets
{
    public class NuclearFly : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divine Fly");
            Tooltip
                .SetDefault("'Ascension'\n" + "Summons a Grand Entity\n" + "Provides a large amount of light in the abyss");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit49;
            item.shoot = mod.ProjectileType("Godrge");
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Red;
            item.expert = true;
            item.buffType = mod.BuffType("GodrgeBuff");
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<NuclearFumes>(), 20);
                recipe.AddIngredient(ModContent.ItemType<NukeFlyItem>(), 1);
                recipe.AddIngredient(ModContent.ItemType<FROM>(), 1);
                recipe.AddTile(TileID.LunarCraftingStation);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}