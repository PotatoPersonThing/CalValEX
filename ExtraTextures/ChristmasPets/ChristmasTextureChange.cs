using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.LightPets;
using CalValEX.Projectiles.Pets.Wulfrum;
using CalValEX.Projectiles.Pets.Scuttlers;
using CalValEX.Projectiles.Pets.Elementals;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace CalValEX.ExtraTextures.ChristmasPets
{
    //I am aware that this is awful, but its the easiest way to do it.
    public static class ChristmasTextureChange
    {
        [JITWhenModsEnabled("CalamityMod")]
        public static void Load()
        {
            string path = "CalValEX/ExtraTextures/ChristmasPets/";
            if (CalValEX.month == 12)
            {
                TextureAssets.Projectile[ModContent.ProjectileType<AeroBaby>()] = ModContent.Request<Texture2D>(path + "AeroBaby");
                TextureAssets.Projectile[ModContent.ProjectileType<AeroSlimePet>()] = ModContent.Request<Texture2D>(path + "AeroSlimePet");
                TextureAssets.Projectile[ModContent.ProjectileType<AmberPet>()] = ModContent.Request<Texture2D>(path + "AmberPet");
                TextureAssets.Projectile[ModContent.ProjectileType<AmethystPet>()] = ModContent.Request<Texture2D>(path + "AmethystPet");
                TextureAssets.Projectile[ModContent.ProjectileType<DarksunSpiritSkull_2>()] = ModContent.Request<Texture2D>(path + "DarksunSpiritSkull_2");
                TextureAssets.Projectile[ModContent.ProjectileType<DarksunSpiritSkull_1>()] = ModContent.Request<Texture2D>(path + "DarksunSpiritSkull_1");
                TextureAssets.Projectile[ModContent.ProjectileType<DarksunSpirit_Fish>()] = ModContent.Request<Texture2D>(path + "DarksunSpirit_Fish");
                TextureAssets.Projectile[ModContent.ProjectileType<Godrge>()] = ModContent.Request<Texture2D>(path + "Godrge");
                TextureAssets.Projectile[ModContent.ProjectileType<HeatPet>()] = ModContent.Request<Texture2D>(path + "HeatPet");
                TextureAssets.Projectile[ModContent.ProjectileType<HeatBaby>()] = ModContent.Request<Texture2D>(path + "HeatBaby");
                TextureAssets.Projectile[ModContent.ProjectileType<Androomba>()] = ModContent.Request<Texture2D>(path + "Androomba");
                TextureAssets.Projectile[ModContent.ProjectileType<Angrypup>()] = ModContent.Request<Texture2D>(path + "Angrypup");
                TextureAssets.Projectile[ModContent.ProjectileType<Minimpious>()] = ModContent.Request<Texture2D>(path + "Minimpious");
                TextureAssets.Projectile[ModContent.ProjectileType<BabyCnidrion>()] = ModContent.Request<Texture2D>(path + "BabyCnidrion");
                TextureAssets.Projectile[ModContent.ProjectileType<PhantomSpirit>()] = ModContent.Request<Texture2D>(path + "PhantomSpirit");
                TextureAssets.Projectile[ModContent.ProjectileType<ProGuard1>()] = ModContent.Request<Texture2D>(path + "ProGuard1");
                TextureAssets.Projectile[ModContent.ProjectileType<ProGuard2>()] = ModContent.Request<Texture2D>(path + "ProGuard1");
                TextureAssets.Projectile[ModContent.ProjectileType<ProGuard3>()] = ModContent.Request<Texture2D>(path + "ProGuard1");
                TextureAssets.Projectile[ModContent.ProjectileType<BabySquid>()] = ModContent.Request<Texture2D>(path + "BabySquid");
                TextureAssets.Projectile[ModContent.ProjectileType<BugDoge>()] = ModContent.Request<Texture2D>(path + "BugDoge");
                TextureAssets.Projectile[ModContent.ProjectileType<CalamityBABY>()] = ModContent.Request<Texture2D>(path + "CalamityBABY");
                TextureAssets.Projectile[ModContent.ProjectileType<ProviPet>()] = ModContent.Request<Texture2D>(path + "ProviPet");
                TextureAssets.Projectile[ModContent.ProjectileType<SeerS>()] = ModContent.Request<Texture2D>(path + "SeerS");
                TextureAssets.Projectile[ModContent.ProjectileType<SeerM>()] = ModContent.Request<Texture2D>(path + "SeerM");
                TextureAssets.Projectile[ModContent.ProjectileType<SeerL>()] = ModContent.Request<Texture2D>(path + "SeerL");
                TextureAssets.Projectile[ModContent.ProjectileType<SolarBunny>()] = ModContent.Request<Texture2D>(path + "SolarBunny");
                TextureAssets.Projectile[ModContent.ProjectileType<Skeetyeet>()] = ModContent.Request<Texture2D>(path + "Skeetyeet");
                TextureAssets.Projectile[ModContent.ProjectileType<VoidOrb>()] = ModContent.Request<Texture2D>(path + "VoidOrb");
                TextureAssets.Projectile[ModContent.ProjectileType<SVoid>()] = ModContent.Request<Texture2D>(path + "VoidOrb");
                TextureAssets.Projectile[ModContent.ProjectileType<CrystalPet>()] = ModContent.Request<Texture2D>(path + "CrystalPet");
                TextureAssets.Projectile[ModContent.ProjectileType<UngodlySerpent>()] = ModContent.Request<Texture2D>(path + "UngodlySerpent");
                TextureAssets.Projectile[ModContent.ProjectileType<TUB>()] = ModContent.Request<Texture2D>(path + "TUB");
                TextureAssets.Projectile[ModContent.ProjectileType<DiamondPet>()] = ModContent.Request<Texture2D>(path + "DiamondPet");
                TextureAssets.Projectile[ModContent.ProjectileType<TopazPet>()] = ModContent.Request<Texture2D>(path + "TopazPet");
                TextureAssets.Projectile[ModContent.ProjectileType<Dragonball>()] = ModContent.Request<Texture2D>(path + "Dragonball");
                TextureAssets.Projectile[ModContent.ProjectileType<TerminalRock>()] = ModContent.Request<Texture2D>(path + "TerminalRock");
                TextureAssets.Projectile[ModContent.ProjectileType<SWeeb>()] = ModContent.Request<Texture2D>(path + "SWeeb");
                TextureAssets.Projectile[ModContent.ProjectileType<StasisArmored>()] = ModContent.Request<Texture2D>(path + "SWeeb");
                TextureAssets.Projectile[ModContent.ProjectileType<StasisNaked>()] = ModContent.Request<Texture2D>(path + "StasisNaked");
                TextureAssets.Projectile[ModContent.ProjectileType<StarJelly>()] = ModContent.Request<Texture2D>(path + "StarJelly");
                TextureAssets.Projectile[ModContent.ProjectileType<SSignus>()] = ModContent.Request<Texture2D>(path + "SSignus");
                TextureAssets.Projectile[ModContent.ProjectileType<SignusMini>()] = ModContent.Request<Texture2D>(path + "SSignus");
                TextureAssets.Projectile[ModContent.ProjectileType<SmolCrab>()] = ModContent.Request<Texture2D>(path + "SmolCrab");
                TextureAssets.Projectile[ModContent.ProjectileType<SlimeDemi>()] = ModContent.Request<Texture2D>(path + "SlimeDemi");
                //TextureAssets.Projectile[ModContent.ProjectileType<Enredpet>()] = ModContent.Request<Texture2D>(path + "CosmicAssistantRing"); im sorry enreden
                TextureAssets.Projectile[ModContent.ProjectileType<EmeraldPet>()] = ModContent.Request<Texture2D>(path + "EmeraldPet");
                TextureAssets.Projectile[ModContent.ProjectileType<Euros>()] = ModContent.Request<Texture2D>(path + "Euros");
                TextureAssets.Projectile[ModContent.ProjectileType<Fistuloid>()] = ModContent.Request<Texture2D>(path + "Fistuloid");
                TextureAssets.Projectile[ModContent.ProjectileType<SkaterPet>()] = ModContent.Request<Texture2D>(path + "SkaterPet");
                TextureAssets.Projectile[ModContent.ProjectileType<FollyPet>()] = ModContent.Request<Texture2D>(path + "FollyPet");
                TextureAssets.Projectile[ModContent.ProjectileType<Sirember>()] = ModContent.Request<Texture2D>(path + "Sirember");
                TextureAssets.Projectile[ModContent.ProjectileType<ScoriaDuke>()] = ModContent.Request<Texture2D>(path + "ScoriaDuke");
                TextureAssets.Projectile[ModContent.ProjectileType<SapphirePet>()] = ModContent.Request<Texture2D>(path + "SapphirePet");
                TextureAssets.Projectile[ModContent.ProjectileType<George>()] = ModContent.Request<Texture2D>(path + "George");
                TextureAssets.Projectile[ModContent.ProjectileType<Sandmini>()] = ModContent.Request<Texture2D>(path + "sandmini");
                TextureAssets.Projectile[ModContent.ProjectileType<GrandPet>()] = ModContent.Request<Texture2D>(path + "GrandPet");
                TextureAssets.Projectile[ModContent.ProjectileType<Headoge>()] = ModContent.Request<Texture2D>(path + "Headoge");
                TextureAssets.Projectile[ModContent.ProjectileType<RustyMimic>()] = ModContent.Request<Texture2D>(path + "RustyMimic");
                TextureAssets.Projectile[ModContent.ProjectileType<RubyPet>()] = ModContent.Request<Texture2D>(path + "RubyPet");
                TextureAssets.Projectile[ModContent.ProjectileType<RepairBot>()] = ModContent.Request<Texture2D>(path + "RepairBot");
                TextureAssets.Projectile[ModContent.ProjectileType<RedPanda>()] = ModContent.Request<Texture2D>(path + "RedPanda");
                TextureAssets.Projectile[ModContent.ProjectileType<Hiveling>()] = ModContent.Request<Texture2D>(path + "Hiveling");
                TextureAssets.Projectile[ModContent.ProjectileType<RaresandMini>()] = ModContent.Request<Texture2D>(path + "raresandmini");
                TextureAssets.Projectile[ModContent.ProjectileType<Hoodieidolist>()] = ModContent.Request<Texture2D>(path + "Hoodieidolist");
                TextureAssets.Projectile[ModContent.ProjectileType<RareBrimling>()] = ModContent.Request<Texture2D>(path + "rarebrimling");
                TextureAssets.Projectile[ModContent.ProjectileType<PolterChan>()] = ModContent.Request<Texture2D>(path + "PolterChan");
                TextureAssets.Projectile[ModContent.ProjectileType<Junko>()] = ModContent.Request<Texture2D>(path + "Junko");
                TextureAssets.Projectile[ModContent.ProjectileType<Pillager>()] = ModContent.Request<Texture2D>(path + "Pillager");
                TextureAssets.Projectile[ModContent.ProjectileType<PhantomPet>()] = ModContent.Request<Texture2D>(path + "PhantomPet");
                TextureAssets.Projectile[ModContent.ProjectileType<PBGmini>()] = ModContent.Request<Texture2D>(path + "PBGmini");
                TextureAssets.Projectile[ModContent.ProjectileType<Nugget>()] = ModContent.Request<Texture2D>(path + "Nugget");
                TextureAssets.Projectile[ModContent.ProjectileType<MiniBumble>()] = ModContent.Request<Texture2D>(path + "MiniBumble");
                TextureAssets.Projectile[ModContent.ProjectileType<MiniCryo>()] = ModContent.Request<Texture2D>(path + "MiniCryo");
                TextureAssets.Projectile[ModContent.ProjectileType<MiniDoge>()] = ModContent.Request<Texture2D>(path + "MiniDoge");
                TextureAssets.Projectile[ModContent.ProjectileType<NuclearfuryshronPet>()] = ModContent.Request<Texture2D>(path + "NuclearfuryshronPet");
                TextureAssets.Projectile[ModContent.ProjectileType<MechaGeorge>()] = ModContent.Request<Texture2D>(path + "MechaGeorge");
                TextureAssets.Projectile[ModContent.ProjectileType<WulfrumDrone>()] = ModContent.Request<Texture2D>(path + "WulfrumDrone");
                TextureAssets.Projectile[ModContent.ProjectileType<WulfrumHover>()] = ModContent.Request<Texture2D>(path + "WulfrumHover");
                TextureAssets.Projectile[ModContent.ProjectileType<WulfrumRover>()] = ModContent.Request<Texture2D>(path + "WulfrumRover");
                TextureAssets.Projectile[ModContent.ProjectileType<Cryokid>()] = ModContent.Request<Texture2D>(path + "cryokid");
                TextureAssets.Projectile[ModContent.ProjectileType<Avalon>()] = ModContent.Request<Texture2D>(path + "Avalon");
                TextureAssets.Projectile[ModContent.ProjectileType<BabyMonster>()] = ModContent.Request<Texture2D>(path + "BabyMonster");
                TextureAssets.Projectile[ModContent.ProjectileType<Blockaroz>()] = ModContent.Request<Texture2D>(path + "Blockaroz");
                TextureAssets.Projectile[ModContent.ProjectileType<Buppy>()] = ModContent.Request<Texture2D>(path + "Buppy");
                TextureAssets.Projectile[ModContent.ProjectileType<CoolBlueSignut>()] = ModContent.Request<Texture2D>(path + "CoolBlueSignut");
                TextureAssets.Projectile[ModContent.ProjectileType<CoolBlueSlime>()] = ModContent.Request<Texture2D>(path + "CoolBlueSlime");
                TextureAssets.Projectile[ModContent.ProjectileType<RoverSpindlePet>()] = ModContent.Request<Texture2D>(path + "RoverSpindlePet");
                TextureAssets.Projectile[ModContent.ProjectileType<Smauler>()] = ModContent.Request<Texture2D>(path + "Smauler");
                if (CalValEX.CalamityActive)
                {
                    TextureAssets.Npc[CalValEX.CalamityNPC("BabyFlakCrab")] = ModContent.Request<Texture2D>(path + "ChrismasFlak");
                }
                TextureAssets.Projectile[ModContent.ProjectileType<FathomEelHead>()] = ModContent.Request<Texture2D>(path + "FathomEelHead");
            }
        }

        public static void Unload()
        {
            if (CalValEX.month == 12)
            {
            }
        }
    }
}