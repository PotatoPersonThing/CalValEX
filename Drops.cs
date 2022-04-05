<<<<<<< Updated upstream
//using CalamityMod.World;
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
//using CalValEX.Items.LightPets;
using CalValEX.Items.Mounts;
using CalValEX.Items.Mounts.InfiniteFlight;
using CalValEX.Items.Mounts.Ground;
using CalValEX.Items.Mounts.LimitedFlight;
using CalValEX.Items.Mounts.Morshu;
using CalValEX.Items.Pets;
//using CalValEX.Items.Pets.Scuttlers;
//using CalValEX.Items.Pets.Elementals;
using CalValEX.Items.Tiles;
using CalValEX.Items.Tiles.Balloons;
using CalValEX.Items.Tiles.Blocks;
using CalValEX.Items.Tiles.Plushies;
using CalValEX.NPCs.Critters;
//using CalValEX.Items.Tiles.Monoliths;
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

        //public override void SetupShop(int type, Chest shop, ref int nextSlot)
        //{

        /*Mod alchLite =
            ModLoader.GetMod(
                "AlchemistNPCLite");
        if (alchLite != null)
        {
            if (type == alchLite.NPCType("Musician"))
            {
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstralMusicBox>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 10);
                    ++nextSlot;
                }
            }
        }
        Mod alchFull =
            ModLoader.GetMod(
                "AlchemistNPC");
        if (alchFull != null)
        {
            if (type == alchFull.NPCType("Musician"))
            {
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstralMusicBox>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 10);
                    ++nextSlot;
                }
            }
        }
        Mod clamMod =
            ModLoader.GetMod(
                "CalamityMod");
        if (clamMod != null)
        {
            if (type == clamMod.NPCType("SEAHOE"))
            {
                if ((bool)clamMod.Call("GetInZone", Main.player[Main.myPlayer], "sunkensea"))
                {
                    if ((bool)clamMod.Call("GetBossDowned", "oldduke"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<BloodwormScarf>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 50);
                        ++nextSlot;
                    }

                    if ((bool)clamMod.Call("GetBossDowned", "supremecalamitas"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Yharlamitas>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(42);
                        ++nextSlot;
                    }
                }

                if (!(bool)clamMod.Call("GetInZone", Main.player[Main.myPlayer], "sunkensea"))
                {
                    if ((bool)clamMod.Call("GetBossDowned", "oldduke"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<BloodwormScarf>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(15);
                        ++nextSlot;
                    }

                    if ((bool)clamMod.Call("GetBossDowned", "supremecalamitas"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Yharlamitas>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(420);
                        ++nextSlot;
                    }
                }
            }

            if (type == clamMod.NPCType("DILF")) //Permafrost
            {/*
                if (Main.rand.Next(9999) == 0)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<CalamitasFumo>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 99, 99);
                    ++nextSlot;
                }*/
        /*if ((bool)clamMod.Call("GetBossDowned", "cryogen"))
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<FrostflakeBrick>());
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 10);
            ++nextSlot;
        }
        if ((bool)clamMod.Call("GetBossDowned", "signus"))
        {
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Signut>());
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(15);
            ++nextSlot;
        }
    }

    if (type == clamMod.NPCType("THIEF"))
    {
        if ((bool)clamMod.Call("GetBossDowned", "astrumaureus"))
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

    if (type == clamMod.NPCType("FAP"))
    {
        shop.item[nextSlot].SetDefaults(ModContent.ItemType<OddMushroomPot>());
        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 30);
        ++nextSlot;
    }

    if (type == NPCID.Clothier)
    {
        int bandit = NPC.FindFirstNPC(clamMod.NPCType("THIEF"));
        int archmage = NPC.FindFirstNPC(clamMod.NPCType("DILF"));
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

        if (Main.LocalPlayer.ZoneDungeon || Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneMockDungeon)
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
    }*/

        /*if (type == NPCID.Dryad && Main.hardMode)
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

            if (CalamityMod.World.CalamityWorld.downedPolterghast)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<ChaoticPuffball>());
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1);
                ++nextSlot;
            }
        }
    }
}*/

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (!CalValEXConfig.Instance.DisableVanityDrops)
            {
                if (npc.type == NPCID.Wizard)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Permascarf>(), 1));
                }
                if (npc.type == NPCID.Steampunker)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BanditHat>(), 1));
                }
                if (npc.type == NPCID.GreenJellyfish)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BoxBalloon>(), 10));
                }
                if (npc.type == NPCID.IceTortoise)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PrismShell>(), 10));
                }
                if (npc.type == NPCID.Lavabat)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ScryllianWings>(), 20));
                }
                if (npc.type == NPCID.Gnome)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WulfrumKeys>(), 10));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WulfrumHelipack>(), 20));
                }
                if (npc.type == NPCID.GreenSlime)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WulfrumBalloon>(), 100));
                }
                if (npc.type == NPCID.GraniteFlyer)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CosmicCone>(), 20));
                }
                if (npc.type == NPCID.MartianSaucer)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ShuttleBalloon>(), 5));
                }
                if (npc.type == NPCID.Slimer2)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AeroWings>(), 20));
                }
                if (npc.type == NPCID.Shark)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FloatyCarpetItem>(), 20));
                }
                if (npc.type == NPCID.Squid)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Help>(), 20));
                }
                if (npc.type == NPCID.SeaSnail)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TrilobiteShield>(), 10));
                }
                if (npc.type == NPCID.DukeFishron)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<NuclearFumes>(), 1, 20, 45));
                }
                if (npc.type == NPCID.Crab)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FlakHeadCrab>(), 20));
                }
                if (npc.type == NPCID.JungleSlime)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PerennialFlower>(), 20));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PerennialDress>(), 20));
                }
                if (npc.type == NPCID.SpikedJungleSlime)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientPerennialFlower>(), 30));
                }
                if (npc.type == NPCID.PinkJellyfish)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CoralMask>(), 25));
                }
                if (npc.type == NPCID.IceGolem)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Cryocap>(), 10));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Cryocoat>(), 10));
                }
                if (npc.type == NPCID.HellArmoredBones)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CultistHood>(), 30));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CultistRobe>(), 30));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CultistLegs>(), 30));
                }
                if (npc.type == NPCID.GiantCursedSkull)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<UnloadedHelm>(), 20));
                }
                if (npc.type == NPCID.RedDevil)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DevilfishMask1>(), 20));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DevilfishMask2>(), 20));
                }
                if (npc.type == NPCID.BloodSquid)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Mirballoon>(), 10));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OldMirage>(), 20));
                }
                if (npc.type == NPCID.GiantFlyingFox)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HadarianTail>(), 20));
                }
                if (npc.type == NPCID.BlueArmoredBones)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EidoMask>(), 30));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Eidcape>(), 30));
                }
                if (npc.type == NPCID.SolarCrawltipedeHead)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedEnergyHook>(), 20));
                }
                if (npc.type == NPCID.FireImp)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedBalloon>(), 20));
                }
                if (npc.type == NPCID.Demon)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ScornEaterMask>(), 20));
                }
                if (npc.type == NPCID.BloodNautilus)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChaosBalloon>(), 5));
                }
                if (npc.type == NPCID.Shark)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ReaperSharkArms>(), 40));
                }
                if (npc.type == NPCID.Shark)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OmegaBlue>(), 100));
                }
                if (npc.type == NPCID.StardustJellyfishBig)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SquidHat>(), 20));
                }
                if (npc.type == NPCID.RockGolem)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EarthShield>(), 20));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EarthenHelmet>(), 30));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EarthenBreastplate>(), 30));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EarthenLeggings>(), 30));
                }
                if (npc.type == NPCID.Crab)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ClamMask>(), 20));
                }
                if (npc.type == NPCID.MossHornet)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlaugeWings>(), 20));
                }
                if (npc.type == NPCID.MoonLordCore)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientAuricTeslaHelm>(), 50));
                }
                if (npc.type == NPCID.AngryTrapper)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MawHook>(), 20));
                }
                if (npc.type == NPCID.WyvernHead)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CloudWaistbelt>(), 20));
                }
                if (npc.type == NPCID.SandElemental)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SandyBangles>(), 20));
                }
                //Scourge
                if (npc.type == NPCID.TombCrawlerHead)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<DesertMedallion>(), 20));
                }
                //Perfs
                if (npc.type == NPCID.LittleCrimera)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SmallWorm>(), 20));
                }
                if (npc.type == NPCID.Crimera)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<MidWorm>(), 20));
                }
                if (npc.type == NPCID.BigCrimera)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BigWorm>(), 20));
                }
                //Slime Gods
                if (npc.type == NPCID.QueenSlimeBoss)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SlimeGodMask>(), 7));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<GoozmaPetItem>(), 30));
                }
                //Brimmy
                if (npc.type == NPCID.WallofFlesh)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BrimmySpirit>(), 10));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BrimmyBody>(), 10));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<FoilSpoon>(), 20));
                }
                //Clone
                if (npc.type == NPCID.Retinazer)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<Calacirclet>(), 5));
                }
                //Levihita
                if (npc.type == NPCID.DukeFishron)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<Items.Tiles.Monoliths.AquaticMonolith>(), 10));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<FoilAtlantis>(), 20));
                }
                //Astrum Aureus
                if (npc.type == NPCID.QueenSlimeBoss)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<AureusShield>(), 5));
                }
                //PBG
                if (npc.type == NPCID.Plantera)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<InfectedController>(), 5));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<PlaguePack>(), 5));
                }
                //Ravager
                if (npc.type == NPCID.Golem)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SkullBalloon>(), 5));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<StonePile>(), 5));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ScavaHook>(), 15));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<RavaHook>(), 10));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<Necrostone>(), 1, 100, 300));
                }
                //Deus
                if (npc.type == NPCID.WyvernHead)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<AstBandana>(), 20));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<AstrumDeusMask>(), 40));
                }
                //Bumblebirb
                if (npc.type == NPCID.DD2Betsy)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<Birbhat>(), 2));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SparrowMeat>(), 20));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<FollyWings>(), 10));
                }
                //Providence
                if (npc.type == NPCID.HallowBoss)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ProviCrystal>(), 20));
                }
                //Storm Weaver
                if (npc.type == NPCID.TheDestroyer)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<StormBandana>(), 10));
                }
                //Signus
                if (npc.type == NPCID.Wraith)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SignusBalloon>(), 30));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SigCape>(), 30));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SignusNether>(), 30));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SignusEmblem>(), 30));
                }
                //CV
                if (npc.type == NPCID.GiantCursedSkull)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<VoidWings>(), 20));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<OldVoidWings>(), 20));
                }
                //Polterghast
                if (npc.type == NPCID.DungeonSpirit)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<Polterhook>(), 20));
                }
                //Old Duke
                if (npc.type == NPCID.GiantCursedSkull)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<OldWings>(), 20));
                }
                //DoG
                if (npc.type == NPCID.TheDestroyer)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CosmicWormScarf>(), 5));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<RapturedWormScarf>(), 20));
                }
                //Yharon
                if (npc.type == NPCID.DD2Betsy)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<YharonShackle>(), 3));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<JunglePhoenixWings>(), 5));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<YharonsAnklet>(), 10));
                }
                //Supreme Cal
                if (npc.type == NPCID.Retinazer)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<GruelingMask>(), 3));
                }
                //Ares
                if (npc.type == NPCID.SkeletronPrime)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<Items.Equips.Shirts.AresChestplate.AresChestplate>(), 3));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<DraedonBody>(), 5));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<DraedonLegs>(), 5));
                }
                //Thanatos
                if (npc.type == NPCID.TheDestroyer)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<XMLightningHook>(), 5));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<DraedonBody>(), 5));
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<DraedonLegs>(), 5));
                }
                //Apollo
                if (npc.type == NPCID.Spazmatism)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ApolloBalloonSmall>(), 3));
                }
                //Artemis
                if (npc.type == NPCID.Retinazer)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ArtemisBalloonSmall>(), 3));
                }
                //Wyrm
                if (npc.type == NPCID.DungeonGuardian)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Tiles.RespirationShrine>(), 1));
                }
                //Donuts
                if (npc.type == NPCID.SolarCorite)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedFrame>(), 15));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedBattery>(), 15));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ProfanedWheels>(), 15));
                }
                //Yharon 2 idk idk
                if (npc.type == NPCID.MoonLordCore)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<Termipebbles>(), 1, 3, 8));
                }
            }
        }
        /*public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback,
            ref bool crit, ref int hitDirection)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (npc.type == calamityMod.NPCType("AstrumAureus"))
            {
                if (projectile.type == calamityMod.ProjectileType("AstrageldonSummon") || projectile.type == calamityMod.ProjectileType("AstrageldonLaser"))
                {
                    geldonSummon = true;
                }
                else
                {
                    geldonSummon = false;
                }
            }
            else if (npc.type == calamityMod.NPCType("Bumblefuck"))
            {
                if (projectile.type == calamityMod.ProjectileType("Minibirb") && !projectile.ranged)
                {
                    bdogeMount = true;
                }
                else
                {
                    bdogeMount = false;
                }
            }
            else if (npc.type == calamityMod.NPCType("Yharon"))
            {
                if (projectile.type == calamityMod.ProjectileType("WulfrumBoltMinion") || projectile.type == calamityMod.ProjectileType("WulfrumDroid"))
                {
                    wolfram = true;
                }
                else
                {
                    wolfram = false;
                }
            }
            else if (npc.type == calamityMod.NPCType("Signus"))
            {
                if (projectile.type == calamityMod.ProjectileType("PristineFire") ||
                    projectile.type == calamityMod.ProjectileType("PristineSecondary"))
                {
                    junkoReference = true;
                }
                else
                {
                    junkoReference = false;
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
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (npc.type == calamityMod.NPCType("WITCH") && (!CalValEXWorld.jharinter || !NPC.downedMoonlord))
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
                    Projectile.NewProjectile(position, direction * speed, type, damage, 0f, Main.myPlayer);
                    calashoot = 0;
                }
            }
            if (npc.type == calamityMod.NPCType("Signus"))
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
                        npc.StrikeNPC(499999, 99f, npc.direction  * 50, true, false, false);
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
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (npc.type == calamityMod.NPCType("Signus") && !signusbackup && Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().junsi && Main.netMode != NetmodeID.Server)
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

        public override void NPCLoot(NPC npc)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
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
                                    Item.NewItem(npc.Hitbox, ItemID.PlatinumCoin, platCoins);
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
                                    Item.NewItem(npc.Hitbox, ItemID.GoldCoin, goldCoins);
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
                                    Item.NewItem(npc.Hitbox, ItemID.SilverCoin, silverCoins);
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
                                Item.NewItem(npc.Hitbox, ItemID.CopperCoin, copperCoins);
                            }

                            droppedMoney++;
                        }
                    }
                }
            }

            //5%
            float normalChance = normalEnemyChance;
            //10%
            float rareChance = rareEnemyChance;
            //1%
            float mountChance = 0.01f;
            Mod catalyst = ModLoader.GetMod("CatalystMod");
            if (npc.boss)
            {
                Player player = Main.LocalPlayer;
                CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
                modPlayer.bossded = 480;
            }
            if (!CalValEXConfig.Instance.DisableVanityDrops)
            {
                if (npc.type == calamityMod.NPCType("DILF"))
                {
                    DropItem(npc, ModContent.ItemType<Permascarf>()); //garanteed
                }

                if (npc.type == calamityMod.NPCType("THIEF"))
                {
                    DropItem(npc, ModContent.ItemType<BanditHat>()); //garanteed
                }

                // Swearshrooms
                if (npc.type == calamityMod.NPCType("CrabShroom"))
                {
                    if (!NPC.AnyNPCs(calamityMod.NPCType("CrabulonIdle")))
                    {
                        if (Main.LocalPlayer.HasItem(ModContent.ItemType<PutridShroom>()))
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Swearshroom>());
                        }
                    }
                }

                //Prehm
                if (npc.type == calamityMod.NPCType("AngryDog"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<TundraBall>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("Rotdog"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<OldTennisBall>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("BoxJellyfish"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<BoxBalloon>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("Catfish"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<DiscardedCollar>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("RepairUnitCritter"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<DisrepairUnit>(), bossPetChance); //Change to normalChance in 1.5.4
                }

                if (npc.type == calamityMod.NPCType("PrismTurtle"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<PrismShell>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("Scryllar"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ScryllianWings>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("ScryllarRage"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ScryllianWings>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("DespairStone"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<Drock>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("Trasher"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<OlTrashtooth>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("WulfrumRover"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<WulfrumKeys>(), mountChance);
                    ChanceDropItem(npc, ModContent.ItemType<WulfrumController>(), 0.02f);
                    ChanceDropItem(npc, ModContent.ItemType<RoverSpindle>(), 0.02f);
                }

                if (npc.type == calamityMod.NPCType("WulfrumDrone"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<WulfrumController>(), 0.02f);
                }

                if (npc.type == calamityMod.NPCType("WulfrumHovercraft"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<WulfrumController>(), 0.02f);
                }

                if (npc.type == calamityMod.NPCType("WulfrumGyrator"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<WulfrumController>(), 0.02f);
                    ChanceDropItem(npc, ModContent.ItemType<WulfrumBalloon>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("WulfrumPylon"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<PylonRemote>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CosmicElemental"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<CosmicCone>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("Sunskater"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<SkeetCrest>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("ShockstormShuttle"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ShuttleBalloon>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("AeroSlime"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<AeroWings>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("SeaFloaty"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<FloatyCarpetItem>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("SuperDummyNPC"))
                {
                    ConditionalDropItem(npc, ModContent.ItemType<DummyMask>(),
                        Main.LocalPlayer.HeldItem.type != calamityMod.ItemType("SuperDummy"));
                }

                //Crawlers
                if (npc.type == calamityMod.NPCType("CrawlerAmethyst"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<AmethystStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerTopaz"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<TopazStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerSapphire"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<SapphireStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerEmerald"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<EmeraldStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerRuby"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<RubyStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerDiamond"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<DiamondStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerCrystal"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<CrystalStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerAmber"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<AmberStone>(), rareChance);
                }

                //end of crawler drops and prehm
                //Acid rain set tier 2
                if (npc.type == calamityMod.NPCType("SulfurousSkater"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<SkaterEgg>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("Orthocera"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<Help>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("FlakCrab"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<FlakHeadCrab>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("Trilobite"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<TrilobiteShield>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("GammaSlime"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<GammaHelmet>(), vanityMinChance);
                    ChanceDropItem(npc, ModContent.ItemType<NuclearFumes>(), 0.3f); //30%
                }

                //Hardmode drops
                if (npc.type == calamityMod.NPCType("PerennialSlime"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<PerennialFlower>(), vanityNormalChance);
                    ChanceDropItem(npc, ModContent.ItemType<PerennialDress>(), vanityNormalChance);
                    ChanceDropItem(npc, ModContent.ItemType<PerennialFlower>(), RIVChance);
                }

                if (npc.type == calamityMod.NPCType("Bohldohr"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<BoldEgg>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("BelchingCoral"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<CoralMask>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("AnthozoanCrab"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<CrackedFossil>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("IceClasper"))
                {
                    //ChanceDropItem(npc, ModContent.ItemType<AntarcticEssence>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("Cryon"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<Cryocap>(), vanityNormalChance);
                    ChanceDropItem(npc, ModContent.ItemType<Cryocoat>(), vanityNormalChance);
                }

                if (npc.type == calamityMod.NPCType("SmallSightseer"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<Binoculars>(),
                        (bool)calamityMod.Call("GetBossDowned", "astrumaureus"), 0.05f); //5%
                }

                if (npc.type == calamityMod.NPCType("BigSightseer"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<Binoculars>(),
                        (bool)calamityMod.Call("GetBossDowned", "astrumaureus"), 0.1f); //10%
                }

                if (npc.type == calamityMod.NPCType("CultistAssassin"))
                {
                    if (Main.rand.NextFloat() < 0.05f)
                    {
                        DropItem(npc, ModContent.ItemType<CultistRobe>());
                        DropItem(npc, ModContent.ItemType<CultistHood>());
                        DropItem(npc, ModContent.ItemType<CultistLegs>());
                    }
                }

                if (npc.type == calamityMod.NPCType("HeatSpirit"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ChaosEssence>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("OverloadedSoldier"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<UnloadedHelm>(), vanityMaxChance);
                    ChanceDropItem(npc, ModContent.ItemType<HauntedPebble>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("PhantomDebris"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<HauntedPebble>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("DevilFishAlt"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<DevilfishMask1>(), vanityNormalChance);
                }

                if (npc.type == calamityMod.NPCType("DevilFish"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<DevilfishMask2>(), vanityNormalChance);
                }

                if (npc.type == calamityMod.NPCType("MirageJelly"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<Mirballoon>(), vanityNormalChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<OldMirage>(), NPC.downedGolemBoss, 0.01f); //1%
                }

                if (npc.type == calamityMod.NPCType("Hadarian"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<HadarianTail>(),
                        (bool)calamityMod.Call("GetBossDowned", "astrumaureus"), 0.05f); //5%
                }

                if (npc.type == calamityMod.NPCType("Eidolist"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<EidoMask>(), vanityNormalChance);
                    ChanceDropItem(npc, ModContent.ItemType<Eidcape>(), vanityNormalChance);
                }

                //Profaned enemies
                if (npc.type == calamityMod.NPCType("ProfanedEnergyBody"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ProfanedEnergyHook>(), bossHookChance);
                    ChanceDropItem(npc, ModContent.ItemType<ProfanedBalloon>(),
                        normalChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ChewyToy>(),
                        (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.01f); //1%
                }

                if (npc.type == calamityMod.NPCType("ScornEater"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ScornEaterMask>(), normalChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ChewyToy>(),
                        (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.01f); //1%
                }

                if (npc.type == calamityMod.NPCType("ImpiousImmolator"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<HolyTorch>(), 0.05f); //10%
                    ChanceDropItem(npc, ModContent.ItemType<ProfanedBalloon>(), normalChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ChewyToy>(),
                        (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.01f); //1%
                }

                //Post-ml misc
                if (npc.type == mod.NPCType("ShockstormShuttle"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<Items.Equips.ExodiumMoon>(), NPC.downedMoonlord, vanityNormalChance);
                }
                if (npc.type == calamityMod.NPCType("ChaoticPuffer"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ChaosBalloon>(), vanityNormalChance);
                }

                //Minibosses
                if (npc.type == calamityMod.NPCType("NuclearTerror"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<RadJuice>(), minibossChance);
                    ChanceDropItem(npc, ModContent.ItemType<TerrorLegs>(), minibossChance);
                    DropItem(npc, ModContent.ItemType<NuclearFumes>(), 3, 5); //garanteed 3 to 5
                    ConditionalDropItem(npc, ModContent.ItemType<NuclearFumes>(), Main.expertMode, 1,
                        3); //when expert mode you get 1 to 3
                    ChanceDropItem(npc, ModContent.ItemType<NuclearFumes>(), 0.5f); //50% chance to get 1 extra
                    ChanceDropItem(npc, ModContent.ItemType<NuclearFumes>(), 0.3f); //30% chance to get 1 extra
                }

                if (npc.type == calamityMod.NPCType("Cnidrion"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<DryShrimp>(), minibossChance);
                }

                if (npc.type == calamityMod.NPCType("WildBumblefuck"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<OrbSummon>(), minibossChance);
                }

                if (npc.type == calamityMod.NPCType("Reaper"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ReaperoidPills>(), minibossChance);
                    ChanceDropItem(npc, ModContent.ItemType<ReaperSharkArms>(), minibossChance);
                    ChanceDropItem(npc, ModContent.ItemType<OmegaBlue>(), 0.05f);
                }

                if (npc.type == calamityMod.NPCType("ColossalSquid"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<SquidHat>(), minibossChance);
                    ChanceDropItem(npc, ModContent.ItemType<OmegaBlue>(), 0.05f);
                }

                if (npc.type == calamityMod.NPCType("EidolonWyrmHead"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<EWail>(), minibossChance);
                    ChanceDropItem(npc, ModContent.ItemType<OmegaBlue>(), 0.05f);
                }

                if (npc.type == calamityMod.NPCType("Horse"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<EarthShield>(), minibossChance);
                    if (Main.rand.NextFloat() < 0.1f)
                    {
                        DropItem(npc, ModContent.ItemType<EarthenHelmet>());
                        DropItem(npc, ModContent.ItemType<EarthenBreastplate>());
                        DropItem(npc, ModContent.ItemType<EarthenLeggings>());
                    }
                }

                if (npc.type == calamityMod.NPCType("GiantClam"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ClamHermitMedallion>(), minibossChance);
                    ChanceDropItem(npc, ModContent.ItemType<ClamMask>(), vanityMaxChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<GiantClamPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance") && Main.hardMode, bossPetChance);
                }

                if (npc.type == NPCID.SandElemental)
                {
                    ChanceDropItem(npc, ModContent.ItemType<SandBottle>(), normalChance);
                    ChanceDropItem(npc, ModContent.ItemType<SandPlush>(), normalChance);
                    ChanceDropItem(npc, ModContent.ItemType<SandyBangles>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("PlaguebringerShade"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<BeeCan>(), 0.1f);
                    ChanceDropItem(npc, ModContent.ItemType<PlaugeWings>(), 0.1f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AncientAuricTeslaHelm>(), Main.expertMode,
                        0.0012f);
                }

                if (npc.type == calamityMod.NPCType("ArmoredDiggerHead"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AncientAuricTeslaHelm>(), Main.expertMode,
                        0.0012f);
                }

                if (npc.type == calamityMod.NPCType("CragmawMire"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<MawHook>(),
                        (bool)calamityMod.Call("GetBossDowned", "polterghast"), 0.1f); //10%
                    ConditionalChanceDropItem(npc, ModContent.ItemType<NuclearFumes>(),
                            (bool)calamityMod.Call("GetBossDowned", "polterghast"), 0.3f, 1, 3);
                }
                if (npc.type == calamityMod.NPCType("ThiccWaifu"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<cloudcandy>(), 0.1f);
                    ChanceDropItem(npc, ModContent.ItemType<CloudWaistbelt>(), 0.1f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<FogG>(), ((bool)calamityMod.Call("GetBossDowned", "supremecalamitas") && (bool)calamityMod.Call("GetBossDowned", "exomechs")), 0.0001f);
                }

                if (npc.type == calamityMod.NPCType("Mauler"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<MaulerMask>(), vanityNormalChance);
                    ChanceDropItem(npc, ModContent.ItemType<BubbledFin>(), minibossChance);
                    DropItem(npc, ModContent.ItemType<NuclearFumes>(), 3, 5); //garanteed 3 to 5
                    ConditionalDropItem(npc, ModContent.ItemType<NuclearFumes>(), Main.expertMode, 1,
                        3); //when expert mode you get 1 to 3
                    ChanceDropItem(npc, ModContent.ItemType<NuclearFumes>(), 0.5f); //50% chance to get 1 extra
                    ChanceDropItem(npc, ModContent.ItemType<NuclearFumes>(), 0.3f); //30% chance to get 1 extra
                }

                //Bosses
                if (npc.type == calamityMod.NPCType("DesertScourgeHead"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<DesertMedallion>(), !Main.expertMode, 0.2f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<DriedMandible>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<DesertScourgePlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("CrabulonIdle"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ClawShroom>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<CrabulonPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("PerforatorHive"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<DigestedWormFood>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<PerforatorPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("HiveMind"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<MissingFang>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<HiveMindPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("PerforatorHeadSmall"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<SmallWorm>(), !Main.expertMode, 0.2f);
                }

                if (npc.type == calamityMod.NPCType("PerforatorHeadMedium"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<MidWorm>(), !Main.expertMode, 0.2f);
                }

                if (npc.type == calamityMod.NPCType("PerforatorHeadLarge"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<BigWorm>(), !Main.expertMode, 0.2f);
                }

                if (npc.type == calamityMod.NPCType("SlimeGodCore") && !NPC.AnyNPCs(calamityMod.NPCType("SlimeGodSplit")) && !NPC.AnyNPCs(calamityMod.NPCType("SlimeGodRunSplit")))
                {
                    if (Main.rand.Next(7) == 0)
                    {
                        DropItem(npc, ModContent.ItemType<SlimeGodMask>());
                    }
                    if (!CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("StatigelBlock"),
                            !Main.expertMode, 155, 265);
                    }

                    ConditionalChanceDropItem(npc, ModContent.ItemType<ImpureStick>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(),
                        (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.01f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<SlimeGodPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("SlimeGodSplit") && !NPC.AnyNPCs(calamityMod.NPCType("SlimeGodCore")) && !NPC.AnyNPCs(calamityMod.NPCType("SlimeGodRunSplit")) && NPC.CountNPCS(calamityMod.NPCType("SlimeGodSplit")) == 1)
                {
                    if (Main.rand.Next(7) == 0)
                    {
                        DropItem(npc, ModContent.ItemType<SlimeGodMask>());
                    }
                    if (!CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("StatigelBlock"),
                            !Main.expertMode, 155, 265);
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ImpureStick>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(),
                        (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.01f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<SlimeGodPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("SlimeGodRunSplit") && !NPC.AnyNPCs(calamityMod.NPCType("SlimeGodCore")) && !NPC.AnyNPCs(calamityMod.NPCType("SlimeGodSplit")) && NPC.CountNPCS(calamityMod.NPCType("SlimeGodRunSplit")) == 1)
                {
                    if (Main.rand.Next(7) == 0)
                    {
                        DropItem(npc, ModContent.ItemType<SlimeGodMask>());
                    }
                    if (!CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("StatigelBlock"),
                            !Main.expertMode, 155, 265);
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ImpureStick>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(),
                        (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.01f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<SlimeGodPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("Cryogen"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<CryoStick>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<CryogenPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("AquaticScourgeHead"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AquaticHide>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AquaticScourgePlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("BrimstoneElemental"))
                {
                    if (!CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("BrimstoneSlag"),
                            !Main.expertMode, 155, 265);
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<brimtulip>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<BrimmySpirit>(), !Main.expertMode, 0.15f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<BrimmyBody>(), !Main.expertMode, 0.15f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<FoilSpoon>(), !Main.expertMode, 0.035f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<BrimstoneElementalPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("CalamitasRun3"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ClonePlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.2f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<Calacirclet>(), !Main.expertMode, bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("Siren") && !NPC.AnyNPCs(calamityMod.NPCType("Leviathan")))
                {
                    if (!Main.expertMode)
                    {
                        ChanceDropItem(npc, ModContent.ItemType<AquaticMonolith>(), 0.15f);
                        ConditionalChanceDropItem(npc, ModContent.ItemType<FoilAtlantis>(), !Main.expertMode, 0.2f);
                        ConditionalChanceDropItem(npc, ModContent.ItemType<WetBubble>(), !Main.expertMode, 0.02f);
                        ConditionalChanceDropItem(npc, ModContent.ItemType<LeviWings>(), !Main.expertMode, vanityMaxChance); //15%
                        ConditionalChanceDropItem(npc, ModContent.ItemType<LeviathanEgg>(), !Main.expertMode, vanityMaxChance); //15%
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AnahitaPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<LeviathanPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance * 0.1f);
                }

                if (npc.type == calamityMod.NPCType("Leviathan") && !NPC.AnyNPCs(calamityMod.NPCType("Siren")))
                {
                    if (!Main.expertMode)
                    { 
                        ChanceDropItem(npc, ModContent.ItemType<AquaticMonolith>(), 0.15f);
                        ConditionalChanceDropItem(npc, ModContent.ItemType<FoilAtlantis>(), !Main.expertMode, 0.2f);
                        ConditionalChanceDropItem(npc, ModContent.ItemType<WetBubble>(), !Main.expertMode, 0.02f);
                        ConditionalChanceDropItem(npc, ModContent.ItemType<LeviWings>(), !Main.expertMode, vanityMaxChance); //15%
                        ConditionalChanceDropItem(npc, ModContent.ItemType<LeviathanEgg>(), !Main.expertMode, vanityMaxChance); //15%
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<LeviathanPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AnahitaPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance * 0.1f);
                }

                if (npc.type == calamityMod.NPCType("AstrumAureus"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AstDie>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AstrumAureusPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AureusShield>(), !Main.expertMode, 0.2f);
                    if (geldonSummon)
                    {
                        ChanceDropItem(npc, ModContent.ItemType<JellyBottle>(), 1.0f);
                    }
                    else
                    {
                        if (catalyst == null)
                        {
                            ConditionalChanceDropItem(npc, ModContent.ItemType<JellyBottle>(),
                                (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.1f);
                        }
                    }
                }

                if (npc.type == calamityMod.NPCType("PlaguebringerGoliath"))
                {
                    if (!CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("PlaguedPlate"), !Main.expertMode,
                            155, 265);
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<PlaguePack>(), !Main.expertMode, vanityMaxChance); //15%
                    ConditionalChanceDropItem(npc, ModContent.ItemType<InfectedController>(), !Main.expertMode, vanityMaxChance); //15%
                    ConditionalChanceDropItem(npc, ModContent.ItemType<PlaguebringerGoliathPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("RavagerBody"))
                {
                    if (!Main.expertMode)
                    {
                        int choice = Main.rand.Next(3);
                        if (choice == 0)
                        {
                            DropItem(npc, ModContent.ItemType<AncientChoker>());
                        }
                        if (choice == 1)
                        {
                            DropItem(npc, ModContent.ItemType<SkullBalloon>());
                        }
                        else
                        {
                            DropItem(npc, ModContent.ItemType<StonePile>());
                        }
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<RavagerPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<RavaHook>(), !Main.expertMode, vanityMaxChance); //15%
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ScavaHook>(), !Main.expertMode, 0.05f); //15%
                    ConditionalDropItem(npc, ModContent.ItemType<Necrostone>(), !Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks, 155, 265);
                }

                if (npc.type == calamityMod.NPCType("AstrumDeusHeadSpectral") && NPC.CountNPCS(calamityMod.NPCType("AstrumDeusHeadSpectral")) == 1)
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AstralStar>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AstBandana>(), !Main.expertMode, 0.2f);
                    if (Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneAstral || Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().Blok)
                    {
                        DropItem(npc, ModContent.ItemType<AstrumDeusMask>());
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AstrumDeusPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("Bumblefuck"))
                {
                    if (!Main.expertMode)
                    {
                        int choice = Main.rand.Next(3);
                        if (choice == 0)
                        {
                            DropItem(npc, ModContent.ItemType<FollyWing>());
                        }
                        if (choice == 1)
                        {
                            DropItem(npc, ModContent.ItemType<Birbhat>());
                        }
                        else
                        {
                            DropItem(npc, ModContent.ItemType<FollyWings>());
                        }
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<FluffyFeather>(),
                        (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<SparrowMeat>(),
                        (bool)calamityMod.Call("DifficultyActive", "malice"), 0.1f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<BumblefuckPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    if (!Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("SilvaCrystal"),
                            (bool)calamityMod.Call("GetBossDowned", "yharon"), 155, 265);
                    }

                    if (bdogeMount)
                    {
                        ChanceDropItem(npc, ModContent.ItemType<FluffyFur>(), 1.0f);
                    }
                    else
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<FluffyFur>(),
                            (bool)calamityMod.Call("DifficultyActive", "death"), 0.001f);
                    }
                }

                if (npc.type == calamityMod.NPCType("Providence"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ProShard>(), !Main.expertMode, bossPetChance);
                    if (!CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("ProfanedRock"), !Main.expertMode,
                            155, 265);
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ProviCrystal>(), !Main.expertMode, 0.2f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<FlareRune>(), !Main.dayTime, 0.01f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ProvidencePlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("StormWeaverHead") &&
                    CalamityWorld.DoGSecondStageCountdown <= 0)
                {
                    if (Main.rand.Next(3) == 0)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            ConditionalDropItem(npc, ModContent.ItemType<WeaverFlesh>(), !Main.expertMode);
                        }
                        else
                        {
                            ConditionalDropItem(npc, ModContent.ItemType<ShellScrap>(), !Main.expertMode);
                        }
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<StormBandana>(), !Main.expertMode, vanityNormalChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<StormWeaverPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    if (!Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("OccultStone"),
                            (bool)calamityMod.Call("GetBossDowned", "devourerofgods"), 155, 265);
                    }
                }

                if (npc.type == calamityMod.NPCType("Signus") && CalamityWorld.DoGSecondStageCountdown <= 0)
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<SigCloth>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<SignusPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    if (!Main.expertMode)
                    {
                        int choice = Main.rand.Next(4);
                        {
                            if (choice == 0)
                                DropItem(npc, ModContent.ItemType<SignusBalloon>());
                            else if (choice == 1)
                                DropItem(npc, ModContent.ItemType<SigCape>());
                            else if (choice == 2)
                                DropItem(npc, ModContent.ItemType<SignusNether>());
                            else if (choice == 3)
                                DropItem(npc, ModContent.ItemType<SignusEmblem>());
                        }
                    }
                    if (junkoReference)
                    {
                        ChanceDropItem(npc, ModContent.ItemType<JunkoHat>(), 1.0f);
                    }
                    else
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<JunkoHat>(),
                            (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.01f);
                    }

                    if (!Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("OccultStone"),
                            (bool)calamityMod.Call("GetBossDowned", "devourerofgods"), 155, 265);
                    }
                }

                if (npc.type == calamityMod.NPCType("CeaselessVoid") && CalamityWorld.DoGSecondStageCountdown <= 0)
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<VoidShard>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<CeaselessVoidPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<OldVoidWings>(), !Main.expertMode, 0.05f); //5%
                    ConditionalChanceDropItem(npc, ModContent.ItemType<VoidWings>(), !Main.expertMode, vanityMaxChance); //15%
                    if (!Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("OccultStone"),
                            (bool)calamityMod.Call("GetBossDowned", "devourerofgods"), 155, 265);
                    }
                }

                if (npc.type == calamityMod.NPCType("Polterghast"))
                {
                    if (!CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        if (Main.rand.NextFloat() < 0.5f)
                        {
                            ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("StratusBricks"),
                                !Main.expertMode, 155, 265);
                        }
                        else
                        {
                            ConditionalDropItem(npc, ModContent.ItemType<PhantowaxBlock>(), !Main.expertMode, 155, 265);
                        }
                    }

                    ConditionalChanceDropItem(npc, ModContent.ItemType<Polterhook>(), !Main.expertMode, vanityMaxChance); //15%
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ToyScythe>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);

                    if (Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().poltermask && Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().polterchest && Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().polterthigh)
                    {
                        DropItem(npc, ModContent.ItemType<ToyScythe>());
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<PolterghastPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("OldDuke"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<CorrodedCleaver>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<OldWings>(), !Main.expertMode, vanityMaxChance); //15%
                    ConditionalChanceDropItem(npc, ModContent.ItemType<OldDukePlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("DevourerofGodsHead"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<DogPetItem>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<DevourerofGodsPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<CosmicWormScarf>(), !Main.expertMode, 0.2f);
                    if (NPC.AnyNPCs(calamityMod.NPCType("ProfanedGuardianBoss")) && (bool)calamityMod.Call("DifficultyActive", "death"))
                    {
                        DropItem(npc, ModContent.ItemType<FlareRune>());
                    }
                    else if (NPC.AnyNPCs(calamityMod.NPCType("ProfanedGuardianBoss2")))
                    {
                        DropItem(npc, ModContent.ItemType<FlareRune>());
                    }
                    //(NPC.AnyNPCs(calamityMod.NPCType("DevourerofGods")))
                }

                if (npc.type == calamityMod.NPCType("Yharon"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<NuggetBiscuit>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<YharonShackle>(), !Main.expertMode, 0.2f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<YharonPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    if (!Main.expertMode)
                    {
                        DropItem(npc, ModContent.ItemType<Termipebbles>(), 2, 8);
                    }
                    if (CalValEX.month == 6 && CalValEX.day == 1)
                    {
                        DropItem(npc, ModContent.ItemType<YharonsAnklet>());
                    }
                    if (wolfram)
                    {
                        ChanceDropItem(npc, ModContent.ItemType<RoverSpindle>(), 1.0f);
                    }
                    if (Main.rand.Next(10) == 0 && !Main.expertMode)
                    {
                        DropItem(npc, ModContent.ItemType<DemonshadeHood>());
                        DropItem(npc, ModContent.ItemType<DemonshadeRobe>());
                        DropItem(npc, ModContent.ItemType<DemonshadePants>());
                    }
                }
                //Exo Twin drops
                if (npc.type == calamityMod.NPCType("Apollo") && !NPC.AnyNPCs(calamityMod.NPCType("ThanatosHead")) && !NPC.AnyNPCs(calamityMod.NPCType("AresBody")))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<Items.Pets.ExoMechs.GeminiMarkImplants>(), !Main.expertMode, bossPetChance);
                    if (Main.rand.Next(7) == 0 && !Main.expertMode)
                    {
                        DropItem(npc, ModContent.ItemType<DraedonBody>());
                        DropItem(npc, ModContent.ItemType<DraedonLegs>());
                    }
                    if (Main.rand.Next(3) == 0 && !Main.expertMode)
                    {
                        DropItem(npc, ModContent.ItemType<ApolloBalloonSmall>());
                        DropItem(npc, ModContent.ItemType<ArtemisBalloonSmall>());
                    }
                    if ((bool)calamityMod.Call("DifficultyActive", "revengeance") && Main.rand.Next(2) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ArtemisPlush>(), 1, false, 0, false, false);
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ApolloPlush>(), 1, false, 0, false, false);
                        ConditionalChanceDropItem(npc, ModContent.ItemType<DraedonPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    }
                }
                //Ares drops
                if (npc.type == calamityMod.NPCType("AresBody") && !NPC.AnyNPCs(calamityMod.NPCType("ThanatosHead")) && !NPC.AnyNPCs(calamityMod.NPCType("Apollo")))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<Items.Pets.ExoMechs.OminousCore>(), !Main.expertMode, bossPetChance);
                    if (Main.rand.Next(7) == 0 && !Main.expertMode)
                    {
                        DropItem(npc, ModContent.ItemType<DraedonBody>());
                        DropItem(npc, ModContent.ItemType<DraedonLegs>());
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<Items.Equips.Shirts.AresChestplate.AresChestplate>(), !Main.expertMode, 0.33f);
                    if ((bool)calamityMod.Call("DifficultyActive", "revengeance") && Main.rand.Next(2) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AresPlush>(), 1, false, 0, false, false);
                        ConditionalChanceDropItem(npc, ModContent.ItemType<DraedonPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    }
                }
                //Thanatos drops
                if (npc.type == calamityMod.NPCType("ThanatosHead") && !NPC.AnyNPCs(calamityMod.NPCType("AresBody")) && !NPC.AnyNPCs(calamityMod.NPCType("Apollo")))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<Items.Pets.ExoMechs.GunmetalRemote>(), !Main.expertMode, bossPetChance);
                    if (Main.rand.Next(7) == 0 && !Main.expertMode)
                    {
                        DropItem(npc, ModContent.ItemType<DraedonBody>());
                        DropItem(npc, ModContent.ItemType<DraedonLegs>());
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<XMLightningHook>(), !Main.expertMode, 0.33f); 
                    if ((bool)calamityMod.Call("DifficultyActive", "revengeance") && Main.rand.Next(2) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ThanatosPlush>(), 1, false, 0, false, false);
                        ConditionalChanceDropItem(npc, ModContent.ItemType<DraedonPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    }
                }

                if (npc.type == calamityMod.NPCType("SupremeCalamitas"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<CalamitasFumo>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<GruelingMask>(), !Main.expertMode, 0.2f);
                }

                if (npc.type == calamityMod.NPCType("EidolonWyrmHeadHuge"))
                {
                    DropItem(npc, ModContent.ItemType<SoulShard>());
                    DropItem(npc, ModContent.ItemType<OmegaBlue>());
                    DropItem(npc, ModContent.ItemType<RespirationShrine>());
                    ConditionalChanceDropItem(npc, ModContent.ItemType<JaredPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                //Profaned bike
                if (npc.type == calamityMod.NPCType("ProfanedGuardianBoss3"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ProfanedBattery>(), 0.2f); //20%
                }

                if (npc.type == calamityMod.NPCType("ProfanedGuardianBoss2"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ProfanedWheels>(), 0.2f); //20%
                }

                if (npc.type == calamityMod.NPCType("ProfanedGuardianBoss"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ProfanedGuardianPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    ChanceDropItem(npc, ModContent.ItemType<ProfanedFrame>(), 0.2f); //20%
                }

                //Catalyst support
                if (catalyst != null)
                {
                    if (npc.type == catalyst.NPCType("Astrageldon"))
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<JellyBottle>(), !Main.expertMode, bossPetChance); //10%
                        ConditionalChanceDropItem(npc, ModContent.ItemType<AstrageldonPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    }
                }

                //Goozma slimes
                if ((bool)calamityMod.Call("DifficultyActive", "revengeance"))
                {
                    if (npc.type == NPCID.Grasshopper)
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(), Main.expertMode, 0.00000002f);
                    }
                    if (npc.type == NPCID.GoldGrasshopper)
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(), Main.expertMode, 0.00000003f);
                    }
                    if (npc.type == NPCID.BlueSlime ||
                       npc.type == NPCID.GreenSlime ||
                       npc.type == NPCID.PurpleSlime ||
                       npc.type == NPCID.YellowSlime ||
                       npc.type == NPCID.RedSlime ||
                       npc.type == NPCID.ArmedZombieSlimed ||
                       npc.type == NPCID.BigSlimedZombie ||
                       npc.type == NPCID.SmallSlimedZombie ||
                       npc.type == NPCID.SlimedZombie)
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(), Main.expertMode, 0.00005f);
                    }
                    if (npc.type == NPCID.CorruptSlime ||
                        npc.type == NPCID.Crimslime ||
                        npc.type == NPCID.BigCrimslime ||
                        npc.type == NPCID.LittleCrimslime ||
                        npc.type == NPCID.Slimer2 ||
                        npc.type == NPCID.SandSlime ||
                        npc.type == NPCID.Pinky ||
                        npc.type == NPCID.BlueSlime ||
                        npc.type == NPCID.GreenSlime ||
                        npc.type == NPCID.PurpleSlime ||
                        npc.type == NPCID.YellowSlime ||
                        npc.type == NPCID.RedSlime ||
                        npc.type == NPCID.BlackSlime ||
                        npc.type == NPCID.MotherSlime ||
                        npc.type == NPCID.ToxicSludge ||
                        npc.type == NPCID.RainbowSlime ||
                        npc.type == NPCID.IceSlime ||
                        npc.type == NPCID.SpikedIceSlime ||
                        npc.type == NPCID.JungleSlime ||
                        npc.type == NPCID.SpikedJungleSlime ||
                        npc.type == NPCID.DungeonSlime ||
                        npc.type == NPCID.LavaSlime ||
                        npc.type == NPCID.UmbrellaSlime ||
                        npc.type == NPCID.BunnySlimed ||
                        npc.type == NPCID.SlimeRibbonGreen ||
                        npc.type == NPCID.SlimeRibbonRed ||
                        npc.type == NPCID.SlimeRibbonWhite ||
                        npc.type == NPCID.SlimeRibbonYellow ||
                        npc.type == NPCID.HoppinJack ||
                        npc.type == NPCID.CorruptSlime)
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(), Main.expertMode, 0.0002f);
                    }
                    if (npc.type == calamityMod.NPCType("AeroSlime") || npc.type == calamityMod.NPCType("CryoSlime") ||
                        npc.type == calamityMod.NPCType("PerennialSlime") ||
                        npc.type == calamityMod.NPCType("PlaguedJungleSlime") ||
                        npc.type == calamityMod.NPCType("BloomSlime") ||
                        npc.type == calamityMod.NPCType("IrradiatedSlime") ||
                        npc.type == calamityMod.NPCType("GammaSlime"))
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(), Main.expertMode, 0.001f);
                    }

                    if (npc.type == calamityMod.NPCType("EbonianBlightSlime") ||
                        npc.type == calamityMod.NPCType("CrimulanBlightSlime") ||
                        npc.type == calamityMod.NPCType("AstralSlime") ||
                        npc.type == NPCID.IlluminantSlime ||
                        npc.type == calamityMod.NPCType("CragmawMire"))
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(), Main.expertMode, 0.002f);
                    }

                    if (npc.type == NPCID.KingSlime)
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(), Main.expertMode, 0.005f);
                    }

                    if (catalyst != null)
                    {
                        if (npc.type == catalyst.NPCType("Astrageldon"))
                        {
                            ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(), Main.expertMode, 0.01f);
                        }
                    }    lol   
                }
            }

            //Yharexs' Dev Pet (Calamity BABY)
            if ((bool)calamityMod.Call("DifficultyActive", "death"))
            {
                if (npc.type == calamityMod.NPCType("AstralSlime") && Main.rand.Next(870000) == 0)
                {
                    DropItem(npc, ModContent.ItemType<YharexsLetter>());
                }

                if (npc.type == calamityMod.NPCType("SupremeCalamitas"))
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
                        DropItem(npc, ModContent.ItemType<YharexsLetter>());
                    }
                    else
                    {
                        if (Main.rand.Next(1000) == 0)
                        {
                            DropItem(npc, ModContent.ItemType<YharexsLetter>());
                        }
                    }
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

        public override bool PreNPCLoot(NPC npc)
        {
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedCLAM, ModContent.NPCType<CalamityMod.NPCs.SunkenSea.GiantClam>());
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
            BossExclam(npc, new int[] { ModContent.NPCType<OracleNPC>() }, CalamityWorld.downedYharon, ModContent.NPCType<CalamityMod.NPCs.Yharon.Yharon>());

            BossExclam(npc, new int[] { ModContent.NPCType<CalamityMod.NPCs.TownNPCs.SEAHOE>() }, CalamityWorld.downedBoomerDuke, ModContent.NPCType<CalamityMod.NPCs.OldDuke.OldDuke>());
            BossExclam(npc, new int[] { ModContent.NPCType<CalamityMod.NPCs.TownNPCs.SEAHOE>() }, CalamityWorld.downedSCal, ModContent.NPCType<CalamityMod.NPCs.SupremeCalamitas.SupremeCalamitas>());

            BossExclam(npc, new int[] { ModContent.NPCType<CalamityMod.NPCs.TownNPCs.DILF>() }, CalamityWorld.downedSentinel3, ModContent.NPCType<CalamityMod.NPCs.Signus.Signus>());

            BossExclam(npc, new int[] { ModContent.NPCType<CalamityMod.NPCs.TownNPCs.THIEF>() }, CalamityWorld.downedAstrageldon, ModContent.NPCType<CalamityMod.NPCs.AstrumAureus.AstrumAureus>());

            BossExclam(npc, new int[] { NPCID.PartyGirl }, CalamityWorld.downedPolterghast, ModContent.NPCType<CalamityMod.NPCs.Polterghast.Polterghast>());
            return true;
        }

        private static int DropItem(NPC npc, int itemID, bool dropPerPlayer, int min = 1, int max = 0)
        {
            int numberOfItems;
            if (max <= min)
            {
                numberOfItems = min;
            }
            else
            {
                numberOfItems = Main.rand.Next(min, max + 1);
            }

            if (numberOfItems <= 0)
            {
                return 0;
            }

            if (dropPerPlayer)
            {
                npc.DropItemInstanced(npc.position, npc.Size, itemID, numberOfItems);
            }
            else
            {
                Item.NewItem(npc.Hitbox, itemID, numberOfItems);
            }

            return numberOfItems;
        }

        private static int DropItem(NPC npc, int itemID, int min = 1, int max = 0) =>
            DropItem(npc, itemID, false, min, max);

        public static int ChanceDropItem(NPC npc, int itemID, float chance, bool dropPerPlayer, int min = 1,
            int max = 0)
        {
            if (Main.rand.NextFloat() < chance)
            {
                return DropItem(npc, itemID, dropPerPlayer, min, max);
            }

            return 0;
        }

        public static int ChanceDropItem(NPC npc, int itemID, float chance, int min = 1, int max = 0) =>
            ChanceDropItem(npc, itemID, chance, false, min, max);

        public static int ConditionalDropItem(NPC npc, int itemID, bool condition, bool dropPerPlayer, int min = 1,
            int max = 0)
        {
            if (condition)
            {
                return DropItem(npc, itemID, dropPerPlayer, min, max);
            }

            return 0;
        }

        public static int ConditionalDropItem(NPC npc, int itemID, bool condition, int min = 1, int max = 0) =>
            ConditionalDropItem(npc, itemID, condition, false, min, max);

        public static int ConditionalChanceDropItem(NPC npc, int itemID, bool condition, float chance,
            bool dropPerPlayer, int min = 1, int max = 0)
        {
            if (condition)
            {
                return ChanceDropItem(npc, itemID, chance, dropPerPlayer, min, max);
            }

            return 0;
        }

        public static int ConditionalChanceDropItem(NPC npc, int itemID, bool condition, float chance, int min = 1,
            int max = 0) =>
            ConditionalChanceDropItem(npc, itemID, condition, chance, false, min, max);
        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
        {
            if (Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneAstral || Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().Blok)
            {
                //DEUS HEAD
                if (npc.type == ModLoader.GetMod("CalamityMod").NPCType("AstrumDeusHeadSpectral"))
                {
                    Texture2D deusheadsprite = (ModContent.GetTexture("CalValEX/NPCs/AstrumDeus/DeusHeadOld"));

                    float deusheadframe = 1f / (float)Main.npcFrameCount[npc.type];
                    int deusheadheight = (int)((float)(npc.frame.Y / npc.frame.Height) * deusheadframe) * (deusheadsprite.Height / 1);

                    Rectangle deusheadsquare = new Rectangle(0, deusheadheight, deusheadsprite.Width, deusheadsprite.Height / 1);
                    Color deusheadalpha = npc.GetAlpha(drawColor);
                    spriteBatch.Draw(deusheadsprite, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusheadsquare, deusheadalpha, npc.rotation, Utils.Size(deusheadsquare) / 2f, npc.scale, SpriteEffects.None, 0f);
                    return false;
                }

                //DEUS BODY
                else if (npc.type == ModLoader.GetMod("CalamityMod").NPCType("AstrumDeusBodySpectral"))
                {
                    Texture2D deusbodsprite = npc.localAI[3] == 1f ? ModContent.GetTexture("CalValEX/NPCs/AstrumDeus/DeusBodyAltOld") : ModContent.GetTexture("CalValEX/NPCs/AstrumDeus/DeusBodyOld");

                    float deusbodframe = 1f / (float)Main.npcFrameCount[npc.type];
                    int deusbodheight = (int)((float)(npc.frame.Y / npc.frame.Height) * deusbodframe) * (deusbodsprite.Height / 1);

                    Rectangle deusbodsquare = new Rectangle(0, deusbodheight, deusbodsprite.Width, deusbodsprite.Height / 1);
                    Color deusbodalpha = npc.GetAlpha(drawColor);
                    spriteBatch.Draw(deusbodsprite, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusbodsquare, deusbodalpha, npc.rotation, Utils.Size(deusbodsquare) / 2f, npc.scale, SpriteEffects.None, 0f);
                    return false;
                }

                //DEUS TAIL
                else if (npc.type == ModLoader.GetMod("CalamityMod").NPCType("AstrumDeusTailSpectral"))
                {
                    Texture2D deustailsprite = (ModContent.GetTexture("CalValEX/NPCs/AstrumDeus/DeusTailOld"));

                    float deustailframe = 1f / (float)Main.npcFrameCount[npc.type];
                    int deustailheight = (int)((float)(npc.frame.Y / npc.frame.Height) * deustailframe) * (deustailsprite.Height / 1);

                    Rectangle deustailsquare = new Rectangle(0, deustailheight, deustailsprite.Width, deustailsprite.Height / 1);
                    Color deustailalpha = npc.GetAlpha(drawColor);
                    spriteBatch.Draw(deustailsprite, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deustailsquare, deustailalpha, npc.rotation, Utils.Size(deustailsquare) / 2f, npc.scale, SpriteEffects.None, 0f);
                    return false;
                }
            }
            return true;

        }

        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Color lightColor)
        {
            if (npc.type == ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodCore>() && ((CalValEX.month == 4 && CalValEX.day == 1) || ModLoader.GetMod("CalValPlus") != null))
            {
                Texture2D tidepodgsprite = (ModContent.GetTexture("CalValEX/ExtraTextures/SlimeGod"));

                float tidepodgframe = 1f / (float)Main.npcFrameCount[npc.type];
                int tidepodgheight = (int)((float)(npc.frame.Y / npc.frame.Height) * tidepodgframe) * (tidepodgsprite.Height / 1);

                Rectangle tidepodgsquare = new Rectangle(0, tidepodgheight, tidepodgsprite.Width, tidepodgsprite.Height / 1);
                Color tidepodgalpha = npc.GetAlpha(lightColor);
                spriteBatch.Draw(tidepodgsprite, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), tidepodgsquare, tidepodgalpha, npc.rotation, Utils.Size(tidepodgsquare) / 2f, npc.scale, SpriteEffects.None, 0f);
            }

            else if (Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneAstral || Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().Blok)
            {
                //DEUS HEAD
                if (npc.type == ModLoader.GetMod("CalamityMod").NPCType("AstrumDeusHeadSpectral"))
                {
                    Texture2D deusheadsprite2 = (ModContent.GetTexture("CalValEX/NPCs/AstrumDeus/DeusHeadOld_Glow"));

                    float deusheadframe2 = 1f / (float)Main.npcFrameCount[npc.type];
                    int deusheadheight2 = (int)((float)(npc.frame.Y / npc.frame.Height) * deusheadframe2) * (deusheadsprite2.Height / 1);

                    Rectangle deusheadsquare2 = new Rectangle(0, deusheadheight2, deusheadsprite2.Width, deusheadsprite2.Height / 1);
                    spriteBatch.Draw(deusheadsprite2, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusheadsquare2, Color.White, npc.rotation, Utils.Size(deusheadsquare2) / 2f, npc.scale, SpriteEffects.None, 0f);
                }

                //DEUS BODY
                else if (npc.type == ModLoader.GetMod("CalamityMod").NPCType("AstrumDeusBodySpectral"))
                {
                    Texture2D deusbodsprite2 = npc.localAI[3] == 1f ? ModContent.GetTexture("CalValEX/NPCs/AstrumDeus/DeusBodyAltOld_Glow") : ModContent.GetTexture("CalValEX/NPCs/AstrumDeus/DeusBodyOld_Glow");

                    float deusbodframe2 = 1f / (float)Main.npcFrameCount[npc.type];
                    int deusbodheight2 = (int)((float)(npc.frame.Y / npc.frame.Height) * deusbodframe2) * (deusbodsprite2.Height / 1);

                    Rectangle deusbodsquare2 = new Rectangle(0, deusbodheight2, deusbodsprite2.Width, deusbodsprite2.Height / 1);
                    spriteBatch.Draw(deusbodsprite2, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusbodsquare2, Color.White, npc.rotation, Utils.Size(deusbodsquare2) / 2f, npc.scale, SpriteEffects.None, 0f);
                }

                //DEUS TAIL
                else if (npc.type == ModLoader.GetMod("CalamityMod").NPCType("AstrumDeusTailSpectral"))
                {
                    Texture2D deustailsprite2 = (ModContent.GetTexture("CalValEX/NPCs/AstrumDeus/DeusTailOld_Glow"));

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
            Player player = LocalPlayer.player;
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            CalamityMod.CalPlayer.CalamityPlayer calp = player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();
            bool noevents = !(CalamityWorld.rainingAcid && calp.ZoneSulphur) && !Main.eclipse && !Main.snowMoon && !Main.pumpkinMoon && Main.invasionType == 0 && !player.ZoneTowerSolar && !player.ZoneTowerStardust && !player.ZoneTowerVortex & !player.ZoneTowerNebula && !player.ZoneOldOneArmy;
            Mod cata = ModLoader.GetMod("CatalystMod");
            if (modPlayer.sBun)
            {
                pool.Add(NPCID.Bunny, 0.001f);
            }
            if (modPlayer.ZoneAstral && noevents)
            {
                pool.Clear();
                if (!CalValEXConfig.Instance.CritterSpawns)
                {
                    pool.Add(ModContent.NPCType<NPCs.Critters.Blightolemur>(), 0.1f);
                    pool.Add(ModContent.NPCType<NPCs.Critters.Blinker>(), 0.1f);
                    pool.Add(ModContent.NPCType<NPCs.Critters.AstJR>(), 0.1f);
                    pool.Add(ModContent.NPCType<NPCs.Critters.GAstJR>(), 0.1f);
                }
                if (cata != null)
                {
                    if (player.ZoneOverworldHeight)
                    {
                        if (!player.HasItem(cata.ItemType("AstralCommunicator")))
                        {
                            pool.Add(cata.NPCType("AstrageldonSlime"), 0.002f);
                        }
                        if ((bool)cata.Call("worlddefeats.astrageldon"))
                        {
                            pool.Add(cata.NPCType("ArmoredAstralSlime"), 0.02f);
                        }
                    }
                }

            }
        }*/
    }
