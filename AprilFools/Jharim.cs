using CalamityMod.CalPlayer;
using CalValEX.AprilFools;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.AprilFools
{
    [AutoloadHead]
    public class Jharim : ModNPC
    {
        private static bool shop1;

        private static bool boss;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Tyrant");
            Main.npcFrameCount[npc.type] = 23;
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
            npc.damage = 1;
            npc.defense = 150;
            npc.lifeMax = 250000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.PartyGirl;
        }

        public override void AI()
        {
            Mod orthoceraDLC = ModLoader.GetMod("CalValPlus");
            if (CalValEX.month != 4 && orthoceraDLC == null)
            {
            npc.active = false;
            }
        }

        public override string TownNPCName()
        {
            return "Jharim";
        }

        public override string GetChat()
        {
            Player player = Main.player[Main.myPlayer];
            CalValEXPlayer CalValEXPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (npc.homeless)
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

            //Main.NewText("MISC EQUIPS 0 TYPE: " + Main.player[Main.myPlayer].miscEquips[0].type + "|MISC EQUIPS 1 TYPE: " + Main.player[Main.myPlayer].miscEquips[1].type);

            int FAP = NPC.FindFirstNPC((ModLoader.GetMod("CalamityMod").NPCType("FAP")));
            if (FAP >= 0 && Main.rand.NextFloat() < 0.25f)
            {
                return "Hyu Hyu Hyu... That purple lady stole my booze.";
            }

            int SEAHOE = NPC.FindFirstNPC((ModLoader.GetMod("CalamityMod").NPCType("SEAHOE")));
            if (SEAHOE >= 0 && Main.rand.NextFloat() < 0.25f)
            {
                return "How is Amidas still alive, I thought that he got burnt by Soup Ree Calamitoad.";
            }
            CalamityPlayer calPlayer = player.GetModPlayer<CalamityPlayer>();

            if (NPC.AnyNPCs((ModLoader.GetMod("CalamityMod").NPCType("Yharon"))) && Main.rand.NextFloat() < 0.25f)
            {
                return "Hyuck Hyuck Hyuck, my loyal friend Yharon! I demand you to stop atacking! ... Guess he doesn't recognize me...";
            }
            Mod clamMod = ModLoader.GetMod("CalamityMod");
            if (((bool)clamMod.Call("GetBossDowned", "supremecalamitas")) && Main.rand.NextFloat() < 0.25)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return "It is time for you to face him.";

                    default:
                        return "The god of the universe... he is willing to face you now.";
                }
            }

            if ((calPlayer.sirenWaifu || calPlayer.elementalHeart) && Main.rand.NextFloat() < 0.25f)
            {
                return "OoooooO Fish Lady, tell me! Where's my fish tacos!";
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
                else
                {
                    switch (Main.rand.Next(4))
                    {
                        case 0:
                            return "I'ts dark.";

                        case 1:
                            return "Hyuck Hyuck Hyuck, nights remind me of the time that I went to the beach and was almost assassinated!";

                        default:
                            return "I wonder where my pet dog went.";
                    }
                }
            }
            else
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
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
            button2 = "Summon";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
                {
                    shop1 = true;
                    boss = false;
                }
            }
            else if (!firstButton)
            {
            {
                if (Main.myPlayer == Main.LocalPlayer.whoAmI)
                {
                    Mod clamMod = ModLoader.GetMod("CalamityMod");
                    if ((bool)clamMod.Call("GetBossDowned", "supremecalamitas"))
                    {
                        npc.active = false;
                        NPC.SpawnOnPlayer(Main.player[Main.myPlayer].whoAmI, mod.NPCType("Fogbound"));
                    }
                    else
                    {
                        Main.npcChatText = "The time is not here yet. He will only appear after the great brimstone witch has been bested in combat.";
                    }
                }
            }
            }
        }

        public static void AddItem(bool check, string mod, string item, int price, ref Chest shop, ref int nextSlot)
        {
            if (shop1)
            {
                Mod calamityMod = ModLoader.GetMod("CalamityMod");
                shop.item[nextSlot].SetDefaults(ItemType<AprilFools.AmogusItem>());
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 0, 0);
                nextSlot++;
                Mod clamMod = ModLoader.GetMod("CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
                if (clamMod != null)
                {
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("CheatTestThing"));
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(3, 99, 99, 6);
                    ++nextSlot;
                }
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (shop1)
            {
                Mod calamityMod = ModLoader.GetMod("CalamityMod");
                shop.item[nextSlot].SetDefaults(ItemType<AprilFools.AmogusItem>());
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 1, 0, 0);
                nextSlot++;
                Mod clamMod = ModLoader.GetMod("CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
                if (clamMod != null)
                {
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("Lol"));
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(3, 99, 99, 6);
                    ++nextSlot;
                }
            }
        }

        public override bool CanGoToStatue(bool toKingStatue)
        {
            return true;
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
            damage = 1;
            knockback = 0f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 100;
            randExtraCooldown = 20;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = (ModLoader.GetMod("CalamityMod").ProjectileType("InfernadoFriendly"));
            attackDelay = 1;
            return;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            randomOffset = 2f;
            multiplier = 24f;
        }
    }
}