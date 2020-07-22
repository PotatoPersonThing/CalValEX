using System;
using System.Collections.Generic;
using CalValEX;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class Headoge : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Headoge");
            Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
            drawOriginOffsetY = -50;
            drawOffsetX = -75;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ZephyrFish);
            aiType = ProjectileID.ZephyrFish;
        }

        public override bool PreAI()
        {
            _ = Main.player[projectile.owner];
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
            {
                modPlayer.hDoge = false;
            }
            if (modPlayer.hDoge)
            {
                projectile.timeLeft = 2;
            }
        }
    }
}
