using CalValEX.Buffs.LightPets;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.Wulfrum
{
    public class WulfrumHover : ModFlyingPet
    {
        public override bool FacesLeft => false;

        public override float TeleportThreshold => 1440f;

        public override float FlyingSpeed => 16f;

        public override Vector2 FlyingOffset => new Vector2(48 * -Main.player[projectile.owner].direction, -90f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Wulfrum Hovercraft");
            Main.projFrames[projectile.type] = 8;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 22;
            projectile.height = 22;
            projectile.ignoreWater = true;
        }

        public override void Animation(int state)
        {
            if (Main.player[projectile.owner].HasBuff(ModContent.BuffType<PylonBuff>()))
            {
                if (projectile.frameCounter++ > 8)
                {
                    projectile.frameCounter = 0;
                    projectile.frame++;
                    if (projectile.frame >= 8)
                        projectile.frame = 4;
                }
            }
            else
            {
                if (projectile.frameCounter++ % 8 == 7)
                {
                    projectile.frame++;
                }
                if (projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.hover = false;

            if (modPlayer.hover)
                projectile.timeLeft = 2;
        }
    }
}

/* THIS CODE ONLY RUNS AFTER THE MAIN CODE RAN.
 * for custom behaviour, you can check if the projectile is walking or not via projectile.localAI[1]
 * you should make new custom behaviour with numbers higher than 0, or less than 0
 * the next few lines is an example on how to implement this
 *
 * switch ((int)projectile.localAI[1])
 * {
 *     case -1:
 *         break;
 *     case 1:
 *         break;
 * }
 *
 * 0 is already in use.
 * 0 = flying
 *
 * you can still use this, changing thing inside (however it's not recomended unless you want to add custom behaviour to this)
 */

/* private Player player;
 public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
 {if (player.HasBuff(ModContent.BuffType<PylonBuff>()))
 {
Main.projectileTexture[ModContent.BuffType<WulfrumHover>()] = Modcontent.GetTexture("CalValEX/Projectiles/Pets/Wulfrum/WulfrumHoverCharge");
}
else
{
Main.projectileTexture[ModContent.BuffType<WulfrumHover>()] = Modcontent.GetTexture("CalValEX/Projectiles/Pets/Wulfrum/WulfrumHover");
}
}
 }
}
*/

/*public override string Texture =>
    {
        if (player.pylon)
        {
            "CalamityValEX/Projectiles/Pets/Wulfrum/WulfrumHoverCharge";
        }
        else
        {
            "CalamityValEX/Projectiles/Pets/Wulfrum/WulfrumHover";
        }
    }*/
/* public override void AI()
{
 projectile.frameCounter += 1.0;
    if (player.pylon)
    {
        if (projectile.frameCounter > 16.0)
        {
            projectile.frame.Y = projectile.frame.Y + frameHeight;
            projectile.frameCounter = 0.0;
        }
        if (projectile.frame.Y >= frameHeight * 4)
        {
            projectile.frame.Y = 0;
        }
    }
    else
    {
        if (projectile.frameCounter > 8.0)
        {
            projectile.frame.Y = projectile.frame.Y + frameHeight;
            projectile.frameCounter = 0.0;
        }
        if (projectile.frame.Y < frameHeight * 4)
        {
            projectile.frame.Y = frameHeight * 4;
        }
        if (projectile.frame.Y >= frameHeight * 8)
        {
        projectile.frame.Y = frameHeight * 4;
        }
    }}*/