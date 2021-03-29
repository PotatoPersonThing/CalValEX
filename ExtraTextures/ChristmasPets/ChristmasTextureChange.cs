using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.LightPets;
using CalValEX.Projectiles.Pets.Wulfrum;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.ExtraTextures.ChristmasPets
{
    //I am aware that this is awful, but its the easiest way to do it.
    public static class ChristmasTextureChange
    {
        public static void Load()
        {
            string path = "CalValEX/ExtraTextures/ChristmasPets/";
            if (CalValEX.month == 12)
            {
                Main.projectileTexture[ModContent.ProjectileType<AeroBaby>()] = ModContent.GetTexture(path + "AeroBaby");
                Main.projectileTexture[ModContent.ProjectileType<AeroSlimePet>()] = ModContent.GetTexture(path + "AeroSlimePet");
                Main.projectileTexture[ModContent.ProjectileType<AmberPet>()] = ModContent.GetTexture(path + "AmberPet");
                Main.projectileTexture[ModContent.ProjectileType<AmethystPet>()] = ModContent.GetTexture(path + "AmethystPet");
                Main.projectileTexture[ModContent.ProjectileType<DarksunSpiritSkull_2>()] = ModContent.GetTexture(path + "DarksunSpiritSkull_2");
                Main.projectileTexture[ModContent.ProjectileType<DarksunSpiritSkull_1>()] = ModContent.GetTexture(path + "DarksunSpiritSkull_1");
                Main.projectileTexture[ModContent.ProjectileType<DarksunSpirit_Fish>()] = ModContent.GetTexture(path + "DarksunSpirit_Fish");
                Main.projectileTexture[ModContent.ProjectileType<Godrge>()] = ModContent.GetTexture(path + "Godrge");
                Main.projectileTexture[ModContent.ProjectileType<HeatPet>()] = ModContent.GetTexture(path + "HeatPet");
                Main.projectileTexture[ModContent.ProjectileType<HeatBaby>()] = ModContent.GetTexture(path + "HeatBaby");
                Main.projectileTexture[ModContent.ProjectileType<Androomba>()] = ModContent.GetTexture(path + "Androomba");
                Main.projectileTexture[ModContent.ProjectileType<Angrypup>()] = ModContent.GetTexture(path + "Angrypup");
                Main.projectileTexture[ModContent.ProjectileType<Minimpious>()] = ModContent.GetTexture(path + "Minimpious");
                Main.projectileTexture[ModContent.ProjectileType<BabyCnidrion>()] = ModContent.GetTexture(path + "BabyCnidrion");
                Main.projectileTexture[ModContent.ProjectileType<PhantomSpirit>()] = ModContent.GetTexture(path + "PhantomSpirit");
                Main.projectileTexture[ModContent.ProjectileType<ProGuard1>()] = ModContent.GetTexture(path + "ProGuard1");
                Main.projectileTexture[ModContent.ProjectileType<ProGuard2>()] = ModContent.GetTexture(path + "ProGuard1");
                Main.projectileTexture[ModContent.ProjectileType<ProGuard3>()] = ModContent.GetTexture(path + "ProGuard1");
                Main.projectileTexture[ModContent.ProjectileType<BabySquid>()] = ModContent.GetTexture(path + "BabySquid");
                Main.projectileTexture[ModContent.ProjectileType<BugDoge>()] = ModContent.GetTexture(path + "BugDoge");
                Main.projectileTexture[ModContent.ProjectileType<CalamityBABY>()] = ModContent.GetTexture(path + "CalamityBABY");
                Main.projectileTexture[ModContent.ProjectileType<ProviPet>()] = ModContent.GetTexture(path + "ProviPet");
                Main.projectileTexture[ModContent.ProjectileType<SeerS>()] = ModContent.GetTexture(path + "SeerS");
                Main.projectileTexture[ModContent.ProjectileType<SeerM>()] = ModContent.GetTexture(path + "SeerM");
                Main.projectileTexture[ModContent.ProjectileType<SeerL>()] = ModContent.GetTexture(path + "SeerL");
                Main.projectileTexture[ModContent.ProjectileType<SolarBunny>()] = ModContent.GetTexture(path + "SolarBunny");
                Main.projectileTexture[ModContent.ProjectileType<Skeetyeet>()] = ModContent.GetTexture(path + "Skeetyeet");
                Main.projectileTexture[ModContent.ProjectileType<VoidOrb>()] = ModContent.GetTexture(path + "VoidOrb");
                Main.projectileTexture[ModContent.ProjectileType<SVoid>()] = ModContent.GetTexture(path + "VoidOrb");
                Main.projectileTexture[ModContent.ProjectileType<CrystalPet>()] = ModContent.GetTexture(path + "CrystalPet");
                Main.projectileTexture[ModContent.ProjectileType<UngodlySerpent>()] = ModContent.GetTexture(path + "UngodlySerpent");
                Main.projectileTexture[ModContent.ProjectileType<TUB>()] = ModContent.GetTexture(path + "TUB");
                Main.projectileTexture[ModContent.ProjectileType<DiamondPet>()] = ModContent.GetTexture(path + "DiamondPet");
                Main.projectileTexture[ModContent.ProjectileType<TopazPet>()] = ModContent.GetTexture(path + "TopazPet");
                Main.projectileTexture[ModContent.ProjectileType<Dragonball>()] = ModContent.GetTexture(path + "Dragonball");
                Main.projectileTexture[ModContent.ProjectileType<TerminalRock>()] = ModContent.GetTexture(path + "TerminalRock");
                Main.projectileTexture[ModContent.ProjectileType<SWeeb>()] = ModContent.GetTexture(path + "SWeeb");
                Main.projectileTexture[ModContent.ProjectileType<StasisArmored>()] = ModContent.GetTexture(path + "SWeeb");
                Main.projectileTexture[ModContent.ProjectileType<StasisNaked>()] = ModContent.GetTexture(path + "StasisNaked");
                Main.projectileTexture[ModContent.ProjectileType<StarJelly>()] = ModContent.GetTexture(path + "StarJelly");
                Main.projectileTexture[ModContent.ProjectileType<SSignus>()] = ModContent.GetTexture(path + "SSignus");
                Main.projectileTexture[ModContent.ProjectileType<SignusMini>()] = ModContent.GetTexture(path + "SSignus");
                Main.projectileTexture[ModContent.ProjectileType<SmolCrab>()] = ModContent.GetTexture(path + "SmolCrab");
                Main.projectileTexture[ModContent.ProjectileType<SlimeDemi>()] = ModContent.GetTexture(path + "SlimeDemi");
                //Main.projectileTexture[ModContent.ProjectileType<Enredpet>()] = ModContent.GetTexture(path + "CosmicAssistantRing"); im sorry enreden
                Main.projectileTexture[ModContent.ProjectileType<EmeraldPet>()] = ModContent.GetTexture(path + "EmeraldPet");
                Main.projectileTexture[ModContent.ProjectileType<Euros>()] = ModContent.GetTexture(path + "Euros");
                Main.projectileTexture[ModContent.ProjectileType<Fistuloid>()] = ModContent.GetTexture(path + "Fistuloid");
                Main.projectileTexture[ModContent.ProjectileType<SkaterPet>()] = ModContent.GetTexture(path + "SkaterPet");
                Main.projectileTexture[ModContent.ProjectileType<FollyPet>()] = ModContent.GetTexture(path + "FollyPet");
                Main.projectileTexture[ModContent.ProjectileType<Sirember>()] = ModContent.GetTexture(path + "Sirember");
                Main.projectileTexture[ModContent.ProjectileType<ScoriaDuke>()] = ModContent.GetTexture(path + "ScoriaDuke");
                Main.projectileTexture[ModContent.ProjectileType<SapphirePet>()] = ModContent.GetTexture(path + "SapphirePet");
                Main.projectileTexture[ModContent.ProjectileType<George>()] = ModContent.GetTexture(path + "George");
                Main.projectileTexture[ModContent.ProjectileType<sandmini>()] = ModContent.GetTexture(path + "sandmini");
                Main.projectileTexture[ModContent.ProjectileType<GrandPet>()] = ModContent.GetTexture(path + "GrandPet");
                Main.projectileTexture[ModContent.ProjectileType<Headoge>()] = ModContent.GetTexture(path + "Headoge");
                Main.projectileTexture[ModContent.ProjectileType<RustyMimic>()] = ModContent.GetTexture(path + "RustyMimic");
                Main.projectileTexture[ModContent.ProjectileType<RubyPet>()] = ModContent.GetTexture(path + "RubyPet");
                Main.projectileTexture[ModContent.ProjectileType<RepairBot>()] = ModContent.GetTexture(path + "RepairBot");
                Main.projectileTexture[ModContent.ProjectileType<RedPanda>()] = ModContent.GetTexture(path + "RedPanda");
                Main.projectileTexture[ModContent.ProjectileType<Hiveling>()] = ModContent.GetTexture(path + "Hiveling");
                Main.projectileTexture[ModContent.ProjectileType<raresandmini>()] = ModContent.GetTexture(path + "raresandmini");
                Main.projectileTexture[ModContent.ProjectileType<Hoodieidolist>()] = ModContent.GetTexture(path + "Hoodieidolist");
                Main.projectileTexture[ModContent.ProjectileType<rarebrimling>()] = ModContent.GetTexture(path + "rarebrimling");
                Main.projectileTexture[ModContent.ProjectileType<PolterChan>()] = ModContent.GetTexture(path + "PolterChan");
                Main.projectileTexture[ModContent.ProjectileType<Junko>()] = ModContent.GetTexture(path + "Junko");
                Main.projectileTexture[ModContent.ProjectileType<Pillager>()] = ModContent.GetTexture(path + "Pillager");
                Main.projectileTexture[ModContent.ProjectileType<PhantomPet>()] = ModContent.GetTexture(path + "PhantomPet");
                Main.projectileTexture[ModContent.ProjectileType<PBGmini>()] = ModContent.GetTexture(path + "PBGmini");
                Main.projectileTexture[ModContent.ProjectileType<Nugget>()] = ModContent.GetTexture(path + "Nugget");
                Main.projectileTexture[ModContent.ProjectileType<MiniBumble>()] = ModContent.GetTexture(path + "MiniBumble");
                Main.projectileTexture[ModContent.ProjectileType<MiniCryo>()] = ModContent.GetTexture(path + "MiniCryo");
                Main.projectileTexture[ModContent.ProjectileType<MiniDoge>()] = ModContent.GetTexture(path + "MiniDoge");
                Main.projectileTexture[ModContent.ProjectileType<NuclearfuryshronPet>()] = ModContent.GetTexture(path + "NuclearfuryshronPet");
                Main.projectileTexture[ModContent.ProjectileType<MechaGeorge>()] = ModContent.GetTexture(path + "MechaGeorge");
                Main.projectileTexture[ModContent.ProjectileType<WulfrumDrone>()] = ModContent.GetTexture(path + "WulfrumDrone");
                Main.projectileTexture[ModContent.ProjectileType<WulfrumHover>()] = ModContent.GetTexture(path + "WulfrumHover");
                Main.projectileTexture[ModContent.ProjectileType<WulfrumRover>()] = ModContent.GetTexture(path + "WulfrumRover");
                Main.projectileTexture[ModContent.ProjectileType<cryokid>()] = ModContent.GetTexture(path + "cryokid");
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