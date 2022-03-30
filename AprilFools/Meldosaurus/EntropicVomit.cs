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
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.hostile = true;
            Projectile.timeLeft = 600;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.aiStyle = -1;
        }

        public override void AI()
        {
            Projectile.velocity.X *= 0.995f;
            Projectile.velocity.Y += 0.17f;
            Projectile.rotation = Projectile.velocity.ToRotation();
        }

       /*public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {

            if (Projectile.ai[0] == 1)
            {
                Texture2D deusheadsprite = (ModContent.Request<Texture2D>("CalValEX/AprilFools/Meldosaurus/EntropicVomitSmall"));
                Rectangle deusheadsquare = new Rectangle(0, deusheadsprite.Height, deusheadsprite.Width, deusheadsprite.Height);
                Color deusheadalpha = Projectile.GetAlpha(drawColor);
                spriteBatch.Draw(deusheadsprite, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), deusheadsquare, deusheadalpha, Projectile.rotation, Utils.Size(deusheadsquare) / 2f, Projectile.scale, SpriteEffects.None, 0f);
            }
            else if (Projectile.ai[0] == 2)
            {
                Texture2D deusheadsprite = (ModContent.Request<Texture2D>("CalValEX/AprilFools/Meldosaurus/EntropicVomitLarge"));
                Rectangle deusheadsquare = new Rectangle(0, deusheadsprite.Height, deusheadsprite.Width, deusheadsprite.Height);
                Color deusheadalpha = Projectile.GetAlpha(drawColor);
                spriteBatch.Draw(deusheadsprite, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), deusheadsquare, deusheadalpha, Projectile.rotation, Utils.Size(deusheadsquare) / 2f, Projectile.scale, SpriteEffects.None, 0f);
            }
            else
            {
                Texture2D deusheadsprite = (ModContent.Request<Texture2D>("CalValEX/AprilFools/Meldosaurus/EntropicVomit"));
                Rectangle deusheadsquare = new Rectangle(0, deusheadsprite.Height, deusheadsprite.Width, deusheadsprite.Height);
                Color deusheadalpha = Projectile.GetAlpha(drawColor);
                spriteBatch.Draw(deusheadsprite, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), deusheadsquare, deusheadalpha, Projectile.rotation, Utils.Size(deusheadsquare) / 2f, Projectile.scale, SpriteEffects.None, 0f);
            }
            return false;
        }*/
    }
}