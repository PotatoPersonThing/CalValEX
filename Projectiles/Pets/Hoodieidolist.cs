using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class Hoodieidolist : ModFlyingPet
    {
        public override float TeleportThreshold => 1440f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Shydolist");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 52;
            projectile.height = 78;
            projectile.ignoreWater = true;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SimpleGlowmask(spriteBatch);
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 12);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.eidolist = false;
            if (modPlayer.eidolist)
                projectile.timeLeft = 2;
        }
    }
}