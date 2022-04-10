using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class BabyHage : ModFlyingPet
    {
        public override float TeleportThreshold => 1000f;

        public override float SpeedupThreshold => 300f;

        public override Vector2 FlyingOffset => new Vector2(30f * -Main.player[projectile.owner].direction, -80f);

        public override float FlyingSpeed => 2.5f;

        public override float FlyingInertia => 10f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Hage");
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 60;
            projectile.height = 60;
            projectile.ignoreWater = true;
            projectile.Opacity = 0;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SimpleGlowmask(spriteBatch);
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
                projectile.timeLeft = 2;
        }
    }
}