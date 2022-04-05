using CalValEX.Buffs.LightPets;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.Wulfrum
{
    public class WulfrumHover : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wulfrum Hovercraft");
            Main.projFrames[Projectile.type] = 8; //frames
            Main.projPet[Projectile.type] = true;
        }

        public override void SafeSetDefaults() //SafeSetDefaults!!!
        {
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.ignoreWater = true;
            /* you don't need to set these anymore!
            Projectile.penetrate = -1;
            Projectile.netImportant = true;
            Projectile.timeLeft *= 5;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
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
            speed = 16f;
            inertia = 60f;
            animationSpeed = 12; //how fast the animation should play
            spinRotationSpeedMult = 0.2f; //rotation speed multiplier, keep it positive for it to spin in the right direction
            offSetX = 48f * -Main.player[Projectile.owner].direction; //this is needed so it's always behind the player.
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
                Projectile.timeLeft = 2;
            if (player.HasBuff(ModContent.BuffType<PylonBuff>()))
            {
                if (Projectile.frameCounter++ > 8)
                {
                    Projectile.frameCounter = 0;
                    Projectile.frame++;
                    if (Projectile.frame >= 8)
                        Projectile.frame = 4;
                }
            }
            else if (!player.HasBuff(ModContent.BuffType<PylonBuff>()))
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
    }
}

/* THIS CODE ONLY RUNS AFTER THE MAIN CODE RAN.
 * for custom behaviour, you can check if the projectile is walking or not via Projectile.localAI[1]
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