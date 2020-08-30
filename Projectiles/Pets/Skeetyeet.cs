using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
    {

    public class Skeetyeet : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sunfish");
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
            projectile.width = 34;
            projectile.height = 16;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            facingLeft = true; //is the sprite facing left? if so, put this to true. if its facing to right keep it false.
            spinRotation = false; //should it spin? if that's the case, set to true. else, leave it false.
            shouldFlip = true; //should the sprite flip? if that's the case, set to true. else, put it to false.
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = 1200f; //teleport distance
            distance[1] = 560f; //faster speed distance
            speed = 50f;
            inertia = 110f;
            animationSpeed = -1; //how fast the animation should play
            spinRotationSpeedMult = 0.2f; //rotation speed multiplier, keep it positive for it to spin in the right direction
            offSetX = 1.5f * Main.player[projectile.owner].direction; //Front of the player now
            offSetY = -7f; //how much higher from the center the pet should float
        }

        public override void SetUpLight() //for when the pet emmits light
        {
            shouldLightUp = true; //should the pet glow? true if it should, false if it shouldn't
            RGB = new Vector3(250, 155, 97); //should only go up to 255 and as low as 0
            intensity = 0.5f; //how intense the light should be. do not go over 2f or else the light will be too strong
            abyssLightLevel = 6; //for abyss light level to work shouldLightUp must be set up true.
        }

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.Skeetyeet = false;
            if (modPlayer.Skeetyeet)
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