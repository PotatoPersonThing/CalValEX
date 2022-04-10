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
            Main.projFrames[projectile.type] = 13;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 126;
            projectile.height = 74;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            drawOriginOffsetY = 2;
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
                    if (projectile.velocity.X != 0f)
                    {
                        if (++projectile.frameCounter > 8)
                        {
                            projectile.frameCounter = 0;
                            projectile.frame++;
                            if (projectile.frame > 1)
                                projectile.frame = 0;
                        }
                    }
                    break;

                case States.Flying:
                    if (++projectile.frameCounter > 8)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;
                        if (projectile.frame > 5 || projectile.frame < 2)
                            projectile.frame = 2;
                    }
                    break;
            }
        }

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
                projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float walkingSpeed, float walkingInertia, float flyingSpeed, float flyingInertia)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            for (int x = 0; x < Main.maxNPCs; x++)
            {
                NPC npc = Main.npc[x];
                if (npc.type == calamityMod.NPCType("Signus") && npc.life == 1 && npc.active)
                {
                    sigdirection = npc.spriteDirection;
                    sigposx = npc.Center.X;
                    sigposy = npc.position.Y;
                    signut = true;
                    //projectile.frame = 6;
                    state = 3;
                    break;
                }
            }

            if (state == 3 && !finished && !Program.IsServer)
            {
                projectile.tileCollide = false;
                projectile.rotation = 0;
                //Framing
                if (sigcounter < basetime + 6)
                {
                    projectile.frame = 6;
                    projectile.velocity = Vector2.Zero;
                    projectile.netUpdate = true;
                }
                else if (sigcounter >= basetime + 6 && sigcounter < basetime + 12)
                {
                    projectile.frame = 7;
                }
                else if (sigcounter >= basetime + 12 && sigcounter < basetime + 18)
                {
                    projectile.frame = 8;
                }
                else if (sigcounter >= basetime + 18 && sigcounter < basetime + 24)
                {
                    projectile.frame = 9;
                }
                else if (sigcounter >= basetime + 24 && sigcounter < basetime + 30)
                {
                    projectile.frame = 10;
                }
                else if (sigcounter > basetime + 30 && sigcounter <= basetime + 40)
                {
                    projectile.frame = 11;
                }
                else if (sigcounter > basetime + 40 && sigcounter <= basetime + 50)
                {
                    projectile.frame = 12;
                }
                else
                {
                    projectile.frame = 6;
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
                                Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, 0f, 0f, 0, new Color(255, 255, 255), 1.4f);
                            }
                            if (sigcounter > 0)
                            {
                                dust = true;
                            }
                        }
                    }
                    if (!teleported)
                    {
                        projectile.direction = sigdirection;
                        projectile.spriteDirection = sigdirection;
                        projectile.position.Y = sigposy + 5;
                        projectile.position.X = sigposx + 40; // (sigdirection == -1 ? 40 : -200);
                        teleported = true;
                    }
                    projectile.velocity.Y = -0.1f;
                    gravity = 0f;
                }
                else if (sigcounter > basetime + 30 && sigcounter <= basetime + 40)
                {
                    if (!sound)
                    {
                        Main.PlaySound(SoundID.Item109);
                        sound = true;
                    }
                    projectile.velocity.X = 20 * sigdirection;
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
                projectile.velocity.Y += gravity;
                if (projectile.velocity.Y > 16)
                    projectile.velocity.Y = 16;
            }
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowMask = mod.GetTexture("Projectiles/Pets/Junko_Glow");
            Rectangle frame = glowMask.Frame(1, Main.projFrames[projectile.type], 0, projectile.frame);
            frame.Height -= 1;
            float originOffsetX = (glowMask.Width - projectile.width) * 0.5f + projectile.width * 0.5f + drawOriginOffsetX;
            spriteBatch.Draw
            (
                glowMask,
                projectile.position - Main.screenPosition + new Vector2(originOffsetX + drawOffsetX, projectile.height / 2 + projectile.gfxOffY),
                frame,
                Color.White,
                projectile.rotation,
                new Vector2(originOffsetX, projectile.height / 2 - drawOriginOffsetY),
                projectile.scale,
                projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                0f
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