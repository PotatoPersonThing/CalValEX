using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.PetComboBuffs
{
    public class BestInstrumentBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Best Instrument");
            Description.SetDefault("Fragments of your journey, keep them safe");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<CalValEXPlayer>().BestInst = true;

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mClam = true;
            bool petProjectileNotSpawnedA = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.ClamHermit>()] <= 0;
            if (petProjectileNotSpawnedA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.ClamHermit>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().SmolCrab = true;
            bool petProjectileNotSpawnedC = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.SmolCrab>()] <= 0;
            if (petProjectileNotSpawnedC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) - 32, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.SmolCrab>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().George = true;
            bool petProjectileNotSpawnedD = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.George>()] <= 0;
            if (petProjectileNotSpawnedD && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) + 64, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.George>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().tub = true;
            bool petProjectileNotSpawnedE = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.TUB>()] <= 0;
            if (petProjectileNotSpawnedE && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2 + 96, player.position.Y + player.height / 2, 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.TUB>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 19000;
            player.GetModPlayer<CalValEXPlayer>().Blok = true;
            bool petProjectileNotSpawnedF = (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Blockaroz>()] <= 0);
            if (petProjectileNotSpawnedF && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) - 96, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Blockaroz>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().euros = true;
            bool petProjectileNotSpawnedG = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Euros>()] <= 0;
            if (petProjectileNotSpawnedG && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) + 128, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Euros>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mPerf = true;
            bool petProjectileNotSpawnedH = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Fistuloid>()] <= 0;
            if (petProjectileNotSpawnedH && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) - 128, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Fistuloid>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mHive = true;
            bool petProjectileNotSpawnedI = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Hiveling>()] <= 0;
            if (petProjectileNotSpawnedI && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) + 160, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Hiveling>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mSlime = true;
            bool petProjectileNotSpawnedJ = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.SlimeDemi>()] <= 0;
            if (petProjectileNotSpawnedJ && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<Projectiles.Pets.SlimeDemi>(), 0, 0f, player.whoAmI);
            }
        }
    }
}