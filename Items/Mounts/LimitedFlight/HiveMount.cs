using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.LimitedFlight
{
    public class HiveMount : ModMount
    {
        public override void SetStaticDefaults()
        {
            MountData.buff =ModContent.BuffType<Buffs.Mounts.HiveVuff>();
            MountData.heightBoost = 45;
            MountData.fallDamage = 0f;
            MountData.runSpeed = 6f;
            MountData.dashSpeed = 2.53f;
            MountData.flightTimeMax = 85;
            MountData.fatigueMax = 0;
            MountData.jumpHeight = 3;
            MountData.acceleration = 0.20f;
            MountData.jumpSpeed = 9f;
            MountData.blockExtraJumps = false;
            MountData.totalFrames = 14;
            MountData.constantJump = false;
            int[] array = new int[MountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 9; // (increase this?)
            }
            MountData.playerYOffsets = array;
            MountData.xOffset = 0;
            MountData.bodyFrame = 6;
            MountData.yOffset = 15;
            MountData.playerHeadOffset = 0;
            MountData.standingFrameCount = 1;
            MountData.standingFrameDelay = 1;
            MountData.standingFrameStart = 10;
            MountData.runningFrameCount = 4;
            MountData.runningFrameDelay = 15;
            MountData.runningFrameStart = 10;
            // if (Main.player.velocity.X = MountData.runSpeed) {
            // MountData.runningFrameCount = 1;
            // MountData.runningFrameDelay = 12;
            // MountData.runningFrameStart = 8;
            // } I forgot what this is for
            MountData.flyingFrameCount = 10;
            MountData.flyingFrameDelay = 5;
            MountData.flyingFrameStart = 0;
            MountData.inAirFrameCount = 10;
            MountData.inAirFrameDelay = 5;
            MountData.inAirFrameStart = 0;
            MountData.idleFrameCount = 1;
            MountData.idleFrameDelay = 1;
            MountData.idleFrameStart = 10;
            MountData.idleFrameLoop = false;
            MountData.swimFrameCount = 1;
            MountData.swimFrameDelay = 40;
            MountData.swimFrameStart = 9;
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            MountData.textureWidth = MountData.frontTexture.Width();
            MountData.textureHeight = MountData.frontTexture.Height();
        }
    }
}