using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts
{
    public class YharonMount : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.buff = mod.BuffType("YharonMountBuff");
            mountData.heightBoost = 15;
            mountData.fallDamage = 0f;
            mountData.runSpeed = 14f;
            mountData.dashSpeed = 14f;
            mountData.flightTimeMax = int.MaxValue - 1;
            mountData.fatigueMax = int.MaxValue - 1;
            mountData.jumpHeight = 12;
            mountData.usesHover = true;
            mountData.acceleration = 0.35f;
            mountData.jumpSpeed = 5f;
            mountData.blockExtraJumps = false;
            mountData.totalFrames = 6;
            mountData.spawnDust = 127;
            mountData.spawnDustNoGravity = true;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 9; // (increase this?)
            }
            mountData.playerYOffsets = array;
            mountData.xOffset = -18;
            mountData.bodyFrame = 6;
            mountData.yOffset = 30;
            mountData.playerHeadOffset = 0;
            mountData.standingFrameCount = 6;
            mountData.standingFrameDelay = 8;
            mountData.standingFrameStart = 0;
            mountData.runningFrameCount = 5;
            mountData.runningFrameDelay = 6;
            mountData.runningFrameStart = 0;
            // if (Main.player.velocity.X = mountData.runSpeed) {
            // mountData.runningFrameCount = 1;
            // mountData.runningFrameDelay = 12;
            // mountData.runningFrameStart = 8;
            // } I forgot what this is for
            mountData.flyingFrameCount = 6;
            mountData.flyingFrameDelay = 6;
            mountData.flyingFrameStart = 0;
            mountData.inAirFrameCount = 6;
            mountData.inAirFrameDelay = 7;
            mountData.inAirFrameStart = 0;
            mountData.idleFrameCount = 6;
            mountData.idleFrameDelay = 8;
            mountData.idleFrameStart = 0;
            mountData.idleFrameLoop = false;
            mountData.swimFrameCount = 6;
            mountData.swimFrameDelay = 40;
            mountData.swimFrameStart = 0;
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            mountData.textureWidth = mountData.frontTexture.Width;
            mountData.textureHeight = mountData.frontTexture.Height;
        }
    }
}