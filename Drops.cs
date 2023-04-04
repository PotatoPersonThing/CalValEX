using CalValEX.Items;
using CalValEX.Items.Critters;
using CalValEX.Items.Equips.Backs;
using CalValEX.Items.Equips.Balloons;
using CalValEX.Items.Equips.Capes;
using CalValEX.Items.Equips.Hats;
using CalValEX.Items.Equips.Legs;
using CalValEX.Items.Equips.Scarves;
using CalValEX.Items.Equips.Shields;
using CalValEX.Items.Equips.Shirts;
using CalValEX.Items.Equips.Transformations;
using CalValEX.Items.Equips.Wings;
using CalValEX.Items.Hooks;
using CalValEX.Items.LightPets;
using CalValEX.Items.Mounts;
using CalValEX.Items.Mounts.InfiniteFlight;
using CalValEX.Items.Mounts.Ground;
using CalValEX.Items.Mounts.LimitedFlight;
using CalValEX.Items.Mounts.Morshu;
using CalValEX.Items.Pets;
using CalValEX.Items.Pets.Scuttlers;
using CalValEX.Items.Pets.Elementals;
using CalValEX.Items.Pets.ExoMechs;
using CalValEX.Items.Tiles;
using CalValEX.Items.Tiles.Balloons;
using CalValEX.Items.Tiles.Blocks;
using CalValEX.Items.Tiles.Plushies;
using CalValEX.NPCs.Critters;
using CalValEX.Items.Tiles.Paintings;
using CalValEX.Items.Tiles.Plants;
using CalValEX.NPCs.Oracle;
using System;
using Terraria.GameContent.ItemDropRules;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CalValEX.AprilFools;
using Terraria.DataStructures;
using Terraria.Localization;

namespace CalValEX
{
    public class CalValEXGlobalNPC : GlobalNPC
    {
        public readonly float bossHookChance = 0.1f; //10%
        public readonly float bossPetChance = 0.2f; //20%
        public readonly float minibossChance = 0.1f; //10%
        public readonly float normalEnemyChance = 0.05f; //5%
        public readonly float rareEnemyChance = 0.1f; //10%
        public readonly float RIVChance = 0.075f; //7.5%
        public readonly float vanityMaxChance = 0.15f; //15%

        public readonly float vanityMinChance = 0.05f; //5%
        public readonly float vanityNormalChance = 0.1f; //10%

        public bool bdogeMount;
        public bool geldonSummon;
        public bool junkoReference;
        public bool wolfram;


        public static int meldodon = -1;
        public static int jharim = -1;

        public override bool InstancePerEntity => true;

