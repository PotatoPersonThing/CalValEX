using System;
using System.Collections.Generic;
using CalValEX;
using CalValEX.Items.Equips;
using CalValEX.Items.Hooks;
using CalValEX.Items.Pets;
using CalValEX.Items.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Mounts;

namespace CalValEX
{
    public class CalValEXGlobalitem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;

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
                        if (Utils.NextFloat(Main.rand) < 0.001f)
                            {   
                                player.QuickSpawnItem(ModContent.ItemType<AncientAuricTeslaHelm>());
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
                    }
                    if (arg == calamityMod.ItemType("AstrumDeusBag"))
                    {
                        if (Utils.NextFloat(Main.rand) < 0.3f)
                            {   
                                player.QuickSpawnItem(ModContent.ItemType<Binoculars>());
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
