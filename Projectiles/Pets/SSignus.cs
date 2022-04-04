using Microsoft.Xna.Framework;
using Terraria;
using System.IO;

namespace CalValEX.Projectiles.Pets
{
    public class SSignus : FlyingPet
    {
        private bool sigtep = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mini Signus");
            Main.projFrames[Projectile.type] = 4; //frames
            Main.projPet[Projectile.type] = true;
        }

        public override void SafeSetDefaults() //SafeSetDefaults!!!
        {
            Projectile.width = 36;
            Projectile.height = 48;
            Projectile.ignoreWater = true;
            /* you don't need to set these anymore!
            Projectile.penetrate = -1;
            Projectile.netImportant = true;
            Projectile.timeLeft *= 5;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            */
            facingLeft = true; //is the sprite facing left? if so, put this to true. if its facing to right keep it false.
            spinRotation = false; //should it spin? if that's the case, set to true. else, leave it false.
            shouldFlip = true; //should the sprite flip? set true if it should, false if it shouldnt
            usesAura = false; //does this pet use an aura?
            usesGlowmask = true; //does this pet use a glowmask?
            auraUsesGlowmask = false; //does the aura use a glowmask?
        }
        public override void SetUpAuraAndGlowmask()
        {
            glowmaskTexture = "CalValEX/Projectiles/Pets/SSignus_Glow";
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = 1440f; //teleport distance
            distance[1] = 560f; //faster speed distance
            speed = 12f;
            inertia = 60f;
            animationSpeed = 12; //how fast the animation should play
            spinRotationSpeedMult = 0.2f; //rotation speed multiplier, keep it positive for it to spin in the right direction
            offSetX = 90f * -Main.player[Projectile.owner].direction; //this is needed so it's always behind the player.
            offSetY = -75f; //how much higher from the center the pet should float
        }

        //you usualy don't have to use the lower two unless you want the pet to have an aura, glowmask
        //or if you want the pet to emit light

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.sSignus = false;
            if (modPlayer.sSignus)
                Projectile.timeLeft = 2;

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
            Player owner = Main.player[Projectile.owner];
            Vector2 vectorToOwner = owner.Center - Projectile.Center;
            float distanceToOwner = vectorToOwner.Length();
            if (distanceToOwner > 1138)
            {
                sigtep = true;
            }
            if (distanceToOwner < 1139)
            {
                sigtep = false;
                Projectile.alpha--;
                Projectile.alpha--;
            }

            if (Projectile.alpha == 45)
            {
                for (int x = 0; x < 20; x++)
                {
                    Dust dust;
                    dust = Main.dust[Terraria.Dust.NewDust(Projectile.Center, 30, 30, 173, 0f, 0f, 0, new Color(255, 255, 255), 0.8f)];
                }
            }

            if (sigtep == true)
            {
                Projectile.alpha = 255;
                for (int x = 0; x < 5; x++)
                {
                    Dust dust;
                    dust = Main.dust[Terraria.Dust.NewDust(Projectile.Center, 30, 30, 173, 0f, 0f, 0, new Color(255, 255, 255), 0.8f)];
                }
            }
        }

        public override void SafeSendExtraAI(BinaryWriter writer)
        {
            writer.Write(sigtep);
        }

        public override void SafeReceiveExtraAI(BinaryReader reader)
        {
            sigtep = reader.ReadBoolean();
        }
    }
}