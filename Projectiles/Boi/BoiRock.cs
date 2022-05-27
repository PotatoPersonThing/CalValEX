using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;
using System.Collections.Generic;

namespace CalValEX.Projectiles.Boi
{
    public class BoiRock : ModProjectile
    {
        public override string Texture => "CalValEX/ExtraTextures/Boi/Block";
        List<int> push = new List<int>() { ModContent.ProjectileType<Brimhita>(), ModContent.ProjectileType<Anahita>() };

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rock");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            Projectile.width = 91;
            Projectile.height = 90;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 18000;
            Projectile.alpha = 255;
        }

        public override void AI()
        {
            if (!CalValEX.DetectProjectile(ModContent.ProjectileType<BoiUI>()))
            {
                Projectile.active = false;
            }

            var thisRect = Projectile.getRect();
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                var proj = Main.projectile[i];

                if (proj != null && proj.active && proj.getRect().Intersects(thisRect) && proj.type == ModContent.ProjectileType<AnahitaTear>())
                {
                    Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.Item10, Projectile.Center);
                    if ((proj.timeLeft < 110 && proj.velocity.Y > 0) || proj.velocity.Y <= 0)
                    proj.active = false;
                }
            }
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                var proj = Main.projectile[i];

                if (proj != null && proj.active && push.Contains(proj.type) && proj.getRect().Intersects(thisRect))
                {
                    Vector2 relative = proj.position - Projectile.position;
                    Rectangle rightbox = new Rectangle((int)proj.position.X + proj.width, (int)proj.position.Y + 8, proj.width / 2, proj.height - 16);
                    Rectangle leftbox = new Rectangle((int)proj.position.X, (int)proj.position.Y + 8, proj.width / 2, proj.height - 16);
                    Rectangle bottombox = new Rectangle((int)proj.position.X + 8, (int)proj.position.Y + proj.height, proj.width - 16, proj.height / 2);
                    Rectangle topbox = new Rectangle((int)proj.position.X + 8, (int)proj.position.Y, proj.width - 16, proj.height / 2);
                    //If ana is to the right of the block and moving left
                    if (relative.X >= 0 && proj.velocity.X < 0)
                    {
                        if (leftbox.Intersects(thisRect))
                        {
                            proj.position.X = Projectile.position.X + Projectile.width;
                        }
                    }
                    //If ana is to the left of the block and moving right
                    if (relative.X < 0 && proj.velocity.X > 0)
                    {
                        if (rightbox.Intersects(thisRect))
                        {
                            proj.position.X = Projectile.position.X - Projectile.width + proj.width/2;
                        }
                    }
                    //If ana is below the block and moving up
                    if (relative.Y >= 0 && proj.velocity.Y < 0)
                    {
                        if (topbox.Intersects(thisRect))
                        {
                            proj.position.Y = Projectile.position.Y + Projectile.height;
                        }
                    }
                    //If ana is above the block and moving down
                    if (relative.Y < 0 && proj.velocity.Y > 0)
                    {
                        if (bottombox.Intersects(thisRect))
                        {
                            proj.position.Y = Projectile.position.Y - Projectile.height + proj.height - 6;
                        }
                    }
                }
            }
        }

        public override void PostDraw(Color lightColor)
        {
        }
    }
}