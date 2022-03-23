using CalValEX.Buffs.LightPets;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.Wulfrum
{
    public class WulfrumHover : FlyingPet
    {
        public Player Owner => Main.player[projectile.owner];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wulfrum Hovercraft");
            Main.projFrames[projectile.type] = 8; //frames
            Main.projPet[projectile.type] = true;
        }

        public override void SafeSetDefaults() //SafeSetDefaults!!!
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.ignoreWater = true;
            /* you don't need to set these anymore!
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
            projectile.tileCollide = false;
            */
            facingLeft = false; ; //is the sprite facing left? if so, put this to true. if its facing to right keep it false.
            spinRotation = false; //should it spin? if that's the case, set to true. else, leave it false.
            shouldFlip = true; //should the sprite flip? set true if it should, false if it shouldnt
            usesAura = false; //does this pet use an aura?
            usesGlowmask = false; //does this pet use a glowmask?
            auraUsesGlowmask = false; //does the aura use a glowmask?
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = 1440f; //teleport distance
            distance[1] = 560f; //faster speed distance
            speed = Owner.GetModPlayer<CalValEXPlayer>().AlarmClock ? 12f : 16f;
            inertia = 60f;
            animationSpeed = 12; //how fast the animation should play
            spinRotationSpeedMult = 0.2f; //rotation speed multiplier, keep it positive for it to spin in the right direction
            offSetX = 48f * -Main.player[projectile.owner].direction; //this is needed so it's always behind the player.
            offSetY = -90f; //how much higher from the center the pet should float
        }

        //you usualy don't have to use the lower two unless you want the pet to have an aura, glowmask
        //or if you want the pet to emit light

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.hover = false;
            if (modPlayer.hover)
                projectile.timeLeft = 2;
            if (player.HasBuff(ModContent.BuffType<PylonBuff>()))
            {
                if (projectile.frameCounter++ > 8)
                {
                    projectile.frameCounter = 0;
                    projectile.frame++;
                    if (projectile.frame >= 8)
                        projectile.frame = 4;
                }
            }
            else if (!player.HasBuff(ModContent.BuffType<PylonBuff>()))
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