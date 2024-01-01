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
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            
            //Mod orthoceraDLC = ModLoader.GetMod("CalValPlus");
            //Mod clamMod = ModLoader.GetMod("CalamityMod");
            //clamMod.Call("AddAbyssLightStrength", Main.player[Main.myPlayer], 4);

            player.GetModPlayer<CalValEXPlayer>().Pandora = true;
            player.GetModPlayer<CalValEXPlayer>().mAero = true;
            player.GetModPlayer<CalValEXPlayer>().aero = true;
            player.GetModPlayer<CalValEXPlayer>().andro = true;
            player.GetModPlayer<CalValEXPlayer>().avalon = true;
            player.GetModPlayer<CalValEXPlayer>().squid = true;
            player.GetModPlayer<CalValEXPlayer>().PBGmini = true;
            player.GetModPlayer<CalValEXPlayer>().Blok = true;
            player.GetModPlayer<CalValEXPlayer>().buppy = true;
            player.GetModPlayer<CalValEXPlayer>().CalamityBABYBool = true;
            player.GetModPlayer<CalValEXPlayer>().catfish = true;
            player.GetModPlayer<CalValEXPlayer>().Cryokid = true;
            player.GetModPlayer<CalValEXPlayer>().mClam = true;
            player.GetModPlayer<CalValEXPlayer>().BabyCnidrion = true;
            player.GetModPlayer<CalValEXPlayer>().bSignut = true;
            player.GetModPlayer<CalValEXPlayer>().bSlime = true;
            player.GetModPlayer<CalValEXPlayer>().SmolCrab = true;
            player.GetModPlayer<CalValEXPlayer>().rarebrimling = true;
            player.GetModPlayer<CalValEXPlayer>().cloudmini = true;
            player.GetModPlayer<CalValEXPlayer>().raresandmini = true;
            player.GetModPlayer<CalValEXPlayer>().sandmini = true;
            player.GetModPlayer<CalValEXPlayer>().babywaterclone = true;
            player.GetModPlayer<CalValEXPlayer>().mAmb = true;
            player.GetModPlayer<CalValEXPlayer>().mAme = true;
            player.GetModPlayer<CalValEXPlayer>().rainbow = true;
            player.GetModPlayer<CalValEXPlayer>().mCry = true;
            player.GetModPlayer<CalValEXPlayer>().mDia = true;
            player.GetModPlayer<CalValEXPlayer>().mEme = true;
            player.GetModPlayer<CalValEXPlayer>().mRub = true;
            player.GetModPlayer<CalValEXPlayer>().mSap = true;
            player.GetModPlayer<CalValEXPlayer>().mTop = true;
            player.GetModPlayer<CalValEXPlayer>().mDebris = true;
            player.GetModPlayer<CalValEXPlayer>().VoidOrb = true;
            player.GetModPlayer<CalValEXPlayer>().deussmall = true;
            player.GetModPlayer<CalValEXPlayer>().deusmain = true;
            player.GetModPlayer<CalValEXPlayer>().voreworm = true;
            player.GetModPlayer<CalValEXPlayer>().Angrypup = true;
            player.GetModPlayer<CalValEXPlayer>().BoldLizard = true;
            player.GetModPlayer<CalValEXPlayer>().euros = true;
            player.GetModPlayer<CalValEXPlayer>().feel = true;
            player.GetModPlayer<CalValEXPlayer>().mPerf = true;
            player.GetModPlayer<CalValEXPlayer>().fog = true;
            player.GetModPlayer<CalValEXPlayer>().mFolly = true;
            player.GetModPlayer<CalValEXPlayer>().George = true;
            player.GetModPlayer<CalValEXPlayer>().goozmaPet = true;
            player.GetModPlayer<CalValEXPlayer>().mHive = true;
            player.GetModPlayer<CalValEXPlayer>().eidolist = true;
            player.GetModPlayer<CalValEXPlayer>().jared = true;
            player.GetModPlayer<CalValEXPlayer>().StarJelly = true;
            player.GetModPlayer<CalValEXPlayer>().junsi = true;
            player.GetModPlayer<CalValEXPlayer>().MechaGeorge = true;
            player.GetModPlayer<CalValEXPlayer>().mBirb = true;
            player.GetModPlayer<CalValEXPlayer>().bDoge = true;
            player.GetModPlayer<CalValEXPlayer>().hDoge = true;
            player.GetModPlayer<CalValEXPlayer>().mDoge = true;
            player.GetModPlayer<CalValEXPlayer>().moistPet = true;
            player.GetModPlayer<CalValEXPlayer>().mDuke = true;
            player.GetModPlayer<CalValEXPlayer>().Nugget = true;
            player.GetModPlayer<CalValEXPlayer>().oSquid = true;
            player.GetModPlayer<CalValEXPlayer>().dBall = true;
            player.GetModPlayer<CalValEXPlayer>().AstPhage = true;
            player.GetModPlayer<CalValEXPlayer>().mRav = true;
            player.GetModPlayer<CalValEXPlayer>().mChan = true;
            player.GetModPlayer<CalValEXPlayer>().Chihuahua = true;
            player.GetModPlayer<CalValEXPlayer>().rPanda = true;
            player.GetModPlayer<CalValEXPlayer>().sirember = true;
            player.GetModPlayer<CalValEXPlayer>().RepairBot = true;
            player.GetModPlayer<CalValEXPlayer>().roverd = true;
            player.GetModPlayer<CalValEXPlayer>().rusty = true;
            player.GetModPlayer<CalValEXPlayer>().Dstone = true;
            player.GetModPlayer<CalValEXPlayer>().sDuke = true;
            player.GetModPlayer<CalValEXPlayer>().asPet = true;
            player.GetModPlayer<CalValEXPlayer>().dsPet = true;
            player.GetModPlayer<CalValEXPlayer>().sSignus = true;
            player.GetModPlayer<CalValEXPlayer>().sVoid = true;
            player.GetModPlayer<CalValEXPlayer>().sWeeb = true;
            player.GetModPlayer<CalValEXPlayer>().sepet = true;
            player.GetModPlayer<CalValEXPlayer>().sepneo = true;
            player.GetModPlayer<CalValEXPlayer>().mShark = true;
            player.GetModPlayer<CalValEXPlayer>().shart = true;
            player.GetModPlayer<CalValEXPlayer>().buffboi = true;
            player.GetModPlayer<CalValEXPlayer>().smaul = true;
            player.GetModPlayer<CalValEXPlayer>().mSkater = true;
            player.GetModPlayer<CalValEXPlayer>().mSlime = true;
            player.GetModPlayer<CalValEXPlayer>().mArmored = true;
            player.GetModPlayer<CalValEXPlayer>().SWPet = true;
            player.GetModPlayer<CalValEXPlayer>().mNaked = true;
            player.GetModPlayer<CalValEXPlayer>().TerminalRock = true;
            player.GetModPlayer<CalValEXPlayer>().tub = true;
            player.GetModPlayer<CalValEXPlayer>().uSerpent = true;
            player.GetModPlayer<CalValEXPlayer>().drone = true;
            player.GetModPlayer<CalValEXPlayer>().rover = true;
            player.GetModPlayer<CalValEXPlayer>().hover = true;
            player.GetModPlayer<CalValEXPlayer>().worb = true;
            player.GetModPlayer<CalValEXPlayer>().EWyrm = true;
            player.GetModPlayer<CalValEXPlayer>().ySquid = true;
            player.GetModPlayer<CalValEXPlayer>().darksunSpirits = true;
            player.GetModPlayer<CalValEXPlayer>().digger = true;
            player.GetModPlayer<CalValEXPlayer>().Enredpet = true;
            player.GetModPlayer<CalValEXPlayer>().GeorgeII = true;
            player.GetModPlayer<CalValEXPlayer>().ProGuard1 = true;
            player.GetModPlayer<CalValEXPlayer>().ProGuard2 = true;
            player.GetModPlayer<CalValEXPlayer>().ProGuard3 = true;
            player.GetModPlayer<CalValEXPlayer>().ProviPet = true;
            player.GetModPlayer<CalValEXPlayer>().pylon = true;
            player.GetModPlayer<CalValEXPlayer>().seerS = true;
            player.GetModPlayer<CalValEXPlayer>().seerM = true;
            player.GetModPlayer<CalValEXPlayer>().seerL = true;
            player.GetModPlayer<CalValEXPlayer>().sBun = true;
            player.GetModPlayer<CalValEXPlayer>().SupJ = true;
            player.GetModPlayer<CalValEXPlayer>().mHeat = true;
            player.GetModPlayer<CalValEXPlayer>().mHeat2 = true;
            player.GetModPlayer<CalValEXPlayer>().Skeetyeet = true;
            player.GetModPlayer<CalValEXPlayer>().darksunSpirits = true;
            player.GetModPlayer<CalValEXPlayer>().MiniCryo = true;
            player.GetModPlayer<CalValEXPlayer>().mPhan = true;
            player.GetModPlayer<CalValEXPlayer>().mImp = true;
            player.GetModPlayer<CalValEXPlayer>().ares = true;
            player.GetModPlayer<CalValEXPlayer>().thanos = true;
            player.GetModPlayer<CalValEXPlayer>().twins = true;

            bool petProjectileNotSpawnedAA = player.ownedProjectileCounts[ModContent.ProjectileType<AeroBaby>()] <= 0;
            if (petProjectileNotSpawnedAA && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<AeroBaby>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedAAB = player.ownedProjectileCounts[ModContent.ProjectileType<AeroSlimePet>()] <= 0;
            if (petProjectileNotSpawnedAAB && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<AeroSlimePet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAB = player.ownedProjectileCounts[ModContent.ProjectileType<Androomba>()] <= 0;
            if (petProjectileNotSpawnedAB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Androomba>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAC = player.ownedProjectileCounts[ModContent.ProjectileType<Avalon>()] <= 0;
            if (petProjectileNotSpawnedAC && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Avalon>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAD = player.ownedProjectileCounts[ModContent.ProjectileType<BabySquid>()] <= 0;
            if (petProjectileNotSpawnedAD && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<BabySquid>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAE = player.ownedProjectileCounts[ModContent.ProjectileType<PBGmini>()] <= 0;
            if (petProjectileNotSpawnedAE && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<PBGmini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAF = (player.ownedProjectileCounts[ModContent.ProjectileType<Blockaroz>()] <= 0);
            if (petProjectileNotSpawnedAF && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Blockaroz>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAG = player.ownedProjectileCounts[ModContent.ProjectileType<Buppy>()] <= 0;
            if (petProjectileNotSpawnedAG && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Buppy>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAH = player.ownedProjectileCounts[ModContent.ProjectileType<CalamityBABY>()] <= 0;
            if (petProjectileNotSpawnedAH && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<CalamityBABY>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAI = player.ownedProjectileCounts[ModContent.ProjectileType<Catfish>()] <= 0;
            if (petProjectileNotSpawnedAI && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Catfish>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAJ = player.ownedProjectileCounts[ModContent.ProjectileType<Cryokid>()] <= 0;
            if (petProjectileNotSpawnedAJ && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Cryokid>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAK = player.ownedProjectileCounts[ModContent.ProjectileType<ClamHermit>()] <= 0;
            if (petProjectileNotSpawnedAK && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<ClamHermit>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAL = player.ownedProjectileCounts[ModContent.ProjectileType<BabyCnidrion>()] <= 0;
            if (petProjectileNotSpawnedAL && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<BabyCnidrion>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAMA = player.ownedProjectileCounts[ModContent.ProjectileType<CoolBlueSignut>()] <= 0;
            if (petProjectileNotSpawnedAMA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<CoolBlueSignut>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedAMB = player.ownedProjectileCounts[ModContent.ProjectileType<CoolBlueSlime>()] <= 0;
            if (petProjectileNotSpawnedAMB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<CoolBlueSlime>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAN = player.ownedProjectileCounts[ModContent.ProjectileType<SmolCrab>()] <= 0;
            if (petProjectileNotSpawnedAN && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<SmolCrab>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAOA = player.ownedProjectileCounts[ModContent.ProjectileType<RareBrimling>()] <= 0;
            if (petProjectileNotSpawnedAOA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<RareBrimling>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedAOB = player.ownedProjectileCounts[ModContent.ProjectileType<CloudMini>()] <= 0;
            if (petProjectileNotSpawnedAOB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<CloudMini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedAOC = player.ownedProjectileCounts[ModContent.ProjectileType<RaresandMini>()] <= 0;
            if (petProjectileNotSpawnedAOC && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<RaresandMini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedAOD = player.ownedProjectileCounts[ModContent.ProjectileType<Sandmini>()] <= 0;
            if (petProjectileNotSpawnedAOD && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Sandmini>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedAOE = player.ownedProjectileCounts[ModContent.ProjectileType<BabyWaterClone>()] <= 0;
            if (petProjectileNotSpawnedAOE && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<BabyWaterClone>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAPA = player.ownedProjectileCounts[ModContent.ProjectileType<ThanatosPet>()] <= 0;
            if (petProjectileNotSpawnedAPA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<ThanatosPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedAPB = player.ownedProjectileCounts[ModContent.ProjectileType<AresBody>()] <= 0;
            if (petProjectileNotSpawnedAPB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<AresBody>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedAPC = player.ownedProjectileCounts[ModContent.ProjectileType<TwinsPet>()] <= 0;
            if (petProjectileNotSpawnedAPC && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<TwinsPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAQA = player.ownedProjectileCounts[ModContent.ProjectileType<AmberPet>()] <= 0;
            if (petProjectileNotSpawnedAQA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<AmberPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedAQB = player.ownedProjectileCounts[ModContent.ProjectileType<AmethystPet>()] <= 0;
            if (petProjectileNotSpawnedAQB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<AmethystPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedAQC = player.ownedProjectileCounts[ModContent.ProjectileType<BejeweledScuttler>()] <= 0;
            if (petProjectileNotSpawnedAQC && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<BejeweledScuttler>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedAQD = player.ownedProjectileCounts[ModContent.ProjectileType<CrystalPet>()] <= 0;
            if (petProjectileNotSpawnedAQD && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<CrystalPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedAQE = player.ownedProjectileCounts[ModContent.ProjectileType<DiamondPet>()] <= 0;
            if (petProjectileNotSpawnedAQE && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<DiamondPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedAQF = player.ownedProjectileCounts[ModContent.ProjectileType<EmeraldPet>()] <= 0;
            if (petProjectileNotSpawnedAQF && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<EmeraldPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedAQG = player.ownedProjectileCounts[ModContent.ProjectileType<RubyPet>()] <= 0;
            if (petProjectileNotSpawnedAQG && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<RubyPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedAQH = player.ownedProjectileCounts[ModContent.ProjectileType<SapphirePet>()] <= 0;
            if (petProjectileNotSpawnedAQH && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<SapphirePet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedAQI = player.ownedProjectileCounts[ModContent.ProjectileType<TopazPet>()] <= 0;
            if (petProjectileNotSpawnedAQI && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<TopazPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAR = player.ownedProjectileCounts[ModContent.ProjectileType<PhantomPet>()] <= 0;
            if (petProjectileNotSpawnedAR && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<PhantomPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAS = player.ownedProjectileCounts[ModContent.ProjectileType<VoidOrb>()] <= 0;
            if (petProjectileNotSpawnedAS && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<WulfrumPylon>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedATA = player.ownedProjectileCounts[ModContent.ProjectileType<DeusPetSmall>()] <= 0;
            if (petProjectileNotSpawnedATA && player.whoAmI == Main.myPlayer){
                for (int k = 0; k < 8; k++){
                    Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                        player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<DeusPetSmall>(), 0, 0f, player.whoAmI, 0f, 0f);
                }
            }
            bool petProjectileNotSpawnedATB = player.ownedProjectileCounts[ModContent.ProjectileType<DeusPet>()] <= 0;
            if (petProjectileNotSpawnedATB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<DeusPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAU = player.ownedProjectileCounts[ModContent.ProjectileType<DogHead>()] <= 0;
            if (petProjectileNotSpawnedAU && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<DogHead>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAV = player.ownedProjectileCounts[ModContent.ProjectileType<Angrypup>()] <= 0;
            if (petProjectileNotSpawnedAV && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<WulfrumPylon>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAW = player.ownedProjectileCounts[ModContent.ProjectileType<BoldLizard>()] <= 0;
            if (petProjectileNotSpawnedAW && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<BoldLizard>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAX = player.ownedProjectileCounts[ModContent.ProjectileType<Euros>()] <= 0;
            if (petProjectileNotSpawnedAX && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Euros>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAY = player.ownedProjectileCounts[ModContent.ProjectileType<FathomEelHead>()] <= 0;
            if (petProjectileNotSpawnedAY && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<FathomEelHead>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedAZ = player.ownedProjectileCounts[ModContent.ProjectileType<Fistuloid>()] <= 0;
            if (petProjectileNotSpawnedAZ && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Fistuloid>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBA = player.ownedProjectileCounts[ModContent.ProjectileType<FogPet>()] <= 0;
            if (petProjectileNotSpawnedBA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<FogPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBB = player.ownedProjectileCounts[ModContent.ProjectileType<FollyPet>()] <= 0;
            if (petProjectileNotSpawnedBB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<FollyPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBC = player.ownedProjectileCounts[ModContent.ProjectileType<George>()] <= 0;
            if (petProjectileNotSpawnedBC && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<George>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBD = player.ownedProjectileCounts[ModContent.ProjectileType<GoozmaPet>()] <= 0;
            if (petProjectileNotSpawnedBD && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<GoozmaPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBE = player.ownedProjectileCounts[ModContent.ProjectileType<Hiveling>()] <= 0;
            if (petProjectileNotSpawnedBE && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Hiveling>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBF = player.ownedProjectileCounts[ModContent.ProjectileType<Hoodieidolist>()] <= 0;
            if (petProjectileNotSpawnedBF && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Hoodieidolist>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBG = player.ownedProjectileCounts[ModContent.ProjectileType<JaredHead>()] <= 0;
            if (petProjectileNotSpawnedBG && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<JaredHead>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedBH = player.ownedProjectileCounts[ModContent.ProjectileType<StarJelly>()] <= 0;
            if (petProjectileNotSpawnedBH && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<StarJelly>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBI = player.ownedProjectileCounts[ModContent.ProjectileType<Junko>()] <= 0;
            if (petProjectileNotSpawnedBI && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Junko>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBJ = player.ownedProjectileCounts[ModContent.ProjectileType<MechaGeorge>()] <= 0;
            if (petProjectileNotSpawnedBJ && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<MechaGeorge>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBK = player.ownedProjectileCounts[ModContent.ProjectileType<MiniBumble>()] <= 0;
            if (petProjectileNotSpawnedBK && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<MiniBumble>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBLA = player.ownedProjectileCounts[ModContent.ProjectileType<BugDoge>()] <= 0;
            if (petProjectileNotSpawnedBLA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<BugDoge>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedBLB = player.ownedProjectileCounts[ModContent.ProjectileType<Headoge>()] <= 0;
            if (petProjectileNotSpawnedBLB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Headoge>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedBLC = player.ownedProjectileCounts[ModContent.ProjectileType<MiniDoge>()] <= 0;
            if (petProjectileNotSpawnedBLC && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<MiniDoge>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBM = player.ownedProjectileCounts[ModContent.ProjectileType<MoistScourgePet>()] <= 0;
            if (petProjectileNotSpawnedBM && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<MoistScourgePet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBN = player.ownedProjectileCounts[ModContent.ProjectileType<NuclearfuryshronPet>()] <= 0;
            if (petProjectileNotSpawnedBN && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<NuclearfuryshronPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBO = player.ownedProjectileCounts[ModContent.ProjectileType<Nugget>()] <= 0;
            if (petProjectileNotSpawnedBO && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Nugget>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBP = player.ownedProjectileCounts[ModContent.ProjectileType<OmegaCultistTrident>()] <= 0;
            if (petProjectileNotSpawnedBP && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<OmegaCultistTrident>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBP2 = player.ownedProjectileCounts[ModContent.ProjectileType<OmegaCultistCandle>()] <= 0;
            if (petProjectileNotSpawnedBP2 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<OmegaCultistCandle>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBQ = player.ownedProjectileCounts[ModContent.ProjectileType<Dragonball>()] <= 0;
            if (petProjectileNotSpawnedBQ && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Dragonball>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBR = player.ownedProjectileCounts[ModContent.ProjectileType<AstPhage>()] <= 0;
            if (petProjectileNotSpawnedBR && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<AstPhage>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBS = player.ownedProjectileCounts[ModContent.ProjectileType<Pillager>()] <= 0;
            if (petProjectileNotSpawnedBS && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Pillager>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBT = player.ownedProjectileCounts[ModContent.ProjectileType<PolterChan>()] <= 0;
            if (petProjectileNotSpawnedBT && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<PolterChan>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBU = player.ownedProjectileCounts[ModContent.ProjectileType<Puppo>()] <= 0;
            if (petProjectileNotSpawnedBU && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Puppo>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBV = player.ownedProjectileCounts[ModContent.ProjectileType<RedPanda>()] <= 0;
            if (petProjectileNotSpawnedBV && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<RedPanda>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBX = player.ownedProjectileCounts[ModContent.ProjectileType<Sirember>()] <= 0;
            if (petProjectileNotSpawnedBX && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Sirember>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBY = player.ownedProjectileCounts[ModContent.ProjectileType<RepairBot>()] <= 0;
            if (petProjectileNotSpawnedBY && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<RepairBot>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBZ = player.ownedProjectileCounts[ModContent.ProjectileType<RoverSpindlePet>()] <= 0;
            if (petProjectileNotSpawnedBZ && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<RoverSpindlePet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCA = player.ownedProjectileCounts[ModContent.ProjectileType<RustyMimic>()] <= 0;
            if (petProjectileNotSpawnedCA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<RustyMimic>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCB = player.ownedProjectileCounts[ModContent.ProjectileType<Dstone>()] <= 0;
            if (petProjectileNotSpawnedCB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Dstone>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCC = player.ownedProjectileCounts[ModContent.ProjectileType<ScoriaDuke>()] <= 0;
            if (petProjectileNotSpawnedCC && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<ScoriaDuke>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCD = player.ownedProjectileCounts[ModContent.ProjectileType<AquaPet>()] <= 0;
            if (petProjectileNotSpawnedCD && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<AquaPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCE = player.ownedProjectileCounts[ModContent.ProjectileType<DesertPet>()] <= 0;
            if (petProjectileNotSpawnedCE && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<DesertPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCFA = player.ownedProjectileCounts[ModContent.ProjectileType<SSignus>()] <= 0;
            if (petProjectileNotSpawnedCFA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<SSignus>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedCFB = player.ownedProjectileCounts[ModContent.ProjectileType<SVoid>()] <= 0;
            if (petProjectileNotSpawnedCFB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<SVoid>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedCFC = player.ownedProjectileCounts[ModContent.ProjectileType<SWeeb>()] <= 0;
            if (petProjectileNotSpawnedCFC && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<SWeeb>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCGA = player.ownedProjectileCounts[ModContent.ProjectileType<Sepulchling>()] <= 0;
            if (petProjectileNotSpawnedCGA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Sepulchling>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            player.GetModPlayer<CalValEXPlayer>().BMonster = true;
            bool petProjectileNotSpawnedCGB = player.ownedProjectileCounts[ModContent.ProjectileType<BabyMonster>()] <= 0;
            if (petProjectileNotSpawnedCGB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<BabyMonster>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCH = player.ownedProjectileCounts[ModContent.ProjectileType<SepulcherHeadNeo>()] <= 0;
            if (petProjectileNotSpawnedCH && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<SepulcherHeadNeo>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCIA = player.ownedProjectileCounts[ModContent.ProjectileType<GrandPet>()] <= 0;
            if (petProjectileNotSpawnedCIA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<GrandPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedCIB = player.ownedProjectileCounts[ModContent.ProjectileType<BuffReaper>()] <= 0;
            if (petProjectileNotSpawnedCIB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<BuffReaper>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedCIC = player.ownedProjectileCounts[ModContent.ProjectileType<Smauler>()] <= 0;
            if (petProjectileNotSpawnedCIC && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Smauler>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCJ = player.ownedProjectileCounts[ModContent.ProjectileType<SkaterPet>()] <= 0;
            if (petProjectileNotSpawnedCJ && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<SkaterPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCK = player.ownedProjectileCounts[ModContent.ProjectileType<SlimeDemi>()] <= 0;
            if (petProjectileNotSpawnedCK && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<SlimeDemi>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCL = player.ownedProjectileCounts[ModContent.ProjectileType<StasisArmored>()] <= 0;
            if (petProjectileNotSpawnedCL && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<StasisArmored>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCM = player.ownedProjectileCounts[ModContent.ProjectileType<SWPet>()] <= 0;
            if (petProjectileNotSpawnedCM && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<SWPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedCN = player.ownedProjectileCounts[ModContent.ProjectileType<StasisNaked>()] <= 0;
            if (petProjectileNotSpawnedCN && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<StasisNaked>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCO = player.ownedProjectileCounts[ModContent.ProjectileType<TerminalRock>()] <= 0;
            if (petProjectileNotSpawnedCO && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<TerminalRock>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCP = player.ownedProjectileCounts[ModContent.ProjectileType<TUB>()] <= 0;
            if (petProjectileNotSpawnedCP && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<TUB>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCQ = player.ownedProjectileCounts[ModContent.ProjectileType<UngodlySerpent>()] <= 0;
            if (petProjectileNotSpawnedCQ && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<UngodlySerpent>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCRA = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumDrone>()] <= 0;
            if (petProjectileNotSpawnedCRA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<WulfrumDrone>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedCRB = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumRover>()] <= 0;
            if (petProjectileNotSpawnedCRB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<WulfrumRover>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedCRC = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumHover>()] <= 0;
            if (petProjectileNotSpawnedCRC && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<WulfrumHover>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedCRD = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumOrb>()] <= 0;
            if (petProjectileNotSpawnedCRD && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<WulfrumOrb>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCS = player.ownedProjectileCounts[ModContent.ProjectileType<EWyrm>()] <= 0;
            if (petProjectileNotSpawnedCS && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<EWyrm>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCT = player.ownedProjectileCounts[ModContent.ProjectileType<YharimSquid>()] <= 0;
            if (petProjectileNotSpawnedCT && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<YharimSquid>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCV = player.ownedProjectileCounts[ModContent.ProjectileType<DiggerPet>()] <= 0;
            if (petProjectileNotSpawnedCV && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<DiggerPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCW = player.ownedProjectileCounts[ModContent.ProjectileType<Enredpet>()] <= 0;
            if (petProjectileNotSpawnedCW && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Enredpet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCX = player.ownedProjectileCounts[ModContent.ProjectileType<Godrge>()] <= 0;
            if (petProjectileNotSpawnedCX && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Godrge>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCY = player.ownedProjectileCounts[ModContent.ProjectileType<ProGuard1>()] <= 0 &&
                                           player.ownedProjectileCounts[ModContent.ProjectileType<ProGuard2>()] <= 0 &&
                                           player.ownedProjectileCounts[ModContent.ProjectileType<ProGuard3>()] <= 0 &&
                                           player.ownedProjectileCounts[ModContent.ProjectileType<ProviPet>()] <= 0;
            if (petProjectileNotSpawnedCY && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<ProGuard1>(), 0, 0f, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<ProGuard2>(), 0, 0f, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<ProGuard3>(), 0, 0f, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<ProviPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedCZ = player.ownedProjectileCounts[ModContent.ProjectileType<WulfrumPylon>()] <= 0;
            if (petProjectileNotSpawnedCZ && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<WulfrumPylon>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedDA = player.ownedProjectileCounts[ModContent.ProjectileType<SeerS>()] <= 0;
            if (petProjectileNotSpawnedDA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<SeerS>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedDB = player.ownedProjectileCounts[ModContent.ProjectileType<SeerM>()] <= 0;
            if (petProjectileNotSpawnedDB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<SeerM>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedDC = player.ownedProjectileCounts[ModContent.ProjectileType<SeerL>()] <= 0;
            if (petProjectileNotSpawnedDC && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<SeerL>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedDD = player.ownedProjectileCounts[ModContent.ProjectileType<SolarBunny>()] <= 0;
            if (petProjectileNotSpawnedDD && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<SolarBunny>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedDE = player.ownedProjectileCounts[ModContent.ProjectileType<SpookShark>()] <= 0;
            if (petProjectileNotSpawnedDE && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<SpookShark>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedDF = player.ownedProjectileCounts[ModContent.ProjectileType<SpookSmall>()] <= 0;
            if (petProjectileNotSpawnedDF && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<SpookSmall>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedDG = player.ownedProjectileCounts[ModContent.ProjectileType<Bishop>()] <= 0;
            if (petProjectileNotSpawnedDG && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Bishop>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedDH = player.ownedProjectileCounts[ModContent.ProjectileType<EndoRune>()] <= 0;
            if (petProjectileNotSpawnedDH && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<EndoRune>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            if (CalValEXConfig.Instance.SupCombo){
                List<int> petscombo = new()
                {
                    ModContent.ProjectileType<HeatPet>(),
                    ModContent.ProjectileType<HeatBaby>(),
                    ModContent.ProjectileType<Skeetyeet>(),
                    ModContent.ProjectileType<DarksunSpirit_Fish>(),
                    ModContent.ProjectileType<DarksunSpiritSkull_1>(),
                    ModContent.ProjectileType<DarksunSpiritSkull_2>(),
                    ModContent.ProjectileType<MiniCryo>(),
                    ModContent.ProjectileType<PhantomSpirit>(),
                    ModContent.ProjectileType<Minimpious>()
                };

                bool petProjectileNotSpawnedcomboDI = true;
                for (int i = 0; i < petscombo.Count; i++){ 
                    if (player.ownedProjectileCounts[petscombo[i]] > 0){
                        petProjectileNotSpawnedcomboDI = false;
                    }
                }

                if (petProjectileNotSpawnedcomboDI && player.whoAmI == Main.myPlayer){
                    for (int i = 0; i < petscombo.Count; i++){
                        Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                            player.position.Y + (player.height / 2), 0f, 0f, petscombo[i], 0, 0f, player.whoAmI, 0f, 0f);
                    }
                }
            }
        }
    }
}