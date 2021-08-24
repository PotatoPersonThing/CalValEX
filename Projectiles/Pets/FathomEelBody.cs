using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

// If you don't know what to change this to, don't mess with this code.
// You will fail
namespace CalValEX.Projectiles.Pets
{
    public class FathomEelBody : ModProjectile
    {
        private static readonly int Size = 26;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fathom Eel");
            ProjectileID.Sets.NeedsUUID[projectile.type] = true;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = Size;
            projectile.height = 26;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.netImportant = true;
            //projectile.timeLeft = 300;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            // Consistently update the worm
            if ((int)Main.time % 120 == 0)
            {
                projectile.netUpdate = true;
            }
            if (projectile.ai[1] == 1f)
            {
                projectile.ai[1] = 0f;
                projectile.netUpdate = true;
            }
            float segmentAheadRotation;

            // This, and Size will likely need to be changed based on the sprite size of the segment
            float travelFactor = 16f;

            Vector2 segmentAheadCenter;
            int segmentAhead = (int)projectile.ai[0];
            // Verify the projectile we specified as the segment ahead is a part of this worm, and exists
            if (segmentAhead >= 0 && Main.projectile[segmentAhead].active &&
                (Main.projectile[segmentAhead].type == ModContent.ProjectileType<FathomEelBody>()) ||
                 Main.projectile[segmentAhead].type == ModContent.ProjectileType<FathomEelHead>())
            {
                segmentAheadCenter = Main.projectile[segmentAhead].Center;
                segmentAheadRotation = Main.projectile[segmentAhead].rotation;
                Main.projectile[segmentAhead].localAI[0] = projectile.localAI[0] + 1f;
            }
            // Otherwise, kill the segment and ignore the rest of the code
            else
            {
                projectile.Kill();
                return;
            }
            projectile.velocity = Vector2.Zero;
            Vector2 vectorToAhead = segmentAheadCenter - projectile.Center;
            if (segmentAheadRotation != projectile.rotation)
            {
                // Fix the angle between -pi and pi (wraps back over if one of the bounds are reached)
                float deltaAngle = MathHelper.WrapAngle(segmentAheadRotation - projectile.rotation);
                vectorToAhead = vectorToAhead.RotatedBy(deltaAngle * 0.1f);
            }
            projectile.rotation = vectorToAhead.ToRotation() + MathHelper.PiOver2;
            projectile.position = projectile.Center;

            // If scale is not 1, adjust the width and height based on that too
            projectile.width = Size;
            projectile.height = 26;
            projectile.Center = projectile.position;

            // Adjust the position of this segment relative to the one ahead
            if (vectorToAhead != Vector2.Zero)
            {
                projectile.Center = segmentAheadCenter - Vector2.Normalize(vectorToAhead) * travelFactor;
            }
            projectile.spriteDirection = (vectorToAhead.X > 0f).ToDirectionInt();

            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.feel)
            {
                projectile.timeLeft = 2;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.knockBack == 2f && !projectile.ranged && !projectile.magic)
            {
                Texture2D texture = ModContent.GetTexture("CalValEX/Projectiles/Pets/FathomEelBody");
                int frameHeight = texture.Height / Main.projFrames[projectile.type];
                int hei = frameHeight * projectile.frame;
                spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * projectile.frame, texture.Width, frameHeight)), lightColor, projectile.rotation, projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
                return false;
            }
            else if (projectile.knockBack == 3f && !projectile.ranged && !projectile.magic)
            {
                Texture2D texture = ModContent.GetTexture("CalValEX/Projectiles/Pets/FathomEelBody2");
                int frameHeight = texture.Height / Main.projFrames[projectile.type];
                int hei = frameHeight * projectile.frame;
                spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * projectile.frame, texture.Width, frameHeight)), lightColor, projectile.rotation, projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
                return false;
            }
            else if (projectile.ranged)
            {
                Texture2D texture = ModContent.GetTexture("CalValEX/Projectiles/Pets/FathomEelBody3");
                int frameHeight = texture.Height / Main.projFrames[projectile.type];
                int hei = frameHeight * projectile.frame;
                spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * projectile.frame, texture.Width, frameHeight)), lightColor, projectile.rotation, projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
                return false;
            }
            else if (projectile.magic)
            {
                Texture2D texture = ModContent.GetTexture("CalValEX/Projectiles/Pets/FathomEelBody4");
                int frameHeight = texture.Height / Main.projFrames[projectile.type];
                int hei = frameHeight * projectile.frame;
                spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * projectile.frame, texture.Width, frameHeight)), lightColor, projectile.rotation, projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
                return false;
            }
            else
            {
                Texture2D texture = ModContent.GetTexture("CalValEX/Projectiles/Pets/FathomEelBody4");
                int frameHeight = texture.Height / Main.projFrames[projectile.type];
                int hei = frameHeight * projectile.frame;
                spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * projectile.frame, texture.Width, frameHeight)), lightColor, projectile.rotation, projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
                return false;
            }
        }
    }
}
