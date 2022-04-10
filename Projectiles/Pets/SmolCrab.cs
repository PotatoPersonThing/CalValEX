using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;

namespace CalValEX.Projectiles.Pets
{
    public class SmolCrab : ModWalkingPet
    {
        public override bool FacesLeft => false;

        public override float WalkingSpeed => 10f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Smol Crab");
            Main.projFrames[projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 36;
            projectile.height = 40;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

        public override void ModifyJumpHeight(ref float oneTileHigherAndNotTwoTilesHigher, ref float twoTilesHigher, ref float fourTilesHigher, ref float fiveTilesHigher, ref float anyOtherJump)
        {
            oneTileHigherAndNotTwoTilesHigher = -4f;
            twoTilesHigher = -6f;
            fiveTilesHigher = -8f;
            fourTilesHigher = -7f;
            anyOtherJump = -6.5f;
        }

        public override void Animation(int state)
        {
            switch(state)
            {
                case States.Walking:

                    if (++projectile.frameCounter > 8)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;

                        if (projectile.frame > 3)
                            projectile.frame = 0;
                    }

                    break;

                case States.Flying:

                    if (++projectile.frameCounter > 10)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;

                        if (projectile.frame < 4 || projectile.frame > 5)
                            projectile.frame = 4;
                    }

                    break;
            }
        }

        int idlecounter = 0;
        int sideflip;

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.SmolCrab = false;

            if (modPlayer.SmolCrab)
                projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float walkingSpeed, float walkingInertia, float flyingSpeed, float flyingInertia)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            Vector2 vectorToOwner = player.Center - projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            sideflip = player.direction == -1 ? 10 : 8;
            if (player.velocity.X == 0 && player.velocity.Y == 0)
            {
                idlecounter++;
            }
            else
            {
                idlecounter = 0;
            }

            if (((idlecounter == 300 && distanceToOwner < 40) || player.HasItem(ModContent.ItemType<Items.PutridShroom>())) && !modPlayer.rockhat && !modPlayer.conejo && !modPlayer.aesthetic)
            {
                state = 3;
            }
            switch (state)
            {
                case 3:
                    projectile.position.X = player.position.X - sideflip;
                    projectile.position.Y = player.position.Y - 40;
                    projectile.frameCounter++;
                    if (projectile.frameCounter >= 9)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;
                        if (projectile.frame < 0 || projectile.frame > 3)
                            projectile.frame = 0;
                    }
                    if ((idlecounter <= 0 && !player.HasItem(ModContent.ItemType<Items.PutridShroom>())) || modPlayer.rockhat || modPlayer.conejo || modPlayer.aesthetic)
                    {
                        state = States.Walking;
                    }
                    break;
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowMask = mod.GetTexture("Projectiles/Pets/SmolCrab_Glow");
            if (CalValEX.month == 12)
            {
                glowMask = mod.GetTexture("ExtraTextures/ChristmasPets/SmolCrabGlow");
            }
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
            writer.Write(idlecounter);
            writer.Write(sideflip);
            base.SendExtraAI(writer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            sideflip = reader.ReadInt32();
            idlecounter = reader.ReadInt32();
            base.ReceiveExtraAI(reader);
        }
    }
}