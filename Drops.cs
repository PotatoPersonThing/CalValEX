using CalamityMod.World;
using CalamityMod;
using static CalamityMod.NPCs.ExoMechs.Ares.AresBody;
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
using CalValEX.Items.Tiles.Monoliths;
using CalValEX.Items.Tiles.Paintings;
using CalValEX.Items.Tiles.Plants;
using CalValEX.NPCs.JellyPriest;
using CalValEX.NPCs.Oracle;
using Terraria.GameContent.ItemDropRules;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

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

        private bool bdogeMount;
        private bool geldonSummon;
        private bool junkoReference;
        private bool wolfram;


        public static int meldodon = -1;
        public static int jharim = -1;

        public override bool InstancePerEntity => true;

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
            if (type == ModContent.NPCType<CalamityMod.NPCs.TownNPCs.SEAHOE>())
            {
                if (CalamityMod.DownedBossSystem.downedBoomerDuke)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<BloodwormScarf>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 50);
                    ++nextSlot;
                }

                if (CalamityMod.DownedBossSystem.downedSCal)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Yharlamitas>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(42);
                    ++nextSlot;
                }
            }

            if (type == ModContent.NPCType<CalamityMod.NPCs.TownNPCs.DILF>()) //Permafrost
            {
                if (CalamityMod.DownedBossSystem.downedCryogen)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<FrostflakeBrick>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 10);
                    ++nextSlot;
                }
                if (CalamityMod.DownedBossSystem.downedSignus)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Signut>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(15);
                    ++nextSlot;
                }
            }

            if (type == ModContent.NPCType<CalamityMod.NPCs.TownNPCs.THIEF>())
            {
                if (CalamityMod.DownedBossSystem.downedAstrumAureus)
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

            if (type == ModContent.NPCType<CalamityMod.NPCs.TownNPCs.FAP>())
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<OddMushroomPot>());
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 30);
                ++nextSlot;
            }

            if (type == NPCID.Clothier)
            {
                int bandit = NPC.FindFirstNPC(ModContent.NPCType<CalamityMod.NPCs.TownNPCs.THIEF>());
                int archmage = NPC.FindFirstNPC(ModContent.NPCType<CalamityMod.NPCs.TownNPCs.DILF>());
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

                if (CalamityMod.DownedBossSystem.downedPolterghast)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<ChaoticPuffball>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1);
                    ++nextSlot;
                }
            }
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (!CalValEXConfig.Instance.DisableVanityDrops)
            {
                if (npc.type == ModContent.NPCType<OracleNPC>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OracleBeanie>(), 1));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.TownNPCs.DILF>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Permascarf>(), 1));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.TownNPCs.THIEF>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BanditHat>(), 1));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Abyss.BoxJellyfish>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BoxBalloon>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.Rimehound>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TundraBall>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.Rotdog>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RottenHotdog>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.SunkenSea.PrismBack>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PrismShell>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.SulphurousSea.Catfish>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DecayingFishtail>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Crags.DespairStone>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DespairMask>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Crags.Scryllar>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ScryllianWings>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Crags.ScryllarRage>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ScryllianWings>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.DraedonLabThings.RepairUnitCritter>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DisrepairUnit>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.WulfrumPylon>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WulfrumTransmitter>(), 10));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WulfrumKeys>(), 10));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WulfrumHelipack>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.WulfrumGyrator>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WulfrumController>(), 100));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WulfrumBalloon>(), 100));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.WulfrumRover>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WulfrumController>(), 100));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RoverSpindle>(), 1000));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.WulfrumHovercraft>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WulfrumController>(), 100));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.WulfrumDrone>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WulfrumController>(), 100));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CosmicElemental>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CosmicCone>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.Sunskater>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EssenceofYeet>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CrawlerAmethyst>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AmethystGeode>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CrawlerSapphire>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SapphireGeode>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CrawlerTopaz>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TopazGeode>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CrawlerEmerald>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EmeraldGeode>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CrawlerRuby>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RubyGeode>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CrawlerDiamond>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DiamondGeode>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CrawlerAmber>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AmberGeode>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CrawlerCrystal>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CrystalGeode>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.ShockstormShuttle>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ShuttleBalloon>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.AcidRain.SulphurousSkater>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AcidLamp>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.AeroSlime>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AeroWings>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.SunkenSea.SeaFloaty>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FloatyCarpetItem>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.AcidRain.Orthocera>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Help>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.AcidRain.Trilobite>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TrilobiteShield>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.AcidRain.Mauler>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NuclearFumes>(), 1, 10, 25));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BubbledFin>(), 10));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<MaulerPlush>(), 4);
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.AcidRain.NuclearTerror>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NuclearFumes>(), 1, 10, 25));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<NuclearTerrorPlush>(), 4);
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.Bohldohr>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Eggstone>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.AcidRain.FlakCrab>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FlakHeadCrab>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.AcidRain.GammaSlime>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GammaHelmet>(), 30));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NuclearFumes>(), 5));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.PerennialSlime>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PerennialFlower>(), 20));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PerennialDress>(), 20));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientPerennialFlower>(), 30));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Astral.BigSightseer>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AstralBinoculars>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Crags.HeatSpirit>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EssenceofDisorder>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.SulphurousSea.BelchingCoral>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CoralMask>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.SulphurousSea.AnthozoanCrab>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CrackedFossil>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.Cryon>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Cryocap>(), 10));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Cryocoat>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Crags.CultistAssassin>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CultistHood>(), 30));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CultistRobe>(), 30));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CultistLegs>(), 30));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.ImpiousImmolator>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedChewToy>(), 40));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HolyTorch>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.Cnidrion>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SunDriedShrimp>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Abyss.EidolonWyrmHead>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CanofWyrms>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.OverloadedSoldier>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<UnloadedHelm>(), 10));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HauntedPebble>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Abyss.DevilFish>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DevilfishMask2>(), 20));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DevilfishMask3>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Abyss.DevilFishAlt>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DevilfishMask1>(), 20));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DevilfishMask3>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Abyss.MirageJelly>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Mirballoon>(), 10));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OldMirage>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Astral.Hadarian>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HadarianTail>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Astral.AstralSlime>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AstraEGGeldon>(), 87000));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.Eidolist>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EidoMask>(), 10));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Eidcape>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.SunkenSea.GiantClam>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ClamHermitMedallion>(), 10));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ClamMask>(), 10));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<GiantClamPlush>(), 4);
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.PlagueEnemies.PlaguebringerMiniboss>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlaguebringerPowerCell>(), 10));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlaugeWings>(), 15));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 10000));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.ThiccWaifu>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CloudCandy>(), 10));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CloudWaistbelt>(), 10));
                }
                if (npc.type == NPCID.SandElemental)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SmallSandPail>(), 5));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SmallSandPlushie>(), 10));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SandyBangles>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.ProfanedEnergyBody>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedChewToy>(), 40));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedEnergyHook>(), 20));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedBalloon>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.ScornEater>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedChewToy>(), 40));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ScornEaterMask>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Abyss.ChaoticPuffer>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChaosBalloon>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Abyss.ReaperShark>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ReaperSharkArms>(), 10));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OmegaBlue>(), 40));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ReaperoidPills>(), 10));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Abyss.ColossalSquid>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SquidHat>(), 10));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OmegaBlue>(), 40));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.Horse>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EarthShield>(), 10));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EarthenHelmet>(), 20));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EarthenBreastplate>(), 20));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EarthenLeggings>(), 20));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.ArmoredDiggerHead>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 10000));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.AcidRain.CragmawMire>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MawHook>(), 1));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NuclearFumes>(), 1, 5, 8));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<MirePlushP1>(), 8);
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<MirePlushP2>(), 8);
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.GreatSandShark.GreatSandShark>()) {
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<SandSharkPlush>(), 4);
                }
                if (npc.type == ModContent.NPCType<Xerocodile>())
                {
                    npcLoot.AddIf(() => CalamityMod.DownedBossSystem.downedYharon, ModContent.ItemType<Termipebbles>(), 1);
                }
                if (npc.type == ModContent.NPCType<XerocodileSwim>())
                {
                    npcLoot.AddIf(() => CalamityMod.DownedBossSystem.downedYharon, ModContent.ItemType<Termipebbles>(), 1);
                }
                //Scourge
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.DesertScourge.DesertScourgeHead>())
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<DesertMedallion>(), 5));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SlightlyMoistbutalsoSlightlyDryLocket>(), 7));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<DriedLocket>(), 3));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<DesertScourgePlush>(), 4);
                }
                //Crabulon
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Crabulon.Crabulon>())
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ClawShroom>(), 3));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<CrabulonPlush>(), 4);
                }
                //Perfs
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorHive>())
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SmallWorm>(), 7));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<MidWorm>(), 7));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BigWorm>(), 7));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<MeatyWormTumor>(), 3));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<PerforatorPlush>(), 4);
                }
                //Hive Mind
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.HiveMind.HiveMind>())
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<RottenKey>(), 3));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<HiveMindPlush>(), 4);
                }
                //Slime Gods...
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodCore>())
                {
                    npcLoot.AddIf(() => !Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks, ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureStatigel.StatigelBlock>(), 1, 155, 265);
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<SlimeGodPlush>(), 4);
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<IonizedJellyCrystal>(), 50));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SlimeGodMask>(), 7));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SlimeDeitysSoul>(), 3));
                }
                //Cryogen
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Cryogen.Cryogen>())
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CoolShades>(), 3));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<CryogenPlush>(), 4);
                }
                //Aqua
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.AquaticScourge.AquaticScourgeHead>())
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<MoistLocket>(), 3));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BleachBall>(), 4));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<AquaticScourgePlush>(), 4);
                }
                //Brimmy
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.BrimstoneElemental.BrimstoneElemental>())
                {
                    npcLoot.AddIf(() => !Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks, ModContent.ItemType<CalamityMod.Items.Placeables.BrimstoneSlag>(), 1, 155, 265);
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BrimmySpirit>(), 10));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BrimmyBody>(), 10));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<FoilSpoon>(), 20));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<RareBrimtulip>(), 3));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<BrimstoneElementalPlush>(), 4);
                }
                //Clone
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Calamitas.CalamitasClone>())
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<Calacirclet>(), 5));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 10000));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<ClonePlush>(), 4);
                }
                //Leviathan
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Leviathan.Leviathan>())
                {
                    npcLoot.AddIf(() => CalamityMod.NPCs.Leviathan.Leviathan.LastAnLStanding() && !Main.expertMode, ModContent.ItemType<FoilAtlantis>(), 3);
                    npcLoot.AddIf(() => CalamityMod.NPCs.Leviathan.Leviathan.LastAnLStanding() && !Main.expertMode, ModContent.ItemType<AquaticMonolith>(), 10);
                    npcLoot.AddIf(() => CalamityMod.NPCs.Leviathan.Leviathan.LastAnLStanding() && !Main.expertMode, ModContent.ItemType<StrangeMusicNote>(), 40);
                    npcLoot.AddIf(() => CalamityMod.NPCs.Leviathan.Leviathan.LastAnLStanding() && CalValEXWorld.masorev, ModContent.ItemType<LeviathanPlush>(), 4);
                    npcLoot.AddIf(() => CalamityMod.NPCs.Leviathan.Leviathan.LastAnLStanding() && CalValEXWorld.masorev, ModContent.ItemType<AnahitaPlush>(), 20);
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Leviathan.Anahita>())
                {
                    npcLoot.AddIf(() => CalamityMod.NPCs.Leviathan.Leviathan.LastAnLStanding() && !Main.expertMode, ModContent.ItemType<FoilAtlantis>(), 3);
                    npcLoot.AddIf(() => CalamityMod.NPCs.Leviathan.Leviathan.LastAnLStanding() && !Main.expertMode, ModContent.ItemType<AquaticMonolith>(), 10);
                    npcLoot.AddIf(() => CalamityMod.NPCs.Leviathan.Leviathan.LastAnLStanding() && !Main.expertMode, ModContent.ItemType<StrangeMusicNote>(), 40);
                    npcLoot.AddIf(() => CalamityMod.NPCs.Leviathan.Leviathan.LastAnLStanding() && CalValEXWorld.masorev, ModContent.ItemType<AnahitaPlush>(), 4);
                    npcLoot.AddIf(() => CalamityMod.NPCs.Leviathan.Leviathan.LastAnLStanding() && CalValEXWorld.masorev, ModContent.ItemType<LeviathanPlush>(), 20);
                }
                //Astrum Aureus
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.AstrumAureus.AstrumAureus>())
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<AureusShield>(), 5));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<AstralInfectedIcosahedron>(), 3));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<SpaceJunk>(), 10);
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<AstrumAureusPlush>(), 4);
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 10000));
                    npcLoot.AddIf(() => geldonSummon, ModContent.ItemType<SpaceJunk>());
                }
                //PBG
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.PlaguebringerGoliath.PlaguebringerGoliath>())
                {
                    npcLoot.AddIf(() => !Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks, ModContent.ItemType<CalamityMod.Items.Placeables.FurniturePlagued.PlaguedContainmentBrick>(), 1, 155, 265);
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<InfectedController>(), 5));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<PlaguePack>(), 5));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<PlaguebringerGoliathPlush>(), 4);
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 1000));
                }
                //Ravager
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Ravager.RavagerBody>())
                {
                    var normalOnly = npcLoot.DefineNormalOnlyDropSet();
                    {
                        int[] items = new int[]
                        {
                            ModContent.ItemType<SkullBalloon>(),
                            ModContent.ItemType<StonePile>(),
                            ModContent.ItemType<RavaHook>(),
                            ModContent.ItemType<SkullCluster>()
                        };
                        normalOnly.Add(DropHelper.CalamityStyle(DropHelper.NormalWeaponDropRateFraction, items));
                    }
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ScavaHook>(), 15));
                    npcLoot.AddIf(() => !Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks, ModContent.ItemType<Necrostone>(), 1, 155, 265);
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<RavagerPlush>(), 4);
                }
                //Deus
                //PS: FUCK deus lootcode, I pray to anyone who wants to make weakref support for this abomination
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.AstrumDeus.AstrumDeusHead>())
                {
                    var lastWorm = npcLoot.DefineConditionalDropSet(info => !CalamityMod.NPCs.AstrumDeus.AstrumDeusHead.ShouldNotDropThings(info.npc));
                    bool blight(DropAttemptInfo info) => Main.LocalPlayer.InModBiome(ModContent.GetInstance<Biomes.AstralBlight>()) && !CalamityMod.NPCs.AstrumDeus.AstrumDeusHead.ShouldNotDropThings(info.npc);
                    bool masre(DropAttemptInfo info) => CalValEXWorld.masorev && !CalamityMod.NPCs.AstrumDeus.AstrumDeusHead.ShouldNotDropThings(info.npc);

                    lastWorm.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<AstBandana>(), 20));
                    lastWorm.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<Geminga>(), 3));
                    npcLoot.AddIf(blight, ModContent.ItemType<AstrumDeusMask>());
                    npcLoot.AddIf(masre, ModContent.ItemType<AstrumDeusPlush>(), 4);
                }
                //Bumblebirb
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Bumblebirb.Bumblefuck>())
                {
                    var normalOnly = npcLoot.DefineNormalOnlyDropSet();
                    {
                        int[] items = new int[]
                        {
                            ModContent.ItemType<Birbhat>(),
                            ModContent.ItemType<FollyWings>(),
                            ModContent.ItemType<DocilePheromones>(),
                        };
                        normalOnly.Add(DropHelper.CalamityStyle(DropHelper.NormalWeaponDropRateFraction, items));
                    }
                    npcLoot.AddIf(() => !Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks && DownedBossSystem.downedYharon, ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureSilva.SilvaCrystal>(), 1, 155, 265);
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SparrowMeat>(), 20));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<BumblefuckPlush>(), 4);
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<ExtraFluffyFeather>(), 10);
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 500));
                    npcLoot.AddIf(() => bdogeMount, ModContent.ItemType<ExtraFluffyFeatherClump>());
                }
                //Providence
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Providence.Providence>())
                {
                    npcLoot.AddIf(() => !Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks, ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureProfaned.ProfanedRock>(), 1, 155, 265);
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ProviCrystal>(), 4));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ProfanedHeart>(), 3));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<ProvidencePlush>(), 4);
                }
                //Storm Weaver
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.StormWeaver.StormWeaverHead>())
                {
                    npcLoot.AddIf(() => !Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks && DownedBossSystem.downedDoG, ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureOtherworldly.OtherworldlyStone>(), 1, 155, 265);
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<StormBandana>(), 10));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ArmoredScrap>(), 6));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<StormMedal>(), 6));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<StormWeaverPlush>(), 4);
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 250));
                }
                //Signus
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Signus.Signus>())
                {
                    var normalOnly = npcLoot.DefineNormalOnlyDropSet();
                    {
                        int[] items = new int[]
                        {
                            ModContent.ItemType<SignusBalloon>(),
                            ModContent.ItemType<SigCape>(),
                            ModContent.ItemType<SignusNether>(),
                            ModContent.ItemType<SignusEmblem>(),
                            ModContent.ItemType<ShadowCloth>(),
                        };
                        normalOnly.Add(DropHelper.CalamityStyle(DropHelper.NormalWeaponDropRateFraction, items));
                    }
                    npcLoot.AddIf(() => !Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks && DownedBossSystem.downedDoG, ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureOtherworldly.OtherworldlyStone>(), 1, 155, 265);
                    npcLoot.AddIf(() => junkoReference, ModContent.ItemType<SuspiciousLookingChineseCrown>());
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<SignusPlush>(), 4);
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 250));
                }
                //CV
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.CeaselessVoid.CeaselessVoid>())
                {
                    npcLoot.AddIf(() => !Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks && DownedBossSystem.downedDoG, ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureOtherworldly.OtherworldlyStone>(), 1, 155, 265);
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<VoidWings>(), 10));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<OldVoidWings>(), 15));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<MirrorMatter>(), 3));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<CeaselessVoidPlush>(), 4);
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 250));
                }
                //Polterghast
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Polterghast.Polterghast>())
                {
                    npcLoot.AddIf(() => !Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks, ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureStratus.StratusBricks>(), 2, 155, 265);
                    npcLoot.AddIf(() => !Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks, ModContent.ItemType<PhantowaxBlock>(), 2, 155, 265);
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<Polterhook>(), 20));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<ToyScythe>(), 3);
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<PolterghastPlush>(), 4);
                    npcLoot.AddIf(() => !Main.expertMode, ModContent.ItemType<BucketOfAxolotl>(), 3);
                }
                //Old Duke
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.OldDuke.OldDuke>())
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<OldWings>(), 3));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CorrodedCleaver>(), 3));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CharredChopper>(), 6));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<OldDukePlush>(), 4);
                }
                //DoG
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.DevourerofGods.DevourerofGodsHead>())
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CosmicWormScarf>(), 5));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<RapturedWormScarf>(), 20));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CosmicRapture>(), 3));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<DevourerofGodsPlush>(), 4);
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 100));
                }
                //Yharon
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Yharon.Yharon>())
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<YharonShackle>(), 3));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<JunglePhoenixWings>(), 5));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<YharonsAnklet>(), 10));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<NuggetinaBiscuit>(), 3));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<YharonPlush>(), 4);
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 20));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<Termipebbles>(), 1, 3, 8));
                    npcLoot.AddIf(() => wolfram, ModContent.ItemType<RoverSpindle>());
                }
                //Supreme Cal
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.SupremeCalamitas.SupremeCalamitas>())
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<GruelingMask>(), 3));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<CalamitasFumo>(), 4);
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 10));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CalamityLamp>(), 5));
                }
                //Ares
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.ExoMechs.Ares.AresBody>())
                {
                    npcLoot.AddIf(() => CanDropLoot() && !Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks, ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureExo.ExoPlating>(), 1, 155, 265);
                    npcLoot.AddIf(() => CanDropLoot() && !Main.expertMode, ModContent.ItemType<Items.Equips.Shirts.AresChestplate.AresChestplate>(), 3);
                    npcLoot.AddIf(() => CanDropLoot() && !Main.expertMode, ModContent.ItemType<DraedonBody>(), 5);
                    npcLoot.AddIf(() => CanDropLoot() && !Main.expertMode, ModContent.ItemType<DraedonLegs>(), 5);
                    npcLoot.AddIf(() => CanDropLoot() && !Main.expertMode, ModContent.ItemType<OminousCore>(), 3);
                    npcLoot.AddIf(() => CanDropLoot() && CalValEXWorld.masorev, ModContent.ItemType<AresPlush>());
                    npcLoot.AddIf(() => CanDropLoot() && CalValEXWorld.masorev, ModContent.ItemType<DraedonPlush>(), 10);
                    npcLoot.AddIf(() => CanDropLoot() && !Main.expertMode, ModContent.ItemType<AncientAuricTeslaHelm>(), 10);
                }
                //Thanatos
                if (npc.type == ModContent.NPCType < CalamityMod.NPCs.ExoMechs.Thanatos.ThanatosHead> ())
                {
                    npcLoot.AddIf(() => CanDropLoot() && !Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks, ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureExo.ExoPlating>(), 1, 155, 265);
                    npcLoot.AddIf(() => CanDropLoot() && !Main.expertMode, ModContent.ItemType<XMLightningHook>(), 3);
                    npcLoot.AddIf(() => CanDropLoot() && !Main.expertMode, ModContent.ItemType<DraedonBody>(), 5);
                    npcLoot.AddIf(() => CanDropLoot() && !Main.expertMode, ModContent.ItemType<DraedonLegs>(), 5);
                    npcLoot.AddIf(() => CanDropLoot() && !Main.expertMode, ModContent.ItemType<GunmetalRemote>(), 3);
                    npcLoot.AddIf(() => CanDropLoot() && CalValEXWorld.masorev, ModContent.ItemType<ThanatosPlush>());
                    npcLoot.AddIf(() => CanDropLoot() && CalValEXWorld.masorev, ModContent.ItemType<DraedonPlush>(), 10);
                    npcLoot.AddIf(() => CanDropLoot() && !Main.expertMode, ModContent.ItemType<AncientAuricTeslaHelm>(), 10);
                }
                //Apollo
                if (npc.type == ModContent.NPCType < CalamityMod.NPCs.ExoMechs.Apollo.Apollo> ())
                {
                    npcLoot.AddIf(() => CanDropLoot() && !Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks, ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureExo.ExoPlating>(), 1, 155, 265);
                    npcLoot.AddIf(() => CanDropLoot() && !Main.expertMode, ModContent.ItemType<ArtemisBalloonSmall>(), 6);
                    npcLoot.AddIf(() => CanDropLoot() && !Main.expertMode, ModContent.ItemType<ApolloBalloonSmall>(), 6);
                    npcLoot.AddIf(() => CanDropLoot() && !Main.expertMode, ModContent.ItemType<DraedonBody>(), 5);
                    npcLoot.AddIf(() => CanDropLoot() && !Main.expertMode, ModContent.ItemType<DraedonLegs>(), 5);
                    npcLoot.AddIf(() => CanDropLoot() && !Main.expertMode, ModContent.ItemType<GeminiMarkImplants>(), 3);
                    npcLoot.AddIf(() => CanDropLoot() && CalValEXWorld.masorev, ModContent.ItemType<ArtemisPlush>());
                    npcLoot.AddIf(() => CanDropLoot() && CalValEXWorld.masorev, ModContent.ItemType<ApolloPlush>());
                    npcLoot.AddIf(() => CanDropLoot() && CalValEXWorld.masorev, ModContent.ItemType<DraedonPlush>(), 10);
                    npcLoot.AddIf(() => CanDropLoot() && !Main.expertMode, ModContent.ItemType<AncientAuricTeslaHelm>(), 10);
                }
                //Wyrm
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.AdultEidolonWyrm.AdultEidolonWyrmHead>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Tiles.RespirationShrine>(), 1));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SoulShard>()));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<JaredPlush>(), 4);
                }
                //Donuts
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.ProfanedGuardians.ProfanedGuardianCommander>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedWheels>(), 3));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<ProfanedGuardianPlush>(), 4);
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ProfanedCultistMask>(), 5));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ProfanedCultistRobes>(), 5));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.ProfanedGuardians.ProfanedGuardianDefender>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedFrame>(), 3));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ProfanedCultistMask>(), 5));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ProfanedCultistRobes>(), 5));
                }
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.ProfanedGuardians.ProfanedGuardianHealer>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedBattery>(), 3));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ProfanedCultistMask>(), 5));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ProfanedCultistRobes>(), 5));
                }
                //Meldosaurus
                if (npc.type == ModContent.NPCType<AprilFools.Meldosaurus.Meldosaurus>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AprilFools.Meldosaurus.MeldosaurusTrophy>(), 10));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<AprilFools.Meldosaurus.MeldosaurusMask>(), 7));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<AprilFools.ShadesBane>(), 2));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<AprilFools.Nyanthrop>(), 2));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<AprilFools.Meldosaurus.MeldosaurusBag>()));
                    npcLoot.AddIf(() => CalValEXWorld.masorev, ModContent.ItemType<AprilFools.Meldosaurus.MeldosaurusRelic>());
                }
                //Meldosaurus
                if (npc.type == ModContent.NPCType<AprilFools.Fogbound>())
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PurifiedFog>(), 1));
                }

                //Yharexs' Dev Pet (Calamity BABY)
                if (CalamityMod.World.CalamityWorld.death)
                {
                    if (npc.type == ModContent.NPCType<CalamityMod.NPCs.SupremeCalamitas.SupremeCalamitas>())
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
                }
            }
        }

        int signuskill;
        private bool signusbackup = false;
        int signusshaker = 0;
        Vector2 jharimpos;
        int calashoot = 0;

        public override void AI(NPC npc)
        {
            if ((npc.type == ModContent.NPCType<CalamityMod.NPCs.TownNPCs.WITCH>()) && (!CalValEXWorld.jharinter || !NPC.downedMoonlord))
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
                    int type = ModContent.ProjectileType<Projectiles.JharimKiller>();
                    int damage = 6666;
                    Projectile.NewProjectile(npc.GetSource_FromAI(), position, direction * speed, type, damage, 0f, Main.myPlayer);
                    calashoot = 0;
                }
            }
            if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Signus.Signus>())
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

        public override bool StrikeNPC(NPC npc, ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Signus.Signus>() && !signusbackup && Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().junsi && Main.netMode != NetmodeID.Server)
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
        
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback,
            ref bool crit, ref int hitDirection)
        {
            if (npc.type == ModContent.NPCType<CalamityMod.NPCs.AstrumAureus.AstrumAureus>())
            {
                if (projectile.type == ModContent.ProjectileType<CalamityMod.Projectiles.Summon.AstrageldonLaser>() || projectile.type == ModContent.ProjectileType<CalamityMod.Projectiles.Summon.AstrageldonSummon>())
                {
                    geldonSummon = true;
                }
                else
                {
                    geldonSummon = false;
                }
            }
            else if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Bumblebirb.Bumblefuck>())
            {
                if (projectile.type == ModContent.ProjectileType<CalamityMod.Projectiles.Ranged.MiniatureFolly>() && projectile.DamageType != DamageClass.Ranged)
                {
                    bdogeMount = true;
                }
                else
                {
                    bdogeMount = false;
                }
            }
            else if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Yharon.Yharon>())
            {
                if (projectile.type == ModContent.ProjectileType<CalamityMod.Projectiles.Summon.WulfrumDroid>() || projectile.type == ModContent.ProjectileType<CalamityMod.Projectiles.Summon.WulfrumDroid>())
                {
                    wolfram = true;
                }
                else
                {
                    wolfram = false;
                }
            }
            else if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Signus.Signus>())
            {
                if (projectile.type == ModContent.ProjectileType<CalamityMod.Projectiles.Ranged.PristineFire>() ||
                    projectile.type == ModContent.ProjectileType<CalamityMod.Projectiles.Ranged.PristineSecondary>())
                {
                    junkoReference = true;
                }
                else
                {
                    junkoReference = false;
                }
            }
        }
        public void BossExclam(NPC npc, int[] types, bool downed, int boss)
        {
            if (npc.type == boss && !downed)
            {
                CalamityMod.NPCs.CalamityGlobalNPC.SetNewShopVariable(types, downed);
            }
        }

        public override bool PreKill(NPC npc)
        {
            /*BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedCLAM, ModContent.NPCType<CalamityMod.NPCs.SunkenSea.GiantClam>());
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedCrabulon, ModContent.NPCType<CalamityMod.NPCs.Crabulon.CrabulonIdle>());
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, NPC.downedBoss3, NPCID.SkeletronHead);
            //Fuck slime god btw
            if (!NPC.AnyNPCs(ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodSplit>())&& !NPC.AnyNPCs(ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodRun>()) && !NPC.AnyNPCs(ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodRunSplit>()) && !NPC.AnyNPCs(ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGod>()))
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedSlimeGod, ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodCore>());
            if (NPC.CountNPCS(ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodSplit>()) == 1 && !NPC.AnyNPCs(ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodCore>()) && !NPC.AnyNPCs(ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodRun>()) && !NPC.AnyNPCs(ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodRunSplit>()) && !NPC.AnyNPCs(ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGod>()))
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedSlimeGod, ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodSplit>());
            if (NPC.CountNPCS(ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodRunSplit>()) == 1 && !NPC.AnyNPCs(ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodCore>()) && !NPC.AnyNPCs(ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodRun>()) && !NPC.AnyNPCs(ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodSplit>()) && !NPC.AnyNPCs(ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGod>()))
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedSlimeGod, ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodSplit>());
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, Main.hardMode, NPCID.WallofFlesh);
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedCryogen, ModContent.NPCType<CalamityMod.NPCs.Cryogen.Cryogen>());
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedCalamitas, ModContent.NPCType<CalamityMod.NPCs.Calamitas.CalamitasRun3>());
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, NPC.downedPlantBoss, NPCID.Plantera);
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedAstrageldon, ModContent.NPCType<CalamityMod.NPCs.AstrumAureus.AstrumAureus>());
            if (!NPC.AnyNPCs(ModContent.NPCType<CalamityMod.NPCs.Leviathan.Siren>()))
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedLeviathan, ModContent.NPCType<CalamityMod.NPCs.Leviathan.Leviathan>());
            if (!NPC.AnyNPCs(ModContent.NPCType<CalamityMod.NPCs.Leviathan.Leviathan>()))
                BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedLeviathan, ModContent.NPCType<CalamityMod.NPCs.Leviathan.Siren>());
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, NPC.downedGolemBoss, NPCID.Golem);
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedPlaguebringer, ModContent.NPCType<CalamityMod.NPCs.PlaguebringerGoliath.PlaguebringerGoliath>());
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedScavenger, ModContent.NPCType<CalamityMod.NPCs.Ravager.RavagerBody>());
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedBumble, ModContent.NPCType<CalamityMod.NPCs.Bumblebirb.Bumblefuck>());
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedProvidence, ModContent.NPCType<CalamityMod.NPCs.Providence.Providence>());
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedSentinel1, ModContent.NPCType<CalamityMod.NPCs.CeaselessVoid.CeaselessVoid>());
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedSentinel2, ModContent.NPCType<CalamityMod.NPCs.StormWeaver.StormWeaverHead>());
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedSentinel3, ModContent.NPCType<CalamityMod.NPCs.Signus.Signus>());
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedPolterghast, ModContent.NPCType<CalamityMod.NPCs.Polterghast.Polterghast>());
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedBoomerDuke, ModContent.NPCType<CalamityMod.NPCs.OldDuke.OldDuke>());
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedDoG, ModContent.NPCType<CalamityMod.NPCs.DevourerofGods.DevourerofGodsHead>());
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedYharon, ModContent.NPCType<CalamityMod.NPCs.Yharon.Yharon>());
            if (npc.type == NPCID.WallofFlesh && !Main.hardMode)
            {
                CalamityMod.NPCs.CalamityGlobalNPC.SetNewShopVariable(new int[] { ModContent.NPCType<NPCs.Oracle.OracleNPC>() }, Main.hardMode);
            }
            if (!CalamityWorld.downedPerforator)
                BossExclam(npc, new int[] { ModContent.NPCType<OracleNPC>() }, CalamityWorld.downedHiveMind, ModContent.NPCType<CalamityMod.NPCs.HiveMind.HiveMind>());
            if (!CalamityWorld.downedHiveMind)
                BossExclam(npc, new int[] { ModContent.NPCType<OracleNPC>() }, CalamityWorld.downedPerforator, ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorHive>());
            BossExclam(npc, new int[] { ModContent.NPCType<OracleNPC>() }, CalamityWorld.downedCryogen, ModContent.NPCType<CalamityMod.NPCs.Cryogen.Cryogen>());
            BossExclam(npc, new int[] { ModContent.NPCType<OracleNPC>() }, NPC.downedPlantBoss, NPCID.Plantera);
            BossExclam(npc, new int[] { ModContent.NPCType<OracleNPC>() }, CalamityWorld.downedCalamitas, ModContent.NPCType<CalamityMod.NPCs.Calamitas.CalamitasRun3>());
            BossExclam(npc, new int[] { ModContent.NPCType<OracleNPC>() }, CalamityWorld.downedBumble, ModContent.NPCType<CalamityMod.NPCs.Bumblebirb.Bumblefuck>());
            BossExclam(npc, new int[] { ModContent.NPCType<OracleNPC>() }, CalamityWorld.downedProvidence, ModContent.NPCType<CalamityMod.NPCs.Providence.Providence>());
            BossExclam(npc, new int[] { ModContent.NPCType<OracleNPC>() }, CalamityWorld.downedSentinel3, ModContent.NPCType<CalamityMod.NPCs.Signus.Signus>());
            BossExclam(npc, new int[] { ModContent.NPCType<OracleNPC>() }, CalamityWorld.downedDoG, ModContent.NPCType<CalamityMod.NPCs.DevourerofGods.DevourerofGodsHead>());
            BossExclam(npc, new int[] { ModContent.NPCType<OracleNPC>() }, CalamityWorld.downedYharon, ModContent.NPCType<CalamityMod.NPCs.Yharon.Yharon>());*/

            BossExclam(npc, new int[] { ModContent.NPCType<CalamityMod.NPCs.TownNPCs.SEAHOE>() }, CalamityMod.DownedBossSystem.downedBoomerDuke, ModContent.NPCType<CalamityMod.NPCs.OldDuke.OldDuke>());
            BossExclam(npc, new int[] { ModContent.NPCType<CalamityMod.NPCs.TownNPCs.SEAHOE>() }, CalamityMod.DownedBossSystem.downedSCal, ModContent.NPCType<CalamityMod.NPCs.SupremeCalamitas.SupremeCalamitas>());

            BossExclam(npc, new int[] { ModContent.NPCType<CalamityMod.NPCs.TownNPCs.DILF>() }, CalamityMod.DownedBossSystem.downedSignus, ModContent.NPCType<CalamityMod.NPCs.Signus.Signus>());

            BossExclam(npc, new int[] { ModContent.NPCType<CalamityMod.NPCs.TownNPCs.THIEF>() }, CalamityMod.DownedBossSystem.downedAstrumAureus, ModContent.NPCType<CalamityMod.NPCs.AstrumAureus.AstrumAureus>());

            BossExclam(npc, new int[] { NPCID.PartyGirl }, CalamityMod.DownedBossSystem.downedPolterghast, ModContent.NPCType<CalamityMod.NPCs.Polterghast.Polterghast>());

            if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Crabulon.CrabShroom>() && Main.LocalPlayer.HasItem(ModContent.ItemType<PutridShroom>()) && NPC.AnyNPCs(ModContent.NPCType<CalamityMod.NPCs.Crabulon.Crabulon>()))
            {
                NPC.NewNPC(npc.GetSource_Death(), (int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Swearshroom>());
            }

            if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Signus.Signus>() && junkoReference)
            {
                Item.NewItem(npc.GetSource_FromAI(), npc.Hitbox, ModContent.ItemType<SuspiciousLookingChineseCrown>());
            }

            if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Yharon.Yharon>() && wolfram)
            {
                Item.NewItem(npc.GetSource_FromAI(), npc.Hitbox, ModContent.ItemType<RoverSpindle>());
            }

            if (npc.type == ModContent.NPCType<CalamityMod.NPCs.AstrumAureus.AstrumAureus>() && geldonSummon)
            {
                Item.NewItem(npc.GetSource_FromAI(), npc.Hitbox, ModContent.ItemType<SpaceJunk>());
            }

            if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Bumblebirb.Bumblefuck>() && bdogeMount)
            {
                Item.NewItem(npc.GetSource_FromAI(), npc.Hitbox, ModContent.ItemType<ExtraFluffyFeatherClump>());
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
            if (Main.LocalPlayer.InModBiome(ModContent.GetInstance<Biomes.AstralBlight>()) || Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().Blok)
            {
                //DEUS HEAD
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.AstrumDeus.AstrumDeusHead>())
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
                else if (npc.type == ModContent.NPCType<CalamityMod.NPCs.AstrumDeus.AstrumDeusBody>())
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
                else if (npc.type == ModContent.NPCType<CalamityMod.NPCs.AstrumDeus.AstrumDeusTail>())
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
            if (npc.type == ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodCore>() && CalValEX.AprilFoolDay)
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
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.AstrumDeus.AstrumDeusHead>())
                {
                    Texture2D deusheadsprite2 = (ModContent.Request<Texture2D>("CalValEX/NPCs/AstrumDeus/DeusHeadOld_Glow").Value);

                    float deusheadframe2 = 1f / (float)Main.npcFrameCount[npc.type];
                    int deusheadheight2 = (int)((float)(npc.frame.Y / npc.frame.Height) * deusheadframe2) * (deusheadsprite2.Height / 1);

                    Rectangle deusheadsquare2 = new Rectangle(0, deusheadheight2, deusheadsprite2.Width, deusheadsprite2.Height / 1);
                    spriteBatch.Draw(deusheadsprite2, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusheadsquare2, Color.White, npc.rotation, Utils.Size(deusheadsquare2) / 2f, npc.scale, SpriteEffects.None, 0f);
                }

                //DEUS BODY
                else if (npc.type == ModContent.NPCType<CalamityMod.NPCs.AstrumDeus.AstrumDeusBody>())
                {
                    Texture2D deusbodsprite2 = npc.localAI[3] == 1f ? ModContent.Request<Texture2D>("CalValEX/NPCs/AstrumDeus/DeusBodyAltOld_Glow").Value : ModContent.Request<Texture2D>("CalValEX/NPCs/AstrumDeus/DeusBodyOld_Glow").Value;

                    float deusbodframe2 = 1f / (float)Main.npcFrameCount[npc.type];
                    int deusbodheight2 = (int)((float)(npc.frame.Y / npc.frame.Height) * deusbodframe2) * (deusbodsprite2.Height / 1);

                    Rectangle deusbodsquare2 = new Rectangle(0, deusbodheight2, deusbodsprite2.Width, deusbodsprite2.Height / 1);
                    spriteBatch.Draw(deusbodsprite2, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusbodsquare2, Color.White, npc.rotation, Utils.Size(deusbodsquare2) / 2f, npc.scale, SpriteEffects.None, 0f);
                }

                //DEUS TAIL
                else if (npc.type == ModContent.NPCType<CalamityMod.NPCs.AstrumDeus.AstrumDeusTail>())
                {
                    Texture2D deustailsprite2 = (ModContent.Request<Texture2D>("CalValEX/NPCs/AstrumDeus/DeusTailOld_Glow").Value);

                    float deustailframe2 = 1f / (float)Main.npcFrameCount[npc.type];
                    int deustailheight2 = (int)((float)(npc.frame.Y / npc.frame.Height) * deustailframe2) * (deustailsprite2.Height / 1);

                    Rectangle deustailsquare2 = new Rectangle(0, deustailheight2, deustailsprite2.Width, deustailsprite2.Height / 1);
                    spriteBatch.Draw(deustailsprite2, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deustailsquare2, Color.White, npc.rotation, Utils.Size(deustailsquare2) / 2f, npc.scale, SpriteEffects.None, 0f);
                }
            }
        }

        //Disable Astral Blight overworld spawns
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo LocalPlayer)
        {
            Player player = LocalPlayer.Player;
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            CalamityMod.CalPlayer.CalamityPlayer calp = player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();
            bool noevents = !CalamityMod.Events.AcidRainEvent.AcidRainEventIsOngoing && !Main.eclipse && !Main.snowMoon && !Main.pumpkinMoon && Main.invasionType == 0 && !player.ZoneTowerSolar && !player.ZoneTowerStardust && !player.ZoneTowerVortex & !player.ZoneTowerNebula && !player.ZoneOldOneArmy;
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
