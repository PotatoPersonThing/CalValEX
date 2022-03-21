using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Pets;
using CalValEX.Items.LightPets;

namespace CalValEX.Items.PetComboItems.PreHardmode
{
    public class DustChime : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dust Chime");
            Tooltip.SetDefault("The winds of progress");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit4;
            item.shoot = mod.ProjectileType("AeroBaby");
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 4;
            item.buffType = mod.BuffType("DustChimeBuff");
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
            string[] summonedPets = new string[] { "AeroBaby", "AeroSlimePet", "RustyMimic", "RepairBot", "WulfrumDrone", "WulfrumRover", "WulfrumHover", "WulfrumOrb", "WulfrumPylon", "RoverSpindlePet" };
            foreach (string pet in summonedPets)
            {
                Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY), mod.ProjectileType(pet), 0, 0, player.whoAmI);
            }
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AeroPebble>());
            recipe.AddIngredient(ModContent.ItemType<CursedLockpick>());
            recipe.AddIngredient(ModContent.ItemType<RepurposedMonitor>());
            recipe.AddIngredient(ModContent.ItemType<WulfrumController>());
            recipe.AddIngredient(ModContent.ItemType<PylonRemote>());
            recipe.AddIngredient(ModContent.ItemType<RoverSpindle>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}