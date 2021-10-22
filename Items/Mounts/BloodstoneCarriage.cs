using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts
{
    public class BloodstoneCarriage : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.buff = mod.BuffType("BloodstoneCarriageBuff");
            mountData.heightBoost = 4;
            mountData.fallDamage = 0f;
            mountData.runSpeed = 15f;
            mountData.dashSpeed = 3f;
            mountData.flightTimeMax = 0;
            mountData.fatigueMax = 0;
            mountData.jumpHeight = 8;
            mountData.acceleration = 0.1f;
            mountData.jumpSpeed = 2f;
            mountData.blockExtraJumps = false;
            mountData.totalFrames = 1;
            mountData.constantJump = true;
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            //mountData.spawnDust = calamityMod.DustType("HolyFireDust");
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 17;
            }
            mountData.playerYOffsets = array;
            mountData.xOffset = 4;
            mountData.bodyFrame = 3;
            mountData.yOffset = 6;
            mountData.playerHeadOffset = 0;
            mountData.standingFrameCount = 1;
            mountData.standingFrameDelay = 1;
            mountData.standingFrameStart = 0;
            // mountData.runningFrameCount = 4;
            // mountData.runningFrameDelay = 65;
            // mountData.runningFrameStart = 4;
            // if (Main.player.velocity.X = mountData.runSpeed) {
            // mountData.runningFrameCount = 1;
            // mountData.runningFrameDelay = 12;
            // mountData.runningFrameStart = 8;
            // }
            mountData.flyingFrameCount = 0;
            mountData.flyingFrameDelay = 0;
            mountData.flyingFrameStart = 0;
            mountData.inAirFrameCount = 1;
            mountData.inAirFrameDelay = 1;
            mountData.inAirFrameStart = 1;
            mountData.idleFrameCount = 1;
            mountData.idleFrameDelay = 1;
            mountData.idleFrameStart = 0;
            mountData.idleFrameLoop = true;
            mountData.swimFrameCount = mountData.inAirFrameCount;
            mountData.swimFrameDelay = mountData.inAirFrameDelay;
            mountData.swimFrameStart = mountData.inAirFrameStart;
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            mountData.textureWidth = mountData.backTexture.Width;
            mountData.textureHeight = mountData.backTexture.Height;
        }
    }
}