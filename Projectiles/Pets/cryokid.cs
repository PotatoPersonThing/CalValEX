using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class Cryokid : ModFlyingPet
    {
        public override float TeleportThreshold => 1440f;

        public override Vector2 FlyingOffset => new Vector2(68f * -Main.player[projectile.owner].direction, -50f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Cryokid");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 58;
            projectile.height = 52;
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
                modPlayer.cryokid = false;

            if (modPlayer.cryokid)
                projectile.timeLeft = 2;
        }
    }
}