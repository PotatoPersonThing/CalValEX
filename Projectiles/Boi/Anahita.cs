using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace CalValEX.Projectiles.Boi
{
    public class Anahita : ModProjectile
    {
        public int iframes;
        public int shotcooldown;
        public bool checkpos;
        List<int> enemies = new() { ModContent.ProjectileType<Brimhita>(), ModContent.ProjectileType<Spider>(), ModContent.ProjectileType<Mire>(), ModContent.ProjectileType<Terror>() };
        List<int> hostproj = new() { ModContent.ProjectileType<AcidRound>() };

        Vector2 nipah;
        public override string Texture => "CalValEX/ExtraTextures/Boi/Anahita";

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Anahita");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            Projectile.width = 60;
            Projectile.height = 50;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 18000;
            Projectile.netImportant = true;
        }

        public override void AI()
        {
            shotcooldown--;
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (checkpos == false)
            {
                nipah.X = player.Center.X;
                nipah.Y = player.Center.Y;
                checkpos = true;
            }

            if (!player.controlUp && !player.controlDown)
            {
                player.velocity.Y = 0;
            }
            if (!player.controlRight && !player.controlLeft)
            {
                player.velocity.X = 0;
            }

            if (player.controlLeft && Projectile.position.X > player.Center.X - 382)
            {
                Projectile.velocity.X = -4;
            }
            else if (player.controlRight && Projectile.position.X < player.Center.X + 332)
            {
                Projectile.velocity.X = 4;
            }
            else
            {
                Projectile.velocity.X = 0;
            }
            if (player.controlUp && Projectile.position.Y > player.Center.Y - 238)
            {
                Projectile.velocity.Y = -4;
            }
            else if (player.controlDown && Projectile.position.Y < player.Center.Y + 173)
            {
                Projectile.velocity.Y = 4;
            }
            else
            {
                Projectile.velocity.Y = 0;
            }

            if (!CalValEX.DetectProjectile(ModContent.ProjectileType<BoiUI>()))
            {
                Projectile.active = false;
            }

            Vector2 cursor = Main.MouseWorld;
            if (player.controlUseItem && shotcooldown <= 0 && Main.myPlayer == Projectile.owner)
            {
                Vector2 position = new(Projectile.Center.X, Projectile.Center.Y - 25);
                Vector2 targetPosition = cursor;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                float speed = 10f;
                int type = ModContent.ProjectileType<AnahitaTear>();
                int damage = 0;
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, direction * speed, type, damage, 0f, Main.myPlayer);
                Projectile.netUpdate = true;
                Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.Item21, Projectile.position);
                shotcooldown = 20;
                //shotcooldown = 5;
            }
            var thisRect = Projectile.getRect();

            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                var proj = Main.projectile[i];

                if (proj != null && proj.active && proj.getRect().Intersects(thisRect) && enemies.Contains(proj.type) && iframes <= 0 && proj.alpha <= 0)
                {
                    Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.FemaleHit, Projectile.Center);
                    modPlayer.boihealth--;
                    Projectile.ai[0]--;
                    iframes = 60;
                }
                if (proj != null && proj.active && proj.getRect().Intersects(thisRect) && hostproj.Contains(proj.type) && iframes <= 0)
                {
                    Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.FemaleHit, Projectile.Center);
                    modPlayer.boihealth--;
                    Projectile.ai[0]--;
                    iframes = 60;
                    if (hostproj.Contains(proj.type))
                    {
                        proj.penetrate--;
                    }
                }
            }
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                var proj = Main.projectile[i];

                if (proj != null && proj.active && proj.getRect().Intersects(thisRect) && proj.type == ModContent.ProjectileType<Atlantis>() && proj.alpha <= 0)
                {
                    Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.Item9, Projectile.Center);
                    Projectile.penetrate = 2;
                    modPlayer.boiatlantis = true;
                }
            }
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                var proj = Main.projectile[i];

                if (proj != null && proj.active && proj.getRect().Intersects(thisRect) && proj.type == ModContent.ProjectileType<ElderBerry>() && proj.alpha <= 0)
                {
                    Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.Item8, Projectile.Center);
                    Projectile.ai[0]++;
                    proj.active = false;
                }
            }
            iframes--;
            if (iframes > 0)
            {
                Projectile.alpha = 20;
            }
            else
            {
                Projectile.alpha = 0;
            }
            if (modPlayer.boihealth <= 0 || Projectile.ai[0] < 2)
            {
                Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.PlayerKilled, Projectile.Center);
                Projectile.active = false;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            return false;     
        }

        public override void PostDraw(Color lightColor)
        {
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.boiactive)
            {
                Texture2D texture2 = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/Anahita").Value;
                Texture2D texture3 = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/AnahitaShadow").Value;
                Rectangle rectangle2 = new(0, texture2.Height / Main.projFrames[Projectile.type] * Projectile.frame, texture2.Width, texture2.Height / Main.projFrames[Projectile.type]);
                Vector2 position2 = Projectile.Center - Main.screenPosition;
                position2.X -= 15;
                position2.Y -= 60;
                Main.EntitySpriteDraw(texture3, position2, rectangle2, Color.White, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
                Main.EntitySpriteDraw(texture2, position2, rectangle2, Color.White, Projectile.rotation, Projectile.Size / 2f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
            }
        }
    }
}