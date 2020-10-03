using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.LightPets
{

    public class Lightshield : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arctic Shield");
            Main.projFrames[projectile.type] = 1;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.damage = 0;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.hostile = false;
            projectile.width = 98;
            projectile.height = 98;
            projectile.aiStyle = -1;
            projectile.netImportant = true;
        }

        public override bool? CanCutTiles()
        {
            return false;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Lighting.AddLight(projectile.Center, 1.08f, 2.27f, 2.55f);
            Texture2D texture = Main.projectileTexture[projectile.type];
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, projectile.GetAlpha(lightColor), projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2), 1f, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.None, 0f);
            return false;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (player.dead || !player.active)
                projectile.Kill();

            Vector2 idlePosition = player.Center;
            idlePosition.Y -= projectile.height / 2;
            idlePosition.X -= projectile.width / 2;
            projectile.position = idlePosition;
            projectile.spriteDirection = 1;

            projectile.rotation += -0.75f;
            if (projectile.rotation > MathHelper.TwoPi)
            {
                projectile.rotation -= MathHelper.TwoPi;
            }
            else if (projectile.rotation < 0)
            {
                projectile.rotation += MathHelper.TwoPi;
            }

            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
                calamityMod.Call("AddAbyssLightStrength", projectile.owner, 2);
            }

            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.Lightshield = false;
            if (modPlayer.Lightshield)
                projectile.timeLeft = 2;
        }
    }
}