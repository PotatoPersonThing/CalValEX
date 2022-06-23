using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class PolterChan : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Polter-Chan");
            Main.projFrames[projectile.type] = 8; //frames
            Main.projPet[projectile.type] = true;
        }

        Mod calamityMod = ModLoader.GetMod("CalamityMod");
        //if ((bool)calamityMod.Call("DifficultyActive", "armageddon") && (bool)calamityMod.Call("DifficultyActive", "death") && (bool)calamityMod.Call("DifficultyActive", "ironheart"))

        public override void SafeSetDefaults() //SafeSetDefaults!!!
        {
            projectile.width = 82;
            projectile.height = 64;
            projectile.ignoreWater = true;
            /* you don't need to set these anymore!
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
            projectile.tileCollide = false;
            */
            facingLeft = false; //is the sprite facing left? if so, put this to true. if its facing to right keep it false.
            spinRotation = false; //should it spin? if that's the case, set to true. else, leave it false.
            shouldFlip = true; //should the sprite flip? set true if it should, false if it shouldnt
            usesAura = false; //does this pet use an aura?
            usesGlowmask = true; //does this pet use a glowmask?
            auraUsesGlowmask = false; //does the aura use a glowmask?
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = 1440f; //teleport distance
            distance[1] = 560f; //faster speed distance
            speed = 12f;
            inertia = 60f;
            animationSpeed = 12; //how fast the animation should play
            spinRotationSpeedMult = 0.2f; //rotation speed multiplier, keep it positive for it to spin in the right direction
            offSetX = 68f * -Main.player[projectile.owner].direction; //this is needed so it's always behind the player.
            offSetY = -50f; //how much higher from the center the pet should float
        }

        public override void SetUpAuraAndGlowmask()
        {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            glowmaskTexture = (modPlayer.signutTrans || modPlayer.signutForce) && !CalValEXConfig.Instance.Polterskin ? "Projectiles/Pets/EvilPolterChan_Glow" : "Projectiles/Pets/PolterChan_Glow";
        }

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            Mod master = ModLoader.GetMod("MasterMode");
            Mod armasortof = ModLoader.GetMod("EfficientNohits");
            Mod infernum = ModLoader.GetMod("InfernumMode");
            Mod cplus = ModLoader.GetMod("CalValPlus");

            if (player.dead)
                modPlayer.mChan = false;
            if (modPlayer.mChan)
                projectile.timeLeft = 2;
            //MAID mode
            if (!CalValEXConfig.Instance.Polterskin && ((master != null && (bool)calamityMod.Call("DifficultyActive", "death") && (infernum != null && (bool)infernum.Call("GetInfernumActive")) && (armasortof != null && (bool)armasortof.Call("GetModifier", "instantdeathalways"))) || cplus != null))
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
    }
}