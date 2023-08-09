using CalValEX.Items.Tiles;
using CalValEX.Items.Tiles.Banners;
using CalValEX.Items.Tiles.Blueprints;
using CalValEX.Items.Tiles.Plants;
using CalValEX.Items.Tiles.Statues;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;
using Terraria.GameContent.Bestiary;
using Terraria.DataStructures;
using CalValEX.Projectiles.NPCs;
using System.IO;
using Terraria.GameContent.Personalities;
using CalValEX.Items.Tiles.FurnitureSets.Arsenal;
using CalValEX.Items.Tiles.FurnitureSets.Wulfrum;
using CalValEX.Items.Tiles.Monoliths;
using CalValEX.Items.Tiles.Blocks;
using static CalValEX.CalValEXConditions;

namespace CalValEX.NPCs.JellyPriest
{
    [AutoloadHead]
    public class JellyPriestNPC : ModNPC
    {
        public int shoptype = 1;

        public const string ShopName = "Shop";

        public override string Texture => "CalValEX/NPCs/JellyPriest/JellyPriestNPC";
        // public override string[] AltTextures => new[] { "CalValEX/NPCs/JellyPriest/JellyPriestNPC_Alt" };

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;

            NPC.Happiness
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like) // Example Person prefers the forest.
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike) // Example Person dislikes the snow.
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Love) // Example Person likes the Example Surface Biome
                .SetNPCAffection(NPCID.Painter, AffectionLevel.Like) // Loves living near the dryad.
                .SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Dislike) // Hates living near the demolitionist.
            ;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
                new FlavorTextBestiaryInfoElement("A jellyfish that took an odd evolutionary turn. Her affinity for building synergizes with her devotion to the Water Elemental."),
            });
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 15;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Mechanic;
        }

        private bool jellyspawn = false;

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            if (CalValEXWorld.rescuedjelly && !CalValEXConfig.Instance.TownNPC)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void AI()
        {
            if (!CalValEXWorld.rescuedjelly)
                CalValEXWorld.rescuedjelly = true;
            NPC.breath += 2;
            if (CalValEXConfig.Instance.TownNPC)
            {
                NPC.active = false;
            }
        }

        public static List<string> PossibleNames = new List<string>()
        {
            "Eika", "Feferi", "Netlia", "Atollia", "Melodi", "Signathia", "Manawa", "Kanji", "Mariacala", "Cuboza", "Nidaria", "Crasqua", "Kuti", "Ooma"
        };
        public override List<string> SetNPCNameList() => PossibleNames;

        [JITWhenModsEnabled("CalamityMod")]
        public override string GetChat()
        {
            Player player = Main.player[Main.myPlayer];
            CalValEXPlayer CalValEXPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (CalValEX.CalamityActive)
                if (NPC.AnyNPCs(CalValEX.CalamityNPC("Anahita")))
                {
                    switch (Main.rand.Next(2))
                    {
                        case 0:
                            return "Oh my Xeroc! It's her! I have to wrap up preparations quickly!";

                        default:
                            return "After all of my preparations, she is finally here! Anahita of the Tides!";
                    }
                }

            if (CalValEXPlayer.sirember && CalValEXPlayer.bossded <= 0)
            {
                return "WHAT IS THAT HORRIBLE MONSTROSITY";
            }

            if (CalValEXPlayer.sirember && CalValEXPlayer.bossded > 0 && NPC.GivenName != "Kuti")
            {
                return "...Actually, that thing is sort of cute.";
            }

            if (CalValEXPlayer.sirember && CalValEXPlayer.bossded > 0 && NPC.GivenName == "Kuti")
            {
                return "Aww, that floating blob you got there is adorable! Reminds me of my magnificent childhood home! I miss it...";
            }

            if (NPC.homeless)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return "Being free from those vines is great and all, but I need a place to settle for my sculpting.";

                    default:
                        return "Greetings, land creature! I rise from this old sea in hopes of traveling and finding a certain idol from the old times, from when the sea was a beautiful reign for many. Do you have any hint about where I could find them?";
                }
            }

            //Main.NewText("MISC EQUIPS 0 TYPE: " + Main.player[Main.myPlayer].miscEquips[0].type + "|MISC EQUIPS 1 TYPE: " + Main.player[Main.myPlayer].miscEquips[1].type);

            if (CalValEX.CalamityActive)
            {
                int FAP = NPC.FindFirstNPC(CalValEX.CalamityNPC("FAP"));
                if (FAP >= 0 && Main.rand.NextFloat() < 0.25f)
                {
                    switch (Main.rand.Next(2))
                    {
                        case 0:
                            return "I don't feel very comfortable with how close that 'Princess' gets to me when I'm showing her some decorations, I'm starting to think she wants to make food out of me by what she says...!";

                        default:
                            return "The last time that Cirrus got near my decorations, she tore off one of my bust's heads!";
                    }
                }

                int WITCH = NPC.FindFirstNPC(CalValEX.CalamityNPC("WITCH"));
                if (WITCH >= 0 && Main.rand.NextFloat() < 0.25f)
                {
                    switch (Main.rand.Next(2))
                    {
                        case 0:
                            return "That witch... she does not give me any good memories...";

                        default:
                            return "Have you heard of the Brimstone Witch's destruction of the capital of the underworld? It was quite a tragedy... a lot of architecture ruined!";
                    }
                }

                int SEAHOE = NPC.FindFirstNPC(CalValEX.CalamityNPC("SEAHOE"));
                if (SEAHOE >= 0 && Main.rand.NextFloat() < 0.25f)
                {
                    switch (Main.rand.Next(2))
                    {
                        case 0:
                            return "The great sea king I've heard many tales of... And you say that you found him inside a clam...? Oh my, isn't that pathetic now.";

                        default:
                            return "Do you think Amidias knows anything about the sea idol I'm searching? It seems that old horse got a lot of knowledge about story.";
                    }
                }
                if ((bool)CalValEX.Calamity.Call("GetBossDowned", "leviathan") && Main.rand.NextFloat() < 0.25f && !NPC.AnyNPCs(CalValEX.CalamityNPC("Anahita")))
                {
                    switch (Main.rand.Next(2))
                    {
                        case 0:
                            return "Oh! So you did find the location of the idol I'm searching for? Please explain in detail everything about them, I would love to start working on my offerings and monuments as soon as possible.";

                        default:
                            return "For some reason, the idol's presence feels like it's weakened. I hope nothing bad happened to her.";
                    }
                }
                if ((bool)CalValEX.Calamity.Call("GetBossDowned", "scal") && Main.rand.NextFloat() < 0.25f)
                {
                    return "Yeesh, through all of your adventures, I've stocked up quite the inventory!";
                }

                if (player.ownedProjectileCounts[CalValEX.CalamityProjectile("WaterElementalMinion")] > 0 && Main.rand.NextFloat() < 0.25f)
                {
                    return "You were successfully able to befriend the grand Water Elemental? I'm impressed.";
                }

                if (CalValEXPlayer.SirenHeart && Main.rand.NextFloat() < 0.25f)
                {
                    return "OH! Please, welcome yourself to my shop. I've been preparing these just for you.";
                }

                if (CalValEXPlayer.CirrusDress && Main.rand.NextFloat() < 0.25f)
                {
                    return "That's a pretty dress! I know someone who was working on a similar one, but it took so long that they gave up.";
                }

                if (player.ownedProjectileCounts[CalValEX.CalamityProjectile("OceanSpirit")] > 0 && Main.rand.NextFloat() < 0.25f)
                {
                    return "Awe, that little one is cute. She reminds me a lot of the idol I seek.";
                }
            }

            if ((CalValEXPlayer.babywaterclone) && Main.rand.NextFloat() < 0.25f)
            {
                return "That little one has a presence that feels similar, but different to the idol I seek.";
            }

            if (Main.eclipse)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return "It seems spooky out there, how about you stay inside my humble abode.";

                    default:
                        return "Hmm, maybe I can use those bits of cloth that some of those creatures have to make something.";
                }
            }

            if (BirthdayParty.PartyIsUp)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return "Parties are fun! Hopefully one day, I can help make one which will catch the eye of the idol I seek.";

                    default:
                        return "There's a lot of celebration today. Hopefully I can spice things up with my decorations!";
                }
            }

            if (!Main.bloodMoon)
            {
                if (Main.dayTime)
                {
                    switch (Main.rand.Next(5))
                    {
                        case 0:
                            return "This place reeks of sadness, let me help you get the place better with some beautiful decorations will you.";

                        case 1:
                            return "I told you already, I'm not going back into that stinky sea to get you materials for your stuff... unless you have some extra change with you, of course.";

                        case 2:
                            return "I would love to decorate your place for free, but I require some coins for buying offerings you know?";

                        default:
                            return "Oh, where I got this apron and tools from? It is all handmade by myself with resources from around my place! You learn to do this stuff over time with enough passion.";
                    }
                }
                else
                {
                    switch (Main.rand.Next(4))
                    {
                        case 0:
                            return "Although the night sky makes things harder to see, some of my decorations can pierce the darkness with colorful light.";

                        case 1:
                            return "I actually have higher motivation to work at night, the moon reminds me of someone...";

                        default:
                            return "I wonder if the idol I seek watches the moon like I do.";
                    }
                }
            }
            else
            {
                switch (Main.rand.Next(6))
                {
                    case 0:
                        return "This isn't a night where I feel like working.";

                    case 1:
                        return "Darling, could you keep an eye on the furniture? Stuff seems to be getting out of control for some reason.";

                    case 2:
                        return "The eerie redness of the sky does not look pretty on most of my decorations...";

                    default:
                        return "Stay away from my statues!";
                }
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            if (shoptype == 1)
                button = "Blocks";
            else if (shoptype == 2)
                button = "Lategame Blocks";
            else if (shoptype == 3)
                button = "General";
            else if (shoptype == 4)
                button = "Plants";
            else
                button = "Blocks";
            button2 = "Switch Shop";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                //shop = ShopName;
                {
                    if (shoptype == 1)
                    {
                        shop = "Blocks1";
                    }
                    else if (shoptype == 2)
                    {
                        shop = "Blocks2";
                    }
                    else if (shoptype == 3)
                    {
                        shop = "Furniture";
                    }
                    else
                    {
                        shop = "Plant";
                    }
                }
            }
            else if (!firstButton)
            {
                if (shoptype < 4)
                {
                    shoptype++;
                }
                else
                {
                    shoptype = 1;
                }
            }
        }
        public static List<(string, int, int, Condition, string)> shopEntries = new List<(string, int, int, Condition, string)>();

        public override void AddShops()
        {
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("WulfrumPlating"), Item.buyPrice(0, 0, 0, 20), calamity, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("LaboratoryPlating"), Item.buyPrice(0, 0, 0, 25), calamity, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("LaboratoryPanels"), Item.buyPrice(0, 0, 0, 25), calamity, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("HazardChevronPanels"), Item.buyPrice(0, 0, 0, 25), calamity, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("RustedPlating"), Item.buyPrice(0, 0, 0, 25), calamity, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("LaboratoryPipePlating"), Item.buyPrice(0, 0, 0, 25), calamity, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("RustedPipes"), Item.buyPrice(0, 0, 0, 25), calamity, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("Acidwood"), Item.buyPrice(0, 0, 5, 0), calamity, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("SulphurousSand"), Item.buyPrice(0, 0, 0, 35), calamity, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("SulphurousShale"), Item.buyPrice(0, 0, 0, 35), calamity, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("EutrophicSand"), Item.buyPrice(0, 0, 0, 50), clam, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("Navystone"), Item.buyPrice(0, 0, 0, 75), clam, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("SmoothNavystone"), Item.buyPrice(0, 0, 2, 5), clam, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("AbyssGravel"), Item.buyPrice(0, 0, 2, 5), Condition.DownedSkeletron, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("StatigelBlock"), Item.buyPrice(0, 0, 3, 5), sg, ""));
            shopEntries.Add(("Blocks1", ItemType<AstralGrass>(), Item.buyPrice(0, 0, 0, 10), Condition.Hardmode, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("AstralMonolith"), Item.buyPrice(0, 0, 2, 5), Condition.Hardmode, ""));
            shopEntries.Add(("Blocks1", ItemType<AstralPearlBlock>(), Item.buyPrice(0, 0, 3, 0), Condition.Hardmode, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("BrimstoneSlag"), Item.buyPrice(0, 0, 4, 0), brim, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("ScorchedRemains"), Item.buyPrice(0, 0, 4, 0), brim, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("PyreMantle"), Item.buyPrice(0, 0, 4, 50), Condition.DownedGolem, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("MoltenPyreMantle"), Item.buyPrice(0, 0, 4, 50),Condition.DownedGolem, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("Voidstone"), Item.buyPrice(0, 0, 5, 0), Condition.DownedGolem, ""));
            shopEntries.Add(("Blocks1", CalValEX.CalamityItem("PlaguedContainmentBrick"), Item.buyPrice(0, 0, 5, 0), pb, ""));
            shopEntries.Add(("Blocks1", ItemType<PlagueHiveWand>(), Item.buyPrice(0, 1, 40, 0), pb, ""));
            shopEntries.Add(("Blocks1", ItemType<Items.Walls.PlagueHiveWall>(), Item.buyPrice(0, 0, 0, 10), pb, ""));
            shopEntries.Add(("Blocks1", ItemType<Necrostone>(), Item.buyPrice(0, 0, 10, 0), rav, ""));

            shopEntries.Add(("Blocks2", CalValEX.CalamityItem("UelibloomBrick"), Item.buyPrice(0, 0, 20, 0), prov, ""));
            shopEntries.Add(("Blocks2", CalValEX.CalamityItem("ProfanedRock"), Item.buyPrice(0, 0, 66, 66), prov, ""));
            shopEntries.Add(("Blocks2", CalValEX.CalamityItem("ProfanedCrystal"), Item.buyPrice(0, 6, 66, 66), prov, ""));
            shopEntries.Add(("Blocks2", ItemType<ChiseledBloodstone>(), Item.buyPrice(0, 0, 40, 0), prov, ""));
            shopEntries.Add(("Blocks2", ItemType<PhantowaxBlock>(), Item.buyPrice(0, 0, 50, 0), polt, ""));
            shopEntries.Add(("Blocks2", ItemType<EidolicSlab>(), Item.buyPrice(0, 1, 0, 0), polt, ""));
            shopEntries.Add(("Blocks2", CalValEX.CalamityItem("StratusBricks"), Item.buyPrice(0, 0, 80, 0), polt, ""));
            shopEntries.Add(("Blocks2", ItemType<AzufreSludge>(), Item.buyPrice(0, 0, 50, 0), boomer, ""));
            shopEntries.Add(("Blocks2", CalValEX.CalamityItem("CosmiliteBrick"), Item.buyPrice(0, 0, 80, 0), dog, ""));
            shopEntries.Add(("Blocks2", CalValEX.CalamityItem("OtherworldlyStone"), Item.buyPrice(0, 0, 90, 0), dog, ""));
            shopEntries.Add(("Blocks2", CalValEX.CalamityItem("SilvaCrystal"), Item.buyPrice(0, 1, 0, 0), dog, ""));
            shopEntries.Add(("Blocks2", ItemType<AuricBrick>(), Item.buyPrice(0, 1, 50, 0), yharon, ""));
            shopEntries.Add(("Blocks2", CalValEX.CalamityItem("ExoPlating"), Item.buyPrice(0, 2, 0, 0), exo, ""));
            shopEntries.Add(("Blocks2", CalValEX.CalamityItem("ExoPrismPanel"), Item.buyPrice(0, 2, 0, 0), exo, ""));
            shopEntries.Add(("Blocks2", CalValEX.CalamityItem("OccultBrickItem"), Item.buyPrice(0, 2, 0, 0), scal, ""));

            shopEntries.Add(("Furniture", ItemType<Items.Tiles.Statues.C>(), Item.buyPrice(0, 1, 0, 0), Condition.NpcIsPresent(NPC.type), ""));
            shopEntries.Add(("Furniture", ItemType<Items.Tiles.FurnitureSets.Wulfrum.WulfrumGlobe>(), Item.buyPrice(0, 1, 0, 0), Condition.NpcIsPresent(NPC.type), ""));
            shopEntries.Add(("Furniture", CalValEX.CalamityItem("LaboratoryConsoleItem"), Item.buyPrice(0, 2, 50, 0), calamity, ""));
            shopEntries.Add(("Furniture", ItemType<SulphurGeyser>(), Item.buyPrice(0, 0, 10, 0), calamity, ""));
            shopEntries.Add(("Furniture", ItemType<SunkenLamp>(), Item.buyPrice(0, 0, 50, 0), clam, ""));
            shopEntries.Add(("Furniture", ItemType<Knight>(), Item.buyPrice(0, 0, 95, 0), Condition.Hardmode, ""));
            shopEntries.Add(("Furniture", ItemType<DecommissionedDaedalusGolem>(), Item.buyPrice(0, 2, 50, 0), cirno, ""));
            shopEntries.Add(("Furniture", ItemType<AuroraMonolith>(), Item.buyPrice(0, 4, 0, 0), cirno, ""));
            shopEntries.Add(("Furniture", ItemType<CalamitousMonolith>(), Item.buyPrice(0, 5, 0, 0), cala, ""));
            shopEntries.Add(("Furniture", ItemType<VeilBanner>(), Item.buyPrice(0, 4, 0, 0), Condition.DownedPlantera, ""));
            shopEntries.Add(("Furniture", ItemType<JunkArt>(), Item.buyPrice(0, 4, 0, 0), Condition.DownedPlantera, ""));
            shopEntries.Add(("Furniture", ItemType<HeartoftheCommunity>(), Item.buyPrice(0, 2, 0, 0), lev, ""));
            shopEntries.Add(("Furniture", ItemType<ShrineoftheTides>(), Item.buyPrice(0, 5, 0, 0), lev, ""));
            shopEntries.Add(("Furniture", ItemType<AquaticMonolith>(), Item.buyPrice(0, 6, 0, 0), lev, ""));
            shopEntries.Add(("Furniture", ItemType<PlagueMonolith>(), Item.buyPrice(0, 7, 0, 0), pb, ""));
            shopEntries.Add(("Furniture", ItemType<BubbleMachine>(), Item.buyPrice(0, 35, 0, 0), Condition.DownedMartians, ""));
            shopEntries.Add(("Furniture", ItemType<PlagueDialysis>(), Item.buyPrice(0, 1, 50, 0), jun, ""));
            shopEntries.Add(("Furniture", ItemType<Provibust>(), Item.buyPrice(1, 50, 0, 0), prov, ""));
            shopEntries.Add(("Furniture", ItemType<UnholyMonolith>(), Item.buyPrice(0, 40, 0, 0), prov, ""));
            shopEntries.Add(("Furniture", ItemType<Tesla>(), Item.buyPrice(2, 75, 0, 0), weavie, ""));
            shopEntries.Add(("Furniture", ItemType<Evolution>(), Item.buyPrice(1, 75, 0, 0), toaster, ""));
            shopEntries.Add(("Furniture", ItemType<VoidPortal>(), Item.buyPrice(2, 75, 0, 0), toaster, ""));
            shopEntries.Add(("Furniture", ItemType<MireAquarium>(), Item.buyPrice(2, 0, 0, 0), boomer, ""));
            shopEntries.Add(("Furniture", ItemType<SulphuricTank>(), Item.buyPrice(0, 50, 0, 0), boomer, ""));
            shopEntries.Add(("Furniture", ItemType<Help>(), Item.buyPrice(76, 0, 0, 0), boomer, ""));
            shopEntries.Add(("Furniture", ItemType<DimensionalMonolith>(), Item.buyPrice(0, 13, 0, 0), dog, ""));
            shopEntries.Add(("Furniture", ItemType<InfernalMonolith>(), Item.buyPrice(0, 15, 0, 0), yharon, ""));
            shopEntries.Add(("Furniture", ItemType<SamLog>(), Item.buyPrice(5, 0, 0, 0), sammy, ""));
            shopEntries.Add(("Furniture", ItemType<ExoMonolith>(), Item.buyPrice(0, 30, 0, 0), exo, ""));
            shopEntries.Add(("Furniture", ItemType<BrimstoneHeart>(), Item.buyPrice(0, 20, 0, 0), scal, ""));
            shopEntries.Add(("Furniture", ItemType<CalamitasBanner>(), Item.buyPrice(0, 60, 0, 0), scal, ""));
            shopEntries.Add(("Furniture", ItemType<DemonShield>(), Item.buyPrice(0, 60, 0, 0), scal, ""));
            shopEntries.Add(("Furniture", ItemType<Se>(), Item.buyPrice(6, 66, 66, 66), scal, ""));

            shopEntries.Add(("Plant", ItemType<FleshThing>(), Item.buyPrice(0, 0, 60, 0), Condition.NpcIsPresent(NPC.type), ""));
            shopEntries.Add(("Plant", ItemType<Anemone>(), Item.buyPrice(0, 0, 60, 0), clam, ""));
            shopEntries.Add(("Plant", ItemType<BrainCoral>(), Item.buyPrice(0, 0, 60, 0), clam, ""));
            shopEntries.Add(("Plant", ItemType<FanCoral>(), Item.buyPrice(0, 0, 60, 0), clam, ""));
            shopEntries.Add(("Plant", ItemType<SSCoral>(), Item.buyPrice(0, 0, 60, 0), clam, ""));
            shopEntries.Add(("Plant", ItemType<TableCoral>(), Item.buyPrice(0, 0, 60, 0), clam, ""));
            shopEntries.Add(("Plant", ItemType<SulphurousCactus>(), Item.buyPrice(0, 0, 30, 0), acid, ""));
            shopEntries.Add(("Plant", ItemType<SulphurousPlanter>(), Item.buyPrice(0, 0, 40, 0), acid, ""));
            shopEntries.Add(("Plant", ItemType<PottedDecapoditaSprout>(), Item.buyPrice(0, 0, 50, 0), crab, ""));
            shopEntries.Add(("Plant", ItemType<MonolithPot>(), Item.buyPrice(0, 0, 95, 0), Condition.Hardmode, ""));
            shopEntries.Add(("Plant", ItemType<BelchingCoral>(), Item.buyPrice(0, 2, 0, 0), aqua, ""));
            shopEntries.Add(("Plant", ItemType<AstralOldPurple>(), Item.buyPrice(0, 1, 0, 0), ass, ""));
            shopEntries.Add(("Plant", ItemType<AstralOldYellow>(), Item.buyPrice(0, 1, 0, 0), ass, ""));
            shopEntries.Add(("Plant", ItemType<BotanicPot>(), Item.buyPrice(0, 20, 0, 0), prov, ""));
            shopEntries.Add(("Plant", ItemType<HolyStudedBonsai>(), Item.buyPrice(0, 20, 0, 0), prov, ""));
            shopEntries.Add(("Plant", ItemType<BloodstoneRoses>(), Item.buyPrice(0, 20, 0, 0), prov, ""));
            shopEntries.Add(("Plant", ItemType<NetherTree>(), Item.buyPrice(1, 75, 0, 0), siggy, ""));
            shopEntries.Add(("Plant", ItemType<NetherTreeBig>(), Item.buyPrice(2, 75, 0, 0), siggy, ""));
            shopEntries.Add(("Plant", ItemType<EidolonTree>(), Item.buyPrice(0, 50, 0, 0), polt, ""));

            var blockShop = new NPCShop(Type, "Blocks1");
            var blockShop2 = new NPCShop(Type, "Blocks2");
            var furnShop = new NPCShop(Type, "Furniture");
            var plantShop = new NPCShop(Type, "Plant");

            for (int i = 0; i < shopEntries.Count; i++)
            {
                var shop = blockShop;
                if (shopEntries[i].Item2 > -1)
                {
                    if (blockShop.Name == shopEntries[i].Item1)
                    {
                        shop = blockShop;
                    }
                    if (blockShop2.Name == shopEntries[i].Item1)
                    {
                        shop = blockShop2;
                    }
                    if (furnShop.Name == shopEntries[i].Item1)
                    {
                        shop = furnShop;
                    }
                    if (plantShop.Name == shopEntries[i].Item1)
                    {
                        shop = plantShop;
                    }
                    shop.Add(shopEntries[i].Item2, shopEntries[i].Item4);
                }
            }
            blockShop.Register();
            blockShop2.Register();
            furnShop.Register();
            plantShop.Register();
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void ModifyActiveShop(string shopName, Item[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                Item item = items[i];
                // Skip 'air' items and null items.
                if (item == null || item.type == ItemID.None)
                {
                    continue;
                }

                for (int j = 0; j < shopEntries.Count; j++)
                {
                    if (shopEntries[j].Item2 > -1)
                    {
                        if (item.type == shopEntries[j].Item2)
                        {
                            item.shopCustomPrice = shopEntries[j].Item3;
                        }
                    }       
                }
            }
        }

        public override bool CanGoToStatue(bool toKingStatue)
        {
            return false;
        }

        public override void OnGoToStatue(bool toKingStatue)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                ModPacket packet = Mod.GetPacket();
                packet.Write((byte)NPC.whoAmI);
                packet.Send();
            }
            else
            {
                StatueTeleport();
            }
        }

        public void StatueTeleport()
        {
            for (int i = 0; i < 30; i++)
            {
                Vector2 position = Main.rand.NextVector2Square(-20, 21);
                if (Math.Abs(position.X) > Math.Abs(position.Y))
                {
                    position.X = Math.Sign(position.X) * 20;
                }
                else
                {
                    position.Y = Math.Sign(position.Y) * 20;
                }
                Dust.NewDustPerfect(NPC.Center + position, 50, Vector2.Zero).noGravity = true;
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 9;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 16;
            randExtraCooldown = 16;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ModContent.ProjectileType<InkShot>();
            attackDelay = 1;
            return;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            randomOffset = 2f;
            multiplier = 24f;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            /*if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.position, NPC.velocity, Mod.GetGoreSlot("Gores/JellyPriest"), 1f);
                Gore.NewGore(NPC.position, NPC.velocity, mod.GetGoreSlot("Gores/JellyPriest2"), 1f);
                Gore.NewGore(NPC.position, NPC.velocity, mod.GetGoreSlot("Gores/JellyPriest3"), 1f);
            }*/
        }
        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(shoptype);
        }
        public override void ReceiveExtraAI(BinaryReader reader)
        {
            shoptype = reader.ReadInt32();
        }
    }
}
