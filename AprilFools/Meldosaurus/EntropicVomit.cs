using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.AprilFools.Meldosaurus
{
    public class EntropicVomit : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meld Blob");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.hostile = true;
            projectile.timeLeft = 600;
            projectile.aiStyle = -1;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.aiStyle = -1;
        }

        public override void AI()
        {
            projectile.velocity.X *= 0.995f;
            projectile.velocity.Y += 0.17f;
            projectile.rotation = projectile.velocity.ToRotation();
        }

       /*public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {

            if (projectile.ai[0] == 1)
            {
                Texture2D deusheadsprite = (ModContent.GetTexture("CalValEX/AprilFools/Meldosaurus/EntropicVomitSmall"));
                Rectangle deusheadsquare = new Rectangle(0, deusheadsprite.Height, deusheadsprite.Width, deusheadsprite.Height);
                Color deusheadalpha = projectile.GetAlpha(drawColor);
                spriteBatch.Draw(deusheadsprite, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), deusheadsquare, deusheadalpha, projectile.rotation, Utils.Size(deusheadsquare) / 2f, projectile.scale, SpriteEffects.None, 0f);
            }
            else if (projectile.ai[0] == 2)
            {
                Texture2D deusheadsprite = (ModContent.GetTexture("CalValEX/AprilFools/Meldosaurus/EntropicVomitLarge"));
                Rectangle deusheadsquare = new Rectangle(0, deusheadsprite.Height, deusheadsprite.Width, deusheadsprite.Height);
                Color deusheadalpha = projectile.GetAlpha(drawColor);
                spriteBatch.Draw(deusheadsprite, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), deusheadsquare, deusheadalpha, projectile.rotation, Utils.Size(deusheadsquare) / 2f, projectile.scale, SpriteEffects.None, 0f);
            }
            else
            {
                Texture2D deusheadsprite = (ModContent.GetTexture("CalValEX/AprilFools/Meldosaurus/EntropicVomit"));
                Rectangle deusheadsquare = new Rectangle(0, deusheadsprite.Height, deusheadsprite.Width, deusheadsprite.Height);
                Color deusheadalpha = projectile.GetAlpha(drawColor);
                spriteBatch.Draw(deusheadsprite, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), deusheadsquare, deusheadalpha, projectile.rotation, Utils.Size(deusheadsquare) / 2f, projectile.scale, SpriteEffects.None, 0f);
            }
            return false;
        }*/
    }
}