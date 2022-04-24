using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;

namespace CalValEX.Projectiles.Pets
{
    public class Sirember : ModFlyingPet
    {
        public override float TeleportThreshold => 1440f;

        public override Vector2 FlyingOffset => new Vector2(54f * -Main.player[Projectile.owner].direction, -130f);

        //Mod orthoceraDLC = ModLoader.GetMod("CalValPlus");

        public bool orthod = false;
        public bool theterror = false;
        public bool entropy = false;

        int apocalypse = 0;
        int time1 = 23600;
        int time2 = 24260;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Giant Decapitated Floating Siren Head");
            Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 112;
            Projectile.height = 112;
            Projectile.ignoreWater = true;
        }

        public override void PostDraw(Color lightColor)
        {
            string glowmaskTexture;
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.bossded > 0 && !entropy)
            {
                Projectile.alpha = 255;
                glowmaskTexture = "CalValEX/Projectiles/Pets/Siretrum";
            }
            else if (entropy)
            {
                glowmaskTexture = "CalValEX/Items/Equips/Shields/Invishield_Shield";
                Projectile.alpha = 255;
            }
            else
            {
                Projectile.alpha = 0;
                glowmaskTexture = "CalValEX/Items/Equips/Shields/Invishield_Shield";
            }

            SimpleGlowmask(Main.spriteBatch, glowmaskTexture);
        }

        public override void ModifyFlyingValues(ref float flyingSpeed, ref float flyingInertia)
        {
            if (theterror)
            {
                flyingSpeed = 0f;
                flyingInertia = 0f;
            }
        }

        public override void Animation(int state)
        {
            if (!theterror)
            {
                SimpleAnimation(speed: 7);
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.sirember = false;

            if (modPlayer.sirember)
                Projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            /*if (orthoceraDLC != null)
            {
                time1 = 600;
                time2 = 1260;
            }
            else
            {*/
                time1 = 23600;
                time2 = 24260;
            //}

            apocalypse++;

            if (apocalypse >= time1 && apocalypse < time2)
            {
                if (!entropy)
                {
                    entropy = true;
                    SoundEngine.PlaySound(SoundLoader.GetLegacySoundSlot(Mod, "Sounds/ReaperEnragedRoar"));
                    Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), 0, 0, ModContent.ProjectileType<SiremberSpook>(), 0, 0, Projectile.owner, 0);
                    Projectile.alpha = 255;
                }

            }
            if (apocalypse >= time2)
            {
                Projectile.alpha = 0;
                for (int x = 0; x < 60; x++)
                {
                    Dust.NewDust(Projectile.Center, 30, 30, 16, 0f, 0f, 0, new Color(255, 255, 255), 1.644737f);
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
                    Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, 0, 0, ModContent.ProjectileType<SiremberSpook>(), 0, 0, Projectile.owner, 0);
                    Projectile.alpha = 255;
                }

            }
            if (apocalypse >= 1260)
            {
                Projectile.alpha = 0;
                for (int x = 0; x < 60; x++)
                {
                    Dust dust;
                    dust = Main.dust[Terraria.Dust.NewDust(Projectile.Center, 30, 30, 16, 0f, 0f, 0, new Color(255, 255, 255), 1.644737f)];
                }
                apocalypse = 0;
                entropy = false;
            }*/
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(orthod);
            writer.Write(theterror);
            writer.Write(entropy);
            writer.Write(apocalypse);
            writer.Write(time1);
            writer.Write(time2);
            base.SendExtraAI(writer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            time1 = reader.ReadInt32();
            time2 = reader.ReadInt32();
            apocalypse = reader.ReadInt32();
            entropy = reader.ReadBoolean();
            theterror = reader.ReadBoolean();
            orthod = reader.ReadBoolean();
            base.ReceiveExtraAI(reader);
        }
    }
}