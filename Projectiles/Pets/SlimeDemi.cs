using System;
using System.Collections.Generic;
using CalValEX;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class SlimeDemi : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Slime Demigod");
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(197);
            base.aiType = 197;
            base.drawOffsetX = 6;
            base.drawOriginOffsetY = 7;
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
                modPlayer.mSlime = false;
            }
            if (modPlayer.mSlime)
            {
                projectile.timeLeft = 2;
            }
        }
    }
}
