using Terraria;

namespace CalValEX.Projectiles.Pets.Elementals
{
    public class VanityEarth : FlyingPet
    {
        public override string Texture => "CalamityMod/NPCs/NormalNPCs/Horse";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Passive Rare Sand");
            Main.projFrames[projectile.type] = 6; //frames
            Main.projPet[projectile.type] = true;
        }

        public override void SafeSetDefaults() //SafeSetDefaults!!!
        {
            projectile.width = 230;
            projectile.height = 230;
            projectile.ignoreWater = true;
            facingLeft = true; //is the sprite facing left? if so, put this to true. if its facing to right keep it false.
            spinRotation = false; //should it spin? if that's the case, set to true. else, leave it false.
            shouldFlip = true; //should the sprite flip? set true if it should, false if it shouldnt
            usesAura = false; //does this pet use an aura?
            usesGlowmask = false; //does this pet use a glowmask?
            auraUsesGlowmask = false; //does the aura use a glowmask?
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = 1200f; //teleport distance
            distance[1] = 560f; //faster speed distance
            speed = 12f;
            inertia = 60f;
            animationSpeed = 16; //how fast the animation should play
            spinRotationSpeedMult = 0.2f; //rotation speed multiplier, keep it positive for it to spin in the right direction
            offSetX = -110f; //this is needed so it's always behind the player.
            offSetY = -250f; //how much higher from the center the pet should float
        }

        //you usualy don't have to use the lower two unless you want the pet to have an aura, glowmask
        //or if you want the pet to emit light

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
                projectile.timeLeft = 0;
            if (!modPlayer.vanityhote && !modPlayer.vanityearth)
                projectile.timeLeft = 0;
            if (modPlayer.vanityhote || modPlayer.vanityearth)
                projectile.timeLeft = 2;
            projectile.rotation = 0;
        }
    }
}