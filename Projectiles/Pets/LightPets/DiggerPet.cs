using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;

namespace CalValEX.Projectiles.Pets.LightPets {
    public class DiggerPet : BaseWormPet {
        //Æ: Chronicles of my descent into madness. Also I can double jump now
        //Æ, 7/6/22: That's right baby, the queen's back
        public override string Texture => "CalValEX/Projectiles/Pets/LightPets/DiggerHead";
        public override WormPetVisualSegment HeadSegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/LightPets/DiggerHead", true, 1, 1);
        public override WormPetVisualSegment BodySegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/LightPets/DiggerSegment", true, 1, 1);
        public override WormPetVisualSegment TailSegment() => new WormPetVisualSegment("CalValEX/Projectiles/Pets/LightPets/DiggerTail", true, 1, 1);
        public override int SegmentSize() => 26;
        public override int SegmentCount() => ModOwner.RepairBot ? 24 : 9;
        public override bool ExistenceCondition() => ModOwner.digger;
        public override Color Lightcolor => ModOwner.RepairBot ? Color.Red : Color.Orange;
        public override int AbyssLightLevel => 3;
        public override float GlowmaskOpacity => ModOwner.RepairBot ? 2 : 0.6f;
        public override float WanderDistance => ModOwner.RepairBot ? 220 : 120;
        public override float Intensity => ModOwner.RepairBot ? 2.2f : 0.7f;
        public override float GetSpeed => MathHelper.Lerp(
            ModOwner.RepairBot ? 22 : 10,
            ModOwner.RepairBot ? 44 : 20,
            MathHelper.Clamp(Projectile.Distance(IdealPosition) / (WanderDistance * 2.2f) - 1f, 0, 1));
        public override float BashHeadIn => 5;

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Miniature Digger");
            Main.projFrames[Projectile.type] = 1;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.LightPet[Projectile.type] = true;
        }

