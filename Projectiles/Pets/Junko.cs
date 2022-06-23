using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;

namespace CalValEX.Projectiles.Pets
{
    public class Junko : ModWalkingPet
    {
        public override float TeleportThreshold => 2400f;

        public override float WalkingSpeed => 10f;

        public override bool HasGravity => false;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Lil Junko");
            Main.projFrames[Projectile.type] = 13;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 126;
            Projectile.height = 74;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            DrawOriginOffsetY = 2;
        }
        public override void ModifyJumpHeight(ref float oneTileHigherAndNotTwoTilesHigher, ref float twoTilesHigher, ref float fourTilesHigher, ref float fiveTilesHigher, ref float anyOtherJump)
        {
            oneTileHigherAndNotTwoTilesHigher = -6f;
            twoTilesHigher = -8f;
            fiveTilesHigher = -12f;
            fourTilesHigher = -10f;
            anyOtherJump = -8.75f;
        }

        public override void Animation(int state)
        {
            switch(state)
            {
                case States.Walking:
                    if (Projectile.velocity.X != 0f)
                    {
                        if (++Projectile.frameCounter > 8)
                        {
                            Projectile.frameCounter = 0;
                            Projectile.frame++;
                            if (Projectile.frame > 1)
                                Projectile.frame = 0;
                        }
                    }
                    break;

                case States.Flying:
                    if (++Projectile.frameCounter > 8)
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame++;
                        if (Projectile.frame > 5 || Projectile.frame < 2)
                            Projectile.frame = 2;
                    }
                    break;
            }
        }

        //I NEED to clean up this abomination some day lmao
        int sigcounter;
        int basetime = 30;
        private bool signut = false;
        private bool dust = false;
        private bool sound = false;
        private bool finished = false;
        private bool teleported = false;
        float sigposx;
        float sigposy;
        int sigdirection;
        float gravity;

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.junsi = false;

            if (modPlayer.junsi)
                Projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float walkingSpeed, float walkingInertia, float flyingSpeed, float flyingInertia)
        {
            if (!NPC.AnyNPCs(ModContent.NPCType<CalamityMod.NPCs.Signus.Signus>()) && state == 3)
            {
                state = 2;
                gravity = 0.4f;
                finished = true;
            }
            for (int x = 0; x < Main.maxNPCs; x++)
            {
                NPC npc = Main.npc[x];
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Signus.Signus>() && npc.life == 1 && npc.active)
                {
                    sigdirection = npc.spriteDirection;
                    sigposx = npc.Center.X;
                    sigposy = npc.position.Y;
                    signut = true;
                    //Projectile.frame = 6;
                    state = 3;
                    break;
                }
            }

            if (state == 3 && !finished)
            {
                Projectile.tileCollide = false;
                Projectile.rotation = 0;
                //Framing
                if (sigcounter < basetime + 6)
                {
                    Projectile.frame = 6;
                    Projectile.velocity = Vector2.Zero;
                    Projectile.netUpdate = true;
                }
                else if (sigcounter >= basetime + 6 && sigcounter < basetime + 12)
                {
                    Projectile.frame = 7;
                }
                else if (sigcounter >= basetime + 12 && sigcounter < basetime + 18)
                {
                    Projectile.frame = 8;
                }
                else if (sigcounter >= basetime + 18 && sigcounter < basetime + 24)
                {
                    Projectile.frame = 9;
                }
                else if (sigcounter >= basetime + 24 && sigcounter < basetime + 30)
                {
                    Projectile.frame = 10;
                }
                else if (sigcounter > basetime + 30 && sigcounter <= basetime + 40)
                {
                    Projectile.frame = 11;
                }
                else if (sigcounter > basetime + 40 && sigcounter <= basetime + 50)
                {
                    Projectile.frame = 12;
                }
                else
                {
                    Projectile.frame = 6;
                }
                //Attack
                if (sigcounter <= basetime + 30)
                {
                    if (sigcounter == 0 || sigcounter == 1)
                    {
                        if (!dust)
                        {
                            for (int a = 0; a < 20; a++)
                            {
                                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 173, 0f, 0f, 0, new Color(255, 255, 255), 1.4f);
                            }
                            if (sigcounter > 0)
                            {
                                dust = true;
                            }
                        }
                    }
                    if (!teleported)
                    {
                        Projectile.direction = sigdirection;
                        Projectile.spriteDirection = sigdirection;
                        Projectile.position.Y = sigposy + 5;
                        Projectile.position.X = sigposx + 40; // (sigdirection == -1 ? 40 : -200);
                        teleported = true;
                    }
                    Projectile.velocity.Y = -0.1f;
                    gravity = 0f;
                }
                else if (sigcounter > basetime + 30 && sigcounter <= basetime + 40)
                {
                    if (!sound)
                    {
                        Terraria.Audio.SoundEngine.PlaySound(SoundID.Item109, Projectile.Center);
                        sound = true;
                    }
                    Projectile.velocity.X = 20 * sigdirection;
                    gravity = 0.05f * sigcounter;
                }
                else if (sigcounter > basetime + 50)
                {
                    state = 2;
                    gravity = 0.4f;
                    finished = true;
                }
                else
                {
                    state = 2;
                }
                if (finished)
                {
                    state = 2;
                }
            }
            if (state == 3 && finished)
            {
                state = 2;
            }
            if (state != 3)
            {
                sigcounter = -1;
                dust = false;
                signut = false;
                sound = false;
                finished = false;
                teleported = false;
                gravity = 0.4f;
            }
            if (signut)
            {
                sigcounter++;
            }
        }

        public override void PostAI()
        {
            if (state == States.Walking)
            {
                Projectile.velocity.Y += gravity;
                if (Projectile.velocity.Y > 16)
                    Projectile.velocity.Y = 16;
            }
        }

        public override void PostDraw(Color lightColor)
        {
            Texture2D glowMask = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/Junko_Glow").Value;
            Rectangle frame = glowMask.Frame(1, Main.projFrames[Projectile.type], 0, Projectile.frame);
            frame.Height -= 1;
            float originOffsetX = (glowMask.Width - Projectile.width) * 0.5f + Projectile.width * 0.5f + DrawOriginOffsetX;
            Main.EntitySpriteDraw
            (
                glowMask,
                Projectile.position - Main.screenPosition + new Vector2(originOffsetX + DrawOffsetX, Projectile.height / 2 + Projectile.gfxOffY),
                frame,
                Color.White,
                Projectile.rotation,
                new Vector2(originOffsetX, Projectile.height / 2 - DrawOriginOffsetY),
                Projectile.scale,
                Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                0
            );
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(sigcounter);
            writer.Write(basetime);
            writer.Write(sigdirection);
            writer.Write(sigposx);
            writer.Write(sigposy);
            writer.Write(signut);
            writer.Write(dust);
            writer.Write(sound);
            writer.Write(teleported);
            writer.Write(finished);
            base.SendExtraAI(writer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            signut = reader.ReadBoolean();
            dust = reader.ReadBoolean();
            sound = reader.ReadBoolean();
            teleported = reader.ReadBoolean();
            finished = reader.ReadBoolean();
            sigcounter = reader.ReadInt32();
            basetime = reader.ReadInt32();
            sigdirection = reader.ReadInt32();
            sigposx = reader.ReadInt32();
            sigposy = reader.ReadInt32();
            base.ReceiveExtraAI(reader);
        }
    }
}