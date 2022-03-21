using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.PetComboBuffs
{
    public class NurseryBellBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Nursery Bell");
            Description.SetDefault("A terrarian's best friends will now follow you!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<CalValEXPlayer>().NurseryBell = true;

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().buppy = true;
            bool petProjectileNotSpawnedA = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Buppy>()] <= 0;
            if (petProjectileNotSpawnedA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Buppy>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().catfish = true;
            bool petProjectileNotSpawnedB = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Catfish>()] <= 0;
            if (petProjectileNotSpawnedB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) + 32, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Catfish>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().Angrypup = true;
            bool petProjectileNotSpawnedC = player.ownedProjectileCounts[ModContent.ProjectileType <Projectiles.Pets.Angrypup>()] <= 0;
            if (petProjectileNotSpawnedC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) - 32, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType < Projectiles.Pets.Angrypup>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().rPanda = true;
            bool petProjectileNotSpawnedD = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.RedPanda>()] <= 0;
            if (petProjectileNotSpawnedD && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) + 64, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.RedPanda>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().Chihuahua = true;
            bool petProjectileNotSpawnedE = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Puppo>()] <= 0;
            if (petProjectileNotSpawnedE && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) - 64, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Puppo>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().BabyCnidrion = true;
            bool petProjectileNotSpawnedF = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.BabyCnidrion>()] <= 0;
            if (petProjectileNotSpawnedF && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) - 64, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.BabyCnidrion>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}