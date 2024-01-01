using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.Ground
{
    public class GoDrider : ModMount
    {
        public override void SetStaticDefaults()
        {
            MountData.buff = ModContent.BuffType<Buffs.Mounts.GodRiderBuff>();
            MountData.heightBoost = 25;
            MountData.fallDamage = 0f;
            MountData.runSpeed = 16f;
            MountData.dashSpeed = 7f;
            MountData.flightTimeMax = 1;
            MountData.fatigueMax = 0;
            MountData.jumpHeight = 25;
            MountData.acceleration = 0.1f;
            MountData.jumpSpeed = 4f;
            MountData.blockExtraJumps = false;
            MountData.totalFrames = 1;
            MountData.constantJump = true;
            //Mod calamityMod = ModLoader.GetMod("CalamityMod");
            MountData.spawnDust = 173;
            int[] array = new int[MountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 27;
            }
            MountData.playerYOffsets = array;
            MountData.xOffset = 4;
            MountData.bodyFrame = 3;
            MountData.yOffset = 6;
            MountData.playerHeadOffset = 0;
            MountData.standingFrameCount = 1;
            MountData.standingFrameDelay = 12;
            MountData.standingFrameStart = 0;
            // MountData.runningFrameCount = 4;
            // MountData.runningFrameDelay = 65;
            // MountData.runningFrameStart = 4;
            // if (Main.player.velocity.X = MountData.runSpeed) {
            // MountData.runningFrameCount = 1;
            // MountData.runningFrameDelay = 12;
            // MountData.runningFrameStart = 8;
            // }
            MountData.flyingFrameCount = 1;
            MountData.flyingFrameDelay = 0;
            MountData.flyingFrameStart = 0;
            MountData.inAirFrameCount = 1;
            MountData.inAirFrameDelay = 12;
            MountData.inAirFrameStart = 0;
            MountData.idleFrameCount = 1;
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