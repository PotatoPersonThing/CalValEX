using CalValEX.Buffs.LightPets;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.Wulfrum
{
    public class WulfrumDrone : FlyingPet
    {
        public Player Owner => Main.player[projectile.owner];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wulfrum Drone");
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
            facingLeft = true; //is the sprite facing left? if so, put this to true. if its facing to right keep it false.
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
            speed = Owner.GetModPlayer<CalValEXPlayer>().DustChime ? 13f : 12f;
            inertia = 60f;
            animationSpeed = 12; //how fast the animation should play
            spinRotationSpeedMult = 0.2f; //rotation speed multiplier, keep it positive for it to spin in the right direction
            offSetX = 48f * -Main.player[projectile.owner].direction; //this is needed so it's always behind the player.
            offSetY = -50f; //how much higher from the center the pet should float
        }

        //you usualy don't have to use the lower two unless you want the pet to have an aura, glowmask
        //or if you want the pet to emit light

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.drone = false;
            if (modPlayer.drone)
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