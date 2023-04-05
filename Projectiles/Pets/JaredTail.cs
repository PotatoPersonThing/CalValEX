using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

// If you don't know what to change this to, don't mess with this code.
// You will fail
namespace CalValEX.Projectiles.Pets
{
    public class JaredTail : ModProjectile
    {
        private static readonly int Size = 78;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Jared");
            ProjectileID.Sets.NeedsUUID[Projectile.type] = true;
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 66;
            Projectile.height = Size;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.netImportant = true;
            //Projectile.timeLeft = 300;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            // Consistently update the worm
            if ((int)Main.time % 120 == 0)
            {
                Projectile.netUpdate = true;
            }

            if (Projectile.ai[1] == 1f)
            {
                Projectile.ai[1] = 0f;
                Projectile.netUpdate = true;
            }

            float segmentAheadRotation;

            // This, and Size will likely need to be changed based on the sprite size of the segment
            float travelFactor = 56f;

            Vector2 segmentAheadCenter;
            int byUUID = Projectile.GetByUUID(Projectile.owner, (int)Projectile.ai[0]);
            // Verify the projectile we specified as the segment ahead is a part of this worm, and exists
            if (byUUID >= 0 && Main.projectile[byUUID].active &&
                (Main.projectile[byUUID].type == ModContent.ProjectileType<JaredBody>()) ||
                 Main.projectile[byUUID].type == ModContent.ProjectileType<JaredHead>())
            {
                segmentAheadCenter = Main.projectile[byUUID].Center;
                segmentAheadRotation = Main.projectile[byUUID].rotation;

                // Define the localAI[0] (i.e segment behind) of the segment ahead as this segment
                Main.projectile[byUUID].localAI[0] = Projectile.localAI[0] + 1f;

                // If this is a tail, and the UUID projectile is a head, kill the tail and head
                if (Main.projectile[byUUID].type == ModContent.ProjectileType<JaredHead>() &&
                    Projectile.type == ModContent.ProjectileType<JaredTail>())
                {
                    Main.projectile[byUUID].Kill();
                    Projectile.Kill();
                    return;
                }
            }
            // Otherwise, kill the segment and ignore the rest of the code
            else
            {
                Projectile.Kill();
                return;
            }
            Projectile.velocity = Vector2.Zero;
            Vector2 vectorToAhead = segmentAheadCenter - Projectile.Center;
            if (segmentAheadRotation != Projectile.rotation)
            {
                // Fix the angle between -pi and pi (wraps back over if one of the bounds are reached)
                float deltaAngle = MathHelper.WrapAngle(segmentAheadRotation - Projectile.rotation);
                vectorToAhead = vectorToAhead.RotatedBy(deltaAngle * 0.1f);
            }
            Projectile.rotation = vectorToAhead.ToRotation() + MathHelper.PiOver2;
            Projectile.position = Projectile.Center;

            // If scale is not 1, adjust the width and height based on that too
            Projectile.width = 66;
            Projectile.height = Size;
            Projectile.Center = Projectile.position;

            // Adjust the position of this segment relative to the one ahead
            if (vectorToAhead != Vector2.Zero)
            {
                Projectile.Center = segmentAheadCenter - Vector2.Normalize(vectorToAhead) * travelFactor;
            }
            Projectile.spriteDirection = (vectorToAhead.X > 0f).ToDirectionInt();

            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.jared)
            {
                Projectile.timeLeft = 2;
            }
        }
        public override void PostDraw(Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/JaredTail_Glow").Value;
            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int hei = frameHeight * Projectile.frame;
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * Projectile.frame, texture.Width, frameHeight)), Color.White, Projectile.rotation, Projectile.Size / 2f, 1f, SpriteEffects.None, 0);
        }
    }
}