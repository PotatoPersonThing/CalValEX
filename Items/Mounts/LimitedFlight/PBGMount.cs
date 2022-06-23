using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.LimitedFlight
{
    public class PBGMount : ModMount
    {
        public override void SetStaticDefaults()
        {
            MountData.buff =ModContent.BuffType<Buffs.Mounts.PBGMountBuff>();
            MountData.heightBoost = 5;
            MountData.fallDamage = 0f;
            MountData.runSpeed = 7f;
            MountData.dashSpeed = 3f;
            MountData.flightTimeMax = 195;
            MountData.fatigueMax = 0;
            MountData.jumpHeight = 6;
            MountData.acceleration = 0.35f;
            //Mod calamityMod = ModLoader.GetMod("CalamityMod");
            //MountData.spawnDust = calamityMod.DustType("BloomTileLeaves");
            MountData.jumpSpeed = 5f;
            MountData.blockExtraJumps = false;
            MountData.totalFrames = 12;
            MountData.constantJump = true;
            int[] array = new int[MountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 9; // (increase this?)
            }
            MountData.playerYOffsets = array;
            MountData.xOffset = 4;
            MountData.bodyFrame = 6;
            MountData.yOffset = 4;
            MountData.playerHeadOffset = 0;
            MountData.standingFrameCount = 1;
            MountData.standingFrameDelay = 1;
            MountData.standingFrameStart = 0;
            MountData.runningFrameCount = 4;
            MountData.runningFrameDelay = 15;
            MountData.runningFrameStart = 1;
            // if (Main.player.velocity.X = MountData.runSpeed) {
            // MountData.runningFrameCount = 1;
            // MountData.runningFrameDelay = 12;
            // MountData.runningFrameStart = 8;
            // } I forgot what this is for
            MountData.flyingFrameCount = 3;
            MountData.flyingFrameDelay = 8;
            MountData.flyingFrameStart = 5;
            MountData.inAirFrameCount = 4;
            MountData.inAirFrameDelay = 8;
            MountData.inAirFrameStart = 8;
            MountData.idleFrameCount = 1;
            MountData.idleFrameDelay = 1;
            MountData.idleFrameStart = 4;
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
    }
}