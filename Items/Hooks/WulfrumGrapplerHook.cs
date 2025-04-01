using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Steamworks;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Hooks
{
    public class WulfrumGrapplerHook : ModProjectile
    {
        public Vector2 savedPosition = default;

        public override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 2;
            Main.projHook[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.BatHook);
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.aiStyle = -1;
            AIType = -1;
        }

        public override bool? CanUseGrapple(Player player)
        {
            int hooksOut = 0;
            for (int l = 0; l < 1000; l++)
            {
                if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == Projectile.type)
                {
                    hooksOut++;
                }
            }
            if (hooksOut > 0)
            {
                return false;
            }
            return true;
        }

        public override bool PreAI()
        {
            Player p = Main.player[Projectile.owner];
            if (p == null || !p.active || p.CCed)
            {
                Projectile.Kill();
                return false;
            }
            // launch behaviour
            if (Projectile.ai[0] == 0)
            {
                Projectile.ai[1]++;
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
                // if the hook touches a tile, save the player's position and enter swing behaviour
                if (Collision.SolidCollision(Projectile.position, Projectile.width, Projectile.height))
                {
                    Projectile.ai[0] = 1;
                    Projectile.ai[1] = 0;
                    savedPosition = p.position;
                    Projectile.velocity = Vector2.Zero;
                    SoundEngine.PlaySound(SoundID.DD2_BallistaTowerShot with { Pitch = 0.3f }, Projectile.Center);
                }
                // retreat if 1.5 seconds have passed or the hook is further than 15 tiles away
                else if (Projectile.ai[1] > 90 || Projectile.Distance(p.Center) > 240)
                {
                    Projectile.ai[0] = 2;
                    Projectile.ai[1] = 0;
                }
            }
            // swing behaviour
            else if (Projectile.ai[0] == 1)
            {
                // kill the hook if jump is pressed
                if (p.controlJump || p.controlMount)
                { Projectile.Kill(); return false; }

                Projectile.velocity = Vector2.Zero;
                Projectile.ai[1]++;
                float rotTime = 60; // how long the swing lasts
                // the original angle and the distance between the saved player position and the hook
                Vector2 ogRotation = Projectile.DirectionTo(savedPosition);
                float ogDist = Projectile.Distance(savedPosition);
                // if the player is to the left of the hook, swing right, otherwise swing left
                bool goRight = savedPosition.X < Projectile.position.X;
                float rotGoal = goRight ? MathHelper.Pi : -MathHelper.Pi;

                // easing
                float completion = Projectile.ai[1] / rotTime;
                float sine = 1 - MathF.Cos(completion * MathF.PI / 2);

                // calculate the new angle the player should be at
                Vector2 newPos = ogRotation.RotatedBy(MathHelper.Lerp(0, rotGoal, sine));
                // multiply by the distance
                Vector2 finalPos = newPos * ogDist;
                // if the new position is inside tiles, end the animation
                if (Collision.SolidCollision(finalPos + Projectile.position, p.width, p.height) && Projectile.ai[1] > 4)
                {
                    Projectile.Kill(); return false;
                }
                // set the player's velocity to go to the desired position
                p.velocity = Projectile.position + finalPos - p.position;
                // force the player to look in the direction of their movement
                p.ChangeDir(Math.Sign(p.Center.X - savedPosition.X));
                Projectile.rotation = Projectile.DirectionTo(p.Center).ToRotation() - MathHelper.PiOver2;

                if (Projectile.ai[1] > rotTime)
                { Projectile.Kill(); return false; }
            }
            // retreat behaviour
            else if (Projectile.ai[0] == 2)
            {
                Projectile.ai[1]++;
                Projectile.velocity = Projectile.DirectionTo(p.Center) * 8;
                Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
                // kill the hook if it's been too long or the hook is close enough to the player
                if (Projectile.ai[1] > 330 || Projectile.Distance(p.Center) < 60)
                {
                    Projectile.Kill();
                    return false;
                }
            }
            return false;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Player player = Main.player[Projectile.owner];
            Vector2 distToProj = Projectile.Center;
            float projRotation = Projectile.AngleTo(player.MountedCenter) - 1.57f;
            bool doIDraw = true;
            Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Hooks/WulfrumGrapplerChain").Value; //change this accordingly to your chain texture

            while (doIDraw)
            {
                float distance = (player.MountedCenter - distToProj).Length();
                if (distance < (texture.Height + 1))
                {
                    doIDraw = false;
                }
                else if (!float.IsNaN(distance))
                {
                    Color drawColor = Lighting.GetColor((int)distToProj.X / 16, (int)(distToProj.Y / 16f));
                    distToProj += Projectile.DirectionTo(player.MountedCenter) * texture.Height;
                    Main.EntitySpriteDraw(texture, distToProj - Main.screenPosition,
                        new Rectangle(0, 0, texture.Width, texture.Height), drawColor, projRotation,
                        Utils.Size(texture) / 2f, Projectile.scale, SpriteEffects.None, 0);
                }
            }
            Texture2D hook = TextureAssets.Projectile[Type].Value;
            Main.EntitySpriteDraw(hook, Projectile.Center - Main.screenPosition, hook.Frame(1, 2, 0, (int)Projectile.ai[0] == 1 ? 1 : 0), Projectile.GetAlpha(lightColor), Projectile.rotation, new Vector2(hook.Width / 2, hook.Height / 4), Projectile.scale, SpriteEffects.None);
            return false;
        }
    }
}