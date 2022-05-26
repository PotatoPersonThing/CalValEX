using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace CalValEX.Projectiles.Boi
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

        //Variable gore
        public bool spawnana = false;
        public bool spawnstuff = false;
        public bool setfield = false;
        public int roomcool = 0;
        public int localboistage = 0;
        int[] rooms = new int[10];
        List<int> enemies = new List<int>() { ModContent.ProjectileType<Brimhita>() };
        Vector2 topdoor = new Vector2(10, -270);
        Vector2 bottomdoor = new Vector2(10, 260);
        Vector2 leftdoor = new Vector2(-420, -20);
        Vector2 rightdoor = new Vector2(1440, -20);
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

            modPlayer.boiactive = true;

            //Assure that the screen is locked on the player
            Projectile.position.X = player.position.X - 400;
            Projectile.position.Y = player.position.Y - 240;

            //Close the screen
            if (player.controlMount)
            {
                modPlayer.boistage = 0;
                modPlayer.boiactive = false;
                Projectile.active = false;
            }
            //The juicy part
            if (modPlayer.boiactive)
            {
                //If the initial contents of the game haven't been spawned, spawn them
                if (!spawnana)
                {
                    //Spawn Anahita. ai[0] is her health + 1
                    SpawnProjectile(new Vector2(-20, -40), ModContent.ProjectileType<Anahita>(), 4);
                    spawnana = true;
                }
                //Spawns the room gates
                if (!spawnstuff)
                {
                    SpawnGates();
                    SpawnProjectile(new Vector2(-280, -40), ModContent.ProjectileType<Brimhita>(), 0, 0);
                    SpawnProjectile(new Vector2(240, -40), ModContent.ProjectileType<Brimhita>(), 1, 1);
                    spawnstuff = true;
                }
                //A cooldown for entering new rooms to prevent infinite room teleporation
                roomcool--;
                //Detection for if Anahita is touching a room transition area
                for (int i = 0; i < Main.maxProjectiles; i++)
                {
                    var proj = Main.projectile[i];

                    if (proj.type == ModContent.ProjectileType<RoomTransition>())
                    {
                        for (int j = 0; j < Main.maxProjectiles; j++)
                        {
                            var proj2 = Main.projectile[j];
                            if (proj != null && proj.active && proj2 != null && proj2.active && proj2.getRect().Intersects(proj.getRect()) && proj2.type == ModContent.ProjectileType<Anahita>() && roomcool <= 0 && rooms[(int)Projectile.localAI[0]] == 1)
                            {
                                //The UI's ai is set to whatever the room transition's ai[0] is. This ai state is what room the UI is in
                                Projectile.localAI[0] = (int)proj.ai[0];
                                roomcool = 40;
                                //Clear room transition and tears
                                ClearStuff();
                                //Spawn new gates
                                SpawnStuff();
                                //Teleport ana to a new room
                                Teleport(proj2, proj);
                            }
                        }
                    }
                }
                { 
                    //Handle room clears
                    bool bossIsAlive = false;
                    for (int i = 0; i < Main.maxNPCs; i++)
                    {
                        Projectile proj = Main.projectile[i];
                        if (proj != null && proj.active && enemies.Contains(proj.type) && proj.alpha <= 0)
                        {
                            bossIsAlive = true;
                        }
                    }
                    if (!bossIsAlive)
                    {
                        rooms[(int)Projectile.localAI[0]] = 1;
                    }
                    else
                    {
                        rooms[(int)Projectile.localAI[0]] = 0;
                    }
                }
            }
        }

        void Teleport(Projectile ana, Projectile gate)
        {
            Player player = Main.player[Projectile.owner];
            Vector2 playp = new Vector2(player.position.X + player.width / 2, player.position.Y + player.height / 2);
            if (player.controlUp && ana.position.Y - player.position.Y < 0)
            {
                ana.position = new Vector2(playp.X - 10, playp.Y + 140);
            }
            else if (player.controlDown && ana.position.Y - player.position.Y >= 0)
            {
                ana.position = new Vector2(playp.X - 10, playp.Y - 215);
            }
            else if (player.controlRight && ana.position.X - player.position.X >= 0)
            {
                ana.position = new Vector2(playp.X - 300, playp.Y);
            }
            else if (player.controlLeft && ana.position.X - player.position.X < 0)
            {
                ana.position = new Vector2(playp.X + 300, playp.Y);
            }
        }
        //Spawn gates based on the room
        void SpawnStuff()
        {
            //Bool for if the current room is clear or not
            bool cler = rooms[(int)Projectile.localAI[0]] == 0;
            
            //Spawn gates on all four sides in the starting room
            //This is THE room
            if (Projectile.localAI[0] == 0)
            {
                SpawnGates();
                //Spawn the enemies
                if (cler)
                {
                    SpawnProjectile(new Vector2(-280, -40), ModContent.ProjectileType<Brimhita>(), 0, 0);
                    SpawnProjectile(new Vector2(240, -40), ModContent.ProjectileType<Brimhita>(), 1, 1);
                }
            }
            //This is the top room
            //Spawn just one gate leading to the starting room on the bottom and one on the top
            if (Projectile.localAI[0] == 1)
            {
                SpawnProjectile(bottomdoor, ModContent.ProjectileType<RoomTransition>(), 0, 1);
                SpawnProjectile(topdoor, ModContent.ProjectileType<RoomTransition>(), 5, 0);
                if (cler)
                {
                    SpawnProjectile(new Vector2(0, -80), ModContent.ProjectileType<Brimhita>(), 2, 2);
                }
            }
            //This is the left room
            //Spawn a gate going to the main room
            if (Projectile.localAI[0] == 2)
            {
                SpawnProjectile(rightdoor, ModContent.ProjectileType<RoomTransition>(), 0, 0);
                if (cler)
                {
                    SpawnProjectile(new Vector2(0, -80), ModContent.ProjectileType<Brimhita>(), 3, 3);
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
        }

        //Spawns gates on all four sides that lead to the main four rooms. This one has its own function because it's called multiple times.
        void SpawnGates()
        {
            //Bottom
            /*Projectile.NewProjectile(new Terraria.DataStructures.EntitySource_WorldEvent(), player.position.X + player.width / 2 + 10, player.position.Y + player.height / 2 + 260,
                0f, 0f, ModContent.ProjectileType<Projectiles.Boi.RoomTransition>(), 0, 0f, player.whoAmI, 3);*/
            SpawnProjectile(leftdoor, ModContent.ProjectileType<RoomTransition>(), 2, 3);
            SpawnProjectile(topdoor, ModContent.ProjectileType<RoomTransition>(), 1, 0);
            //Right
            /*Projectile.NewProjectile(new Terraria.DataStructures.EntitySource_WorldEvent(), player.position.X + player.width / 2 + 440, player.position.Y + player.height / 2 - 20,
                0f, 0f, ModContent.ProjectileType<Projectiles.Boi.RoomTransition>(), 0, 0f, player.whoAmI, 4);*/
        }

        //KILL all tears, items, enemies, and room transitions upon entering a new room
        void ClearStuff()
        {
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                var proj = Main.projectile[i];

                if (proj.type == ModContent.ProjectileType<RoomTransition>() || 
                    proj.type == ModContent.ProjectileType<AnahitaTear>() || 
                    (proj.type == ModContent.ProjectileType<Atlantis>() && proj.ai[1] != 2)) //ai 2 means it's been collected!
                {
                    proj.active = false;
                }
                if (enemies.Contains(proj.type))
                {
                    proj.active = false;
                }
            }
        }

        void SpawnProjectile(Vector2 offset, int type, int ai0 = 0, int ai1 = 0)
        {
            Player player = Main.player[Projectile.owner];
            Projectile.NewProjectile(new Terraria.DataStructures.EntitySource_WorldEvent(), player.position.X + player.width / 2 + offset.X, player.position.Y + player.height / 2 + offset.Y,
                0f, 0f, type, 0, 0f, player.whoAmI, ai0, ai1);
        }

        public override void PostDraw(Color lightColor)
        {
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.boiactive)
            {
                //BG
                Texture2D texture2 = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Pong/PongBG").Value;
                Rectangle rectangle2 = new Rectangle(0, texture2.Height / Main.projFrames[Projectile.type] * Projectile.frame, texture2.Width, texture2.Height / Main.projFrames[Projectile.type]);
                Vector2 position2 = Projectile.Center - Main.screenPosition;
                position2.X += DrawOffsetX;
                position2.Y += DrawOriginOffsetY;
                Main.EntitySpriteDraw(texture2, position2, rectangle2, Color.White, Projectile.rotation, Projectile.Size / 2f, 1.205f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);

                //Room
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/Room").Value;
                Vector2 position = Projectile.Center - Main.screenPosition;
                position.X += DrawOffsetX;
                position.Y += DrawOriginOffsetY;
                Main.EntitySpriteDraw(texture, position, rectangle2, Color.White, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);

                //Healthbar
                for (int i = 0; i < Main.maxProjectiles; i++)
                {
                    var proj = Main.projectile[i];

                    if (proj != null && proj.active && proj.type == ModContent.ProjectileType<Anahita>())
                    {
                        Texture2D mapicon = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/Heart").Value;
                        Rectangle rectangle3 = new Rectangle(0, mapicon.Height / Main.projFrames[Projectile.type] * Projectile.frame, mapicon.Width, mapicon.Height / Main.projFrames[Projectile.type]);
                        Vector2 position3 = Projectile.Center - Main.screenPosition;
                        position3.X = position3.X + DrawOffsetX + 20;
                        position3.Y = position3.Y + DrawOriginOffsetY - 35;
                        for (int cont = 0; cont < proj.ai[0] - 1; cont++)
                        {
                            Main.EntitySpriteDraw(mapicon, new Vector2(position3.X + mapicon.Width * cont, position3.Y), rectangle3, Color.White, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
                        }
                    }
                }
                //Map
                {
                    Texture2D mapicon = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Pong/PongBall").Value;
                    Rectangle rectangle3 = new Rectangle(0, mapicon.Height / Main.projFrames[Projectile.type] * Projectile.frame, mapicon.Width, mapicon.Height / Main.projFrames[Projectile.type]);
                    Vector2 position3 = Projectile.Center - Main.screenPosition;
                    position3.X = position3.X + DrawOffsetX + 460;
                    position3.Y = position3.Y + DrawOriginOffsetY - 150;
                    for (int cont = 0; cont < 6; cont++)
                    {
                        Color cooo = cont == Projectile.localAI[0] ? Color.DarkCyan : Color.White;
                        Main.EntitySpriteDraw(mapicon, new Vector2(position3.X + mapicon.Width * cont, position3.Y), rectangle3, cooo, Projectile.rotation, Projectile.Size / 4f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
                    }
                }
                //Draw projectiles over the UI
                for (int i = 0; i < Main.maxProjectiles; i++)
                {
                    var proj = Main.projectile[i];

                    if (proj != null && proj.active)
                    {
                        if (proj.type == ModContent.ProjectileType<RoomTransition>() && rooms[(int)Projectile.localAI[0]] == 1)
                        BasicProjectileDraw(ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/RoomTransition").Value, proj);
                        if (proj.type == ModContent.ProjectileType<Atlantis>())
                        BasicProjectileDraw(ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/Atlantis").Value, proj, false);
                        if (proj.type == ModContent.ProjectileType<AnahitaTear>())
                        BasicProjectileDraw(ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Pong/PongBall").Value, proj);
                    }
                }
            }
        }

        void BasicProjectileDraw(Texture2D texture, Projectile proj, bool fip = true, float size = 1f)
        {
            Rectangle rectangle23 = new Rectangle(0, texture.Height / Main.projFrames[proj.type] * proj.frame, texture.Width, texture.Height / Main.projFrames[proj.type]);
            SpriteEffects fx = fip ? (proj.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally) : SpriteEffects.None;  
            Main.EntitySpriteDraw(texture, proj.Center - Main.screenPosition, rectangle23, Color.White, proj.rotation, proj.Size / 2f, size, fx, 0);
        }
    }
}