using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;

namespace CalValEX.AprilFools
{
    public class Amogus : WalkingPet
    {
        int deathcounter = 0;
        int lifecounter = 0;
        int sandblasttimer = 0;
        int mushroom = 0;
        int birb = 1200;
        int minetimer = 0;
        int infernadotimer = 1200;
        int polterdart = 0;
        int mine;
        int raintype;
        int attackphase;
        int attackcounter1;
        int attackcounter2;
        int attackmoment = 0;
        int chargetype = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amogus");
            Main.projFrames[Projectile.type] = 4; //frames
            Main.projPet[Projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.penetrate = -1;
            Projectile.netImportant = true;
            Projectile.timeLeft *= 5;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            base.DrawOffsetX = -7;
            base.DrawOriginOffsetY = 0;
            facingLeft = false; //is the sprite facing left? if so, put this to true. if its facing to right keep it false.
            spinRotation = false; //should it spin? if that's the case, set to true. else, leave it false.
            shouldFlip = true;
        }

        //all things should be synchronized. most things vanilla already does for us, however you should sync the things you
        //made yourself as they are not synchronized alone by the server.
        public override void SetPetGravityAndDrag()
        {
            gravity = 0.1f; //needs to be positive for the pet to be pushed down platforms plus for it to have gravity
            drag[0] = 0.92f; //idle drag
            drag[1] = 0.95f; //walking drag
        }

        public override void SetPetDistances()
        {
            distance[0] = 2400f; //teleport
            distance[1] = 560f; //speed increase
            distance[2] = 140f; //when to walk
            distance[3] = 40f; //when to stop walking
            distance[4] = 448f; //when to fly
            distance[5] = 180f; //when to stop flying
        }

        public override void SetPetSpeedsAndInertia()
        {
            speed[0] = 10f; //walking speed
            speed[1] = 12f; //flying speed

            inertia[0] = 20f; //walking inertia
            inertia[1] = 80f; //flight inertia
        }

        public override void SetJumpSpeeds()
        {
            jumpSpeed[0] = -4f; //1 tile above pet
            jumpSpeed[1] = -6f; //2 tiles above pet
            jumpSpeed[2] = -8f; //5 tiles above pet
            jumpSpeed[3] = -7f; //4 tiles above pet
            jumpSpeed[4] = -6.5f; //any other tile number above pet
        }

