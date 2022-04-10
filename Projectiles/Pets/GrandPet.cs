using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class GrandPet : ModFlyingPet
    {
        public override float TeleportThreshold => 1440f;

        public override bool FacesLeft => false;

        public override Vector2 FlyingOffset
        {
            get
            {
                Player player = Main.player[projectile.owner];
                CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

                float X = modPlayer.shart ? (-48f) : (48f * -Main.player[projectile.owner].direction);
                float Y = -50f;

                return new Vector2(X, Y);
            }
        }

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Great Grandson Shark");
            Main.projFrames[projectile.type] = 10;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 22;
            projectile.height = 22;
            projectile.ignoreWater = true;
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 12);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mShark = false;

            if (modPlayer.mShark)
                projectile.timeLeft = 2;
        }
    }
}