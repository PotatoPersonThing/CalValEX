using Terraria;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;

namespace CalValEX.Buffs.PetComboBuffs
{
    public class VaselineBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;

            player.GetModPlayer<CalValEXPlayer>().Vaseline = true;
            player.GetModPlayer<CalValEXPlayer>().mShark = true;
            player.GetModPlayer<CalValEXPlayer>().shart = true;
            player.GetModPlayer<CalValEXPlayer>().buffboi = true;
            player.GetModPlayer<CalValEXPlayer>().smaul = true;
            player.GetModPlayer<CalValEXPlayer>().sDuke = true;
            player.GetModPlayer<CalValEXPlayer>().mFolly = true;
            player.GetModPlayer<CalValEXPlayer>().bDoge = true;
            player.GetModPlayer<CalValEXPlayer>().hDoge = true;
            player.GetModPlayer<CalValEXPlayer>().mDoge = true;
            player.GetModPlayer<CalValEXPlayer>().mChan = true;

            bool petProjectileNotSpawnedAA = player.ownedProjectileCounts[ModContent.ProjectileType<GrandPet>()] <= 0;
            if (petProjectileNotSpawnedAA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<GrandPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedAB = player.ownedProjectileCounts[ModContent.ProjectileType<BuffReaper>()] <= 0;
            if (petProjectileNotSpawnedAB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<BuffReaper>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedAC = player.ownedProjectileCounts[ModContent.ProjectileType<Smauler>()] <= 0;
            if (petProjectileNotSpawnedAC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Smauler>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedB = player.ownedProjectileCounts[ModContent.ProjectileType<ScoriaDuke>()] <= 0;
            if (petProjectileNotSpawnedB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<ScoriaDuke>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedC = player.ownedProjectileCounts[ModContent.ProjectileType<FollyPet>()] <= 0;
            if (petProjectileNotSpawnedC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<FollyPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedDA = player.ownedProjectileCounts[ModContent.ProjectileType<BugDoge>()] <= 0;
            if (petProjectileNotSpawnedDA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<BugDoge>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedDB = player.ownedProjectileCounts[ModContent.ProjectileType<Headoge>()] <= 0;
            if (petProjectileNotSpawnedDB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Headoge>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedDC = player.ownedProjectileCounts[ModContent.ProjectileType<MiniDoge>()] <= 0;
            if (petProjectileNotSpawnedDC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<MiniDoge>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedE = player.ownedProjectileCounts[ModContent.ProjectileType<PolterChan>()] <= 0;
            if (petProjectileNotSpawnedE && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<PolterChan>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}