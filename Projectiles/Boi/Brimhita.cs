using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Boi
{
    public class Brimhita : ModProjectile
    {
        public int health = 6;
        public int ow = 0;
        public bool anaex = false;
        public int frozen = 30;
        public override string Texture => "CalValEX/ExtraTextures/Boi/Brimhita";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brimnahita");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            Projectile.width = 60;
            Projectile.height = 50;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 18000;
            Projectile.alpha = 1;
        }

        public override void AI()
        {
            if (Projectile.alpha <= 0)
            {
                frozen--;
            }
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (!modPlayer.boiactive)
            {
                Projectile.active = false;
            }

            var thisRect = Projectile.getRect();

            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                var proj = Main.projectile[i];

                if (proj != null && proj.active && proj.getRect().Intersects(thisRect) && proj.type == ModContent.ProjectileType<AnahitaTear>() && Projectile.alpha <= 0)
                {
                    Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.NPCHit1, Projectile.Center);
                    health--;
                    proj.active = false;
                    ow = 10;
                }
                if (proj != null && proj.active && proj.getRect().Intersects(thisRect) && proj.type == ModContent.ProjectileType<Atlantis>() && Projectile.alpha <= 0 && ow <= 0)
                {
                    Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.NPCHit1, Projectile.Center);
                    health--;
                    ow = 10;
                }
            }
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                var proj = Main.projectile[i];
                if (proj.type == ModContent.ProjectileType<Anahita>() && Projectile.alpha <= 0 && frozen <= 0)
                {
                    Vector2 targetPosition = proj.Center;
                    Vector2 direction = targetPosition - Projectile.Center;
                    direction.Normalize();
                    float speed = 2f;
                    Projectile.velocity = direction * speed;
                    anaex = true;
                }
                if (proj.type == ModContent.ProjectileType<Anahita>())
                {
                    if (proj.ai[0] < 2)
                    {
                        Projectile.velocity = new Vector2(0, 0);
                    }
                }
            }
            if (health <= 0)
            {
                switch (Projectile.ai[1])
                {
                    case 0: 
                        modPlayer.boienemy1 = true;
                        break;
                    case 1:
                        modPlayer.boienemy2 = true;
                        break;
                    case 2:
                        modPlayer.boienemy3 = true;
                        break;
                }
                Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.NPCDeath1, Projectile.Center);
                Projectile.active = false;
            }
            ow--;
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                var proj = Main.projectile[i];
                if (proj.type == ModContent.ProjectileType<BoiUI>())
                {
                    switch (proj.localAI[0])
                    {
                        case 0:
                            if (Projectile.ai[1] == 0 || Projectile.ai[1] == 1)
                            {
                                Projectile.alpha = 0;
                            }
                            else
                            {
                                freze(0);
                            }
                            break;
                        case 1:
                            if (Projectile.ai[1] == 2)
                            {
                                Projectile.alpha = 0;
                            }
                            else
                            {
                                freze(1);
                            }
                            break;
                        case 2:
                            if (Projectile.ai[1] == 3)
                            {
                                Projectile.alpha = 0;
                            }
                            else
                            {
                                freze(2);
                            }
                            break;
                        case 3:
                            if (Projectile.ai[1] == 2)
                            {
                                Projectile.alpha = 0;
                            }
                            else
                            {
                                freze(3);
                            }
                            break;
                        default:
                            if (Projectile.ai[1] == 2)
                            {
                                Projectile.alpha = 0;
                            }
                            else
                            {
                                freze(4);
                            }
                            break;
                    }
                }
            }
        }

        void freze(int ai)
        {
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            Projectile.alpha = 255;
            Projectile.velocity = new Vector2(0, 0);
            frozen = 30;
            if (ai != 0)
            {
                if (Projectile.ai[1] == 0)
                {
                    Projectile.position = new Vector2(player.position.X + player.width / 2 - 280, player.position.Y + player.height / 2 - 40);
                }
                if (Projectile.ai[1] == 1)
                {
                    Projectile.position = new Vector2(player.position.X + player.width / 2 + 240, player.position.Y + player.height / 2 - 40);
                }
            }
            if (ai != 1)
            {
                if (Projectile.ai[1] == 2)
                {
                    Projectile.position = new Vector2(player.position.X + player.width / 2, player.position.Y + player.height / 2 - 80);
                }
            }
            if (ai != 2)
            {
                if (Projectile.ai[1] == 3)
                {
                    Projectile.position = new Vector2(player.position.X + player.width / 2, player.position.Y + player.height / 2 - 80);
                }
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            return false;
        }

        public override void PostDraw(Color lightColor)
        {
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.boiactive && Projectile.alpha <= 0)
            {
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
                else if (Projectile.alpha > 0)
                {
                    clo = Color.DarkBlue;
                }
                Main.EntitySpriteDraw(texture2, position2, rectangle2, clo, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
            }
        }
    }
}