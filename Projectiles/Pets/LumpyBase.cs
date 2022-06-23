using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace CalValEX.Projectiles.Pets
{
    public class LumpyBase : ModFlyingPet
    {
        public bool checkpos = false;
        int i = 0;
        public override string Texture => "CalValEX/Projectiles/Plushies/ItsReal";

        public override Vector2 FlyingOffset => new Vector2(68f * -Main.player[Projectile.owner].direction, -50f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Lumpy");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 78;
            Projectile.height = 68;
            Projectile.ignoreWater = true;
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
                Projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            if (checkpos)
            {
                Projectile.alpha = 255;
            }
            else
            {
                Projectile.alpha = 0;
            }
        }

        public override void PostDraw(Color lightColor)
        {
            var thisRect = Projectile.getRect();

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
                        Texture2D projTexture = TextureAssets.Projectile[projmim.type].Value;

                        int frameHeight = projTexture.Height / Main.projFrames[projmim.type];
                        int frameWidth = projTexture.Width / 1;
                        int hei = frameHeight * projmim.frame;
                        int wid = frameWidth * projmim.frame;
                        SpriteEffects rainbowy = SpriteEffects.None;
                        if (Projectile.spriteDirection == -1)
                        {
                            rainbowy = SpriteEffects.FlipHorizontally;
                        }
                        Main.EntitySpriteDraw(projTexture, Projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(wid, hei, frameWidth, frameHeight)), Color.White, Projectile.rotation, new Vector2(frameWidth / 2f, frameHeight / 2f), projmim.scale, rainbowy, 0);
                    }
                }
            //}
            
        }
    }
}