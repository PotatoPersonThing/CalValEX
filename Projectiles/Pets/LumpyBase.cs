using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CalValEX.Projectiles.Pets
{
    public class LumpyBase : FlyingPet
    {
        public bool checkpos = false;
        int i = 0;
        public override string Texture => "CalValEX/Projectiles/Plushies/ItsReal";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lumpy");
            Main.projFrames[projectile.type] = 1; //frames
            Main.projPet[projectile.type] = true;
        }

        public override void SafeSetDefaults() //SafeSetDefaults!!!
        {
            projectile.width = 78;
            projectile.height = 68;
            projectile.ignoreWater = true;
            facingLeft = true; //is the sprite facing left? if so, put this to true. if its facing to right keep it false.
            spinRotation = false; //should it spin? if that's the case, set to true. else, leave it false.
            shouldFlip = true; //should the sprite flip? set true if it should, false if it shouldnt
            usesAura = false; //does this pet use an aura?
            usesGlowmask = false; //does this pet use a glowmask?
            auraUsesGlowmask = false; //does the aura use a glowmask?
        }
        public override void SetUpAuraAndGlowmask()
        {
            glowmaskTexture = "";
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = 1440f; //teleport distance
            distance[1] = 560f; //faster speed distance
            speed = 12f;
            inertia = 60f;
            animationSpeed = 12; //how fast the animation should play
            spinRotationSpeedMult = 0.2f; //rotation speed multiplier, keep it positive for it to spin in the right direction
            offSetX = 68f * -Main.player[projectile.owner].direction; //this is needed so it's always behind the player.
            offSetY = -50f; //how much higher from the center the pet should float
        }

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.lumpe = false;
            if (modPlayer.lumpe)
                projectile.timeLeft = 2;

            if (checkpos)
            {
                projectile.alpha = 255;
            }
            else
            {
                projectile.alpha = 0;
            }

        }

        public override void SafePostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            var thisRect = projectile.getRect();

            //if (!checkpos)
            //{
            var projmim = Main.projectile[i];
            for (i = 0; i < Main.maxProjectiles; i++)
                {
                    var proj = Main.projectile[i];
                    if (proj != null && proj.active && proj.getRect().Intersects(thisRect) && (proj.minion || proj.sentry) && !checkpos)
                    {
                        checkpos = true;
                        projmim = proj;
                    }
                    if (checkpos)
                    {
                        Texture2D projTexture = Main.projectileTexture[projmim.type];

                        int frameHeight = projTexture.Height / Main.projFrames[projmim.type];
                        int frameWidth = projTexture.Width / 1;
                        int hei = frameHeight * projmim.frame;
                        int wid = frameWidth * projmim.frame;
                        SpriteEffects rainbowy = SpriteEffects.None;
                        if (projectile.spriteDirection == -1)
                        {
                            rainbowy = SpriteEffects.FlipHorizontally;
                        }
                        spriteBatch.Draw(projTexture, projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(wid, hei, frameWidth, frameHeight)), Color.White, projectile.rotation, new Vector2(frameWidth / 2f, frameHeight / 2f), projmim.scale, rainbowy, 0f);
                    }
                }
            //}
            
        }
    }
}