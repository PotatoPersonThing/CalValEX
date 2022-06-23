using CalValEX.Buffs.LightPets;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.Wulfrum
{
    public class WulfrumDrone : ModFlyingPet
    {
        public override float TeleportThreshold => 1440f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Wulfrum Drone");
            Main.projFrames[Projectile.type] = 8;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.ignoreWater = true;
        }

        public override void Animation(int state)
        {
            if (Main.player[Projectile.owner].HasBuff(ModContent.BuffType<PylonBuff>()))
            {
                if (Projectile.frameCounter++ > 8)
                {
                    Projectile.frameCounter = 0;
                    Projectile.frame++;
                    if (Projectile.frame >= 8)
                        Projectile.frame = 4;
                }
            }
            else
            {
                if (Projectile.frameCounter++ % 8 == 7)
                {
                    Projectile.frame++;
                }
                if (Projectile.frame >= 4)
                {
                    Projectile.frame = 0;
                }
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.drone = false;

            if (modPlayer.drone)
                Projectile.timeLeft = 2;
        }
    }
}