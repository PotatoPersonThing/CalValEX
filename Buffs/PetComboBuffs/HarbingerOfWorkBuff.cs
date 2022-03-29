﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.LightPets;

namespace CalValEX.Buffs.PetComboBuffs
{
    public class HarbingerOfWorkBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Harbinger Of Work");
            Description.SetDefault("Watch out if their eyes turn red");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<CalValEXPlayer>().Harbinger = true;

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().roverd = true;
            bool petProjectileNotSpawnedA = player.ownedProjectileCounts[ModContent.ProjectileType<RoverSpindlePet>()] <= 0;
            if (petProjectileNotSpawnedA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) + 32, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<RoverSpindlePet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().digger = true;
            bool petProjectileNotSpawnedB = player.ownedProjectileCounts[ModContent.ProjectileType<DiggerPet>()] <= 0;
            if (petProjectileNotSpawnedB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.Center, Vector2.Zero, ModContent.ProjectileType<DiggerPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().andro = true;
            bool petProjectileNotSpawnedC = player.ownedProjectileCounts[ModContent.ProjectileType<Androomba>()] <= 0;
            if (petProjectileNotSpawnedC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) + 32, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Androomba>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().AstPhage = true;
            bool petProjectileNotSpawnedD = player.ownedProjectileCounts[ModContent.ProjectileType<AstPhage>()] <= 0;
            if (petProjectileNotSpawnedD && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) - 32, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<AstPhage>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().PBGmini = true;
            bool petProjectileNotSpawnedE = player.ownedProjectileCounts[ModContent.ProjectileType<PBGmini>()] <= 0;
            if (petProjectileNotSpawnedE && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) + 64, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<PBGmini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            Mod clamMod = ModLoader.GetMod("CalamityMod");
            clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 2);
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().seerS = true;
            bool petProjectileNotSpawnedFA = player.ownedProjectileCounts[ModContent.ProjectileType<SeerS>()] <= 0;
            if (petProjectileNotSpawnedFA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SeerS>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().seerM = true;
            bool petProjectileNotSpawnedFB = player.ownedProjectileCounts[ModContent.ProjectileType<SeerM>()] <= 0;
            if (petProjectileNotSpawnedFB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SeerM>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().seerL = true;
            bool petProjectileNotSpawnedFC = player.ownedProjectileCounts[ModContent.ProjectileType<SeerL>()] <= 0;
            if (petProjectileNotSpawnedFC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SeerL>(), 0, 0f, player.whoAmI);
            }
        }
    }
}