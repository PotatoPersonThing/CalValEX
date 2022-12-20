using CalValEX.Items;
using CalValEX.Items.Equips.Hats;
using CalValEX.Items.Pets;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Projectiles.NPCs;
using System.Collections.Generic;
using CalamityMod.CalPlayer;
using Terraria.GameContent.Personalities;
using CalValEX.Items.Pets.TownPets;

namespace CalValEX.NPCs.Oracle
{
    [AutoloadHead]
    public class OracleNPC : ModNPC
    {
        public override string Texture => "CalValEX/NPCs/Oracle/OracleNPC";

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;

            NPC.Happiness
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like) // Example Person prefers the forest.
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike) // Example Person dislikes the snow.
                .SetNPCAffection(NPCID.BestiaryGirl, AffectionLevel.Like) // Loves living near the dryad.
                .SetNPCAffection(NPCID.ArmsDealer, AffectionLevel.Dislike) // Hates living near the demolitionist.
            ;
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

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                Terraria.GameContent.Bestiary.BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("A clairvoyant with a passion for collecting little creatures. She is accomponied by a squishy little critter that she created using her mystic powers."),
            });
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (!CalValEXConfig.Instance.TownNPC)
            {
                for (int k = 0; k < Main.maxPlayers; k++)
                {
                    Player player = Main.player[k];
                    if (!player.active)
                        continue;

                    if (player.miscEquips[0].type != ItemID.None || player.miscEquips[1].type != ItemID.None)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool rachelname = false;



        public static List<string> PossibleNames = new List<string>()
        {
            "Maddi", "Tiggy", "Gabriel", "Lex", "Gwyn", "Sammy", "Eve", "Emily", "Lilith", "Rachel", "Leah", "Rebecca", "Alex", "Mabel"
        };
        public override List<string> SetNPCNameList() => PossibleNames;

        public override string GetChat()
        {
            if (NPC.homeless)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return "I know, I know, you can't make homes for each of my buddies, but could you spare one for me?";

                    default:
                        return "I might not be very useful for your adventure, but believe me, my babies are adorable!";
                }
            }

            //Main.NewText("MISC EQUIPS 0 TYPE: " + Main.player[Main.myPlayer].miscEquips[0].type + "|MISC EQUIPS 1 TYPE: " + Main.player[Main.myPlayer].miscEquips[1].type);

            if (Main.player[Main.myPlayer].miscEquips[0].type != ItemID.None || Main.player[Main.myPlayer].miscEquips[1].type != ItemID.None)
            {
                if (Main.rand.NextFloat() < 0.25f)
                {
                    if (!Main.bloodMoon)
                    {
                        switch (Main.rand.Next(2))
                        {
                            case 0:
                                return "Aww... I love your little buddy, " + Main.player[Main.myPlayer].name + ". You take care of 'em, 'kay?";

                            default:
                                return "What a cutie you have there, punk! You better care of em', 'kay?";
                        }
                    }
                    else
                    {
                        switch (Main.rand.Next(2))
                        {
                            case 0:
                                return "You should be happy that your buddy there isn't like TUB.";

                            default:
                                return "Maybe you should start putting your buddy away, for your own safety.";
                        }
                    }
                }
            }

            //CalamityMod.CalPlayer.CalamityPlayer calPlayer = Main.LocalPlayer.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();

            if (Main.hardMode && Main.rand.NextFloat() < 0.12f)
            {
                return "Y'know, if you're trying to find a certain little Water Elemental, you may have better luck if you take a fishing trip instead of resorting to violence.";
            }

            if (NPC.AnyNPCs(ModContent.NPCType<CalamityMod.NPCs.Bumblebirb.Bumblefuck>()) && Main.rand.NextFloat() < 0.25f)
            {
                return "That little birb over there seems to have a lot of little friends you can recover!";
            }

            int WITCH = NPC.FindFirstNPC(ModContent.NPCType<CalamityMod.NPCs.TownNPCs.WITCH>());
            if (WITCH >= 0 && Main.rand.NextFloat() < 0.25f)
            {
                return "Some people may fear Calamitas, but she's got a lot of cute little ones with her like those bats and the necropede! She can't be that bad.";
            }

            int wizard = NPC.FindFirstNPC(NPCID.Wizard);
            if (wizard >= 0 && Main.rand.NextFloat() < 0.25f)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return Main.npc[wizard].GivenName + " may seem like a weird old dude with a silly costume, but his magic is real for sure.";

                    default:
                        return "Hey punk, can you talk to " + Main.npc[wizard].GivenName + "? I have a buddy that he might enjoy having!";
                }
            }

            if (Main.player[Main.myPlayer].GetModPlayer<CalamityPlayer>().cirrusDress && Main.rand.NextFloat() < 0.25f)
            {
                return "Hey, ya'd rather wear those alcohol drenched rags than something more stylish? Not judging.";
            }

            if (!Main.expertMode)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return "Y'know kid, a lot of little buddies tend to only follow those who challenge themselves. Some could say that they will only follow Experts.";

                    default:
                        return "While your current adventure gives many opportunity to find little friends, I heard that Experts attract a lot more!";
                }
            }

            if (Main.eclipse)
            {
                switch (Main.rand.Next(4))
                {
                    case 0:
                        return "I'm happy that none of my friends become as mindless as these monsters!";

                    case 1:
                        return "Hey " + Main.player[Main.myPlayer].name + ", if you see one of my babies go a little more agressive than usual, please don't hurt them.";

                    case 2:
                        return "Hey punk! Promise me to protect me and my buddies, alright?";

                    default:
                        return "I sure am glad that my friends are not going mad on this weird day.";
                }
            }

            if (BirthdayParty.PartyIsUp)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return "My cuties are having a blast in this fine day! You should get one to have a great day yourself!";

                    default:
                        return "Today is a great day to get a new pal! You should totally get one today bro.";
                }
            }

            if (!Main.bloodMoon)
            {
                if (Main.dayTime)
                {
                    switch (Main.rand.Next(5))
                    {
                        case 0:
                            return "Hey punk! I got some cute pets and I know you wanna buy one of 'em.";

                        case 1:
                            return "You're destined to do great things, bro. Do one right now and give these babies a home.";

                        case 2:
                            return "How does my little pet TUB eat? Well... ya don't wanna know that, bud.";

                        case 3:
                            return "Being clairvoyant helps find me pets in need and homes for the ones I have. Which have you got today " + Main.player[Main.myPlayer].name + "?";

                        default:
                            return "Been expecting you, punk. Right on time. Now let's talk about those cuties.";
                    }
                }
                else
                {
                    switch (Main.rand.Next(4))
                    {
                        case 0:
                            return "The stars are watching you, punk. Don't fail 'em.";

                        case 1:
                            return "It's dark and gloomy outside. Why not buy one of my little pals to keep you spirits up?";

                        case 2:
                            return "It's never too late to get one of these babies. Get one now, punk!";

                        default:
                            return "Do you need a buddy in these dark times?";
                    }
                }
            }
            else
            {
                if (Main.rand.NextFloat() < 0.01f)
                {
                    //pet becomes angery at you for like, a minute (or you go far away from the npc)
                    OracleGlobalNPC.playerTarget = Main.player[Main.myPlayer].whoAmI;
                    OracleGlobalNPC.playerTargetTimer = Main.rand.Next(3600, 7201); //1 to 2 minutes
                    return "YOU ARE NEXT.";
                }

                switch (Main.rand.Next(6))
                {
                    case 0:
                        return "You better get one of these babies, or else.";

                    case 1:
                        return "You don't want to know what by buddy TUB can do to you in these times.";

                    case 2:
                        return "You better don't get in the way of me and one of my babies.";

                    case 3:
                        return "Hey " + Main.player[Main.myPlayer].name + ", maybe you should try to hide for tonight.";

                    case 4:
                        return "You better run tonight, punk. TUB is looking for you and it won't go easy.";

                    default:
                        return "If you like living you should start hiding.";
                }
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "Divination";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
            else
            {
                shop = false;
                if (Main.myPlayer == Main.LocalPlayer.whoAmI)
                {
                    if (!Main.LocalPlayer.GetModPlayer<OraclePlayer>().playerHasGottenBag)
                    {
                        Main.npcChatText = "Here's what TUB found with my divination!";
                        Main.LocalPlayer.GetModPlayer<OraclePlayer>().playerHasGottenBag = true;
                        if (CalValEX.month == 10)
                        {
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                Main.LocalPlayer.QuickSpawnItem(NPC.GetSource_Loot(), ItemID.GoodieBag);
                            }
                            else if (Main.rand.NextFloat() < 0.1f)
                            {
                                Main.LocalPlayer.QuickSpawnItem(NPC.GetSource_Loot(), ItemID.Present);
                            }
                            else
                            {
                                Main.LocalPlayer.QuickSpawnItem(NPC.GetSource_Loot(), ItemType<MysteryPainting>());
                            }
                        }
                        else if (CalValEX.month == 12)
                        {
                            if (Main.rand.NextFloat() < 0.1f)
                            {
                                Main.LocalPlayer.QuickSpawnItem(NPC.GetSource_Loot(), ItemID.GoodieBag);
                            }
                            else if (Main.rand.NextFloat() < 0.3f)
                            {
                                Main.LocalPlayer.QuickSpawnItem(NPC.GetSource_Loot(), ItemID.Present);
                            }
                            else
                            {
                                Main.LocalPlayer.QuickSpawnItem(NPC.GetSource_Loot(), ItemType<MysteryPainting>());
                            }
                        }
                        else
                        {
                            if (Main.rand.NextFloat() < 0.2f)
                            {
                                Main.LocalPlayer.QuickSpawnItem(NPC.GetSource_Loot(), ItemID.GoodieBag);
                            }
                            else if (Main.rand.NextFloat() < 0.2f)
                            {
                                Main.LocalPlayer.QuickSpawnItem(NPC.GetSource_Loot(), ItemID.Present);
                            }
                            else
                            {
                                Main.LocalPlayer.QuickSpawnItem(NPC.GetSource_Loot(), ItemType<MysteryPainting>());
                            }
                        }
                    }
                    else
                    {
                        Main.npcChatText = "Sorry dude, only one reading per day!";
                    }
                }
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {

            //Mod calamityMod = ModLoader.GetMod("CalamityMod");
            shop.item[nextSlot].SetDefaults(ItemType<Items.Pets.DoggoCollar>());
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 50, 0);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemType<Items.Pets.BambooStick>());
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 2, 0, 0);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemType<Items.Pets.RuinedBandage>());
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 2, 50, 0);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemType<Items.Pets.Cube>());
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 3, 0, 0);
            nextSlot++;
            Mod clamMod = ModLoader.GetMod("CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
            
            var calEntryCount = Main.BestiaryDB.GetCompletedPercentByMod(clamMod);
            var vanEntryCount = Main.GetBestiaryProgressReport().CompletionPercent;

            if (clamMod != null)
            {
                if ((bool)clamMod.Call("GetBossDowned", "hivemind"))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<AerialiteBubble>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5, 50, 0);
                    ++nextSlot;
                }
                else if ((bool)clamMod.Call("GetBossDowned", "perforator"))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<AerialiteBubble>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5, 50, 0);
                    ++nextSlot;
                }
                if ((bool)NPC.downedPlantBoss)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<SmolEldritchHoodie>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 10, 0, 0);
                    ++nextSlot;
                }
                shop.item[nextSlot].SetDefaults(ItemType<Items.Pets.UglyTentacle>());
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 20, 0, 0);
                nextSlot++;
                if (rachelname)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<BubbleGum>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 0, 0);
                    nextSlot++;
                }
                else if (Main.player[Main.myPlayer].GetModPlayer<CalamityPlayer>().ZoneSulphur || CalamityMod.Events.AcidRainEvent.AcidRainEventIsOngoing || CalamityMod.DownedBossSystem.downedEoCAcidRain)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<BubbleGum>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 10, 0, 0);
                    nextSlot++;
                }
                if (CalamityMod.DownedBossSystem.downedHiveMind && WorldGen.crimson)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<MeatyWormTumor>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 20, 0, 0);
                    ++nextSlot;
                }
                if (CalamityMod.DownedBossSystem.downedPerforator && !WorldGen.crimson)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<RottenKey>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 20, 0, 0);
                    ++nextSlot;
                }
                if (CalamityMod.DownedBossSystem.downedCryogen)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<CooperShortsword>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 10, 0, 0);
                    ++nextSlot;
                }
                if (CalamityMod.DownedBossSystem.downedBrimstoneElemental)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<BrimberryItem>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 15, 0, 0);
                    ++nextSlot;
                }
                if (CalamityMod.DownedBossSystem.downedCalamitas)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<SuspiciousLookingGBC>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 20, 0, 0);
                    ++nextSlot;
                }
                if (CalamityMod.DownedBossSystem.downedCalamitas)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<DeepseaLantern>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 20, 0, 0);
                    ++nextSlot;
                }
                if (CalamityMod.DownedBossSystem.downedDragonfolly)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<TheDragonball>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 75, 0, 0);
                    ++nextSlot;
                }
                if (CalamityMod.DownedBossSystem.downedProvidence)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<ProfanedChewToy>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 80, 0, 0);
                    ++nextSlot;
                }
                if (CalamityMod.DownedBossSystem.downedSignus)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<SuspiciousLookingChineseCrown>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 95, 0, 0);
                    ++nextSlot;
                }
                if (CalamityMod.DownedBossSystem.downedDoG)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.LightPets.CosmicBubble>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 0, 0, 0);
                    ++nextSlot;
                }
                if (CalamityMod.DownedBossSystem.downedYharon)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<NuggetinaBiscuit>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 10, 0, 0);
                    ++nextSlot;
                }
                if ((calEntryCount + vanEntryCount) > 0.028 || CalamityMod.DownedBossSystem.downedDragonfolly) {
                    shop.item[nextSlot].SetDefaults(ItemType<NuggetLicense>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 6, 60, 90);
                    ++nextSlot;
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
            damage = 13;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 20;
            randExtraCooldown = 20;
        }

        private int OracleWeapon = 0;

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            if (Main.rand.NextBool(7))
            {
                projType = ModContent.ProjectileType<OracleNPC_8Ball>();
                attackDelay = 1;
                OracleWeapon = 1;
                return;
            }
            else
            {
                projType = ModContent.ProjectileType<OracleNPC_Cards>();
                attackDelay = 1;
                OracleWeapon = 0;
            }
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            randomOffset = 2f;

            if (OracleWeapon == 0)
            {
                multiplier = 24f;
            }
            if (OracleWeapon == 1)
            {
                multiplier = 10f;
            }
        }

        public override bool PreAI()
        {
            OracleGlobalNPC.oracleNPC = NPC.whoAmI;
            return true;
        }

        public override void AI()
        {
            if (CalValEXConfig.Instance.TownNPC)
            {
                NPC.active = false;
            }
            bool iExist = false;
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                if (Main.projectile[i].type == ModContent.ProjectileType<OracleNPCPet_Pet>() && Main.projectile[i].active)
                    iExist = true;
            }

            Vector2 position = NPC.position;
            position.Y -= 16f;

            if (!iExist)
                if (Main.netMode != NetmodeID.MultiplayerClient)
                    Projectile.NewProjectile(NPC.GetSource_FromAI(), position, NPC.velocity, ModContent.ProjectileType<OracleNPCPet_Pet>(), NPC.damage, 0f, Main.myPlayer);
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OracleNPC").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OracleNPC2").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OracleNPC3").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OracleNPC4").Type, 1f);
            }
        }
    }
}