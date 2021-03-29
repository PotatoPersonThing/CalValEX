using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class Enredpet : ModProjectile
    {
        public override string Texture => "CalValEX/Projectiles/Pets/LightPets/CosmicAssistantRing";
        private readonly string CosmicTexture = "CalValEX/Projectiles/Pets/LightPets/CosmicAssistant";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cosmic Assistant");
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = 72;
            projectile.height = 72;
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.aiStyle = -1;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Player player = Main.player[projectile.owner];
            Texture2D texture = ModContent.GetTexture(CosmicTexture);
            Rectangle sourceRectangle = new Rectangle(0, 40 * frame, texture.Width, texture.Height / 6);
            Vector2 origin = new Vector2(texture.Width, texture.Height);
            Vector2 position = player.Center;
            position.Y += 36f;
            position -= Main.screenPosition;
            spriteBatch.Draw(texture, position, sourceRectangle, lightColor, 0f, origin / 2f, 1f, SpriteEffects.None, 0);
        }

        private int frame = 0;

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
            {
                modPlayer.Enredpet = false;
            }
            if (modPlayer.Enredpet)
            {
                projectile.timeLeft = 2;
            }

            Vector2 vectorToOwner = player.Center;
            vectorToOwner.Y -= 64f;

            float value = 8f;

            float velY = MathHelper.Clamp(player.velocity.Y, -value, value);
            float velX = MathHelper.Clamp(player.velocity.X, -value, value);

            vectorToOwner.X += 0.5f * -velX;
            vectorToOwner.Y += 0.5f * -velY;

            projectile.Center = vectorToOwner;

            projectile.frameCounter++;
            if (projectile.frameCounter > 5)
            {
                frame++;
                projectile.frameCounter = 0;
                if (frame > 5)
                    frame = 0;
            }

            Lighting.AddLight(projectile.Center, new Vector3(1.2f, 0.65882353f, 1.38039216f));
        }
    }
}