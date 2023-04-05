using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class Smauler : ModFlyingPet
    {
        public override float TeleportThreshold => 1440f;

        public override Vector2 FlyingOffset
        {
            get
            {
                Player player = Main.player[Projectile.owner];
                CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

                float offSetX = modPlayer.shart ? (48f) : (48f * -Main.player[Projectile.owner].direction); //this is needed so it's always behind the player.
                float offSetY = -50f; //how much higher from the center the pet should float
                return new Vector2(offSetX, offSetY);
            }
        }

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            // DisplayName.SetDefault("Smauler");
            Main.projFrames[Projectile.type] = 8;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.ignoreWater = true;
            Projectile.GetGlobalProjectile<CalValEXGlobalProjectile>().isCalValPet = true;
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 12);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.smaul = false;

            if (modPlayer.smaul)
                Projectile.timeLeft = 2;
        }
    }
}