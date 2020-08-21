using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts
{
    public class ProfanedCycle : ModMountData
    {
        public override void SetDefaults()
        {
            //mountData.spawnDust = mod.DustType("Smoke");
            mountData.buff = mod.BuffType("BikeBuff");
            mountData.heightBoost = 20;
            mountData.fallDamage = 0.1f;
            mountData.runSpeed = 25f;
            mountData.dashSpeed = 9f;
            mountData.flightTimeMax = 0;
            mountData.fatigueMax = 0;
            mountData.jumpHeight = 25;
            mountData.acceleration = 0.30f;
            mountData.jumpSpeed = 6f;
            mountData.blockExtraJumps = false;
            mountData.totalFrames = 13;
            mountData.constantJump = true;
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
            mountData.standingFrameCount = 4;
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
            mountData.inAirFrameStart = 11;
            mountData.idleFrameCount = 4;
            mountData.idleFrameDelay = 12;
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

        public override void UpdateEffects(Player player)
        {
            if ((Math.Abs(player.velocity.X) > 20))
            {
                mountData.runningFrameCount = 4;
                mountData.runningFrameDelay = 65;
                mountData.runningFrameStart = 8;
                mountData.inAirFrameCount = 1;
                mountData.inAirFrameDelay = 12;
                mountData.inAirFrameStart = 12;
                mountData.runSpeed = 25f;
                mountData.acceleration = 0.25f;

                if (player.whoAmI == Main.myPlayer)
                    Dust.NewDust(player.position, 47, 30, 6, 3.684211f, 0f, 0, new Color(255, 255, 255), 1f);
            }
            else
            {
                mountData.runningFrameCount = 4;
                mountData.runningFrameDelay = 65;
                mountData.runningFrameStart = 4;
                mountData.inAirFrameCount = 1;
                mountData.inAirFrameDelay = 12;
                mountData.inAirFrameStart = 11;
                mountData.runSpeed = 25f;
            }
        }
    }
}