using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX;

namespace CalValEX.Projectiles.Pets {
	public class AeroBaby : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Baby Aero Slime");
			Main.projFrames[projectile.type] = 4;
			Main.projPet[projectile.type] = true;
			
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			aiType = ProjectileID.ZephyrFish;
			projectile.scale = 1.1f;
		}

		public override bool PreAI() {
			_ = Main.player[projectile.owner];
			return true;
		}

		public override void AI() {
			Player player = Main.player[projectile.owner];
			CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
			if (player.dead) {
				modPlayer.mAero = false;
			}
			if (modPlayer.mAero) {
				projectile.timeLeft = 2;
			}
		}
	}
}