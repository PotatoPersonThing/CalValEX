using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.LightPets;

namespace CalValEX.Buffs.PetComboBuffs
{
    public class AltarBellBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Altar Bell");
            Description.SetDefault("The guiding stars");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<CalValEXPlayer>().AltarBell = true;

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().dBall = true;
            bool petProjectileNotSpawnedA = player.ownedProjectileCounts[ModContent.ProjectileType<Dragonball>()] <= 0;
            if (petProjectileNotSpawnedA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Dragonball>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            Mod clamMod = ModLoader.GetMod("CalamityMod");
            clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 3);
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().GeorgeII = true;
            bool petProjectileNotSpawnedB = player.ownedProjectileCounts[ModContent.ProjectileType<Godrge>()] <= 0;
            if (petProjectileNotSpawnedB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (player.width / 2) + 32, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<Godrge>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().avalon = true;
            bool petProjectileNotSpawnedC = player.ownedProjectileCounts[ModContent.ProjectileType<Avalon>()] <= 0;
            if (petProjectileNotSpawnedC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) - 32, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Avalon>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().ySquid = true;
            bool petProjectileNotSpawnedD = player.ownedProjectileCounts[ModContent.ProjectileType<YharimSquid>()] <= 0;
            if (petProjectileNotSpawnedD && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2 + 64, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<YharimSquid>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().TerminalRock = true;
            bool petProjectileNotSpawnedE = player.ownedProjectileCounts[ModContent.ProjectileType<TerminalRock>()] <= 0;
            if (petProjectileNotSpawnedE && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2 - 64, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<TerminalRock>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().rainbow = true;
            bool petProjectileNotSpawnedF = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Scuttlers.BejeweledScuttler>()] <= 0;
            if (petProjectileNotSpawnedF && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) + 96, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Scuttlers.BejeweledScuttler>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 3);
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().ProGuard1 = true;
            player.GetModPlayer<CalValEXPlayer>().ProGuard2 = true;
            player.GetModPlayer<CalValEXPlayer>().ProGuard3 = true;
            player.GetModPlayer<CalValEXPlayer>().ProviPet = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("ProGuard1")] <= 0 &&
                                           player.ownedProjectileCounts[mod.ProjectileType("ProGuard2")] <= 0 &&
                                           player.ownedProjectileCounts[mod.ProjectileType("ProGuard3")] <= 0 &&
                                           player.ownedProjectileCounts[mod.ProjectileType("ProviPet")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, mod.ProjectileType("ProGuard1"), 0, 0f, player.whoAmI);
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, mod.ProjectileType("ProGuard2"), 0, 0f, player.whoAmI);
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, mod.ProjectileType("ProGuard3"), 0, 0f, player.whoAmI);
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, mod.ProjectileType("ProviPet"), 0, 0f, player.whoAmI);
            }

        }
    }
}