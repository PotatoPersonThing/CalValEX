using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class RepairBot : ModWalkingPet
    {
        public override float TeleportThreshold => 1000f;

        public override bool ShouldFlyRotate => false;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Repair Bot");
            Main.projFrames[Projectile.type] = 17;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 24;
            Projectile.height = 30;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }

        public override void Animation(int state)
        {
            switch(state)
            {
                case States.Walking:
                    if (Projectile.velocity.X != 0f)
                    {
                        if (++Projectile.frameCounter > 3)
                        {
                            Projectile.frameCounter = 0;
                            Projectile.frame++;

                            if (Projectile.frame > 8 || Projectile.frame < 1)
                                Projectile.frame = 1;
                        }
                    }
                    else
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame = 0;
                    }
                    break;

                case States.Flying:
                    if (++Projectile.frameCounter > 5)
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame++;

                        if (Projectile.frame > 16 || Projectile.frame < 9)
                            Projectile.frame = 9;
                    }
                    break;
            }
        }

        public override void CustomBehaviour(Player player, ref int state, float walkingSpeed, float walkingInertia, float flyingSpeed, float flyingInertia)
        {
            if (state == States.Flying)
            {
                Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + MathHelper.PiOver2;
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.RepairBot = false;

            if (modPlayer.RepairBot)
                Projectile.timeLeft = 2;
        }

        public override void PostDraw(Color lightColor)
        {
            Texture2D glowMask = ModContent.Request<Texture2D>("Projectiles/Pets/RepairBot_Glow").Value;
            Rectangle frame = glowMask.Frame(1, Main.projFrames[Projectile.type], 0, Projectile.frame);
            frame.Height -= 1;
            float originOffsetX = (glowMask.Width - Projectile.width) * 0.5f + Projectile.width * 0.5f + DrawOriginOffsetX;
            Main.EntitySpriteDraw
            (
                glowMask,
                Projectile.position - Main.screenPosition + new Vector2(originOffsetX + DrawOffsetX, Projectile.height / 2 + Projectile.gfxOffY),
                frame,
                Color.White,
                Projectile.rotation,
                new Vector2(originOffsetX, Projectile.height / 2 - DrawOriginOffsetY),
                Projectile.scale,
                Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                0
            );
        }
    }
}