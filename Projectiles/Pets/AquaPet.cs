using CalValEX.Items.Pets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class AquaPet : BaseWormPet
    {
        public override string Texture => "CalValEX/Projectiles/Pets/AquaHead";
        public override WormPetVisualSegment HeadSegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/AquaHead");
        public override WormPetVisualSegment BodySegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/AquaBody");
        public override WormPetVisualSegment TailSegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/AquaTail");

        public override int SegmentSize() => 10;

        public override int SegmentCount() => 10;

        public override bool ExistenceCondition() => ModOwner.asPet;

        public override float GetSpeed => MathHelper.Lerp(10, 20, MathHelper.Clamp(Projectile.Distance(IdealPosition) / (WanderDistance * 2.2f) - 1f, 0, 1));

        public override int BodyVariants => 1;
        public override float BashHeadIn => 5;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Aquatic Pest");
            Main.projFrames[Projectile.type] = 1;
            Main.projPet[Projectile.type] = true;
        }

        public override void UpdateIdealPosition()
        {
            TimeTillReset++;
            if (TimeTillReset > 150)
            {
                RelativeIdealPosition = Vector2.Zero;
                TimeTillReset = 0;
            }
            Dust.NewDustPerfect(RelativeIdealPosition, 267);
            //Reset the ideal position if the ideal position was reached
            if (Projectile.Distance(IdealPosition) < GetSpeed)
                RelativeIdealPosition = Vector2.Zero;
            //Get a new ideal position
            if (RelativeIdealPosition == null || RelativeIdealPosition == Vector2.Zero)
            {
				RelativeIdealPosition = Main.rand.NextVector2CircularEdge(WanderDistance, WanderDistance);
                return;
            }

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

        public override void CustomAI()
        {
            
        }
    }
}