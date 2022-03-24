using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Pets;

namespace CalValEX.Items.PetComboItems.Hardmode
{
    public class MaladyBells : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Malady Bells");
            Tooltip.SetDefault("Start anew");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit4;
            item.shoot = mod.ProjectileType("cryokid");
            item.value = Item.sellPrice(0, 8, 40, 15);
            item.rare = 6;
            item.buffType = mod.BuffType("MaladyBellsBuff");
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
            string[] summonedPets = new string[] {"cryokid", "PhantomPet", "Hoodieeidolist", "FathomEelHead", "MoistScourgePet", "BoldLizard", "SkaterPet"};
            foreach (string pet in summonedPets)
            {
                Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY), mod.ProjectileType(pet), 0, 0, player.whoAmI);
            }
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<coopershortsword>());
            recipe.AddIngredient(ModContent.ItemType<HauntedPebble>());
            recipe.AddIngredient(ModContent.ItemType<Eidolistthingy>());
            recipe.AddIngredient(ModContent.ItemType<DeepseaLantern>());
            recipe.AddIngredient(ModContent.ItemType<SandTooth>());
            recipe.AddIngredient(ModContent.ItemType<BoldEgg>());
            recipe.AddIngredient(ModContent.ItemType<SkaterEgg>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}