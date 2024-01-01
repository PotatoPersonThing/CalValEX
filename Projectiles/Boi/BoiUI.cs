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
        public bool secret = false;
        public int roomcool = 0;
        public int localboistage = 0;
        int[] rooms = new int[10];
        List<int> enemies = new() { ModContent.ProjectileType<Brimhita>(), ModContent.ProjectileType<Spider>(), ModContent.ProjectileType<Mire>(), ModContent.ProjectileType<Terror>() };
        List<int> objects = new() { ModContent.ProjectileType<BoiRock>() };
        Vector2 topdoor = new(10, -270);
        Vector2 bottomdoor = new(10, 260);
        Vector2 leftdoor = new(-420, -20);
        Vector2 rightdoor = new(435, -20);
        public override string Texture => "CalValEX/ExtraTextures/Pong/PongBG";

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Boi UI");
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
                    SpawnProjectile(new Vector2(10, 40), ModContent.ProjectileType<Anahita>(), 4);
                    spawnana = true;
                }
                //Spawns the room gates
                if (!spawnstuff)
                {
                    SpawnGates();
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
                            if (proj2.getRect().Intersects(proj.getRect()) && proj != null && proj.active && proj2 != null && proj2.active && proj2.type == ModContent.ProjectileType<Anahita>() && roomcool <= 0 && rooms[(int)Projectile.localAI[0]] == 1)
                            {
                                //Teleport ana to a new room
                                Teleport(proj2, (int)proj.ai[1]);
                                //The UI's ai is set to whatever the room transition's ai[0] is. This ai state is what room the UI is in
                                Projectile.localAI[0] = (int)proj.ai[0];
                                roomcool = 40;
                                //Clear room transition and tears
                                ClearStuff();
                                //Spawn new gates
                                SpawnStuff();
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

        void Teleport(Projectile ana, int boxtype)
        {
            Player player = Main.player[Projectile.owner];
            Vector2 playp = new(player.position.X + player.width / 2, player.position.Y + player.height / 2);
            switch (boxtype)
            {
                //Top door
                case 0:
                    ana.position = new Vector2(playp.X - 18, playp.Y + 140);
                    break;
                //Right door
                case 1:
                    ana.position = new Vector2(playp.X - 340, playp.Y - 30);
                    break;
                //Bottom door
                case 2:
                    ana.position = new Vector2(playp.X - 18, playp.Y - 215);
                    break;
                //Left door
                case 3:
                    ana.position = new Vector2(playp.X + 300, playp.Y - 30);
                    break;

            }
        }
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
                            Vector2 rockpos = new(player.position.X + player.width / 2 - 330 + (i * 90 + i * 6), player.position.Y + player.height / 2 - 192 + j * 90);
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
                            Vector2 rockpos = new(player.position.X + player.width / 2 - 330 + (i * 90 + i * 6), player.position.Y + player.height / 2 - 192 + j * 90);
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
                            Vector2 rockpos = new(player.position.X + player.width / 2 - 330 + (i * 90 + i * 6), player.position.Y + player.height / 2 - 192 + j * 90);
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
                            Vector2 rockpos = new(player.position.X + player.width / 2 - 330 + (i * 90 + i * 6), player.position.Y + player.height / 2 - 192 + j * 90);
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

        //Spawns gates on all four (two atm) sides that lead to the main four rooms. This one has its own function because it's called multiple times.
        void SpawnGates()
        {
            SpawnProjectile(topdoor, ModContent.ProjectileType<RoomTransition>(), 1, 0);
            SpawnProjectile(leftdoor, ModContent.ProjectileType<RoomTransition>(), 2, 3);
            SpawnProjectile(bottomdoor, ModContent.ProjectileType<RoomTransition>(), 3, 2);
            SpawnProjectile(rightdoor, ModContent.ProjectileType<RoomTransition>(), 4, 1);
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
                if (enemies.Contains(proj.type) || objects.Contains(proj.type))
                {
                    proj.active = false;
                }
            }
        }

        void SpawnProjectile(Vector2 offset, int type, int ai0 = 0, int ai1 = 0, bool posover = false)
        {
            Player player = Main.player[Projectile.owner];
            if (!posover)
            Projectile.NewProjectile(new Terraria.DataStructures.EntitySource_WorldEvent(), player.position.X + player.width / 2 + offset.X, player.position.Y + player.height / 2 + offset.Y,
                0f, 0f, type, 0, 0f, player.whoAmI, ai0, ai1);
            else
                Projectile.NewProjectile(new Terraria.DataStructures.EntitySource_WorldEvent(), offset.X, offset.Y,
                    0f, 0f, type, 0, 0f, player.whoAmI, ai0, ai1);
        }

        public override void PostDraw(Color lightColor)
        {
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.boiactive)
            {
                //Draw base screen
                BasicProjectileDraw(ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Pong/PongBG").Value, Projectile, Color.White, true, 1.205f);

                //Draw room border
                BasicProjectileDraw(ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/Room").Value, Projectile, Color.White);

                //Draw closed doors
                for (int i = 0; i < Main.maxProjectiles; i++)
                {
                    var proj = Main.projectile[i];

                    if (proj != null && proj.active)
                    {
                        if (proj.type == ModContent.ProjectileType<RoomTransition>() && rooms[(int)Projectile.localAI[0]] != 1)
                        {
                            Vector2 position3 = proj.Center - Main.screenPosition;
                            float orientation = 0f;
                            switch (proj.ai[1])
                            {
                                case 0:
                                    orientation = 0f;
                                    position3.Y += 72;
                                    break;
                                case 2:
                                    orientation = 0f;
                                    position3.Y += 4;
                                    break;
                                case 1:
                                    orientation = MathHelper.Pi / 2;
                                    position3.X -= 75;
                                    break;
                                case 3:
                                    orientation = MathHelper.Pi / 2;
                                    position3.X += 1;
                                    break;
                            }
                            Texture2D mapicon = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/Door").Value;
                            Rectangle rectangle3 = new(0, mapicon.Height / Main.projFrames[proj.type] * proj.frame, mapicon.Width, mapicon.Height / Main.projFrames[proj.type]);
                            Main.EntitySpriteDraw(mapicon, new Vector2(position3.X, position3.Y), rectangle3, Color.YellowGreen, orientation, proj.Size / 2f, 1f, (proj.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);

                        }
                    }
                }

                //Healthbar
                for (int i = 0; i < Main.maxProjectiles; i++)
                {
                    var proj = Main.projectile[i];

                    if (proj != null && proj.active && proj.type == ModContent.ProjectileType<Anahita>())
                    {
                        Texture2D mapicon = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/Heart").Value;
                        Rectangle rectangle3 = new(0, mapicon.Height / Main.projFrames[Projectile.type] * Projectile.frame, mapicon.Width, mapicon.Height / Main.projFrames[Projectile.type]);
                        Vector2 position3 = Projectile.Center - Main.screenPosition;
                        position3.X = position3.X + DrawOffsetX + 20;
                        position3.Y = position3.Y + DrawOriginOffsetY - 35;
                        for (int cont = 0; cont < 3; cont++)
                        {
                            Main.EntitySpriteDraw(mapicon, new Vector2(position3.X + mapicon.Width * cont, position3.Y), rectangle3, Color.DarkGray, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
                        }
                        for (int cont = 0; cont < proj.ai[0] - 1; cont++)
                        {
                            Main.EntitySpriteDraw(mapicon, new Vector2(position3.X + mapicon.Width * cont, position3.Y), rectangle3, Color.White, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
                        }
                    }
                }
                //Boss Healthbar
                for (int i = 0; i < Main.maxProjectiles; i++)
                {
                    var proj = Main.projectile[i];

                    if (proj != null && proj.active && proj.type == ModContent.ProjectileType<Terror>())
                    {
                        Texture2D mapicon = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/Pixel").Value;
                        Rectangle rectangle3 = new(0, mapicon.Height / Main.projFrames[Projectile.type] * Projectile.frame, mapicon.Width, 20);
                        Vector2 position3 = Projectile.Center - Main.screenPosition;
                        position3.X = position3.X + DrawOffsetX + 142;
                        position3.Y = position3.Y + DrawOriginOffsetY + 525;
                        for (int cont = 0; cont < 600; cont++)
                        {
                            Main.EntitySpriteDraw(mapicon, new Vector2(position3.X + mapicon.Width * cont, position3.Y), rectangle3, Color.DarkGray, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
                        }
                        for (int cont = 0; cont < 10*proj.ai[0]; cont++)
                        {
                            Main.EntitySpriteDraw(mapicon, new Vector2(position3.X + mapicon.Width * cont, position3.Y), rectangle3, Color.White, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
                        }
                    }
                }
                //Map
                {
                    Texture2D mapicon = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Pong/PongBall").Value;
                    Rectangle rectangle3 = new(0, mapicon.Height / Main.projFrames[Projectile.type] * Projectile.frame, mapicon.Width, mapicon.Height / Main.projFrames[Projectile.type]);
                    Vector2 position3 = Projectile.Center - Main.screenPosition;
                    position3.X = position3.X + DrawOffsetX + 380;
                    position3.Y = position3.Y + DrawOriginOffsetY - 150;
                    for (int cont = 0; cont < 10; cont++)
                    {
                        Color cooo;
                        if (cont == Projectile.localAI[0])
                        {
                            cooo = Color.Lime;
                        }
                        else if (rooms[cont] == 1)
                        {
                            cooo = Color.White;
                        }
                        else
                        {
                            cooo = Color.DarkCyan;
                        }
                        Main.EntitySpriteDraw(mapicon, new Vector2(position3.X + mapicon.Width * cont, position3.Y), rectangle3, cooo, Projectile.rotation, Projectile.Size / 4f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
                    }
                }
                //Draw projectiles over the UI
                for (int i = 0; i < Main.maxProjectiles; i++)
                {
                    var proj = Main.projectile[i];

                    if (proj != null && proj.active)
                    {
                        if (proj.type == ModContent.ProjectileType<Brimhita>())
                        {
                            BasicProjectileDraw(ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/AnahitaShadow").Value, proj, Color.White, false);
                            BasicProjectileDraw(ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/Brimhita").Value, proj, Color.White, false);
                        }
                        if (proj.type == ModContent.ProjectileType<RoomTransition>() && rooms[(int)Projectile.localAI[0]] == 1)
                            BasicProjectileDraw(ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/RoomTransition").Value, proj, Color.White);

                        if (proj.type == ModContent.ProjectileType<Spider>())
                            BasicProjectileDraw(ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/Spider").Value, proj, Color.White);
                        if (proj.type == ModContent.ProjectileType<Mire>())
                            BasicProjectileDraw(ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/Mire").Value, proj, Color.White);
                        if (proj.type == ModContent.ProjectileType<Terror>())
                            BasicProjectileDraw(ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/Terror").Value, proj, Color.White);


                        if (proj.type == ModContent.ProjectileType<Atlantis>())
                        {
                            BasicProjectileDraw(ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/AtlantisShadow").Value, proj, Color.White, false);
                            BasicProjectileDraw(ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/Atlantis").Value, proj, Color.White, false);
                        }
                        if (proj.type == ModContent.ProjectileType<AnahitaTear>())
                            BasicProjectileDraw(ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Pong/PongBall").Value, proj, Color.White);
                        if (proj.type == ModContent.ProjectileType<ElderBerry>() && proj.alpha <= 0)
                            BasicProjectileDraw(ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/ElderBerry").Value, proj, Color.White);
                        if (proj.type == ModContent.ProjectileType<AcidRound>())
                            BasicProjectileDraw(ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Pong/PongBall").Value, proj, Color.Pink);
                        if (proj.type == ModContent.ProjectileType<BoiRock>())
                            BasicProjectileDraw(ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/Block").Value, proj, Color.White, true, 0.8f);
                    }
                }
            }
        }

        void BasicProjectileDraw(Texture2D texture, Projectile proj, Color color, bool fip = true, float size = 1f)
        {
            Rectangle rectangle23 = new(0, texture.Height / Main.projFrames[proj.type] * proj.frame, texture.Width, texture.Height / Main.projFrames[proj.type]);
            SpriteEffects fx = fip ? (proj.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally) : SpriteEffects.None;
            Vector2 pos = proj.Center - Main.screenPosition;
            if (proj.type == ModContent.ProjectileType<Brimhita>())
            {
                pos.X -= 15;
                pos.Y -= 60;
            }
            if (proj.type == ModContent.ProjectileType<Spider>())
            {
                pos.X -= 15;
                pos.Y -= 10;
            }
            if (proj.type == ModContent.ProjectileType<Mire>())
            {
                pos.X -= 15;
                pos.Y -= 15;
            }
            if (proj.type == ModContent.ProjectileType<Terror>())
            {
                pos.X -= 20;
                pos.Y -= 15;
            }
            Main.EntitySpriteDraw(texture, pos, rectangle23, color, proj.rotation, proj.Size / 2f, size, fx, 0);
        }
    }
}