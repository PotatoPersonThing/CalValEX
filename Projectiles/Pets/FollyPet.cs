using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class FollyPet : ModFlyingPet
    {
        public override float TeleportThreshold => 1440f;

        public override Vector2 FlyingOffset => new Vector2(68f * -Main.player[projectile.owner].direction, -50f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Bumblefolly");
            Main.projFrames[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 78;
            projectile.height = 68;
            projectile.ignoreWater = true;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SimpleGlowmask(spriteBatch);
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 12);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mFolly = false;

            if (modPlayer.mFolly)
                projectile.timeLeft = 2;

            CalValEX.Bumble = false;
        }
    }
}