        [JITWhenModsEnabled("CalamityMod")]
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            Mod alchLite;
            ModLoader.TryGetMod("AlchemistNPCLite", out alchLite);
            Mod alchFull;
            ModLoader.TryGetMod("AlchemistNPC", out alchFull);
            if (alchLite != null)
            {
                if (type == alchLite.Find<ModNPC>("Musician").Type)
                {
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstralMusicBox>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 10);
                        ++nextSlot;
                    }
                }
            }
            if (alchFull != null)
            {
                if (type == alchFull.Find<ModNPC>("Musician").Type)
                {
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstralMusicBox>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 10);
                        ++nextSlot;
                    }
                }
            }
            if (CalValEX.CalamityActive)
            {
                if (type == CalValEX.CalamityNPC("SEAHOE"))
                {
                    if ((bool)CalValEX.Calamity.Call("GetBossDowned", "oldduke"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<BloodwormScarf>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 50);
                        ++nextSlot;
                    }

                    if ((bool)CalValEX.Calamity.Call("GetBossDowned", "scal"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Yharlamitas>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(42);
                        ++nextSlot;
                    }
                }
                if (type == CalValEX.CalamityNPC("DILF")) //Permafrost
                {
                    if ((bool)CalValEX.Calamity.Call("GetBossDowned", "cryogen"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<FrostflakeBrick>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 10);
                        ++nextSlot;
                    }
                    if ((bool)CalValEX.Calamity.Call("GetBossDowned", "signus"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Signut>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(15);
                        ++nextSlot;
                    }
                }

                if (type == CalValEX.CalamityNPC("THIEF"))
                {
                    if ((bool)CalValEX.Calamity.Call("GetBossDowned", "astrumaureus"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<AureicFedora>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 10);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstrachnidTentacles>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstrachnidThorax>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstrachnidCranium>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5);
                        ++nextSlot;
                    }
                }

                if (type == CalValEX.CalamityNPC("FAP"))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<OddMushroomPot>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 30);
                    ++nextSlot;
                }
            }

            if (type == NPCID.Clothier)
            {
                if (CalValEX.CalamityActive)
                {
                    int bandit = NPC.FindFirstNPC(CalValEX.CalamityNPC("THIEF"));
                    int archmage = NPC.FindFirstNPC(CalValEX.CalamityNPC("DILF"));
                    if (bandit != -1)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<BanditHat>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 3);
                        ++nextSlot;
                    }

                    if (archmage != -1)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Permascarf>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 3);
                        ++nextSlot;
                    }
                }

                if (Main.LocalPlayer.ZoneDungeon || CalValEXWorld.dungeontiles > 100)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<PolterMask>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 3);
                    ++nextSlot;

                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Polterskirt>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 3);
                    ++nextSlot;

                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<PolterStockings>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 3);
                    ++nextSlot;
                }
            }

            if (type == NPCID.Dryad && Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstralGrass>());
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 50);
                ++nextSlot;
            }

            if (type == NPCID.Truffle)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<SwearshroomItem>());
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 2);
                ++nextSlot;
                if (NPC.downedPlantBoss)
                {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<ShroomiteVisage>());
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5);
                ++nextSlot;
            }
            }

            if (type == NPCID.Steampunker)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<XenoSolution>());
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 5);
                ++nextSlot;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<StarstruckSynthesizer>());
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5);
                ++nextSlot;
            }

            if (type == NPCID.PartyGirl)
            {
                if (Main.LocalPlayer.HasItem(ModContent.ItemType<Mirballoon>()) ||
                    Main.LocalPlayer.HasItem(ModContent.ItemType<BoB2>()))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<TiedMirageBalloon>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 5);
                    ++nextSlot;
                }

                if (Main.LocalPlayer.HasItem(ModContent.ItemType<BoxBalloon>()) ||
                    Main.LocalPlayer.HasItem(ModContent.ItemType<BoB2>()))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<TiedBoxBalloon>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 5);
                    ++nextSlot;
                }

                if (Main.LocalPlayer.HasItem(ModContent.ItemType<ChaosBalloon>()) ||
                    Main.LocalPlayer.HasItem(ModContent.ItemType<BoB2>()))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<TiedChaosBalloon>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 5);
                    ++nextSlot;
                }

                if (Main.LocalPlayer.HasItem(ModContent.ItemType<BoB2>()))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<TiedBoB2>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 5);
                    ++nextSlot;
                }

                if (CalValEX.CalamityActive && (bool)CalValEX.Calamity.Call("GetBossDowned", "polterghast"))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<ChaoticPuffball>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1);
                    ++nextSlot;
                }
            }
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == ModContent.NPCType<OracleNPC>())
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OracleBeanie>(), 1));
            }
            if (!CalValEXConfig.Instance.DisableVanityDrops)
            {
                if (CalValEX.CalamityActive)
                {
                    if (npc.type == CalValEX.CalamityNPC("DILF"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Permascarf>(), 1));
                    }
                    if (npc.type == CalValEX.CalamityNPC("THIEF"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BanditHat>(), 1));
                    }
                    if (npc.type == CalValEX.CalamityNPC("BoxJellyfish"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BoxBalloon>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("Rimehound"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TundraBall>(), 10));
                    }
                    if (npc.type == CalValEX.CalamityNPC("Rotdog"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RottenHotdog>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("PrismBack"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PrismShell>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("Toxicatfish"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DecayingFishtail>(), 10));
                    }
                    if (npc.type == CalValEX.CalamityNPC("DespairStone"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DespairMask>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("Scryllar"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ScryllianWings>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("ScryllarRage"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ScryllianWings>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("RepairUnitCritter"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DisrepairUnit>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("WulfrumAmplifier"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WulfrumTransmitter>(), 10));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WulfrumKeys>(), 10));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WulfrumHelipack>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("WulfrumGyrator"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WulfrumController>(), 100));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WulfrumBalloon>(), 100));
                    }
                    if (npc.type == CalValEX.CalamityNPC("WulfrumRover"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WulfrumController>(), 100));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RoverSpindle>(), 1000));
                    }
                    if (npc.type == CalValEX.CalamityNPC("WulfrumHovercraft"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WulfrumController>(), 100));
                    }
                    if (npc.type == CalValEX.CalamityNPC("WulfrumDrone"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WulfrumController>(), 100));
                    }
                    if (npc.type == CalValEX.CalamityNPC("CosmicElemental"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CosmicCone>(), 10));
                    }
                    if (npc.type == CalValEX.CalamityNPC("Sunskater"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EssenceofYeet>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("CrawlerAmethyst"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AmethystGeode>(), 10));
                    }
                    if (npc.type == CalValEX.CalamityNPC("CrawlerSapphire"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SapphireGeode>(), 10));
                    }
                    if (npc.type == CalValEX.CalamityNPC("CrawlerTopaz"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TopazGeode>(), 10));
                    }
                    if (npc.type == CalValEX.CalamityNPC("CrawlerEmerald"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EmeraldGeode>(), 10));
                    }
                    if (npc.type == CalValEX.CalamityNPC("CrawlerRuby"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RubyGeode>(), 10));
                    }
                    if (npc.type == CalValEX.CalamityNPC("CrawlerDiamond"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DiamondGeode>(), 10));
                    }
                    if (npc.type == CalValEX.CalamityNPC("CrawlerAmber"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AmberGeode>(), 10));
                    }
                    if (npc.type == CalValEX.CalamityNPC("CrawlerCrystal"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CrystalGeode>(), 10));
                    }
                    if (npc.type == CalValEX.CalamityNPC("ShockstormShuttle"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ShuttleBalloon>(), 10));
                    }
                    if (npc.type == CalValEX.CalamityNPC("SulphurousSkater"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AcidLamp>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("AeroSlime"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AeroWings>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("SeaFloaty"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FloatyCarpetItem>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("Orthocera"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Help>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("Trilobite"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TrilobiteShield>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("Bohldohr"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Eggstone>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("FlakCrab"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FlakHeadCrab>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("GammaSlime"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GammaHelmet>(), 30));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NuclearFumes>(), 5));
                    }
                    if (npc.type == CalValEX.CalamityNPC("PerennialSlime"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PerennialFlower>(), 20));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PerennialDress>(), 20));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientPerennialFlower>(), 30));
                    }
                    if (npc.type == CalValEX.CalamityNPC("BigSightseer"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AstralBinoculars>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("HeatSpirit"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EssenceofDisorder>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("BelchingCoral"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CoralMask>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("AnthozoanCrab"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CrackedFossil>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("Cryon"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Cryocap>(), 10));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Cryocoat>(), 10));
                    }
                    if (npc.type == CalValEX.CalamityNPC("CultistAssassin"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CultistHood>(), 30));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CultistRobe>(), 30));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CultistLegs>(), 30));
                    }
                    if (npc.type == CalValEX.CalamityNPC("ImpiousImmolator"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedChewToy>(), 40));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HolyTorch>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("Cnidrion"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SunDriedShrimp>(), 10));
                    }
                    if (npc.type == CalValEX.CalamityNPC("EidolonWyrmHead"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CanofWyrms>(), 10));
                    }
                    if (npc.type == CalValEX.CalamityNPC("OverloadedSoldier"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<UnloadedHelm>(), 10));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HauntedPebble>(), 10));
                    }
                    if (npc.type == CalValEX.CalamityNPC("DevilFish"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DevilfishMask2>(), 20));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DevilfishMask3>(), 10));
                    }
                    if (npc.type == CalValEX.CalamityNPC("DevilFishAlt"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DevilfishMask1>(), 20));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DevilfishMask3>(), 10));
                    }
                    if (npc.type == CalValEX.CalamityNPC("MirageJelly"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Mirballoon>(), 10));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OldMirage>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("Hadarian"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HadarianTail>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("AstralSlime"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AstraEGGeldon>(), 87000));
                    }
                    if (npc.type == CalValEX.CalamityNPC("Eidolist"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EidoMask>(), 10));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Eidcape>(), 10));
                    }
                    if (npc.type == NPCID.SandElemental)
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SmallSandPail>(), 5));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SmallSandPlushie>(), 10));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SandyBangles>(), 10));
                    }
                    if (npc.type == CalValEX.CalamityNPC("ProfanedEnergyBody"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedChewToy>(), 40));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedEnergyHook>(), 20));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedBalloon>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("ScornEater"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedChewToy>(), 40));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ScornEaterMask>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("ChaoticPuffer"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChaosBalloon>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("ReaperShark"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ReaperSharkArms>(), 10));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OmegaBlue>(), 40));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ReaperoidPills>(), 10));
                    }
                    if (npc.type == CalValEX.CalamityNPC("ColossalSquid"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SquidHat>(), 10));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OmegaBlue>(), 40));
                    }
                    if (npc.type == CalValEX.CalamityNPC("Horse"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EarthShield>(), 10));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EarthenHelmet>(), 20));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EarthenBreastplate>(), 20));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EarthenLeggings>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("ArmoredDiggerHead"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 10000));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ConstructionRemote>(), 4));
                    }
                    if (npc.type == CalValEX.CalamityNPC("PlaguebringerMiniboss"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlaguebringerPowerCell>(), 10));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlaugeWings>(), 15));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 10000));
                    }
                    if (npc.type == CalValEX.CalamityNPC("Mauler"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NuclearFumes>(), 1, 10, 25));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BubbledFin>(), 10));
                        npcLoot.Add(ItemDropRule.ByCondition(new MasterRevCondition(), ModContent.ItemType<MaulerPlush>(), 4));
                    }
                    if (npc.type == CalValEX.CalamityNPC("NuclearTerror"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NuclearFumes>(), 1, 10, 25));
                        npcLoot.Add(ItemDropRule.ByCondition(new MasterRevCondition(), ModContent.ItemType<NuclearTerrorPlush>(), 4));
                    }
                    if (npc.type == CalValEX.CalamityNPC("GiantClam"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ClamHermitMedallion>(), 10));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ClamMask>(), 10));
                        npcLoot.Add(ItemDropRule.ByCondition(new MasterRevCondition(), ModContent.ItemType<GiantClamPlush>(), 4));
                    }
                    if (npc.type == CalValEX.CalamityNPC("ThiccWaifu"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CloudCandy>(), 10));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CloudWaistbelt>(), 10));
                        npcLoot.Add(ItemDropRule.ByCondition(new FogboundCondition(), ModContent.ItemType<PurifiedFog>(), 20));
                        npcLoot.Add(ItemDropRule.ByCondition(new FogboundCondition2(), ModContent.ItemType<PurifiedFog>(), 999999));
                    }
                    if (npc.type == CalValEX.CalamityNPC("CragmawMire"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MawHook>(), 1));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NuclearFumes>(), 1, 5, 8));
                        npcLoot.Add(ItemDropRule.ByCondition(new Polteralive(), ModContent.ItemType<MirePlushP1>(), 4));
                        npcLoot.Add(ItemDropRule.ByCondition(new Polterdead(), ModContent.ItemType<MirePlushP1>(), 8));
                        npcLoot.Add(ItemDropRule.ByCondition(new Polterdead(), ModContent.ItemType<MirePlushP2>(), 8));
                    }
                    if (npc.type == CalValEX.CalamityNPC("GreatSandShark"))
                    {
                        AddPlushDrop(npcLoot, ModContent.ItemType<SandSharkPlush>());
                    }
                    if (npc.type == ModContent.NPCType<Xerocodile>())
                    {
                        npcLoot.Add(ItemDropRule.ByCondition(new YharonDowned(), ModContent.ItemType<Termipebbles>()));
                    }
                    if (npc.type == ModContent.NPCType<XerocodileSwim>())
                    {
                        npcLoot.Add(ItemDropRule.ByCondition(new YharonDowned(), ModContent.ItemType<Termipebbles>()));
                    }
                    //Scourge
                    if (npc.type == CalValEX.CalamityNPC("DesertScourgeHead"))
                    {
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<DesertMedallion>(), 5));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SlightlyMoistbutalsoSlightlyDryLocket>(), 7));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<DriedLocket>(), 3));
                        AddPlushDrop(npcLoot, ModContent.ItemType<DesertScourgePlush>());
                    }
                    //Crabulon
                    if (npc.type == CalValEX.CalamityNPC("Crabulon"))
                    {
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ClawShroom>(), 3));
                        AddPlushDrop(npcLoot, ModContent.ItemType<CrabulonPlush>());
                    }
                    //Perfs
                    if (npc.type == CalValEX.CalamityNPC("PerforatorHive"))
                    {
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SmallWorm>(), 7));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<MidWorm>(), 7));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BigWorm>(), 7));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<MeatyWormTumor>(), 3));
                        AddPlushDrop(npcLoot, ModContent.ItemType<PerforatorPlush>());
                    }
                    //Hive Mind
                    if (npc.type == CalValEX.CalamityNPC("HiveMind"))
                    {
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<RottenKey>(), 3));
                        AddPlushDrop(npcLoot, ModContent.ItemType<HiveMindPlush>());
                    }
                    //Slime Gods
                    if (npc.type == CalValEX.CalamityNPC("SlimeGodCore"))
                    {
                        AddBlockDrop(npcLoot, CalValEX.CalamityItem("StatigelBlock"));
                        AddPlushDrop(npcLoot, ModContent.ItemType<SlimeGodPlush>());
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<IonizedJellyCrystal>(), 50));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SlimeGodMask>(), 7));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SlimeDeitysSoul>(), 3));
                    }
                    //Cryogen
                    if (npc.type == CalValEX.CalamityNPC("Cryogen"))
                    {
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CoolShades>(), 3));
                        AddPlushDrop(npcLoot, ModContent.ItemType<CryogenPlush>());
                    }
                    //Aqua
                    if (npc.type == CalValEX.CalamityNPC("AquaticScourgeHead"))
                    {
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<MoistLocket>(), 3));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BleachBallItem>(), 4));
                        AddPlushDrop(npcLoot, ModContent.ItemType<AquaticScourgePlush>());
                    }
                    //Brimmy
                    if (npc.type == CalValEX.CalamityNPC("BrimstoneElemental"))
                    {
                        AddBlockDrop(npcLoot, CalValEX.CalamityItem("BrimstoneSlag"));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BrimmySpirit>(), 10));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BrimmyBody>(), 10));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<FoilSpoon>(), 20));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<RareBrimtulip>(), 3));
                        AddPlushDrop(npcLoot, ModContent.ItemType<BrimstoneElementalPlush>());
                    }
                    //Clone
                    if (npc.type == CalValEX.CalamityNPC("CalamitasClone"))
                    {
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<Calacirclet>(), 5));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 10000));
                        AddPlushDrop(npcLoot, ModContent.ItemType<ClonePlush>());
                    }
                    //Leviathan
                    if (npc.type == CalValEX.CalamityNPC("Leviathan"))
                    {
                        npcLoot.Add(ItemDropRule.ByCondition(new Levihita(), ModContent.ItemType<FoilAtlantis>(), 3));
                        npcLoot.Add(ItemDropRule.ByCondition(new Levihita(), ModContent.ItemType<StrangeMusicNote>(), 40));
                        AddPlushDrop(npcLoot, ModContent.ItemType<LeviathanPlush>());
                        npcLoot.Add(ItemDropRule.ByCondition(new LevihitaPlushies(), ModContent.ItemType<AnahitaPlush>(), 20));
                    }
                    if (npc.type == CalValEX.CalamityNPC("Anahita"))
                    {
                        npcLoot.Add(ItemDropRule.ByCondition(new Levihita(), ModContent.ItemType<FoilAtlantis>(), 3));
                        npcLoot.Add(ItemDropRule.ByCondition(new Levihita(), ModContent.ItemType<StrangeMusicNote>(), 40));
                        AddPlushDrop(npcLoot, ModContent.ItemType<AnahitaPlush>());
                        npcLoot.Add(ItemDropRule.ByCondition(new LevihitaPlushies(), ModContent.ItemType<LeviathanPlush>(), 20));
                    }
                    //Astrum Aureus
                    if (npc.type == CalValEX.CalamityNPC("AstrumAureus"))
                    {
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<AureusShield>(), 5));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<AstralInfectedIcosahedron>(), 3));
                        npcLoot.Add(ItemDropRule.ByCondition(new MasterRevCondition(), ModContent.ItemType<SpaceJunk>()));
                        AddPlushDrop(npcLoot, ModContent.ItemType<AstrumAureusPlush>());
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 10000));
                        npcLoot.Add(ItemDropRule.ByCondition(new GeldonDrop(), ModContent.ItemType<SpaceJunk>()));
                    }
                    //PBG
                    if (npc.type == CalValEX.CalamityNPC("PlaguebringerGoliath"))
                    {
                        AddBlockDrop(npcLoot, CalValEX.CalamityItem("PlaguedContainmentBrick"));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<InfectedController>(), 5));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<PlaguePack>(), 5));
                        AddPlushDrop(npcLoot, ModContent.ItemType<PlaguebringerGoliathPlush>());
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 1000));
                    }
                    //Ravager
                    if (npc.type == CalValEX.CalamityNPC("RavagerBody"))
                    {
                        LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

                        notExpertRule.OnSuccess(ItemDropRule.OneFromOptions(1, new int[]{
                        ModContent.ItemType<SkullBalloon>(),
                        ModContent.ItemType<StonePile>(),
                        ModContent.ItemType<RavaHook>(),
                        ModContent.ItemType<SkullCluster>() }));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ScavaHook>(), 15));
                        AddBlockDrop(npcLoot, ModContent.ItemType<Necrostone>());
                        AddPlushDrop(npcLoot, ModContent.ItemType<RavagerPlush>());
                    }
                    //Deus
                    //PS: FUCK deus lootcode, I pray to anyone who wants to make weakref support for this abomination _ YuH 2022
                    if (npc.type == CalValEX.CalamityNPC("AstrumDeusHead"))
                    {
                        LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
                        npcLoot.Add(ItemDropRule.ByCondition(new DeusFUCKBlight(), ModContent.ItemType<AstrumDeusMask>()));
                        npcLoot.Add(ItemDropRule.ByCondition(new DeusFUCKMasorev(), ModContent.ItemType<AstrumDeusPlush>(), 4));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new DeusFUCK(), ModContent.ItemType<AstBandana>(), 4));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new DeusFUCK(), ModContent.ItemType<Geminga>(), 3));
                    }
                    //Bumblebirb
                    if (npc.type == CalValEX.CalamityNPC("Bumblefuck"))
                    {
                        LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

                        notExpertRule.OnSuccess(ItemDropRule.OneFromOptions(1, new int[]{
                        ModContent.ItemType<Birbhat>(),
                        ModContent.ItemType<FollyWings>(),
                        ModContent.ItemType<DocilePheromones>()}));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new SilvaCrystal(), CalValEX.CalamityItem("SilvaCrystal"), 1, 155, 265));
                        npcLoot.Add(ItemDropRule.ByCondition(new MasterRevCondition(), ModContent.ItemType<ExtraFluffyFeather>()));
                        AddPlushDrop(npcLoot, ModContent.ItemType<BumblefuckPlush>()); ;
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 500));
                        npcLoot.Add(ItemDropRule.ByCondition(new DogeDrop(), ModContent.ItemType<ExtraFluffyFeather>()));
                    }
                    //Providence
                    if (npc.type == CalValEX.CalamityNPC("Providence"))
                    {
                        AddBlockDrop(npcLoot, CalValEX.CalamityItem("ProfanedRock"));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ProviCrystal>(), 4));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ProfanedHeart>(), 3));
                        AddPlushDrop(npcLoot, ModContent.ItemType<ProvidencePlush>());
                    }
                    //Storm Weaver
                    if (npc.type == CalValEX.CalamityNPC("StormWeaverHead"))
                    {
                        LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new OtherworldlyStoneDrop(), CalValEX.CalamityItem("OtherworldlyStone"), 1, 155, 265));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<StormBandana>(), 10));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ArmoredScrap>(), 6));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<StormMedal>(), 6));
                        AddPlushDrop(npcLoot, ModContent.ItemType<StormWeaverPlush>());
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 250));
                    }
                    //Signus
                    if (npc.type == CalValEX.CalamityNPC("Signus"))
                    {
                        LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

                        notExpertRule.OnSuccess(ItemDropRule.OneFromOptions(1, new int[]{
                        ModContent.ItemType<SignusBalloon>(),
                        ModContent.ItemType<SigCape>(),
                        ModContent.ItemType<SignusEmblem>(),
                        ModContent.ItemType<ShadowCloth>(),
                        ModContent.ItemType<SignusNether>()}));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new OtherworldlyStoneDrop(), CalValEX.CalamityItem("OtherworldlyStone"), 1, 155, 265));
                        npcLoot.Add(ItemDropRule.ByCondition(new JunkoDrop(), ModContent.ItemType<SuspiciousLookingChineseCrown>()));
                        AddPlushDrop(npcLoot, ModContent.ItemType<SignusPlush>());
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 250));
                    }
                    //CV
                    if (npc.type == CalValEX.CalamityNPC("CeaselessVoid"))
                    {
                        LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new OtherworldlyStoneDrop(), CalValEX.CalamityItem("OtherworldlyStone"), 1, 155, 265));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<VoidWings>(), 10));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<OldVoidWings>(), 15));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<MirrorMatter>(), 3));
                        AddPlushDrop(npcLoot, ModContent.ItemType<CeaselessVoidPlush>());
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 250));
                    }
                    //Polterghast
                    if (npc.type == CalValEX.CalamityNPC("Polterghast"))
                    {
                        LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new BlockDrops(), CalValEX.CalamityItem("StratusBricks"), 2, 155, 265));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new BlockDrops(), ModContent.ItemType<PhantowaxBlock>(), 2, 155, 265));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<Polterhook>(), 20));
                        npcLoot.Add(ItemDropRule.ByCondition(new MasterRevCondition(), ModContent.ItemType<ToyScythe>(), 3));
                        AddPlushDrop(npcLoot, ModContent.ItemType<PolterghastPlush>());
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ZygoteinaBucket>(), 3));
                    }
                    //Old Duke
                    if (npc.type == CalValEX.CalamityNPC("OldDuke"))
                    {
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<OldWings>(), 3));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CorrodedCleaver>(), 3));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CharredChopper>(), 6));
                        AddPlushDrop(npcLoot, ModContent.ItemType<OldDukePlush>());
                    }
                    //DoG
                    if (npc.type == CalValEX.CalamityNPC("DevourerofGodsHead"))
                    {
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CosmicWormScarf>(), 5));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<RapturedWormScarf>(), 20));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CosmicRapture>(), 3));
                        AddPlushDrop(npcLoot, ModContent.ItemType<DevourerofGodsPlush>());
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 100));
                    }
                    //Yharon
                    if (npc.type == CalValEX.CalamityNPC("Yharon"))
                    {
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<YharonShackle>(), 3));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<JunglePhoenixWings>(), 5));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<YharonsAnklet>(), 10));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<NuggetinaBiscuit>(), 3));
                        AddPlushDrop(npcLoot, ModContent.ItemType<YharonPlush>());
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 20));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<Termipebbles>(), 1, 3, 8));
                        npcLoot.Add(ItemDropRule.ByCondition(new RoverDrop(), ModContent.ItemType<RoverSpindle>()));
                    }
                    //Supreme Cal
                    if (npc.type == CalValEX.CalamityNPC("SupremeCalamitas"))
                    {
                        AddBlockDrop(npcLoot, CalValEX.CalamityItem("OccultBrickItem"));
                        npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<GruelingMask>(), 3));
                        AddPlushDrop(npcLoot, ModContent.ItemType<CalamitasFumo>());
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 10));
                    }
                    //Ares
                    if (npc.type == CalValEX.CalamityNPC("AresBody"))
                    {
                        LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new Exodrop(), ModContent.ItemType<Items.Equips.Shirts.AresChestplate.AresChestplate>(), 3));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new Exodrop(), ModContent.ItemType<DraedonBody>(), 5));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new Exodrop(), ModContent.ItemType<DraedonLegs>(), 5));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new Exodrop(), ModContent.ItemType<OminousCore>(), 3));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new Exodrop(), ModContent.ItemType<AncientAuricTeslaHelm>(), 3));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new ExoPlating(), CalValEX.CalamityItem("ExoPlating"), 1, 155, 265));
                        npcLoot.Add(ItemDropRule.ByCondition(new ExoPlush(), ModContent.ItemType<AresPlush>()));
                        npcLoot.Add(ItemDropRule.ByCondition(new ExoPlush(), ModContent.ItemType<DraedonPlush>(), 10));
                    }
                    //Thanatos
                    if (npc.type == CalValEX.CalamityNPC("ThanatosHead"))
                    {
                        LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new Exodrop(), ModContent.ItemType<XMLightningHook>(), 3));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new Exodrop(), ModContent.ItemType<DraedonBody>(), 5));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new Exodrop(), ModContent.ItemType<DraedonLegs>(), 5));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new Exodrop(), ModContent.ItemType<GunmetalRemote>(), 3));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new Exodrop(), ModContent.ItemType<AncientAuricTeslaHelm>(), 3));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new ExoPlating(), CalValEX.CalamityItem("ExoPlating"), 1, 155, 265));
                        npcLoot.Add(ItemDropRule.ByCondition(new ExoPlush(), ModContent.ItemType<ThanatosPlush>()));
                        npcLoot.Add(ItemDropRule.ByCondition(new ExoPlush(), ModContent.ItemType<DraedonPlush>(), 10));
                    }
                    //Apollo
                    if (npc.type == CalValEX.CalamityNPC("Apollo"))
                    {
                        LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new Exodrop(), ModContent.ItemType<ArtemisBalloonSmall>(), 3));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new Exodrop(), ModContent.ItemType<ApolloBalloonSmall>(), 3));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new Exodrop(), ModContent.ItemType<DraedonBody>(), 5));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new Exodrop(), ModContent.ItemType<DraedonLegs>(), 5));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new Exodrop(), ModContent.ItemType<GeminiMarkImplants>(), 3));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new Exodrop(), ModContent.ItemType<AncientAuricTeslaHelm>(), 3));
                        notExpertRule.OnSuccess(ItemDropRule.ByCondition(new ExoPlating(), CalValEX.CalamityItem("ExoPlating"), 1, 155, 265));
                        npcLoot.Add(ItemDropRule.ByCondition(new ExoPlush(), ModContent.ItemType<ArtemisPlush>()));
                        npcLoot.Add(ItemDropRule.ByCondition(new ExoPlush(), ModContent.ItemType<ApolloPlush>()));
                        npcLoot.Add(ItemDropRule.ByCondition(new ExoPlush(), ModContent.ItemType<DraedonPlush>(), 10));
                    }
                    //Wyrm
                    if (npc.type == CalValEX.CalamityNPC("AdultEidolonWyrmHead"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Tiles.RespirationShrine>()));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SoulShard>()));
                        AddPlushDrop(npcLoot, ModContent.ItemType<JaredPlush>());
                    }
                    //Donuts
                    if (npc.type == CalValEX.CalamityNPC("ProfanedGuardianCommander"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedWheels>(), 3));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedCultistMask>(), 5));
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedCultistRobes>(), 5));
                        AddPlushDrop(npcLoot, ModContent.ItemType<ProfanedGuardianPlush>());
                    }
                    if (npc.type == CalValEX.CalamityNPC("ProfanedGuardianDefender"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedFrame>(), 3));
                    }
                    if (npc.type == CalValEX.CalamityNPC("ProfanedGuardianHealer"))
                    {
                        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedBattery>(), 3));
                    }
                }
            }
            //Meldosaurus
            if (npc.type == ModContent.NPCType<AprilFools.Meldosaurus.Meldosaurus>())
            {
                LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

                notExpertRule.OnSuccess(ItemDropRule.OneFromOptions(1, new int[]{
                        ModContent.ItemType<ShadesBane>(),
                        ModContent.ItemType<Nyanthrop>()}));


                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AprilFools.Meldosaurus.MeldosaurusTrophy>(), 10));
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<AprilFools.Meldosaurus.MeldosaurusMask>(), 7));
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<AprilFools.Meldosaurus.MeldosaurusBag>()));
                if (CalValEX.CalamityActive)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new MasterRevCondition(), ModContent.ItemType<AprilFools.Meldosaurus.MeldosaurusRelic>()));
                }
                npcLoot.Add(ItemDropRule.ByCondition(new MeldosaurusDowned(), ModContent.ItemType<AprilFools.Meldosaurus.KnowledgeMeldosaurus>()));
            }
            //Fogbound
            if (npc.type == ModContent.NPCType<AprilFools.Fogbound>())
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PurifiedFog>(), 1));
                if (CalValEX.CalamityActive)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Fogdowned(), Mod.Find<ModItem>("KnowledgeFogbound").Type));
                }
            }
            Mod CatalystMod;
            Mod Hypnos;
            ModLoader.TryGetMod("CatalystMod", out CatalystMod);
            ModLoader.TryGetMod("Hypnos", out Hypnos);
            if (Hypnos != null)
            {
                if (npc.type == Hypnos.Find<ModNPC>("HypnosBoss").Type)
                {
                    AddPlushDrop(npcLoot, ModContent.ItemType<HypnosPlush>());
                }
            }
            if (CatalystMod != null)
            {
                if (npc.type == CatalystMod.Find<ModNPC>("Astrageldon").Type)
                {
                    AddPlushDrop(npcLoot, ModContent.ItemType<AstrageldonPlush>());
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SpaceJunk>(), 3));
                }
            }

            //Yharexs' Dev Pet (Calamity BABY)
            /*if (CalValEX.CalamityActive && (bool)CalValEX.Calamity.Call("GetDifficultyActive", "death"))
            {
                if (npc.type == CalValEX.CalamityNPC("SupremeCalamitas"))
                {
                    bool didIGetHit = false;
                    for (int i = 0; i < Main.maxPlayers; i++)
                    {
                        Player player = Main.player[i];
                        if (player.active && !player.dead)
                        {
                            if (player.GetModPlayer<CalValEXPlayer>().SCalHits > 0)
                            {
                                didIGetHit = true;
                            }
                        }
                    }

                    if (!didIGetHit)
                    {
                        Item.NewItem(npc.GetSource_FromAI(), npc.getRect(), ModContent.ItemType<AstraEGGeldon>());
                    }
                    else
                    {
                        if (Main.rand.Next(1000) == 0)
                        {
                            Item.NewItem(npc.GetSource_FromAI(), npc.getRect(), ModContent.ItemType<AstraEGGeldon>());
                        }
                    }
                }
            }*/
        }
        public static void AddPlushDrop(NPCLoot loot, int item)
        {
            loot.Add(ItemDropRule.ByCondition(new MasterRevCondition(), item, 4));
        }
        public static void AddBlockDrop(NPCLoot loot, int item)
        {
            LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
            notExpertRule.OnSuccess(ItemDropRule.ByCondition(new BlockDrops(), item, 1, 55, 265));
        }

        int signuskill;
        private bool signusbackup = false;
        int signusshaker = 0;
        Vector2 jharimpos;
        int calashoot = 0;

        [JITWhenModsEnabled("CalamityMod")]
        public override void AI(NPC npc)
        {
            if (CalValEX.CalamityActive)
            {
                Mod.TryFind<ModProjectile>("JharimKiller", out ModProjectile brimbuck);
                if (npc.type == CalValEX.CalamityNPC("WITCH") && (!CalValEXWorld.jharinter || !NPC.downedMoonlord))
                {
                    if (NPC.AnyNPCs(ModContent.NPCType<AprilFools.Jharim.Jharim>()))
                    {
                        for (int x = 0; x < Main.maxNPCs; x++)
                        {
                            NPC npc3 = Main.npc[x];
                            if (npc3.type == ModContent.NPCType<AprilFools.Jharim.Jharim>() && npc3.active)
                            {
                                jharimpos.X = npc3.Center.X;
                                jharimpos.Y = npc3.Center.Y;
                                calashoot++;
                                if (npc3.position.X - npc.position.X >= 0)
                                {
                                    npc.direction = 1;
                                }
                                else
                                {
                                    npc.direction = -1;
                                }
                            }
                        }
                    }
                    if (calashoot >= 5)
                    {
                        Vector2 position = npc.Center;
                        position.X = npc.Center.X + (20f * npc.direction);
                        Vector2 direction = jharimpos - position;
                        direction.Normalize();
                        float speed = 10f;
                        int type = brimbuck.Type;
                        int damage = 6666;
                        Projectile.NewProjectile(npc.GetSource_FromAI(), position, direction * speed, type, damage, 0f, Main.myPlayer);
                        calashoot = 0;
                    }
                }
                if (npc.type == CalValEX.CalamityNPC("Signus"))
                {
                    if ((npc.ai[0] == -33f || signusbackup) && Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().junsi)
                    {
                        Dust dust;
                        Vector2 position = npc.position;
                        for (int a = 0; a < 3; a++)
                        {
                            dust = Main.dust[Terraria.Dust.NewDust(position, npc.width, npc.height, 16, 0f, 0f, 0, new Color(255, 255, 255), 1.578947f)];
                            dust.shader = GameShaders.Armor.GetSecondaryShader(131, Main.LocalPlayer);
                        }
                        npc.rotation = 0;
                        npc.direction = -1;
                        npc.spriteDirection = -1;
                        signusshaker++;
                        npc.alpha = 0;
                        npc.velocity.X = 0;
                        npc.velocity.Y = 0;
                        signuskill++;
                        npc.dontTakeDamage = true;
                        for (int k = 0; k < npc.buffImmune.Length; k++)
                        {
                            npc.buffImmune[k] = true;
                        }
                        if (signuskill == 64)
                        {
                            signuskill = 0;
                            npc.knockBackResist = 20f;
                            npc.StrikeNPC(499999, 99f, npc.direction * 50, true, false, false);
                            signusbackup = false;
                        }
                        if (signusshaker == 1)
                        {
                            npc.velocity.X = -5;
                        }
                        else if (signusshaker == 2)
                        {
                            npc.velocity.X = 5;
                            signusshaker = 0;
                        }
                    }
                    else
                    {
                        signuskill = 0;
                        signusshaker = 0;
                    }
                    if (!Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().junsi)
                    {
                        signusbackup = false;
                        if (npc.ai[0] == -33f)
                        {
                            npc.ai[0] = 0f;
                            npc.ai[1] = 0f;
                            npc.ai[2] = 0f;
                            npc.ai[3] = 0f;
                        }
                    }
                }
            }
        }

        public override bool StrikeNPC(NPC npc, ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            if (CalValEX.CalamityActive)
            {
                if (npc.type == CalValEX.CalamityNPC("Signus") && !signusbackup && Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().junsi && Main.netMode != NetmodeID.Server)
                {
                    if (damage >= npc.life)
                    {
                        npc.dontTakeDamage = true;
                        damage = npc.life - 1;
                        npc.ai[0] = -33f;
                        npc.ai[1] = -33f;
                        npc.ai[2] = -33f;
                        npc.ai[3] = -33f;
                        signusbackup = true;
                        crit = false;
                    }
                    else
                    {
                        signusbackup = false;
                    }
                    return false;
                }
                return true;
            }
            return true;
        }
        
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback,
            ref bool crit, ref int hitDirection)
        {
            if (CalValEX.CalamityActive)
            {
                if (npc.type == CalValEX.CalamityNPC("AstrumAureus"))
                {
                    if (projectile.type == CalValEX.CalamityProjectile("AstrageldonLaser") || projectile.type == CalValEX.CalamityProjectile("AstrageldonSummon"))
                    {
                        npc.GetGlobalNPC<CalValEXGlobalNPC>().geldonSummon = true;
                    }
                    else
                    {
                        npc.GetGlobalNPC<CalValEXGlobalNPC>().geldonSummon = false;
                    }
                }
                else if (npc.type == CalValEX.CalamityNPC("Bumblefuck"))
                {
                    if (projectile.type == CalValEX.CalamityProjectile("MiniatureFolly") && projectile.DamageType != DamageClass.Ranged)
                    {
                        npc.GetGlobalNPC<CalValEXGlobalNPC>().bdogeMount = true;
                    }
                    else
                    {
                        npc.GetGlobalNPC<CalValEXGlobalNPC>().bdogeMount = false;
                    }
                }
                else if (npc.type == CalValEX.CalamityNPC("Yharon"))
                {
                    if (projectile.type == CalValEX.CalamityProjectile("WulfrumDroid"))
                    {
                        npc.GetGlobalNPC<CalValEXGlobalNPC>().wolfram = true;
                    }
                    else
                    {
                        npc.GetGlobalNPC<CalValEXGlobalNPC>().wolfram = false;
                    }
                }
                else if (npc.type == CalValEX.CalamityNPC("Signus"))
                {
                    if (projectile.type == CalValEX.CalamityProjectile("PristineFire") ||
                        projectile.type == CalValEX.CalamityProjectile("PristineSecondary"))
                    {
                        npc.GetGlobalNPC<CalValEXGlobalNPC>().junkoReference = true;
                    }
                    else
                    {
                        npc.GetGlobalNPC<CalValEXGlobalNPC>().junkoReference = false;
                    }
                }
            }
        }

        [JITWhenModsEnabled("CalamityMod")]
        public void BossExclam(NPC npc, int[] types, bool downed, int boss)
        {
            if (npc.type == boss && !downed)
            {
                CalamityMod.NPCs.CalamityGlobalNPC.SetNewShopVariable(types, downed);
            }
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override bool PreKill(NPC npc)
        {
            if (CalValEX.CalamityActive)
            {
                BossExclam(npc, new int[] { CalValEX.CalamityNPC("SEAHOE") }, (bool)CalValEX.Calamity.Call("GetBossDowned", "oldduke"), CalValEX.CalamityNPC("OldDuke"));
                BossExclam(npc, new int[] { CalValEX.CalamityNPC("SEAHOE") }, (bool)CalValEX.Calamity.Call("GetBossDowned", "scal"), CalValEX.CalamityNPC("SupremeCalamitas"));

                BossExclam(npc, new int[] { CalValEX.CalamityNPC("DILF") }, (bool)CalValEX.Calamity.Call("GetBossDowned", "signus"), CalValEX.CalamityNPC("Signus"));

                BossExclam(npc, new int[] { CalValEX.CalamityNPC("THIEF") }, (bool)CalValEX.Calamity.Call("GetBossDowned", "astrumaureus"), CalValEX.CalamityNPC("AstrumAureus"));

                BossExclam(npc, new int[] { NPCID.PartyGirl }, (bool)CalValEX.Calamity.Call("GetBossDowned", "polterghast"), CalValEX.CalamityNPC("Polterghast"));

                if (npc.type == CalValEX.CalamityNPC("CrabShroom") && Main.LocalPlayer.HasItem(ModContent.ItemType<PutridShroom>()) && NPC.AnyNPCs(CalValEX.CalamityNPC("Crabulon")))
                {
                    NPC.NewNPC(npc.GetSource_Death(), (int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Swearshroom>());
                }

                if (npc.type == CalValEX.CalamityNPC("Signus") && junkoReference)
                {
                    Item.NewItem(npc.GetSource_FromAI(), npc.Hitbox, ModContent.ItemType<SuspiciousLookingChineseCrown>());
                }

                if (npc.type == CalValEX.CalamityNPC("Yharon") && wolfram)
                {
                    Item.NewItem(npc.GetSource_FromAI(), npc.Hitbox, ModContent.ItemType<RoverSpindle>());
                }

                if (npc.type == CalValEX.CalamityNPC("AstrumAureus") && geldonSummon)
                {
                    Item.NewItem(npc.GetSource_FromAI(), npc.Hitbox, ModContent.ItemType<SpaceJunk>());
                }

                if (npc.type == CalValEX.CalamityNPC("Bumblefuck") && bdogeMount)
                {
                    Item.NewItem(npc.GetSource_FromAI(), npc.Hitbox, ModContent.ItemType<ExtraFluffyFeatherClump>());
                }
            }

            int droppedMoney = 0;
            for (int i = 0; i < Main.maxPlayers; i++)
            {
                Player player = Main.player[i];
                if (player.active && !player.dead)
                {
                    if (player.HasBuff(ModContent.BuffType<MorshuBuff>()))
                    {
                        float value = npc.value;
                        value /= 5;
                        if (value < 0)
                        {
                            value = 1;
                        }

                        if (droppedMoney == 0)
                        {
                            while (value > 0)
                            {
                                if (value > 1000000f)
                                {
                                    int platCoins = (int)(value / 1000000f);
                                    if (platCoins > 50 && Main.rand.Next(5) == 0)
                                    {
                                        platCoins /= Main.rand.Next(3) + 1;
                                    }

                                    if (Main.rand.Next(5) == 0)
                                    {
                                        platCoins /= Main.rand.Next(3) + 1;
                                    }

                                    value -= 1000000f * platCoins;
                                    Item.NewItem(npc.GetSource_FromAI(), npc.Hitbox, ItemID.PlatinumCoin, platCoins);
                                    continue;
                                }

                                if (value > 10000f)
                                {
                                    int goldCoins = (int)(value / 10000f);
                                    if (goldCoins > 50 && Main.rand.Next(5) == 0)
                                    {
                                        goldCoins /= Main.rand.Next(3) + 1;
                                    }

                                    if (Main.rand.Next(5) == 0)
                                    {
                                        goldCoins /= Main.rand.Next(3) + 1;
                                    }

                                    value -= 10000f * goldCoins;
                                    Item.NewItem(npc.GetSource_FromAI(), npc.Hitbox, ItemID.GoldCoin, goldCoins);
                                    continue;
                                }

                                if (value > 100f)
                                {
                                    int silverCoins = (int)(value / 100f);
                                    if (silverCoins > 50 && Main.rand.Next(5) == 0)
                                    {
                                        silverCoins /= Main.rand.Next(3) + 1;
                                    }

                                    if (Main.rand.Next(5) == 0)
                                    {
                                        silverCoins /= Main.rand.Next(3) + 1;
                                    }

                                    value -= 100f * silverCoins;
                                    Item.NewItem(npc.GetSource_FromAI(), npc.Hitbox, ItemID.SilverCoin, silverCoins);
                                    continue;
                                }

                                int copperCoins = (int)value;
                                if (copperCoins > 50 && Main.rand.Next(5) == 0)
                                {
                                    copperCoins /= Main.rand.Next(3) + 1;
                                }

                                if (Main.rand.Next(5) == 0)
                                {
                                    copperCoins /= Main.rand.Next(4) + 1;
                                }

                                if (copperCoins < 1)
                                {
                                    copperCoins = 1;
                                }

                                value -= copperCoins;
                                Item.NewItem(npc.GetSource_FromAI(), npc.Hitbox, ItemID.CopperCoin, copperCoins);
                            }

                            droppedMoney++;
                        }
                    }
                }
            }
            return true;
        }

        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenpos, Color drawColor)
        {
            //ModLoader.GetMod("Cala").GetContent<ModBiome>().
            if (Main.LocalPlayer.InModBiome(ModContent.GetInstance<Biomes.AstralBlight>()) || Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().Blok)
            {
                //DEUS HEAD
                if (npc.type == CalValEX.CalamityNPC("AstrumDeusHead"))
                {
                    Texture2D deusheadsprite = (ModContent.Request<Texture2D>("CalValEX/NPCs/AstrumDeus/DeusHeadOld").Value);

                    float deusheadframe = 1f / (float)Main.npcFrameCount[npc.type];
                    int deusheadheight = (int)((float)(npc.frame.Y / npc.frame.Height) * deusheadframe) * (deusheadsprite.Height / 1);

                    Rectangle deusheadsquare = new Rectangle(0, deusheadheight, deusheadsprite.Width, deusheadsprite.Height / 1);
                    Color deusheadalpha = npc.GetAlpha(drawColor);
                    Main.EntitySpriteDraw(deusheadsprite, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusheadsquare, deusheadalpha, npc.rotation, Utils.Size(deusheadsquare) / 2f, npc.scale, SpriteEffects.None, 0);
                    return false;
                }

                //DEUS BODY
                else if (npc.type == CalValEX.CalamityNPC("AstrumDeusBody"))
                {
                    Texture2D deusbodsprite = npc.localAI[3] == 1f ? ModContent.Request<Texture2D>("CalValEX/NPCs/AstrumDeus/DeusBodyAltOld").Value : ModContent.Request<Texture2D>("CalValEX/NPCs/AstrumDeus/DeusBodyOld").Value;

                    float deusbodframe = 1f / (float)Main.npcFrameCount[npc.type];
                    int deusbodheight = (int)((float)(npc.frame.Y / npc.frame.Height) * deusbodframe) * (deusbodsprite.Height / 1);

                    Rectangle deusbodsquare = new Rectangle(0, deusbodheight, deusbodsprite.Width, deusbodsprite.Height / 1);
                    Color deusbodalpha = npc.GetAlpha(drawColor);
                    Main.EntitySpriteDraw(deusbodsprite, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusbodsquare, deusbodalpha, npc.rotation, Utils.Size(deusbodsquare) / 2f, npc.scale, SpriteEffects.None, 0);
                    return false;
                }

                //DEUS TAIL
                else if (npc.type == CalValEX.CalamityNPC("AstrumDeusTail"))
                {
                    Texture2D deustailsprite = ModContent.Request<Texture2D>("CalValEX/NPCs/AstrumDeus/DeusTailOld").Value;

                    float deustailframe = 1f / (float)Main.npcFrameCount[npc.type];
                    int deustailheight = (int)((float)(npc.frame.Y / npc.frame.Height) * deustailframe) * (deustailsprite.Height / 1);

                    Rectangle deustailsquare = new Rectangle(0, deustailheight, deustailsprite.Width, deustailsprite.Height / 1);
                    Color deustailalpha = npc.GetAlpha(drawColor);
                    Main.EntitySpriteDraw(deustailsprite, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deustailsquare, deustailalpha, npc.rotation, Utils.Size(deustailsquare) / 2f, npc.scale, SpriteEffects.None, 0);
                    return false;
                }
            }
            return true;

        }

        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenpos, Color drawColor)
        {
            if (CalValEX.CalamityActive)
            {
                if (npc.type == CalValEX.CalamityNPC("SlimeGodCore") && CalValEX.AprilFoolDay)
                {
                    Texture2D tidepodgsprite = (ModContent.Request<Texture2D>("CalValEX/ExtraTextures/SlimeGod").Value);

                    float tidepodgframe = 1f / (float)Main.npcFrameCount[npc.type];
                    int tidepodgheight = (int)((float)(npc.frame.Y / npc.frame.Height) * tidepodgframe) * (tidepodgsprite.Height / 1);

                    Rectangle tidepodgsquare = new Rectangle(0, tidepodgheight, tidepodgsprite.Width, tidepodgsprite.Height / 1);
                    Color tidepodgalpha = npc.GetAlpha(drawColor);
                    spriteBatch.Draw(tidepodgsprite, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), tidepodgsquare, tidepodgalpha, npc.rotation, Utils.Size(tidepodgsquare) / 2f, npc.scale, SpriteEffects.None, 0f);
                }

                else if (Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneAstral || Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().Blok)
                {
                    //DEUS HEAD
                    if (npc.type == CalValEX.CalamityNPC("AstrumDeusHead"))
                    {
                        Texture2D deusheadsprite2 = (ModContent.Request<Texture2D>("CalValEX/NPCs/AstrumDeus/DeusHeadOld_Glow").Value);

                        float deusheadframe2 = 1f / (float)Main.npcFrameCount[npc.type];
                        int deusheadheight2 = (int)((float)(npc.frame.Y / npc.frame.Height) * deusheadframe2) * (deusheadsprite2.Height / 1);

                        Rectangle deusheadsquare2 = new Rectangle(0, deusheadheight2, deusheadsprite2.Width, deusheadsprite2.Height / 1);
                        spriteBatch.Draw(deusheadsprite2, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusheadsquare2, Color.White, npc.rotation, Utils.Size(deusheadsquare2) / 2f, npc.scale, SpriteEffects.None, 0f);
                    }

                    //DEUS BODY
                    else if (npc.type == CalValEX.CalamityNPC("AstrumDeusBody"))
                    {
                        Texture2D deusbodsprite2 = npc.localAI[3] == 1f ? ModContent.Request<Texture2D>("CalValEX/NPCs/AstrumDeus/DeusBodyAltOld_Glow").Value : ModContent.Request<Texture2D>("CalValEX/NPCs/AstrumDeus/DeusBodyOld_Glow").Value;

                        float deusbodframe2 = 1f / (float)Main.npcFrameCount[npc.type];
                        int deusbodheight2 = (int)((float)(npc.frame.Y / npc.frame.Height) * deusbodframe2) * (deusbodsprite2.Height / 1);

                        Rectangle deusbodsquare2 = new Rectangle(0, deusbodheight2, deusbodsprite2.Width, deusbodsprite2.Height / 1);
                        spriteBatch.Draw(deusbodsprite2, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusbodsquare2, Color.White, npc.rotation, Utils.Size(deusbodsquare2) / 2f, npc.scale, SpriteEffects.None, 0f);
                    }

                    //DEUS TAIL
                    else if (npc.type == CalValEX.CalamityNPC("AstrumDeusTail"))
                    {
                        Texture2D deustailsprite2 = (ModContent.Request<Texture2D>("CalValEX/NPCs/AstrumDeus/DeusTailOld_Glow").Value);

                        float deustailframe2 = 1f / (float)Main.npcFrameCount[npc.type];
                        int deustailheight2 = (int)((float)(npc.frame.Y / npc.frame.Height) * deustailframe2) * (deustailsprite2.Height / 1);

                        Rectangle deustailsquare2 = new Rectangle(0, deustailheight2, deustailsprite2.Width, deustailsprite2.Height / 1);
                        spriteBatch.Draw(deustailsprite2, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deustailsquare2, Color.White, npc.rotation, Utils.Size(deustailsquare2) / 2f, npc.scale, SpriteEffects.None, 0f);
                    }
                }
            }
        }

        //Disable Astral Blight overworld spawns
        [JITWhenModsEnabled("CalamityMod")]
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo LocalPlayer)
        {
            Player player = LocalPlayer.Player;
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            bool acid = CalValEX.CalamityActive ? !(bool)CalValEX.Calamity.Call("AcidRainActive") : true;
            bool noevents = acid && !Main.eclipse && !Main.snowMoon && !Main.pumpkinMoon && Main.invasionType == 0 && !player.ZoneTowerSolar && !player.ZoneTowerStardust && !player.ZoneTowerVortex & !player.ZoneTowerNebula && !player.ZoneOldOneArmy;
            Mod cata;
            ModLoader.TryGetMod("CatalystMod", out cata);
            if (!CalValEXConfig.Instance.CritterSpawns)
            {
                if (modPlayer.sBun)
                {
                    pool.Add(NPCID.Bunny, 0.001f);
                }
            }
            if (player.InModBiome(ModContent.GetInstance<Biomes.AstralBlight>()) && noevents)
            {
                pool.Clear();
                if (!CalValEXConfig.Instance.CritterSpawns)
                {
                    pool.Add(ModContent.NPCType<NPCs.Critters.Blightolemur>(), 0.1f);
                    pool.Add(ModContent.NPCType<NPCs.Critters.Blinker>(), 0.1f);
                    pool.Add(ModContent.NPCType<NPCs.Critters.AstJR>(), 0.1f);
                    pool.Add(ModContent.NPCType<NPCs.Critters.GAstJR>(), 0.1f);
                    if (modPlayer.sBun)
                    {
                        pool.Add(NPCID.Bunny, 0.001f);
                    }
                }
                if (cata != null)
                {
                    if (player.ZoneOverworldHeight)
                    {
                        if (!player.HasItem(cata.Find<ModItem>("AstralCommunicator").Type))
                        {
                            pool.Add(cata.Find<ModNPC>("AstrageldonSlime").Type, 0.002f);
                        }
                        if ((bool)cata.Call("DownedAstrageldon", Mod))
                        {
                            pool.Add(cata.Find<ModNPC>("ArmoredAstralSlime").Type, 0.02f);
                        }
                    }
                }

            }
        }
    }
}
