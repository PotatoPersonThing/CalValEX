using CalamityMod.DataStructures;
using CalValEX.Items.Pets.ExoMechs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static CalamityMod.CalamityUtils;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class DiggerPet : BaseWormPet
    {
        public override string Texture => "CalValEX/Projectiles/Pets/LightPets/DiggerHead"; 
        public override WormPetVisualSegment HeadSegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/LightPets/DiggerHead", true, 1, 1);
        public override WormPetVisualSegment BodySegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/LightPets/DiggerSegment", true, 1, 1);
        public override WormPetVisualSegment TailSegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/LightPets/DiggerTail", true, 1, 1);
        public override string ArmTexture => "CalValEX/Projectiles/Pets/LightPets/DiggerArm";
        public override string ForearmTexture => "CalValEX/Projectiles/Pets/LightPets/DiggerForearm";
        public override string HandTexture => "CalValEX/Projectiles/Pets/LightPets/DiggerClaw";

        public override int SegmentSize() => 26;

        public override int SegmentCount() => ModOwner.RepairBot ? 24 : 9;

        public override bool ExistenceCondition() => ModOwner.digger;
        public override Color lightcolor => Color.Orange;
        public override int abyssLightLevel => 3;
        public override float GlowmaskOpacity => ModOwner.RepairBot ? 2 : 0.6f;
        public override float WanderDistance => ModOwner.RepairBot ? 160 : 60;
        public override float GetSpeed => MathHelper.Lerp(
            ModOwner.RepairBot ? 20 : 10,
            ModOwner.RepairBot ? 40 : 16,
            MathHelper.Clamp(projectile.Distance(IdealPosition) / (WanderDistance * 2.2f) - 1f, 0, 1));

        public override float BashHeadIn => 5;

        public Vector2 Center;

        public float Rotation;
        public void ArmSegment(Vector2 center, float rotation)
        {
            Center = center;
            Rotation = rotation;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Miniature Digger");
            Main.projFrames[projectile.type] = 1;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.LightPet[projectile.type] = true;
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