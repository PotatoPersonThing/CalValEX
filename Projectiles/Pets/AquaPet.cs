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
    public class AquaPet : BaseWormPet
    {
        public override string Texture => "CalValEX/Projectiles/Pets/AquaHead";
        public override WormPetVisualSegment HeadSegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/AquaHead");
        public override WormPetVisualSegment BodySegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/AquaBody");
        public override WormPetVisualSegment TailSegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/AquaTail");

        public override int SegmentSize() => 10;

        public override int SegmentCount() => 10;

        public override bool ExistenceCondition() => ModOwner.asPet;

        public override float GetSpeed => MathHelper.Lerp(10, 20, MathHelper.Clamp(projectile.Distance(IdealPosition) / (WanderDistance * 2.2f) - 1f, 0, 1));

        public override int BodyVariants => 1;
        public override float BashHeadIn => 5;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aquatic Pest");
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