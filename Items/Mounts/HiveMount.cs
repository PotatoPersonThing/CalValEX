using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts
{
    public class HiveMount : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.buff = mod.BuffType("HiveVuff");
            mountData.heightBoost = 45;
            mountData.fallDamage = 0.1f;
            mountData.runSpeed = 6f;
            mountData.dashSpeed = 2.53f;
            mountData.flightTimeMax = 85;
            mountData.fatigueMax = 0;
            mountData.jumpHeight = 3;
            mountData.acceleration = 0.20f;
            mountData.jumpSpeed = 9f;
            mountData.blockExtraJumps = false;
            mountData.totalFrames = 14;
            mountData.constantJump = false;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 9; // (increase this?)
            }
            mountData.playerYOffsets = array;
            mountData.xOffset = 0;
            mountData.bodyFrame = 6;
            mountData.yOffset = 15;
            mountData.playerHeadOffset = 0;
            mountData.standingFrameCount = 1;
            mountData.standingFrameDelay = 1;
            mountData.standingFrameStart = 10;
            mountData.runningFrameCount = 4;
            mountData.runningFrameDelay = 15;
            mountData.runningFrameStart = 10;
            // if (Main.player.velocity.X = mountData.runSpeed) {
            // mountData.runningFrameCount = 1;
            // mountData.runningFrameDelay = 12;
            // mountData.runningFrameStart = 8;
            // } I forgot what this is for
            mountData.flyingFrameCount = 10;
            mountData.flyingFrameDelay = 5;
            mountData.flyingFrameStart = 0;
            mountData.inAirFrameCount = 10;
            mountData.inAirFrameDelay = 5;
            mountData.inAirFrameStart = 0;
            mountData.idleFrameCount = 1;
            mountData.idleFrameDelay = 1;
            mountData.idleFrameStart = 10;
            mountData.idleFrameLoop = false;
            mountData.swimFrameCount = 1;
            mountData.swimFrameDelay = 40;
            mountData.swimFrameStart = 9;
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            mountData.textureWidth = mountData.frontTexture.Width;
            mountData.textureHeight = mountData.frontTexture.Height;
        }
    }
}