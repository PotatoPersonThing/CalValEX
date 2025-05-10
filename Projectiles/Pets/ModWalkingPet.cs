using System;
using System.IO;
using Terraria;

namespace CalValEX.Projectiles.Pets
{
    /// <summary>
    /// The base of a walking pet
    /// </summary>
    public abstract class ModWalkingPet : ModPet
    {
        public class States
        {
            public const int Walking = 0;
            public const int Flying = 1;
        }

        /// <summary>
        /// Default is 80f
        /// </summary>
        public virtual float WalkingThreshold => 80f;

        /// <summary>
        /// Default is 16f
        /// </summary>
        public virtual float WalkingSpeed => 16f;

        /// <summary>
        /// Default value is 0.4f
        /// </summary>
        public virtual float Gravity => 0.4f;

        /// <summary>
        /// Default value is 20f
        /// </summary>
        public virtual float WalkingInertia => 20f;

        /// <summary>
        /// Default is 0.95f
        /// </summary>
        public virtual float WalkingDrag => 0.95f;

        /// <summary>
        /// Default is 6.5f
        /// </summary>
        public virtual float MaxWalkingSpeed => 6.5f;

        /// <summary>
        /// Default is 250f
        /// </summary>
        public virtual float BackToWalkingThreshold => 250f;

        /// <summary>
        /// Default is 500f
        /// </summary>
        public virtual float BackToFlyingThreshold => 500f;

        /// <summary>
        /// Make false so you can apply your own gravity. Default is true
        /// </summary>
        public virtual bool HasGravity => true;

        /// <summary>
        /// Makes this WalkingPet always jump. Default is false. Only works if CanJump is true
        /// </summary>
        public virtual bool AlwaysJumping => false;

        /// <summary>
        /// Allows this WalkingPet to jump. Default is true
        /// </summary>
        public virtual bool CanJump => true;

        /// <summary>
        /// Default is true
        /// </summary>
        public virtual bool CanFly => true;

        /// <summary>
        /// Default value is 0
        /// </summary>
        public virtual int JumpOffset => 0;

        /// <summary>
        /// Counter for jumps
        /// </summary>
        public int jumpCounter = 0;

        /// <summary>
        /// Allows you to add custom logic when this pet jumps
        /// </summary>
        public virtual void OnJump()
        {
        }

        /// <summary>
        /// Allows you to change the jump height (strength) of this pet
        /// </summary>
        /// <param name="oneTileHigherAndNotTwoTilesHigher"></param>
        /// <param name="twoTilesHigher"></param>
        /// <param name="fiveTilesHigher"></param>
        /// <param name="fourTilesHigher"></param>
        /// <param name="anyOtherJump"></param>
        public virtual void ModifyJumpHeight(ref float oneTileHigherAndNotTwoTilesHigher, ref float twoTilesHigher, ref float fourTilesHigher, ref float fiveTilesHigher, ref float anyOtherJump)
        {
        }

        /// <summary>
        /// Allows you to modify this pets' speeds
        /// </summary>
        /// <param name="walkingSpeed">The current walking speed</param>
        /// <param name="flyingSpeed">The current flying speed</param>
        public virtual void ModifyPetSpeeds(ref float walkingSpeed, ref float flyingSpeed)
        {
        }

        /// <summary>
        /// Allows you to modify this pets' inertias
        /// </summary>
        /// <param name="walkingInertia">The current walking inertia</param>
        /// <param name="flyingInertia">the current flying inertia</param>
        public virtual void ModifyPetInertias(ref float walkingInertia, ref float flyingInertia)
        {
        }

        public sealed override void CustomBehaviour(Player player, ref int state)
        {
            base.CustomBehaviour(player, ref state);
        }

        /// <summary>
        /// <inheritdoc cref="ModPet.CustomBehaviour(Player, ref int)"/>
        /// </summary>
        /// <param name="player">The owner of this pet</param>
        /// <param name="state">The state this Walking Pet is in</param>
        /// <param name="walkingSpeed">The current walking speed</param>
        /// <param name="walkingInertia">The current walking inertia</param>
        /// <param name="flyingSpeed">The current flying speed</param>
        /// <param name="flyingInertia">The current flying inertia</param>
        public virtual void CustomBehaviour(Player player, ref int state, float walkingSpeed, float walkingInertia, float flyingSpeed, float flyingInertia)
        {

        }

        public sealed override void PetBehaviour()
        {
            if (!Main.player[Projectile.owner].active)
            {
                Projectile.active = false;
                return;
            }

            bool leftOfPlayer = false;
            bool rightOfPlayer = false;
            bool isBelowPlayer = false;
            bool wantsToJump = false;

            Player player = Main.player[Projectile.owner];

            PetFunctionality(player);

            if (Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y) > 0.05f)
            {
                if (FacesLeft && ShouldFlip)
                    Projectile.spriteDirection = Projectile.velocity.X > 0 ? -1 : 1;
                else if (!FacesLeft && ShouldFlip)
                    Projectile.spriteDirection = Projectile.velocity.X > 0 ? 1 : -1;
            }

