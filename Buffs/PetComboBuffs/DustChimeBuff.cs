using Microsoft.Xna.Framework;
using CalValEX.Projectiles.Pets.Wulfrum;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.PetComboBuffs
{
    public class DustChimeBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Dust Chime");
            Description.SetDefault("The adventure begins!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<CalValEXPlayer>().DustChime = true;

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mAero = true;
            bool petProjectileNotSpawnedA = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.AeroBaby>()] <= 0;
            if (petProjectileNotSpawnedA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.AeroBaby>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().aero = true;
            bool petProjectileNotSpawnedB = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.AeroSlimePet>()] <= 0;
            if (petProjectileNotSpawnedB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) + 32, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.AeroSlimePet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().rusty = true;
            bool petProjectileNotSpawnedC = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.RustyMimic>()] <= 0;
            if (petProjectileNotSpawnedC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) - 32, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.RustyMimic>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().RepairBot = true;
            bool petProjectileNotSpawnedD = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.RepairBot>()] <= 0;
            if (petProjectileNotSpawnedD && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) + 64, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.RepairBot>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().drone = true;
            bool petProjectileNotSpawnedEA = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumDrone>()] <= 0;
            if (petProjectileNotSpawnedEA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<WulfrumDrone>(), 0, 0f, player.whoAmI);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().rover = true;
            bool petProjectileNotSpawnedEB = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumRover>()] <= 0;
            if (petProjectileNotSpawnedEB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<WulfrumRover>(), 0, 0f, player.whoAmI);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().hover = true;
            bool petProjectileNotSpawnedEC = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumHover>()] <= 0;
            if (petProjectileNotSpawnedEC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<WulfrumHover>(), 0, 0f, player.whoAmI);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().worb = true;
            bool petProjectileNotSpawnedED = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumOrb>()] <= 0;
            if (petProjectileNotSpawnedED && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<WulfrumOrb>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().roverd = true;
            bool petProjectileNotSpawnedF = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.RoverSpindlePet>()] <= 0;
            if (petProjectileNotSpawnedF && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) - 64, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.RoverSpindlePet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().pylon = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumPylon>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, ModContent.ProjectileType<WulfrumPylon>(), 0, 0f, player.whoAmI);
            }
        }
    }
}