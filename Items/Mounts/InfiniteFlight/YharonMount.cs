using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.InfiniteFlight
{
    public class YharonMount : ModMount
    {
        public override void SetStaticDefaults()
        {
            MountData.buff = ModContent.BuffType<Buffs.Mounts.YharonMountBuff>();
            MountData.heightBoost = 15;
            MountData.fallDamage = 0f;
            MountData.runSpeed = 14f;
            MountData.dashSpeed = 14f;
            MountData.flightTimeMax = int.MaxValue - 1;
            MountData.fatigueMax = int.MaxValue - 1;
            MountData.jumpHeight = 12;
            MountData.usesHover = true;
            MountData.acceleration = 0.35f;
            MountData.jumpSpeed = 5f;
            MountData.blockExtraJumps = false;
            MountData.totalFrames = 8;
            MountData.spawnDust = 127;
            MountData.spawnDustNoGravity = true;
            int[] array = new int[MountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 9; // (increase this?)
            }
            MountData.playerYOffsets = array;
            MountData.bodyFrame = 6;
            MountData.yOffset = 10;
            MountData.xOffset = -38;
            MountData.playerHeadOffset = 0;
            MountData.standingFrameCount = 6;
            MountData.standingFrameDelay = 8;
            MountData.standingFrameStart = 0;
            MountData.runningFrameCount = 5;
            MountData.runningFrameDelay = 6;
            MountData.runningFrameStart = 0;
            MountData.flyingFrameCount = 6;
            MountData.flyingFrameDelay = 6;
            MountData.flyingFrameStart = 0;
            MountData.inAirFrameCount = 6;
            MountData.inAirFrameDelay = 7;
            MountData.inAirFrameStart = 0;
            MountData.idleFrameCount = 6;
            MountData.idleFrameDelay = 8;
            MountData.idleFrameStart = 0;
            MountData.idleFrameLoop = false;
            MountData.swimFrameCount = 6;
            MountData.swimFrameDelay = 40;
            MountData.swimFrameStart = 0;
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            MountData.textureWidth = MountData.frontTexture.Width();
            MountData.textureHeight = MountData.frontTexture.Height();
        }

        public override void UpdateEffects(Player player)
        {
            if (Math.Abs(player.velocity.X) >= 13)
            {
                MountData.standingFrameCount = 2;
                MountData.standingFrameDelay = 4;
                MountData.standingFrameStart = 6;
                MountData.runningFrameCount = 5;
                MountData.runningFrameDelay = 2;
                MountData.runningFrameStart = 6;
                MountData.flyingFrameCount = 2;
                MountData.flyingFrameDelay = 4;
                MountData.flyingFrameStart = 6;
                MountData.inAirFrameCount = 2;
                MountData.inAirFrameDelay = 4;
                MountData.inAirFrameStart = 6;
                MountData.idleFrameCount = 2;
                MountData.idleFrameDelay = 4;
                MountData.idleFrameStart = 6;
                MountData.idleFrameLoop = true;
                MountData.swimFrameCount = 2;
                MountData.swimFrameDelay = 8;
                MountData.swimFrameStart = 6;
            }
            else
            {
                MountData.standingFrameCount = 6;
                MountData.standingFrameDelay = 8;
                MountData.standingFrameStart = 0;
                MountData.runningFrameCount = 5;
                MountData.runningFrameDelay = 6;
                MountData.runningFrameStart = 0;
                MountData.flyingFrameCount = 6;
                MountData.flyingFrameDelay = 6;
                MountData.flyingFrameStart = 0;
                MountData.inAirFrameCount = 6;
                MountData.inAirFrameDelay = 7;
                MountData.inAirFrameStart = 0;
                MountData.idleFrameCount = 6;
                MountData.idleFrameDelay = 8;
                MountData.idleFrameStart = 0;
                MountData.idleFrameLoop = false;
                MountData.swimFrameCount = 6;
                MountData.swimFrameDelay = 40;
                MountData.swimFrameStart = 0;
            }
        }
    }
}