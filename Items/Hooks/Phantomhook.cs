using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX;

namespace CalValEX.Items.Hooks
{

internal class Phantomhook : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Phantom Hook");
		}

		public override void SetDefaults()
        {
			projectile.CloneDefaults(ProjectileID.BatHook);
		}
        public override bool? CanUseGrapple(Player player) {
			int hooksOut = 0;
			for (int l = 0; l < 1000; l++) {
				if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == projectile.type) {
					hooksOut++;
				}
			}
			if (hooksOut > 3) 
			{
				return false;
			}
			return true;
		}

		public override float GrappleRange() {
			return 900f;
		}

		public override void NumGrappleHooks(Player player, ref int numHooks) {
			numHooks = 3;
		}

		public override void GrappleRetreatSpeed(Player player, ref float speed) {
			speed = 30f;
		}

		public override void GrapplePullSpeed(Player player, ref float speed) {
			speed = 15;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor) {
			Vector2 playerCenter = Main.player[projectile.owner].MountedCenter;
			Vector2 center = projectile.Center;
			Vector2 distToProj = playerCenter - projectile.Center;
			float projRotation = distToProj.ToRotation() - 1.57f;
			float distance = distToProj.Length();
			while (distance > 30f && !float.IsNaN(distance)) {
				distToProj.Normalize();                
				distToProj *= 24f;                 
				center += distToProj;                   
				distToProj = playerCenter - center;   
				distance = distToProj.Length();
				Color drawColor = lightColor;
				spriteBatch.Draw(mod.GetTexture("Items/Hooks/Polterchain"), new Vector2(center.X - Main.screenPosition.X, center.Y - Main.screenPosition.Y),
					new Rectangle(0, 0, Main.chain30Texture.Width, Main.chain30Texture.Height), drawColor, projRotation,
					new Vector2(Main.chain30Texture.Width * 0.5f, Main.chain30Texture.Height * 0.5f), 1f, SpriteEffects.None, 0f);
			}
			return true;
		}
	}

}
