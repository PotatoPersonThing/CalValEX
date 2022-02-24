using CalamityMod.DataStructures;
using CalValEX.Items.Pets.ExoMechs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static CalamityMod.CalamityUtils;

namespace CalValEX.Projectiles.Pets.ExoMechs
{
    public class ThanatosPet : BaseWormPet
    {
        public override string Texture => "CalValEX/Projectiles/Pets/ExoMechs/ThanatosHead"; 
        public override string HeadTexture() => "CalValEX/Projectiles/Pets/ExoMechs/ThanatosHead";
        public override string BodyTexture() => "CalValEX/Projectiles/Pets/ExoMechs/ThanatosBody";
        public override string TailTexture() => "CalValEX/Projectiles/Pets/ExoMechs/ThanatosTail";

        public override int SegmentSize() => 28;

        public override int SegmentCount() => 20;

        public override bool ExistenceCondition() => ModOwner.thanos;

        public override float GetSpeed() => MathHelper.Lerp(20, 40, MathHelper.Clamp(projectile.Distance(IdealPosition) / (WanderDistance * 2.2f) - 1f, 0, 1));

        public override int BodyVariants => 2;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Toy Thanatos");
            Main.projFrames[projectile.type] = 5;
            Main.projPet[projectile.type] = true;
        }

        public override void MoveTowardsIdealPosition()
        {
            //THIS CODE NEEDS CALAMITY 1.5.1.001 STUFF TO WORK PROPERLY!

            //If the owner is holding right click, shift its goal from the worms ideal position tothe mouse cursor
            //if (Owner.Calamity().mouseRight && Owner.HeldItem.type == ModContent.ItemType<GunmetalRemote>())
            //    RelativeIdealPosition = Owner.Calamity().mouseWorld - Owner.Center;

            //Rotate towards its ideal position
            projectile.rotation = projectile.rotation.AngleTowards((IdealPosition - projectile.Center).ToRotation(), MathHelper.Lerp(MaximumSteerAngle, MinimumSteerAngle, MathHelper.Clamp(projectile.Distance(IdealPosition) / 80f, 0, 1)));
            projectile.velocity = projectile.rotation.ToRotationVector2() * GetSpeed();

            //Update its segment
            Segments[0].oldPosition = Segments[0].position;
            Segments[0].position = projectile.Center;
        }

        public override void Animate()
        {
            if (Owner.statLife / (float)Owner.statLifeMax > 0.5f && projectile.frame != 0)
            {
                projectile.frameCounter++;
                if (projectile.frameCounter > 6)
                {
                    projectile.frame--;
                    projectile.frameCounter = 0;
                }
            }
            else if (Owner.statLife / (float)Owner.statLifeMax <= 0.5f && projectile.frame != 4)
            {
                projectile.frameCounter++;
                if (projectile.frameCounter > 6)
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;
                }
            }
        }
    }
}