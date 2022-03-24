using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Pets;
using CalValEX.Items.LightPets;

namespace CalValEX.Items.PetComboItems.Hardmode
{
    public class HarbingerOfWork : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Harbinger Of Work");
            Tooltip.SetDefault("Robot love");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit4;
            item.shoot = mod.ProjectileType("RepairBot");
            item.value = Item.sellPrice(0, 10, 30, 0);
            item.rare = 7;
            item.buffType = mod.BuffType("HarbingerOfWorkBuff");
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
            string[] summonedPets = new string[] {"RepairBot", "DiggerPet", "Androomba", "AstPhage", "PBGMini"};
            foreach (string pet in summonedPets)
            {
                Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY), mod.ProjectileType(pet), 0, 0, player.whoAmI);
            }
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<RepurposedMonitor>());
            recipe.AddIngredient(ModContent.ItemType<DiggerRemote>());
            recipe.AddIngredient(ModContent.ItemType<AndroombaGBC>());
            recipe.AddIngredient(ModContent.ItemType<AstDie>());
            recipe.AddIngredient(ModContent.ItemType<BeeCan>());
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}