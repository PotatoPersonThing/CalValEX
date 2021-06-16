using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

// If you don't know what to change this to, don't mess with this code.
// You will fail
namespace CalValEX.Projectiles.Pets
{
    public class DeusSmallTail : ModProjectile
    {
        private static readonly int Size = 24;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astrum Demus");
            ProjectileID.Sets.NeedsUUID[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = Size;
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
            float travelFactor = 12f;

            Vector2 segmentAheadCenter;
            int byUUID = Projectile.GetByUUID(projectile.owner, (int)projectile.ai[0]);
            // Verify the projectile we specified as the segment ahead is a part of this worm, and exists
            if (byUUID >= 0 && Main.projectile[byUUID].active &&
                (Main.projectile[byUUID].type == ModContent.ProjectileType<DeusSmallBody>()) ||
                 Main.projectile[byUUID].type == ModContent.ProjectileType<DeusSmallHead>())
            {
                segmentAheadCenter = Main.projectile[byUUID].Center;
                segmentAheadRotation = Main.projectile[byUUID].rotation;

                // Define the localAI[0] (i.e segment behind) of the segment ahead as this segment
                Main.projectile[byUUID].localAI[0] = projectile.localAI[0] + 1f;

                // If this is a tail, and the UUID projectile is a head, kill the tail and head
                if (Main.projectile[byUUID].type == ModContent.ProjectileType<DeusSmallHead>() &&
                    projectile.type == ModContent.ProjectileType<DeusSmallTail>())
                {
                    Main.projectile[byUUID].Kill();
                    projectile.Kill();
                    return;
                }
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
            projectile.width = 22;
            projectile.height = Size;
            projectile.Center = projectile.position;

            // Adjust the position of this segment relative to the one ahead
            if (vectorToAhead != Vector2.Zero)
            {
                projectile.Center = segmentAheadCenter - Vector2.Normalize(vectorToAhead) * travelFactor;
            }
            projectile.spriteDirection = (vectorToAhead.X > 0f).ToDirectionInt();

            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.deussmall)
            {
                projectile.timeLeft = 2;
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = ModContent.GetTexture("CalValEX/Projectiles/Pets/DeusTail_Glow");
            int frameHeight = texture.Height / Main.projFrames[projectile.type];
            int hei = frameHeight * projectile.frame;
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * projectile.frame, texture.Width, frameHeight)), Color.White, projectile.rotation, projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
        }
    }
}