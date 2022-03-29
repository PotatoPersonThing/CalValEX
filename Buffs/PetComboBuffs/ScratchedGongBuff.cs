using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.Wulfrum;
using CalValEX.Projectiles.Pets.ExoMechs;
using CalValEX.Projectiles.Pets.LightPets;

namespace CalValEX.Buffs.PetComboBuffs
{
    public class ScratchedGongBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Scratched Gong");
            Description.SetDefault("What joy to tinker on these small machines");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<CalValEXPlayer>().ScratchedGong = true;

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().pylon = true;
            bool petProjectileNotSpawnedA = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumPylon>()] <= 0;
            if (petProjectileNotSpawnedA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, ModContent.ProjectileType<WulfrumPylon>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().drone = true;
            bool petProjectileNotSpawnedBA = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumDrone>()] <= 0;
            if (petProjectileNotSpawnedBA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<WulfrumDrone>(), 0, 0f, player.whoAmI);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().rover = true;
            bool petProjectileNotSpawnedBB = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumRover>()] <= 0;
            if (petProjectileNotSpawnedBB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<WulfrumRover>(), 0, 0f, player.whoAmI);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().hover = true;
            bool petProjectileNotSpawnedBC = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumHover>()] <= 0;
            if (petProjectileNotSpawnedBC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<WulfrumHover>(), 0, 0f, player.whoAmI);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().worb = true;
            bool petProjectileNotSpawnedBD = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumOrb>()] <= 0;
            if (petProjectileNotSpawnedBD && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<WulfrumOrb>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().RepairBot = true;
            bool petProjectileNotSpawnedC = player.ownedProjectileCounts[ModContent.ProjectileType<RepairBot>()] <= 0;
            if (petProjectileNotSpawnedC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<RepairBot>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().roverd = true;
            bool petProjectileNotSpawnedD = player.ownedProjectileCounts[ModContent.ProjectileType<RoverSpindlePet>()] <= 0;
            if (petProjectileNotSpawnedD && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) + 32, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<RoverSpindlePet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().digger = true;
            bool petProjectileNotSpawnedE = player.ownedProjectileCounts[ModContent.ProjectileType<DiggerPet>()] <= 0;
            if (petProjectileNotSpawnedE && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.Center, Vector2.Zero, ModContent.ProjectileType<DiggerPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().andro = true;
            bool petProjectileNotSpawnedF = player.ownedProjectileCounts[ModContent.ProjectileType<Androomba>()] <= 0;
            if (petProjectileNotSpawnedF && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) + 32, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Androomba>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().AstPhage = true;
            bool petProjectileNotSpawnedG = player.ownedProjectileCounts[ModContent.ProjectileType<AstPhage>()] <= 0;
            if (petProjectileNotSpawnedG && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) - 32, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<AstPhage>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().PBGmini = true;
            bool petProjectileNotSpawnedH = player.ownedProjectileCounts[ModContent.ProjectileType<PBGmini>()] <= 0;
            if (petProjectileNotSpawnedH && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) + 64, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<PBGmini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            Mod clamMod = ModLoader.GetMod("CalamityMod");
            clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 2);
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().seerS = true;
            bool petProjectileNotSpawnedIA = player.ownedProjectileCounts[ModContent.ProjectileType<SeerS>()] <= 0;
            if (petProjectileNotSpawnedIA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SeerS>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().seerM = true;
            bool petProjectileNotSpawnedIB = player.ownedProjectileCounts[ModContent.ProjectileType<SeerM>()] <= 0;
            if (petProjectileNotSpawnedIB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SeerM>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().seerL = true;
            bool petProjectileNotSpawnedIC = player.ownedProjectileCounts[ModContent.ProjectileType<SeerL>()] <= 0;
            if (petProjectileNotSpawnedIC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SeerL>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().thanos = true;
            bool petProjectileNotSpawnedJA = player.ownedProjectileCounts[ModContent.ProjectileType<ThanatosPet>()] <= 0;
            if (petProjectileNotSpawnedJA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<ThanatosPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.GetModPlayer<CalValEXPlayer>().ares = true;
            bool petProjectileNotSpawnedJB = player.ownedProjectileCounts[ModContent.ProjectileType<AresBody>()] <= 0;
            if (petProjectileNotSpawnedJB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<AresBody>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.GetModPlayer<CalValEXPlayer>().twins = true;
            bool petProjectileNotSpawnedJC = player.ownedProjectileCounts[ModContent.ProjectileType<TwinsPet>()] <= 0;
            if (petProjectileNotSpawnedJC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<TwinsPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}