using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.Ground
{
    public class SilvaJeep : ModMount
    {
        public override void SetStaticDefaults()
        {
            MountData.buff = ModContent.BuffType<Buffs.Mounts.SilvaJeepBuff>();
            MountData.heightBoost = 8;
            MountData.fallDamage = 0f;
            MountData.runSpeed = 18f;
            MountData.dashSpeed = 8f;
            MountData.flightTimeMax = 0;
            MountData.fatigueMax = 0;
            MountData.jumpHeight = 8;
            MountData.acceleration = 0.3f;
            MountData.jumpSpeed = 4f;
            MountData.blockExtraJumps = false;
            MountData.totalFrames = 4;
            MountData.constantJump = true;
            MountData.spawnDust = 157;
            int[] array = new int[MountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 12;
            }
            MountData.playerYOffsets = array;
            MountData.xOffset = 15;
            MountData.bodyFrame = 3;
            MountData.yOffset = 1;
            MountData.playerHeadOffset = 0;
            MountData.standingFrameCount = 4;
            MountData.standingFrameDelay = 12;
            MountData.standingFrameStart = 0;
            MountData.runningFrameCount = 4;
            MountData.runningFrameDelay = 12;
            MountData.runningFrameStart = 0;
            MountData.flyingFrameCount = 0;
            MountData.flyingFrameDelay = 0;
            MountData.flyingFrameStart = 0;
            MountData.inAirFrameCount = 1;
            MountData.inAirFrameDelay = 12;
            MountData.inAirFrameStart = 0;
            MountData.idleFrameCount = 4;
            MountData.idleFrameDelay = 12;
            MountData.idleFrameStart = 0;
            MountData.idleFrameLoop = true;
            MountData.swimFrameCount = MountData.inAirFrameCount;
            MountData.swimFrameDelay = MountData.inAirFrameDelay;
            MountData.swimFrameStart = MountData.inAirFrameStart;
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            MountData.textureWidth = MountData.backTexture.Width();
            MountData.textureHeight = MountData.backTexture.Height();
        }
    }
}