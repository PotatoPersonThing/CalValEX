using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.Ground
{
    public class NuclearHorror : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.buff = mod.BuffType("NuclearHorrorBuff");
            mountData.heightBoost = 20;
            mountData.fallDamage = 0f;
            mountData.runSpeed = 6f;
            mountData.dashSpeed = 3f;
            mountData.flightTimeMax = 0;
            mountData.fatigueMax = 0;
            mountData.jumpHeight = 20;
            mountData.acceleration = 0.1f;
            mountData.jumpSpeed = 11f;
            mountData.blockExtraJumps = false;
            mountData.totalFrames = 8;
            mountData.constantJump = true;
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            mountData.spawnDust = 75;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 42;
            }
            mountData.playerYOffsets = array;
            mountData.xOffset = 11;
            mountData.bodyFrame = 3;
            mountData.yOffset = 1;
            mountData.playerHeadOffset = 0;
            mountData.standingFrameCount = 4;
            mountData.standingFrameDelay = 12;
            mountData.standingFrameStart = 4;
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
            mountData.inAirFrameDelay = 12;
            mountData.inAirFrameStart = 1;
            mountData.idleFrameCount = 4;
            mountData.idleFrameDelay = 12;
            mountData.idleFrameStart = 4;
            mountData.runningFrameCount = 4;
            mountData.runningFrameDelay = 12;
            mountData.runningFrameStart = 0;
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