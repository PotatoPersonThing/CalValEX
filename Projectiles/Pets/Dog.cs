using Microsoft.Xna.Framework;
using System.Drawing;
using System;
using Terraria;
using System.IO;

namespace CalValEX.Projectiles.Pets
{
    public class Dog : BaseWormPet
    {
        public override string Texture => "CalValEX/Projectiles/Pets/DogHead";

        public const string DogPath = "CalValEX/Projectiles/Pets/Dog";

        public override WormPetVisualSegment HeadSegment() => new(DogPath + (CalValEX.InfernumActive() ? "IHead" : "Head"), true);
        public override WormPetVisualSegment BodySegment() => new(DogPath + (CalValEX.InfernumActive() ? "IBody" : "Body"), true);
        public override WormPetVisualSegment TailSegment() => new(DogPath + (CalValEX.InfernumActive() ? "ITail" : "Tail"), true);

        public override int SegmentSize() => 68;

        public override int SegmentCount() => CalValEXConfig.Instance.FatDog ? 100 : 26;

        public override bool ExistenceCondition() => ModOwner.voreworm;

        public override float GetSpeed => 22;
        public override float BashHeadIn => 5;

        public override void SetStaticDefaults()
        {
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