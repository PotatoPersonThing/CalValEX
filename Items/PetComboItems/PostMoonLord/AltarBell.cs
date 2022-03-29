using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Pets;
using CalValEX.Items.Pets.Scuttlers;
using CalValEX.Items.LightPets;

namespace CalValEX.Items.PetComboItems.PostMoonLord
{
    public class AltarBell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Altar Bell");
            Tooltip.SetDefault("The gods from the heavens on the palm of your hand");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit4;
            item.shoot = mod.ProjectileType("Dragonball");
            item.value = Item.sellPrice(0, 25, 80, 15);
            item.rare = 16;
            item.buffType = mod.BuffType("AltarBellBuff");
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
            string[] summonedPets = new string[] {"Dragonball", "Godrge", "Avalon", "YharimSquid", "TerminalRock", "BejeweledScuttler", "ProGuard1", "ProGuard2", "ProGuard3", "ProviPet"};
            foreach (string pet in summonedPets)
            {
                Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY), mod.ProjectileType(pet), 0, 0, player.whoAmI);
            }
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<OrbSummon>());
            recipe.AddIngredient(ModContent.ItemType<NuclearFly>());
            recipe.AddIngredient(ModContent.ItemType<FlareRune>());
            recipe.AddIngredient(ModContent.ItemType<AuricBottle>());
            recipe.AddIngredient(ModContent.ItemType<TerminusStone>());
            recipe.AddIngredient(ModContent.ItemType<BejeweledSpike>());
            recipe.AddIngredient(ModContent.ItemType<ProShard>());
            recipe.AddTile(ModLoader.GetMod("CalamityMod").TileType("DraedonsForge"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}