using CalValEX.AprilFools;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using System.Collections.Generic;

namespace CalValEX.AprilFools.Jharim
{
    [AutoloadHead]
    public class Jharim : ModNPC
    {
        private bool MELDOSAURUSED;
        private int textcounter;
        public int framebuffer = 0;
        public int framecounter = 0;
        public bool firinglaser = false;
        public bool lasercheck = false;
        public int shopnum = 1;
        public int maxshops = 18;
        public List<int> cvitems = new List<int> { };
        Vector2 jharimpos;

        private static int ShimmerHeadIndex;
        private static Profiles.StackedNPCProfile NPCProfile;

        public override void Load()
        {
            // Adds our Shimmer Head to the NPCHeadLoader.
            ShimmerHeadIndex = Mod.AddNPCHeadTexture(Type, "CalValEX/AprilFools/Jharim/Jharim_Shimmer_Head");
        }

        public override void SetStaticDefaults()
        {
           // DisplayName.SetDefault("Jungle Tyrant");
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;

            NPCID.Sets.ShimmerTownTransform[Type] = true; // Allows for this NPC to have a different texture after touching the Shimmer liquid.


            // This creates a "profile" for ExamplePerson, which allows for different textures during a party and/or while the NPC is shimmered.
            NPCProfile = new Profiles.StackedNPCProfile(
                new Profiles.DefaultNPCProfile(Texture, NPCHeadLoader.GetHeadSlot(HeadTexture), Texture),
                new Profiles.DefaultNPCProfile("CalValEX/AprilFools/Jharim/Jharim_Shimmer", ShimmerHeadIndex)
            );
            NPC.Happiness
                .SetBiomeAffection<JungleBiome>(AffectionLevel.Like) // Example Person prefers the jungle.
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike) // Example Person dislikes the snow.
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Hate) // Example Person dislikes the ocean.
                .SetBiomeAffection<MushroomBiome>(AffectionLevel.Love) // Example Person likes the shroom biome.
                .SetNPCAffection(NPCID.Dryad, AffectionLevel.Love) // Loves living near the dryad.
                .SetNPCAffection(NPCID.Pirate, AffectionLevel.Like) // Likes living near the pirate.
                .SetNPCAffection(NPCID.TaxCollector, AffectionLevel.Dislike) // Dislikes living near the tax collector.
            ;
            if (CalValEX.CalamityActive)
                NPC.Happiness.SetNPCAffection(CalValEX.CalamityNPC("WITCH"), AffectionLevel.Hate); // Hates living near scal.

