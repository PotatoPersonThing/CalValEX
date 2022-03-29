using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.Elementals;
using CalValEX.Projectiles.Pets.LightPets;
using CalValEX.Projectiles.Pets.Scuttlers;
using CalValEX.Projectiles.Pets.ExoMechs;
using CalValEX.Projectiles.Pets.Wulfrum;
using CalValEX.Projectiles.Pets.SepulcherNeo;
using CalValEX.Projectiles.Pets.LightPets.SupJewel;

namespace CalValEX.Buffs.PetComboBuffs
{
    public class PandoraBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Pandemonium Box");
            Description.SetDefault("Dream, it's all over\nWe've been waiting for another sight to see");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<CalValEXPlayer>().Pandora = true;

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mAero = true;
            bool petProjectileNotSpawnedAA = player.ownedProjectileCounts[ModContent.ProjectileType<AeroBaby>()] <= 0;
            if (petProjectileNotSpawnedAA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.AeroBaby>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().aero = true;
            bool petProjectileNotSpawnedAAB = player.ownedProjectileCounts[ModContent.ProjectileType<AeroSlimePet>()] <= 0;
            if (petProjectileNotSpawnedAAB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.AeroSlimePet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().andro = true;
            bool petProjectileNotSpawnedAB = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Androomba>()] <= 0;
            if (petProjectileNotSpawnedAB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Androomba>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().avalon = true;
            bool petProjectileNotSpawnedAC = player.ownedProjectileCounts[ModContent.ProjectileType<Avalon>()] <= 0;
            if (petProjectileNotSpawnedAC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Avalon>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().squid = true;
            bool petProjectileNotSpawnedAD = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.BabySquid>()] <= 0;
            if (petProjectileNotSpawnedAD && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.BabySquid>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().PBGmini = true;
            bool petProjectileNotSpawnedAE = player.ownedProjectileCounts[mod.ProjectileType("PBGmini")] <= 0;
            if (petProjectileNotSpawnedAE && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("PBGmini"), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().Blok = true;
            bool petProjectileNotSpawnedAF = (player.ownedProjectileCounts[mod.ProjectileType("Blockaroz")] <= 0);
            if (petProjectileNotSpawnedAF && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("Blockaroz"), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().buppy = true;
            bool petProjectileNotSpawnedAG = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Buppy>()] <= 0;
            if (petProjectileNotSpawnedAG && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Buppy>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().CalamityBABYBool = true;
            bool petProjectileNotSpawnedAH = player.ownedProjectileCounts[ModContent.ProjectileType<CalamityBABY>()] <= 0;
            if (petProjectileNotSpawnedAH && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (player.width / 2), player.position.Y + (player.height / 2) + 50f, 0f, 0f, ModContent.ProjectileType<CalamityBABY>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().catfish = true;
            bool petProjectileNotSpawnedAI = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Catfish>()] <= 0;
            if (petProjectileNotSpawnedAI && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Catfish>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 19000;
            player.GetModPlayer<CalValEXPlayer>().cryokid = true;
            bool petProjectileNotSpawnedAJ = player.ownedProjectileCounts[mod.ProjectileType("cryokid")] <= 0;
            if (petProjectileNotSpawnedAJ && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("cryokid"), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mClam = true;
            bool petProjectileNotSpawnedAK = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.ClamHermit>()] <= 0;
            if (petProjectileNotSpawnedAK && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.ClamHermit>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().BabyCnidrion = true;
            bool petProjectileNotSpawnedAL = player.ownedProjectileCounts[mod.ProjectileType("BabyCnidrion")] <= 0;
            if (petProjectileNotSpawnedAL && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("BabyCnidrion"), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().bSignut = true;
            bool petProjectileNotSpawnedAMA = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.CoolBlueSignut>()] <= 0;
            if (petProjectileNotSpawnedAMA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.CoolBlueSignut>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().bSlime = true;
            bool petProjectileNotSpawnedAMB = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.CoolBlueSlime>()] <= 0;
            if (petProjectileNotSpawnedAMB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.CoolBlueSlime>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().SmolCrab = true;
            bool petProjectileNotSpawnedAN = player.ownedProjectileCounts[mod.ProjectileType("SmolCrab")] <= 0;
            if (petProjectileNotSpawnedAN && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("SmolCrab"), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().rarebrimling = true;
            bool petProjectileNotSpawnedAOA = player.ownedProjectileCounts[ModContent.ProjectileType<rarebrimling>()] <= 0;
            if (petProjectileNotSpawnedAOA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<rarebrimling>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().cloudmini = true;
            bool petProjectileNotSpawnedAOB = player.ownedProjectileCounts[ModContent.ProjectileType<cloudmini>()] <= 0;
            if (petProjectileNotSpawnedAOB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<cloudmini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().raresandmini = true;
            bool petProjectileNotSpawnedAOC = player.ownedProjectileCounts[ModContent.ProjectileType<raresandmini>()] <= 0;
            if (petProjectileNotSpawnedAOC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<raresandmini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().sandmini = true;
            bool petProjectileNotSpawnedAOD = player.ownedProjectileCounts[ModContent.ProjectileType<sandmini>()] <= 0;
            if (petProjectileNotSpawnedAOD && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<sandmini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().babywaterclone = true;
            bool petProjectileNotSpawnedAOE = player.ownedProjectileCounts[ModContent.ProjectileType<babywaterclone>()] <= 0;
            if (petProjectileNotSpawnedAOE && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<babywaterclone>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAPA = player.ownedProjectileCounts[ModContent.ProjectileType<ThanatosPet>()] <= 0;
            if (petProjectileNotSpawnedAPA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<ThanatosPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedAPB = player.ownedProjectileCounts[ModContent.ProjectileType<AresBody>()] <= 0;
            if (petProjectileNotSpawnedAPB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<AresBody>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedAPC = player.ownedProjectileCounts[ModContent.ProjectileType<TwinsPet>()] <= 0;
            if (petProjectileNotSpawnedAPC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<TwinsPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mAmb = true;
            bool petProjectileNotSpawnedAQA = player.ownedProjectileCounts[ModContent.ProjectileType<AmberPet>()] <= 0;
            if (petProjectileNotSpawnedAQA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<AmberPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mAme = true;
            bool petProjectileNotSpawnedAQB = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Scuttlers.AmethystPet>()] <= 0;
            if (petProjectileNotSpawnedAQB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Scuttlers.AmethystPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().rainbow = true;
            bool petProjectileNotSpawnedAQC = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Scuttlers.BejeweledScuttler>()] <= 0;
            if (petProjectileNotSpawnedAQC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Scuttlers.BejeweledScuttler>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mCry = true;
            bool petProjectileNotSpawnedAQD = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Scuttlers.CrystalPet>()] <= 0;
            if (petProjectileNotSpawnedAQD && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Scuttlers.CrystalPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mDia = true;
            bool petProjectileNotSpawnedAQE = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Scuttlers.DiamondPet>()] <= 0;
            if (petProjectileNotSpawnedAQE && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Scuttlers.DiamondPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mEme = true;
            bool petProjectileNotSpawnedAQF = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Scuttlers.EmeraldPet>()] <= 0;
            if (petProjectileNotSpawnedAQF && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Scuttlers.EmeraldPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mRub = true;
            bool petProjectileNotSpawnedAQG = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Scuttlers.RubyPet>()] <= 0;
            if (petProjectileNotSpawnedAQG && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Scuttlers.RubyPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mSap = true;
            bool petProjectileNotSpawnedAQH = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Scuttlers.SapphirePet>()] <= 0;
            if (petProjectileNotSpawnedAQH && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Scuttlers.SapphirePet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mTop = true;
            bool petProjectileNotSpawnedAQI = player.ownedProjectileCounts[ModContent.ProjectileType<TopazPet>()] <= 0;
            if (petProjectileNotSpawnedAQI && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<TopazPet>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mDebris = true;
            bool petProjectileNotSpawnedAR = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.PhantomPet>()] <= 0;
            if (petProjectileNotSpawnedAR && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.PhantomPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().VoidOrb = true;
            bool petProjectileNotSpawnedAS = player.ownedProjectileCounts[mod.ProjectileType("VoidOrb")] <= 0;
            if (petProjectileNotSpawnedAS && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("VoidOrb"), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().deussmall = true;
            bool petProjectileNotSpawnedATA = player.ownedProjectileCounts[mod.ProjectileType("DeusPetSmall")] <= 0;
            if (petProjectileNotSpawnedATA && player.whoAmI == Main.myPlayer)
            {
                for (int k = 0; k < 10; k++)
                {
                    Projectile.NewProjectile(player.position.X + (float)(player.width / 2) + (32 * k), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("DeusPetSmall"), 0, 0f, player.whoAmI, 0f, 0f);
                }
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().deusmain = true;
            bool petProjectileNotSpawnedATB = player.ownedProjectileCounts[mod.ProjectileType("DeusPet")] <= 0;
            if (petProjectileNotSpawnedATB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height * 20), 0f, 0f, mod.ProjectileType("DeusPet"), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().voreworm = true;
            bool petProjectileNotSpawnedAU = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.DogHead>()] <= 0;
            if (petProjectileNotSpawnedAU && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<DogHead>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().Angrypup = true;
            bool petProjectileNotSpawnedAV = player.ownedProjectileCounts[mod.ProjectileType("Angrypup")] <= 0;
            if (petProjectileNotSpawnedAV && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("Angrypup"), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().BoldLizard = true;
            bool petProjectileNotSpawnedAW = player.ownedProjectileCounts[mod.ProjectileType("BoldLizard")] <= 0;
            if (petProjectileNotSpawnedAW && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("BoldLizard"), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().euros = true;
            bool petProjectileNotSpawnedAX = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Euros>()] <= 0;
            if (petProjectileNotSpawnedAX && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Euros>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().feel = true;
            bool petProjectileNotSpawnedAY = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.FathomEelHead>()] <= 0;
            if (petProjectileNotSpawnedAY && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.FathomEelHead>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mPerf = true;
            bool petProjectileNotSpawnedAZ = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Fistuloid>()] <= 0;
            if (petProjectileNotSpawnedAZ && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Fistuloid>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().fog = true;
            bool petProjectileNotSpawnedBA = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.FogPet>()] <= 0;
            if (petProjectileNotSpawnedBA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.FogPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mFolly = true;
            bool petProjectileNotSpawnedBB = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.FollyPet>()] <= 0;
            if (petProjectileNotSpawnedBB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.FollyPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().George = true;
            bool petProjectileNotSpawnedBC = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.George>()] <= 0;
            if (petProjectileNotSpawnedBC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.George>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().goozmaPet = true;
            bool petProjectileNotSpawnedBD = player.ownedProjectileCounts[ModContent.ProjectileType<GoozmaPet>()] <= 0;
            if (petProjectileNotSpawnedBD && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.GoozmaPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mHive = true;
            bool petProjectileNotSpawnedBE = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Hiveling>()] <= 0;
            if (petProjectileNotSpawnedBE && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Hiveling>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().eidolist = true;
            bool petProjectileNotSpawnedBF = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Hoodieidolist>()] <= 0;
            if (petProjectileNotSpawnedBF && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Hoodieidolist>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().jared = true;
            bool petProjectileNotSpawnedBG = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.JaredHead>()] <= 0;
            if (petProjectileNotSpawnedBG && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.JaredHead>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().StarJelly = true;
            bool petProjectileNotSpawnedBH = player.ownedProjectileCounts[mod.ProjectileType("StarJelly")] <= 0;
            if (petProjectileNotSpawnedBH && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("StarJelly"), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().junsi = true;
            bool petProjectileNotSpawnedBI = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Junko>()] <= 0;
            if (petProjectileNotSpawnedBI && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Junko>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().MechaGeorge = true;
            bool petProjectileNotSpawnedBJ = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.MechaGeorge>()] <= 0;
            if (petProjectileNotSpawnedBJ && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.MechaGeorge>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mBirb = true;
            bool petProjectileNotSpawnedBK = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.MiniBumble>()] <= 0;
            if (petProjectileNotSpawnedBK && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.MiniBumble>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().bDoge = true;
            bool petProjectileNotSpawnedBLA = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.BugDoge>()] <= 0;
            if (petProjectileNotSpawnedBLA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.BugDoge>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().hDoge = true;
            bool petProjectileNotSpawnedBLB = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Headoge>()] <= 0;
            if (petProjectileNotSpawnedBLB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Headoge>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mDoge = true;
            bool petProjectileNotSpawnedBLC = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.MiniDoge>()] <= 0;
            if (petProjectileNotSpawnedBLC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.MiniDoge>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().moistPet = true;
            bool petProjectileNotSpawnedBM = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.MoistScourgePet>()] <= 0;
            if (petProjectileNotSpawnedBM && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.MoistScourgePet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mDuke = true;
            bool petProjectileNotSpawnedBN = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.NuclearfuryshronPet>()] <= 0;
            if (petProjectileNotSpawnedBN && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.NuclearfuryshronPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().Nugget = true;
            bool petProjectileNotSpawnedBO = player.ownedProjectileCounts[mod.ProjectileType("Nugget")] <= 0;
            if (petProjectileNotSpawnedBO && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("Nugget"), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().oSquid = true;
            bool petProjectileNotSpawnedBP = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.OmegaSquid>()] <= 0;
            if (petProjectileNotSpawnedBP && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.OmegaSquid>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().dBall = true;
            bool petProjectileNotSpawnedBQ = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Dragonball>()] <= 0;
            if (petProjectileNotSpawnedBQ && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Dragonball>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().AstPhage = true;
            bool petProjectileNotSpawnedBR = player.ownedProjectileCounts[mod.ProjectileType("AstPhage")] <= 0;
            if (petProjectileNotSpawnedBR && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("AstPhage"), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mRav = true;
            bool petProjectileNotSpawnedBS = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Pillager>()] <= 0;
            if (petProjectileNotSpawnedBS && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Pillager>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mChan = true;
            bool petProjectileNotSpawnedBT = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.PolterChan>()] <= 0;
            if (petProjectileNotSpawnedBT && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.PolterChan>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().Chihuahua = true;
            bool petProjectileNotSpawnedBU = player.ownedProjectileCounts[mod.ProjectileType("Puppo")] <= 0;
            if (petProjectileNotSpawnedBU && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("Puppo"), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().rPanda = true;
            bool petProjectileNotSpawnedBV = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.RedPanda>()] <= 0;
            if (petProjectileNotSpawnedBV && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.RedPanda>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().sirember = true;
            bool petProjectileNotSpawnedBX = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Sirember>()] <= 0;
            if (petProjectileNotSpawnedBX && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Sirember>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().RepairBot = true;
            bool petProjectileNotSpawnedBY = player.ownedProjectileCounts[mod.ProjectileType("RepairBot")] <= 0;
            if (petProjectileNotSpawnedBY && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("RepairBot"), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().roverd = true;
            bool petProjectileNotSpawnedBZ = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.RoverSpindlePet>()] <= 0;
            if (petProjectileNotSpawnedBZ && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.RoverSpindlePet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().rusty = true;
            bool petProjectileNotSpawnedCA = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.RustyMimic>()] <= 0;
            if (petProjectileNotSpawnedCA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.RustyMimic>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().Dstone = true;
            bool petProjectileNotSpawnedCB = player.ownedProjectileCounts[mod.ProjectileType("Dstone")] <= 0;
            if (petProjectileNotSpawnedCB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("Dstone"), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().sDuke = true;
            bool petProjectileNotSpawnedCC = player.ownedProjectileCounts[ModContent.ProjectileType<ScoriaDuke>()] <= 0;
            if (petProjectileNotSpawnedCC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<ScoriaDuke>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().asPet = true;
            bool petProjectileNotSpawnedCD = player.ownedProjectileCounts[ModContent.ProjectileType<AquaPet>()] <= 0;
            if (petProjectileNotSpawnedCD && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height * 10,
                    0f, 0f, ModContent.ProjectileType<AquaPet>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().dsPet = true;
            bool petProjectileNotSpawnedCE = player.ownedProjectileCounts[ModContent.ProjectileType<DesertPet>()] <= 0;
            if (petProjectileNotSpawnedCE && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<DesertPet>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().sSignus = true;
            bool petProjectileNotSpawnedCFA = player.ownedProjectileCounts[ModContent.ProjectileType<SSignus>()] <= 0;
            if (petProjectileNotSpawnedCFA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SSignus>(), 0, 0f, player.whoAmI);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().sVoid = true;
            bool petProjectileNotSpawnedCFB = player.ownedProjectileCounts[ModContent.ProjectileType<SVoid>()] <= 0;
            if (petProjectileNotSpawnedCFB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SVoid>(), 0, 0f, player.whoAmI);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().sWeeb = true;
            bool petProjectileNotSpawnedCFC = player.ownedProjectileCounts[ModContent.ProjectileType<SWeeb>()] <= 0;
            if (petProjectileNotSpawnedCFC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SWeeb>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().sepet = true;
            bool petProjectileNotSpawnedCGA = player.ownedProjectileCounts[ModContent.ProjectileType<Sepulchling>()] <= 0;
            if (petProjectileNotSpawnedCGA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<Sepulchling>(), 0, 0f, player.whoAmI);
            }
            Mod orthoceraDLC = ModLoader.GetMod("CalValPlus");
            if (CalValEX.month != 4 && orthoceraDLC == null)
            {
                player.buffTime[buffIndex] = 18000;
                player.GetModPlayer<CalValEXPlayer>().BMonster = true;
                bool petProjectileNotSpawnedCGB = player.ownedProjectileCounts[ModContent.ProjectileType<BabyMonster>()] <= 0;
                if (petProjectileNotSpawnedCGB && player.whoAmI == Main.myPlayer)
                {
                    Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                        0f, 0f, ModContent.ProjectileType<BabyMonster>(), 0, 0f, player.whoAmI);
                }
            }
            if (CalValEX.month == 4 || orthoceraDLC != null)
            {
                player.buffTime[buffIndex] = 18000;
                player.GetModPlayer<CalValEXPlayer>().hage = true;
                bool petProjectileNotSpawnedCGC = player.ownedProjectileCounts[ModContent.ProjectileType<BabyHage>()] <= 0;
                if (petProjectileNotSpawnedCGC && player.whoAmI == Main.myPlayer)
                {
                    Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                        0f, 0f, ModContent.ProjectileType<BabyHage>(), 0, 0f, player.whoAmI);
                }
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().sepneo = true;
            bool petProjectileNotSpawnedCH = player.ownedProjectileCounts[ModContent.ProjectileType<SepulcherHeadNeo>()] <= 0;
            if (petProjectileNotSpawnedCH && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SepulcherHeadNeo>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mShark = true;
            player.GetModPlayer<CalValEXPlayer>().shart = true;
            bool petProjectileNotSpawnedCIA = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.GrandPet>()] <= 0;
            if (petProjectileNotSpawnedCIA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.GrandPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().buffboi = true;
            bool petProjectileNotSpawnedCIB = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.BuffReaper>()] <= 0;
            if (petProjectileNotSpawnedCIB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.BuffReaper>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().smaul = true;
            bool petProjectileNotSpawnedCIC = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Smauler>()] <= 0;
            if (petProjectileNotSpawnedCIC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Smauler>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mSkater = true;
            bool petProjectileNotSpawnedCJ = player.ownedProjectileCounts[ModContent.ProjectileType<SkaterPet>()] <= 0;
            if (petProjectileNotSpawnedCJ && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SkaterPet>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mSlime = true;
            bool petProjectileNotSpawnedCK = player.ownedProjectileCounts[ModContent.ProjectileType<SlimeDemi>()] <= 0;
            if (petProjectileNotSpawnedCK && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SlimeDemi>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mArmored = true;
            bool petProjectileNotSpawnedCL = player.ownedProjectileCounts[ModContent.ProjectileType<StasisArmored>()] <= 0;
            if (petProjectileNotSpawnedCL && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<StasisArmored>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().SWPet = true;
            bool petProjectileNotSpawnedCM = player.ownedProjectileCounts[ModContent.ProjectileType<SWPet>()] <= 0;
            if (petProjectileNotSpawnedCM && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SWPet>(), 0, 0f, player.whoAmI);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mNaked = true;
            bool petProjectileNotSpawnedCN = player.ownedProjectileCounts[ModContent.ProjectileType<StasisNaked>()] <= 0;
            if (petProjectileNotSpawnedCN && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<StasisNaked>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().TerminalRock = true;
            bool petProjectileNotSpawnedCO = player.ownedProjectileCounts[mod.ProjectileType("TerminalRock")] <= 0;
            if (petProjectileNotSpawnedCO && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, mod.ProjectileType("TerminalRock"), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().tub = true;
            bool petProjectileNotSpawnedCP = player.ownedProjectileCounts[ModContent.ProjectileType<TUB>()] <= 0;
            if (petProjectileNotSpawnedCP && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<TUB>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().uSerpent = true;
            bool petProjectileNotSpawnedCQ = player.ownedProjectileCounts[ModContent.ProjectileType<UngodlySerpent>()] <= 0;
            if (petProjectileNotSpawnedCQ && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<UngodlySerpent>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().drone = true;
            bool petProjectileNotSpawnedCRA = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumDrone>()] <= 0;
            if (petProjectileNotSpawnedCRA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<WulfrumDrone>(), 0, 0f, player.whoAmI);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().rover = true;
            bool petProjectileNotSpawnedCRB = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumRover>()] <= 0;
            if (petProjectileNotSpawnedCRB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<WulfrumRover>(), 0, 0f, player.whoAmI);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().hover = true;
            bool petProjectileNotSpawnedCRC = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumHover>()] <= 0;
            if (petProjectileNotSpawnedCRC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<WulfrumHover>(), 0, 0f, player.whoAmI);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().worb = true;
            bool petProjectileNotSpawnedCRD = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumOrb>()] <= 0;
            if (petProjectileNotSpawnedCRD && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<WulfrumOrb>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().EWyrm = true;
            bool petProjectileNotSpawnedCS = player.ownedProjectileCounts[mod.ProjectileType("EWyrm")] <= 0;
            if (petProjectileNotSpawnedCS && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, mod.ProjectileType("EWyrm"), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().ySquid = true;
            bool petProjectileNotSpawnedCT = player.ownedProjectileCounts[ModContent.ProjectileType<YharimSquid>()] <= 0;
            if (petProjectileNotSpawnedCT && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<YharimSquid>(), 0, 0f, player.whoAmI);
            }

            Mod clamMod = ModLoader.GetMod("CalamityMod");
            clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 4);
            List<int> pets = new List<int>
            {
                ModContent.ProjectileType<DarksunSpirit_Fish>(),
                ModContent.ProjectileType<DarksunSpiritSkull_1>(),
                ModContent.ProjectileType<DarksunSpiritSkull_2>()
            };
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().darksunSpirits = true;
            bool petProjectileNotSpawnedCU = true;
            for (int i = 0; i < pets.Count; i++)
                if (player.ownedProjectileCounts[pets[i]] > 0)
                {
                    petProjectileNotSpawnedCU = false;
                }

            if (petProjectileNotSpawnedCU && player.whoAmI == Main.myPlayer)
            {
                for (int i = 0; i < pets.Count; i++)
                    Projectile.NewProjectile(player.position.X + player.width / 2,
                        player.position.Y + player.height / 2, 0f, 0f, pets[i], 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().digger = true;
            bool petProjectileNotSpawnedCV = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.LightPets.DiggerPet>()] <= 0;
            if (petProjectileNotSpawnedCV && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Pets.LightPets.DiggerPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 4);
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().Enredpet = true;
            bool petProjectileNotSpawnedCW = player.ownedProjectileCounts[mod.ProjectileType("Enredpet")] <= 0;
            if (petProjectileNotSpawnedCW && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, mod.ProjectileType("Enredpet"), 0, 0f, player.whoAmI);
            }

            clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 3);
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().GeorgeII = true;
            bool petProjectileNotSpawnedCX = player.ownedProjectileCounts[ModContent.ProjectileType<Godrge>()] <= 0;
            if (petProjectileNotSpawnedCX && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<Godrge>(), 0, 0f, player.whoAmI);
            }

            clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 3);
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().ProGuard1 = true;
            player.GetModPlayer<CalValEXPlayer>().ProGuard2 = true;
            player.GetModPlayer<CalValEXPlayer>().ProGuard3 = true;
            player.GetModPlayer<CalValEXPlayer>().ProviPet = true;
            bool petProjectileNotSpawnedCY = player.ownedProjectileCounts[mod.ProjectileType("ProGuard1")] <= 0 &&
                                           player.ownedProjectileCounts[mod.ProjectileType("ProGuard2")] <= 0 &&
                                           player.ownedProjectileCounts[mod.ProjectileType("ProGuard3")] <= 0 &&
                                           player.ownedProjectileCounts[mod.ProjectileType("ProviPet")] <= 0;
            if (petProjectileNotSpawnedCY && player.whoAmI == Main.myPlayer)
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

            clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 1);
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().pylon = true;
            bool petProjectileNotSpawnedCZ = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumPylon>()] <= 0;
            if (petProjectileNotSpawnedCZ && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<WulfrumPylon>(), 0, 0f, player.whoAmI);
            }

            clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 2);
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().seerS = true;
            bool petProjectileNotSpawnedDA = player.ownedProjectileCounts[ModContent.ProjectileType<SeerS>()] <= 0;
            if (petProjectileNotSpawnedDA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SeerS>(), 0, 0f, player.whoAmI);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().seerM = true;
            bool petProjectileNotSpawnedDB = player.ownedProjectileCounts[ModContent.ProjectileType<SeerM>()] <= 0;
            if (petProjectileNotSpawnedDB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SeerM>(), 0, 0f, player.whoAmI);
            }
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().seerL = true;
            bool petProjectileNotSpawnedDC = player.ownedProjectileCounts[ModContent.ProjectileType<SeerL>()] <= 0;
            if (petProjectileNotSpawnedDC && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SeerL>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().sBun = true;
            bool petProjectileNotSpawnedDD = player.ownedProjectileCounts[ModContent.ProjectileType<SolarBunny>()] <= 0;
            if (petProjectileNotSpawnedDD && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SolarBunny>(), 0, 0f, player.whoAmI);
            }
            clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 3);

            clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 5);
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().SupJ = true;
            bool petProjectileNotSpawnedDE = player.ownedProjectileCounts[ModContent.ProjectileType<SpookShark>()] <= 0;
            if (petProjectileNotSpawnedDE && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SpookShark>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().SupJ = true;
            bool petProjectileNotSpawnedDF = player.ownedProjectileCounts[ModContent.ProjectileType<SpookSmall>()] <= 0;
            if (petProjectileNotSpawnedDF && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SpookSmall>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().SupJ = true;
            bool petProjectileNotSpawnedDG = player.ownedProjectileCounts[ModContent.ProjectileType<Bishop>()] <= 0;
            if (petProjectileNotSpawnedDG && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<Bishop>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().SupJ = true;
            bool petProjectileNotSpawnedDH = player.ownedProjectileCounts[ModContent.ProjectileType<EndoRune>()] <= 0;
            if (petProjectileNotSpawnedDH && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<EndoRune>(), 0, 0f, player.whoAmI);
            }

            if (CalValEXConfig.Instance.SupCombo)
            {
                List<int> petscombo = new List<int>
                {
                    ModContent.ProjectileType<HeatPet>(),
                    ModContent.ProjectileType<HeatBaby>(),
                    ModContent.ProjectileType<Skeetyeet>(),
                    //ModContent.ProjectileType<Lightshield>(),
                    ModContent.ProjectileType<DarksunSpirit_Fish>(),
                    ModContent.ProjectileType<DarksunSpiritSkull_1>(),
                    ModContent.ProjectileType<DarksunSpiritSkull_2>(),
                    ModContent.ProjectileType<MiniCryo>(),
                    ModContent.ProjectileType<PhantomSpirit>(),
                    ModContent.ProjectileType<Minimpious>()
                };

                player.buffTime[buffIndex] = 18000;
                player.GetModPlayer<CalValEXPlayer>().mHeat = true;
                player.GetModPlayer<CalValEXPlayer>().mHeat2 = true;
                player.GetModPlayer<CalValEXPlayer>().Skeetyeet = true;
                //player.GetModPlayer<CalValEXPlayer>().Lightshield = true;
                player.GetModPlayer<CalValEXPlayer>().darksunSpirits = true;
                player.GetModPlayer<CalValEXPlayer>().MiniCryo = true;
                player.GetModPlayer<CalValEXPlayer>().mPhan = true;
                player.GetModPlayer<CalValEXPlayer>().mImp = true;
                bool petProjectileNotSpawnedcomboDI = true;
                for (int i = 0; i < petscombo.Count; i++)
                    if (player.ownedProjectileCounts[petscombo[i]] > 0)
                    {
                        petProjectileNotSpawnedcomboDI = false;
                    }

                if (petProjectileNotSpawnedcomboDI && player.whoAmI == Main.myPlayer)
                {
                    for (int i = 0; i < petscombo.Count; i++)
                        Projectile.NewProjectile(player.position.X + player.width / 2,
                            player.position.Y + player.height / 2, 0f, 0f, petscombo[i], 0, 0f, player.whoAmI);
                }
            }
        }
    }
}