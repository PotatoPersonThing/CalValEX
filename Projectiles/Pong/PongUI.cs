using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pong
{
    public class PongUI : ModProjectile
    {
        public bool checkpos = false;
        public bool spawnstuff = false;
        public bool setfield = false;

        Vector2 nipah;
        public override string Texture => "CalValEX/ExtraTextures/Pong/PongBG";

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Pong UI");
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

            modPlayer.pongactive = true;

            if (checkpos == false)
            {
                nipah.X = player.Center.X;
                nipah.Y = player.Center.Y;
                checkpos = true;
            }

            Projectile.position.X = player.position.X - 400;
            Projectile.position.Y = player.position.Y - 240;

            var thisRect = Projectile.getRect();

            if (player.controlMount)
            {
                modPlayer.pongstage = 0;
                modPlayer.pongactive = false;
                Projectile.active = false;
            }
            if (modPlayer.pongactive)
            {
                //Stage logic
                if (modPlayer.pongstage == 0)
                {
                    if (player.controlUseItem)
                    {
                        if (!setfield)
                        {
                            int choice = Main.rand.Next(5);
                            {
                                if (choice == 0)
                                    modPlayer.pongstage = 3;
                                else if (choice == 1)
                                    modPlayer.pongstage = 4;
                                else if (choice == 2)
                                    modPlayer.pongstage = 6;
                                else if (choice == 3)
                                    modPlayer.pongstage = 7;
                                else
                                    modPlayer.pongstage = 5;
                            }
                            setfield = true;
                        }
                        if (!spawnstuff)
                        {
                            Projectile.NewProjectile(new Terraria.DataStructures.EntitySource_WorldEvent(), player.position.X + player.width / 2 - 240, player.position.Y + player.height / 2 - 40,
                                0f, 0f, ModContent.ProjectileType<Projectiles.Pong.PlayerSlider>(), 0, 0f, player.whoAmI);
                            Projectile.NewProjectile(new Terraria.DataStructures.EntitySource_WorldEvent(), player.position.X + player.width / 2 + 80, player.position.Y + player.height / 2 - 40,
                                -4f, -4f, ModContent.ProjectileType<Projectiles.Pong.PongBall>(), 0, 0f, player.whoAmI);
                            switch (modPlayer.pongstage)
                            {
                                case 3:
                                    Projectile.NewProjectile(new Terraria.DataStructures.EntitySource_WorldEvent(), player.position.X + player.width / 2 + 260, player.position.Y + player.height / 2 - 40,
                                        0f, -4f, ModContent.ProjectileType<Projectiles.Pong.DSSlider>(), 0, 0f, player.whoAmI);
                                    break;
                                case 4:
                                    Projectile.NewProjectile(new Terraria.DataStructures.EntitySource_WorldEvent(), player.position.X + player.width / 2 + 260, player.position.Y + player.height / 2 - 40,
                                        0f, -4f, ModContent.ProjectileType<Projectiles.Pong.CrabSlider>(), 0, 0f, player.whoAmI);
                                    break;
                                case 5:
                                    Projectile.NewProjectile(new Terraria.DataStructures.EntitySource_WorldEvent(), player.position.X + player.width / 2 + 260, player.position.Y + player.height / 2 - 40,
                                        0f, -4f, ModContent.ProjectileType<Projectiles.Pong.HiveSlider>(), 0, 0f, player.whoAmI);
                                    break;
                                case 6:
                                    Projectile.NewProjectile(new Terraria.DataStructures.EntitySource_WorldEvent(), player.position.X + player.width / 2 + 260, player.position.Y + player.height / 2 - 40,
                                        0f, -4f, ModContent.ProjectileType<Projectiles.Pong.PerfSlider>(), 0, 0f, player.whoAmI);
                                    break;
                                case 7:
                                    Projectile.NewProjectile(new Terraria.DataStructures.EntitySource_WorldEvent(), player.position.X + player.width / 2 + 260, player.position.Y + player.height / 2 - 20,
                                        0f, 4f, ModContent.ProjectileType<Projectiles.Pong.SGSlider>(), 0, 0f, player.whoAmI);
                                    Projectile.NewProjectile(new Terraria.DataStructures.EntitySource_WorldEvent(), player.position.X + player.width / 2 + 260, player.position.Y + player.height / 2 - 80,
                                        0f, -4f, ModContent.ProjectileType<Projectiles.Pong.SGSlider>(), 0, 0f, player.whoAmI);
                                    break;
                                default:
                                    Projectile.NewProjectile(new Terraria.DataStructures.EntitySource_WorldEvent(), player.position.X + player.width / 2 + 260, player.position.Y + player.height / 2 - 40,
                                        0f, -4f, ModContent.ProjectileType<Projectiles.Pong.DSSlider>(), 0, 0f, player.whoAmI);
                                    break;
                            }
                                spawnstuff = true;
                        }
                    }
                }
            }
        }

        public override void PostDraw(Color lightColor)
        {
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.pongactive)
            {
                Texture2D texture2 = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Pong/PongBG").Value;
                Rectangle rectangle2 = new Rectangle(0, texture2.Height / Main.projFrames[Projectile.type] * Projectile.frame, texture2.Width, texture2.Height / Main.projFrames[Projectile.type]);
                Vector2 position2 = Projectile.Center - Main.screenPosition;
                position2.X += DrawOffsetX;
                position2.Y += DrawOriginOffsetY;
                Main.EntitySpriteDraw(texture2, position2, rectangle2, Color.White, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);

                //Screen types

                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Pong/PongInitialPrompt").Value;

                if (modPlayer.pongstage == 0)
                {
                    texture = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Pong/PongInitialPrompt").Value;
                }
                else if (modPlayer.pongstage == 1)
                {
                    texture = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Pong/PongLossPrompt").Value;
                }
                else if (modPlayer.pongstage == 2)
                {
                    texture = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Pong/PongWinPrompt").Value;
                }
                else
                {
                    texture = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Pong/InnerBarriers").Value;
                }
                Vector2 position = Projectile.Center - Main.screenPosition;
                position.X += DrawOffsetX;
                position.Y += DrawOriginOffsetY;
                Main.EntitySpriteDraw(texture, position, rectangle2, Color.White, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);

                //Opponent icon
                Texture2D mapicon = ModContent.Request<Texture2D>("CalValEX/Buffs/Pets/DesertBuff").Value;

                if (modPlayer.pongstage == 3)
                {
                    mapicon = ModContent.Request<Texture2D>("CalValEX/Buffs/Pets/DesertBuff").Value;
                }
                else if (modPlayer.pongstage == 4)
                {
                    mapicon = ModContent.Request<Texture2D>("CalValEX/Buffs/Pets/CrabBuff").Value;
                }
                else if (modPlayer.pongstage == 6)
                {
                    mapicon = ModContent.Request<Texture2D>("CalValEX/Buffs/Pets/FistuloidBuff").Value;
                }
                else if (modPlayer.pongstage == 7)
                {
                    mapicon = ModContent.Request<Texture2D>("CalValEX/Buffs/Pets/SlimeBuff").Value;
                }
                else
                {
                    mapicon = ModContent.Request<Texture2D>("CalValEX/Buffs/Pets/HivelingBuff").Value;
                }
                Rectangle rectangle3 = new Rectangle(0, mapicon.Height / Main.projFrames[Projectile.type] * Projectile.frame, mapicon.Width, mapicon.Height / Main.projFrames[Projectile.type]);
                Vector2 position3 = Projectile.Center - Main.screenPosition;
                position3.X = position3.X + DrawOffsetX + 400;
                position3.Y = position3.Y + DrawOriginOffsetY - 16;
                if (modPlayer.pongstage > 2)
                {
                    Main.EntitySpriteDraw(mapicon, position3, rectangle3, Color.White, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
                }
            }
        }
    }
}