using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class BabyMonster : ModFlyingPet
    {
        public override float TeleportThreshold => 1000f;

        public override float SpeedupThreshold => 300f;

        public override Vector2 FlyingOffset => new Vector2(70f * -Main.player[projectile.owner].direction, -40f);

        public override float FlyingSpeed => 3f;

        public override float FlyingInertia => 10f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Baby Monster");
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 60;
            projectile.height = 60;
            projectile.ignoreWater = true;
            projectile.Opacity = 0;
        }

        public override void Animation(int state)
        {
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SimpleGlowmask(spriteBatch);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.BMonster = false;

            if (modPlayer.BMonster)
                projectile.timeLeft = 2;
        }
    }
}