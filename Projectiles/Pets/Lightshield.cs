using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
    {

    public class Lightshield : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arctic Shield");
            Main.projFrames[projectile.type] = 1;
            Main.projPet[projectile.type] = true;
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            return true;
        }

        public override void SafeSetDefaults() //SAFE SET DEFAULTS!!!
        {
            projectile.width = 98;
            projectile.height = 98;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            facingLeft = false; //is the sprite facing left? if so, put this to true. if its facing to right keep it false.
            spinRotation = true; //should it spin? if that's the case, set to true. else, leave it false.
            shouldFlip = false; //should the sprite flip? if that's the case, set to true. else, put it to false.
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = -1f; //teleport distance
            distance[1] = -1f; //faster speed distance
            speed = -1f;
            inertia = -1f;
            animationSpeed = -1; //how fast the animation should play
            spinRotationSpeedMult = 0.35f; //rotation speed multiplier, keep it positive for it to spin in the right direction
            offSetX = projectile.Center.X - Main.screenPosition.X;
            offSetY = projectile.Center.Y - Main.screenPosition.Y;
        }

        public override void SetUpLight() //for when the pet emmits light
        {
            shouldLightUp = true; //should the pet glow? true if it should, false if it shouldn't
            RGB = new Vector3(108, 227, 255); //should only go up to 255 and as low as 0
            intensity = 0.8f; //how intense the light should be. do not go over 2f or else the light will be too strong
            abyssLightLevel = 2; //for abyss light level to work shouldLightUp must be set up true.
        }

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.Lightshield = false;
            if (modPlayer.Lightshield)
                projectile.timeLeft = 2;

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
        }
    }
}