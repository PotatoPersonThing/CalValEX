using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.Ground
{
    public class AnthozoanCrab : ModMount
    {
        public override void SetStaticDefaults()
        {
            MountData.buff = ModContent.BuffType<Buffs.Mounts.AnthozoanBuff>();
            MountData.heightBoost = 0;
            MountData.fallDamage = 0f;
            MountData.runSpeed = 4f;
            MountData.dashSpeed = 2f;
            MountData.flightTimeMax = 0;
            MountData.fatigueMax = 0;
            MountData.jumpHeight = 4;
            MountData.acceleration = 0.2f;
            MountData.jumpSpeed = 10f;
            MountData.blockExtraJumps = false;
            MountData.totalFrames = 4;
            MountData.constantJump = true;
            //Mod calamityMod = ModLoader.GetMod("CalamityMod");
            MountData.spawnDust = 75;
            int[] array = new int[MountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 12;
            }
            MountData.playerYOffsets = array;
            MountData.xOffset = 15;
            MountData.bodyFrame = 3;
            MountData.yOffset = 4;
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
            MountData.flyingFrameCount = 0;
            MountData.flyingFrameDelay = 0;
            MountData.flyingFrameStart = 0;
            MountData.inAirFrameCount = 1;
            MountData.inAirFrameDelay = 12;
            MountData.inAirFrameStart = 1;
            MountData.idleFrameCount = 1;
            MountData.idleFrameDelay = 12;
            MountData.idleFrameStart = 0;
            MountData.runningFrameCount = 4;
            MountData.runningFrameDelay = 12;
            MountData.runningFrameStart = 0;
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
        public override void UpdateEffects(Player player)
        {
            if (player.wet)
            {
                MountData.runSpeed = 10f;
                MountData.acceleration = 0.6f;
                MountData.jumpHeight = 0;
                MountData.jumpSpeed = 0f;
                MountData.flightTimeMax = int.MaxValue - 1;
                MountData.fatigueMax = int.MaxValue - 1;
                MountData.usesHover = true;
            }
            else
            {
                MountData.jumpHeight = 5;
                MountData.acceleration = 0.2f;
                MountData.jumpSpeed = 4f;
                MountData.runSpeed = 4f;
                MountData.flightTimeMax = 0;
                MountData.fatigueMax = 0;
                MountData.usesHover = false;
            }
        }
    }
}