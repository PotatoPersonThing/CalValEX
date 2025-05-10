using Terraria;
using Terraria.ID;

namespace CalValEX.Projectiles.Pets
{
    public class CoolBlueSignut : ModFlyingPet
    {
        public override bool FacesLeft => false;
        public override float TeleportThreshold => 1440f;

        public override Vector2 FlyingOffset => new(90f * -Main.player[Projectile.owner].direction, -75f);

        private bool sigtep = false;
        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            // DisplayName.SetDefault("Cool Blue Signut");
            Main.projFrames[Projectile.type] = 7;
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
                modPlayer.bSignut = false;

            if (modPlayer.bSignut)
                Projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            Player owner = Main.player[Projectile.owner];
            Vector2 vectorToOwner = owner.Center - Projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            if (distanceToOwner > 1138)
            {
                sigtep = true;
            }
            if (distanceToOwner < 1139)
            {
                sigtep = false;
                Projectile.alpha -= 2;
            }

            if (Projectile.alpha == 45)
            {
                for (int x = 0; x < 20; x++)
                {
                    Dust.NewDust(Projectile.Center, 30, 30, DustID.ShadowbeamStaff, 0f, 0f, 0, new Color(255, 255, 255), 0.8f);
                }
            }

            if (sigtep)
            {
                Projectile.alpha = 255;
                for (int x = 0; x < 5; x++)
                {
                    Dust.NewDust(Projectile.Center, 30, 30, DustID.ShadowbeamStaff, 0f, 0f, 0, new Color(255, 255, 255), 0.8f);
                }
            }
        }
    }
}