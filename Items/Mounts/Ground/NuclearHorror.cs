using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.Ground
{
    public class NuclearHorror : ModMount
    {
        public override void SetStaticDefaults()
        {
            MountData.buff = ModContent.BuffType<Buffs.Mounts.NuclearHorrorBuff>();
            MountData.heightBoost = 20;
            MountData.fallDamage = 0f;
            MountData.runSpeed = 6f;
            MountData.dashSpeed = 3f;
            MountData.flightTimeMax = 0;
            MountData.fatigueMax = 0;
            MountData.jumpHeight = 20;
            MountData.acceleration = 0.1f;
            MountData.jumpSpeed = 11f;
            MountData.blockExtraJumps = false;
            MountData.totalFrames = 8;
            MountData.constantJump = true;
            //Mod calamityMod = ModLoader.GetMod("CalamityMod");
            MountData.spawnDust = 75;
            int[] array = new int[MountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 42;
            }
            MountData.playerYOffsets = array;
            MountData.xOffset = 11;
            MountData.bodyFrame = 3;
            MountData.yOffset = 1;
            MountData.playerHeadOffset = 0;
            MountData.standingFrameCount = 4;
            MountData.standingFrameDelay = 12;
            MountData.standingFrameStart = 4;
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
            MountData.idleFrameCount = 4;
            MountData.idleFrameDelay = 12;
            MountData.idleFrameStart = 4;
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
    }
}