using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX;

namespace CalValEX.Projectiles.Pets {
	public class HeatBaby : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Baby Cinder Spirit");
			Main.projFrames[projectile.type] = 4;
			
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.BabyHornet);
			aiType = ProjectileID.BabyHornet;
		}

		public override bool PreAI() {
			_ = Main.player[projectile.owner];
			return true;
		}

		public override void AI() {
			Player player = Main.player[projectile.owner];
			CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
			if (player.dead) {
				modPlayer.mHeat2 = false;
			}
			if (modPlayer.mHeat2) {
				projectile.timeLeft = 2;
			}
		}
	}
}