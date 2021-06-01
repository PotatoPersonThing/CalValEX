using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts
{
    public class LeviMount : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.buff = mod.BuffType("LeviathanMountBuff");
            mountData.heightBoost = 4;
            mountData.fallDamage = 0f;
            mountData.runSpeed = 6f;
            mountData.dashSpeed = 6f;
            mountData.flightTimeMax = int.MaxValue - 1;
            mountData.fatigueMax = int.MaxValue - 1;
            mountData.jumpHeight = 5;
            mountData.usesHover = true;
            mountData.acceleration = 0.17f;
            mountData.jumpSpeed = 2f;
            mountData.blockExtraJumps = false;
            mountData.totalFrames = 8;
            mountData.spawnDust = 33;
            mountData.spawnDustNoGravity = true;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 9; // (increase this?)
            }
            mountData.playerYOffsets = array;
            mountData.xOffset = -5;
            mountData.bodyFrame = 6;
            mountData.yOffset = 30;
            mountData.playerHeadOffset = 0;
            mountData.standingFrameCount = 8;
            mountData.standingFrameDelay = 8;
            mountData.standingFrameStart = 0;
            mountData.runningFrameCount = 8;
            mountData.runningFrameDelay = 6;
            mountData.runningFrameStart = 0;
            // if (Main.player.velocity.X = mountData.runSpeed) {
            // mountData.runningFrameCount = 1;
            // mountData.runningFrameDelay = 12;
            // mountData.runningFrameStart = 8;
            // } I forgot what this is for
            mountData.flyingFrameCount = 8;
            mountData.flyingFrameDelay = 6;
            mountData.flyingFrameStart = 0;
            mountData.inAirFrameCount = 8;
            mountData.inAirFrameDelay = 7;
            mountData.inAirFrameStart = 0;
            mountData.idleFrameCount = 8;
            mountData.idleFrameDelay = 8;
            mountData.idleFrameStart = 0;
            mountData.idleFrameLoop = false;
            mountData.swimFrameCount = 8;
            mountData.swimFrameDelay = 20;
            mountData.swimFrameStart = 0;
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            mountData.textureWidth = mountData.frontTexture.Width;
            mountData.textureHeight = mountData.frontTexture.Height;
        }
        public override void UpdateEffects(Player player)
        {
            if (player.wet)
            {
                mountData.runSpeed = 10f;
                mountData.acceleration = 0.27f;
                mountData.jumpHeight = 6;
            }
            else
            {
                mountData.jumpHeight = 5;
                mountData.acceleration = 0.17f;
                mountData.jumpSpeed = 2f;
                mountData.runSpeed = 6f;
            }
        }
    }
}