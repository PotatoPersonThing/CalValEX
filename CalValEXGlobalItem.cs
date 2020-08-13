using CalValEX.Items.Equips;
using CalValEX.Items.Hooks;
using CalValEX.Items.Mounts;
using CalValEX.Items.Pets;
using CalValEX.Items.Tiles;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX
{
    public class CalValEXGlobalitem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;

        public override void RightClick(Item item, Player player)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (item.type == calamityMod.ItemType("StarterBag"))
            {
                if (player.whoAmI == Main.myPlayer)
                {
                    player.QuickSpawnItem(ModContent.ItemType<C>());
                    switch (player.name)
                    {
                        case "Jared":
                            player.QuickSpawnItem(ModContent.ItemType<EWail>());
                            player.QuickSpawnItem(ModContent.ItemType<SoulShard>());
                            break;
                        case "RamG":
                        case "Ramgear":
                            player.QuickSpawnItem(ModContent.ItemType<ToyScythe>());
                            break;
                        case "Bumbledoge":
                        case "BumbleDoge":
                        case "Bojangles":
                        case "Bojeangles":
                            player.QuickSpawnItem(ModContent.ItemType<AeroPebble>());
                            player.QuickSpawnItem(ModContent.ItemType<FluffyFur>());
                            break;
                        case "Krysmun":
                            player.QuickSpawnItem(ModContent.ItemType<FluffyFeather>());
                            break;
                        case "William":
                            player.QuickSpawnItem(ModContent.ItemType<EurosBandage>());
                            break;
                        case "Kiwabug":
                            player.QuickSpawnItem(ModContent.ItemType<UglyTentacle>());
                            break;
                        case "Nukebirb":
                        case "Unyuho":
                            player.QuickSpawnItem(ModContent.ItemType<PristineExcalibur>());
                            break;
                        case "YuH":
                            player.QuickSpawnItem(ModContent.ItemType<Eidolistthingy>());
                            break;
                        case "Hypera":
                            player.QuickSpawnItem(ModContent.ItemType<SolarBun>());
                            break;
                        case "Drakudragonx":
                            player.QuickSpawnItem(ModContent.ItemType<BambooStick>());
                            break;
                        case "Lucca":
                            player.QuickSpawnItem(ModContent.ItemType<JunkoHat>());
                            break;
                        case "Lil Junko":
                            player.QuickSpawnItem(ModContent.ItemType<JunkoHat>());
                            break;
                        case "Cooper":
                            player.QuickSpawnItem(ModContent.ItemType<coopershortsword>());
                            break;
                        case "Enreden":
                            player.QuickSpawnItem(ModContent.ItemType<Enredenitem>());
                            break;
                        case "Emerald":
                        case "EmeraldXLapis":
                            player.QuickSpawnItem(ModContent.ItemType<FogG>());
                            break;
                        case "Yharex87":
                            player.QuickSpawnItem(ModContent.ItemType<JellyBottle>());
                            break;
                        case "Scarfy":
                            player.QuickSpawnItem(ModContent.ItemType<FluffyFeather>());
                            break;
                        case "Willow":
                        case "willowmaine":
                        case "bean long":
                            player.QuickSpawnItem(ModContent.ItemType<PerennialFlower>());
                            player.QuickSpawnItem(ModContent.ItemType<VVanities>());
                            break;
                    }
                }
            }
        }

        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");

            if (context == "bossBag")
            {
                if (calamityMod != null)
                {
                    //Here is a list of all Calamity Bags:
                    //Aquatic Scourge = AquaticScourgeBag
                    //Astrum Aureus = AstrageldonBag
                    //Astrum Deus = AstrumDeusBag
                    //Brimstone Elemental = BrimstoneWaifuBag
                    //Dragonfolly = BumblebirbBag
                    //Calamitas = CalamitasBag
                    //Crabulon = CrabulonBag
                    //Cryogen = CryogenBag
                    //Desert Scourge = DesertScourgeBag
                    //Devourer of Gods = DevourerofGodsBag
                    //Hive Mind = HiveMindBag
                    //Leviathan and Siren = LeviathanBag
                    //Old Duke = OldDukeBag
                    //Perforators = PerforatorBag
                    //Plaguebringer Goliath = PlaguebringerGoliathBag
                    //Polterghast = PolterghastBag
                    //Providence = ProvidenceBag
                    //Ravager = RavagerBag
                    //Slime God = SlimeGodBag
                    //Starter Bag = StarterBag
                    //Yharon = YharonBag

                    if (arg == calamityMod.ItemType("StarterBag"))
                    {
                        player.QuickSpawnItem(ModContent.ItemType<C>());
                    }
                    if (arg == calamityMod.ItemType("DesertScourgeBag"))
                    {
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<DesertMedallion>());
                        }
                        if (Utils.NextFloat(Main.rand) < 0.2f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<DriedMandible>());
                        }
                    }
                    if (arg == calamityMod.ItemType("CrabulonBag"))
                    {
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<ClawShroom>());
                        }
                    }
                    if (arg == calamityMod.ItemType("HiveMindBag"))
                    {
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<MissingFang>());
                        }
                    }
                    if (arg == calamityMod.ItemType("PerforatorBag"))
                    {
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<DigestedWormFood>());
                        }
                    }
                    if (arg == calamityMod.ItemType("SlimeGodBag"))
                    {
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<ImpureStick>());
                        }
                    }
                    if (arg == calamityMod.ItemType("CryogenBag"))
                    {
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<CryoStick>());
                        }
                    }
                    if (arg == calamityMod.ItemType("AquaticScourgeBag"))
                    {
                        if (Utils.NextFloat(Main.rand) < 0.2f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<AquaticHide>());
                        }
                    }
                    if (arg == calamityMod.ItemType("BrimstoneWaifuBag"))
                    {
                        if (Utils.NextFloat(Main.rand) < 0.2f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<BrimmyBody>());
                        }
                        if (Utils.NextFloat(Main.rand) < 0.2f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<BrimmySpirit>());
                        }
                        if (Utils.NextFloat(Main.rand) < 0.2f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<brimtulip>());
                        }
                    }
                    if (arg == calamityMod.ItemType("CalamitasBag"))
                    {
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<Calacirclet>());
                        }
                        if (Utils.NextFloat(Main.rand) < 0.001f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<AncientAuricTeslaHelm>());
                        }
                    }
                    if (arg == calamityMod.ItemType("LeviathanBag"))
                    {
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<LeviWings>());
                        }
                    }
                    if (arg == calamityMod.ItemType("AstrageldonBag"))
                    {
                        if (Utils.NextFloat(Main.rand) < 0.2f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<AstDie>());
                        }
                        if (Utils.NextFloat(Main.rand) < 0.2f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<AureusShield>());
                        }
                        if (Utils.NextFloat(Main.rand) < 0.001f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<AncientAuricTeslaHelm>());
                        }
                    }
                    if (arg == calamityMod.ItemType("PlaguebringerGoliathBag"))
                    {
                        if (Utils.NextFloat(Main.rand) < 0.004f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<AncientAuricTeslaHelm>());
                        }
                        if (Utils.NextFloat(Main.rand) < 0.2f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<InfectedController>());
                        }
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<PlaguePack>());
                        }
                    }
                    if (arg == calamityMod.ItemType("RavagerBag"))
                    {
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<AncientChoker>());
                        }
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<RavaHook>());
                        }
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<SkullBalloon>());
                        }
                    }
                    if (arg == calamityMod.ItemType("AstrumDeusBag"))
                    {
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<AstralStar>());
                        }
                        if (Utils.NextFloat(Main.rand) < 0.2f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<AstBandana>());
                        }
                    }
                    if (arg == calamityMod.ItemType("BumblebirbBag"))
                    {
                        int choice = Main.rand.Next(4);
                        if (choice == 0)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<FollyWings>());
                        }
                        else if (choice == 1)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<OrbSummon>());
                        }
                        else if (choice == 2)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<Birbhat>());
                        }
                        else
                        {
                            player.QuickSpawnItem(ModContent.ItemType<FollyWing>());
                        }
                        if (Utils.NextFloat(Main.rand) < 0.005f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<AncientAuricTeslaHelm>());
                        }
                    }

                    if (arg == calamityMod.ItemType("ProvidenceBag"))
                    {
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<ProShard>());
                        }
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<ProviCrystal>());
                        }
                    }
                    if (arg == calamityMod.ItemType("PolterghastBag"))
                    {
                        if (Utils.NextFloat(Main.rand) < 0.1f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<Polterhook>());
                        }
                    }
                    if (arg == calamityMod.ItemType("OldDukeBag"))
                    {
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<OldWings>());
                        }
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<CorrodedCleaver>());
                        }
                    }
                    if (arg == calamityMod.ItemType("DevourerofGodsBag"))
                    {
                        if (Utils.NextFloat(Main.rand) < 0.01f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<CosBandana>());
                        }
                        if (Utils.NextFloat(Main.rand) < 0.01f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<AncientAuricTeslaHelm>());
                        }
                    }
                    if (arg == calamityMod.ItemType("YharonBag"))
                    {
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<JunglePhoenixWings>());
                        }
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<NuggetBiscuit>());
                        }
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<YharonShackle>());
                        }
                        if (Utils.NextFloat(Main.rand) < 0.05f)
                        {
                            player.QuickSpawnItem(ModContent.ItemType<AncientAuricTeslaHelm>());
                        }
                    }
                }
            }
        }
    }
}