        public override void SetFrameLimitsAndFrameSpeed()
        {
            idleFrameLimits[0] = idleFrameLimits[1] = 0; //what your min idle frame is (start of idle animation)

            walkingFrameLimits[0] = 0; //what your min walking frame is (start of walking animation)
            walkingFrameLimits[1] = 3; //what your max walking frame is (end of walking animation)

            flyingFrameLimits[0] = 0;
            flyingFrameLimits[1] = 3; //what your min flying frame is (start of flying animation)

            animationSpeed[0] = 30; //idle animation speed
            animationSpeed[1] = 8; //walking animation speed
            animationSpeed[2] = 10; //flying animation speed
            spinRotationSpeedMult = 2.5f; //how fast it should spin
            //put the below to -1 if you dont want a jump animation (so its just gonna continue it's walk animation
            animationSpeed[3] = -1; //jumping animation speed

            jumpFrameLimits[0] = -1; //what your min jump frame is (start of jump animation)
            jumpFrameLimits[1] = -1; //what your max jump frame is (end of jump animation)

            jumpAnimationLength = -1; //how long the jump animation should stay
        }
        private void EdgyTalk(string text, Color color, bool combatText = false)
        {
            if (combatText)
            {
                CombatText.NewText(Projectile.getRect(), color, text, true);
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

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
            { 
                modPlayer.amogus = false;
                Projectile.active = false;
            }
            if (modPlayer.amogus)
                Projectile.timeLeft = 2;

            /* THIS CODE ONLY RUNS AFTER THE MAIN CODE RAN.
             * for custom behaviour, you can check if the projectile is walking or not via Projectile.localAI[1]
             * you should make new custom behaviour with numbers higher than 2, or less than 0
             * the next few lines is an example on how to implement this
             *
             * switch ((int)Projectile.localAI[1])
             * {
             *     case -1:
             *         break;
             *     case 3:
             *         break;
             * }
             *
             * 0, 1 and 2 are already in use.
             * 0 = idling
             * 1 = walking
             * 2 = flying
             *
             * you can still use these, changing thing inside (however it's not recomended unless you want to add custom behaviour to these)
             */

            if (deathcounter <= 0 && !player.HasBuff(ModContent.BuffType<AprilFools.AmogusBuff>()) && !NPC.AnyNPCs(ModContent.NPCType<Meldosaurus.Meldosaurus>()))
            {
                Projectile.active = false;
            }

            if (NPC.AnyNPCs(ModContent.NPCType<Meldosaurus.Meldosaurus>()) && deathcounter <= 0)
            {
                Projectile.tileCollide = false;
                Projectile.localAI[1] = 5;
            }

            if ((CalValEX.month != 4 && Projectile.localAI[1] != 4 && !CalValEXWorld.amogus) || modPlayer.rockhat)
            {
                deathcounter++;
                if (deathcounter >= 300)
                {
                    Projectile.localAI[1] = 3;
                    Projectile.timeLeft = 2;
                }
            }
            switch ((int)Projectile.localAI[1])
            {
                case 3:
                    //Main.sunTexture = mod.GetTexture(("AprilFools/AmogusBuff"));
                    //Mod calamityMod = ModLoader.GetMod("CalamityMod");
                    Vector2 playerpos;
                    playerpos.X = player.position.X + (Main.rand.Next(-256, 256));
                    playerpos.Y = player.position.Y - 256;
                    if (deathcounter >= 900)
                    {
                        sandblasttimer++;

                        if (deathcounter <= 1800)
                        {
                            if (Main.rand.Next(2) == 0)
                            {
                                raintype = ProjectileID.SandBallFalling;
                            }
                            else
                            {
                                raintype = ProjectileID.AncientDoomProjectile;
                            }
                        }
                        else if (deathcounter > 1800 && deathcounter <= 2700)
                        {
                            if (Main.rand.Next(2) == 0)
                            {
                                raintype = ProjectileID.InfernoHostileBolt;
                            }
                            else
                            {
                                raintype = ProjectileID.EyeLaser;
                            }
                        }
                        else if (deathcounter > 2700 && deathcounter <= 3600)
                        {
                            if (Main.rand.Next(2) == 0)
                            {
                                raintype = ProjectileID.DeathLaser;
                            }
                            else
                            {
                                raintype = ProjectileID.Flare;
                            }
                        }
                        else if (deathcounter > 3600)
                        {
                            if (Main.rand.Next(3) == 0)
                            {
                                raintype = ProjectileID.FrostWave;
                            }
                            else if (Main.rand.Next(2) == 0)
                            {
                                raintype = ProjectileID.SaucerMissile;
                            }
                            else
                            {
                                raintype = ProjectileID.InfernoHostileBlast;
                            }    
                        }

                        if (sandblasttimer >= 10)
                        {
                            Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), playerpos.X, playerpos.Y, 0, 5, raintype, 80, 0f, Main.myPlayer, 0f, 0f);
                            sandblasttimer = 0;
                        }
                    }
                    if (deathcounter >= 1080)
                    {
                        mushroom++;
                        if (mushroom >= 120)
                        {
                            for (int x = 0; x < 10; x++)
                            {
                                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item11);
                            }
                            Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), playerpos.X, playerpos.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, -3), ProjectileID.OrnamentHostileShrapnel, 180, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), playerpos.X, playerpos.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, -3), ProjectileID.OrnamentHostileShrapnel, 90, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), playerpos.X, playerpos.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, -3), ProjectileID.OrnamentHostileShrapnel, 180, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), playerpos.X, playerpos.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, -3), ProjectileID.OrnamentHostileShrapnel, 120, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), playerpos.X, playerpos.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, -3), ProjectileID.OrnamentHostileShrapnel, 80, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), playerpos.X, playerpos.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, -3), ProjectileID.OrnamentHostileShrapnel, 80, 0f, Main.myPlayer, 0f, 0f);
                            if (deathcounter >= 2700)
                            {
                                Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), playerpos.X, playerpos.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, -3), ProjectileID.EyeBeam, 80, 0f, Main.myPlayer, 0f, 0f);
                                Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), playerpos.X, playerpos.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, -3), ProjectileID.HornetStinger, 80, 0f, Main.myPlayer, 0f, 0f);
                            }
                            for (int x = 0; x < 20; x++)
                            {
                                Dust dust;
                                dust = Main.dust[Terraria.Dust.NewDust(playerpos, 30, 30, 16, 0f, 0f, 0, new Color(255, 255, 255), 1.644737f)];
                            }
                            mushroom = 0;
                        }
                    }
                    if (deathcounter >= 1400)
                    {
                        birb++;
                        if (birb >= 1200)
                        {
                            Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), playerpos.X, playerpos.Y, 1, 20, ProjectileID.SharknadoBolt, 0, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), playerpos.X, playerpos.Y, 0, 0, ProjectileID.NebulaSphere, 0, 0f, Main.myPlayer, 0f, 0f);
                            birb = 0;
                        }
                    }
                    if (deathcounter >= 1000)
                    {
                        if (deathcounter <= 1800)
                        {
                            mine = ProjectileID.SaucerLaser;
                        }
                        else if (deathcounter >= 1800 && deathcounter <= 2700)
                        {
                            mine = ProjectileID.QueenSlimeGelAttack;
                        }
                        else if (deathcounter >= 2700)
                        {
                            mine = ProjectileID.SandnadoHostile;
                        }

                        minetimer++;
                        if (minetimer >= 240)
                        {
                            for (int x = 0; x < 8; x++)
                            {
                                Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.position.X, Projectile.position.Y, Main.rand.Next(-2, 2), Main.rand.Next(-2, 2), mine, 80, 0f, Main.myPlayer, 0f, 0f);
                                minetimer = 0;
                            }
                        }
                    }
                    if (deathcounter >= 1800)
                    {
                        infernadotimer++;
                        if (infernadotimer >= 1200)
                        {
                            Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), playerpos.X, playerpos.Y, 0, 20, ProjectileID.Cthulunado, 80, 0f, Main.myPlayer, 0f, 0f);
                            polterdart = 0;
                        }
                    }
                    if (deathcounter <= 540)
                    {
                        Projectile.velocity.X = 0;
                        Projectile.velocity.Y = 0;
                    }
                    if (deathcounter > 540 && deathcounter <= 900)
                    {
                        Projectile.position.Y = player.position.Y;
                        Projectile.position.X = player.position.X + 256;
                    }
                    if (deathcounter > 900)
                    {
                        Projectile.position.Y = player.position.Y - 256;
                        Projectile.position.X = player.position.X;
                    }
                    if (deathcounter > 540 && deathcounter < 820)
                    {
                        Projectile.scale *= 1.008f;
                        if (Projectile.frameCounter++ > 4)
                        {
                            Projectile.frameCounter = 0;
                            Projectile.frame++;
                            if (Projectile.frame >= 4)
                                Projectile.frame = 0;
                        }
                    }
                    if (deathcounter == 300)
                    {
                        EdgyTalk("HOOOOOOOOOOOOOOOOLD UP", Color.White, true);
                    }
                    if (deathcounter == 420)
                    {
                        EdgyTalk("This isn't April... why am I here...", Color.White, true);
                    }
                    if (deathcounter == 540)
                    {
                        EdgyTalk("Could it be that... Someone has been cheating!? AN IMPOSTER EVEN?!?!?!", Color.White, true);
                        Projectile.rotation = 0;
                    }
                    if (deathcounter == 680)
                    {
                        EdgyTalk("That's pretty sus kid, and you know what we do to sussy little ones right?", Color.White, true);
                    }
                    if (deathcounter == 820)
                    {
                        EdgyTalk("We eject them.", Color.DarkRed, true);
                        Projectile.alpha = 50;
                        Projectile.rotation = 0;
                    }
                    if (deathcounter >= 4200 && !modPlayer.rockhat)
                    {
                        Projectile.localAI[1] = 4;
                    }
                    break;

                case 4:
                    lifecounter++;
                    deathcounter = 0;
                    if (lifecounter < 420)
                    {
                        Projectile.position.Y = player.position.Y - 256;
                        Projectile.position.X = player.position.X;
                    }
                    else if (lifecounter >= 420 && lifecounter < 680)
                    {
                        Projectile.position.X = player.position.X - 256;
                        Projectile.position.Y = player.position.Y;
                    }
                    if (lifecounter == 300)
                    {
                        EdgyTalk("Interesting, you survived...", Color.White, true);
                    }
                    if (lifecounter == 420)
                    {
                        EdgyTalk("You probably cheated tbh, or the attacks weren't working properly.", Color.White, true);
                    }
                    if (lifecounter == 540)
                    {
                        EdgyTalk("Oh well, guess you proved your worthiness to me. Wear the stone hat if you wanna go again.", Color.White, true);
                        CalValEXWorld.amogus = true;
                        CalValEXWorld.UpdateWorldBool();
                    }
                    if (lifecounter == 680)
                    {
                        Projectile.scale = 1;
                        Projectile.localAI[1] = 0;
                        deathcounter = 0;
                        lifecounter = 0;
                    }
                    break;
                case 5:
                    {
                        if (!NPC.AnyNPCs(ModContent.NPCType<Meldosaurus.Meldosaurus>()))
                        {
                            attackcounter1 = 0;
                            attackcounter2 = 0;
                            attackphase = 0;
                            Projectile.localAI[1] = 0;
                        }
                        if (attackphase == 0)
                        {
                            attackcounter2--;
                            var thisRect = Projectile.getRect();

                            for (int i = 0; i < Main.maxNPCs; i++)
                            {
                                var npc = Main.npc[i];

                                if (npc != null && npc.active && npc.getRect().Intersects(thisRect) && npc.type == ModContent.NPCType<Meldosaurus.Meldosaurus>() && attackcounter2 <= 20)
                                {
                                    if (chargetype == 4)
                                    {
                                        Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), (int)npc.Center.X, (int)npc.Center.Y, 0, 0, ProjectileID.InfernoFriendlyBlast, 2020, 0, Main.myPlayer);
                                    }
                                    else
                                    {
                                        Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), (int)npc.Center.X, (int)npc.Center.Y, 0, 0, ProjectileID.DaybreakExplosion, 1020, 0, Main.myPlayer);
                                    }
                                    attackcounter2 = 40;
                                }
                            }
                            int chargedelay = 30;
                            int chargedist = 10;
                            attackcounter1++;
                            if (chargetype == 0)
                            {
                                if (attackcounter1 <= chargedelay) //Less than or equal to 30
                                {
                                    Projectile.position.X = Main.npc[CalValEXGlobalNPC.meldodon].Center.X - 100;
                                    Projectile.position.Y = Main.npc[CalValEXGlobalNPC.meldodon].Center.Y;
                                }
                                if (attackcounter1 == chargedelay + 1) //Exactly 31
                                {
                                    Projectile.velocity.X = 20;
                                    Projectile.velocity.Y = 0;
                                    attackmoment = 0 + chargedelay + chargedist; //Set the counter to 40
                                    chargetype = 1;
                                }
                            }
                            if (chargetype == 1)
                            {
                                if (attackcounter1 >= attackmoment && attackcounter1 <= attackmoment + chargedelay) //Between 40 and 70
                                {
                                    Projectile.position.Y = Main.npc[CalValEXGlobalNPC.meldodon].Center.Y - 100;
                                    Projectile.position.X = Main.npc[CalValEXGlobalNPC.meldodon].Center.X;
                                }
                                if (attackcounter1 == attackmoment + chargedelay + 1) //71
                                {
                                    Projectile.velocity.Y = 20;
                                    Projectile.velocity.X = 0;
                                    attackmoment = attackmoment + chargedelay + chargedist; //80
                                    chargetype = 2;
                                }
                            }
                            if (chargetype == 2)
                            {
                                if (attackcounter1 >= attackmoment && attackcounter1 <= attackmoment + chargedelay) //Between 80 and 110
                                {
                                    Projectile.position.Y = Main.npc[CalValEXGlobalNPC.meldodon].Center.Y + 100;
                                    Projectile.position.X = Main.npc[CalValEXGlobalNPC.meldodon].Center.X - 100;
                                }
                                if (attackcounter1 == attackmoment + chargedelay + 1) //111
                                {
                                    Projectile.velocity.X = 20;
                                    Projectile.velocity.Y = -20;
                                    attackmoment = attackmoment + chargedelay + chargedist; //120
                                    chargetype = 3;
                                }
                            }
                            if (chargetype == 3)
                            {
                                if (attackcounter1 >= attackmoment && attackcounter1 <= attackmoment + chargedelay) //Between 120 and 150
                                {
                                    Projectile.position.Y = Main.npc[CalValEXGlobalNPC.meldodon].Center.Y - 100;
                                    Projectile.position.X = Main.npc[CalValEXGlobalNPC.meldodon].Center.X + 100;
                                }
                                if (attackcounter1 == attackmoment + chargedelay + 1) //151
                                {
                                    Projectile.velocity.X = -20;
                                    Projectile.velocity.Y = +20;
                                    attackmoment = attackmoment + chargedelay + chargedist; //160
                                    chargetype = 4;
                                }
                            }
                            if (chargetype == 4)
                            {
                                if (attackcounter1 >= attackmoment + chargedist) //170
                                {
                                    chargetype = 0;
                                    attackmoment = 0;
                                    attackcounter1 = 0;
                                    attackcounter2 = 0;
                                    attackphase = 1;
                                }
                            }
                        }
                        if (attackphase == 1)
                        {
                            attackcounter1++;
                            attackcounter2++;
                            int num412 = 1;
                            float num413 = 25f;
                            float num414 = 1.2f;
                            float distanceX = 480f;
                            float yoffset = 0f;

                            Vector2 vector40 = new Vector2(Projectile.position.X + (float)Projectile.width * 0.5f, Projectile.position.Y + (float)Projectile.height * 0.5f);
                            float num415 = Main.npc[CalValEXGlobalNPC.meldodon].position.X + (float)(Main.npc[CalValEXGlobalNPC.meldodon].width / 2) + (float)(num412 * distanceX) - vector40.X;
                            float num416 = Main.npc[CalValEXGlobalNPC.meldodon].position.Y + (float)(Main.npc[CalValEXGlobalNPC.meldodon].height / 2) + yoffset - vector40.Y;
                            float num417 = (float)Math.Sqrt(num415 * num415 + num416 * num416);
                            num417 = num413 / num417;
                            num415 *= num417;
                            num416 *= num417;
                            if (Projectile.velocity.X < num415)
                            {
                                Projectile.velocity.X += num414;
                                if (Projectile.velocity.X < 0f && num415 > 0f)
                                {
                                    Projectile.velocity.X += num414;
                                }
                            }
                            else if (Projectile.velocity.X > num415)
                            {
                                Projectile.velocity.X -= num414;
                                if (Projectile.velocity.X > 0f && num415 < 0f)
                                {
                                    Projectile.velocity.X -= num414;
                                }
                            }
                            if (Projectile.velocity.Y < num416)
                            {
                                Projectile.velocity.Y += num414;
                                if (Projectile.velocity.Y < 0f && num416 > 0f)
                                {
                                    Projectile.velocity.Y += num414;
                                }
                            }
                            else if (Projectile.velocity.Y > num416)
                            {
                                Projectile.velocity.Y -= num414;
                                if (Projectile.velocity.Y > 0f && num416 < 0f)
                                {
                                    Projectile.velocity.Y -= num414;
                                }
                            }
                            if (attackcounter1 >= 5)
                            {
                                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item, (int)Projectile.Center.X, (int)Projectile.Center.Y, 41);
                                Vector2 position = Projectile.Center;
                                position.X = Projectile.Center.X + (10f * Projectile.direction);
                                Vector2 targetPosition = Main.npc[CalValEXGlobalNPC.meldodon].Center;
                                Vector2 direction = targetPosition - position;
                                direction.Normalize();
                                float speed = 15f;
                                int type = ProjectileID.GoldenBullet;
                                int damage = Main.expertMode ? 60 : 95;
                                Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), position, direction * speed, type, damage, 0f, Main.myPlayer);
                                attackcounter1 = 0;
                            }
                            if (attackcounter2 >= 360)
                            {
                                attackcounter1 = 0;
                                attackcounter2 = 0;
                                attackphase = 2;
                            }
                        }
                        if (attackphase == 2)
                        {
                            attackcounter1++;
                            Projectile.velocity.X = 0;
                            Projectile.velocity.Y = 0;
                            if (attackcounter1 == 60)
                            {
                                Terraria.Audio.SoundEngine.PlaySound(SoundLoader.GetLegacySoundSlot(Mod, "Sounds/Item/LargeWeaponFire"), Projectile.Center);
                                Vector2 position = Projectile.Center;
                                position.X = Projectile.Center.X + (10f * Projectile.direction);
                                Vector2 targetPosition = Main.npc[CalValEXGlobalNPC.meldodon].Center;
                                Vector2 direction = targetPosition - position;
                                direction.Normalize();
                                float speed = 18f;
                                int type = ProjectileID.IchorBullet;
                                int damage = Main.expertMode ? 1702 : 2040;
                                Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), position, direction * speed, type, damage, 0f, Main.myPlayer);
                            }
                            if (attackcounter1 >= 120)
                            {
                                attackcounter1 = 0;
                                attackphase = 3;
                            }
                        } 
                        if (attackphase == 3)
                        {
                            attackcounter1++;
                            attackcounter2++;
                            int num412 = 1;
                            float num413 = 25f;
                            float num414 = 1.2f;
                            float distanceX = 580f;
                            float yoffset = -300f;

                            Vector2 vector40 = new Vector2(Projectile.position.X + (float)Projectile.width * 0.5f, Projectile.position.Y + (float)Projectile.height * 0.5f);
                            float num415 = Main.npc[CalValEXGlobalNPC.meldodon].position.X + (float)(Main.npc[CalValEXGlobalNPC.meldodon].width / 2) + (float)(num412 * distanceX) - vector40.X;
                            float num416 = Main.npc[CalValEXGlobalNPC.meldodon].position.Y + (float)(Main.npc[CalValEXGlobalNPC.meldodon].height / 2) + yoffset - vector40.Y;
                            float num417 = (float)Math.Sqrt(num415 * num415 + num416 * num416);
                            num417 = num413 / num417;
                            num415 *= num417;
                            num416 *= num417;
                            if (Projectile.velocity.X < num415)
                            {
                                Projectile.velocity.X += num414;
                                if (Projectile.velocity.X < 0f && num415 > 0f)
                                {
                                    Projectile.velocity.X += num414;
                                }
                            }
                            else if (Projectile.velocity.X > num415)
                            {
                                Projectile.velocity.X -= num414;
                                if (Projectile.velocity.X > 0f && num415 < 0f)
                                {
                                    Projectile.velocity.X -= num414;
                                }
                            }
                            if (Projectile.velocity.Y < num416)
                            {
                                Projectile.velocity.Y += num414;
                                if (Projectile.velocity.Y < 0f && num416 > 0f)
                                {
                                    Projectile.velocity.Y += num414;
                                }
                            }
                            else if (Projectile.velocity.Y > num416)
                            {
                                Projectile.velocity.Y -= num414;
                                if (Projectile.velocity.Y > 0f && num416 < 0f)
                                {
                                    Projectile.velocity.Y -= num414;
                                }
                            }
                            if (attackcounter1 >= 40)
                            {
                                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item, (int)Projectile.Center.X, (int)Projectile.Center.Y, 21);
                                Vector2 position = Projectile.Center;
                                position.X = Projectile.Center.X + (10f * Projectile.direction);
                                Vector2 targetPosition = Main.npc[CalValEXGlobalNPC.meldodon].Center;
                                Vector2 direction = targetPosition - position;
                                direction.Normalize();
                                float speed = 10f;
                                int type = ProjectileID.RainCloudRaining;
                                int damage = Main.expertMode ? 120 : 152;
                                Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), position, direction * speed, type, damage, 0f, Main.myPlayer);
                                attackcounter1 = 0;
                            }
                            if (attackcounter2 >= 460)
                            {
                                attackcounter1 = 0;
                                attackcounter2 = 0;
                                attackphase = 0;
                            }
                        }
                    }
                    break;
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if (deathcounter >= 820)
            {
                return new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, Projectile.alpha);
            }
            else
            {
                return null;
            }
        }

        public override void SafeSendExtraAI(BinaryWriter writer)
        {
            writer.Write(deathcounter);
            writer.Write(lifecounter);
            writer.Write(sandblasttimer);
            writer.Write(mushroom);
            writer.Write(birb);
            writer.Write(minetimer);
            writer.Write(infernadotimer);
            writer.Write(polterdart);
            writer.Write(mine);
            writer.Write(raintype);
            writer.Write(attackphase);
            writer.Write(attackcounter1);
            writer.Write(attackcounter2);
        }

        public override void SafeReceiveExtraAI(BinaryReader reader)
        {
            deathcounter = reader.ReadInt32();
            lifecounter = reader.ReadInt32();
            sandblasttimer = reader.ReadInt32();
            mushroom = reader.ReadInt32();
            birb = reader.ReadInt32();
            minetimer = reader.ReadInt32();
            infernadotimer = reader.ReadInt32();
            polterdart = reader.ReadInt32();
            mine = reader.ReadInt32();
            raintype = reader.ReadInt32();
            attackphase = reader.ReadInt32();
            attackcounter1 = reader.ReadInt32();
            attackcounter2 = reader.ReadInt32();
        }

        public override void PostDraw(Color lightColor)
        {
            Texture2D deusheadsprite;
            if ((attackphase == 1 || attackphase == 2) && Projectile.localAI[1] == 5)
            {
                deusheadsprite = (ModContent.Request<Texture2D>("CalValEX/AprilFools/AmogusGun").Value);
            }
            else if (attackphase == 0 && Projectile.localAI[1] == 5)
            {
                deusheadsprite = (ModContent.Request<Texture2D>("CalValEX/AprilFools/AmogusKnife").Value);
            }
            else
            {
                deusheadsprite = (ModContent.Request<Texture2D>("CalValEX/Items/Equips/Shields/Invishield_Shield").Value);
            }

            int deusheadheight = deusheadsprite.Height;

            Rectangle deusheadsquare = new Rectangle(0, 0, deusheadsprite.Width, deusheadsprite.Height);
            Color deusheadalpha = Projectile.GetAlpha(lightColor);
            Main.EntitySpriteDraw(deusheadsprite, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY + 10), deusheadsquare, deusheadalpha, Projectile.rotation, Utils.Size(deusheadsquare) / 2f, Projectile.scale, Projectile.spriteDirection != 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        }
    }
}