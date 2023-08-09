using CalValEX.Buffs.LightPets;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.Ground
{
    public class WulfrumTractor : ModMount
    {
        public override void SetStaticDefaults()
        {
            //MountData.spawnDust = mod.DustType("Smoke");
            MountData.buff = ModContent.BuffType<Buffs.Mounts.TractorMount>();
            MountData.heightBoost = 20;
            MountData.fallDamage = 0.1f;
            MountData.runSpeed = 5;
            MountData.dashSpeed = 2f;
            MountData.flightTimeMax = 0;
            MountData.fatigueMax = 0;
            MountData.jumpHeight = 8;
            MountData.acceleration = 0.04f;
            MountData.jumpSpeed = 4f;
            MountData.blockExtraJumps = false;
            MountData.totalFrames = 10;
            MountData.constantJump = true;
            int[] array = new int[MountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 17;
            }
            MountData.playerYOffsets = array;
            MountData.xOffset = 4;
            MountData.bodyFrame = 3;
            MountData.yOffset = 14;
            MountData.playerHeadOffset = 0;
            MountData.standingFrameCount = 0;
            MountData.standingFrameDelay = 0;
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
            MountData.flyingFrameStart = 4;
            MountData.inAirFrameCount = 1;
            MountData.inAirFrameDelay = 12;
            MountData.inAirFrameStart = 4;
            MountData.idleFrameCount = 4;
            MountData.idleFrameDelay = 12;
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

        public override void UpdateEffects(Player player)
        {
            MountData.heightBoost = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 22 : 20);
            MountData.fallDamage = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 0.04f : 0.1f);
            MountData.runSpeed = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 7 : 5);
            MountData.dashSpeed = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 3.5f : 2f);
            MountData.jumpHeight = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 9 : 8);
            MountData.acceleration = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 0.05f : 0.04f);
            MountData.jumpSpeed = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 5f : 4f);
            MountData.flyingFrameStart = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 9 : 4);
            MountData.inAirFrameStart = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 9 : 4);
            MountData.idleFrameStart = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 5 : 0);
            MountData.standingFrameStart = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 5 : 0);
            if ((Math.Abs(player.velocity.X) > 20))
            {
                MountData.runningFrameCount = 4;
                MountData.runningFrameDelay = 12;
                MountData.runningFrameStart = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 5 : 0);
                MountData.inAirFrameCount = 1;
                MountData.inAirFrameDelay = 12;
                MountData.inAirFrameStart = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 9 : 4);
                MountData.runSpeed = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 9 : 7);
                MountData.acceleration = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 0.06f : 0.05f);
            }
            else
            {
                MountData.runningFrameCount = 4;
                MountData.runningFrameDelay = 12;
                MountData.runningFrameStart = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 5 : 0);
                MountData.inAirFrameCount = 1;
                MountData.inAirFrameDelay = 12;
                MountData.inAirFrameStart = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 9 : 4);
                MountData.runSpeed = (player.HasBuff(ModContent.BuffType<PylonBuff>()) ? 9 : 7);
            }
        }
    }
}