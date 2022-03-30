using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Hooks
{
    public class THanosHook : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("T Hanos Hook");
            base.DrawOriginOffsetY = -10;
            base.DrawOffsetX = -11;
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.StaticHook);
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            player.AddBuff(BuffID.ChaosState, 180);
        }

        public override bool? CanUseGrapple(Player player)
        {
            int hooksOut = 0;
            for (int l = 0; l < 960; l++)
            {
                if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == Projectile.type)
                {
                    hooksOut++;
                }
            }
            if (hooksOut > 0 || player.HasBuff(BuffID.ChaosState))
            {
                return false;
            }
            return true;
        }

        public override float GrappleRange()
        {
            return 1200f;
        }

        public override void NumGrappleHooks(Player player, ref int numHooks)
        {
            numHooks = 1;
        }

        public override void GrappleRetreatSpeed(Player player, ref float speed)
        {
            speed = 32f;
        }

        public override void GrapplePullSpeed(Player player, ref float speed)
        {
            speed = 26;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Player player = Main.player[Projectile.owner];
            Vector2 distToProj = Projectile.Center;
            float projRotation = Projectile.AngleTo(player.MountedCenter) - 1.57f;
            bool doIDraw = true;
            Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Hooks/THanosChain").Value; //change this accordingly to your chain texture

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
                        Utils.Size(texture) / 2f, 1f, SpriteEffects.None, 0);
                }
            }
            return true;
        }
    }
}