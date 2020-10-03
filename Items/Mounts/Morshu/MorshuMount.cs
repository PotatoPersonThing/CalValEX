using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.Morshu
{
    public class MorshuMount : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.buff = ModContent.BuffType<MorshuBuff>();
            mountData.heightBoost = 94;
			mountData.flightTimeMax = 0;
			mountData.fallDamage = 0.5f;
			mountData.runSpeed = 8f;
			mountData.dashSpeed = 8f;
			mountData.acceleration = 0.35f;
			mountData.jumpHeight = 18;
			mountData.jumpSpeed = 8.25f;
			mountData.constantJump = true;
			mountData.totalFrames = 4;
			int[] array = new int[mountData.totalFrames];
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = 94;
			}
			mountData.playerYOffsets = array;
			mountData.xOffset = 30;
			mountData.bodyFrame = 3;
			mountData.yOffset = 0;
			mountData.playerHeadOffset = 94;
			mountData.standingFrameCount = 1;
			mountData.standingFrameDelay = 12;
			mountData.standingFrameStart = 0;
			mountData.runningFrameCount = 4;
			mountData.runningFrameDelay = 60;
			mountData.runningFrameStart = 0;
			mountData.flyingFrameCount = 0;
			mountData.flyingFrameDelay = 0;
			mountData.flyingFrameStart = 0;
			mountData.inAirFrameCount = 1;
			mountData.inAirFrameDelay = 12;
			mountData.inAirFrameStart = 3;
			mountData.idleFrameCount = 0;
			mountData.idleFrameDelay = 0;
			mountData.idleFrameStart = 0;

			if (Main.netMode == NetmodeID.Server)
			{
				return;
			}

			mountData.textureWidth = mountData.backTexture.Width;
			mountData.textureHeight = mountData.backTexture.Height;
		}

        public override void UpdateEffects(Player player)
        {
			if (player.wet)
            {
				if (player.velocity.Y >= 0)
					player.velocity.Y = -4.5f;
            }
        }
    }
}
