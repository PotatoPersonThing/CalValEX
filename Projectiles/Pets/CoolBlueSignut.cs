using Terraria;
using Microsoft.Xna.Framework;

namespace CalValEX.Projectiles.Pets
{
    public class CoolBlueSignut : ModFlyingPet
    {
        public override float TeleportThreshold => 1440f;

        public override Vector2 FlyingOffset => new Vector2(90f * -Main.player[projectile.owner].direction, -75f);

        private bool sigtep = false;
        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Cool Blue Signut");
            Main.projFrames[projectile.type] = 4;
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
                modPlayer.bSignut = false;

            if (modPlayer.bSignut)
                projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            Player owner = Main.player[projectile.owner];
            Vector2 vectorToOwner = owner.Center - projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            if (distanceToOwner > 1138)
            {
                sigtep = true;
            }
            if (distanceToOwner < 1139)
            {
                sigtep = false;
                projectile.alpha -= 2;
            }

            if (projectile.alpha == 45)
            {
                for (int x = 0; x < 20; x++)
                {
                    Dust.NewDust(projectile.Center, 30, 30, 173, 0f, 0f, 0, new Color(255, 255, 255), 0.8f);
                }
            }

            if (sigtep)
            {
                projectile.alpha = 255;
                for (int x = 0; x < 5; x++)
                {
                    Dust.NewDust(projectile.Center, 30, 30, 173, 0f, 0f, 0, new Color(255, 255, 255), 0.8f);
                }
            }
        }
    }
}