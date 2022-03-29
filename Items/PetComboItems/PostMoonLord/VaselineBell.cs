using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Pets;
using CalValEX.Items.LightPets;

namespace CalValEX.Items.PetComboItems.PostMoonLord
{
    public class VaselineBell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vaseline Bell");
            Tooltip.SetDefault("All at once I come alive, it's a rebirth!");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit4;
            item.shoot = mod.ProjectileType("GrandPet");
            item.value = Item.sellPrice(0, 13, 50, 0);
            item.rare = 9;
            item.buffType = mod.BuffType("VaselineBuff");
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
            string[] summonedPets = new string[] {"GrandPet", "BuffReaper", "Smauler", "ScoriaDuke", "FollyPet", "BugDoge", "Headoge", "MiniDoge", "PolterChan"};
            foreach (string pet in summonedPets)
            {
                Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY), mod.ProjectileType(pet), 0, 0, player.whoAmI);
            }
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<HeartoftheSharks>());
            recipe.AddIngredient(ModContent.ItemType<CharredChopper>());
            recipe.AddIngredient(ModContent.ItemType<FollyWing>());
            recipe.AddIngredient(ModContent.ItemType<FluffyFur>());
            recipe.AddIngredient(ModContent.ItemType<ToyScythe>());
            recipe.AddTile(ModLoader.GetMod("CalamityMod").TileType("CosmicAnvil"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}