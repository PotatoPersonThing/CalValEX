using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.Ground
{
    public class BloodstoneCarriage : ModMount
    {
        public override void SetStaticDefaults()
        {
            MountData.buff = ModContent.BuffType<Buffs.Mounts.BloodstoneCarriageBuff>();
            MountData.heightBoost = 6;
            MountData.fallDamage = 0f;
            MountData.runSpeed = 11f;
            MountData.dashSpeed = 3f;
            MountData.flightTimeMax = 0;
            MountData.fatigueMax = 0;
            MountData.jumpHeight = 12;
            MountData.acceleration = 0.1f;
            MountData.jumpSpeed = 2f;
            MountData.blockExtraJumps = false;
            MountData.totalFrames = 1;
            MountData.constantJump = true;
            MountData.spawnDust = 6;
            int[] array = new int[MountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 31;
            }
            MountData.playerYOffsets = array;
            MountData.xOffset = 4;
            MountData.bodyFrame = 3;
            MountData.yOffset = -19;
            MountData.playerHeadOffset = 0;
            MountData.standingFrameCount = 1;
            MountData.standingFrameDelay = 1;
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
            MountData.inAirFrameDelay = 1;
            MountData.inAirFrameStart = 0;
            MountData.idleFrameCount = 1;
            MountData.idleFrameDelay = 1;
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
        /*public override bool Draw(List<DrawData> playerDrawData, int drawType, Player drawPlayer, ref Texture2D texture, ref Texture2D glowTexture, ref Vector2 drawPosition, ref Rectangle frame, ref Color drawColor, ref Color glowColor, ref float rotation, ref SpriteEffects spriteEffects, ref Vector2 drawOrigin, ref float drawScale, float shadow)
        {
            return true;
        }*/
    }
}