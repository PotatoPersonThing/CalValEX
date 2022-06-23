using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.IO;

namespace CalValEX.Projectiles.Pets
{
    public class Sirember : FlyingPet
    {
        Mod orthoceraDLC = ModLoader.GetMod("CalValPlus");

        public bool orthod = false;
        public bool theterror = false;
        public bool entropy = false;

        int apocalypse = 0;
        int time1 = 23600;
        int time2 = 24260;

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
            usesGlowmask = true; //does this pet use a glowmask?
            auraUsesGlowmask = false; //does the aura use a glowmask?
        }
        public override void SetUpAuraAndGlowmask()
        {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.bossded > 0 && !entropy)
            {
                projectile.alpha = 255;
                glowmaskTexture = "Projectiles/Pets/Siretrum";
            }
            else if (entropy)
            {
                glowmaskTexture = "Items/Equips/Shields/Invishield_Shield";
                projectile.alpha = 255;
            }
            else
            {
                projectile.alpha = 0;
                glowmaskTexture = "Items/Equips/Shields/Invishield_Shield";
            }
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

            if (orthoceraDLC != null)
            {
                time1 = 600;
                time2 = 1260;
            }
            else
            {
                time1 = 23600;
                time2 = 24260;
            }

            apocalypse++;

            if (apocalypse >= time1 && apocalypse < time2)
            {
                if (!entropy)
                {
                    entropy = true;
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/ReaperEnragedRoar"));
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ModContent.ProjectileType<SiremberSpook>(), 0, 0, projectile.owner, 0);
                    projectile.alpha = 255;
                }

            }
            if (apocalypse >= time2)
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
            //Test version with smaller times
            /*apocalypse++;

            if (apocalypse >= 600 && apocalypse < 1260)
            {
                if (!entropy)
                {
                    entropy = true;
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/ReaperEnragedRoar"));
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ModContent.ProjectileType<SiremberSpook>(), 0, 0, projectile.owner, 0);
                    projectile.alpha = 255;
                }

            }
            if (apocalypse >= 1260)
            {
                projectile.alpha = 0;
                for (int x = 0; x < 60; x++)
                {
                    Dust dust;
                    dust = Main.dust[Terraria.Dust.NewDust(projectile.Center, 30, 30, 16, 0f, 0f, 0, new Color(255, 255, 255), 1.644737f)];
                }
                apocalypse = 0;
                entropy = false;
            }*/
        }
        public override void SafeSendExtraAI(BinaryWriter writer)
        {
            writer.Write(orthod);
            writer.Write(theterror);
            writer.Write(entropy);
            writer.Write(apocalypse);
            writer.Write(time1);
            writer.Write(time2);
        }

        public override void SafeReceiveExtraAI(BinaryReader reader)
        {
            time1 = reader.ReadInt32();
            time2 = reader.ReadInt32();
            apocalypse = reader.ReadInt32();
            entropy = reader.ReadBoolean();
            theterror = reader.ReadBoolean();
            orthod = reader.ReadBoolean();
        }
    }
}