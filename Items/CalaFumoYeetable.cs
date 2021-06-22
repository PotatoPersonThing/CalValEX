using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items
{
    public class CalaFumoYeetable : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Calamitas Plushie (Throwable)");
            Tooltip.SetDefault("A dark artifact that must be handled with care\n" + "Can be thrown\n" + "Right click to make it spin while thrown");
        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.width = 44;
            item.height = 44;
            item.consumable = true;
            item.UseSound = SoundID.Item1;
            item.rare = 6;
            item.useAnimation = 20;
            item.useTime = 20;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.value = 20;
            item.shoot = mod.ProjectileType("CalaFumo");
            item.shootSpeed = 6f;
            item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<CalamitasFumo>());
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
                type = mod.ProjectileType("CalaFumoSpeen");
                return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            }
            else
            {
                if (Main.rand.NextFloat() < 0.01f)
                {
                    type = mod.ProjectileType("ItsReal");
                    Main.PlaySound(SoundID.NPCHit49, (int)player.position.X, (int)player.position.Y);
                }
                else if (Main.rand.NextFloat() < 0.1f && CalValEX.month == 6 && CalValEX.day == 22)
                {
                    type = mod.ProjectileType("ItsReal");
                    Main.PlaySound(SoundID.NPCHit49, (int)player.position.X, (int)player.position.Y);
                }
                else
                {
                    type = mod.ProjectileType("CalaFumo");
                }
                return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            }
        }
    }
}