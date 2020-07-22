using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
    {

    public class cloudmini : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("cloudgirl");
            Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ZephyrFish);
            aiType = ProjectileID.ZephyrFish;
            drawOffsetX = -70;
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            return true;
        }
        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 400) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 1; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 4;
            }
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
            {
                modPlayer.cloudmini = false;
            }
            if (modPlayer.cloudmini)
            {
                projectile.timeLeft = 2;
            }
        }
    }
}