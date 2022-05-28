using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Boi
{
    public class Mire : ModProjectile
    {
        public int health = 20;
        public int ow = 0;
        public bool anaex = false;
        public int frozen = 30;
        public int crosstimer = 0;
        public int shoottimer = 0;
        public override string Texture => "CalValEX/ExtraTextures/Boi/Mire";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mire");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            Projectile.width = 80;
            Projectile.height = 80;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 18000;
            Projectile.alpha = 0;
        }

        public override void AI()
        {
            //if (Projectile.alpha <= 0)
            {
                frozen--;
            }
            if (frozen <= 0)
            {
                shoottimer++;
                crosstimer++;
            }
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (!CalValEX.DetectProjectile(ModContent.ProjectileType<BoiUI>()))
            {
                Projectile.active = false;
            }

            var thisRect = Projectile.getRect();

            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                var proj = Main.projectile[i];

                if (proj != null && proj.active && proj.getRect().Intersects(thisRect) && proj.type == ModContent.ProjectileType<AnahitaTear>() && Projectile.alpha <= 0)
                {
                    Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.NPCHit1, Projectile.Center);
                    health--;
                    proj.active = false;
                    ow = 10;
                }
                if (proj != null && proj.active && proj.getRect().Intersects(thisRect) && proj.type == ModContent.ProjectileType<Atlantis>() && Projectile.alpha <= 0 && ow <= 0)
                {
                    Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.NPCHit1, Projectile.Center);
                    health--;
                    ow = 10;
                }
            }
            if (shoottimer >= 30 - ((20 - health)/1))
            {
                for (int i = 0; i < Main.maxProjectiles; i++)
                {
                    var proj = Main.projectile[i];
                    if (proj.type == ModContent.ProjectileType<Anahita>() && Projectile.alpha <= 0 && frozen <= 0)
                    {
                        Vector2 targetPosition = proj.Center;
                        Vector2 direction = targetPosition - Projectile.Center;
                        direction.Normalize();
                        float speed = 4f;
                        Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.Item61, Projectile.Center);
                        int type = ModContent.ProjectileType<AcidRound>();
                        int damage = 0;
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, direction * speed, type, damage, 0f, Main.myPlayer);
                        anaex = true;
                    }
                }
                shoottimer = 0;
            }
            if (crosstimer >= 300)
            {
                int type = ModContent.ProjectileType<AcidRound>();
                int damage = 0;
                Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.NPCDeath13, Projectile.Center);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(-4, 4), type, damage, 0f, Main.myPlayer);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(4, 4), type, damage, 0f, Main.myPlayer);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(-4, -4), type, damage, 0f, Main.myPlayer);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(4, -4), type, damage, 0f, Main.myPlayer);
                crosstimer = 0;
            }
            Projectile.velocity = new Vector2(0, 0);
            if (health <= 0)
            {
                for (int i = 0; i < Main.maxProjectiles; i++)
                {
                    var proj = Main.projectile[i];
                    if (proj.type == ModContent.ProjectileType<Anahita>() && proj.ai[0] < 4)
                    {
                        proj.ai[0]++;
                    }
                }
                Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.NPCDeath1, Projectile.Center);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), new Vector2(Projectile.Center.X + 15, Projectile.Center.Y + 15), new Vector2(0,0), ModContent.ProjectileType<Spider>(), 0, 0f, Main.myPlayer);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), new Vector2(Projectile.Center.X - 15, Projectile.Center.Y - 15), new Vector2(0, 0), ModContent.ProjectileType<Spider>(), 0, 0f, Main.myPlayer);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), new Vector2(Projectile.Center.X + 15, Projectile.Center.Y - 15), new Vector2(0, 0), ModContent.ProjectileType<Spider>(), 0, 0f, Main.myPlayer);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), new Vector2(Projectile.Center.X - 15, Projectile.Center.Y + 15), new Vector2(0, 0), ModContent.ProjectileType<Spider>(), 0, 0f, Main.myPlayer);
                Projectile.active = false;
            }
            ow--;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            return false;
        }

        public override void PostDraw(Color lightColor)
        {
            /*Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            Texture2D texture2 = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/Brimhita").Value;
            Rectangle rectangle2 = new Rectangle(0, texture2.Height / Main.projFrames[Projectile.type] * Projectile.frame, texture2.Width, texture2.Height / Main.projFrames[Projectile.type]);
            Vector2 position2 = Projectile.Center - Main.screenPosition;
            position2.X -= 15;
            position2.Y -= 60;
            Color clo = Color.White;
            if (ow > 0)
            {
                clo = Color.Orange;
            }
            Main.EntitySpriteDraw(texture2, position2, rectangle2, clo, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
        */
        }
    }
}