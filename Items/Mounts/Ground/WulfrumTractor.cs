using CalValEX.Buffs.LightPets;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.Ground
{
    public class WulfrumTractor : ModMountData
    {
        public override void SetDefaults()
        {
            //mountData.spawnDust = mod.DustType("Smoke");
            mountData.buff = mod.BuffType("TractorMount");
            mountData.heightBoost = 20;
            mountData.fallDamage = 0.1f;
            mountData.runSpeed = 5;
            mountData.dashSpeed = 2f;
            mountData.flightTimeMax = 0;
            mountData.fatigueMax = 0;
            mountData.jumpHeight = 8;
            mountData.acceleration = 0.04f;
            mountData.jumpSpeed = 4f;
            mountData.blockExtraJumps = false;
            mountData.totalFrames = 10;
            mountData.constantJump = true;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 17;
            }
            mountData.playerYOffsets = array;
            mountData.xOffset = 4;
            mountData.bodyFrame = 3;
            mountData.yOffset = 16;
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
            mountData.flyingFrameStart = 4;
            mountData.inAirFrameCount = 1;
            mountData.inAirFrameDelay = 12;
            mountData.inAirFrameStart = 4;
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
            mountData.heightBoost = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 22 : 20);
            mountData.fallDamage = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 0.04f : 0.1f);
            mountData.runSpeed = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 7 : 5);
            mountData.dashSpeed = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 3.5f : 2f);
            mountData.jumpHeight = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 9 : 8);
            mountData.acceleration = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 0.05f : 0.04f);
            mountData.jumpSpeed = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 5f : 4f);
            mountData.flyingFrameStart = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 9 : 4);
            mountData.inAirFrameStart = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 9 : 4);
            mountData.idleFrameStart = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 5 : 0);
            mountData.standingFrameStart = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 5 : 0);
            if ((Math.Abs(player.velocity.X) > 20))
            {
                mountData.runningFrameCount = 4;
                mountData.runningFrameDelay = 12;
                mountData.runningFrameStart = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 5 : 0);
                mountData.inAirFrameCount = 1;
                mountData.inAirFrameDelay = 12;
                mountData.inAirFrameStart = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 9 : 4);
                mountData.runSpeed = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 9 : 7);
                mountData.acceleration = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 0.06f : 0.05f);
            }
            else
            {
                mountData.runningFrameCount = 4;
                mountData.runningFrameDelay = 12;
                mountData.runningFrameStart = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 5 : 0);
                mountData.inAirFrameCount = 1;
                mountData.inAirFrameDelay = 12;
                mountData.inAirFrameStart = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 9 : 4);
                mountData.runSpeed = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 9 : 7);
            }
        }
    }
}