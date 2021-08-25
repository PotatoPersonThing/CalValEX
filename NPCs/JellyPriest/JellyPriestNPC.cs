using CalamityMod.CalPlayer;
using CalValEX.Items.Tiles;
using CalValEX.Items.Tiles.Banners;
using CalValEX.Items.Tiles.Blocks;
using CalValEX.Items.Tiles.Blueprints;
using CalValEX.Items.Tiles.FurnitureSets.Arsenal;
using CalValEX.Items.Tiles.FurnitureSets.Wulfrum;
using CalValEX.Items.Tiles.Plants;
using CalValEX.Items.Tiles.Statues;
using CalValEX.Items.Walls;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Projectiles.NPCs;

namespace CalValEX.NPCs.JellyPriest
{
    [AutoloadHead]
    public class JellyPriestNPC : ModNPC
    {
        private static bool shop1;

        private static bool shop2;

        public override string Texture => "CalValEX/NPCs/JellyPriest/JellyPriestNPC";
        public override string[] AltTextures => new[] { "CalValEX/NPCs/JellyPriest/JellyPriestNPC_Alt" };

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jelly Priestess");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 15;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Mechanic;
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
            npc.breath += 2;
            if (CalValEXConfig.Instance.TownNPC)
            {
                npc.active = false;
            }
        }

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(14))
            {
                case 0:
                    return "Eika";

                case 1:
                    return "Feferi";

                case 3:
                    return "Netlia";

                case 4:
                    return "Atollia";

                case 5:
                    return "Melodi";

                case 6:
                    return "Signathia";

                case 7:
                    return "Manawa";

                case 8:
                    return "Kanji";

                case 9:
                    return "Mariacala";

                case 10:
                    return "Cuboza";

                case 11:
                    return "Nidaria";

                case 12:
                    return "Crasqua";

                default:
                    return "Ooma";
            }
        }

        public override string GetChat()
        {
            Player player = Main.player[Main.myPlayer];
            CalValEXPlayer CalValEXPlayer = player.GetModPlayer<CalValEXPlayer>();

            CalamityPlayer calPlayer = player.GetModPlayer<CalamityPlayer>();

            if (NPC.AnyNPCs((ModLoader.GetMod("CalamityMod").NPCType("Siren"))))
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return "Oh my Xeroc! It's her! I have to wrap up preparations quickly!";

                    default:
                        return "After all of my preparations, she is finally here! Anahita of the Tides!";
                }
            }

            if (CalValEXPlayer.sirember)
            {
                return "WHAT IS THAT HORRIBLE MONSTROSITY";
            }

            if (npc.homeless)
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

            int FAP = NPC.FindFirstNPC((ModLoader.GetMod("CalamityMod").NPCType("FAP")));
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

            int SEAHOE = NPC.FindFirstNPC((ModLoader.GetMod("CalamityMod").NPCType("SEAHOE")));
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
            Mod clamMod = ModLoader.GetMod("CalamityMod");
            if (((bool)clamMod.Call("GetBossDowned", "anahitaleviathan")) && Main.rand.NextFloat() < 0.25f && !NPC.AnyNPCs((ModLoader.GetMod("CalamityMod").NPCType("Siren"))))
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return "Oh! So you did find the location of the deity I'm searching for? Please explain in detail everything about them, I would love to start working on my offerings and monuments as soon as possible.";

                    default:
                        return "For some reason, the goddess' presence feels like it's weakened. I hope nothing bad happened to her.";
                }
            }

            if ((calPlayer.sirenWaifu || calPlayer.elementalHeart) && Main.rand.NextFloat() < 0.25f)
            {
                return "You were successfully able to befriend the grand Water Elemental? I'm impressed.";
            }

            if ((calPlayer.sirenBoobs && !calPlayer.sirenBoobsHide) && Main.rand.NextFloat() < 0.25f)
            {
                return "OH! Please, welcome yourself to my shop. I've been preparing these just for you.";
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
                            return "I would love to decorate your place for free, but I require some coins for buying offerings you know?.";

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
            button = "Decorations";
            button2 = "Blocks";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
                {
                    shop1 = true;
                    shop2 = false;
                }
            }
            else if (!firstButton)
            {
                shop = true;
                {
                    shop2 = true;
                    shop1 = false;
                }
            }
        }

        public static void AddItem(bool check, string mod, string item, int price, ref Chest shop, ref int nextSlot)
        {
            if (shop1)
            {
                Mod calamityMod = ModLoader.GetMod("CalamityMod");
                shop.item[nextSlot].SetDefaults(ItemType<Items.Tiles.Statues.C>());
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 0, 0);
                nextSlot++;
                Mod clamMod = ModLoader.GetMod("CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
                if (clamMod != null)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<WulfrumGlobe>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 10, 0);
                    ++nextSlot;

                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("LaboratoryConsoleItem"));
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 3, 0, 0);
                    ++nextSlot;

                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<AgedRustGamingTable>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 15, 0, 0);
                    ++nextSlot;

                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<RustGamingTable>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 15, 0, 0);
                    ++nextSlot;

                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<RustGamingTable2>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 15, 0, 0);
                    ++nextSlot;

                    if ((bool)clamMod.Call("GetInZone", Main.player[Main.myPlayer], "sulphursea") || (bool)clamMod.Call("GetBossDowned", "acidrainscourge"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.SulphurGeyser>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 10, 0);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.SulphurColumn>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 5, 0);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.Ribrod>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 50, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "giantclam"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.SunkenLamp>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 50, 0);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.Plants.Anemone>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 20, 0);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.Plants.BrainCoral>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 20, 0);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.Plants.FanCoral>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 20, 0);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.Plants.SSCoral>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 20, 0);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.Plants.BrainCoral>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 20, 0);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.Plants.TableCoral>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 20, 0);
                        ++nextSlot;
                    }
                    if (Main.hardMode == true)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.RoxFake>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 0, 0);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.Plants.MonolithPot>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 95, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "acidrainscourge"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.Plants.BelchingCoral>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 2, 0, 0);
                        ++nextSlot;
                    }
                    if (NPC.downedPlantBoss)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<JunkArt>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 10, 0, 0);
                        ++nextSlot;
                    }
                    if (NPC.downedPlantBoss || ((bool)clamMod.Call("GetBossDowned", "calamitas")))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<VeilBanner>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5, 0, 0);
                        ++nextSlot;
                    }
                    if (((bool)clamMod.Call("GetBossDowned", "leviathan")) && Main.expertMode)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<HeartoftheCommunity>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(2, 0, 0, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "astrumaureus"))
                    {
                        if (!Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneAstral && Main.expertMode)
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstralOldPurple>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 0, 0, 0);
                            ++nextSlot;
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstralOldYellow>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 0, 0, 0);
                            ++nextSlot;
                        }
                        else if (Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneAstral)
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstralOldPurple>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 0, 0);
                            ++nextSlot;
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstralOldYellow>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 0, 0);
                            ++nextSlot;
                        }
                        else
                            return;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "plaguebringergoliath"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<PlagueDialysis>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 0, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "providence"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Provibust>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 50, 0, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "stormweaver"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Tesla>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(2, 75, 0, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "ceaselessvoid"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<VoidPortal>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(2, 75, 0, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "signus"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<NetherTree>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(2, 5, 0, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "polterghast") && Main.expertMode)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<EidolonTree>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 50, 0, 0);
                        ++nextSlot;
                    }
                    if (Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().HellLab && Main.LocalPlayer.ZoneUnderworldHeight)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<SamLog>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(5, 0, 0, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "oldduke") && Main.expertMode)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<SulphuricTank>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 50, 0, 0);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Help>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(76, 0, 0, 0);
                        ++nextSlot;
                    }
                }
            }
            else if (shop2)
            {
                Mod calamityMod = ModLoader.GetMod("CalamityMod");
                Mod clamMod = ModLoader.GetMod("CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
                if (clamMod != null)
                {
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("LaboratoryPlating"));
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 25);
                    ++nextSlot;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("LaboratoryPanels"));
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 25);
                    ++nextSlot;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("HazardChevronPanels"));
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 25);
                    ++nextSlot;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("RustedPlating"));
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 25);
                    ++nextSlot;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("RustedPipes"));
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 25);
                    ++nextSlot;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("LaboratoryPipePlating"));
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 25);
                    ++nextSlot;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("SulphurousSandstone"));
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 35);
                    ++nextSlot;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("HardenedSulphurousSandstone"));
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 50);
                    ++nextSlot;
                    if ((bool)clamMod.Call("GetBossDowned", "giantclam"))
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("EutrophicSand"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 5, 5);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("SmoothNavystone"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 2, 5);
                        ++nextSlot;
                    }
                    if (NPC.downedBoss3)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("AbyssGravel"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 2, 5);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "slimegod"))
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("StatigelBlock"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 3, 5);
                        ++nextSlot;
                    }
                    if (Main.hardMode == true)
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<AstralGrass>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 10);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("AstralMonolith"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 2, 5);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ItemType<AstralPearlBlock>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 3, 0);
                        nextSlot++;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "brimstoneelemental"))
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("BrimstoneSlag"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 3, 5);
                        ++nextSlot;
                    }
                    if (NPC.downedGolemBoss)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("Voidstone"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 10, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "plaguebringergoliath"))
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("PlaguedPlate"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 30, 0);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ItemType<PlagueHiveWand>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 40, 0);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ItemType<PlagueHiveWall>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 10);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "ravager"))
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<Necrostone>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 40, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "providence"))
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("UelibloomBrick"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 50, 0);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("ProfanedRock"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 66, 66);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("ProfanedCrystal"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 6, 66, 66);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ItemType<ChiseledBloodstone>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 80, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "polterghast"))
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<PhantowaxBlock>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 90, 0);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ItemType<EidolicSlab>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 0, 0);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("StratusBricks"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 0, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "devourerofgods"))
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("CosmiliteBrick"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 2, 0, 0);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("OccultStone"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 3, 0, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "buffedmothron"))
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("SilvaCrystal"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5, 0, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "yharon"))
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<AuricBrick>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 30, 0, 0);
                        ++nextSlot;
                    }
                }
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (shop1)
            {
                Mod calamityMod = ModLoader.GetMod("CalamityMod");
                shop.item[nextSlot].SetDefaults(ItemType<Items.Tiles.Statues.C>());
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 0, 0);
                nextSlot++;
                Mod clamMod = ModLoader.GetMod("CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
                if (clamMod != null)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<WulfrumGlobe>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 10, 0);
                    ++nextSlot;

                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("LaboratoryConsoleItem"));
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 3, 0, 0);
                    ++nextSlot;

                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<AgedRustGamingTable>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 15, 0, 0);
                    ++nextSlot;

                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<RustGamingTable>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 15, 0, 0);
                    ++nextSlot;

                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<RustGamingTable2>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 15, 0, 0);
                    ++nextSlot;

                    if ((bool)clamMod.Call("GetInZone", Main.player[Main.myPlayer], "sulphursea") || (bool)clamMod.Call("GetBossDowned", "acidrainscourge"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.SulphurGeyser>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 10, 0);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.SulphurColumn>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 5, 0);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.Ribrod>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 50, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "giantclam"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.SunkenLamp>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 50, 0);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.Plants.Anemone>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 20, 0);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.Plants.BrainCoral>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 20, 0);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.Plants.FanCoral>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 20, 0);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.Plants.SSCoral>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 20, 0);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.Plants.BrainCoral>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 20, 0);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.Plants.TableCoral>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 20, 0);
                        ++nextSlot;
                    }
                    if (Main.hardMode == true)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.RoxFake>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 0, 0);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.Plants.MonolithPot>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 95, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "acidrainscourge"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Tiles.Plants.BelchingCoral>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 2, 0, 0);
                        ++nextSlot;
                    }
                    if (NPC.downedPlantBoss)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<JunkArt>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 10, 0, 0);
                        ++nextSlot;
                    }
                    if (NPC.downedPlantBoss || ((bool)clamMod.Call("GetBossDowned", "calamitas")))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<VeilBanner>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5, 0, 0);
                        ++nextSlot;
                    }
                    if (((bool)clamMod.Call("GetBossDowned", "leviathan")) && Main.expertMode)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<HeartoftheCommunity>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(2, 0, 0, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "astrumaureus"))
                    {
                        if (!Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneAstral && Main.expertMode)
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstralOldPurple>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 0, 0, 0);
                            ++nextSlot;
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstralOldYellow>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 0, 0, 0);
                            ++nextSlot;
                        }
                        else if (Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneAstral)
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstralOldPurple>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 0, 0);
                            ++nextSlot;
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstralOldYellow>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 0, 0);
                            ++nextSlot;
                        }
                        else
                            return;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "plaguebringergoliath"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<PlagueDialysis>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 0, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "providence"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Provibust>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 50, 0, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "stormweaver"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Tesla>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(2, 75, 0, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "ceaselessvoid"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<VoidPortal>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(2, 75, 0, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "signus"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<NetherTree>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(2, 5, 0, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "polterghast") && Main.expertMode)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<EidolonTree>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 50, 0, 0);
                        ++nextSlot;
                    }
                    if (Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().HellLab && Main.LocalPlayer.ZoneUnderworldHeight)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<SamLog>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(5, 0, 0, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "oldduke") && Main.expertMode)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Help>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(76, 0, 0, 0);
                        ++nextSlot;
                    }
                }
            }
            else if (shop2)
            {
                Mod calamityMod = ModLoader.GetMod("CalamityMod");
                Mod clamMod = ModLoader.GetMod("CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
                if (clamMod != null)
                {
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("LaboratoryPlating"));
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 25);
                    ++nextSlot;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("LaboratoryPanels"));
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 25);
                    ++nextSlot;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("HazardChevronPanels"));
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 25);
                    ++nextSlot;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("RustedPlating"));
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 25);
                    ++nextSlot;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("RustedPipes"));
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 25);
                    ++nextSlot;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("LaboratoryPipePlating"));
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 25);
                    ++nextSlot;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("SulphurousSandstone"));
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 35);
                    ++nextSlot;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("HardenedSulphurousSandstone"));
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 50);
                    ++nextSlot;
                    if ((bool)clamMod.Call("GetBossDowned", "giantclam"))
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("EutrophicSand"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 5, 5);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("SmoothNavystone"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 2, 5);
                        ++nextSlot;
                    }
                    if (NPC.downedBoss3)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("AbyssGravel"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 2, 5);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "slimegod"))
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("StatigelBlock"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 3, 5);
                        ++nextSlot;
                    }
                    if (Main.hardMode == true)
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<AstralGrass>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 10);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("AstralMonolith"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 2, 5);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ItemType<AstralPearlBlock>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 3, 0);
                        nextSlot++;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "brimstoneelemental"))
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("BrimstoneSlag"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 3, 5);
                        ++nextSlot;
                    }
                    if (NPC.downedGolemBoss)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("Voidstone"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 10, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "plaguebringergoliath"))
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("PlaguedPlate"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 30, 0);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ItemType<PlagueHiveWand>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 40, 0);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ItemType<PlagueHiveWall>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 10);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "ravager"))
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<Necrostone>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 40, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "providence"))
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("UelibloomBrick"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 50, 0);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("ProfanedRock"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 66, 66);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("ProfanedCrystal"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 6, 66, 66);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ItemType<ChiseledBloodstone>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 80, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "polterghast"))
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<PhantowaxBlock>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 90, 0);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ItemType<EidolicSlab>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 0, 0);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("StratusBricks"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 0, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "devourerofgods"))
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("CosmiliteBrick"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 2, 0, 0);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("OccultStone"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 3, 0, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "buffedmothron"))
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("SilvaCrystal"));
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5, 0, 0);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "yharon"))
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<AuricBrick>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 30, 0, 0);
                        ++nextSlot;
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
                ModPacket packet = mod.GetPacket();
                packet.Write((byte)npc.whoAmI);
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
                Dust.NewDustPerfect(npc.Center + position, 50, Vector2.Zero).noGravity = true;
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 9;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 20;
            randExtraCooldown = 20;
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
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/JellyPriest"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/JellyPriest2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/JellyPriest3"), 1f);
            }
        }
    }
}