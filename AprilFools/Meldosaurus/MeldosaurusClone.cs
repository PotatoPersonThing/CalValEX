using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.AprilFools.Meldosaurus
{
    public class MeldosaurusClone : ModProjectile
    {
        public override string Texture => "CalValEX/AprilFools/Meldosaurus/Meldosaurus";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meldosaurid Clone");
            Main.projFrames[projectile.type] = 7;
        }

        public override void SetDefaults()
        {
            projectile.width = 77;
            projectile.height = 118;
            projectile.hostile = true;
            projectile.timeLeft = 120;
            projectile.aiStyle = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.aiStyle = -1;
        }

        public override void AI()
        {
            int distance = 200;
            projectile.ai[1]++;
            if (projectile.ai[1] == 30)
            {
                int killhim = (int)projectile.ai[0];
                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 20);
                Vector2 position = projectile.Center;
                position.X = projectile.Center.X;
                Vector2 targetPosition = Main.player[killhim].Center;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                projectile.velocity = direction * 16;
            }
            if (projectile.ai[1] < 30)
            {
                projectile.velocity.X = 0;
                projectile.velocity.Y = 0;
                int killhim = (int)projectile.ai[0];
                projectile.rotation = projectile.AngleTo(Main.player[killhim].Center);
            }
            if (projectile.ai[1] >= 110 && CalamityMod.World.CalamityWorld.revenge)
            {
                int speed = CalamityMod.World.CalamityWorld.death ? 20 : 15;
                Main.PlaySound(SoundID.NPCKilled, (int)projectile.Center.X, (int)projectile.Center.Y, 13);
                Projectile.NewProjectile((int)projectile.Center.X, (int)projectile.Center.Y, -speed, 0, ModContent.ProjectileType<EntropicVomit>(), Main.expertMode ? 30 : 35, 0, Main.myPlayer);
                Projectile.NewProjectile((int)projectile.Center.X, (int)projectile.Center.Y, speed, 0, ModContent.ProjectileType<EntropicVomit>(), Main.expertMode ? 30 : 35, 0, Main.myPlayer);
                Projectile.NewProjectile((int)projectile.Center.X, (int)projectile.Center.Y, 0, -speed, ModContent.ProjectileType<EntropicVomit>(), Main.expertMode ? 30 : 35, 0, Main.myPlayer);
                Projectile.NewProjectile((int)projectile.Center.X, (int)projectile.Center.Y, 0, speed, ModContent.ProjectileType<EntropicVomit>(), Main.expertMode ? 30 : 35, 0, Main.myPlayer);
                projectile.active = false;
            }
            var thisRect = projectile.getRect();

            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                var proj = Main.projectile[i];

                if (proj != null && proj.active && proj.getRect().Intersects(thisRect) && proj.type == ModContent.ProjectileType<MeldosaurusClone>() && proj != projectile)
                {
                    for (int x = 0; x < 3; x++)
                    Gore.NewGore(projectile.Center, projectile.velocity, mod.GetGoreSlot("Projectiles/NPCs/InkShot"), 1f); 
                    //proj.active = false;
                    //projectile.active = false;
                }
            }

            projectile.frameCounter++;
            if (projectile.frameCounter > 5)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
                if (projectile.frame > 6)
                {
                    projectile.frame = 0;
                }
            }
        }
    }
}