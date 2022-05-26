using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;

namespace CalValEX.Projectiles.Boi
{
    public class Atlantis : ModProjectile
    {
        private double rotation = 0D;
        bool collec = false;
        public override string Texture => "CalValEX/ExtraTextures/Boi/Atlantis";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Atlantis");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 18000;
            Projectile.alpha = 255;
        }

        public override void AI()
        {
            int bop = 0;
            {
                bop++;
                Player player = Main.player[Projectile.owner];
                CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
                for (int i = 0; i < Main.maxProjectiles; i++)
                {
                    var proj = Main.projectile[i];
                    if (proj != null && proj.type == ModContent.ProjectileType<BoiUI>() && !collec)
                    {
                        if (proj.localAI[0] == 5)
                        {
                            Projectile.alpha = 0;
                            Projectile.width = 50;
                            Projectile.height = 100;
                        }
                        else
                        {
                            Projectile.alpha = 255;
                            Projectile.width = 20;
                            Projectile.height = 20;
                        }
                    }
                }
                for (int i = 0; i < Main.maxProjectiles; i++)
                {
                    var proj = Main.projectile[i];
                    if (proj.type == ModContent.ProjectileType<Anahita>() && proj.penetrate == 2)
                    {
                        Projectile.width = 40;
                        Projectile.height = 40;
                        collec = true;
                        Vector2 vector = proj.Center - Projectile.Center;
                        Projectile.rotation = vector.ToRotation() - MathHelper.PiOver2;

                        Projectile.Center = proj.Center + new Vector2(80, 0).RotatedBy(rotation);
                        rotation += 0.1;

                        Projectile.velocity.X = (vector.X > 0f) ? -0.000001f : 0f;
                        Projectile.ai[0]++;
                    }
                }
                if (Projectile.ai[0] >= 60)
                {
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Item71, Projectile.position);
                    Projectile.ai[0] = 0;
                }
                bool bossIsAlive = false;
                for (int i = 0; i < Main.maxProjectiles; i++)
                {
                    Projectile proj = Main.projectile[i];
                    if (proj != null && proj.active && proj.type == ModContent.ProjectileType<BoiUI>() && proj.alpha <= 0)
                    {
                        bossIsAlive = true;
                    }
                }
                if (!bossIsAlive)
                {
                    Projectile.active = false;
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
                Texture2D texture2 = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/Atlantis").Value;
                Rectangle rectangle2 = new Rectangle(0, texture2.Height / Main.projFrames[Projectile.type] * Projectile.frame, texture2.Width, texture2.Height / Main.projFrames[Projectile.type]);
                Vector2 position2 = Projectile.Center - Main.screenPosition;
                Main.EntitySpriteDraw(texture2, position2, rectangle2, Color.White, Projectile.rotation, Projectile.Size / 2f, 1f, SpriteEffects.None, 0);
            }
        }
    }
}