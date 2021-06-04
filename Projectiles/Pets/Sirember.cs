using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace CalValEX.Projectiles.Pets
{
    public class Sirember : FlyingPet
    {
        private bool theterror = false;

        int apocalypse = 0;
        int countdown = 0;
        public bool entropy = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Giant Decapitated Floating Siren Head");
            Main.projFrames[projectile.type] = 6; //frames
            Main.projPet[projectile.type] = true;
        }

        public override void SafeSetDefaults() //SafeSetDefaults!!!
        {
            projectile.width = 112;
            projectile.height = 112;
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
            shouldFlip = false; //should the sprite flip? set true if it should, false if it shouldnt
            usesAura = false; //does this pet use an aura?
            usesGlowmask = false; //does this pet use a glowmask?
            auraUsesGlowmask = false; //does the aura use a glowmask?
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = 1200f; //teleport distance
            distance[1] = 560f; //faster speed distance
            speed = (theterror? 0 : 12f);
            inertia = (theterror? 0: 60f);
            animationSpeed = (theterror ? 0 : 7); //how fast the animation should play
            spinRotationSpeedMult = 0.2f; //rotation speed multiplier, keep it positive for it to spin in the right direction
            offSetX = 54f * -Main.player[projectile.owner].direction; //this is needed so it's always behind the player.
            offSetY = -130f; //how much higher from the center the pet should float
        }

        //you usualy don't have to use the lower two unless you want the pet to have an aura, glowmask
        //or if you want the pet to emit light

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.sirember = false;
            if (modPlayer.sirember)
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
            /*countdown++;
            if (!theterror)
            {
                if (countdown == 60)
                {
                    theterror = true;
                    countdown = 666;
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, ModContent.ProjectileType<SiremberSpook>(), 0, 0, projectile.owner, 0);
                }
            }
            if (theterror)
            {
                for (int j = 0; j < 1; j++)
                {
                    theterror = true;
                    projectile.frame = 0;
                    projectile.rotation = 0;
                    //projectile.position = projectile.position;
                }
                apocalypse++;
                if (apocalypse == 660)
                {
                    theterror = false;
                    countdown = 0;
                    apocalypse = -1;
                }
                else if (apocalypse == 300)
                {
                    player.AddBuff(BuffID.Blackout, 360);
                }
            }*/
            apocalypse++;

            if (apocalypse >= 23600 && apocalypse < 24260)
            {
                if (!entropy)
                {
                    entropy = true;
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/ReaperEnragedRoar"));
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ModContent.ProjectileType<SiremberSpook>(), 0, 0, projectile.owner, 0);
                    projectile.alpha = 255;
                }

            }
            if (apocalypse >= 24260)
            {
                projectile.alpha = 0;
                for (int x = 0; x < 60; x++)
                {
                    Dust dust;
                    dust = Main.dust[Terraria.Dust.NewDust(projectile.Center, 30, 30, 16, 0f, 0f, 0, new Color(255, 255, 255), 1.644737f)];
                }
                apocalypse = 0;
                entropy = false;
            }
        }
    }
}