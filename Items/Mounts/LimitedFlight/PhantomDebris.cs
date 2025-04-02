using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.LimitedFlight
{
    public class PhantomDebris : ModMount
    {
        public override void SetStaticDefaults()
        {
            MountData.buff = ModContent.BuffType<Buffs.Mounts.DebrisMount>();
            MountData.heightBoost = 3;
            MountData.fallDamage = 0f;
            MountData.runSpeed = 5f;
            MountData.dashSpeed = 3f;
            MountData.flightTimeMax = 90;
            MountData.fatigueMax = 0;
            MountData.jumpHeight = 6;
            MountData.acceleration = 0.35f;
            MountData.jumpSpeed = 5f;
            MountData.blockExtraJumps = false;
            MountData.totalFrames = 11;
            MountData.constantJump = true;
            int[] array = new int[MountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 90;
            }
            MountData.playerYOffsets = array;
            MountData.xOffset = 18;
            MountData.bodyFrame = 6;
            MountData.yOffset = -38;
            MountData.playerHeadOffset = 0;
            MountData.standingFrameCount = 1;
            MountData.standingFrameDelay = 1;
            MountData.standingFrameStart = 0;
            MountData.runningFrameCount = 6;
            MountData.runningFrameDelay = 15;
            MountData.runningFrameStart = 1;
            MountData.flyingFrameCount = 3;
            MountData.flyingFrameDelay = 4;
            MountData.flyingFrameStart = 7;
            MountData.inAirFrameCount = 1;
            MountData.inAirFrameDelay = 8;
            MountData.inAirFrameStart = 10;
            MountData.idleFrameCount = 1;
            MountData.idleFrameDelay = 1;
            MountData.idleFrameStart = 0;
            MountData.idleFrameLoop = false;
            MountData.swimFrameCount = 1;
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
        }
    }
}