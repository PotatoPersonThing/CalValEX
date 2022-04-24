using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class DiggerPet : BaseWormPet
    {
        //Æ: Chronicles of my descent into madness. Also I can double jump now
        public override string Texture => "CalValEX/Projectiles/Pets/LightPets/DiggerHead"; 
        public override WormPetVisualSegment HeadSegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/LightPets/DiggerHead", true, 1, 1);
        public override WormPetVisualSegment BodySegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/LightPets/DiggerSegment", true, 1, 1);
        public override WormPetVisualSegment TailSegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/LightPets/DiggerTail", true, 1, 1);
        //public override string ArmTexture => "CalValEX/Projectiles/Pets/LightPets/DiggerArm";
        //public override string ForearmTexture => "CalValEX/Projectiles/Pets/LightPets/DiggerForearm";
        //public override string HandTexture => "CalValEX/Projectiles/Pets/LightPets/DiggerClaw";

        public override int SegmentSize() => 26;

        public override int SegmentCount() => ModOwner.RepairBot ? 24 : 9;

        public override bool ExistenceCondition() => ModOwner.digger;
        public override Color lightcolor => ModOwner.RepairBot ? Color.Red : Color.Orange;
        public override int abyssLightLevel => 3;
        public override float GlowmaskOpacity => ModOwner.RepairBot ? 2 : 0.6f;
        public override float WanderDistance => ModOwner.RepairBot ? 160 : 60;
        public override float intensity => ModOwner.RepairBot ? 2.2f : 0.7f;
        public override float GetSpeed => MathHelper.Lerp(
            ModOwner.RepairBot ? 20 : 10,
            ModOwner.RepairBot ? 40 : 16,
            MathHelper.Clamp(Projectile.Distance(IdealPosition) / (WanderDistance * 2.2f) - 1f, 0, 1));

        public override float BashHeadIn => 5;

        public Vector2 Center;

        public float Rotation;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Miniature Digger");
            Main.projFrames[Projectile.type] = 1;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.LightPet[Projectile.type] = true;
        }
    }
}