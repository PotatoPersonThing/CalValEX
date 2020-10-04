using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class SolarBunny : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Bunny");
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.LightPet[projectile.type] = true;
        }

        public override void SafeSetDefaults() //SafeSetDefaults!!!
        {
            projectile.width = 34;
            projectile.height = 28;
            projectile.ignoreWater = true;
            facingLeft = true;
            spinRotation = false;
            shouldFlip = true;
            usesAura = true;
            usesGlowmask = false;
            auraUsesGlowmask = true;
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = 1840f;
            distance[1] = 560f;
            speed = 12f;
            inertia = 60f;
            animationSpeed = 30;
            spinRotationSpeedMult = 0.2f;
            offSetX = 48f * -Main.player[projectile.owner].direction;
            offSetY = -50f;
        }

        public override void SetUpAuraAndGlowmask()
        {
            auraTexture = "Projectiles/Pets/LightPets/SolarBunnyAura";
            auraRotates = true;
            auraRotation = true;
            auraRotationSpeedMult = 0.05f;

            glowmaskTexture = "";
            auraGlowmaskTexture = "Projectiles/Pets/LightPets/SolarBunnyAuraGlow";
        }

        public override void SetUpLight()
        {
            shouldLightUp = true;
            RGB = new Vector3(255, 191, 73);
            intensity = 1.75f;
            abyssLightLevel = 6;
        }

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            //calamityMod.Call("MakeColdImmune", player);

            if (player.dead)
                modPlayer.sBun = false;
            if (modPlayer.sBun)
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
