using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts
{
    public class HadarianMount : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.buff = mod.BuffType("HadarianBuff");
            mountData.heightBoost = 5;
            mountData.fallDamage = 0.1f;
            mountData.runSpeed = 10f;
            mountData.dashSpeed = 3f;
            mountData.flightTimeMax = 165;
            mountData.fatigueMax = 0;
            mountData.jumpHeight = 5;
            mountData.acceleration = 0.31f;
            mountData.jumpSpeed = 10f;
            mountData.blockExtraJumps = false;
            mountData.totalFrames = 8;
            mountData.constantJump = true;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 9; // (increase this?)
            }
            mountData.playerYOffsets = array;
            mountData.xOffset = 4;
            mountData.bodyFrame = 6;
            mountData.yOffset = 0;
            mountData.playerHeadOffset = 0;
            mountData.standingFrameCount = 1;
            mountData.standingFrameDelay = 1;
            mountData.standingFrameStart = 4;
            mountData.runningFrameCount = 4;
            mountData.runningFrameDelay = 15;
            mountData.runningFrameStart = 4;
            // if (Main.player.velocity.X = mountData.runSpeed) {
            // mountData.runningFrameCount = 1;
            // mountData.runningFrameDelay = 12;
            // mountData.runningFrameStart = 8;
            // } I forgot what this is for
            mountData.flyingFrameCount = 4;
            mountData.flyingFrameDelay = 8;
            mountData.flyingFrameStart = 0;
            mountData.inAirFrameCount = 4;
            mountData.inAirFrameDelay = 15;
            mountData.inAirFrameStart = 0;
            mountData.idleFrameCount = 1;
            mountData.idleFrameDelay = 1;
            mountData.idleFrameStart = 4;
            mountData.idleFrameLoop = false;
            mountData.swimFrameCount = 1;
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