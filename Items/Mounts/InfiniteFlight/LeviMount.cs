using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Buffs.Mounts;

namespace CalValEX.Items.Mounts.InfiniteFlight {
    public class LeviMount : ModMount {
        public override void SetStaticDefaults() {
            MountData.buff = ModContent.BuffType<LeviathanMountBuff>();
            MountData.heightBoost = 4;
            MountData.fallDamage = 0f;
            MountData.runSpeed = 6f;
            MountData.dashSpeed = 6f;
            MountData.flightTimeMax = int.MaxValue - 1;
            MountData.fatigueMax = int.MaxValue - 1;
            MountData.jumpHeight = 5;
            MountData.usesHover = true;
            MountData.acceleration = 0.17f;
            MountData.jumpSpeed = 2f;
            MountData.blockExtraJumps = false;
            MountData.totalFrames = 8;
            MountData.spawnDust = 33;
            MountData.spawnDustNoGravity = true;
            int[] array = new int[MountData.totalFrames];
            for (int l = 0; l < array.Length; l++) {
                array[l] = 12; // (increase this?)
            }
            MountData.playerYOffsets = array;
            MountData.xOffset = -5;
            MountData.bodyFrame = 6;
            MountData.yOffset = 30;
            MountData.playerHeadOffset = 0;
            MountData.standingFrameCount = 6;
            MountData.standingFrameDelay = 8;
            MountData.standingFrameStart = 0;
            MountData.runningFrameCount = 6;
            MountData.runningFrameDelay = 8;
            MountData.runningFrameStart = 0;
            // if (Main.player.velocity.X = MountData.runSpeed) {
            // MountData.runningFrameCount = 1;
            // MountData.runningFrameDelay = 12;
            // MountData.runningFrameStart = 8;
            // } I forgot what this is for
            MountData.flyingFrameCount = 6;
            MountData.flyingFrameDelay = 6;
            MountData.flyingFrameStart = 0;
            MountData.inAirFrameCount = 6;
            MountData.inAirFrameDelay = 7;
            MountData.inAirFrameStart = 0;
            MountData.idleFrameCount = 6;
            MountData.idleFrameDelay = 8;
            MountData.idleFrameStart = 0;
            MountData.idleFrameLoop = true;
            MountData.swimFrameCount = 6;
            MountData.swimFrameDelay = 20;
            MountData.swimFrameStart = 0;
            if (Main.netMode == NetmodeID.Server) {
                return;
            }

            MountData.textureWidth = MountData.frontTexture.Width();
            MountData.textureHeight = MountData.frontTexture.Height();
        }
        public override void UpdateEffects(Player player) {
            if (player.wet) {
                MountData.runSpeed = 18f;
                MountData.acceleration = 0.47f;
                MountData.jumpHeight = 6;
            } else {
                MountData.jumpHeight = 5;
                MountData.acceleration = 0.17f;
                MountData.jumpSpeed = 2f;
                MountData.runSpeed = 6f;
            }
        }
    }
}