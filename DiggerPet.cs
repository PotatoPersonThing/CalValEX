using CalamityMod.DataStructures;
using CalValEX.Items.Pets.ExoMechs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static CalamityMod.CalamityUtils;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class DiggerPet : BaseWormPet
    {
        public override string Texture => "CalValEX/Projectiles/Pets/LightPets/DiggerHead"; 
        public override WormPetVisualSegment HeadSegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/LightPets/DiggerHead", true, 1, 1);
        public override WormPetVisualSegment BodySegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/LightPets/DiggerSegment", true, 1, 1);
        public override WormPetVisualSegment TailSegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/LightPets/DiggerTail", true, 1, 1);

        public override int SegmentSize() => 26;

        public override int SegmentCount() => Owner.GetModPlayer<CalValEXPlayer>().RepairBot ? 24 : 12;

        public override bool ExistenceCondition() => ModOwner.digger;
        public override float WanderDistance => Owner.GetModPlayer<CalValEXPlayer>().RepairBot ? 160 : 60;
        public override float GetSpeed => MathHelper.Lerp(
            Owner.GetModPlayer<CalValEXPlayer>().RepairBot ? 20 : 10,
            Owner.GetModPlayer<CalValEXPlayer>().RepairBot ? 40 : 16, 
            MathHelper.Clamp(projectile.Distance(IdealPosition) / (WanderDistance * 2.2f) - 1f, 0, 1));

        public override int BodyVariants => 1;
        public override float BashHeadIn => 5;
        public override float GlowmaskOpacity => Owner.GetModPlayer<CalValEXPlayer>().RepairBot ? 2 : 0.6f;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Digger pet, also change this");
            Main.projFrames[projectile.type] = 1;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.LightPet[projectile.type] = true;
        }
        public override void MoveTowardsIdealPosition()
        {
            /*If the owner is holding right click, shift its goal from the worms ideal position tothe mouse cursor
            if (Owner.Calamity().mouseRight && Owner.HeldItem.type == ModContent.ItemType<GunmetalRemote>())
                RelativeIdealPosition = Owner.Calamity().mouseWorld - Owner.Center;
            */

            //Rotate towards its ideal position
            projectile.rotation = projectile.rotation.AngleTowards((IdealPosition - projectile.Center).ToRotation(), MathHelper.Lerp(MaximumSteerAngle, MinimumSteerAngle, MathHelper.Clamp(projectile.Distance(IdealPosition) / 80f, 0, 1)));
            projectile.velocity = projectile.rotation.ToRotationVector2() * GetSpeed;

            //Update its segment
            Segments[0].oldPosition = Segments[0].position;
            Segments[0].position = projectile.Center;
        }
    }
}