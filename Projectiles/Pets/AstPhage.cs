using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CalValEX.Projectiles.Pets
{
    public class AstPhage : WalkingPet
    {
        public Player Owner => Main.player[projectile.owner];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aureophage");
            Main.projFrames[projectile.type] = 18; //frames
            Main.projPet[projectile.type] = true;
        }

        public override void SafeSetDefaults() //SAFE SET DEFAULTS!!!
        {
            projectile.width = 46;
            projectile.height = 80;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            facingLeft = true; //is the sprite facing left? if so, put this to true. if its facing to right keep it false.
            spinRotation = false; //should it spin? if that's the case, set to true. else, leave it false.
            shouldFlip = true; //should the sprite flip? if that's the case, set to true. else, put it to false.
        }

        public override void SetPetDistances()
        {
            distance[0] = 1000f; //teleport
            distance[1] = 560f; //speed increase
            distance[2] = 200f; //when to walk
            distance[3] = 50f; //when to stop walking
            distance[4] = 380f; //when to fly
            distance[5] = 180f; //when to stop flying
        }

        public override void SetFrameLimitsAndFrameSpeed()
        {
            idleFrameLimits[0] = idleFrameLimits[1] = 0; //what your min idle frame is (start of idle animation)

            walkingFrameLimits[0] = 1; //what your min walking frame is (start of walking animation)
            walkingFrameLimits[1] = 11; //what your max walking frame is (end of walking animation)

            flyingFrameLimits[0] = 12; //what your min flying frame is (start of flying animation)
            flyingFrameLimits[1] = 17; //what your max flying frame is (end of flying animation)

            jumpFrameLimits[0] = -1; //what your min jump frame is (start of jump animation)
            jumpFrameLimits[1] = -1; //what your max jump frame is (end of jump animation)

            animationSpeed[0] = 30; //idle animation speed
            animationSpeed[1] = 3; //walking animation speed
            animationSpeed[2] = 5; //flying animation speed
            animationSpeed[3] = -1; //jumping animation speed

            jumpAnimationLength = -1; //how long the jump animation should stay
        }

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.AstPhage = false;
            if (modPlayer.AstPhage)
                projectile.timeLeft = 2;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowMask = mod.GetTexture("Projectiles/Pets/AstPhage_Glow");
            Rectangle frame = glowMask.Frame(1, Main.projFrames[projectile.type], 0, projectile.frame);
            frame.Height -= 1;
            float originOffsetX = (glowMask.Width - projectile.width) * 0.5f + projectile.width * 0.5f + drawOriginOffsetX;
            spriteBatch.Draw
            (
                glowMask,
                projectile.position - Main.screenPosition + new Vector2(originOffsetX + drawOffsetX, projectile.height / 2 + projectile.gfxOffY),
                frame,
                Color.White,
                projectile.rotation,
                new Vector2(originOffsetX, projectile.height / 2 - drawOriginOffsetY),
                projectile.scale,
                projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                0f
            );
        }
    }
}