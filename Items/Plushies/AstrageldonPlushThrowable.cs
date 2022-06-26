using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Projectiles.Plushies;
//using CalValEX.Items.Tiles.Plushies;

namespace CalValEX.Items.Plushies
{
    public class AstrageldonPlushThrowable : ModItem
    {
        public override string Texture => "CalValEX/Items/Tiles/Plushies/AstrageldonPlush";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astrageldon Plushie (Throwable)");
            Tooltip.SetDefault("Can be thrown");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.width = 44;
            Item.height = 44;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.rare = 10;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.value = 20;
            Item.shoot = ModContent.ProjectileType<AstrageldonPlush>();
            Item.shootSpeed = 6f;
            Item.maxStack = 99;
        }

        /*public override void AddRecipes()
        {
            Mod Cata = ModLoader.GetMod("CatalystMod");
            if (Cata != null)
            {
                
                {
                    ModRecipe recipe = new ModRecipe(mod);
                    recipe.AddIngredient(ModContent.ItemType<Tiles.Plushies.AstrageldonPlush>());
                    recipe.SetResult(this);
                    recipe.AddRecipe();
                }
            }
        }*/
    }
}