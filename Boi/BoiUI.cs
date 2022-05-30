using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using CalValEX.Boi.BaseClasses;

namespace CalValEX.Boi
{
    public class BoiUI : ModProjectile
    {
        //ROOM IDS
        //0 = Starting room
        //1 = Above starting room
        //5 = Item room
        //2 = Left room
        //3 = Bottom room
        //4 = Right room
        //6 = Miniboss room
        //7 = Corridor
        //8 = Final room
        //9 = Boss
        //10 = Secret Room

        /*
        //Variable gore
        public bool spawnana = false;
        public bool spawnstuff = false;
        public bool setfield = false;
        public bool secret = false;
        public int roomcool = 0;
        public int localboistage = 0;
        int[] rooms = new int[10];
        List<int> enemies = new List<int>() { ModContent.ProjectileType<Brimhita>(), ModContent.ProjectileType<Spider>(), ModContent.ProjectileType<Mire>(), ModContent.ProjectileType<Terror>() };
        List<int> objects = new List<int>() { ModContent.ProjectileType<BoiRock>() };
        Vector2 topdoor = new Vector2(10, -270);
        Vector2 bottomdoor = new Vector2(10, 260);
        Vector2 leftdoor = new Vector2(-420, -20);
        Vector2 rightdoor = new Vector2(435, -20);
        */

        public ref float Initialized => ref Projectile.ai[0];

        public override string Texture => "CalValEX/ExtraTextures/Pong/PongBG";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Boi UI");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            Projectile.width = 832;
            Projectile.height = 512;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 18000;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            player.AddBuff(Terraria.ID.BuffID.Invisibility, 2);
            //player.AddBuff(Terraria.ID.BuffID.Stoned, 2);

            modPlayer.boiactive = true;
            player.velocity = Vector2.Zero;

            //Close the screen
            if (player.controlMount)
            {
                BoiHandler.Unload();
                modPlayer.boistage = 0;
                modPlayer.boiactive = false;
                Projectile.active = false;
            }

            //The juicy part
            if (modPlayer.boiactive)
            {
                //If the initial contents of the game haven't been spawned, spawn them
                if (Initialized == 0f)
                {
                    BoiHandler.Initialize();
                    Initialized = 1f;
                }

                BoiHandler.Run();
            }
        }



