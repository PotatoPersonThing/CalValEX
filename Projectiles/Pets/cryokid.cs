using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
    {

    public class cryokid : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("cryokid");
            Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
        }
        
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.BabyHornet);
            aiType = ProjectileID.BabyHornet;
            drawOriginOffsetY = -29;
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            return true;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
            {
                modPlayer.cryokid = false;
            }
            if (modPlayer.cryokid)
            {
                projectile.timeLeft = 2;
            }
        }
        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 70) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 1; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 4;
            }
        }
    }

}