
using CalValEX.Items.Pets.ExoMechs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class Sepulchling : BaseWormPet
    {
        public override string Texture => "CalValEX/Projectiles/Pets/SepulcherHead";
        public override WormPetVisualSegment HeadSegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/SepulcherHead");
        public override WormPetVisualSegment BodySegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/SepulcherBody");
        public override WormPetVisualSegment TailSegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/SepulcherTail");

        public override int SegmentSize() => 25;

        public override int SegmentCount() => 8;

        public override bool ExistenceCondition() => ModOwner.sepet;

        public override float GetSpeed => MathHelper.Lerp(10, 20, MathHelper.Clamp(Projectile.Distance(IdealPosition) / (WanderDistance * 2.2f) - 1f, 0, 1));

        public override int BodyVariants => 1;
        public override float BashHeadIn => 5;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rotting Sepulchling");
            Main.projFrames[Projectile.type] = 1;
            Main.projPet[Projectile.type] = true;
        }

        public override void MoveTowardsIdealPosition()
        {
            //Rotate towards its ideal position
            Projectile.rotation = Projectile.rotation.AngleTowards((IdealPosition - Projectile.Center).ToRotation(), MathHelper.Lerp(MaximumSteerAngle, MinimumSteerAngle, MathHelper.Clamp(Projectile.Distance(IdealPosition) / 80f, 0, 1)));
            Projectile.velocity = Projectile.rotation.ToRotationVector2() * GetSpeed;

            //Update its segment
            Segments[0].oldPosition = Segments[0].position;
            Segments[0].position = Projectile.Center;
        }
    }
}