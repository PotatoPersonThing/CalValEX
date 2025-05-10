using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Buffs.LightPets;

namespace CalValEX.Items.LightPets
{
    public class ConstructionRemote : ModItem 
    {
        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = ModContent.RarityType<Rarities.Aqua>();
            Item.buffType = ModContent.BuffType<DiggerBuff>();
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2);
            return false;
        }
        /*public override void AddRecipes()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddRecipeGroup("AnyHardmodeDrill", 1);
                recipe.AddIngredient(calamityMod.ItemType("DubiousPlating"), 15);
                recipe.AddIngredient(calamityMod.ItemType("MysteriousCircuitry"), 5);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("PowerCell"), 10);
                recipe.AddTile(ModLoader.GetMod("CalamityMod").TileType("LaboratoryConsole"));
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}