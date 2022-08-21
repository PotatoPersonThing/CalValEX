using CalamityMod.CalPlayer;
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
using CalamityMod.World;
using CalamityMod;
using Terraria.GameContent.Personalities;
using CalValEX.Items.Tiles.FurnitureSets.Arsenal;

namespace CalValEX.NPCs.JellyPriest
{
    [AutoloadHead]
    public class JellyPriestNPC : ModNPC
    {
        private static bool shop1;

        private static bool shop2;

        private static bool shop3;

        public int shoptype = 1;

        public override string Texture => "CalValEX/NPCs/JellyPriest/JellyPriestNPC";
       // public override string[] AltTextures => new[] { "CalValEX/NPCs/JellyPriest/JellyPriestNPC_Alt" };

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jelly Priestess");
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
				new FlavorTextBestiaryInfoElement("A jellyfish that took an odd evolutionary turn. Her affinity for building synergizes with her devotion to a forgotten goddess."),
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

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        { 
            if (CalValEXWorld.rescuedjelly && !CalValEXConfig.Instance.TownNPC)
            {
                jellyspawn = true;
            }
            return jellyspawn;
        }

        public override void AI()
        {
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

        public override string GetChat()
        {
            Player player = Main.player[Main.myPlayer];
            CalValEXPlayer CalValEXPlayer = player.GetModPlayer<CalValEXPlayer>();

            CalamityPlayer calPlayer = player.GetModPlayer<CalamityPlayer>();

            if (NPC.AnyNPCs(NPCType<CalamityMod.NPCs.Leviathan.Anahita>()))
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
                        return "Greetings, land creature! I rise from this old sea in hopes of traveling and finding a certain deity from the old times, from when the sea was a beautiful reign for many. Do you have any hint about where I could find them?";
                }
            }

            //Main.NewText("MISC EQUIPS 0 TYPE: " + Main.player[Main.myPlayer].miscEquips[0].type + "|MISC EQUIPS 1 TYPE: " + Main.player[Main.myPlayer].miscEquips[1].type);

            int FAP = NPC.FindFirstNPC(NPCType<CalamityMod.NPCs.TownNPCs.FAP>());
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

            int WITCH = NPC.FindFirstNPC(NPCType<CalamityMod.NPCs.TownNPCs.WITCH>());
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

            int SEAHOE = NPC.FindFirstNPC(NPCType<CalamityMod.NPCs.TownNPCs.SEAHOE>());
            if (SEAHOE >= 0 && Main.rand.NextFloat() < 0.25f)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return "The great sea king I've heard many tales of... And you say that you found him inside a clam...? Oh my, isn't that pathetic now.";