            if (player.position.X + (player.width / 2) < Projectile.position.X + (Projectile.width / 2) - WalkingThreshold)
            {
                leftOfPlayer = true;
            }
            else if (player.position.X + (player.width / 2) > Projectile.position.X + (Projectile.width / 2) + WalkingThreshold)
            {
                rightOfPlayer = true;
            }

            if (player.rocketDelay2 > 0 && state == States.Walking && CanFly)
                ResetMe(States.Flying);

            Vector2 ProjectileCenter = Projectile.Center;
            Vector2 vectorToPlayer = player.Center - ProjectileCenter;
            float lengthToPlayer = vectorToPlayer.Length();

            if (lengthToPlayer > TeleportThreshold && CanTeleport)
            {
                PreTeleport();
                Projectile.position = player.Center;
                Projectile.velocity *= 0.1f;
                OnTeleport();
            }
            else if ((lengthToPlayer > BackToFlyingThreshold || (Math.Abs(vectorToPlayer.Y) > 300f)) && (state == States.Walking || state == States.Flying) && CanFly)
            {
                if (vectorToPlayer.Y > 0f && Projectile.velocity.Y < 0f)
                    Projectile.velocity.Y = 0f;

                if (vectorToPlayer.Y < 0f && Projectile.velocity.Y > 0f)
                    Projectile.velocity.Y = 0f;

                ResetMe(States.Flying);
            }

            Animation(state);

            float walkingSpeed = WalkingSpeed;
            float flyingSpeed = FlyingSpeed;
            float flyingInertia = FlyingInertia;
            float walkingInertia = WalkingInertia;

            if ((lengthToPlayer > SpeedupThreshold) && ShouldSpeedup)
            {
                walkingSpeed *= 1.25f;
                walkingInertia *= 0.75f;
                flyingSpeed *= 1.25f;
                flyingInertia *= 0.75f;
            }

            ModifyPetSpeeds(ref walkingSpeed, ref flyingSpeed);

            ModifyPetInertias(ref walkingInertia, ref flyingInertia);

            CustomBehaviour(player, ref state, walkingSpeed, walkingInertia, flyingSpeed, flyingInertia);

