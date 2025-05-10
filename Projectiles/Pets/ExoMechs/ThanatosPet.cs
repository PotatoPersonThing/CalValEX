using CalValEX.Items.Pets.ExoMechs;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.ExoMechs
{
    public class ThanatosPet : BaseWormPet
    {
        public override string Texture => "CalValEX/Projectiles/Pets/ExoMechs/ThanatosHead"; 
        public override WormPetVisualSegment HeadSegment() => new("CalValEX/Projectiles/Pets/ExoMechs/ThanatosHead", true, 1, 5);
        public override WormPetVisualSegment BodySegment() => new("CalValEX/Projectiles/Pets/ExoMechs/ThanatosBody", true, 2, 5);
        public override WormPetVisualSegment TailSegment() => new("CalValEX/Projectiles/Pets/ExoMechs/ThanatosTail", true, 1, 5);

        public override int SegmentSize() => 28;

        public override int SegmentCount() => 20;

        public override bool ExistenceCondition() => ModOwner.thanos;

        public override float GetSpeed => MathHelper.Lerp(17, 40, MathHelper.Clamp(Projectile.Distance(IdealPosition) / (WanderDistance * 2.2f) - 1f, 0, 1));

        public override int BodyVariants => 2;
        public override float BashHeadIn => 5;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Toy Thanatos");
            Main.projFrames[Projectile.type] = 5;
            Main.projPet[Projectile.type] = true;
        }

        public override void MoveTowardsIdealPosition()
        {
            //If the owner is holding right click, shift its goal from the worms ideal position tothe mouse cursor
            if (CalValEX.CalamityActive)
            {
                if ((bool)CalValEX.Calamity.Call("GetRightClick", Owner) && Owner.HeldItem.type == ModContent.ItemType<GunmetalRemote>())
                    RelativeIdealPosition = (Vector2)CalValEX.Calamity.Call("GetMouseWorld", Owner) - Owner.Center;
            }

            //Rotate towards its ideal position
            Projectile.rotation = Projectile.rotation.AngleTowards((IdealPosition - Projectile.Center).ToRotation(), MathHelper.Lerp(MaximumSteerAngle, MinimumSteerAngle, MathHelper.Clamp(Projectile.Distance(IdealPosition) / 80f, 0, 1)));
            Projectile.velocity = Projectile.rotation.ToRotationVector2() * GetSpeed;

            //Update its segment
            Segments[0].oldPosition = Segments[0].position;
            Segments[0].position = Projectile.Center;
        }

        public override void Animate()
        {
            foreach (WormPetSegment segment in Segments)
            {
                if (Owner.statLife / (float)Owner.statLifeMax > 0.5f && segment.visual.Frame != 0)
                {
                    segment.visual.FrameCounter++;
                    if (segment.visual.FrameCounter > segment.visual.FrameDuration)
                    {
                        segment.visual.Frame--;
                        segment.visual.FrameCounter = 0;
                    }
                }
                else if (Owner.statLife / (float)Owner.statLifeMax <= 0.5f && segment.visual.Frame != segment.visual.FrameCount - 1)
                {
                    segment.visual.FrameCounter++;
                    if (segment.visual.FrameCounter > segment.visual.FrameDuration)
                    {
                        segment.visual.Frame++;
                        segment.visual.FrameCounter = 0;
                    }
                }
            }
        }
    }
}