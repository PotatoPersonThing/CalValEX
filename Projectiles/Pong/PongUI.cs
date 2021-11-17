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
            DisplayName.SetDefault("Pong UI");
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            projectile.width = 832;
            projectile.height = 512;
            projectile.aiStyle = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 18000;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            modPlayer.pongactive = true;

            if (checkpos == false)
            {
                nipah.X = player.Center.X;
                nipah.Y = player.Center.Y;
                checkpos = true;
            }

            projectile.position.X = player.position.X - 400;
            projectile.position.Y = player.position.Y - 240;

            var thisRect = projectile.getRect();

            if (player.controlMount)
            {
                modPlayer.pongstage = 0;
                modPlayer.pongactive = false;
                projectile.active = false;
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
                            int choice = Main.rand.Next(2);
                            {
                                if (choice == 0)
                                    modPlayer.pongstage = 3;
                                else
                                    modPlayer.pongstage = 4;
                            }
                            setfield = true;
                        }
                        if (!spawnstuff)
                        {
                            Projectile.NewProjectile(player.position.X + player.width / 2 - 240, player.position.Y + player.height / 2 - 40,
                                0f, 0f, ModContent.ProjectileType<Projectiles.Pong.PlayerSlider>(), 0, 0f, player.whoAmI);
                            Projectile.NewProjectile(player.position.X + player.width / 2 + 80, player.position.Y + player.height / 2 - 40,
                                -4f, -4f, ModContent.ProjectileType<Projectiles.Pong.PongBall>(), 0, 0f, player.whoAmI);
                            switch (modPlayer.pongstage)
                            {
                                case 3:
                                    Projectile.NewProjectile(player.position.X + player.width / 2 + 260, player.position.Y + player.height / 2 - 40,
                                        0f, -4f, ModContent.ProjectileType<Projectiles.Pong.DSSlider>(), 0, 0f, player.whoAmI);
                                    break;
                                case 4:
                                    Projectile.NewProjectile(player.position.X + player.width / 2 + 260, player.position.Y + player.height / 2 - 40,
                                        0f, -4f, ModContent.ProjectileType<Projectiles.Pong.CrabSlider>(), 0, 0f, player.whoAmI);
                                    break;
                                default:
                                    Projectile.NewProjectile(player.position.X + player.width / 2 + 260, player.position.Y + player.height / 2 - 40,
                                        0f, -4f, ModContent.ProjectileType<Projectiles.Pong.DSSlider>(), 0, 0f, player.whoAmI);
                                    break;
                            }
                                spawnstuff = true;
                        }
                    }
                }
            }
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.pongactive)
            {
                Texture2D texture2 = ModContent.GetTexture("CalValEX/ExtraTextures/Pong/PongBG");
                Rectangle rectangle2 = new Rectangle(0, texture2.Height / Main.projFrames[projectile.type] * projectile.frame, texture2.Width, texture2.Height / Main.projFrames[projectile.type]);
                Vector2 position2 = projectile.Center - Main.screenPosition;
                position2.X += drawOffsetX;
                position2.Y += drawOriginOffsetY;
                spriteBatch.Draw(texture2, position2, rectangle2, Color.White, projectile.rotation, projectile.Size / 2f, 1f, (projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0f);

                //Screen types

                Texture2D texture = ModContent.GetTexture("CalValEX/ExtraTextures/Pong/PongInitialPrompt");

                if (modPlayer.pongstage == 0)
                {
                    texture = ModContent.GetTexture("CalValEX/ExtraTextures/Pong/PongInitialPrompt");
                }
                else if (modPlayer.pongstage == 1)
                {
                    texture = ModContent.GetTexture("CalValEX/ExtraTextures/Pong/PongLossPrompt");
                }
                else if (modPlayer.pongstage == 2)
                {
                    texture = ModContent.GetTexture("CalValEX/ExtraTextures/Pong/PongWinPrompt");
                }
                else
                {
                    texture = ModContent.GetTexture("CalValEX/ExtraTextures/Pong/InnerBarriers");
                }
                Vector2 position = projectile.Center - Main.screenPosition;
                position.X += drawOffsetX;
                position.Y += drawOriginOffsetY;
                spriteBatch.Draw(texture, position, rectangle2, Color.White, projectile.rotation, projectile.Size / 2f, 1f, (projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0f);

                //Opponent icon
                Texture2D mapicon = ModContent.GetTexture("CalValEX/Buffs/Pets/DesertBuff");

                if (modPlayer.pongstage == 3)
                {
                    mapicon = ModContent.GetTexture("CalValEX/Buffs/Pets/DesertBuff");
                }
                else
                {
                    mapicon = ModContent.GetTexture("CalValEX/Buffs/Pets/CrabBuff");
                }
                Rectangle rectangle3 = new Rectangle(0, mapicon.Height / Main.projFrames[projectile.type] * projectile.frame, mapicon.Width, mapicon.Height / Main.projFrames[projectile.type]);
                Vector2 position3 = projectile.Center - Main.screenPosition;
                position3.X = position3.X + drawOffsetX + 400;
                position3.Y = position3.Y + drawOriginOffsetY - 16;
                if (modPlayer.pongstage > 2)
                {
                    spriteBatch.Draw(mapicon, position3, rectangle3, Color.White, projectile.rotation, projectile.Size / 2f, 1f, (projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0f);
                }
            }
        }
    }
}