=======
using CalamityMod.World;
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
            
            Mod alchLite =
                ModLoader.GetMod(
                    "AlchemistNPCLite");
            if (alchLite != null)
            {
                if (type == alchLite.NPCType("Musician"))
                {
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstralMusicBox>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 10);
                        ++nextSlot;
                    }
                }
            }
            Mod alchFull =
                ModLoader.GetMod(
                    "AlchemistNPC");
            if (alchFull != null)
            {
                if (type == alchFull.NPCType("Musician"))
                {
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstralMusicBox>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 10);
                        ++nextSlot;
                    }
                }
            }
            Mod clamMod =
                ModLoader.GetMod(
                    "CalamityMod");
            if (clamMod != null)
            {
                if (type == clamMod.NPCType("SEAHOE"))
                {
                    if ((bool)clamMod.Call("GetInZone", Main.player[Main.myPlayer], "sunkensea"))
                    {
                        if ((bool)clamMod.Call("GetBossDowned", "oldduke"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<BloodwormScarf>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 50);
                            ++nextSlot;
                        }

                        if ((bool)clamMod.Call("GetBossDowned", "supremecalamitas"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Yharlamitas>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(42);
                            ++nextSlot;
                        }
                    }

                    if (!(bool)clamMod.Call("GetInZone", Main.player[Main.myPlayer], "sunkensea"))
                    {
                        if ((bool)clamMod.Call("GetBossDowned", "oldduke"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<BloodwormScarf>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(15);
                            ++nextSlot;
                        }

                        if ((bool)clamMod.Call("GetBossDowned", "supremecalamitas"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Yharlamitas>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(420);
                            ++nextSlot;
                        }
                    }
                }

                if (type == clamMod.NPCType("DILF")) //Permafrost
                {/*
                    if (Main.rand.Next(9999) == 0)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<CalamitasFumo>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 99, 99);
                        ++nextSlot;
                    }*/
                    if ((bool)clamMod.Call("GetBossDowned", "cryogen"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<FrostflakeBrick>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 10);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "signus"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Signut>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(15);
                        ++nextSlot;
                    }
                }

                if (type == clamMod.NPCType("THIEF"))
                {
                    if ((bool)clamMod.Call("GetBossDowned", "astrumaureus"))
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

                if (type == clamMod.NPCType("FAP"))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<OddMushroomPot>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 30);
                    ++nextSlot;
                }

                if (type == NPCID.Clothier)
                {
                    int bandit = NPC.FindFirstNPC(clamMod.NPCType("THIEF"));
                    int archmage = NPC.FindFirstNPC(clamMod.NPCType("DILF"));
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

                    if (Main.LocalPlayer.ZoneDungeon || Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneMockDungeon)
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

                    if (CalamityMod.World.CalamityWorld.downedPolterghast)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<ChaoticPuffball>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1);
                        ++nextSlot;
                    }
                }
            }
        }

        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback,
            ref bool crit, ref int hitDirection)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (npc.type == calamityMod.NPCType("AstrumAureus"))
            {
                if (projectile.type == calamityMod.ProjectileType("AstrageldonSummon") || projectile.type == calamityMod.ProjectileType("AstrageldonLaser"))
                {
                    geldonSummon = true;
                }
                else
                {
                    geldonSummon = false;
                }
            }
            else if (npc.type == calamityMod.NPCType("Bumblefuck"))
            {
                if (projectile.type == calamityMod.ProjectileType("Minibirb") && !projectile.ranged)
                {
                    bdogeMount = true;
                }
                else
                {
                    bdogeMount = false;
                }
            }
            else if (npc.type == calamityMod.NPCType("Yharon"))
            {
                if (projectile.type == calamityMod.ProjectileType("WulfrumBoltMinion") || projectile.type == calamityMod.ProjectileType("WulfrumDroid"))
                {
                    wolfram = true;
                }
                else
                {
                    wolfram = false;
                }
            }
            else if (npc.type == calamityMod.NPCType("Signus"))
            {
                if (projectile.type == calamityMod.ProjectileType("PristineFire") ||
                    projectile.type == calamityMod.ProjectileType("PristineSecondary"))
                {
                    junkoReference = true;
                }
                else
                {
                    junkoReference = false;
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
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (npc.type == calamityMod.NPCType("WITCH") && (!CalValEXWorld.jharinter || !NPC.downedMoonlord))
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
                    Projectile.NewProjectile(position, direction * speed, type, damage, 0f, Main.myPlayer);
                    calashoot = 0;
                }
            }
            if (npc.type == calamityMod.NPCType("Signus"))
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
                        npc.StrikeNPC(499999, 99f, npc.direction  * 50, true, false, false);
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
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (npc.type == calamityMod.NPCType("Signus") && !signusbackup && Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().junsi && Main.netMode != NetmodeID.Server)
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

        public override void NPCLoot(NPC npc)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
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
                                    Item.NewItem(npc.Hitbox, ItemID.PlatinumCoin, platCoins);
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
                                    Item.NewItem(npc.Hitbox, ItemID.GoldCoin, goldCoins);
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
                                    Item.NewItem(npc.Hitbox, ItemID.SilverCoin, silverCoins);
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
                                Item.NewItem(npc.Hitbox, ItemID.CopperCoin, copperCoins);
                            }

                            droppedMoney++;
                        }
                    }
                }
            }

            //5%
            float normalChance = normalEnemyChance;
            //10%
            float rareChance = rareEnemyChance;
            //1%
            float mountChance = 0.01f;
            Mod catalyst = ModLoader.GetMod("CatalystMod");
            if (npc.boss)
            {
                Player player = Main.LocalPlayer;
                CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
                modPlayer.bossded = 480;
            }
            if (!CalValEXConfig.Instance.DisableVanityDrops)
            {
                if (npc.type == calamityMod.NPCType("DILF"))
                {
                    DropItem(npc, ModContent.ItemType<Permascarf>()); //garanteed
                }

                if (npc.type == calamityMod.NPCType("THIEF"))
                {
                    DropItem(npc, ModContent.ItemType<BanditHat>()); //garanteed
                }

                // Swearshrooms
                if (npc.type == calamityMod.NPCType("CrabShroom"))
                {
                    if (!NPC.AnyNPCs(calamityMod.NPCType("CrabulonIdle")))
                    {
                        if (Main.LocalPlayer.HasItem(ModContent.ItemType<PutridShroom>()))
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Swearshroom>());
                        }
                    }
                }

                //Prehm
                if (npc.type == calamityMod.NPCType("AngryDog"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<TundraBall>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("Rotdog"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<OldTennisBall>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("BoxJellyfish"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<BoxBalloon>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("Catfish"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<DiscardedCollar>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("RepairUnitCritter"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<DisrepairUnit>(), bossPetChance); //Change to normalChance in 1.5.4
                }

                if (npc.type == calamityMod.NPCType("PrismTurtle"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<PrismShell>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("Scryllar"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ScryllianWings>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("ScryllarRage"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ScryllianWings>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("DespairStone"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<Drock>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("Trasher"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<OlTrashtooth>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("WulfrumRover"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<WulfrumKeys>(), mountChance);
                    ChanceDropItem(npc, ModContent.ItemType<WulfrumController>(), 0.02f);
                    ChanceDropItem(npc, ModContent.ItemType<RoverSpindle>(), 0.02f);
                }

                if (npc.type == calamityMod.NPCType("WulfrumDrone"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<WulfrumController>(), 0.02f);
                }

                if (npc.type == calamityMod.NPCType("WulfrumHovercraft"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<WulfrumController>(), 0.02f);
                }

                if (npc.type == calamityMod.NPCType("WulfrumGyrator"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<WulfrumController>(), 0.02f);
                    ChanceDropItem(npc, ModContent.ItemType<WulfrumBalloon>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("WulfrumPylon"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<PylonRemote>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CosmicElemental"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<CosmicCone>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("Sunskater"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<SkeetCrest>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("ShockstormShuttle"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ShuttleBalloon>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("AeroSlime"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<AeroWings>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("SeaFloaty"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<FloatyCarpetItem>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("SuperDummyNPC"))
                {
                    ConditionalDropItem(npc, ModContent.ItemType<DummyMask>(),
                        Main.LocalPlayer.HeldItem.type != calamityMod.ItemType("SuperDummy"));
                }

                //Crawlers
                if (npc.type == calamityMod.NPCType("CrawlerAmethyst"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<AmethystStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerTopaz"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<TopazStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerSapphire"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<SapphireStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerEmerald"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<EmeraldStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerRuby"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<RubyStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerDiamond"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<DiamondStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerCrystal"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<CrystalStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerAmber"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<AmberStone>(), rareChance);
                }

                //end of crawler drops and prehm
                //Acid rain set tier 2
                if (npc.type == calamityMod.NPCType("SulfurousSkater"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<SkaterEgg>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("Orthocera"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<Help>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("FlakCrab"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<FlakHeadCrab>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("Trilobite"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<TrilobiteShield>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("GammaSlime"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<GammaHelmet>(), vanityMinChance);
                    ChanceDropItem(npc, ModContent.ItemType<NuclearFumes>(), 0.3f); //30%
                }

                //Hardmode drops
                if (npc.type == calamityMod.NPCType("PerennialSlime"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<PerennialFlower>(), vanityNormalChance);
                    ChanceDropItem(npc, ModContent.ItemType<PerennialDress>(), vanityNormalChance);
                    ChanceDropItem(npc, ModContent.ItemType<PerennialFlower>(), RIVChance);
                }

                if (npc.type == calamityMod.NPCType("Bohldohr"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<BoldEgg>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("BelchingCoral"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<CoralMask>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("AnthozoanCrab"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<CrackedFossil>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("IceClasper"))
                {
                    //ChanceDropItem(npc, ModContent.ItemType<AntarcticEssence>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("Cryon"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<Cryocap>(), vanityNormalChance);
                    ChanceDropItem(npc, ModContent.ItemType<Cryocoat>(), vanityNormalChance);
                }

                if (npc.type == calamityMod.NPCType("SmallSightseer"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<Binoculars>(),
                        (bool)calamityMod.Call("GetBossDowned", "astrumaureus"), 0.05f); //5%
                }

                if (npc.type == calamityMod.NPCType("BigSightseer"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<Binoculars>(),
                        (bool)calamityMod.Call("GetBossDowned", "astrumaureus"), 0.1f); //10%
                }

                if (npc.type == calamityMod.NPCType("CultistAssassin"))
                {
                    if (Main.rand.NextFloat() < 0.05f)
                    {
                        DropItem(npc, ModContent.ItemType<CultistRobe>());
                        DropItem(npc, ModContent.ItemType<CultistHood>());
                        DropItem(npc, ModContent.ItemType<CultistLegs>());
                    }
                }

                if (npc.type == calamityMod.NPCType("HeatSpirit"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ChaosEssence>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("OverloadedSoldier"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<UnloadedHelm>(), vanityMaxChance);
                    ChanceDropItem(npc, ModContent.ItemType<HauntedPebble>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("PhantomDebris"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<HauntedPebble>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("DevilFishAlt"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<DevilfishMask1>(), vanityNormalChance);
                }

                if (npc.type == calamityMod.NPCType("DevilFish"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<DevilfishMask2>(), vanityNormalChance);
                }

                if (npc.type == calamityMod.NPCType("MirageJelly"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<Mirballoon>(), vanityNormalChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<OldMirage>(), NPC.downedGolemBoss, 0.01f); //1%
                }

                if (npc.type == calamityMod.NPCType("Hadarian"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<HadarianTail>(),
                        (bool)calamityMod.Call("GetBossDowned", "astrumaureus"), 0.05f); //5%
                }

                if (npc.type == calamityMod.NPCType("Eidolist"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<EidoMask>(), vanityNormalChance);
                    ChanceDropItem(npc, ModContent.ItemType<Eidcape>(), vanityNormalChance);
                }

                //Profaned enemies
                if (npc.type == calamityMod.NPCType("ProfanedEnergyBody"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ProfanedEnergyHook>(), bossHookChance);
                    ChanceDropItem(npc, ModContent.ItemType<ProfanedBalloon>(),
                        normalChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ChewyToy>(),
                        (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.01f); //1%
                }

                if (npc.type == calamityMod.NPCType("ScornEater"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ScornEaterMask>(), normalChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ChewyToy>(),
                        (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.01f); //1%
                }

                if (npc.type == calamityMod.NPCType("ImpiousImmolator"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<HolyTorch>(), 0.05f); //10%
                    ChanceDropItem(npc, ModContent.ItemType<ProfanedBalloon>(), normalChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ChewyToy>(),
                        (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.01f); //1%
                }

                //Post-ml misc
                if (npc.type == mod.NPCType("ShockstormShuttle"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<Items.Equips.ExodiumMoon>(), NPC.downedMoonlord, vanityNormalChance);
                }
                if (npc.type == calamityMod.NPCType("ChaoticPuffer"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ChaosBalloon>(), vanityNormalChance);
                }

                //Minibosses
                if (npc.type == calamityMod.NPCType("NuclearTerror"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<RadJuice>(), minibossChance);
                    ChanceDropItem(npc, ModContent.ItemType<TerrorLegs>(), minibossChance);
                    DropItem(npc, ModContent.ItemType<NuclearFumes>(), 3, 5); //garanteed 3 to 5
                    ConditionalDropItem(npc, ModContent.ItemType<NuclearFumes>(), Main.expertMode, 1,
                        3); //when expert mode you get 1 to 3
                    ChanceDropItem(npc, ModContent.ItemType<NuclearFumes>(), 0.5f); //50% chance to get 1 extra
                    ChanceDropItem(npc, ModContent.ItemType<NuclearFumes>(), 0.3f); //30% chance to get 1 extra
                }

                if (npc.type == calamityMod.NPCType("Cnidrion"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<DryShrimp>(), minibossChance);
                }

                if (npc.type == calamityMod.NPCType("WildBumblefuck"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<OrbSummon>(), minibossChance);
                }

                if (npc.type == calamityMod.NPCType("Reaper"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ReaperoidPills>(), minibossChance);
                    ChanceDropItem(npc, ModContent.ItemType<ReaperSharkArms>(), minibossChance);
                    ChanceDropItem(npc, ModContent.ItemType<OmegaBlue>(), 0.05f);
                }

                if (npc.type == calamityMod.NPCType("ColossalSquid"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<SquidHat>(), minibossChance);
                    ChanceDropItem(npc, ModContent.ItemType<OmegaBlue>(), 0.05f);
                }

                if (npc.type == calamityMod.NPCType("EidolonWyrmHead"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<EWail>(), minibossChance);
                    ChanceDropItem(npc, ModContent.ItemType<OmegaBlue>(), 0.05f);
                }

                if (npc.type == calamityMod.NPCType("Horse"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<EarthShield>(), minibossChance);
                    if (Main.rand.NextFloat() < 0.1f)
                    {
                        DropItem(npc, ModContent.ItemType<EarthenHelmet>());
                        DropItem(npc, ModContent.ItemType<EarthenBreastplate>());
                        DropItem(npc, ModContent.ItemType<EarthenLeggings>());
                    }
                }

                if (npc.type == calamityMod.NPCType("GiantClam"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ClamHermitMedallion>(), minibossChance);
                    ChanceDropItem(npc, ModContent.ItemType<ClamMask>(), vanityMaxChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<GiantClamPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance") && Main.hardMode, bossPetChance);
                }

                if (npc.type == NPCID.SandElemental)
                {
                    ChanceDropItem(npc, ModContent.ItemType<SandBottle>(), normalChance);
                    ChanceDropItem(npc, ModContent.ItemType<SandPlush>(), normalChance);
                    ChanceDropItem(npc, ModContent.ItemType<SandyBangles>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("PlaguebringerShade"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<BeeCan>(), 0.1f);
                    ChanceDropItem(npc, ModContent.ItemType<PlaugeWings>(), 0.1f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AncientAuricTeslaHelm>(), Main.expertMode,
                        0.0012f);
                }

                if (npc.type == calamityMod.NPCType("ArmoredDiggerHead"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AncientAuricTeslaHelm>(), Main.expertMode, 0.0012f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<DiggerRemote>(), Main.expertMode, 0.2f);
                }

                if (npc.type == calamityMod.NPCType("CragmawMire"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<MawHook>(),
                        (bool)calamityMod.Call("GetBossDowned", "polterghast"), 0.1f); //10%
                    ConditionalChanceDropItem(npc, ModContent.ItemType<NuclearFumes>(),
                            (bool)calamityMod.Call("GetBossDowned", "polterghast"), 0.3f, 1, 3);
                }
                if (npc.type == calamityMod.NPCType("ThiccWaifu"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<cloudcandy>(), 0.1f);
                    ChanceDropItem(npc, ModContent.ItemType<CloudWaistbelt>(), 0.1f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<FogG>(), ((bool)calamityMod.Call("GetBossDowned", "supremecalamitas") && (bool)calamityMod.Call("GetBossDowned", "exomechs")), 0.0001f);
                }

                if (npc.type == calamityMod.NPCType("Mauler"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<MaulerMask>(), vanityNormalChance);
                    ChanceDropItem(npc, ModContent.ItemType<BubbledFin>(), minibossChance);
                    DropItem(npc, ModContent.ItemType<NuclearFumes>(), 3, 5); //garanteed 3 to 5
                    ConditionalDropItem(npc, ModContent.ItemType<NuclearFumes>(), Main.expertMode, 1,
                        3); //when expert mode you get 1 to 3
                    ChanceDropItem(npc, ModContent.ItemType<NuclearFumes>(), 0.5f); //50% chance to get 1 extra
                    ChanceDropItem(npc, ModContent.ItemType<NuclearFumes>(), 0.3f); //30% chance to get 1 extra
                }

                //Bosses
                if (npc.type == calamityMod.NPCType("DesertScourgeHead"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<DesertMedallion>(), !Main.expertMode, 0.2f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<DriedMandible>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<DesertScourgePlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("CrabulonIdle"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ClawShroom>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<CrabulonPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("PerforatorHive"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<DigestedWormFood>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<PerforatorPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("HiveMind"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<MissingFang>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<HiveMindPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("PerforatorHeadSmall"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<SmallWorm>(), !Main.expertMode, 0.2f);
                }

                if (npc.type == calamityMod.NPCType("PerforatorHeadMedium"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<MidWorm>(), !Main.expertMode, 0.2f);
                }

                if (npc.type == calamityMod.NPCType("PerforatorHeadLarge"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<BigWorm>(), !Main.expertMode, 0.2f);
                }

                if (npc.type == calamityMod.NPCType("SlimeGodCore") && !NPC.AnyNPCs(calamityMod.NPCType("SlimeGodSplit")) && !NPC.AnyNPCs(calamityMod.NPCType("SlimeGodRunSplit")))
                {
                    if (Main.rand.Next(7) == 0)
                    {
                        DropItem(npc, ModContent.ItemType<SlimeGodMask>());
                    }
                    if (!CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("StatigelBlock"),
                            !Main.expertMode, 155, 265);
                    }

                    ConditionalChanceDropItem(npc, ModContent.ItemType<ImpureStick>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(),
                        (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.01f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<SlimeGodPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("SlimeGodSplit") && !NPC.AnyNPCs(calamityMod.NPCType("SlimeGodCore")) && !NPC.AnyNPCs(calamityMod.NPCType("SlimeGodRunSplit")) && NPC.CountNPCS(calamityMod.NPCType("SlimeGodSplit")) == 1)
                {
                    if (Main.rand.Next(7) == 0)
                    {
                        DropItem(npc, ModContent.ItemType<SlimeGodMask>());
                    }
                    if (!CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("StatigelBlock"),
                            !Main.expertMode, 155, 265);
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ImpureStick>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(),
                        (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.01f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<SlimeGodPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("SlimeGodRunSplit") && !NPC.AnyNPCs(calamityMod.NPCType("SlimeGodCore")) && !NPC.AnyNPCs(calamityMod.NPCType("SlimeGodSplit")) && NPC.CountNPCS(calamityMod.NPCType("SlimeGodRunSplit")) == 1)
                {
                    if (Main.rand.Next(7) == 0)
                    {
                        DropItem(npc, ModContent.ItemType<SlimeGodMask>());
                    }
                    if (!CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("StatigelBlock"),
                            !Main.expertMode, 155, 265);
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ImpureStick>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(),
                        (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.01f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<SlimeGodPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("Cryogen"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<CryoStick>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<CryogenPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("AquaticScourgeHead"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AquaticHide>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AquaticScourgePlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("BrimstoneElemental"))
                {
                    if (!CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("BrimstoneSlag"),
                            !Main.expertMode, 155, 265);
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<brimtulip>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<BrimmySpirit>(), !Main.expertMode, 0.15f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<BrimmyBody>(), !Main.expertMode, 0.15f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<FoilSpoon>(), !Main.expertMode, 0.035f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<BrimstoneElementalPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("CalamitasRun3"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ClonePlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.2f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<Calacirclet>(), !Main.expertMode, bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("Siren") && !NPC.AnyNPCs(calamityMod.NPCType("Leviathan")))
                {
                    if (!Main.expertMode)
                    {
                        ChanceDropItem(npc, ModContent.ItemType<AquaticMonolith>(), 0.15f);
                        ConditionalChanceDropItem(npc, ModContent.ItemType<FoilAtlantis>(), !Main.expertMode, 0.2f);
                        ConditionalChanceDropItem(npc, ModContent.ItemType<WetBubble>(), !Main.expertMode, 0.02f);
                        ConditionalChanceDropItem(npc, ModContent.ItemType<LeviWings>(), !Main.expertMode, vanityMaxChance); //15%
                        ConditionalChanceDropItem(npc, ModContent.ItemType<LeviathanEgg>(), !Main.expertMode, vanityMaxChance); //15%
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AnahitaPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<LeviathanPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance * 0.1f);
                }

                if (npc.type == calamityMod.NPCType("Leviathan") && !NPC.AnyNPCs(calamityMod.NPCType("Siren")))
                {
                    if (!Main.expertMode)
                    { 
                        ChanceDropItem(npc, ModContent.ItemType<AquaticMonolith>(), 0.15f);
                        ConditionalChanceDropItem(npc, ModContent.ItemType<FoilAtlantis>(), !Main.expertMode, 0.2f);
                        ConditionalChanceDropItem(npc, ModContent.ItemType<WetBubble>(), !Main.expertMode, 0.02f);
                        ConditionalChanceDropItem(npc, ModContent.ItemType<LeviWings>(), !Main.expertMode, vanityMaxChance); //15%
                        ConditionalChanceDropItem(npc, ModContent.ItemType<LeviathanEgg>(), !Main.expertMode, vanityMaxChance); //15%
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<LeviathanPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AnahitaPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance * 0.1f);
                }

                if (npc.type == calamityMod.NPCType("AstrumAureus"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AstDie>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AstrumAureusPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AureusShield>(), !Main.expertMode, 0.2f);
                    if (geldonSummon)
                    {
                        ChanceDropItem(npc, ModContent.ItemType<JellyBottle>(), 1.0f);
                    }
                    else
                    {
                        if (catalyst == null)
                        {
                            ConditionalChanceDropItem(npc, ModContent.ItemType<JellyBottle>(),
                                (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.1f);
                        }
                    }
                }

                if (npc.type == calamityMod.NPCType("PlaguebringerGoliath"))
                {
                    if (!CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("PlaguedPlate"), !Main.expertMode,
                            155, 265);
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<PlaguePack>(), !Main.expertMode, vanityMaxChance); //15%
                    ConditionalChanceDropItem(npc, ModContent.ItemType<InfectedController>(), !Main.expertMode, vanityMaxChance); //15%
                    ConditionalChanceDropItem(npc, ModContent.ItemType<PlaguebringerGoliathPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("RavagerBody"))
                {
                    if (!Main.expertMode)
                    {
                        int choice = Main.rand.Next(3);
                        if (choice == 0)
                        {
                            DropItem(npc, ModContent.ItemType<AncientChoker>());
                        }
                        if (choice == 1)
                        {
                            DropItem(npc, ModContent.ItemType<SkullBalloon>());
                        }
                        else
                        {
                            DropItem(npc, ModContent.ItemType<StonePile>());
                        }
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<RavagerPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<RavaHook>(), !Main.expertMode, vanityMaxChance); //15%
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ScavaHook>(), !Main.expertMode, 0.05f); //15%
                    ConditionalDropItem(npc, ModContent.ItemType<Necrostone>(), !Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks, 155, 265);
                }

                if (npc.type == calamityMod.NPCType("AstrumDeusHeadSpectral") && NPC.CountNPCS(calamityMod.NPCType("AstrumDeusHeadSpectral")) == 1)
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AstralStar>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AstBandana>(), !Main.expertMode, 0.2f);
                    if (Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneAstral || Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().Blok)
                    {
                        DropItem(npc, ModContent.ItemType<AstrumDeusMask>());
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AstrumDeusPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("Bumblefuck"))
                {
                    if (!Main.expertMode)
                    {
                        int choice = Main.rand.Next(3);
                        if (choice == 0)
                        {
                            DropItem(npc, ModContent.ItemType<FollyWing>());
                        }
                        if (choice == 1)
                        {
                            DropItem(npc, ModContent.ItemType<Birbhat>());
                        }
                        else
                        {
                            DropItem(npc, ModContent.ItemType<FollyWings>());
                        }
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<FluffyFeather>(),
                        (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<SparrowMeat>(),
                        (bool)calamityMod.Call("DifficultyActive", "malice"), 0.1f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<BumblefuckPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    if (!Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("SilvaCrystal"),
                            (bool)calamityMod.Call("GetBossDowned", "yharon"), 155, 265);
                    }

                    if (bdogeMount)
                    {
                        ChanceDropItem(npc, ModContent.ItemType<FluffyFur>(), 1.0f);
                    }
                    else
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<FluffyFur>(),
                            (bool)calamityMod.Call("DifficultyActive", "death"), 0.001f);
                    }
                }

                if (npc.type == calamityMod.NPCType("Providence"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ProShard>(), !Main.expertMode, bossPetChance);
                    if (!CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("ProfanedRock"), !Main.expertMode,
                            155, 265);
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ProviCrystal>(), !Main.expertMode, 0.2f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<FlareRune>(), !Main.dayTime, 0.01f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ProvidencePlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("StormWeaverHead") &&
                    CalamityWorld.DoGSecondStageCountdown <= 0)
                {
                    if (Main.rand.Next(3) == 0)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            ConditionalDropItem(npc, ModContent.ItemType<WeaverFlesh>(), !Main.expertMode);
                        }
                        else
                        {
                            ConditionalDropItem(npc, ModContent.ItemType<ShellScrap>(), !Main.expertMode);
                        }
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<StormBandana>(), !Main.expertMode, vanityNormalChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<StormWeaverPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    if (!Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("OccultStone"),
                            (bool)calamityMod.Call("GetBossDowned", "devourerofgods"), 155, 265);
                    }
                }

                if (npc.type == calamityMod.NPCType("Signus") && CalamityWorld.DoGSecondStageCountdown <= 0)
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<SigCloth>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<SignusPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    if (!Main.expertMode)
                    {
                        int choice = Main.rand.Next(4);
                        {
                            if (choice == 0)
                                DropItem(npc, ModContent.ItemType<SignusBalloon>());
                            else if (choice == 1)
                                DropItem(npc, ModContent.ItemType<SigCape>());
                            else if (choice == 2)
                                DropItem(npc, ModContent.ItemType<SignusNether>());
                            else if (choice == 3)
                                DropItem(npc, ModContent.ItemType<SignusEmblem>());
                        }
                    }
                    if (junkoReference)
                    {
                        ChanceDropItem(npc, ModContent.ItemType<JunkoHat>(), 1.0f);
                    }
                    else
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<JunkoHat>(),
                            (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.01f);
                    }

                    if (!Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("OccultStone"),
                            (bool)calamityMod.Call("GetBossDowned", "devourerofgods"), 155, 265);
                    }
                }

                if (npc.type == calamityMod.NPCType("CeaselessVoid") && CalamityWorld.DoGSecondStageCountdown <= 0)
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<VoidShard>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<CeaselessVoidPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<OldVoidWings>(), !Main.expertMode, 0.05f); //5%
                    ConditionalChanceDropItem(npc, ModContent.ItemType<VoidWings>(), !Main.expertMode, vanityMaxChance); //15%
                    if (!Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("OccultStone"),
                            (bool)calamityMod.Call("GetBossDowned", "devourerofgods"), 155, 265);
                    }
                }

                if (npc.type == calamityMod.NPCType("Polterghast"))
                {
                    if (!CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        if (Main.rand.NextFloat() < 0.5f)
                        {
                            ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("StratusBricks"),
                                !Main.expertMode, 155, 265);
                        }
                        else
                        {
                            ConditionalDropItem(npc, ModContent.ItemType<PhantowaxBlock>(), !Main.expertMode, 155, 265);
                        }
                    }

                    ConditionalChanceDropItem(npc, ModContent.ItemType<Polterhook>(), !Main.expertMode, vanityMaxChance); //15%
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ToyScythe>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);

                    if (Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().poltermask && Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().polterchest && Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().polterthigh)
                    {
                        DropItem(npc, ModContent.ItemType<ToyScythe>());
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<PolterghastPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("OldDuke"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<CorrodedCleaver>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<OldWings>(), !Main.expertMode, vanityMaxChance); //15%
                    ConditionalChanceDropItem(npc, ModContent.ItemType<OldDukePlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                if (npc.type == calamityMod.NPCType("DevourerofGodsHead"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<DogPetItem>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<DevourerofGodsPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<CosmicWormScarf>(), !Main.expertMode, 0.2f);
                    if (NPC.AnyNPCs(calamityMod.NPCType("ProfanedGuardianBoss")) && (bool)calamityMod.Call("DifficultyActive", "death"))
                    {
                        DropItem(npc, ModContent.ItemType<FlareRune>());
                    }
                    else if (NPC.AnyNPCs(calamityMod.NPCType("ProfanedGuardianBoss2")))
                    {
                        DropItem(npc, ModContent.ItemType<FlareRune>());
                    }
                    //(NPC.AnyNPCs(calamityMod.NPCType("DevourerofGods")))
                }

                if (npc.type == calamityMod.NPCType("Yharon"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<NuggetBiscuit>(), !Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<YharonShackle>(), !Main.expertMode, 0.2f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<YharonPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    if (!Main.expertMode)
                    {
                        DropItem(npc, ModContent.ItemType<Termipebbles>(), 2, 8);
                    }
                    if (CalValEX.month == 6 && CalValEX.day == 1)
                    {
                        DropItem(npc, ModContent.ItemType<YharonsAnklet>());
                    }
                    if (wolfram)
                    {
                        ChanceDropItem(npc, ModContent.ItemType<RoverSpindle>(), 1.0f);
                    }
                    if (Main.rand.Next(10) == 0 && !Main.expertMode)
                    {
                        DropItem(npc, ModContent.ItemType<DemonshadeHood>());
                        DropItem(npc, ModContent.ItemType<DemonshadeRobe>());
                        DropItem(npc, ModContent.ItemType<DemonshadePants>());
                    }
                }
                //Exo Twin drops
                if (npc.type == calamityMod.NPCType("Apollo") && !NPC.AnyNPCs(calamityMod.NPCType("ThanatosHead")) && !NPC.AnyNPCs(calamityMod.NPCType("AresBody")))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<Items.Pets.ExoMechs.GeminiMarkImplants>(), !Main.expertMode, bossPetChance);
                    if (Main.rand.Next(7) == 0 && !Main.expertMode)
                    {
                        DropItem(npc, ModContent.ItemType<DraedonBody>());
                        DropItem(npc, ModContent.ItemType<DraedonLegs>());
                    }
                    if (Main.rand.Next(3) == 0 && !Main.expertMode)
                    {
                        DropItem(npc, ModContent.ItemType<ApolloBalloonSmall>());
                        DropItem(npc, ModContent.ItemType<ArtemisBalloonSmall>());
                    }
                    if ((bool)calamityMod.Call("DifficultyActive", "revengeance") && Main.rand.Next(2) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ArtemisPlush>(), 1, false, 0, false, false);
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ApolloPlush>(), 1, false, 0, false, false);
                        ConditionalChanceDropItem(npc, ModContent.ItemType<DraedonPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    }
                }
                //Ares drops
                if (npc.type == calamityMod.NPCType("AresBody") && !NPC.AnyNPCs(calamityMod.NPCType("ThanatosHead")) && !NPC.AnyNPCs(calamityMod.NPCType("Apollo")))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<Items.Pets.ExoMechs.OminousCore>(), !Main.expertMode, bossPetChance);
                    if (Main.rand.Next(7) == 0 && !Main.expertMode)
                    {
                        DropItem(npc, ModContent.ItemType<DraedonBody>());
                        DropItem(npc, ModContent.ItemType<DraedonLegs>());
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<Items.Equips.Shirts.AresChestplate.AresChestplate>(), !Main.expertMode, 0.33f);
                    if ((bool)calamityMod.Call("DifficultyActive", "revengeance") && Main.rand.Next(2) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AresPlush>(), 1, false, 0, false, false);
                        ConditionalChanceDropItem(npc, ModContent.ItemType<DraedonPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    }
                }
                //Thanatos drops
                if (npc.type == calamityMod.NPCType("ThanatosHead") && !NPC.AnyNPCs(calamityMod.NPCType("AresBody")) && !NPC.AnyNPCs(calamityMod.NPCType("Apollo")))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<Items.Pets.ExoMechs.GunmetalRemote>(), !Main.expertMode, bossPetChance);
                    if (Main.rand.Next(7) == 0 && !Main.expertMode)
                    {
                        DropItem(npc, ModContent.ItemType<DraedonBody>());
                        DropItem(npc, ModContent.ItemType<DraedonLegs>());
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<XMLightningHook>(), !Main.expertMode, 0.33f); 
                    if ((bool)calamityMod.Call("DifficultyActive", "revengeance") && Main.rand.Next(2) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ThanatosPlush>(), 1, false, 0, false, false);
                        ConditionalChanceDropItem(npc, ModContent.ItemType<DraedonPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    }
                }

                if (npc.type == calamityMod.NPCType("SupremeCalamitas"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<CalamitasFumo>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<GruelingMask>(), !Main.expertMode, 0.2f);
                }

                if (npc.type == calamityMod.NPCType("EidolonWyrmHeadHuge"))
                {
                    DropItem(npc, ModContent.ItemType<SoulShard>());
                    DropItem(npc, ModContent.ItemType<OmegaBlue>());
                    DropItem(npc, ModContent.ItemType<RespirationShrine>());
                    ConditionalChanceDropItem(npc, ModContent.ItemType<JaredPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                }

                //Profaned bike
                if (npc.type == calamityMod.NPCType("ProfanedGuardianBoss3"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ProfanedBattery>(), 0.2f); //20%
                }

                if (npc.type == calamityMod.NPCType("ProfanedGuardianBoss2"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ProfanedWheels>(), 0.2f); //20%
                }

                if (npc.type == calamityMod.NPCType("ProfanedGuardianBoss"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ProfanedGuardianPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    ChanceDropItem(npc, ModContent.ItemType<ProfanedFrame>(), 0.2f); //20%
                }

                //Catalyst support
                if (catalyst != null)
                {
                    if (npc.type == catalyst.NPCType("Astrageldon"))
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<JellyBottle>(), !Main.expertMode, bossPetChance); //10%
                        ConditionalChanceDropItem(npc, ModContent.ItemType<AstrageldonPlush>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    }
                }

                //Goozma slimes
                if ((bool)calamityMod.Call("DifficultyActive", "revengeance"))
                {
                    if (npc.type == NPCID.Grasshopper)
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(), Main.expertMode, 0.00000002f);
                    }
                    if (npc.type == NPCID.GoldGrasshopper)
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(), Main.expertMode, 0.00000003f);
                    }
                    if (npc.type == NPCID.BlueSlime ||
                       npc.type == NPCID.GreenSlime ||
                       npc.type == NPCID.PurpleSlime ||
                       npc.type == NPCID.YellowSlime ||
                       npc.type == NPCID.RedSlime ||
                       npc.type == NPCID.ArmedZombieSlimed ||
                       npc.type == NPCID.BigSlimedZombie ||
                       npc.type == NPCID.SmallSlimedZombie ||
                       npc.type == NPCID.SlimedZombie)
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(), Main.expertMode, 0.00005f);
                    }
                    if (npc.type == NPCID.CorruptSlime ||
                        npc.type == NPCID.Crimslime ||
                        npc.type == NPCID.BigCrimslime ||
                        npc.type == NPCID.LittleCrimslime ||
                        npc.type == NPCID.Slimer2 ||
                        npc.type == NPCID.SandSlime ||
                        npc.type == NPCID.Pinky ||
                        npc.type == NPCID.BlueSlime ||
                        npc.type == NPCID.GreenSlime ||
                        npc.type == NPCID.PurpleSlime ||
                        npc.type == NPCID.YellowSlime ||
                        npc.type == NPCID.RedSlime ||
                        npc.type == NPCID.BlackSlime ||
                        npc.type == NPCID.MotherSlime ||
                        npc.type == NPCID.ToxicSludge ||
                        npc.type == NPCID.RainbowSlime ||
                        npc.type == NPCID.IceSlime ||
                        npc.type == NPCID.SpikedIceSlime ||
                        npc.type == NPCID.JungleSlime ||
                        npc.type == NPCID.SpikedJungleSlime ||
                        npc.type == NPCID.DungeonSlime ||
                        npc.type == NPCID.LavaSlime ||
                        npc.type == NPCID.UmbrellaSlime ||
                        npc.type == NPCID.BunnySlimed ||
                        npc.type == NPCID.SlimeRibbonGreen ||
                        npc.type == NPCID.SlimeRibbonRed ||
                        npc.type == NPCID.SlimeRibbonWhite ||
                        npc.type == NPCID.SlimeRibbonYellow ||
                        npc.type == NPCID.HoppinJack ||
                        npc.type == NPCID.CorruptSlime)
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(), Main.expertMode, 0.0002f);
                    }
                    if (npc.type == calamityMod.NPCType("AeroSlime") || npc.type == calamityMod.NPCType("CryoSlime") ||
                        npc.type == calamityMod.NPCType("PerennialSlime") ||
                        npc.type == calamityMod.NPCType("PlaguedJungleSlime") ||
                        npc.type == calamityMod.NPCType("BloomSlime") ||
                        npc.type == calamityMod.NPCType("IrradiatedSlime") ||
                        npc.type == calamityMod.NPCType("GammaSlime"))
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(), Main.expertMode, 0.001f);
                    }

                    if (npc.type == calamityMod.NPCType("EbonianBlightSlime") ||
                        npc.type == calamityMod.NPCType("CrimulanBlightSlime") ||
                        npc.type == calamityMod.NPCType("AstralSlime") ||
                        npc.type == NPCID.IlluminantSlime ||
                        npc.type == calamityMod.NPCType("CragmawMire"))
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(), Main.expertMode, 0.002f);
                    }

                    if (npc.type == NPCID.KingSlime)
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(), Main.expertMode, 0.005f);
                    }

                    if (catalyst != null)
                    {
                        if (npc.type == catalyst.NPCType("Astrageldon"))
                        {
                            ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(), Main.expertMode, 0.01f);
                        }
                    }

                    /*if ((npc.type == calamityMod.NPCType("AstrageldonSlime"))
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(), Main.expertMode, 0.0375f);
                    }      lol   */
                }
            }

            //Yharexs' Dev Pet (Calamity BABY)
            if ((bool)calamityMod.Call("DifficultyActive", "death"))
            {
                if (npc.type == calamityMod.NPCType("AstralSlime") && Main.rand.Next(870000) == 0)
                {
                    DropItem(npc, ModContent.ItemType<YharexsLetter>());
                }

                if (npc.type == calamityMod.NPCType("SupremeCalamitas"))
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
                        DropItem(npc, ModContent.ItemType<YharexsLetter>());
                    }
                    else
                    {
                        if (Main.rand.Next(1000) == 0)
                        {
                            DropItem(npc, ModContent.ItemType<YharexsLetter>());
                        }
                    }
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

        public override bool PreNPCLoot(NPC npc)
        {
            BossExclam(npc, new int[] { ModContent.NPCType<JellyPriestNPC>() }, CalamityWorld.downedCLAM, ModContent.NPCType<CalamityMod.NPCs.SunkenSea.GiantClam>());
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
            BossExclam(npc, new int[] { ModContent.NPCType<OracleNPC>() }, CalamityWorld.downedYharon, ModContent.NPCType<CalamityMod.NPCs.Yharon.Yharon>());

            BossExclam(npc, new int[] { ModContent.NPCType<CalamityMod.NPCs.TownNPCs.SEAHOE>() }, CalamityWorld.downedBoomerDuke, ModContent.NPCType<CalamityMod.NPCs.OldDuke.OldDuke>());
            BossExclam(npc, new int[] { ModContent.NPCType<CalamityMod.NPCs.TownNPCs.SEAHOE>() }, CalamityWorld.downedSCal, ModContent.NPCType<CalamityMod.NPCs.SupremeCalamitas.SupremeCalamitas>());

            BossExclam(npc, new int[] { ModContent.NPCType<CalamityMod.NPCs.TownNPCs.DILF>() }, CalamityWorld.downedSentinel3, ModContent.NPCType<CalamityMod.NPCs.Signus.Signus>());

            BossExclam(npc, new int[] { ModContent.NPCType<CalamityMod.NPCs.TownNPCs.THIEF>() }, CalamityWorld.downedAstrageldon, ModContent.NPCType<CalamityMod.NPCs.AstrumAureus.AstrumAureus>());

            BossExclam(npc, new int[] { NPCID.PartyGirl }, CalamityWorld.downedPolterghast, ModContent.NPCType<CalamityMod.NPCs.Polterghast.Polterghast>());
            return true;
        }

        private static int DropItem(NPC npc, int itemID, bool dropPerPlayer, int min = 1, int max = 0)
        {
            int numberOfItems;
            if (max <= min)
            {
                numberOfItems = min;
            }
            else
            {
                numberOfItems = Main.rand.Next(min, max + 1);
            }

            if (numberOfItems <= 0)
            {
                return 0;
            }

            if (dropPerPlayer)
            {
                npc.DropItemInstanced(npc.position, npc.Size, itemID, numberOfItems);
            }
            else
            {
                Item.NewItem(npc.Hitbox, itemID, numberOfItems);
            }

            return numberOfItems;
        }

        private static int DropItem(NPC npc, int itemID, int min = 1, int max = 0) =>
            DropItem(npc, itemID, false, min, max);

        public static int ChanceDropItem(NPC npc, int itemID, float chance, bool dropPerPlayer, int min = 1,
            int max = 0)
        {
            if (Main.rand.NextFloat() < chance)
            {
                return DropItem(npc, itemID, dropPerPlayer, min, max);
            }

            return 0;
        }

        public static int ChanceDropItem(NPC npc, int itemID, float chance, int min = 1, int max = 0) =>
            ChanceDropItem(npc, itemID, chance, false, min, max);

        public static int ConditionalDropItem(NPC npc, int itemID, bool condition, bool dropPerPlayer, int min = 1,
            int max = 0)
        {
            if (condition)
            {
                return DropItem(npc, itemID, dropPerPlayer, min, max);
            }

            return 0;
        }

        public static int ConditionalDropItem(NPC npc, int itemID, bool condition, int min = 1, int max = 0) =>
            ConditionalDropItem(npc, itemID, condition, false, min, max);

        public static int ConditionalChanceDropItem(NPC npc, int itemID, bool condition, float chance,
            bool dropPerPlayer, int min = 1, int max = 0)
        {
            if (condition)
            {
                return ChanceDropItem(npc, itemID, chance, dropPerPlayer, min, max);
            }

            return 0;
        }

        public static int ConditionalChanceDropItem(NPC npc, int itemID, bool condition, float chance, int min = 1,
            int max = 0) =>
            ConditionalChanceDropItem(npc, itemID, condition, chance, false, min, max);
        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
        {
            if (Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneAstral || Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().Blok)
            {
                //DEUS HEAD
                if (npc.type == ModLoader.GetMod("CalamityMod").NPCType("AstrumDeusHeadSpectral"))
                {
                    Texture2D deusheadsprite = (ModContent.GetTexture("CalValEX/NPCs/AstrumDeus/DeusHeadOld"));

                    float deusheadframe = 1f / (float)Main.npcFrameCount[npc.type];
                    int deusheadheight = (int)((float)(npc.frame.Y / npc.frame.Height) * deusheadframe) * (deusheadsprite.Height / 1);

                    Rectangle deusheadsquare = new Rectangle(0, deusheadheight, deusheadsprite.Width, deusheadsprite.Height / 1);
                    Color deusheadalpha = npc.GetAlpha(drawColor);
                    spriteBatch.Draw(deusheadsprite, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusheadsquare, deusheadalpha, npc.rotation, Utils.Size(deusheadsquare) / 2f, npc.scale, SpriteEffects.None, 0f);
                    return false;
                }

                //DEUS BODY
                else if (npc.type == ModLoader.GetMod("CalamityMod").NPCType("AstrumDeusBodySpectral"))
                {
                    Texture2D deusbodsprite = npc.localAI[3] == 1f ? ModContent.GetTexture("CalValEX/NPCs/AstrumDeus/DeusBodyAltOld") : ModContent.GetTexture("CalValEX/NPCs/AstrumDeus/DeusBodyOld");

                    float deusbodframe = 1f / (float)Main.npcFrameCount[npc.type];
                    int deusbodheight = (int)((float)(npc.frame.Y / npc.frame.Height) * deusbodframe) * (deusbodsprite.Height / 1);

                    Rectangle deusbodsquare = new Rectangle(0, deusbodheight, deusbodsprite.Width, deusbodsprite.Height / 1);
                    Color deusbodalpha = npc.GetAlpha(drawColor);
                    spriteBatch.Draw(deusbodsprite, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusbodsquare, deusbodalpha, npc.rotation, Utils.Size(deusbodsquare) / 2f, npc.scale, SpriteEffects.None, 0f);
                    return false;
                }

                //DEUS TAIL
                else if (npc.type == ModLoader.GetMod("CalamityMod").NPCType("AstrumDeusTailSpectral"))
                {
                    Texture2D deustailsprite = (ModContent.GetTexture("CalValEX/NPCs/AstrumDeus/DeusTailOld"));

                    float deustailframe = 1f / (float)Main.npcFrameCount[npc.type];
                    int deustailheight = (int)((float)(npc.frame.Y / npc.frame.Height) * deustailframe) * (deustailsprite.Height / 1);

                    Rectangle deustailsquare = new Rectangle(0, deustailheight, deustailsprite.Width, deustailsprite.Height / 1);
                    Color deustailalpha = npc.GetAlpha(drawColor);
                    spriteBatch.Draw(deustailsprite, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deustailsquare, deustailalpha, npc.rotation, Utils.Size(deustailsquare) / 2f, npc.scale, SpriteEffects.None, 0f);
                    return false;
                }
            }
            return true;

        }

        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Color lightColor)
        {
            if (npc.type == ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodCore>() && ((CalValEX.month == 4 && CalValEX.day == 1) || ModLoader.GetMod("CalValPlus") != null))
            {
                Texture2D tidepodgsprite = (ModContent.GetTexture("CalValEX/ExtraTextures/SlimeGod"));

                float tidepodgframe = 1f / (float)Main.npcFrameCount[npc.type];
                int tidepodgheight = (int)((float)(npc.frame.Y / npc.frame.Height) * tidepodgframe) * (tidepodgsprite.Height / 1);

                Rectangle tidepodgsquare = new Rectangle(0, tidepodgheight, tidepodgsprite.Width, tidepodgsprite.Height / 1);
                Color tidepodgalpha = npc.GetAlpha(lightColor);
                spriteBatch.Draw(tidepodgsprite, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), tidepodgsquare, tidepodgalpha, npc.rotation, Utils.Size(tidepodgsquare) / 2f, npc.scale, SpriteEffects.None, 0f);
            }

            else if (Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneAstral || Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().Blok)
            {
                //DEUS HEAD
                if (npc.type == ModLoader.GetMod("CalamityMod").NPCType("AstrumDeusHeadSpectral"))
                {
                    Texture2D deusheadsprite2 = (ModContent.GetTexture("CalValEX/NPCs/AstrumDeus/DeusHeadOld_Glow"));

                    float deusheadframe2 = 1f / (float)Main.npcFrameCount[npc.type];
                    int deusheadheight2 = (int)((float)(npc.frame.Y / npc.frame.Height) * deusheadframe2) * (deusheadsprite2.Height / 1);

                    Rectangle deusheadsquare2 = new Rectangle(0, deusheadheight2, deusheadsprite2.Width, deusheadsprite2.Height / 1);
                    spriteBatch.Draw(deusheadsprite2, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusheadsquare2, Color.White, npc.rotation, Utils.Size(deusheadsquare2) / 2f, npc.scale, SpriteEffects.None, 0f);
                }

                //DEUS BODY
                else if (npc.type == ModLoader.GetMod("CalamityMod").NPCType("AstrumDeusBodySpectral"))
                {
                    Texture2D deusbodsprite2 = npc.localAI[3] == 1f ? ModContent.GetTexture("CalValEX/NPCs/AstrumDeus/DeusBodyAltOld_Glow") : ModContent.GetTexture("CalValEX/NPCs/AstrumDeus/DeusBodyOld_Glow");

                    float deusbodframe2 = 1f / (float)Main.npcFrameCount[npc.type];
                    int deusbodheight2 = (int)((float)(npc.frame.Y / npc.frame.Height) * deusbodframe2) * (deusbodsprite2.Height / 1);

                    Rectangle deusbodsquare2 = new Rectangle(0, deusbodheight2, deusbodsprite2.Width, deusbodsprite2.Height / 1);
                    spriteBatch.Draw(deusbodsprite2, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusbodsquare2, Color.White, npc.rotation, Utils.Size(deusbodsquare2) / 2f, npc.scale, SpriteEffects.None, 0f);
                }

                //DEUS TAIL
                else if (npc.type == ModLoader.GetMod("CalamityMod").NPCType("AstrumDeusTailSpectral"))
                {
                    Texture2D deustailsprite2 = (ModContent.GetTexture("CalValEX/NPCs/AstrumDeus/DeusTailOld_Glow"));

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
            Player player = LocalPlayer.player;
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            CalamityMod.CalPlayer.CalamityPlayer calp = player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();
            bool noevents = !(CalamityWorld.rainingAcid && calp.ZoneSulphur) && !Main.eclipse && !Main.snowMoon && !Main.pumpkinMoon && Main.invasionType == 0 && !player.ZoneTowerSolar && !player.ZoneTowerStardust && !player.ZoneTowerVortex & !player.ZoneTowerNebula && !player.ZoneOldOneArmy;
            Mod cata = ModLoader.GetMod("CatalystMod");
            if (modPlayer.sBun)
            {
                pool.Add(NPCID.Bunny, 0.001f);
            }
            if (modPlayer.ZoneAstral && noevents)
            {
                pool.Clear();
                if (!CalValEXConfig.Instance.CritterSpawns)
                {
                    pool.Add(ModContent.NPCType<NPCs.Critters.Blightolemur>(), 0.1f);
                    pool.Add(ModContent.NPCType<NPCs.Critters.Blinker>(), 0.1f);
                    pool.Add(ModContent.NPCType<NPCs.Critters.AstJR>(), 0.1f);
                    pool.Add(ModContent.NPCType<NPCs.Critters.GAstJR>(), 0.1f);
                }
                if (cata != null)
                {
                    if (player.ZoneOverworldHeight)
                    {
                        if (!player.HasItem(cata.ItemType("AstralCommunicator")))
                        {
                            pool.Add(cata.NPCType("AstrageldonSlime"), 0.002f);
                        }
                        if ((bool)cata.Call("worlddefeats.astrageldon"))
                        {
                            pool.Add(cata.NPCType("ArmoredAstralSlime"), 0.02f);
                        }
                    }
                }

            }
        }
    }
>>>>>>> Stashed changes
}