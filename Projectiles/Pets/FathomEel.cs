using System.Collections.Generic;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class FathomEel : BaseWormPet
    {
        public override string Texture => "CalValEX/Projectiles/Pets/FathomEelHead";
        public override WormPetVisualSegment HeadSegment() => new("CalValEX/Projectiles/Pets/FathomEelHead", true);
        public override WormPetVisualSegment BodySegment() => new("CalValEX/Projectiles/Pets/FathomEelBody");
        public override WormPetVisualSegment TailSegment() => new("CalValEX/Projectiles/Pets/FathomEelTail");

        public override Dictionary<string, WormPetVisualSegment> CustomSegments => new Dictionary<string, WormPetVisualSegment>()
        {
            { "Arms1", new("CalValEX/Projectiles/Pets/FathomEelArms") },
            { "Arms2", new("CalValEX/Projectiles/Pets/FathomEelArms2") },
            { "Body2", new("CalValEX/Projectiles/Pets/FathomEelBody2") },
            { "Body3", new("CalValEX/Projectiles/Pets/FathomEelBody3") },
        };

        public override string[] TextureProgression => ["Arms1", "Body", "Arms2", "Body2", "Body3"];

        public override int SegmentSize() => 16;

        public override int SegmentCount() => 7;

        public override bool ExistenceCondition() => ModOwner.feel;

        public override float GetSpeed => MathHelper.Lerp(10, 20, MathHelper.Clamp(Projectile.Distance(IdealPosition) / (WanderDistance * 2.2f) - 1f, 0, 1));

        public override int BodyVariants => 1;
        public override float BashHeadIn => 5;

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 1;
            Main.projPet[Projectile.type] = true;
        }

        public override void MoveTowardsIdealPosition() => OldWormMovement();

        public override void DrawWorm(Color lightColor, bool glow = false)
        {
            base.DrawWorm(lightColor, glow);
        }
    }
}