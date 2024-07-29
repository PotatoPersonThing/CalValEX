using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CalValEX.Items.Mounts.Ground
{
    public class YhogoStickMount : ModMount
    {
        public override void SetStaticDefaults()
        {
            MountData.buff = ModContent.BuffType<Buffs.Mounts.YhogoStickBuff>();
            MountData.spawnDust = 15;
            MountData.heightBoost = 12;
            MountData.flightTimeMax = 0;
            MountData.fallDamage = 0f;
            MountData.runSpeed = 6f;
            MountData.acceleration = 0.22f;
            MountData.jumpHeight = 12;
            MountData.jumpSpeed = 10f;
            MountData.constantJump = true;
            MountData.totalFrames = 10;
            int[] array = new int[MountData.totalFrames];
            for (int num7 = 0; num7 < array.Length; num7++)
            {
                array[num7] = 20;
            }
            MountData.playerYOffsets = array;
            MountData.xOffset = 5;
            MountData.bodyFrame = 4;
            MountData.yOffset = -4;
            MountData.playerHeadOffset = 10;
            MountData.standingFrameCount = 1;
            MountData.standingFrameDelay = 5;
            MountData.standingFrameStart = 0;
            MountData.runningFrameCount = 1;
            MountData.runningFrameDelay = 5;
            MountData.runningFrameStart = 0;
            MountData.inAirFrameCount = 1;
            MountData.inAirFrameDelay = 5;
            MountData.inAirFrameStart = 0;
            MountData.idleFrameCount = 0;
            MountData.idleFrameDelay = 0;
            MountData.idleFrameStart = 0;
            MountData.idleFrameLoop = false;
            MountData.swimFrameCount = 1;
            MountData.swimFrameDelay = 5;
            MountData.swimFrameStart = 0;
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            MountData.textureWidth = MountData.backTexture.Width();
            MountData.textureHeight = MountData.backTexture.Height();
        }

        public override void UpdateEffects(Player player)
        {
            bool controlhorizontal = player.controlLeft || player.controlRight;
            Mount mount = player.mount;
            float playerspeed = (player.accRunSpeed + player.maxRunSpeed) / 2f;
            if (controlhorizontal && mount.Active && player.velocity.Y == 0f && !player.controlJump)
            {
                SoundEngine.PlaySound(in SoundID.Item168, player.Center);
                float playerjumpspeed = Player.jumpSpeed * player.gravDir * 0.5f;
                if (playerjumpspeed < 2f)
                {
                    playerjumpspeed = 2f;
                }
                playerjumpspeed += 0.01f;
                player.velocity.Y = 0f - playerjumpspeed;
                player.jump = Player.jumpHeight;
                player.fullRotation = 0f;
            }
            if (player.controlJump)
            {
                if (mount.Active && player.releaseJump && player.velocity.Y != 0f)
                {
                    player.isPerformingPogostickTricks = true;
                }
                if (player.jump <= 0)
                {
                    if ((player.sliding || player.velocity.Y == 0f || player.AnyExtraJumpUsable()) && (player.releaseJump || (player.autoJump && (player.velocity.Y == 0f || player.sliding))))
                    {
                        if (player.velocity.Y == 0f || controlhorizontal || player.sliding)
                        {
                            SoundEngine.PlaySound(in SoundID.Item168, player.Center);
                        }
                    }
                }
            }
            if (player.velocity.Y != 0f)
            {
                player.runSlowdown = 0;
                Vector2 playerspeedog = player.velocity;
                player.velocity.X = 0f;
                player.DryCollision(false, false);
                player.velocity.X = playerspeedog.X;
            }
        }
    }
}