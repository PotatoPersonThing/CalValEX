using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class BabyHage : ModFlyingPet
    {
        public override float TeleportThreshold => 1000f;

        public override float SpeedupThreshold => 300f;

        public override Vector2 FlyingOffset => new Vector2(30f * -Main.player[Projectile.owner].direction, -80f);

        public override float FlyingSpeed => 2.5f;

        public override float FlyingInertia => 10f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            // DisplayName.SetDefault("Hage");
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 60;
            Projectile.height = 60;
            Projectile.ignoreWater = true;
            Projectile.Opacity = 0;
            Projectile.GetGlobalProjectile<CalValEXGlobalProjectile>().isCalValPet = true;
        }

        public override void PostDraw(Color lightColor)
        {
            SimpleGlowmask(Main.spriteBatch);
        }

        public override void Animation(int state)
        {
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.hage = false;
            
            if (modPlayer.hage)
                Projectile.timeLeft = 2;
        }
    }
}