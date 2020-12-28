using System;
using CalValEX.Oracle;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using CalValEX.Items;
using CalValEX.Items.Pets;
using CalValEX.Items.Equips;
using CalValEX.Items.Equips.Hats;
using CalValEX;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.LightPets;

namespace CalValEX.Oracle
{
    [AutoloadHead]
    public class OracleNPC : ModNPC
    {
        public override string Texture => "CalValEX/Oracle/OracleNPC";
        public override string[] AltTextures => new[] { "CalValEX/Oracle/OracleNPC_Alt" };

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oracle");
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
            npc.damage = 15;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Mechanic;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
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
            return false;
        }

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(14))
            {
                case 0:
                    return "Maddi";
                case 1:
                    return "Tiggy";
                case 3:
                    return "Gabriel";
                case 4:
                    return "Lex";
                case 5:
                    return "Gwyn";
                case 6:
                    return "Sammy";
                case 7:
                    return "Eve";
                case 8:
                    return "Emily";
                case 9:
                    return "Lilith";
                case 10:
                    return "Rachel";
                case 11:
                    return "Leah";
                case 12:
                    return "Rebecca";
                default:
                    return "Alex";
            }
        }

        public override string GetChat()
        {
            if (npc.homeless)
            {
                switch(Main.rand.Next(2))
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

            int wizard = NPC.FindFirstNPC(NPCID.Wizard);
            if (wizard >= 0 && Main.rand.NextFloat() < 0.25f)
            {
                switch(Main.rand.Next(2))
                {
                    case 0:
                        return Main.npc[wizard].GivenName + " may seem like a weird old dude with a silly costume, but his magic is real for sure.";
                    default:
                        return "Hey punk, can you talk to " + Main.npc[wizard].GivenName + "? I have a buddy that he might enjoy having!";
                }
            }

            if (Main.eclipse)
            {
                switch(Main.rand.Next(4))
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
                        if (Main.rand.NextFloat() < 0.2f)
                        {
                            Main.LocalPlayer.QuickSpawnItem(ItemID.GoodieBag);
                        }
                        else if (Main.rand.NextFloat() < 0.2f)
                        {
                            Main.LocalPlayer.QuickSpawnItem(ItemID.Present);
                        }
                        else
                        {
                            Main.LocalPlayer.QuickSpawnItem(ItemType<MysteryPainting>());
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
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            shop.item[nextSlot].SetDefaults(ItemType<Items.Pets.BambooStick>());
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5, 0, 0);
			nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemType<Items.Pets.EurosBandage>());
            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 6, 50, 0);
			nextSlot++;
            Mod clamMod = ModLoader.GetMod("CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
            if (clamMod != null)
            {
                if ((bool) clamMod.Call("GetBossDowned", "hivemind"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<AeroPebble>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 10, 50, 0);
                        ++nextSlot;
                    }
                    else if ((bool) clamMod.Call("GetBossDowned", "perforator"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<AeroPebble>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 10, 50, 0);
                        ++nextSlot;
                    }
                if ((bool) NPC.downedPlantBoss)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Eidolistthingy>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 95, 0, 0);
                        ++nextSlot;
                    }
                        shop.item[nextSlot].SetDefaults(ItemType<Items.Pets.UglyTentacle>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 0, 0, 0);
                        nextSlot++;
                if (npc.GivenName == "Rachel")
                {
                                shop.item[nextSlot].SetDefaults(ModContent.ItemType<BubbleGum>());
                                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 80, 0, 0);
                                nextSlot++;
                            
                }
                if ((bool)clamMod.Call("GetInZone", Main.player[Main.myPlayer], "sulphursea"))
                            {
                                shop.item[nextSlot].SetDefaults(ModContent.ItemType<BubbleGum>());
                                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 75, 0, 0);
                                nextSlot++;
                            }
                if ((bool) clamMod.Call("GetBossDowned", "hivemind") && Main.expertMode)
                    {
                        if ((bool) clamMod.Call("GetBossDowned", "slimegod"))
                        {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<DigestedWormFood>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 80, 0, 0);
                        ++nextSlot;
                        }
                    }
                if ((bool) clamMod.Call("GetBossDowned", "perforator") && Main.expertMode)
                    {
                        if ((bool) clamMod.Call("GetBossDowned", "slimegod"))
                        {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<MissingFang>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 80, 0, 0);
                        ++nextSlot;
                        }
                    }
                if ((bool) clamMod.Call("GetBossDowned", "cryogen") && Main.expertMode)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<coopershortsword>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 5, 0, 0);
                        ++nextSlot;
                    }
                if ((bool) clamMod.Call("GetBossDowned", "calamitas") && Main.expertMode)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<AndroombaGBC>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 50, 0, 0);
                        ++nextSlot;
                    }
		 if ((bool) clamMod.Call("GetBossDowned", "dragonfolly") && Main.expertMode)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<OrbSummon>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(2, 75, 0, 0);
                        ++nextSlot;
                    }
                if ((bool) clamMod.Call("GetBossDowned", "providence") && Main.expertMode)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<ChewyToy>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(5, 0, 0, 0);
                        ++nextSlot;
                    }
		if ((bool) clamMod.Call("GetBossDowned", "signus") && Main.expertMode)
                   {
                       shop.item[nextSlot].SetDefaults(ModContent.ItemType<JunkoHat>());
                       shop.item[nextSlot].shopCustomPrice = Item.buyPrice(10, 75, 0, 0);
                       ++nextSlot;
                   }
                if ((bool) clamMod.Call("GetBossDowned", "devourerofgods") && Main.expertMode)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Enredenitem>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(10, 0, 0, 0);
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
            OracleGlobalNPC.oracleNPC = npc.whoAmI;
            return true;
        }

        public override void AI()
        {
            bool iExist = false;
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                if (Main.projectile[i].type == ModContent.ProjectileType<OracleNPCPet_Pet>() && Main.projectile[i].active)
                    iExist = true;
            }

            Vector2 position = npc.position;
            position.Y -= 16f;

            if (!iExist)
                if (Main.netMode != NetmodeID.MultiplayerClient)
                    Projectile.NewProjectile(position, npc.velocity, ModContent.ProjectileType<OracleNPCPet_Pet>(), npc.damage, 0f, Main.myPlayer);
        }

        public override void NPCLoot()
	{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<OracleBeanie>() , 1, false, 0, false, false);
		
    }
    public override void HitEffect(int hitDirection, double damage) 
            {
			    if (npc.life <= 0) 
                {
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OracleNPC"), 1f);
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OracleNPC2"), 1f);
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OracleNPC3"), 1f);
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OracleNPC4"), 1f);
				}
			}
    }
}
