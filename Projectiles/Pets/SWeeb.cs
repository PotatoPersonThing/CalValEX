using System;
using System.Collections.Generic;
using CalValEX;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class SWeeb : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Armored Stasis Drone");
            Main.projFrames[projectile.type] = 4;
            drawOffsetX = -110;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ZephyrFish);
            aiType = ProjectileID.ZephyrFish;
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
                modPlayer.sWeeb = false;
            }
            if (modPlayer.sWeeb)
            {
                projectile.timeLeft = 2;
            }
        }
    }
}
