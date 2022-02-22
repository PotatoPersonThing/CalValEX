using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.ExoMechs
{
    public class AresBody : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Toy Ares");
            Main.projFrames[projectile.type] = 1;
            Main.projPet[projectile.type] = true;
            //drawOriginOffsetY = -15;
            //drawOffsetX = -14;
        }

        public override void SetDefaults()
        {
            projectile.width =  54;
            projectile.height = 46;
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.aiStyle = -1;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
                projectile.timeLeft = 0;
            if (!modPlayer.ares)
                projectile.timeLeft = 0;
            if (modPlayer.ares)
                projectile.timeLeft = 2;

            Vector2 vectorToOwner = player.Center;
            vectorToOwner.Y -= 60f;
            vectorToOwner.X -= 10f;

            float value = 8f;

            float velY = MathHelper.Clamp(player.velocity.Y, -value, value);
            float velX = MathHelper.Clamp(player.velocity.X, -value, value);

            vectorToOwner.X += 0.5f * -velX;
            vectorToOwner.Y += 0.5f * -velY;

            projectile.Center = vectorToOwner;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            int bottomdist = 40;
            int topdist = 46;
            int weapon1dist = 80;
            int weapon2dist = 70;

            int ybottomdist = 5;
            int ytopdist = 20;

            Texture2D dartarm = (ModContent.GetTexture("CalValEX/Projectiles/Pets/ExoMechs/AresToyDart"));
            Texture2D squirtarm = (ModContent.GetTexture("CalValEX/Projectiles/Pets/ExoMechs/AresToySquirt"));
            Texture2D nukearm = (ModContent.GetTexture("CalValEX/Projectiles/Pets/ExoMechs/AresToyNuke"));
            Texture2D laserarm = (ModContent.GetTexture("CalValEX/Projectiles/Pets/ExoMechs/AresToyLaser"));
            Texture2D armtop = (ModContent.GetTexture("CalValEX/Projectiles/Pets/ExoMechs/AresArmTop"));
            Texture2D armbottom = (ModContent.GetTexture("CalValEX/Projectiles/Pets/ExoMechs/AresArmBottom"));

            Rectangle dartarmsquare = new Rectangle(0, 0, dartarm.Width, dartarm.Height);
            Rectangle squirtarmsquare = new Rectangle(0, 0, squirtarm.Width, squirtarm.Height);
            Rectangle nukearmsquare = new Rectangle(0, 0, nukearm.Width, nukearm.Height);
            Rectangle laserarmsquare = new Rectangle(0, 1, laserarm.Width, laserarm.Height);
            Rectangle armtopsquare = new Rectangle(0, 0, armtop.Width, armtop.Height);
            Rectangle armbottomsquare = new Rectangle(0, 0, armbottom.Width, armbottom.Height);

            Color projalpha = projectile.GetAlpha(drawColor);

            //Draw left arms
            spriteBatch.Draw(dartarm, projectile.Center - Main.screenPosition + new Vector2(0f - weapon2dist, projectile.gfxOffY + ybottomdist), dartarmsquare, projalpha, projectile.AngleTo(Main.MouseWorld), Utils.Size(dartarmsquare) / 2f, projectile.scale, SpriteEffects.FlipHorizontally, 0f);
            spriteBatch.Draw(laserarm, projectile.Center - Main.screenPosition + new Vector2(0f - weapon1dist, projectile.gfxOffY - ytopdist), laserarmsquare, projalpha, projectile.AngleTo(Main.MouseWorld), Utils.Size(laserarmsquare) / 2f, projectile.scale, SpriteEffects.FlipHorizontally, 0f);
            spriteBatch.Draw(armtop, projectile.Center - Main.screenPosition + new Vector2(0f - topdist, projectile.gfxOffY - ytopdist), armtopsquare, projalpha, projectile.rotation, Utils.Size(armtopsquare) / 2f, projectile.scale, SpriteEffects.FlipHorizontally, 0f);
            spriteBatch.Draw(armbottom, projectile.Center - Main.screenPosition + new Vector2(0f - bottomdist, projectile.gfxOffY + ybottomdist), armbottomsquare, projalpha, projectile.rotation, Utils.Size(armbottomsquare) / 2f, projectile.scale, SpriteEffects.FlipHorizontally, 0f);

            //Draw right arms
            spriteBatch.Draw(squirtarm, projectile.Center - Main.screenPosition + new Vector2(0f + weapon2dist, projectile.gfxOffY + ybottomdist), squirtarmsquare, projalpha, projectile.AngleTo(Main.MouseWorld), Utils.Size(squirtarmsquare) / 2f, projectile.scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(nukearm, projectile.Center - Main.screenPosition + new Vector2(0f + weapon1dist, projectile.gfxOffY - ytopdist), nukearmsquare, projalpha, projectile.AngleTo(Main.MouseWorld), Utils.Size(nukearmsquare) / 2f, projectile.scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(armtop, projectile.Center - Main.screenPosition + new Vector2(0f + topdist, projectile.gfxOffY - ytopdist), armtopsquare, projalpha, projectile.rotation, Utils.Size(armtopsquare) / 2f, projectile.scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(armbottom, projectile.Center - Main.screenPosition + new Vector2(0f + bottomdist, projectile.gfxOffY + ybottomdist), armbottomsquare, projalpha, projectile.rotation, Utils.Size(armbottomsquare) / 2f, projectile.scale, SpriteEffects.None, 0f);
            return true;
        }
    }
}