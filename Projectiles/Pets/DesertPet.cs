using Microsoft.Xna.Framework;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class DesertPet : BaseWormPet
    {
        public override string Texture => "CalValEX/Projectiles/Pets/DesertHead";
        public override WormPetVisualSegment HeadSegment() => new("CalValEX/Projectiles/Pets/DesertHead");
        public override WormPetVisualSegment BodySegment() => new("CalValEX/Projectiles/Pets/DesertBody");
        public override WormPetVisualSegment TailSegment() => new("CalValEX/Projectiles/Pets/DesertTail");

        public override int SegmentSize() => 10;

        public override int SegmentCount() => 10;

        public override bool ExistenceCondition() => ModOwner.dsPet;

        public override float GetSpeed => MathHelper.Lerp(10, 20, MathHelper.Clamp(Projectile.Distance(IdealPosition) / (WanderDistance * 2.2f) - 1f, 0, 1));

        public override int BodyVariants => 1;
        public override float BashHeadIn => 5;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Desert Pest");
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