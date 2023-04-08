using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class BabyMonster : ModFlyingPet
    {
        public override float TeleportThreshold => 1000f;

        public override float SpeedupThreshold => 300f;

        public override Vector2 FlyingOffset => new Vector2(70f * -Main.player[Projectile.owner].direction, -40f);

        public override float FlyingSpeed => 3f;

        public override float FlyingInertia => 10f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            // DisplayName.SetDefault("Baby Monster");
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

        public override void Animation(int state)
        {
        }

        public override void PostDraw(Color lightColor)
        {
            SimpleGlowmask(Main.spriteBatch);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.BMonster = false;

            if (modPlayer.BMonster)
                Projectile.timeLeft = 2;
        }
    }
}