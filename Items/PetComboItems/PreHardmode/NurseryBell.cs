using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Pets;

namespace CalValEX.Items.PetComboItems.PreHardmode
{
    public class NurseryBell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nursery Bell");
            Tooltip.SetDefault("Our best friends...");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit4;
            item.shoot = mod.ProjectileType("Buppy");
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 3;
            item.buffType = mod.BuffType("NurseryBellBuff");
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            string[] summonedPets = new string[] { "Buppy", "Catfish", "Angrypup", "RedPanda", "Puppo", "BabyCnidrion"};
            foreach (string pet in summonedPets)
            {
                Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY), mod.ProjectileType(pet), 0, 0, player.whoAmI);
            }
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<OldTennisBall>());
            recipe.AddIngredient(ModContent.ItemType<DiscardedCollar>());
            recipe.AddIngredient(ModContent.ItemType<TundraBall>());
            recipe.AddIngredient(ModContent.ItemType<BambooStick>());
            recipe.AddIngredient(ModContent.ItemType<PuppoCollar>());
            recipe.AddIngredient(ModContent.ItemType<DryShrimp>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}