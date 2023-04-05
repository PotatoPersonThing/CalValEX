using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;

namespace CalValEX.Projectiles.Boi
{
    public class AcidRound : ModProjectile
    {
        public override string Texture => "CalValEX/ExtraTextures/Pong/PongBall";

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Terror Bullet");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            Projectile.width = 23;
            Projectile.height = 23;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 120;
            Projectile.alpha = 255;
            Projectile.penetrate = -1;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (Projectile.position.X < player.Center.X - 382)
            {
                Projectile.active = false;
            }
            else if (Projectile.position.X > player.Center.X + 372)
            {
                //SoundEngine.PlaySound(SoundID.Item14);
                Projectile.active = false;
            }
            if (Projectile.position.Y < player.Center.Y - 238 && Projectile.velocity.Y <= 0)
            {
                Projectile.active = false;
            }
            else if (Projectile.position.Y > player.Center.Y + 193)
            {
                //SoundEngine.PlaySound(SoundID.Item14);
                Projectile.active = false;
            }

            if (!CalValEX.DetectProjectile(ModContent.ProjectileType<BoiUI>()))
            {
                Projectile.active = false;
            }
        }

        public override void PostDraw(Color lightColor)
        {
        }
    }
}