                    default:
                        return "Do you think Amidias knows anything about the sea deity I'm searching? It seems that old horse got a lot of knowledge about story.";
                }
            }
            if (DownedBossSystem.downedLeviathan && Main.rand.NextFloat() < 0.25f && !NPC.AnyNPCs(NPCType<CalamityMod.NPCs.Leviathan.Anahita>()))
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return "Oh! So you did find the location of the deity I'm searching for? Please explain in detail everything about them, I would love to start working on my offerings and monuments as soon as possible.";

                    default:
                        return "For some reason, the goddess' presence feels like it's weakened. I hope nothing bad happened to her.";
                }
            }

            if (DownedBossSystem.downedSCal && Main.rand.NextFloat() < 0.25f)
            {
                    return "Yeesh, through all of your adventures, I've stocked up quite the inventory!";
            }

            if ((calPlayer.sirenWaifu || calPlayer.elementalHeart || (CalValEXPlayer.vanityhote && !CalValEXConfig.Instance.HeartVanity) || (CalValEXPlayer.vanitysiren && !CalValEXConfig.Instance.HeartVanity)) && Main.rand.NextFloat() < 0.25f)
            {
                return "You were successfully able to befriend the grand Water Elemental? I'm impressed.";
            }

            if ((calPlayer.aquaticHeart && !calPlayer.aquaticHeartHide) && Main.rand.NextFloat() < 0.25f)
            {
                return "OH! Please, welcome yourself to my shop. I've been preparing these just for you.";
            }

            if (calPlayer.cirrusDress && Main.rand.NextFloat() < 0.25f)
            {
                return "That's a pretty dress! I know someone who was working on a similar one, but it took so long that they gave up.";
            }

            if ((calPlayer.sirenPet) && Main.rand.NextFloat() < 0.25f)
            {
                return "Awe, that little one is cute. She reminds me a lot of the deity I seek.";
            }

            if ((CalValEXPlayer.babywaterclone) && Main.rand.NextFloat() < 0.25f)
            {
                return "That little one has a presence that feels similar, but different to the deity I seek.";
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
                        return "Parties are fun! Hopefully one day, I can help make one which will catch the eye of the goddess I seek.";

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
                            return "I wonder if the deity I seek watches the moon like I do.";
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
                button = "General";
            else if (shoptype == 3)
                button = "Plants";
            else 
                button = "Blocks";
            button2 = "Switch Shop";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
                {
                    if (shoptype == 1)
                    {
                        shop1 = true;
                        shop2 = false;
                        shop3 = false;
                    }
                    else if (shoptype == 2)
                    {
                        shop1 = false;
                        shop2 = true;
                        shop3 = false;
                    }
                    else
                    {
                        shop1 = false;
                        shop2 = false;
                        shop3 = true;
                    }
                }
            }
            else if (!firstButton)
            {
                shop = false;
                if (shoptype < 3)
                {
                    shoptype++;
                }
                else
                {
                    shoptype = 1;
                }
            }
        }

        public static void AddItem(int item, int price, bool condition, ref Chest shop, ref int nextSlot)
        {
            if (condition)
            {
                shop.item[nextSlot].SetDefaults(item);
                shop.item[nextSlot].shopCustomPrice = price;
                nextSlot++;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            //if (shop1)
            //Mod clamMod = ModLoader.GetMod("CalamityMod");
            bool acid = Main.player[Main.myPlayer].GetModPlayer<CalamityPlayer>().ZoneSulphur || DownedBossSystem.downedAquaticScourgeAcidRain;
            bool clam = DownedBossSystem.downedCLAM;
            bool sg = DownedBossSystem.downedSlimeGod;
            bool lev = DownedBossSystem.downedLeviathan;
            bool pb = DownedBossSystem.downedPlaguebringer;
            bool prov = DownedBossSystem.downedProvidence;
            bool toaster = DownedBossSystem.downedCeaselessVoid;
            bool siggy = DownedBossSystem.downedSignus;
            bool polt = DownedBossSystem.downedPolterghast;
            bool boomer = DownedBossSystem.downedBoomerDuke;
            bool dog = DownedBossSystem.downedDoG;
            bool scal = DownedBossSystem.downedSCal;
            bool ass = Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneAstral;
            bool sammy = CalValEXWorld.hellTiles > 20 && Main.LocalPlayer.ZoneUnderworldHeight;

            if (shop1)
            {
                AddItem(ItemType<CalamityMod.Items.Placeables.DraedonStructures.LaboratoryPlating>(), Item.buyPrice(0, 0, 0, 25), true, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.DraedonStructures.LaboratoryPanels>(), Item.buyPrice(0, 0, 0, 25), true, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.DraedonStructures.HazardChevronPanels>(), Item.buyPrice(0, 0, 0, 25), true, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.DraedonStructures.RustedPlating>(), Item.buyPrice(0, 0, 0, 25), true, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.DraedonStructures.LaboratoryPipePlating>(), Item.buyPrice(0, 0, 0, 25), true, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.DraedonStructures.RustedPipes>(), Item.buyPrice(0, 0, 0, 25), true, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.Acidwood>(), Item.buyPrice(0, 0, 5, 0), true, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.SulphurousSandstone>(), Item.buyPrice(0, 0, 0, 35), true, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.HardenedSulphurousSandstone>(), Item.buyPrice(0, 0, 0, 50), true, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.EutrophicSand>(), Item.buyPrice(0, 0, 5, 5), clam, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.FurnitureEutrophic.SmoothNavystone>(), Item.buyPrice(0, 0, 2, 5), clam, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.AbyssGravel>(), Item.buyPrice(0, 0, 2, 5), NPC.downedBoss3, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.FurnitureStatigel.StatigelBlock>(), Item.buyPrice(0, 0, 3, 5), sg, ref shop, ref nextSlot);
                AddItem(ItemType<Items.Tiles.Blocks.AstralGrass>(), Item.buyPrice(0, 0, 0, 10), Main.hardMode, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.AstralMonolith>(), Item.buyPrice(0, 0, 2, 5), Main.hardMode, ref shop, ref nextSlot);
                AddItem(ItemType<Items.Tiles.Blocks.AstralPearlBlock>(), Item.buyPrice(0, 0, 3, 0), Main.hardMode, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.Voidstone>(), Item.buyPrice(0, 0, 2, 5), NPC.downedGolemBoss, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.FurniturePlagued.PlaguedContainmentBrick>(), Item.buyPrice(0, 0, 5, 0), pb, ref shop, ref nextSlot);
                AddItem(ItemType<Items.Tiles.Blocks.PlagueHiveWand>(), Item.buyPrice(0, 1, 40, 0), pb, ref shop, ref nextSlot);
                AddItem(ItemType<Items.Walls.PlagueHiveWall>(), Item.buyPrice(0, 0, 0, 10), pb, ref shop, ref nextSlot);
                AddItem(ItemType<Items.Tiles.Blocks.Necrostone>(), Item.buyPrice(0, 0, 10, 0), DownedBossSystem.downedRavager, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.UelibloomBrick>(), Item.buyPrice(0, 0, 20, 0), prov, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.FurnitureProfaned.ProfanedRock>(), Item.buyPrice(0, 0, 66, 66), prov, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.FurnitureProfaned.ProfanedCrystal>(), Item.buyPrice(0, 6, 66, 66), prov, ref shop, ref nextSlot);
                AddItem(ItemType<Items.Tiles.Blocks.ChiseledBloodstone>(), Item.buyPrice(0, 0, 40, 0), prov, ref shop, ref nextSlot);
                AddItem(ItemType<Items.Tiles.Blocks.PhantowaxBlock>(), Item.buyPrice(0, 0, 50, 0), polt, ref shop, ref nextSlot);
                AddItem(ItemType<Items.Tiles.Blocks.EidolicSlab>(), Item.buyPrice(0, 1, 0, 0), polt, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.FurnitureStratus.StratusBricks>(), Item.buyPrice(0, 0, 80, 0), polt, ref shop, ref nextSlot);
                AddItem(ItemType<Items.Tiles.Blocks.AzufreSludge>(), Item.buyPrice(0, 0, 50, 0), boomer, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.FurnitureCosmilite.CosmiliteBrick>(), Item.buyPrice(0, 0, 80, 0), dog, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.FurnitureOtherworldly.OtherworldlyStone>(), Item.buyPrice(0, 0, 90, 0), dog, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.FurnitureSilva.SilvaCrystal>(), Item.buyPrice(0, 1, 0, 0), dog, ref shop, ref nextSlot);
                AddItem(ItemType<Items.Tiles.Blocks.AuricBrick>(), Item.buyPrice(0, 1, 50, 0), DownedBossSystem.downedYharon, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.FurnitureExo.ExoPlating>(), Item.buyPrice(0, 2, 0, 0), DownedBossSystem.downedExoMechs, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.FurnitureExo.ExoPrismPanel>(), Item.buyPrice(0, 2, 0, 0), DownedBossSystem.downedExoMechs, ref shop, ref nextSlot);
            }
            else if (shop2)
            {
                AddItem(ItemType<C>(), Item.buyPrice(0, 1, 0, 0), true, ref shop, ref nextSlot);
                AddItem(ItemType<Items.Tiles.FurnitureSets.Wulfrum.WulfrumGlobe>(), Item.buyPrice(0, 1, 0, 0), true, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityMod.Items.Placeables.DraedonStructures.LaboratoryConsoleItem>(), Item.buyPrice(0, 2, 50, 0), true, ref shop, ref nextSlot);
                AddItem(ItemType<AgedRustGamingTable>(), Item.buyPrice(0, 15, 0, 0), true, ref shop, ref nextSlot);
                AddItem(ItemType<RustGamingTable>(), Item.buyPrice(0, 15, 0, 0), true, ref shop, ref nextSlot);
                AddItem(ItemType<RustGamingTable2>(), Item.buyPrice(0, 15, 0, 0), true, ref shop, ref nextSlot);
                AddItem(ItemType<SulphurColumn>(), Item.buyPrice(0, 0, 5, 0), acid, ref shop, ref nextSlot);
                AddItem(ItemType<SulphurGeyser>(), Item.buyPrice(0, 0, 10, 0), acid, ref shop, ref nextSlot);
                AddItem(ItemType<Ribrod>(), Item.buyPrice(0, 0, 50, 0), acid, ref shop, ref nextSlot);
                AddItem(ItemType<SunkenLamp>(), Item.buyPrice(0, 0, 50, 0), clam, ref shop, ref nextSlot);
                AddItem(ItemType<RoxFake>(), Item.buyPrice(0, 1, 0, 0), Main.hardMode, ref shop, ref nextSlot);
                AddItem(ItemType<Knight>(), Item.buyPrice(0, 0, 95, 0), Main.hardMode, ref shop, ref nextSlot);
                AddItem(ItemType<DecommissionedDaedalusGolem>(), Item.buyPrice(0, 2, 50, 0), DownedBossSystem.downedCryogen, ref shop, ref nextSlot);
                AddItem(ItemType<VeilBanner>(), Item.buyPrice(0, 5, 0, 0), NPC.downedPlantBoss, ref shop, ref nextSlot);
                AddItem(ItemType<JunkArt>(), Item.buyPrice(0, 10, 0, 0), NPC.downedPlantBoss, ref shop, ref nextSlot);
                AddItem(ItemType<HeartoftheCommunity>(), Item.buyPrice(0, 2, 0, 0), lev, ref shop, ref nextSlot);
                AddItem(ItemType<ShrineoftheTides>(), Item.buyPrice(0, 5, 0, 0), lev, ref shop, ref nextSlot);
                AddItem(ItemType<BubbleMachine>(), Item.buyPrice(0, 35, 0, 0), NPC.downedMartians, ref shop, ref nextSlot);
                AddItem(ItemType<PlagueDialysis>(), Item.buyPrice(0, 35, 0, 0), DownedBossSystem.downedDragonfolly, ref shop, ref nextSlot);
                AddItem(ItemType<Provibust>(), Item.buyPrice(1, 50, 0, 0), prov, ref shop, ref nextSlot);
                AddItem(ItemType<Tesla>(), Item.buyPrice(2, 75, 0, 0), DownedBossSystem.downedStormWeaver, ref shop, ref nextSlot);
                AddItem(ItemType<Evolution>(), Item.buyPrice(1, 75, 0, 0), toaster, ref shop, ref nextSlot);
                AddItem(ItemType<VoidPortal>(), Item.buyPrice(2, 75, 0, 0), toaster, ref shop, ref nextSlot);
                AddItem(ItemType<SamLog>(), Item.buyPrice(5, 0, 0, 0), sammy, ref shop, ref nextSlot);
                AddItem(ItemType<MireAquarium>(), Item.buyPrice(2, 0, 0, 0), boomer, ref shop, ref nextSlot);
                AddItem(ItemType<SulphuricTank>(), Item.buyPrice(0, 50, 0, 0), boomer, ref shop, ref nextSlot);
                AddItem(ItemType<Help>(), Item.buyPrice(76, 0, 0, 0), boomer, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityLamp>(), Item.buyPrice(0, 20, 0, 0), scal, ref shop, ref nextSlot);
                AddItem(ItemType<BrimstoneHeart>(), Item.buyPrice(0, 20, 0, 0), scal, ref shop, ref nextSlot);
                AddItem(ItemType<CalamitasBanner>(), Item.buyPrice(0, 60, 0, 0), scal, ref shop, ref nextSlot);
                AddItem(ItemType<DemonShield>(), Item.buyPrice(0, 60, 0, 0), scal, ref shop, ref nextSlot);
                AddItem(ItemType<Se>(), Item.buyPrice(6, 66, 66, 66), scal, ref shop, ref nextSlot);
            }
            else if (shop3)
            {
                AddItem(ItemType<FleshThing>(), Item.buyPrice(0, 0, 60, 0), true, ref shop, ref nextSlot);
                AddItem(ItemType<Anemone>(), Item.buyPrice(0, 0, 20, 0), clam, ref shop, ref nextSlot);
                AddItem(ItemType<BrainCoral>(), Item.buyPrice(0, 0, 20, 0), clam, ref shop, ref nextSlot);
                AddItem(ItemType<FanCoral>(), Item.buyPrice(0, 0, 20, 0), clam, ref shop, ref nextSlot);
                AddItem(ItemType<SSCoral>(), Item.buyPrice(0, 0, 20, 0), clam, ref shop, ref nextSlot);
                AddItem(ItemType<TableCoral>(), Item.buyPrice(0, 0, 20, 0), clam, ref shop, ref nextSlot);
                AddItem(ItemType<SulphurousCactus>(), Item.buyPrice(0, 0, 30, 0), acid, ref shop, ref nextSlot);
                AddItem(ItemType<SulphurousPlanter>(), Item.buyPrice(0, 0, 40, 0), acid, ref shop, ref nextSlot);
                AddItem(ItemType<PottedDecapoditaSprout>(), Item.buyPrice(0, 0, 50, 0), DownedBossSystem.downedCrabulon, ref shop, ref nextSlot);
                AddItem(ItemType<MonolithPot>(), Item.buyPrice(0, 0, 95, 0), Main.hardMode, ref shop, ref nextSlot);
                AddItem(ItemType<BelchingCoral>(), Item.buyPrice(0, 2, 0, 0), DownedBossSystem.downedAquaticScourge, ref shop, ref nextSlot);
                if (NPC.downedPlantBoss)
                {
                    AddItem(ItemType<AstralOldPurple>(), Item.buyPrice(1, 0, 0, 0), !ass, ref shop, ref nextSlot);
                    AddItem(ItemType<AstralOldPurple>(), Item.buyPrice(0, 1, 0, 0), ass, ref shop, ref nextSlot);
                    AddItem(ItemType<AstralOldYellow>(), Item.buyPrice(1, 0, 0, 0), !ass, ref shop, ref nextSlot);
                    AddItem(ItemType<AstralOldYellow>(), Item.buyPrice(0, 1, 0, 0), ass, ref shop, ref nextSlot);
                }
                AddItem(ItemType<BotanicPot>(), Item.buyPrice(0, 20, 0, 0), prov, ref shop, ref nextSlot);
                AddItem(ItemType<HolyStudedBonsai>(), Item.buyPrice(0, 20, 0, 0), prov, ref shop, ref nextSlot);
                AddItem(ItemType<BloodstoneRoses>(), Item.buyPrice(0, 20, 0, 0), prov, ref shop, ref nextSlot);
                AddItem(ItemType<NetherTree>(), Item.buyPrice(1, 75, 0, 0), siggy, ref shop, ref nextSlot);
                AddItem(ItemType<NetherTreeBig>(), Item.buyPrice(2, 75, 0, 0), siggy, ref shop, ref nextSlot);
                AddItem(ItemType<EidolonTree>(), Item.buyPrice(0, 50, 0, 0), polt, ref shop, ref nextSlot);
                AddItem(ItemType<CalamityLamp>(), Item.buyPrice(3, 50, 25, 0), scal, ref shop, ref nextSlot);
            }
            else
            {
                AddItem(ItemType<Items.Equips.Shields.Invishield>(), Item.buyPrice(8, 0, 0, 0), true, ref shop, ref nextSlot);
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

        public override void HitEffect(int hitDirection, double damage)
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
            writer.Write(shop1);
            writer.Write(shop2);
            writer.Write(shop3);
        }
        public override void ReceiveExtraAI(BinaryReader reader)
        {
            shop1 = reader.ReadBoolean();
            shop2 = reader.ReadBoolean();
            shop3 = reader.ReadBoolean();
            shoptype = reader.ReadInt32();
        }
    }
}
