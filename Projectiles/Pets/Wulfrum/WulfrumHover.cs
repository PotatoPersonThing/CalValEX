using CalValEX.Buffs.LightPets;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.Wulfrum
{
    public class WulfrumHover : ModFlyingPet
    {
        public override bool FacesLeft => false;

        public override float TeleportThreshold => 1440f;

        public override float FlyingSpeed => 16f;

        public override Vector2 FlyingOffset => new(48 * -Main.player[Projectile.owner].direction, -90f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            // DisplayName.SetDefault("Wulfrum Hovercraft");
            Main.projFrames[Projectile.type] = 8;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.ignoreWater = true;
        }

        public override void Animation(int state)
        {
            if (Main.player[Projectile.owner].HasBuff(ModContent.BuffType<PylonBuff>()))
            {
                if (Projectile.frameCounter++ > 8)
                {
                    Projectile.frameCounter = 0;
                    Projectile.frame++;
                    if (Projectile.frame >= 8)
                        Projectile.frame = 4;
                }
            }
            else
            {
                if (Projectile.frameCounter++ % 8 == 7)
                {
                    Projectile.frame++;
                }
                if (Projectile.frame >= 4)
                {
                    Projectile.frame = 0;
                }
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.hover = false;

            if (modPlayer.hover)
                Projectile.timeLeft = 2;
        }
    }
}

/* THIS CODE ONLY RUNS AFTER THE MAIN CODE RAN.
 * for custom behaviour, you can check if the Projectile is walking or not via Projectile.localAI[1]
 * you should make new custom behaviour with numbers higher than 0, or less than 0
 * the next few lines is an example on how to implement this
 *
 * switch ((int)Projectile.localAI[1])
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
Main.ProjectileTexture[ModContent.BuffType<WulfrumHover>()] = Modcontent.GetTexture("CalValEX/Projectiles/Pets/Wulfrum/WulfrumHoverCharge");
}
else
{
Main.ProjectileTexture[ModContent.BuffType<WulfrumHover>()] = Modcontent.GetTexture("CalValEX/Projectiles/Pets/Wulfrum/WulfrumHover");
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
 Projectile.frameCounter += 1.0;
    if (player.pylon)
    {
        if (Projectile.frameCounter > 16.0)
        {
            Projectile.frame.Y = Projectile.frame.Y + frameHeight;
            Projectile.frameCounter = 0.0;
        }
        if (Projectile.frame.Y >= frameHeight * 4)
        {
            Projectile.frame.Y = 0;
        }
    }
    else
    {
        if (Projectile.frameCounter > 8.0)
        {
            Projectile.frame.Y = Projectile.frame.Y + frameHeight;
            Projectile.frameCounter = 0.0;
        }
        if (Projectile.frame.Y < frameHeight * 4)
        {
            Projectile.frame.Y = frameHeight * 4;
        }
        if (Projectile.frame.Y >= frameHeight * 8)
        {
        Projectile.frame.Y = frameHeight * 4;
        }
    }}*/