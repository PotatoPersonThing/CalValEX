using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Boi
{
    public class Terror : ModProjectile
    {
        //public int health = 60;
        public int ow = 0;
        public bool anaex = false;
        public int frozen = 30;
        public int aitimer = 0;
        public int crosstimer = 0;
        public int aiphase = 0;
        public int phasetimer = 0;
        public override string Texture => "CalValEX/ExtraTextures/Boi/Terror";

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Terror");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            Projectile.width = 98;
            Projectile.height = 78;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 18000;
            Projectile.alpha = 0;
        }

        public override void AI()
        {
            //if (Projectile.alpha <= 0)
            {
                frozen--;
            }
            aitimer++;
            phasetimer++;
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (Projectile.position.X <= player.Center.X - 382 && Projectile.velocity.X < 0)
            {
                Projectile.velocity.X = 0;
            }
            else if (Projectile.position.X >= player.Center.X + 332 && Projectile.velocity.X > 0)
            {
                Projectile.velocity.X = 0;
            }
            if (Projectile.position.Y <= player.Center.Y - 238 && Projectile.velocity.Y < 0)
            {
                Projectile.velocity.Y = 0;
            }
            else if (Projectile.position.Y >= player.Center.Y + 173 && Projectile.velocity.X < 0)
            {
                Projectile.velocity.Y = 0;
            }

            if (!CalValEX.DetectProjectile(ModContent.ProjectileType<BoiUI>()))
            {
                Projectile.active = false;
            }

            var thisRect = Projectile.getRect();

            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                var proj = Main.projectile[i];

                if (proj != null && proj.active && proj.getRect().Intersects(thisRect) && proj.type == ModContent.ProjectileType<AnahitaTear>() && Projectile.alpha <= 0)
                {
                    Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.NPCHit50, Projectile.Center);
                    Projectile.ai[0]--;
                    proj.active = false;
                    ow = 10;
                }
                if (proj != null && proj.active && proj.getRect().Intersects(thisRect) && proj.type == ModContent.ProjectileType<Atlantis>() && Projectile.alpha <= 0 && ow <= 0)
                {
                    Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.NPCHit50, Projectile.Center);
                    Projectile.ai[0]--;
                    ow = 10;
                }
            }
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                var proj = Main.projectile[i];
                if (proj.type == ModContent.ProjectileType<Anahita>())
                {
                    if (proj.ai[0] < 2)
                    {
                        Projectile.velocity = new Vector2(0, 0);
                    }
                }
            }
            //This area is where main AI is done
            if (aiphase == 0)
            {
                if (aitimer >= 90)
                {
                    for (int i = 0; i < Main.maxProjectiles; i++)
                    {
                        var proj = Main.projectile[i];
                        if (proj.type == ModContent.ProjectileType<Anahita>() && Projectile.alpha <= 0 && frozen <= 0)
                        {
                            Vector2 targetPosition = proj.Center;
                            Vector2 direction = targetPosition - Projectile.Center;
                            direction.Normalize();
                            float speed = 12f;
                            Projectile.velocity = direction * speed;
                            anaex = true;
                        }
                    }
                    aitimer = 0;
                }
                Projectile.velocity *= 0.95f;
                if (phasetimer > 359)
                {
                    aiphase = 1;
                    aitimer = 0;
                    crosstimer = 0;
                    phasetimer = 0;
                }
            }
            if (aiphase == 1)
            {
                crosstimer++;
                Projectile.velocity = new Vector2(0, 0);
                if (aitimer >= 15)
                {
                    for (int i = 0; i < Main.maxProjectiles; i++)
                    {
                        var proj = Main.projectile[i];
                        if (proj.type == ModContent.ProjectileType<Anahita>() && Projectile.alpha <= 0 && frozen <= 0)
                        {
                            Vector2 targetPosition = proj.Center;
                            Vector2 direction = targetPosition - Projectile.Center;
                            direction.Normalize();
                            float speed = 4f;
                            Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.Item61, Projectile.Center);
                            int type = ModContent.ProjectileType<AcidRound>();
                            int damage = 0;
                            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, direction * speed, type, damage, 0f, Main.myPlayer);
                            if (Projectile.ai[0] <= 15)
                            {
                                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, direction * -speed, type, damage, 0f, Main.myPlayer);
                            }
                            anaex = true;
                        }
                    }
                    aitimer = 0;
                }
                if (crosstimer >= 60)
                {
                    int type = ModContent.ProjectileType<AcidRound>();
                    int damage = 0;
                    Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.NPCDeath13, Projectile.Center);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(-4, 4), type, damage, 0f, Main.myPlayer);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(4, 4), type, damage, 0f, Main.myPlayer);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(-4, -4), type, damage, 0f, Main.myPlayer);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(4, -4), type, damage, 0f, Main.myPlayer);
                    crosstimer = 0;
                }
                if (phasetimer >= 179)
                {
                    aiphase = 0;
                    aitimer = 0;
                    crosstimer = 0;
                    phasetimer = 0;
                }
            }
            //Endregion
            if (Projectile.ai[0] <= 0)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), new Vector2(Projectile.Center.X, Projectile.Center.Y), new Vector2(0, 0), ModContent.ProjectileType<ElderBerry>(), 0, 0f, Main.myPlayer);
                Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.NPCDeath13, Projectile.Center);
                Projectile.active = false;
            }
            ow--;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            return false;
        }

        public override void PostDraw(Color lightColor)
        {
            /*Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            Texture2D texture2 = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/Brimhita").Value;
            Rectangle rectangle2 = new Rectangle(0, texture2.Height / Main.projFrames[Projectile.type] * Projectile.frame, texture2.Width, texture2.Height / Main.projFrames[Projectile.type]);
            Vector2 position2 = Projectile.Center - Main.screenPosition;
            position2.X -= 15;
            position2.Y -= 60;
            Color clo = Color.White;
            if (ow > 0)
            {
                clo = Color.Orange;
            }
            Main.EntitySpriteDraw(texture2, position2, rectangle2, clo, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
        */
        }
    }
}