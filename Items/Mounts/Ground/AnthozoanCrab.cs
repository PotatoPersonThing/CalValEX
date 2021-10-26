using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.Ground
{
    public class AnthozoanCrab : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.buff = mod.BuffType("AnthozoanBuff");
            mountData.heightBoost = 0;
            mountData.fallDamage = 0f;
            mountData.runSpeed = 4f;
            mountData.dashSpeed = 2f;
            mountData.flightTimeMax = 0;
            mountData.fatigueMax = 0;
            mountData.jumpHeight = 4;
            mountData.acceleration = 0.2f;
            mountData.jumpSpeed = 10f;
            mountData.blockExtraJumps = false;
            mountData.totalFrames = 4;
            mountData.constantJump = true;
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            mountData.spawnDust = 75;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 12;
            }
            mountData.playerYOffsets = array;
            mountData.xOffset = 15;
            mountData.bodyFrame = 3;
            mountData.yOffset = 4;
            mountData.playerHeadOffset = 0;
            mountData.standingFrameCount = 1;
            mountData.standingFrameDelay = 12;
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
            mountData.inAirFrameDelay = 12;
            mountData.inAirFrameStart = 1;
            mountData.idleFrameCount = 1;
            mountData.idleFrameDelay = 12;
            mountData.idleFrameStart = 0;
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
        public override void UpdateEffects(Player player)
        {
            if (player.wet)
            {
                mountData.runSpeed = 10f;
                mountData.acceleration = 0.6f;
                mountData.jumpHeight = 0;
                mountData.jumpSpeed = 0f;
                mountData.flightTimeMax = int.MaxValue - 1;
                mountData.fatigueMax = int.MaxValue - 1;
                mountData.usesHover = true;
            }
            else
            {
                mountData.jumpHeight = 5;
                mountData.acceleration = 0.2f;
                mountData.jumpSpeed = 4f;
                mountData.runSpeed = 4f;
                mountData.flightTimeMax = 0;
                mountData.fatigueMax = 0;
                mountData.usesHover = false;
            }
        }
    }
}