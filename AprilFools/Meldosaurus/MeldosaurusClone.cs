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
            //DisplayName.SetDefault("Meldosaurid Clone");
            Main.projFrames[Projectile.type] = 7;
        }

        public override void SetDefaults()
        {
            Projectile.width = 77;
            Projectile.height = 118;
            Projectile.hostile = true;
            Projectile.timeLeft = 120;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.aiStyle = -1;
        }

        public override void AI()
        {
            int distance = 200;
            Projectile.ai[1]++;
            if (Projectile.ai[1] == 30)
            {
                int killhim = (int)Projectile.ai[0];
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item, (int)Projectile.Center.X, (int)Projectile.Center.Y, 20);
                Vector2 position = Projectile.Center;
                position.X = Projectile.Center.X;
                Vector2 targetPosition = Main.player[killhim].Center;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                Projectile.velocity = direction * 16;
            }
            if (Projectile.ai[1] < 30)
            {
                Projectile.velocity.X = 0;
                Projectile.velocity.Y = 0;
                int killhim = (int)Projectile.ai[0];
                Projectile.rotation = Projectile.AngleTo(Main.player[killhim].Center);
            }
            if (Projectile.ai[1] >= 110/* && CalamityMod.World.CalamityWorld.revenge*/)
            {
                int speed = /*CalamityMod.World.CalamityWorld.death ? 20 :*/ 15;
                Terraria.Audio.SoundEngine.PlaySound(SoundID.NPCKilled, (int)Projectile.Center.X, (int)Projectile.Center.Y, 13);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), (int)Projectile.Center.X, (int)Projectile.Center.Y, -speed, 0, ModContent.ProjectileType<EntropicVomit>(), Main.expertMode ? 30 : 35, 0, Main.myPlayer);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(),(int)Projectile.Center.X, (int)Projectile.Center.Y, speed, 0, ModContent.ProjectileType<EntropicVomit>(), Main.expertMode ? 30 : 35, 0, Main.myPlayer);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(),(int)Projectile.Center.X, (int)Projectile.Center.Y, 0, -speed, ModContent.ProjectileType<EntropicVomit>(), Main.expertMode ? 30 : 35, 0, Main.myPlayer);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(),(int)Projectile.Center.X, (int)Projectile.Center.Y, 0, speed, ModContent.ProjectileType<EntropicVomit>(), Main.expertMode ? 30 : 35, 0, Main.myPlayer);
                Projectile.active = false;
            }
            var thisRect = Projectile.getRect();

            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                var proj = Main.projectile[i];

                if (proj != null && proj.active && proj.getRect().Intersects(thisRect) && proj.type == ModContent.ProjectileType<MeldosaurusClone>() && proj != Projectile)
                {
                    //for (int x = 0; x < 3; x++)
                    //Gore.NewGore(Projectile.Center, Projectile.velocity, mod.GetGoreSlot("Projectiles/NPCs/InkShot"), 1f); 
                    //proj.active = false;
                    //Projectile.active = false;
                }
            }

            Projectile.frameCounter++;
            if (Projectile.frameCounter > 5)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame > 6)
                {
                    Projectile.frame = 0;
                }
            }
        }
    }
}