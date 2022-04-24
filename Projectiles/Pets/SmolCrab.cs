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
            Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 36;
            Projectile.height = 40;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
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

                    if (++Projectile.frameCounter > 8)
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame++;

                        if (Projectile.frame > 3)
                            Projectile.frame = 0;
                    }

                    break;

                case States.Flying:

                    if (++Projectile.frameCounter > 10)
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame++;

                        if (Projectile.frame < 4 || Projectile.frame > 5)
                            Projectile.frame = 4;
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
                Projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float walkingSpeed, float walkingInertia, float flyingSpeed, float flyingInertia)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            Vector2 vectorToOwner = player.Center - Projectile.Center;
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
                    Projectile.position.X = player.position.X - sideflip;
                    Projectile.position.Y = player.position.Y - 40;
                    Projectile.frameCounter++;
                    if (Projectile.frameCounter >= 9)
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame++;
                        if (Projectile.frame < 0 || Projectile.frame > 3)
                            Projectile.frame = 0;
                    }
                    if ((idlecounter <= 0 && !player.HasItem(ModContent.ItemType<Items.PutridShroom>())) || modPlayer.rockhat || modPlayer.conejo || modPlayer.aesthetic)
                    {
                        state = States.Walking;
                    }
                    break;
            }
        }
        public override void PostDraw(Color lightColor)
        {
            Texture2D glowMask = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/SmolCrab_Glow").Value;
            if (CalValEX.month == 12)
            {
                glowMask = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/ChristmasPets/SmolCrabGlow").Value;
            }
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