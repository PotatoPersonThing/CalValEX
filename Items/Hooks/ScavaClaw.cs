using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX;

namespace CalValEX.Items.Hooks
{

internal class ScavaClaw : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Scavenger Claw");
            base.drawOriginOffsetY = -10;
		    base.drawOffsetX = -11;
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
			if (hooksOut > 2) 
			{
				return false;
			}
			return true;
		}

		public override float GrappleRange() {
			return 800f;
		}

		public override void NumGrappleHooks(Player player, ref int numHooks) {
			numHooks = 2;
		}

		public override void GrappleRetreatSpeed(Player player, ref float speed) {
			speed = 25f;
		}

		public override void GrapplePullSpeed(Player player, ref float speed) {
			speed = 13;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
{
    Player player = Main.player[projectile.owner];
    Vector2 distToProj = projectile.Center;
    float projRotation = projectile.AngleTo(player.MountedCenter) - 1.57f;
    bool doIDraw = true;
    Texture2D texture = mod.GetTexture("Items/Hooks/ScavaChain"); //change this accordingly to your chain texture

    while (doIDraw)
    {
        float distance = (player.MountedCenter - distToProj).Length();
        if (distance < (texture.Height + 1))
        {
            doIDraw = false;
        }
        else if (!float.IsNaN(distance))
        {
            Color drawColor = Lighting.GetColor((int)distToProj.X / 16, (int)(distToProj.Y / 16f));
            distToProj += projectile.DirectionTo(player.MountedCenter) * texture.Height;
            spriteBatch.Draw(texture, distToProj - Main.screenPosition,
                new Rectangle(0, 0, texture.Width, texture.Height), drawColor, projRotation,
                Utils.Size(texture) / 2f, 1f, SpriteEffects.None, 0f);
        }

    }
    return true;
}
	}

}
