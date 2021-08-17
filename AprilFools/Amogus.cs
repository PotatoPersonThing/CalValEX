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
        private bool talk1 = false;
        private bool talk2 = false;
        private bool talk3 = false;
        private bool talk4 = false;
        private bool talk5 = false;
        private bool talk6 = false;
        private bool talk7 = false;
        private bool talk8 = false;
        private bool talk9 = false;
        private bool talk10 = false;
        int sandblasttimer = 0;
        int mushroom = 0;
        int birb = 1200;
        int minetimer = 0;
        int infernadotimer = 1200;
        int polterdart = 0;
        int mine;
        int raintype;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amogus");
            Main.projFrames[projectile.type] = 4; //frames
            Main.projPet[projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            base.drawOffsetX = -7;
            base.drawOriginOffsetY = 0;
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
                CombatText.NewText(projectile.getRect(), color, text, true);
            }
            else
            {
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText(text, color);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromKey(text), color);
                }
            }
        }

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
            { 
                modPlayer.amogus = false;
                projectile.active = false;
                talk1 = false;
                talk2 = false;
                talk3 = false;
                talk4 = false;
                talk5 = false;
                talk6 = false;
                talk7 = false;
                talk8 = false;
                talk9 = false;
            }
            if (modPlayer.amogus)
                projectile.timeLeft = 2;

            /* THIS CODE ONLY RUNS AFTER THE MAIN CODE RAN.
             * for custom behaviour, you can check if the projectile is walking or not via projectile.localAI[1]
             * you should make new custom behaviour with numbers higher than 2, or less than 0
             * the next few lines is an example on how to implement this
             *
             * switch ((int)projectile.localAI[1])
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
            if ((CalValEX.month != 4 && projectile.localAI[1] != 4 && !CalValEXWorld.amogus) || modPlayer.rockhat)
            {
                deathcounter++;
                if (deathcounter >= 300)
                {
                    projectile.localAI[1] = 3;
                    projectile.timeLeft = 2;
                }
            }
            switch ((int)projectile.localAI[1])
            {
                case 3:
                    Mod calamityMod = ModLoader.GetMod("CalamityMod");
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
                                raintype = calamityMod.ProjectileType("SandBlast");
                            }
                            else
                            {
                                raintype = calamityMod.ProjectileType("AbyssBallVolley");
                            }
                        }
                        else if (deathcounter > 1800 && deathcounter <= 2700)
                        {
                            if (Main.rand.Next(2) == 0)
                            {
                                raintype = calamityMod.ProjectileType("BrimstoneLaser");
                            }
                            else
                            {
                                raintype = calamityMod.ProjectileType("AstralLaser");
                            }
                        }
                        else if (deathcounter > 2700 && deathcounter <= 3600)
                        {
                            if (Main.rand.Next(2) == 0)
                            {
                                raintype = calamityMod.ProjectileType("BrimstoneBarrage");
                            }
                            else
                            {
                                raintype = calamityMod.ProjectileType("ProfanedSpear");
                            }
                        }
                        else if (deathcounter > 3600)
                        {
                            if (Main.rand.Next(2) == 0)
                            {
                                raintype = calamityMod.ProjectileType("SignusScythe");
                            }
                            else
                            {
                                raintype = calamityMod.ProjectileType("BrimstoneHellblast");
                            }
                        }

                        if (sandblasttimer >= 10)
                        {
                            Projectile.NewProjectile(playerpos.X, playerpos.Y, 0, 5, raintype, 80, 0f, Main.myPlayer, 0f, 0f);
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
                                Main.PlaySound(SoundID.Item11);
                            }
                            Projectile.NewProjectile(playerpos.X, playerpos.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, -3), calamityMod.ProjectileType("MushBomb"), 180, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(playerpos.X, playerpos.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, -3), calamityMod.ProjectileType("IchorShot"), 90, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(playerpos.X, playerpos.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, -3), calamityMod.ProjectileType("IceRain"), 180, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(playerpos.X, playerpos.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, -3), calamityMod.ProjectileType("MoltenBlob"), 120, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(playerpos.X, playerpos.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, -3), calamityMod.ProjectileType("ShadeNimbusHostile"), 80, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(playerpos.X, playerpos.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, -3), calamityMod.ProjectileType("OldDukeGore"), 80, 0f, Main.myPlayer, 0f, 0f);
                            if (deathcounter >= 2700)
                            {
                                Projectile.NewProjectile(playerpos.X, playerpos.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, -3), calamityMod.ProjectileType("ScavengerLaser"), 80, 0f, Main.myPlayer, 0f, 0f);
                                Projectile.NewProjectile(playerpos.X, playerpos.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, -3), calamityMod.ProjectileType("PlagueStingerGoliath"), 80, 0f, Main.myPlayer, 0f, 0f);
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
                            Projectile.NewProjectile(playerpos.X, playerpos.Y, 1, 20, calamityMod.ProjectileType("BirbAuraFlare"), 0, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(playerpos.X, playerpos.Y, 0, 0, calamityMod.ProjectileType("DoGBeamPortal"), 0, 0f, Main.myPlayer, 0f, 0f);
                            birb = 0;
                        }
                    }
                    if (deathcounter >= 1200)
                    {
                        if (deathcounter <= 1800)
                        {
                            mine = calamityMod.ProjectileType("DeusMine");
                        }
                        else if (deathcounter >= 1800 && deathcounter <= 2700)
                        {
                            mine = calamityMod.ProjectileType("SirenSong");
                        }
                        else if (deathcounter >= 2700)
                        {
                            mine = calamityMod.ProjectileType("SandPoisonCloud");
                        }

                        minetimer++;
                        if (minetimer >= 1200)
                        {
                            for (int x = 0; x < 8; x++)
                            {
                                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, Main.rand.Next(-2, 2), Main.rand.Next(-2, 2), mine, 0, 0f, Main.myPlayer, 0f, 0f);
                                minetimer = 0;
                            }
                        }
                    }
                    if (deathcounter >= 1800)
                    {
                        infernadotimer++;
                        if (infernadotimer >= 1200)
                        {
                            Projectile.NewProjectile(playerpos.X, playerpos.Y, 0, 20, calamityMod.ProjectileType("BigFlare"), 0, 0f, Main.myPlayer, 0f, 0f);
                            infernadotimer = 0;
                        }
                    }
                    if (deathcounter >= 2700)
                    {
                        polterdart++;
                        if (polterdart >= 60)
                        {
                            Projectile.NewProjectile(playerpos.X, playerpos.Y, 14, 0, calamityMod.ProjectileType("PhantomGhostShot"), 80, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(playerpos.X, playerpos.Y, -14, 0, calamityMod.ProjectileType("PhantomGhostShot"), 80, 0f, Main.myPlayer, 0f, 0f);
                            polterdart = 0;
                        }
                    }
                    if (deathcounter <= 540)
                    {
                        projectile.velocity.X = 0;
                        projectile.velocity.Y = 0;
                    }
                    if (deathcounter > 540 && deathcounter <= 900)
                    {
                        projectile.position.Y = player.position.Y;
                        projectile.position.X = player.position.X + 256;
                    }
                    if (deathcounter > 900)
                    {
                        projectile.position.Y = player.position.Y - 256;
                        projectile.position.X = player.position.X;
                    }
                    if (deathcounter > 540 && deathcounter < 820)
                    {
                        projectile.scale *= 1.008f;
                        if (projectile.frameCounter++ > 4)
                        {
                            projectile.frameCounter = 0;
                            projectile.frame++;
                            if (projectile.frame >= 4)
                                projectile.frame = 0;
                        }
                    }
                    if (deathcounter == 300 && !talk1)
                    {
                        EdgyTalk("HOOOOOOOOOOOOOOOOLD UP", Color.White, true);
                        talk1 = true;
                    }
                    if (deathcounter == 420 && !talk2)
                    {
                        EdgyTalk("This isn't April... why am I here...", Color.White, true);
                        talk2 = true;
                    }
                    if (deathcounter == 540 && !talk3)
                    {
                        EdgyTalk("Could it be that... Someone has been cheating!? AN IMPOSTER EVEN?!?!?!", Color.White, true);
                        talk3 = true;
                        projectile.rotation = 0;
                    }
                    if (deathcounter == 680 && !talk4)
                    {
                        EdgyTalk("That's pretty sus kid, and you know what we do to sussy little ones right?", Color.White, true);
                        talk4 = true;
                    }
                    if (deathcounter == 820 && !talk5)
                    {
                        EdgyTalk("We eject them.", Color.DarkRed, true);
                        talk5 = true;
                        projectile.alpha = 50;
                        projectile.rotation = 0;
                    }
                    if (deathcounter >= 4200 && !modPlayer.rockhat)
                    {
                        projectile.localAI[1] = 4;
                    }
                    break;

                case 4:
                    lifecounter++;
                    deathcounter = 0;
                    if (lifecounter < 420)
                    {
                        projectile.position.Y = player.position.Y - 256;
                        projectile.position.X = player.position.X;
                    }
                    else if (lifecounter >= 420 && lifecounter < 680)
                    {
                        projectile.position.X = player.position.X - 256;
                        projectile.position.Y = player.position.Y;
                    }
                    if (lifecounter == 300 && !talk6)
                    {
                        EdgyTalk("Interesting, you survived...", Color.White, true);
                        talk6 = true;
                    }
                    if (lifecounter == 420 && !talk7)
                    {
                        EdgyTalk("You probably cheated tbh, or the attacks weren't working properly.", Color.White, true);
                        talk7 = true;
                    }
                    if (lifecounter == 540 && !talk8)
                    {
                        EdgyTalk("Oh well, guess you prooved your worthiness to me. Wear the stone hat if you wanna go again.", Color.White, true);
                        talk8 = true;
                        CalValEXWorld.amogus = true;
                        CalValEXWorld.UpdateWorldBool();
                    }
                    if (lifecounter == 680 && !talk9)
                    {
                        projectile.scale = 1;
                        projectile.localAI[1] = 0;
                        deathcounter = 0;
                        lifecounter = 0;
                        talk1 = false;
                        talk2 = false;
                        talk3 = false;
                        talk4 = false;
                        talk5 = false;
                        talk6 = false;
                        talk7 = false;
                        talk8 = false;
                        talk9 = false;
                    }
                    break;
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if (deathcounter >= 820)
            {
                return new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, projectile.alpha);
            }
            else
            {
                return null;
            }
        }
    }
}