            switch (state)
            {
                case States.Walking:

                    if (AllowRotationReset)
                        Projectile.rotation = 0f;

                    Projectile.tileCollide = true;
                    
                    if (leftOfPlayer || rightOfPlayer)
                    {
                        vectorToPlayer.Normalize();
                        vectorToPlayer *= walkingSpeed;

                        if (walkingInertia != 0f && walkingSpeed != 0f)
                            Projectile.velocity.X = (Projectile.velocity.X * (walkingInertia - 1) + vectorToPlayer.X) / walkingInertia;
                    }
                    else
                    {
                        Projectile.velocity.X *= WalkingDrag;
                        if (Projectile.velocity.X >= 0f - 0.2f && Projectile.velocity.X <= 0.2f)
                            Projectile.velocity.X = 0f;
                    }

                    if (leftOfPlayer || rightOfPlayer)
                    {
                        int XTileToPlayer = (int)(Projectile.position.X + (Projectile.width / 2)) / 16;
                        int YTileToPlayer = (int)(Projectile.position.Y + (Projectile.height / 2)) / 16;

                        if (leftOfPlayer)
                            XTileToPlayer--;

                        if (rightOfPlayer)
                            XTileToPlayer++;

                        XTileToPlayer += (int)Projectile.velocity.X;
                        if (WorldGen.SolidTile(XTileToPlayer, YTileToPlayer))
                            wantsToJump = true;
                    }

                    if (player.position.Y + player.height - 8f > Projectile.position.Y + Projectile.height)
                        isBelowPlayer = true;

                    Collision.StepUp(ref Projectile.position, ref Projectile.velocity, Projectile.width, Projectile.height, ref Projectile.stepSpeed, ref Projectile.gfxOffY);
                    if (Projectile.velocity.Y == 0f)
                    {
                        if (!isBelowPlayer && (Projectile.velocity.X < 0f || Projectile.velocity.X > 0f))
                        {
                            int XCenterTile = (int)(Projectile.position.X + (Projectile.width / 2)) / 16;
                            int YCenterTile = (int)(Projectile.position.Y + (Projectile.height / 2)) / 16 + 1;
                            if (leftOfPlayer)
                                XCenterTile--;

                            if (rightOfPlayer)
                                XCenterTile++;

                            WorldGen.SolidTile(XCenterTile, YCenterTile);
                        }

                        if ((wantsToJump || AlwaysJumping) && CanJump)
                        {
                            if (jumpCounter < JumpOffset)
                            {
                                jumpCounter++;
                                goto SkipJump;
                            }

                            jumpCounter = 0;
                            int XCenterTile = (int)(Projectile.position.X + (Projectile.width / 2)) / 16;
                            int YBottomTile = (int)(Projectile.position.Y + Projectile.height) / 16 + 1;
                            if (WorldGen.SolidTile(XCenterTile, YBottomTile) || Main.tile[XCenterTile, YBottomTile].IsHalfBlock || Main.tile[XCenterTile, YBottomTile].Slope > 0)
                            {
                                float oneAndNotTwo = -5.1f;
                                float two = -7.1f;
                                float five = -11.1f;
                                float four = -10.1f;
                                float anyOther = -9.1f;

                                ModifyJumpHeight(ref oneAndNotTwo, ref two, ref four, ref five, ref anyOther);

                                try
                                {
                                    XCenterTile = (int)(Projectile.position.X + (Projectile.width / 2)) / 16;
                                    YBottomTile = (int)(Projectile.position.Y + (Projectile.height / 2)) / 16;
                                    if (leftOfPlayer)
                                        XCenterTile--;

                                    if (rightOfPlayer)
                                        XCenterTile++;

                                    XCenterTile += (int)Projectile.velocity.X;
                                    if (!WorldGen.SolidTile(XCenterTile, YBottomTile - 1) && !WorldGen.SolidTile(XCenterTile, YBottomTile - 2))
                                        Projectile.velocity.Y = oneAndNotTwo;
                                    else if (!WorldGen.SolidTile(XCenterTile, YBottomTile - 2))
                                        Projectile.velocity.Y = two;
                                    else if (WorldGen.SolidTile(XCenterTile, YBottomTile - 5))
                                        Projectile.velocity.Y = five;
                                    else if (WorldGen.SolidTile(XCenterTile, YBottomTile - 4))
                                        Projectile.velocity.Y = four;
                                    else
                                        Projectile.velocity.Y = anyOther;
                                }
                                catch
                                {
                                    Projectile.velocity.Y = anyOther;
                                }

                                OnJump();
                            }
                        }
                        else
                        {
                            jumpCounter = 0;
                        }
                    }

                    SkipJump:
                    if (Projectile.velocity.X > MaxWalkingSpeed)
                        Projectile.velocity.X = MaxWalkingSpeed;

                    if (Projectile.velocity.X < 0f - MaxWalkingSpeed)
                        Projectile.velocity.X = 0f - MaxWalkingSpeed;
                    break;

                case States.Flying:

                    Projectile.tileCollide = false;

                    vectorToPlayer += FlyingOffset;
                    lengthToPlayer = vectorToPlayer.Length();

                    if (lengthToPlayer < BackToWalkingThreshold && player.velocity.Y == 0f && Projectile.position.Y + Projectile.height <= player.position.Y + player.height && !Collision.SolidCollision(Projectile.position, Projectile.width, Projectile.height))
                    {
                        ResetMe(States.Walking);
                        if (Projectile.velocity.Y < -6f)
                            Projectile.velocity.Y = -6f;
                    }

                    if (lengthToPlayer > FlyingArea)
                    {
                        vectorToPlayer.Normalize();
                        vectorToPlayer *= flyingSpeed;

                        if (Projectile.velocity == Vector2.Zero)
                        {
                            Projectile.velocity = new Vector2(-0.15f);
                        }
                        if (flyingInertia != 0f && flyingSpeed != 0f)
                            Projectile.velocity = (Projectile.velocity * (flyingInertia - 1) + vectorToPlayer) / flyingInertia;
                    }
                    else
                    {
                        Projectile.velocity *= FlyingDrag;
                    }

                    if (ShouldFlyRotate)
                    {
                        Projectile.rotation = Projectile.velocity.X * 0.1f;
                    }

                    int dustType = 16;
                    if (ModifyDustSpawn(ref dustType))
                    {
                        int theDust = Dust.NewDust(new Vector2(Projectile.position.X + (Projectile.width / 2) - 4f, Projectile.position.Y + (Projectile.height / 2) - 4f) - Projectile.velocity, 8, 8, dustType, (0f - Projectile.velocity.X) * 0.5f, Projectile.velocity.Y * 0.5f, 50, default, 1.7f);
                        Main.dust[theDust].velocity.X = Main.dust[theDust].velocity.X * 0.2f;
                        Main.dust[theDust].velocity.Y = Main.dust[theDust].velocity.Y * 0.2f;
                        Main.dust[theDust].noGravity = true;
                    }

                    break;
            }

            if (state == States.Walking && HasGravity)
            {
                Projectile.velocity.Y += Gravity;
            }

            auraRotation = MathHelper.WrapAngle(auraRotation);
        }

        /// <summary>
        /// <inheritdoc cref="ModPet.SendExtraAI(BinaryWriter)"/>
        /// </summary>
        /// <param name="writer"></param>
        public new virtual void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(jumpCounter);
            base.SendExtraAI(writer);
        }

        /// <summary>
        /// <inheritdoc cref="ModPet.ReceiveExtraAI(BinaryReader)"/>
        /// </summary>
        /// <param name="writer"></param>
        public new virtual void ReceiveExtraAI(BinaryReader reader)
        {
            jumpCounter = reader.ReadInt32();
            base.ReceiveExtraAI(reader);
        }
    }
}
