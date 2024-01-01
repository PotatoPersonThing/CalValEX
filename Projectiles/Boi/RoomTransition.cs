using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Boi
{
    public class RoomTransition : ModProjectile
    {
        public override string Texture => "CalValEX/ExtraTextures/Boi/RoomTransition";

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Room Transition");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            Projectile.width = 88;
            Projectile.height = 85;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 18000;
            Projectile.alpha = 255;
        }

        public override void AI()
        {
            if (!CalValEX.DetectProjectile(ModContent.ProjectileType<BoiUI>()))
            {
                Projectile.active = false;
            }
        }

        /*public override void PostDraw(Color lightColor)
        {
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.boiactive)
            {
                Texture2D texture2 = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/Door").Value;
                Rectangle rectangle2 = new Rectangle(0, texture2.Height / Main.projFrames[Projectile.type] * Projectile.frame, texture2.Width, texture2.Height / Main.projFrames[Projectile.type]);
                Vector2 position2 = Projectile.Center - Main.screenPosition;
                position2.X += DrawOffsetX;
                position2.Y += DrawOriginOffsetY;
                Main.EntitySpriteDraw(texture2, position2, rectangle2, Color.White, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
            }
        }*/
    }
}