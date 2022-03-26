using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.Elementals;
using CalValEX.Projectiles.Pets.LightPets;

namespace CalValEX.Buffs.PetComboBuffs
{
    public class SpiritDinerBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Spirit Diner Bell");
            Description.SetDefault("It's a dark path ahead of you, they'll help");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<CalValEXPlayer>().SpiritDiner = true;

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mRav = true;
            bool petProjectileNotSpawnedA = player.ownedProjectileCounts[ModContent.ProjectileType<Pillager>()] <= 0;
            if (petProjectileNotSpawnedA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Pillager>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().rarebrimling = true;
            bool petProjectileNotSpawnedBA = player.ownedProjectileCounts[ModContent.ProjectileType<rarebrimling>()] <= 0;
            if (petProjectileNotSpawnedBA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<rarebrimling>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().cloudmini = true;
            bool petProjectileNotSpawnedBB = player.ownedProjectileCounts[ModContent.ProjectileType<cloudmini>()] <= 0;
            if (petProjectileNotSpawnedBB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<cloudmini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().raresandmini = true;
            bool petProjectileNotSpawnedBC = player.ownedProjectileCounts[ModContent.ProjectileType<raresandmini>()] <= 0;
            if (petProjectileNotSpawnedBC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<raresandmini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().sandmini = true;
            bool petProjectileNotSpawnedBD = player.ownedProjectileCounts[ModContent.ProjectileType<sandmini>()] <= 0;
            if (petProjectileNotSpawnedBD && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<sandmini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().babywaterclone = true;
            bool petProjectileNotSpawnedBE = player.ownedProjectileCounts[ModContent.ProjectileType<babywaterclone>()] <= 0;
            if (petProjectileNotSpawnedBE && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<babywaterclone>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            calamityMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 3);
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().sBun = true;
            bool petProjectileNotSpawnedC = player.ownedProjectileCounts[ModContent.ProjectileType<SolarBunny>()] <= 0;
            if (petProjectileNotSpawnedC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2 + 32, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SolarBunny>(), 0, 0f, player.whoAmI);
            }
        }
    }
}