using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class Fistuloid : ModFlyingPet
    {
        public override float TeleportThreshold => 1440f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Perfistuloid");
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 44;
            Projectile.height = 56;
            Projectile.ignoreWater = true;
        }

        public override void PostDraw(Color lightColor)
        {
            //SimpleGlowmask(spriteBatch);
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 12);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mPerf = false;

            if (modPlayer.mPerf)
                Projectile.timeLeft = 2;
        }
    }
}