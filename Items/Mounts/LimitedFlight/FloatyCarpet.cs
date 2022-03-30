using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.LimitedFlight
{
    public class FloatyCarpet : ModMount
    {
        public override void SetStaticDefaults()
        {
            MountData.buff =ModContent.BuffType<Buffs.Mounts.FloatyBuff>();
            MountData.heightBoost = -1;
            MountData.fallDamage = 0f;
            MountData.runSpeed = 3f;
            MountData.dashSpeed = 6f;
            MountData.flightTimeMax = 2;
            MountData.fatigueMax = 0;
            MountData.jumpHeight = 5;
            MountData.acceleration = 0.1f;
            MountData.jumpSpeed = 3f;
            MountData.blockExtraJumps = false;
            MountData.totalFrames = 7;
            MountData.constantJump = true;
            int[] array = new int[MountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 9; // (increase this?)
            }
            MountData.playerYOffsets = array;
            MountData.xOffset = 4;
            MountData.bodyFrame = 6;
            MountData.yOffset = 14;
            MountData.playerHeadOffset = 0;
            MountData.standingFrameCount = 1;
            MountData.standingFrameDelay = 1;
            MountData.standingFrameStart = 0;
            MountData.runningFrameCount = 5;
            MountData.runningFrameDelay = 60;
            MountData.runningFrameStart = 1;
            // if (Main.player.velocity.X = MountData.runSpeed) {
            // MountData.runningFrameCount = 1;
            // MountData.runningFrameDelay = 12;
            // MountData.runningFrameStart = 8;
            // } I forgot what this is for
            MountData.flyingFrameCount = 1;
            MountData.flyingFrameDelay = 1;
            MountData.flyingFrameStart = 0;
            MountData.inAirFrameCount = 1;
            MountData.inAirFrameDelay = 1;
            MountData.inAirFrameStart = 6;
            MountData.idleFrameCount = 1;
            MountData.idleFrameDelay = 1;
            MountData.idleFrameStart = 0;
            MountData.idleFrameLoop = false;
            MountData.swimFrameCount = 5;
            MountData.swimFrameDelay = 40;
            MountData.swimFrameStart = 1;
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            MountData.textureWidth = MountData.backTexture.Width();
            MountData.textureHeight = MountData.backTexture.Height();
        }

        // yo make this thing faster if the player is moist
        public override void UpdateEffects(Player player)
        {
            if (player.wet)
            {
                MountData.runSpeed = 10f;
                MountData.acceleration = 0.9f;
                MountData.jumpHeight = 27;
            }
            else
            {
                MountData.jumpHeight = 5;
                MountData.acceleration = 0.1f;
                MountData.jumpSpeed = 3f;
                MountData.runSpeed = 3f;
            }
        }
    }
}