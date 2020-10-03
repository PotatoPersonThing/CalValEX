using System;
using System.Collections.Generic;
using CalValEX;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class PhantomSpirit : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantom Spirit");
            Main.projFrames[projectile.type] = 6;
            Main.projPet[projectile.type] = true;
            base.drawOriginOffsetY = -15;
			base.drawOffsetX = -14;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(702);
            base.aiType = 702;
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
                modPlayer.mPhan = false;
            }
            if (modPlayer.mPhan)
            {
                projectile.timeLeft = 2;
            }
            if (Main.rand.NextFloat() < 0.5f)
            {
                int dust = Dust.NewDust(projectile.Center, 89, 100, 66, 0f, 0f, 164, new Color(255,0,251), 1f);
                Main.dust[dust].noGravity = true;
            }
        }
    }
}




