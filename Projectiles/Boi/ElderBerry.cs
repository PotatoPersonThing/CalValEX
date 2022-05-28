using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;

namespace CalValEX.Projectiles.Boi
{
    public class ElderBerry : ModProjectile
    {
        bool collec = false;
        public override string Texture => "CalValEX/ExtraTextures/Boi/ElderBerry";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elderberry");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 18000;
            //Projectile.alpha = 255;
        }

        public override void AI()
        {
            int bop = 0;
            {
                bop++;
                Player player = Main.player[Projectile.owner];
                CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
                for (int i = 0; i < Main.maxProjectiles; i++)
                {
                    var proj = Main.projectile[i];
                    if (proj != null && proj.type == ModContent.ProjectileType<BoiUI>() && !collec)
                    {
                        if (proj.localAI[0] == 5)
                        {
                            //Projectile.alpha = 0;
                            Projectile.width = 40;
                            Projectile.height = 40;
                        }
                        else
                        {
                            //Projectile.alpha = 255;
                            Projectile.width = 20;
                            Projectile.height = 20;
                        }
                    }
                }

                if (!CalValEX.DetectProjectile(ModContent.ProjectileType<BoiUI>()))
                {
                    Projectile.active = false;
                }
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            return false;
        }

        public override void PostDraw(Color lightColor)
        {
            /* Player player = Main.player[Projectile.owner];
             CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
                 Texture2D texture2 = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/Atlantis").Value;
                 Rectangle rectangle2 = new Rectangle(0, texture2.Height / Main.projFrames[Projectile.type] * Projectile.frame, texture2.Width, texture2.Height / Main.projFrames[Projectile.type]);
                 Vector2 position2 = Projectile.Center - Main.screenPosition;
                 Main.EntitySpriteDraw(texture2, position2, rectangle2, Color.White, Projectile.rotation, Projectile.Size / 2f, 1f, SpriteEffects.None, 0);
           */
        }
    }
}