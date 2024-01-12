using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

// If you don't know what to change this to, don't mess with this code.
// You will fail
namespace CalValEX.Projectiles.Pets
{
    public class DogBody : ModProjectile
    {
        private static readonly int Size = 88;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Devourer of Gods (real)");
            ProjectileID.Sets.NeedsUUID[Projectile.type] = true;
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 114;
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
            float travelFactor = 58f;
            if (CalValEX.instance.infernum != null)
            {
                if ((bool)CalValEX.instance.infernum.Call("GetInfernumActive"))
                {
                    travelFactor = 88f;
                }    
            }

            Vector2 segmentAheadCenter;
            int segmentAhead = (int)Projectile.ai[0];
            // Verify the projectile we specified as the segment ahead is a part of this worm, and exists
            if (segmentAhead >= 0 && Main.projectile[segmentAhead].active &&
                (Main.projectile[segmentAhead].type == ModContent.ProjectileType<DogBody>()) ||
                 Main.projectile[segmentAhead].type == ModContent.ProjectileType<DogHead>())
            {
                segmentAheadCenter = Main.projectile[segmentAhead].Center;
                segmentAheadRotation = Main.projectile[segmentAhead].rotation;
                Main.projectile[segmentAhead].localAI[0] = Projectile.localAI[0] + 1f;
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
            Projectile.width = 114;
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
            if (modPlayer.voreworm)
            {
                Projectile.timeLeft = 2;
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D main = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/DogBody").Value;
            Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/DogBody_Glow").Value;
            if (CalValEX.instance.infernum != null)
            {
                if ((bool)CalValEX.instance.infernum.Call("GetInfernumActive"))
                {
                    main = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/DogIBody").Value;
                    texture = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/DogIBody_Glow").Value;
                }
            }
            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int hei = frameHeight * Projectile.frame;
            Main.EntitySpriteDraw(main, Projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * Projectile.frame, texture.Width, frameHeight)), Projectile.GetAlpha(lightColor), Projectile.rotation, Projectile.Size / 2f, 1f, SpriteEffects.None, 0);
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * Projectile.frame, texture.Width, frameHeight)), Color.White, Projectile.rotation, Projectile.Size / 2f, 1f, SpriteEffects.None, 0);
            return false;
        }
    }
}