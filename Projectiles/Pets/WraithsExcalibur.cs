using System;
using System.Collections.Generic;
using CalValEX;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class WraithsExcalibur : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wraith's Excalibur");
            Main.projFrames[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(197);
            base.aiType = 197;
            base.drawOriginOffsetY = -33;
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
                modPlayer.excal = false;
            }
            if (modPlayer.excal)
            {
                projectile.timeLeft = 2;
            }
        }
    }
}
