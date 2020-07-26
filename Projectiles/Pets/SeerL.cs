using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX;

namespace CalValEX.Projectiles.Pets {
	public class SeerL : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Small Sightseer");
			Main.projFrames[projectile.type] = 5;
			
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.BlueFairy);
			aiType = ProjectileID.BlueFairy;
            base.drawOriginOffsetY = -11;
		base.drawOffsetX = -21;
        projectile.width = 31;
		projectile.height = 15;
		}

		public override bool PreAI() {
			_ = Main.player[projectile.owner];
			return true;
		}

		public override void AI() {
			Player player = Main.player[projectile.owner];
			CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
			if (player.dead) {
				modPlayer.seerL = false;
			}
			if (modPlayer.seerL) {
				projectile.timeLeft = 2;
			}
		}
	}
}