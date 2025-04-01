using Microsoft.Xna.Framework;
using System.Drawing;
using System;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    public class Jared : BaseWormPet
    {
        public override string Texture => "CalValEX/Projectiles/Pets/JaredHead";
        public override WormPetVisualSegment HeadSegment() => new("CalValEX/Projectiles/Pets/JaredHead", true);
        public override WormPetVisualSegment BodySegment() => new("CalValEX/Projectiles/Pets/JaredBodyFull", true, 2);
        public override WormPetVisualSegment TailSegment() => new("CalValEX/Projectiles/Pets/JaredTail", true);

        public override int SegmentSize() => 48;

        public override int SegmentCount() => 14;

        public override bool ExistenceCondition() => ModOwner.jared;

        public override float GetSpeed => 22;

        public override int BodyVariants => 2;
        public override float BashHeadIn => 5;

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
            Main.projPet[Projectile.type] = true;
        }

        public override void MoveTowardsIdealPosition()
        {
            Segments[0].oldPosition = Segments[0].position;
            Segments[0].position = Projectile.Center;
        }

        public override void CustomAI() => OldWormMovement();
    }
}