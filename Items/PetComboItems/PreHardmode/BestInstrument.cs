using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Pets;

namespace CalValEX.Items.PetComboItems.PreHardmode
{
    public class BestInstrument : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Best Instrument");
            Tooltip.SetDefault("Pieces of our journey");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit4;
            item.shoot = mod.ProjectileType("ClamHermit");
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 5;
            item.buffType = mod.BuffType("BestInstrumentBuff");
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            string[] summonedPets = new string[] {"ClamHermit", "SmolCrab", "George", "Fistuloid", "Hiveling", "SlimeDemi"};
            foreach (string pet in summonedPets)
            {
                Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY), mod.ProjectileType(pet), 0, 0, player.whoAmI);
            }
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ClamHermitMedallion>());
            recipe.AddIngredient(ModContent.ItemType<ClawShroom>());
            recipe.AddIngredient(ModContent.ItemType<BubbleGum>());
            recipe.AddIngredient(ModContent.ItemType<DigestedWormFood>());
            recipe.AddIngredient(ModContent.ItemType<MissingFang>());
            recipe.AddIngredient(ModContent.ItemType<ImpureStick>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}