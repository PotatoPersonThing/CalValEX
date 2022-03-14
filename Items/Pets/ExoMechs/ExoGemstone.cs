using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.World;
using CalamityMod.NPCs;
using CalamityMod.World.Planets;
using System.Threading;

namespace CalValEX.Items.Pets.ExoMechs
{
    public class ExoGemstone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Exo Gemstone");
            Tooltip.SetDefault("Summons the full miniaturized exo ensemble");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit4;
            item.shoot = mod.ProjectileType("TwinsPet");
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 11;
            item.buffType = mod.BuffType("ExoMayhemBuff");
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
                recipe.AddIngredient(ModContent.ItemType<GeminiMarkImplants>(), 1);
                recipe.AddIngredient(ModContent.ItemType<GunmetalRemote>(), 1);
                recipe.AddIngredient(ModContent.ItemType<OminousCore>(), 1);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("ExoPrism"), 8);
                recipe.AddTile(ModLoader.GetMod("CalamityMod").TileType("DraedonsForge"));
                recipe.SetResult(this);
                recipe.AddRecipe();
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
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(108, 45, 199); //change the color accordingly to above
                }
            }
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(player.Center, Vector2.Zero, mod.ProjectileType("ThanatosPet"), 0, 0, player.whoAmI);
            Projectile.NewProjectile(player.Center, Vector2.Zero, mod.ProjectileType("AresBody"), 0, 0, player.whoAmI);
            Projectile.NewProjectile(player.Center, Vector2.Zero, mod.ProjectileType("TwinsPet"), 0, 0, player.whoAmI);

            return false;
        }
    }
}