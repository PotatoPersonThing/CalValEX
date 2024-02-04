using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Projectiles
{
    public class ApolloBalloonProj : ModProjectile
    {
        public List<VerletSimulatedSegment> Segments;
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 5; //frames
            ProjectileID.Sets.DrawScreenCheckFluff[Type] = 2222;
        }

        public override void SetDefaults()
        {
            Projectile.width = 194;
            Projectile.height = 200;
            Projectile.penetrate = -1;
            Projectile.netImportant = true;
            Projectile.timeLeft *= 5;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            if (Projectile.ai[0] == 0)
            {
                Segments = new List<VerletSimulatedSegment>(100);
                for (int i = 0; i < 100; i++)
                {
                    VerletSimulatedSegment segment = new VerletSimulatedSegment(Projectile.Center + Vector2.UnitY * 5 * i);
                    Segments.Add(segment);
                }

                Segments[0].locked = true;
                Segments[Segments.Count - 1].locked = true;
                Projectile.ai[0] = 1;
            }
            //this can also be a only flying pet, go below and search for the bool onlyFlying.
            Player owner = Main.player[Projectile.owner];
            if (!owner.active)
            {
                Projectile.active = false;
                return;
            }

            {
                Player player = Main.player[Projectile.owner];
                CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
                if (player.dead)
                {
                    modPlayer.apballoon = false;
                }
                if (modPlayer.apballoon)
                {
                    Projectile.timeLeft = 2;
                }
            }
            Vector2 idealPos = owner.Center - 260 * Vector2.UnitY + Vector2.UnitX * - 210;
            if (Projectile.Center.Distance(idealPos) > 64)
            {
                float playerSpeedAbs = Math.Abs(Main.LocalPlayer.velocity.X);
                float speed = playerSpeedAbs > 12 ? Main.LocalPlayer.velocity.X - Math.Sign(Main.LocalPlayer.velocity.X) * 0.1f : 12;
                Projectile.velocity = Projectile.DirectionTo(idealPos).SafeNormalize(Vector2.Zero) * Math.Abs(speed);
            }
            else
            {
                Projectile.velocity *= 0.9f;
            }
            Projectile.direction = Math.Sign(Projectile.velocity.X);
            Projectile.spriteDirection = Projectile.direction;
            if (Segments is null)
            {
                Segments = new List<VerletSimulatedSegment>(100);
                for (int i = 0; i < 100; ++i)
                    Segments[i] = new VerletSimulatedSegment(Projectile.Center, false);
            }

            Segments[0].oldPosition = Segments[0].position;
            Segments[0].position = Projectile.Center + Vector2.UnitX * Projectile.direction * 20;

            Segments[Segments.Count - 1].oldPosition = Segments[Segments.Count - 1].position;
            Segments[Segments.Count - 1].position = owner.Center;

            Segments = VerletSimulatedSegment.SimpleSimulation(Segments, 2, loops: 100, gravity: 0.3f);

            Projectile.netUpdate = true;
            Projectile.netSpam = 0;

            if (Projectile.frameCounter++ > 6)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
            }
            if (Projectile.frame > 4)
                Projectile.frame = 0;
        }
        public static Vector2 GetDesiredVelocityForDistance(Vector2 start, Vector2 end, float slowDownFactor, int time)
        {
            Vector2 velocity = start.DirectionTo(end).SafeNormalize(Vector2.Zero);
            float distance = start.Distance(end);
            float velocityFactor = (distance * (float)Math.Log(slowDownFactor)) / ((float)Math.Pow(slowDownFactor, time) - 1);
            return velocity * velocityFactor;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            if (Segments == null || Segments.Count <= 0)
                return true;
            for (int i = 0; i < Segments.Count; i++)
            {
                VerletSimulatedSegment seg = Segments[i];
                float dist = i > 0 ? Vector2.Distance(seg.position, Segments[i - 1].position) : 0;
                if (dist <= 2)
                    dist = 2;
                dist += 2;
                if (i == Segments.Count - 1)
                {
                    dist = Vector2.Distance(seg.position, Main.player[Projectile.owner].Center) + 2;
                }
                float rot = 0f;
                if (i > 0)
                    rot = seg.position.DirectionTo(Segments[i - 1].position).ToRotation();
                Main.EntitySpriteDraw(TextureAssets.MagicPixel.Value, seg.position - Main.screenPosition, new Rectangle(0, 0, (int)dist, 2), Color.Black, rot, TextureAssets.BlackTile.Size() / 2, 1f, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0);
            }
            return true;
        }
    }
}