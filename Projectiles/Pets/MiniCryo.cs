using Terraria;
using CalamityMod.Particles;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CalValEX.Projectiles.Pets
{
    public class MiniCryo : ModFlyingPet
    {
        public override bool FacesLeft => false;

        public override float TeleportThreshold => 1840f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Chill Dude");
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 20;
            projectile.height = 24;
            projectile.ignoreWater = true;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SimpleAura(spriteBatch, new string[] { "CalValEX/Projectiles/Pets/MiniCryoShield" }, false);
            return base.PreDraw(spriteBatch, lightColor);
        }

        public override void Animation(int state)
        {
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.MiniCryo = false;

            if (modPlayer.MiniCryo)
                projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            Vector2 vectorToOwner = player.Center - projectile.Center;
            float distanceToOwner = vectorToOwner.Length();
            Vector2 placementrun = new Vector2(projectile.Center.X + Main.rand.Next(-5, 5), projectile.Center.Y + Main.rand.Next(-6, 6));
            if ((Math.Abs(projectile.velocity.X) > 5 || Math.Abs(projectile.velocity.Y) > 5) && Main.rand.Next(2) == 0)
            {
                Particle mist = new MediumMistParticle(placementrun, Vector2.Zero, new Color(172, 238, 255), new Color(145, 170, 188), Main.rand.NextFloat(0.15f, 0.45f), 245 - Main.rand.Next(50), 0.02f);
                mist.Velocity = (mist.Position - projectile.Center) * 0.2f + projectile.velocity;
                GeneralParticleHandler.SpawnParticle(mist);
            }
        }
    }
}