        public override void DrawWorm(Color lightColor, bool glow = false) {
            for (int i = SegmentCount() - 1; i >= 0; i--) {
                #region //Actual worm stuff, don't touch
                WormPetVisualSegment currentSegment = Segments[i].visual;
                //If the segment doesn't have a glowmask on the glow pass, simply don't draw it lol?
                if (glow & !currentSegment.Glows)
                    continue;

                bool bodySegment = i != 0 && i != SegmentCount() - 1;
                Texture2D sprite = ModContent.Request<Texture2D>(currentSegment.TexturePath + (glow ? GlowmaskSuffix : "")).Value;

                Vector2 angleVector = (i == 0 ? Projectile.rotation.ToRotationVector2() : (Segments[i - 1].position - Segments[i].position));
                bool flipped = Math.Sign(angleVector.X) < 0 && currentSegment.Directional;

                //Get the horizontal start of the frame (for segments with variants)
                int frameStartX = (i % currentSegment.Variants) * sprite.Width / currentSegment.Variants;

                //Get the vertical segment of the frame
                int frameStartY = sprite.Height / currentSegment.FrameCount * currentSegment.Frame;

                int frameWidth = sprite.Width / currentSegment.Variants;
                int frameHeight = (sprite.Height / currentSegment.FrameCount);

                //Remove 2 from the width and height of the frame if the segment has variants/is animated to account for the extra gap of 2 pixels
                frameWidth -= currentSegment.Variants > 1 ? 2 : 0;
                frameHeight -= (Main.projFrames[Projectile.type] > 1) ? 2 : 0;

                Rectangle frame = new Rectangle(frameStartX, frameStartY, frameWidth, frameHeight);
                Vector2 origin = bodySegment ? frame.Size() / 2f : i == 0 ? new Vector2(frame.Width / 2f, frame.Height - SegmentSize() / 2f) : new Vector2(frame.Width / 2f, SegmentSize() / 2f);

                if (i == 0)
                    origin -= Vector2.UnitY * BashHeadIn;

                origin -= Vector2.UnitX * currentSegment.LateralShift * (flipped ? -1 : 1);

                float rotation = i == 0 ? Projectile.rotation + MathHelper.PiOver2 : (Segments[i].position - Segments[i - 1].position).ToRotation() - MathHelper.PiOver2;

                Color segmentLight = glow ? Color.White * GlowmaskOpacity : Lighting.GetColor((int)Segments[i].position.X / 16, (int)Segments[i].position.Y / 16); //Lighting of the position of the segment. Pure white if its a glowmask

                Main.EntitySpriteDraw(sprite, Segments[i].position - Main.screenPosition, frame, segmentLight, rotation, origin, Projectile.scale, flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
                #endregion

                #region //Arm stuff
                if (i % 2 == 1 && bodySegment) { // Check if the segment is divisible by two so we can skip them
                    var col = Lighting.GetColor((int)Segments[i].position.X / 16, (int)Segments[i].position.Y / 16);
                    var pos = Segments[i].position - Main.screenPosition;
                    var armBatch = ModOwner.RepairBot ? 10 : 4;
                    var speed = 15; // Changes the arm's rotation speed, higher = slower
                    // Movement delay
                    var lSinOffset = i < armBatch ? speed * 0.5f : 0;
                    var rSinOffset = i < armBatch ? 0 : speed * 0.5f;
                    // How far to draw the arm from the segments
                    var posOffset = new Vector2(20f, 0f).RotatedBy(rotation);

                    #region //Arm
                    var armTex = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/LightPets/DiggerArm").Value;
                    var armRot = MathHelper.Lerp(0, 130, Main.GlobalTimeWrappedHourly / speed);
                    var lArmOrigin = new Vector2(20, 6);
                    var rArmOrigin = new Vector2(4, 6);
                    // Sets its own rotation
                    var lArmRotVec = (float)Math.Sin(armRot + lSinOffset);
                    var rArmRotVec = -(float)Math.Sin(-armRot + rSinOffset);

                    Main.EntitySpriteDraw(armTex, pos - posOffset, null, col, lArmRotVec + rotation, lArmOrigin, Projectile.scale, SpriteEffects.None, 0);
                    Main.EntitySpriteDraw(armTex, pos + posOffset, null, col, rArmRotVec + rotation, rArmOrigin, Projectile.scale, SpriteEffects.FlipHorizontally, 0);
                    #endregion

                    #region //Forearm
                    var fArmTex = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/LightPets/DiggerForearm").Value;
                    // Slightly different speed to compensate for new angles
                    var fArmRot = MathHelper.Lerp(0, 45, Main.GlobalTimeWrappedHourly / (speed / 3));
                    var lFArmOrigin = new Vector2(14, 6);
                    var rFArmOrigin = new Vector2(2, 6);
                    // Moves the origin position to match the arm's movement
                    var lOriginOffset = new Vector2(22f, 0).RotatedBy(lArmRotVec + rotation);
                    var rOriginOffset = new Vector2(22f, 0).RotatedBy(rArmRotVec + rotation);
                    // Sets its own rotation
                    var lFArmRotVec = 0.35f * (float)Math.Sin(fArmRot + lSinOffset) + 1.7f;
                    var rFArmRotVec = 0.35f * -(float)Math.Sin(-fArmRot + rSinOffset) - 1.7f;

                    Main.EntitySpriteDraw(fArmTex, pos - posOffset - lOriginOffset, null, col, lFArmRotVec + rotation, lFArmOrigin, Projectile.scale, SpriteEffects.None, 0);
                    Main.EntitySpriteDraw(fArmTex, pos + posOffset + rOriginOffset, null, col, rFArmRotVec + rotation, rFArmOrigin, Projectile.scale, SpriteEffects.FlipHorizontally, 0);
                    #endregion

                    #region //Claw
                    var clawTex = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/LightPets/DiggerClaw").Value;
                    var clawRot = MathHelper.Lerp(0, 45, Main.GlobalTimeWrappedHourly / (speed / 2.8f));
                    var lclawOrigin = new Vector2(12, 2);
                    var rclawOrigin = new Vector2(2, 2);
                    // Second vector offset to account for the forearm's rotation, first offset was accounted for in the forearm
                    var lClawPivotOffset = new Vector2(14f, 0).RotatedBy(lFArmRotVec + rotation);
                    var rClawPivotOffset = new Vector2(14f, 0).RotatedBy(rFArmRotVec + rotation);
                    // Sets its own rotation
                    var lClawRotVec = (float)Math.Sin(clawRot + lSinOffset) - 0.8f;
                    var rClawRotVec = -(float)Math.Sin(-clawRot + rSinOffset) + 0.8f;

                    Main.EntitySpriteDraw(clawTex, pos - posOffset - lOriginOffset - lClawPivotOffset, null, col, lClawRotVec + rotation + 90, lclawOrigin, Projectile.scale, SpriteEffects.None, 0);
                    Main.EntitySpriteDraw(clawTex, pos + posOffset + rOriginOffset + rClawPivotOffset, null, col, rClawRotVec + rotation - 90, rclawOrigin, Projectile.scale, SpriteEffects.FlipHorizontally, 0);
                    #endregion
                }
                #endregion
            }
        }
    }
}