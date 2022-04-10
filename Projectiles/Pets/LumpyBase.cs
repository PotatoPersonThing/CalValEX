using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CalValEX.Projectiles.Pets
{
    public class LumpyBase : ModFlyingPet
    {
        public bool checkpos = false;
        int i = 0;
        public override string Texture => "CalValEX/Projectiles/Plushies/ItsReal";

        public override Vector2 FlyingOffset => new Vector2(68f * -Main.player[projectile.owner].direction, -50f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Lumpy");
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 78;
            projectile.height = 68;
            projectile.ignoreWater = true;
        }

        public override void Animation(int state)
        {
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.lumpe = false;

            if (modPlayer.lumpe)
                projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            if (checkpos)
            {
                projectile.alpha = 255;
            }
            else
            {
                projectile.alpha = 0;
            }
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
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