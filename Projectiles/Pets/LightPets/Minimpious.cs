using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;
using Terraria.ID;
namespace CalValEX.Projectiles.Pets.LightPets
{
    public class Minimpious : ModProjectile
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Minimpious");
            Main.projFrames[Projectile.type] = 5;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.LightPet[Projectile.type] = true;
        }

        public override void SetDefaults() {
            Projectile.width = 64;
            Projectile.height = 48;
            Projectile.penetrate = -1;
            Projectile.netImportant = true;
            Projectile.timeLeft *= 5;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.aiStyle = -1;
            DrawOriginOffsetY = -11;
            DrawOffsetX = -21;
        }

        public override void AI() {
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
                modPlayer.mImp = false;
            if (modPlayer.mImp)
                Projectile.timeLeft = 2;

            Vector2 vectorToOwner = player.Center - Projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            if (distanceToOwner > 2400f) {
                Projectile.position = player.Center;
                Projectile.velocity *= 0.1f;
                Projectile.netUpdate = true;
            }

            if (Projectile.velocity.X > 0f)
                Projectile.spriteDirection = -1;
            else if (Projectile.velocity.X < 0f)
                Projectile.spriteDirection = 1;

            Projectile.rotation = Projectile.rotation.AngleLerp(Projectile.velocity.X * 0.1f, 0.1f);
            Projectile.frameCounter++;
            if (Projectile.frameCounter > 8) {
                Projectile.frame++;
                Projectile.frameCounter = 0;
                if (Projectile.frame > 4)
                    Projectile.frame = 0;
            }

            Lighting.AddLight(Projectile.position, new Vector3(1.61568627f, 0.901960784f, 0.462745098f));

            if (Main.rand.Next(5) == 0) {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 55, 0, 0, 125);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0.3f;
                Main.dust[dust].shader = GameShaders.Armor.GetSecondaryShader(player.cLight, player);
            }

            Vector2 extraPos = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
            float posX = player.position.X + (player.width / 2) - extraPos.X;
            float posY = player.position.Y + (player.width / 2) - extraPos.Y;
            float num0 = 80;

            Projectile.velocity.X = MathHelper.Lerp(Projectile.velocity.X, (posX - Projectile.velocity.X) * 0.1f, 0.1f);
            Projectile.velocity.Y = MathHelper.Lerp(Projectile.velocity.Y, (posY - Projectile.velocity.Y) * 0.1f, 0.1f);
        }
        public override void PostDraw(Color lightColor) {
            Texture2D glowMask = Mod.Assets.Request<Texture2D>("Projectiles/Pets/LightPets/Minimpious_Glow").Value;
            Rectangle frame = glowMask.Frame(1, Main.projFrames[Projectile.type], 0, Projectile.frame);
            frame.Height -= 1;
            float originOffsetX = (glowMask.Width - Projectile.width) * 0.5f + Projectile.width * 0.5f + DrawOriginOffsetX;
            Main.EntitySpriteDraw
            (
                glowMask,
                Projectile.position - Main.screenPosition + new Vector2(originOffsetX + DrawOffsetX, Projectile.height / 2 + Projectile.gfxOffY),
                frame,
                Color.White,
                Projectile.rotation,
                new Vector2(originOffsetX, Projectile.height / 2 - DrawOriginOffsetY),
                Projectile.scale,
                Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                0
            );
        }
    }
}