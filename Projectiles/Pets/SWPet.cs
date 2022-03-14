using CalamityMod.DataStructures;
using CalValEX.Items.Pets.ExoMechs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static CalamityMod.CalamityUtils;

namespace CalValEX.Projectiles.Pets
{
    public class SWPet : BaseWormPet
    {
        public override string Texture => "CalValEX/Projectiles/Pets/SWPetHead";
        public override string HeadTexture() => "CalValEX/Projectiles/Pets/SWPetHead";
        public override string BodyTexture() => "CalValEX/Projectiles/Pets/SWPetBody";
        public override string TailTexture() => "CalValEX/Projectiles/Pets/SWPetTail";

        public override int SegmentSize() => 12;

        public override int SegmentCount() => 16;

        public override bool ExistenceCondition() => ModOwner.SWPet;

        public override float GetSpeed => MathHelper.Lerp(10, 20, MathHelper.Clamp(projectile.Distance(IdealPosition) / (WanderDistance * 2.2f) - 1f, 0, 1));

        public override int BodyVariants => 1;
        public override float BashHeadIn => 5;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lil Weaver");
            Main.projFrames[projectile.type] = 1;
            Main.projPet[projectile.type] = true;
        }

        public override void MoveTowardsIdealPosition()
        {
            //Rotate towards its ideal position
            projectile.rotation = projectile.rotation.AngleTowards((IdealPosition - projectile.Center).ToRotation(), MathHelper.Lerp(MaximumSteerAngle, MinimumSteerAngle, MathHelper.Clamp(projectile.Distance(IdealPosition) / 80f, 0, 1)));
            projectile.velocity = projectile.rotation.ToRotationVector2() * GetSpeed;

            //Update its segment
            Segments[0].oldPosition = Segments[0].position;
            Segments[0].position = projectile.Center;
        }
    }
}