using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;
using static Terraria.Projectile;
using System.IO;
using CalamityMod.Projectiles.BaseProjectiles;

namespace CalValEX.AprilFools.Jharim
{
    public class JharimLaser : BaseLaserbeamProjectile //I can't believe Jharim would use a base projectile from Calamity, literal thievery! ban!!!!
    {
        float laserscale = 1f;
        bool playedsound = false;
        public override string Texture => "CalValEX/Items/Equips/Shields/Invishield_Shield";

        public override float MaxScale => laserscale;
        public override float MaxLaserLength => 1400f;
        public override float Lifetime => 240f;
        public override Color LaserOverlayColor => Color.White;
        public override Color LightCastColor => LaserOverlayColor;
        public override Texture2D LaserBeginTexture => ModContent.GetTexture("CalValEX/AprilFools/Jharim/JharimLaserStart");
        public override Texture2D LaserMiddleTexture => ModContent.GetTexture("CalValEX/AprilFools/Jharim/JharimLaserMiddle");
        public override Texture2D LaserEndTexture => ModContent.GetTexture("CalValEX/AprilFools/Jharim/JharimLaserEnd");
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jharim Buster");
            Main.projFrames[projectile.type] = 5;
        }
        public override void SetDefaults()
        {
            projectile.width = projectile.height = 80;
            projectile.penetrate = -1;
            //projectile.alpha = 100;
            projectile.tileCollide = false;
            projectile.friendly = true;
            projectile.npcProj = true;
        }
        public override bool PreAI()
        {
            //If Jharim dies during the laser, kill it
            if (!NPC.AnyNPCs(ModContent.NPCType<Jharim>()))
            {
                projectile.active = false;
            }
            //Theres definitely a better way to do this but im lazy
            if (!playedsound)
            {
                Main.PlaySound(Terraria.ID.SoundID.Zombie, (int)projectile.Center.X, (int)projectile.Center.Y, 104);
                playedsound = true;
            }
            return true;
        }

        //Animeme
        public override void PostAI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter % 5f == 0f)
                projectile.frame = (projectile.frame + 1) % Main.projFrames[projectile.type];
        }
        public override bool ShouldUpdatePosition() => false;

        //When do we get an animated laser field tbh
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            //Textures and variables
            Rectangle beginsquare = LaserBeginTexture.Frame(1, Main.projFrames[projectile.type], 0, projectile.frame);
            Rectangle middlesquare = LaserMiddleTexture.Frame(1, Main.projFrames[projectile.type], 0, projectile.frame);
            Rectangle endsquare = LaserEndTexture.Frame(1, Main.projFrames[projectile.type], 0, projectile.frame);
            float lenghtofmidlaser = LaserLength + middlesquare.Height;
            Vector2 centerr = projectile.Center;

            //The beginning...
            spriteBatch.Draw(LaserBeginTexture, projectile.Center - Main.screenPosition, beginsquare, LaserOverlayColor, projectile.rotation, LaserBeginTexture.Size() / 2f, projectile.scale, SpriteEffects.None, 0f);
            //The middle!
            if (lenghtofmidlaser > 0f)
            {
                //Size variables
                float laserOffset = middlesquare.Height * projectile.scale;
                float incrementalBodyLength = 0f;
                //Draw textures until the end of the laser
                while (incrementalBodyLength + 1f < lenghtofmidlaser - laserOffset)
                {
                    //The middle (for real)
                    spriteBatch.Draw(LaserMiddleTexture, centerr - Main.screenPosition, middlesquare, LaserOverlayColor, projectile.rotation, LaserMiddleTexture.Size() * 0.5f, projectile.scale, SpriteEffects.None, 0f);
                    //Prepare for the next laser segment (woo)
                    incrementalBodyLength += laserOffset;
                    centerr += projectile.velocity * laserOffset;
                    middlesquare.Y += LaserMiddleTexture.Height / Main.projFrames[projectile.type];
                    if (middlesquare.Y + middlesquare.Height > LaserMiddleTexture.Height)
                    {
                        middlesquare.Y = 0;
                    }
                }
            }
            //The end.
            spriteBatch.Draw(LaserEndTexture, centerr - Main.screenPosition, endsquare, LaserOverlayColor, projectile.rotation, LaserEndTexture.Size() / 2f, projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
        //Shitcode
        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(playedsound);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            playedsound = reader.ReadBoolean();
        }

        public override bool? CanHitNPC(NPC target)
        {
            if (target.type == ModContent.NPCType<CalamityMod.NPCs.TownNPCs.WITCH>())
            {
                return true;
            }
            return null;
        }

        public override bool CanHitPlayer(Player target)
        {
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (target.type == ModContent.NPCType<CalamityMod.NPCs.TownNPCs.WITCH>() && target.life <= 0)
            {
                CalValEXWorld.jharinter = true;
            }
        }
    }
}