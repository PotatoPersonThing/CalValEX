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
    public class Amogus : ModWalkingPet
    {
        public override bool FacesLeft => false;

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
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Amogus");
            Main.projFrames[projectile.type] = 4; //frames
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 26;
            projectile.height = 26;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            drawOffsetX = -7;
            drawOriginOffsetY = 0;
        }

        public override void ModifyJumpHeight(ref float oneTileHigherAndNotTwoTilesHigher, ref float twoTilesHigher, ref float fourTilesHigher, ref float fiveTilesHigher, ref float anyOtherJump)
        {
            oneTileHigherAndNotTwoTilesHigher = -4f;
            twoTilesHigher = -6f;
            fiveTilesHigher = -8f;
            fourTilesHigher = -7f;
            anyOtherJump = -6.5f;
        }

        public override void Animation(int state)
        {
            switch(state)
            {
                case States.Walking:
                    if (projectile.velocity.X != 0f)
                    {
                        if (++projectile.frameCounter > 8)
                        {
                            projectile.frameCounter = 0;
                            projectile.frame++;
                            if (projectile.frame > 3)
                                projectile.frame = 0;
                        }
                    }
                    else
                    {
                        projectile.frameCounter = 0;
                        projectile.frame = 0;
                    }
                    break;

                case States.Flying:
                    if (++projectile.frameCounter > 10)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;
                        if (projectile.frame > 3)
                            projectile.frame = 0;
                    }
                    break;
            }
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

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
            {
                modPlayer.amogus = false;
                projectile.active = false;
            }
            if (modPlayer.amogus)
                projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float walkingSpeed, float walkingInertia, float flyingSpeed, float flyingInertia)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (deathcounter <= 0 && !player.HasBuff(ModContent.BuffType<AprilFools.AmogusBuff>()) && !NPC.AnyNPCs(ModContent.NPCType<Meldosaurus.Meldosaurus>()))
            {
                projectile.active = false;
            }

            if (NPC.AnyNPCs(ModContent.NPCType<Meldosaurus.Meldosaurus>()) && deathcounter <= 0)
            {
                projectile.tileCollide = false;
                state = 5;
            }

            if ((CalValEX.month != 4 && state != 4 && !CalValEXWorld.amogus) || modPlayer.rockhat)
            {
                deathcounter++;
                if (deathcounter >= 300)
                {
                    state = 3;
                    projectile.timeLeft = 2;
                }
            }
            switch (state)
            {
                case 3:
                    //Main.sunTexture = mod.GetTexture(("AprilFools/AmogusBuff"));
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
                                raintype = calamityMod.ProjectileType("BrimstoneHellblast");
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
                            if (Main.rand.Next(3) == 0)
                            {
                                raintype = calamityMod.ProjectileType("SignusScythe");
                            }
                            else if (Main.rand.Next(2) == 0)
                            {
                                raintype = calamityMod.ProjectileType("ApolloRocket");
                            }
                            else
                            {
                                raintype = calamityMod.ProjectileType("BrimstoneGigaBlast");
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
                    if (deathcounter >= 1000)
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
                        if (minetimer >= 240)
                        {
                            for (int x = 0; x < 8; x++)
                            {
                                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, Main.rand.Next(-2, 2), Main.rand.Next(-2, 2), mine, 80, 0f, Main.myPlayer, 0f, 0f);
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
                        projectile.rotation = 0;
                    }
                    if (deathcounter == 680)
                    {
                        EdgyTalk("That's pretty sus kid, and you know what we do to sussy little ones right?", Color.White, true);
                    }
                    if (deathcounter == 820)
                    {
                        EdgyTalk("We eject them.", Color.DarkRed, true);
                        projectile.alpha = 50;
                        projectile.rotation = 0;
                    }
                    if (deathcounter >= 4200 && !modPlayer.rockhat)
                    {
                        state = 4;
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
                        projectile.scale = 1;
                        state = 0;
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
                            state = 0;
                        }
                        if (attackphase == 0)
                        {
                            attackcounter2--;
                            var thisRect = projectile.getRect();

                            for (int i = 0; i < Main.maxNPCs; i++)
                            {
                                var npc = Main.npc[i];

                                if (npc != null && npc.active && npc.getRect().Intersects(thisRect) && npc.type == ModContent.NPCType<Meldosaurus.Meldosaurus>() && attackcounter2 <= 20)
                                {
                                    if (chargetype == 4)
                                    {
                                        Projectile.NewProjectile((int)npc.Center.X, (int)npc.Center.Y, 0, 0, ModContent.ProjectileType<CalamityMod.Projectiles.Rogue.ScarletBlast>(), 2020, 0, Main.myPlayer);
                                    }
                                    else
                                    {
                                        Projectile.NewProjectile((int)npc.Center.X, (int)npc.Center.Y, 0, 0, ModContent.ProjectileType<CalamityMod.Projectiles.Typeless.FuckYou>(), 1020, 0, Main.myPlayer);
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
                                    projectile.position.X = Main.npc[CalValEXGlobalNPC.meldodon].Center.X - 100;
                                    projectile.position.Y = Main.npc[CalValEXGlobalNPC.meldodon].Center.Y;
                                }
                                if (attackcounter1 == chargedelay + 1) //Exactly 31
                                {
                                    projectile.velocity.X = 20;
                                    projectile.velocity.Y = 0;
                                    attackmoment = 0 + chargedelay + chargedist; //Set the counter to 40
                                    chargetype = 1;
                                }
                            }
                            if (chargetype == 1)
                            {
                                if (attackcounter1 >= attackmoment && attackcounter1 <= attackmoment + chargedelay) //Between 40 and 70
                                {
                                    projectile.position.Y = Main.npc[CalValEXGlobalNPC.meldodon].Center.Y - 100;
                                    projectile.position.X = Main.npc[CalValEXGlobalNPC.meldodon].Center.X;
                                }
                                if (attackcounter1 == attackmoment + chargedelay + 1) //71
                                {
                                    projectile.velocity.Y = 20;
                                    projectile.velocity.X = 0;
                                    attackmoment = attackmoment + chargedelay + chargedist; //80
                                    chargetype = 2;
                                }
                            }
                            if (chargetype == 2)
                            {
                                if (attackcounter1 >= attackmoment && attackcounter1 <= attackmoment + chargedelay) //Between 80 and 110
                                {
                                    projectile.position.Y = Main.npc[CalValEXGlobalNPC.meldodon].Center.Y + 100;
                                    projectile.position.X = Main.npc[CalValEXGlobalNPC.meldodon].Center.X - 100;
                                }
                                if (attackcounter1 == attackmoment + chargedelay + 1) //111
                                {
                                    projectile.velocity.X = 20;
                                    projectile.velocity.Y = -20;
                                    attackmoment = attackmoment + chargedelay + chargedist; //120
                                    chargetype = 3;
                                }
                            }
                            if (chargetype == 3)
                            {
                                if (attackcounter1 >= attackmoment && attackcounter1 <= attackmoment + chargedelay) //Between 120 and 150
                                {
                                    projectile.position.Y = Main.npc[CalValEXGlobalNPC.meldodon].Center.Y - 100;
                                    projectile.position.X = Main.npc[CalValEXGlobalNPC.meldodon].Center.X + 100;
                                }
                                if (attackcounter1 == attackmoment + chargedelay + 1) //151
                                {
                                    projectile.velocity.X = -20;
                                    projectile.velocity.Y = +20;
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

                            Vector2 vector40 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                            float num415 = Main.npc[CalValEXGlobalNPC.meldodon].position.X + (float)(Main.npc[CalValEXGlobalNPC.meldodon].width / 2) + (float)(num412 * distanceX) - vector40.X;
                            float num416 = Main.npc[CalValEXGlobalNPC.meldodon].position.Y + (float)(Main.npc[CalValEXGlobalNPC.meldodon].height / 2) + yoffset - vector40.Y;
                            float num417 = (float)Math.Sqrt(num415 * num415 + num416 * num416);
                            num417 = num413 / num417;
                            num415 *= num417;
                            num416 *= num417;
                            if (projectile.velocity.X < num415)
                            {
                                projectile.velocity.X += num414;
                                if (projectile.velocity.X < 0f && num415 > 0f)
                                {
                                    projectile.velocity.X += num414;
                                }
                            }
                            else if (projectile.velocity.X > num415)
                            {
                                projectile.velocity.X -= num414;
                                if (projectile.velocity.X > 0f && num415 < 0f)
                                {
                                    projectile.velocity.X -= num414;
                                }
                            }
                            if (projectile.velocity.Y < num416)
                            {
                                projectile.velocity.Y += num414;
                                if (projectile.velocity.Y < 0f && num416 > 0f)
                                {
                                    projectile.velocity.Y += num414;
                                }
                            }
                            else if (projectile.velocity.Y > num416)
                            {
                                projectile.velocity.Y -= num414;
                                if (projectile.velocity.Y > 0f && num416 < 0f)
                                {
                                    projectile.velocity.Y -= num414;
                                }
                            }
                            if (attackcounter1 >= 5)
                            {
                                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 41);
                                Vector2 position = projectile.Center;
                                position.X = projectile.Center.X + (10f * projectile.direction);
                                Vector2 targetPosition = Main.npc[CalValEXGlobalNPC.meldodon].Center;
                                Vector2 direction = targetPosition - position;
                                direction.Normalize();
                                float speed = 15f;
                                int type = ModContent.ProjectileType<CalamityMod.Projectiles.Ranged.AccelerationBulletProj>();
                                int damage = Main.expertMode ? 60 : 95;
                                Projectile.NewProjectile(position, direction * speed, type, damage, 0f, Main.myPlayer);
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
                            projectile.velocity.X = 0;
                            projectile.velocity.Y = 0;
                            if (attackcounter1 == 60)
                            {
                                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/LargeWeaponFire"), projectile.Center);
                                Vector2 position = projectile.Center;
                                position.X = projectile.Center.X + (10f * projectile.direction);
                                Vector2 targetPosition = Main.npc[CalValEXGlobalNPC.meldodon].Center;
                                Vector2 direction = targetPosition - position;
                                direction.Normalize();
                                float speed = 18f;
                                int type = ModContent.ProjectileType<CalamityMod.Projectiles.Ranged.AMRShot>();
                                int damage = Main.expertMode ? 1702 : 2040;
                                Projectile.NewProjectile(position, direction * speed, type, damage, 0f, Main.myPlayer);
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

                            Vector2 vector40 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                            float num415 = Main.npc[CalValEXGlobalNPC.meldodon].position.X + (float)(Main.npc[CalValEXGlobalNPC.meldodon].width / 2) + (float)(num412 * distanceX) - vector40.X;
                            float num416 = Main.npc[CalValEXGlobalNPC.meldodon].position.Y + (float)(Main.npc[CalValEXGlobalNPC.meldodon].height / 2) + yoffset - vector40.Y;
                            float num417 = (float)Math.Sqrt(num415 * num415 + num416 * num416);
                            num417 = num413 / num417;
                            num415 *= num417;
                            num416 *= num417;
                            if (projectile.velocity.X < num415)
                            {
                                projectile.velocity.X += num414;
                                if (projectile.velocity.X < 0f && num415 > 0f)
                                {
                                    projectile.velocity.X += num414;
                                }
                            }
                            else if (projectile.velocity.X > num415)
                            {
                                projectile.velocity.X -= num414;
                                if (projectile.velocity.X > 0f && num415 < 0f)
                                {
                                    projectile.velocity.X -= num414;
                                }
                            }
                            if (projectile.velocity.Y < num416)
                            {
                                projectile.velocity.Y += num414;
                                if (projectile.velocity.Y < 0f && num416 > 0f)
                                {
                                    projectile.velocity.Y += num414;
                                }
                            }
                            else if (projectile.velocity.Y > num416)
                            {
                                projectile.velocity.Y -= num414;
                                if (projectile.velocity.Y > 0f && num416 < 0f)
                                {
                                    projectile.velocity.Y -= num414;
                                }
                            }
                            if (attackcounter1 >= 40)
                            {
                                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 21);
                                Vector2 position = projectile.Center;
                                position.X = projectile.Center.X + (10f * projectile.direction);
                                Vector2 targetPosition = Main.npc[CalValEXGlobalNPC.meldodon].Center;
                                Vector2 direction = targetPosition - position;
                                direction.Normalize();
                                float speed = 10f;
                                int type = ProjectileID.RainCloudRaining;
                                int damage = Main.expertMode ? 120 : 152;
                                Projectile.NewProjectile(position, direction * speed, type, damage, 0f, Main.myPlayer);
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
                return new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, projectile.alpha);
            }
            else
            {
                return null;
            }
        }

        public override void SendExtraAI(BinaryWriter writer)
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
            base.SendExtraAI(writer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
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
            base.ReceiveExtraAI(reader);
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D deusheadsprite;
            if ((attackphase == 1 || attackphase == 2) && state == 5)
            {
                deusheadsprite = (ModContent.GetTexture("CalValEX/AprilFools/AmogusGun"));
            }
            else if (attackphase == 0 && state == 5)
            {
                deusheadsprite = (ModContent.GetTexture("CalValEX/AprilFools/AmogusKnife"));
            }
            else
            {
                deusheadsprite = (ModContent.GetTexture("CalValEX/Items/Equips/Shields/Invishield_Shield"));
            }

            int deusheadheight = deusheadsprite.Height;

            Rectangle deusheadsquare = new Rectangle(0, 0, deusheadsprite.Width, deusheadsprite.Height);
            Color deusheadalpha = projectile.GetAlpha(lightColor);
            spriteBatch.Draw(deusheadsprite, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY + 10), deusheadsquare, deusheadalpha, projectile.rotation, Utils.Size(deusheadsquare) / 2f, projectile.scale, projectile.spriteDirection != 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
        }
    }
}