        //Convert that into room layouts in RoomGenerator.cs
        /*
        //Spawn gates based on the room
        void SpawnStuff()
        {
            Player player = Main.player[Projectile.owner];
            //Bool for if the current room is clear or not
            bool cler = rooms[(int)Projectile.localAI[0]] == 0;
            
            //Spawn gates on all four sides in the starting room
            //This is THE room
            if (Projectile.localAI[0] == 0)
            {
                SpawnGates();
            }
            //This is the top room
            //Spawn just one gate leading to the starting room on the bottom and one on the top
            if (Projectile.localAI[0] == 1)
            {
                SpawnProjectile(bottomdoor, ModContent.ProjectileType<RoomTransition>(), 0, 2);
                SpawnProjectile(topdoor, ModContent.ProjectileType<RoomTransition>(), 5, 0);
                //Spawn the enemies
                if (cler)
                {
                    SpawnProjectile(new Vector2(-280, -40), ModContent.ProjectileType<Brimhita>(), 0, 0);
                    SpawnProjectile(new Vector2(240, -40), ModContent.ProjectileType<Brimhita>(), 1, 1);
                }
            }
            //This is the left room
            //Spawn a gate going to the main room
            if (Projectile.localAI[0] == 2)
            {
                SpawnProjectile(rightdoor, ModContent.ProjectileType<RoomTransition>(), 0, 1);
                SpawnProjectile(new Vector2(0, 0), ModContent.ProjectileType<BoiRock>());
                if (cler)
                {
                    SpawnProjectile(new Vector2(0, -100), ModContent.ProjectileType<Brimhita>(), 3, 3);
                    SpawnProjectile(new Vector2(0, 100), ModContent.ProjectileType<Spider>(), 3, 3);
                }
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (i == 0) //Leave a space for Ana to move through
                        {
                            Vector2 rockpos = new Vector2(player.position.X + player.width / 2 - 330 + (i * 90 + i * 6), player.position.Y + player.height / 2 - 192 + j * 90);
                            if (j > 2)
                            {
                                rockpos.Y -= 10;
                            }
                            SpawnProjectile(rockpos, ModContent.ProjectileType<BoiRock>(), 0, 0, true);
                        }
                    }
                }
            }
            //This is the bottom room
            //Spawn a gate going to the main room
            if (Projectile.localAI[0] == 3)
            {
                SpawnProjectile(topdoor, ModContent.ProjectileType<RoomTransition>(), 0, 0);
                SpawnProjectile(bottomdoor, ModContent.ProjectileType<RoomTransition>(), 6, 2);
                if (cler)
                {
                    SpawnProjectile(new Vector2(-80, -80), ModContent.ProjectileType<Spider>(), 0, 0);
                    SpawnProjectile(new Vector2(240, -80), ModContent.ProjectileType<Spider>(), 1, 1);
                    SpawnProjectile(new Vector2(-80, 80), ModContent.ProjectileType<Spider>(), 0, 0);
                    SpawnProjectile(new Vector2(240, 80), ModContent.ProjectileType<Spider>(), 1, 1);
                }
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (j != 2 && i < 1 || i > 6) 
                        {
                            Vector2 rockpos = new Vector2(player.position.X + player.width / 2 - 330 + (i * 90 + i * 6), player.position.Y + player.height / 2 - 192 + j * 90);
                            if (j > 2)
                            {
                                rockpos.Y -= 10;
                            }
                            SpawnProjectile(rockpos, ModContent.ProjectileType<BoiRock>(), 0, 0, true);
                        }
                    }
                }
            }
            //This is the right room, a corrodor
            //Spawn a gate going to the main room. Also spawn a shitton of rocks
            if (Projectile.localAI[0] == 4)
            {
                SpawnProjectile(leftdoor, ModContent.ProjectileType<RoomTransition>(), 0, 3);
                SpawnProjectile(rightdoor, ModContent.ProjectileType<RoomTransition>(), 8, 1);
                for (int i =0; i < 8; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (j != 2) //Leave a space for Ana to move through
                        {
                            Vector2 rockpos = new Vector2(player.position.X + player.width / 2 - 330 + (i * 90 + i * 6), player.position.Y + player.height / 2 - 192 + j * 90);
                            if (j > 2)
                            {
                                rockpos.Y -= 10;
                            }
                            SpawnProjectile(rockpos, ModContent.ProjectileType<BoiRock>(), 0, 0, true);
                        }
                    }
                }
            }
            //This is the item room
            //Spawn a gate going to the mono enemy room
            if (Projectile.localAI[0] == 5)
            {
                SpawnProjectile(bottomdoor, ModContent.ProjectileType<RoomTransition>(), 1, 2);
                if (!CalValEX.DetectProjectile(ModContent.ProjectileType<Atlantis>()))
                SpawnProjectile(new Vector2(10, -100), ModContent.ProjectileType<Atlantis>());
            }
            //This is the miniboss room
            //Spawn a gate going to the bottom middle room
            if (Projectile.localAI[0] == 6)
            {
                SpawnProjectile(topdoor, ModContent.ProjectileType<RoomTransition>(), 3, 0);
                if (cler)
                {
                    SpawnProjectile(new Vector2(0, -50), ModContent.ProjectileType<Mire>(), 3, 3);
                }
            }
            //This is the final normal room
            //Spawn a gate going to the corridor
            if (Projectile.localAI[0] == 8)
            {
                SpawnProjectile(leftdoor, ModContent.ProjectileType<RoomTransition>(), 4, 3);
                SpawnProjectile(rightdoor, ModContent.ProjectileType<RoomTransition>(), 9, 1);
                if (cler)
                {
                    SpawnProjectile(new Vector2(-80, -80), ModContent.ProjectileType<Brimhita>(), 0, 0);
                    SpawnProjectile(new Vector2(240, -80), ModContent.ProjectileType<Brimhita>(), 1, 1);
                    SpawnProjectile(new Vector2(-80, 80), ModContent.ProjectileType<Brimhita>(), 0, 0);
                    SpawnProjectile(new Vector2(240, 80), ModContent.ProjectileType<Brimhita>(), 1, 1);
                }
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if ((i == 0 && j == 0) || (i == 7 && j == 4) || (i == 7 && j == 0) || (i == 0 && j == 4)) 
                        {
                            Vector2 rockpos = new Vector2(player.position.X + player.width / 2 - 330 + (i * 90 + i * 6), player.position.Y + player.height / 2 - 192 + j * 90);
                            if (j > 2)
                            {
                                rockpos.Y -= 10;
                            }
                            SpawnProjectile(rockpos, ModContent.ProjectileType<BoiRock>(), 0, 0, true);
                        }
                    }
                }
            }
            //Boss room
            if (Projectile.localAI[0] == 9)
            {
                SpawnProjectile(leftdoor, ModContent.ProjectileType<RoomTransition>(), 8, 3);
                if (cler)
                {
                    SpawnProjectile(new Vector2(0, -50), ModContent.ProjectileType<Terror>(), 60, 0);
                }
            }
        }
        */

        public override bool PreDraw(ref Color lightColor)
        {
            BoiHandler.Draw(Main.spriteBatch);
            return false;
        }

    }
}