using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX;

namespace CalValEX.Projectiles.Pets {
	public class Hiveling : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Hiveling");
			Main.projFrames[projectile.type] = 8;
			
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			aiType = ProjectileID.ZephyrFish;
		}

		public override bool PreAI() {
			_ = Main.player[projectile.owner];
			return true;
		}

		public override void AI() {
			Player player = Main.player[projectile.owner];
			CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
			if (player.dead) {
				modPlayer.mHive = false;
			}
			if (modPlayer.mHive) {
				projectile.timeLeft = 2;
			}
		}
	}
}