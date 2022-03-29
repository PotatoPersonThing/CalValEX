using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.SepulcherNeo;
using CalValEX.Projectiles.Pets.LightPets;

namespace CalValEX.Buffs.PetComboBuffs
{
    public class WormBellBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Slither Charm");
            Description.SetDefault("Keep going");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<CalValEXPlayer>().WormBell = true;

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().SWPet = true;
            bool petProjectileNotSpawnedAA = player.ownedProjectileCounts[ModContent.ProjectileType<SWPet>()] <= 0;
            if (petProjectileNotSpawnedAA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SWPet>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mNaked = true;
            bool petProjectileNotSpawnedAB = player.ownedProjectileCounts[ModContent.ProjectileType<StasisNaked>()] <= 0;
            if (petProjectileNotSpawnedAB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<StasisNaked>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().asPet = true;
            bool petProjectileNotSpawnedBA = player.ownedProjectileCounts[ModContent.ProjectileType<AquaPet>()] <= 0;
            if (petProjectileNotSpawnedBA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height * 10,
                    0f, 0f, ModContent.ProjectileType<AquaPet>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().dsPet = true;
            bool petProjectileNotSpawnedBB = player.ownedProjectileCounts[ModContent.ProjectileType<DesertPet>()] <= 0;
            if (petProjectileNotSpawnedBB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<DesertPet>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().deussmall = true;
            bool petProjectileNotSpawnedCA = player.ownedProjectileCounts[ModContent.ProjectileType<DeusPetSmall>()] <= 0;
            if (petProjectileNotSpawnedCA && player.whoAmI == Main.myPlayer)
            {
                for (int k = 0; k < 10; k++)
                {
                    Projectile.NewProjectile(player.position.X + (float)(player.width / 2) + (32 * k), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<DeusPetSmall>(), 0, 0f, player.whoAmI, 0f, 0f);
                }
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().deusmain = true;
            bool petProjectileNotSpawnedCB = player.ownedProjectileCounts[ModContent.ProjectileType<DeusPet>()] <= 0;
            if (petProjectileNotSpawnedCB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height * 20), 0f, 0f, ModContent.ProjectileType<DeusPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().voreworm = true;
            bool petProjectileNotSpawnedD = player.ownedProjectileCounts[ModContent.ProjectileType<DogHead>()] <= 0;
            if (petProjectileNotSpawnedD && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<DogHead>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().jared = true;
            bool petProjectileNotSpawnedE = player.ownedProjectileCounts[ModContent.ProjectileType<JaredHead>()] <= 0;
            if (petProjectileNotSpawnedE && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<JaredHead>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().sepneo = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<SepulcherHeadNeo>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SepulcherHeadNeo>(), 0, 0f, player.whoAmI);
            }
        }
    }
}