            if (!CalValEX.AprilFoolMonth)
            {
                NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
                {
                    Hide = true
                };
                NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
            }
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 1;
            NPC.defense = 150;
            NPC.lifeMax = 250000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.PartyGirl;
        }
        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            if (CalValEX.AprilFoolMonth)
            {
                bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                Terraria.GameContent.Bestiary.BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.SurfaceMushroom,
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("A bumbling idiot."),
            });
            }
        }
        private void EdgyTalk(string text, Color color, bool combatText = false)
        {
            if (combatText)
            {
                CombatText.NewText(NPC.getRect(), color, text, true);
            }
            else
            {
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText(text, color);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    //NetMessage.BroadcastChatMessage(NetworkText.FromKey(text), color);
                }
            }
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void AI()
        {
            if (!CalValEX.AprilFoolMonth && CalValEX.CalamityActive)
            {
                NPC.active = false;
            }
            if (CalValEX.CalamityActive)
            {
                if (NPC.AnyNPCs(CalValEX.CalamityNPC("WITCH")) && !MELDOSAURUSED && NPC.life < NPC.lifeMax * 0.15f)
                {
                    if (!lasercheck)
                    {
                        lasercheck = true;
                        firinglaser = true;
                    }
                    for (int x = 0; x < Main.maxNPCs; x++)
                    {
                        NPC npc3 = Main.npc[x];
                        if (npc3.type == CalValEX.CalamityNPC("WITCH"))
                        {
                            if (npc3.active)
                            {
                                jharimpos.X = npc3.Center.X;
                                jharimpos.Y = npc3.Center.Y;
                                if (npc3.position.X - NPC.position.X >= 0)
                                {
                                    NPC.direction = 1;
                                }
                                else
                                {
                                    NPC.direction = -1;
                                }
                            }
                            else
                            {
                                CalValEXWorld.jharinter = true;
                                lasercheck = false;
                            }
                        }
                    }
                    if (firinglaser)
                    {
                        Vector2 position = NPC.Center;
                        position.X = NPC.Center.X;
                        Vector2 direction = jharimpos - position;
                        direction.Normalize();
                        float speed = 10f;
                        int type = CalValEX.CalamityActive ? Mod.Find<ModProjectile>("JharimLaser").Type : 0;
                        int damage = 6666666;
                        Projectile.NewProjectile(NPC.GetSource_FromAI(), position, direction * speed, type, damage, 0f, Main.myPlayer);
                        firinglaser = false;
                        NPC.defense = 999;
                    }
                }
            }
            if (MELDOSAURUSED)
            {
                NPC.dontTakeDamage = true;
                NPC.dontTakeDamageFromHostiles = true;
                textcounter++;
                NPC.velocity.X *= 0.04f;
                if (textcounter == 1)
                {
                    EdgyTalk("GRAHGAHGAH WHY WOULD YOU DO THAT!", Color.White, true);
                }
                else if (textcounter == 120)
                {
                    EdgyTalk("IT    IS GOING TO WAKE UP HELPHELPHELP", Color.White, true);
                }
                else if (textcounter == 240 || textcounter == 280 || textcounter == 300 || textcounter == 310 || textcounter == 305 || textcounter == 310 || textcounter == 315 || textcounter == 320)
                {
                    EdgyTalk("ORULQDORULQDORULQDORULQD", Color.DarkGreen, true);
                }
                if (textcounter == 360)
                {
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.NPCHit1, NPC.position);
                    NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, (int)NPC.Center.Y, NPCType<AprilFools.Meldosaurus.Meldosaurus>());
                    NPC.active = false;
                }

            }
        }

        public override List<string> SetNPCNameList() => new List<string>() { "Jharim" };
        public override ITownNPCProfile TownNPCProfile()
        {
            return NPCProfile;
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override string GetChat()
        {
            CalValEXGlobalNPC.jharim = NPC.whoAmI;
            Player player = Main.player[Main.myPlayer];
            CalValEXPlayer CalValEXPlayer = player.GetModPlayer<CalValEXPlayer>();
           /* int itemamt = 0;
            for (int i = 0; i < ContentSamples.ItemsByType.Count; i++)
            {
                Item item = ContentSamples.ItemsByType[i];
                if ((item.ModItem?.Mod ?? null) == CalValEX.instance)
                {
                    itemamt++;
                }
            }*/

            //maxshops = itemamt / 39;
            if (!MELDOSAURUSED)
            {
                if (NPC.homeless)
                {
                    switch (Main.rand.Next(3))
                    {
                        case 0:
                            return "Hyuck Hyuck Hyuck, hello I am Jharim the Great Jungle Tyrant. I appear in seek of someone to defeat a great beast for me.";

                        case 1:
                            return "That bag wasn't very comfy. I think I ate a fly in there.";

                        default:
                            return "Hyuck Hyuck Hyuck, I as Great Jungle Tyrant, will aid you on your quest to defeat the Non-Great Jungle Tyrant... by doing nothing!";
                    }
                }

                if ((NPC.AnyNPCs(NPCID.LunarTowerNebula) || NPC.AnyNPCs(NPCID.LunarTowerVortex) || NPC.AnyNPCs(NPCID.LunarTowerStardust) || NPC.AnyNPCs(NPCID.LunarTowerSolar)) && Main.rand.NextFloat() < 0.25f)
                {
                    return "These pillars are spookay, and those dark globs some of their friends drop are... I don't want to touch any... especially if its on fire, so please don't shoot me with any fiery weapons made of that stuff.";
                }

                if (CalValEX.CalamityActive)
                {
                    if (CalValEXPlayer.CirrusDress)
                    {
                        return "NO NO NOT THE STAR NEVER AGAIN NO NO NO!";
                    }

                    int FAP = NPC.FindFirstNPC(CalValEX.CalamityNPC("FAP"));
                    if (FAP >= 0 && Main.rand.NextFloat() < 0.25f)
                    {
                        return "Hyu Hyu Hyu... That purple lady stole my booze.";
                    }

                    int Cal = NPC.FindFirstNPC(CalValEX.CalamityNPC("WITCH"));
                    if (Cal >= 0 && Main.rand.NextFloat() < 0.25f)
                    {
                        return "GET THAT ACURSED WITCH AWAY FROM ME";
                    }

                    int SEAHOE = NPC.FindFirstNPC(CalValEX.CalamityNPC("SEAHOE"));
                    if (SEAHOE >= 0 && Main.rand.NextFloat() < 0.25f)
                    {
                        if (Cal >= 0)
                            return "How is Amidas still alive, I thought that he got burnt by that DUMB witch.";
                        else
                            return "How is Amidas still alive, I thought that he got burnt by Soup Ree Calamitoad.";
                    }

                    if (NPC.AnyNPCs(CalValEX.CalamityNPC("Draedon")) && Main.rand.NextFloat() < 0.25f)
                    {
                        return "DRAAAAAAAAAEEEEEEEDOOOOOOOOOOOONNNNNNNNNNNNNNNNNNN I KNOW WHAT YOU DID!";
                    }

                    /*Mod apoc = ModLoader.GetMod("ApothTestMod");
                    if (apoc != null)
                    {
                        if (NPC.AnyNPCs((apoc.NPCType("THELORDE"))))
                        {
                            return "IMPOSTER!";
                        }
                    }*/

                    if (NPC.AnyNPCs(CalValEX.CalamityNPC("Yharon")) && Main.rand.NextFloat() < 0.25f)
                    {
                        return "Hyuck Hyuck Hyuck, my loyal friend Yharon! I demand you to stop atacking! ... Guess he doesn't recognize me...";
                    }

                    Mod clamMod = CalValEX.Calamity;
                    if (((bool)clamMod.Call("GetBossDowned", "supremecalamitas")) && ((bool)clamMod.Call("GetBossDowned", "exomechs")) && Main.rand.NextFloat() < 0.25)
                    {
                        switch (Main.rand.Next(2))
                        {
                            case 0:
                                return "It is time for you to face him.";

                            default:
                                return "The god of the universe... he is willing to face you now.";
                        }
                    }

                    if (player.ownedProjectileCounts[CalValEX.CalamityProjectile("WaterElemental")] > 0 && Main.rand.NextFloat() < 0.25f)
                    {
                        return "OoooooO Fish Lady, tell me! Where's my fish tacos!";
                    }
                }

                if (Main.eclipse)
                {
                    switch (Main.rand.Next(2))
                    {
                        case 0:
                            return "Hyuck Hyuck Hyuck, why is it so dark.";

                        default:
                            return "Hmm, I KNOW! I should go and wrestle one of those moths! I've wrestled a lot of moths before!";
                    }
                }

                if (CalValEX.CalamityActive)
                {
                    if ((bool)CalValEX.Calamity.Call("GetDifficultyActive", "bossrush"))
                    {
                        switch (Main.rand.Next(2))
                        {
                            case 0:
                                return "THE SKY IS COLLAPSING, IT'S THE END AGAIN!";

                            default:
                                return "THE MOTH, THEY'LL RECKON HAVOC UPON ME AND FLING ME OFF EXISTENCE AAAAAHHHHHHHHHH";
                        }
                    }

                    if ((bool)CalValEX.Calamity.Call("AcidRainActive"))
                    {
                        switch (Main.rand.Next(2))
                        {
                            case 0:
                                return "ribbit.";

                            default:
                                return "I'm feeling kinda drunk right now Hyickup Hyickup. Maybe I should stop drinking highly toxic acid...";
                        }
                    }
                }

                if (BirthdayParty.PartyIsUp)
                {
                    switch (Main.rand.Next(2))
                    {
                        case 0:
                            return "Hyuck Hyuck Hyuck Hyuck Hyuck Hyuck Hyuck Hyuck Hyuck Hyuck Hyuck Hyuck Hyuck Hyuck Hyuck Hyuck Hyuck Hyuck Hyuck Hyuck Hyuck Hyuck Hyuck Hyuck .";

                        default:
                            return "PARTY TIMEEEEEEEEEEEEE HYUCK HYUCK HYUCK.";
                    }
                }

                if (!Main.bloodMoon)
                {
                    if (Main.dayTime)
                    {
                        switch (Main.rand.Next(4))
                        {
                            case 0:
                                return "Hyuck Hyuck Hyuck, Jharim the Great orders you to get fish for me! ... what do you mean you don't want to!?";

                            case 1:
                                return "Yharim is a faker, I AM THE ONLY JUNGLE TYRANT!";

                            case 2:
                                return "HYuHck HYuHck HYuHck. Why am I spelling like this?";

                            default:
                                return "When I was younger, I tortured a bee for a minute straight then bashed nails into its body. It was funny and got a lot of views on TubeYou.";
                        }
                    }
                    else
                    {
                        switch (Main.rand.Next(4))
                        {
                            case 0:
                                return "It's dark.";

                            case 1:
                                return "Hyuck Hyuck Hyuck, nights remind me of the time that I went to the beach and was almost assassinated!";

                            default:
                                return "I wonder where my pet dog went.";
                        }
                    }
                }
                else
                {
                    switch (Main.rand.Next(3))
                    {
                        case 0:
                            return "Run.";

                        case 1:
                            return "The red moon... a cursed thing... Anyways where's my eggos, chop chop little one.";

                        default:
                            return "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA.";
                    }
                }
            }
            else
            {
                return "GAHUGIEGJIWEGUIEUWG";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            if (!MELDOSAURUSED)
            {
                button = CalValEX.CalamityActive ? "Shop" : "Shop " + shopnum;
                button2 = CalValEX.CalamityActive ? "Summon" : "Cycle Shop";
            }
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (!MELDOSAURUSED)
            {
                if (firstButton)
                {
                    if (CalValEX.CalamityActive)
                        shopName = "Jharim";
                    else
                        shopName = "Jharim" + shopnum;
                }
                else if (!firstButton)
                {
                    if (CalValEX.CalamityActive)
                    {
                        if (Main.myPlayer == Main.LocalPlayer.whoAmI)
                        {
                            if ((bool)CalValEX.Calamity.Call("GetBossDowned", "scal") && (bool)CalValEX.Calamity.Call("GetBossDowned", "draedon"))
                            {
                                NPC.active = false;
                                NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, (int)NPC.Center.Y, NPCType<Fogbound>());
                                Main.NewText("You've awoken me... time to pay the price...", Color.Gray);
                                NPC.HitEffect();
                            }
                            else
                            {
                                Main.npcChatText = "The time is not here yet. He will only appear after both the supreme witch and the mechanical abominations have been silenced.";
                            }
                        }
                    }
                    else
                    {
                        if (shopnum < maxshops)
                            shopnum++;
                        else
                            shopnum = 1;
                    }
                }
            }
        }
        public override void AddShops()
        {
            if (CalValEX.CalamityActive)
            {
                var blockShop = new NPCShop(Type, "Jharim");
                blockShop.Add(ItemType<AmogusItem>());
                blockShop.Register();
            }
            else
            {
                for (int i = 0; i < ContentSamples.ItemsByType.Count; i++)
                {
                    Item item = ContentSamples.ItemsByType[i];
                    // if the item is from CalVal, add it to the shop
                    if ((item.ModItem?.Mod ?? null) == CalValEX.instance && item.Name != "Compensation")
                    {
                        cvitems.Add(i);
                    }
                }

                int progress = 0;

                for (int s = 1; s < maxshops + 1; s++)
                {
                    var shope = new NPCShop(Type, "Jharim" + s);
                    for (int i = 0 + progress; i < 39 + progress; i++)
                    {
                        if (i < cvitems.Count)
                        {
                            Item item = ContentSamples.ItemsByType[cvitems[i]];
                            item.value = DecidePrice(item);
                            shope.Add(item);
                        }
                    }
                    progress += 39;
                    shope.Register();
                }
            }
        }

        public override void ModifyActiveShop(string shopName, Item[] items)
        {
        }

        public static int DecidePrice(Item item)
        {
            int price = 0;
            // Ore-HM
            if (item.rare < 4)
            {
                price = Item.buyPrice(gold: 20);
                // Blocks
                if (item.createTile > 0 && item.rare == 0)
                {
                    price /= 1000;
                }
            }
            // Post-ML
            else if (item.rare > 10)
            {
                price = Item.buyPrice(gold: 60);
            }
            // Hardmode
            else
            {
                price = Item.buyPrice(gold: 40);
            }
            return price;
        }

        public override bool CanGoToStatue(bool toKingStatue)
        {
            return true;
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

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("JharimGore").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("JharimGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("JharimGore3").Type, 1f);
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
            damage = 1;
            knockback = 0f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 100;
            randExtraCooldown = 20;
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            int prod = CalValEX.CalamityActive ? Mod.Find<ModProjectile>("JharimLaser").Type : 0;
            if (!MELDOSAURUSED)
                projType = prod;
            else
                projType = ProjectileID.None;
            attackDelay = 1;
            return;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            randomOffset = 2f;
            multiplier = 24f;
        }

        public override void OnHitByProjectile(Projectile projectile, NPC.HitInfo hit, int damageDone)
        {
            if (!NPC.IsShimmerVariant)
            {
                if (CalValEX.CalamityActive)
                {
                    if (projectile.type == CalValEX.CalamityProjectile("CosmicFire"))
                    {
                        MELDOSAURUSED = true;
                    }
                }
                else if (projectile.type == ProjectileID.VortexBeaterRocket)
                {
                    MELDOSAURUSED = true;
                }
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (MELDOSAURUSED)
            {
                framebuffer++;
                if (framebuffer >= 6)
                {
                    framecounter++;
                    framebuffer = 0;
                }
                if (framecounter > 5)
                {
                    framecounter = 0;
                }

                Texture2D deusheadsprite = (ModContent.Request<Texture2D>("CalValEX/AprilFools/Meldosaurus/JharimsBane").Value);

                int deusheadheight = framecounter * (deusheadsprite.Height / 6);

                Rectangle deusheadsquare = new Rectangle(0, deusheadheight, deusheadsprite.Width, deusheadsprite.Height / 6);
                Color deusheadalpha = NPC.GetAlpha(drawColor);
                spriteBatch.Draw(deusheadsprite, NPC.Center - Main.screenPosition + new Vector2(0f, NPC.gfxOffY), deusheadsquare, deusheadalpha, NPC.rotation, Utils.Size(deusheadsquare) / 2f, NPC.scale, SpriteEffects.None, 0);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}