using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts
{
    public class FloatyCarpet : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.buff = mod.BuffType("FloatyBuff");
            mountData.heightBoost = -1;
            mountData.fallDamage = 0f;
            mountData.runSpeed = 3f;
            mountData.dashSpeed = 6f;
            mountData.flightTimeMax = 2;
            mountData.fatigueMax = 0;
            mountData.jumpHeight = 5;
            mountData.acceleration = 0.1f;
            mountData.jumpSpeed = 3f;
            mountData.blockExtraJumps = false;
            mountData.totalFrames = 7;
            mountData.constantJump = true;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 9; // (increase this?)
            }
            mountData.playerYOffsets = array;
            mountData.xOffset = 4;
            mountData.bodyFrame = 6;
            mountData.yOffset = 14;
            mountData.playerHeadOffset = 0;
            mountData.standingFrameCount = 1;
            mountData.standingFrameDelay = 1;
            mountData.standingFrameStart = 0;
            mountData.runningFrameCount = 5;
            mountData.runningFrameDelay = 60;
            mountData.runningFrameStart = 1;
            // if (Main.player.velocity.X = mountData.runSpeed) {
            // mountData.runningFrameCount = 1;
            // mountData.runningFrameDelay = 12;
            // mountData.runningFrameStart = 8;
            // } I forgot what this is for
            mountData.flyingFrameCount = 1;
            mountData.flyingFrameDelay = 1;
            mountData.flyingFrameStart = 0;
            mountData.inAirFrameCount = 1;
            mountData.inAirFrameDelay = 1;
            mountData.inAirFrameStart = 6;
            mountData.idleFrameCount = 1;
            mountData.idleFrameDelay = 1;
            mountData.idleFrameStart = 0;
            mountData.idleFrameLoop = false;
            mountData.swimFrameCount = 5;
            mountData.swimFrameDelay = 40;
            mountData.swimFrameStart = 1;
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            mountData.textureWidth = mountData.backTexture.Width;
            mountData.textureHeight = mountData.backTexture.Height;
        }

        // yo make this thing faster if the player is moist
        public override void UpdateEffects(Player player)
        {
            if (player.wet)
            {
                mountData.runSpeed = 10f;
                mountData.acceleration = 0.9f;
                mountData.jumpHeight = 27;
            }
            else
            {
                mountData.jumpHeight = 5;
                mountData.acceleration = 0.1f;
                mountData.jumpSpeed = 3f;
                mountData.runSpeed = 3f;
            }
        }
    }
}