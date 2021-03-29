using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

// If you don't know what to change this to, don't mess with this code.
// You will fail
namespace CalValEX.Projectiles.Pets
{
    public class AquaHead : ModProjectile
    {
        private static readonly int Size = 20;
        private static readonly int SegmentCount = 9;
        private bool SpawnedSegments = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aquatic Pest");
            ProjectileID.Sets.NeedsUUID[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = projectile.height = Size;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.netImportant = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 300;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            if (!SpawnedSegments)
            {
                int tail = Projectile.NewProjectile(projectile.Center, Vector2.Zero, ModContent.ProjectileType<AquaTail>(),
                    projectile.damage, projectile.knockBack, 0, projectile.whoAmI);
                // The minus one is because this segment and the tail are incorporated in the worm as well
                for (int i = 0; i < SegmentCount - 2; i++)
                {
                    float uuid = (float)Projectile.GetByUUID(Main.myPlayer, Main.projectile[tail].ai[0]);
                    int body = Projectile.NewProjectile(projectile.Center, Vector2.Zero,
                        ModContent.ProjectileType<AquaBody>(), projectile.damage, projectile.knockBack,
                        0, uuid);
                    int back = Projectile.NewProjectile(projectile.Center, Vector2.Zero,
                        ModContent.ProjectileType<AquaBody>(), projectile.damage, projectile.knockBack,
                        0, (float)body);

                    Main.projectile[body].ai[1] = 1f;
                    Main.projectile[body].netUpdate = true;
                    Main.projectile[body].identity = projectile.whoAmI;

                    Main.projectile[back].netUpdate = true;
                    Main.projectile[back].ai[1] = 1f;
                    Main.projectile[body].identity = projectile.whoAmI;

                    Main.projectile[tail].ai[0] = Main.projectile[body].projUUID;
                    Main.projectile[tail].netUpdate = true;
                    Main.projectile[tail].ai[1] = 1f;
                }
                SpawnedSegments = true;
            }
            // Consistently update the worm
            if ((int)Main.time % 120 == 0)
            {
                projectile.netUpdate = true;
            }

            // Custom AI here
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
            {
                modPlayer.asPet = false;
            }
            if (modPlayer.asPet)
            {
                projectile.timeLeft = 2;
            }

            Vector2 PlayerCenter = player.Center;
            float MinVel = 0.36f;
            Vector2 ProjDistance = PlayerCenter - projectile.Center;
            if (ProjDistance.Length() < 100f)
            {
                MinVel = 0.22f;
            }
            if (ProjDistance.Length() < 80f)
            {
                MinVel = 0.1f;
            }
            if (ProjDistance.Length() > 50f)
            {
                if (Math.Abs(PlayerCenter.X - projectile.Center.X) > 10f)
                {
                    projectile.velocity.X = projectile.velocity.X + MinVel * (float)Math.Sign(PlayerCenter.X - projectile.Center.X);
                }
                if (Math.Abs(PlayerCenter.Y - projectile.Center.Y) > 5f)
                {
                    projectile.velocity.Y = projectile.velocity.Y + MinVel * (float)Math.Sign(PlayerCenter.Y - projectile.Center.Y);
                }
            }
            else if (projectile.velocity.Length() > 1.6f)
            {
                projectile.velocity *= 0.96f;
            }
            float MaxVel = 15f;
            if (ProjDistance.Length() > 800f)
            {
                MaxVel = 25;
            }
            else if (ProjDistance.Length() > 500f)
            {
                MaxVel = 22f;
            }
            else if (ProjDistance.Length() > 300f)
            {
                MaxVel = 18.5f;
            }
            else
            {
                MaxVel = 15;
            }

            if (projectile.velocity.Length() > MaxVel)
            {
                projectile.velocity = Vector2.Normalize(projectile.velocity) * MaxVel;
            }
            if (ProjDistance.Length() > 2000f)
            {
                projectile.Center = PlayerCenter;
            }
            if (Math.Abs(projectile.velocity.Y) < 1f)
            {
                projectile.velocity.Y = projectile.velocity.Y - 0.1f;
            }
            // NOTE: If you wish for this worm to travel at very high speeds, the
            // Body and tail segments will gain gaps. You would have to change the position adjusting
            // In the body and tail's code to mitigate this problem.

            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;

            int oldDirection = projectile.direction;
            projectile.direction = projectile.spriteDirection = (projectile.velocity.X > 0f).ToDirectionInt();

            // Update the projectile in multiplayer if the determined direction is not the true direction.
            // It will do weird things in multiplayer because of a lack of syncing among the directions
            if (oldDirection != projectile.direction)
            {
                projectile.netUpdate = true;
            }

            projectile.position = projectile.Center;
            projectile.width = projectile.height = Size;
            projectile.Center = projectile.position;
        }
    }
}