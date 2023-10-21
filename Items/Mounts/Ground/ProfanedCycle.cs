using CalamityMod.Particles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.Ground
{
    public class ProfanedCycle : ModMount
    {
        public override void SetStaticDefaults()
        {
            MountData.buff = ModContent.BuffType<Buffs.Mounts.BikeBuff>();
            MountData.heightBoost = 15;
            MountData.fallDamage = 0f;
            MountData.runSpeed = 20f;
            MountData.dashSpeed = 7f;
            MountData.flightTimeMax = 0;
            MountData.fatigueMax = 0;
            MountData.jumpHeight = 15;
            MountData.acceleration = 0.1f;
            MountData.jumpSpeed = 4f;
            MountData.blockExtraJumps = false;
            MountData.totalFrames = 13;
            MountData.constantJump = true;
            //Mod calamityMod = ModLoader.GetMod("CalamityMod");
            //MountData.spawnDust = calamityMod.DustType("HolyFireDust");
            int[] array = new int[MountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 17;
            }
            MountData.playerYOffsets = array;
            MountData.xOffset = 4;
            MountData.bodyFrame = 3;
            MountData.yOffset = 6;
            MountData.playerHeadOffset = 0;
            MountData.standingFrameCount = 4;
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
            MountData.inAirFrameStart = 11;
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
            if (Math.Abs(player.velocity.X) > 20 || player.GetModPlayer<CalValEXPlayer>().bikeShred)
            {
                MountData.runningFrameCount = 4;
                MountData.runningFrameDelay = 65;
                MountData.runningFrameStart = 8;
                MountData.inAirFrameCount = 1;
                MountData.inAirFrameDelay = 12;
                MountData.inAirFrameStart = 12;
                MountData.runSpeed = 20f;
                MountData.acceleration = 0.11f;

                if (Math.Abs(player.velocity.X) > 20)
                {
                    if (player.whoAmI == Main.myPlayer)
                    Dust.NewDust(player.position, 47, 30, 6, 3.684211f, 0f, 0, new Color(255, 255, 255), 1f);
                }
            }
            else
            {
                MountData.runningFrameCount = 4;
                MountData.runningFrameDelay = 65;
                MountData.runningFrameStart = 4;
                MountData.inAirFrameCount = 1;
                MountData.inAirFrameDelay = 12;
                MountData.inAirFrameStart = 11;
                MountData.runSpeed = 20f;
            }
        }
    }
}