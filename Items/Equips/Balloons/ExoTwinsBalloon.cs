﻿using CalValEX.Projectiles;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Balloons
{
    [AutoloadEquip(EquipType.Balloon)]
    public class ExoTwinsBalloon : ModItem
    {
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 1;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 42;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = CalamityID.CalRarityID.Violet;
            Item.accessory = true;
            Item.vanity = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<CalValEXPlayer>().twinballoon = true;
            if (player.ownedProjectileCounts[ModContent.ProjectileType<ArtemisBalloonProj>()] <= 0 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Accessory(Item), player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0, 0, ModContent.ProjectileType<ArtemisBalloonProj>(), 0, 0f, player.whoAmI);
            }
            if (player.ownedProjectileCounts[ModContent.ProjectileType<ApolloBalloonProj>()] <= 0 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Accessory(Item), player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0, 0, ModContent.ProjectileType<ApolloBalloonProj>(), 0, 0f, player.whoAmI);
            }
        }

        public override void UpdateVanity(Player player)
        {
            player.GetModPlayer<CalValEXPlayer>().twinballoon = true;
        }
        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
           
            recipe.AddIngredient(calamityMod.ItemType("MiracleMatter"), 1);
            recipe.AddIngredient(ModContent.ItemType<ArtemisBalloon>());
            recipe.AddIngredient(ModContent.ItemType<ApolloBalloon>());
            recipe.AddTile(calamityMod.TileType("DraedonsForge"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}