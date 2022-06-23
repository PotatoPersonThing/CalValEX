using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CalValEX.Projectiles.Pets.Scuttlers
{
    public class BejeweledScuttler : ModWalkingPet
    {
        public override float TeleportThreshold => 2400f;

        public override float BackToWalkingThreshold => 140f;

        public override float BackToFlyingThreshold => 448f;

        public override float WalkingThreshold => 75f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Bejeweled Scuttler");
            Main.projFrames[Projectile.type] = 10;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 62;
            Projectile.height = 28;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }

        public override void ModifyJumpHeight(ref float oneTileHigherAndNotTwoTilesHigher, ref float twoTilesHigher, ref float fourTilesHigher, ref float fiveTilesHigher, ref float anyOtherJump)
        {
            oneTileHigherAndNotTwoTilesHigher = -4f;
            twoTilesHigher = -6f;
            fiveTilesHigher = -8f;
            fourTilesHigher = -7f;
            anyOtherJump = -6.5f;
        }

        public override void Animation(int state)
        {
            switch(state)
            {
                case States.Walking:

                    if (Projectile.velocity.X != 0f)
                    {
                        if (Projectile.velocity.Y == 0f)
                        {
                            if (++Projectile.frameCounter > 8)
                            {
                                Projectile.frameCounter = 0;
                                Projectile.frame++;
                                if (Projectile.frame < 1 || Projectile.frame > 3)
                                {
                                    Projectile.frame = 1;
                                }
                            }
                        }
                        else
                        {
                            Projectile.frameCounter = 0;

                            if (Projectile.velocity.Y < -0.5f)
                                Projectile.frame = 1;
                            else if (Projectile.velocity.Y > 0.5f)
                                Projectile.frame = 3;
                            else
                                Projectile.frame = 2;
                        }
                    }
                    else
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame = 0;
                    }

                    break;

                case States.Flying:

                    if (++Projectile.frameCounter > 10)
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame++;
                        if (Projectile.frame < 4 || Projectile.frame > 9)
                        {
                            Projectile.frame = 4;
                        }
                    }

                    break;
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.rainbow = false;
            if (modPlayer.rainbow)
                Projectile.timeLeft = 2;
        }

        public override void PostDraw(Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/Scuttlers/BejeweledScuttlerGlow").Value;
            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int hei = frameHeight * Projectile.frame;
            SpriteEffects rainbowy = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
            {
                rainbowy = SpriteEffects.FlipHorizontally;
            }
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, hei, texture.Width, frameHeight)), new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, 109), Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, rainbowy, 0);
        }
    }
}