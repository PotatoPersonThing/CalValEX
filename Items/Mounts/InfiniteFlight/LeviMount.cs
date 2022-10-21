using Terraria;
using Terraria.ModLoader;
using CalValEX.Buffs.Mounts;
using System.Linq;

namespace CalValEX.Items.Mounts.InfiniteFlight {
    public class LeviMount : ModMount {
        public override void SetStaticDefaults() {
            MountData.acceleration = 0.17f;
            MountData.jumpHeight = 5;
            MountData.jumpSpeed = 2f;
            MountData.blockExtraJumps = false;
            MountData.usesHover = true;
            MountData.heightBoost = 4;
            MountData.fallDamage = 0f;
            MountData.runSpeed = 6f;
            MountData.dashSpeed = 6f;
            MountData.flightTimeMax = int.MaxValue - 1;

            MountData.fatigueMax = int.MaxValue - 1;
            MountData.buff = ModContent.BuffType<LeviathanMountBuff>();

            MountData.spawnDust = 33;
            MountData.spawnDustNoGravity = true;

            MountData.totalFrames = 12;
            MountData.playerYOffsets = Enumerable.Repeat(20, MountData.totalFrames).ToArray();
            MountData.xOffset = 6;
            MountData.yOffset = 12;
            MountData.playerHeadOffset = 0;
            MountData.bodyFrame = 6;

            MountData.flyingFrameCount = MountData.inAirFrameCount = MountData.idleFrameCount = MountData.swimFrameCount = 6;
            MountData.flyingFrameDelay = MountData.inAirFrameDelay = MountData.idleFrameDelay = MountData.swimFrameDelay = 8;
            MountData.flyingFrameStart = MountData.inAirFrameStart = MountData.swimFrameStart = 6;
            MountData.idleFrameStart = 0;
            MountData.idleFrameLoop = true;

            if (!Main.dedServ) {
                MountData.textureWidth = MountData.backTexture.Width();
                MountData.textureHeight = MountData.backTexture.Height();
            }
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