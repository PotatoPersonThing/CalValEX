using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Projectiles.Plushies;
//using CalValEX.Items.Tiles.Plushies;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.DataStructures;

namespace CalValEX.Items.Plushies
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
            Item.useStyle = 1;
            Item.width = 44;
            Item.height = 44;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.rare = 11;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.value = 20;
            Item.shoot = ModContent.ProjectileType<CalaFumo>();
            Item.shootSpeed = 6f;
            Item.maxStack = 99;
        }

        /*public override void AddRecipes()
        {
            
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<CalamitasFumo>());
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                type = ModContent.ProjectileType<CalaFumoSpeen>();
                return base.Shoot(player, source, position, velocity, type, damage, knockback);
            }
            else
            {
                if (Main.rand.NextFloat() < 0.01f)
                {
                    type = ModContent.ProjectileType<ItsReal>();
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.NPCHit49, (int)player.position.X, (int)player.position.Y);
                }
                else if (Main.rand.NextFloat() < 0.1f && CalValEX.month == 6 && CalValEX.day == 22)
                {
                    type = ModContent.ProjectileType<ItsReal>();
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.NPCHit49, (int)player.position.X, (int)player.position.Y);
                }
                else if (Main.rand.NextFloat() < 0.002f)
                {
                    type = ModContent.ProjectileType<ItsRealAlt>();
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.NPCHit49, (int)player.position.X, (int)player.position.Y);
                }
                else
                {
                    type = ModContent.ProjectileType<CalaFumo>();
                }
                return base.Shoot(player, source, position, velocity, type, damage, knockback);
            }
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            //rarity 12 (Turquoise) = new Color(0, 255, 200)
            //rarity 13 (Pure Green) = new Color(0, 255, 0)
            //rarity 14 (Dark Blue) = new Color(43, 96, 222)
            //rarity 15 (Violet) = new Color(108, 45, 199)
            //rarity 16 (Hot Pink/Developer) = new Color(255, 0, 255)
            //rarity rainbow (no expert tag on item) = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB)
            //rarity rare variant = new Color(255, 140, 0)
            //rarity dedicated(patron items) = new Color(139, 0, 0)
            //look at https://calamitymod.gamepedia.com/Rarity to know where to use the colors
            foreach (TooltipLine tooltipLine in tooltips)
            {
                if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.OverrideColor = new Color(108, 45, 199); //change the color accordingly to above
                }
            }
        }
    }
}