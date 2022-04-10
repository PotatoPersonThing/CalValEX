using Terraria;
using CalamityMod.Particles;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CalValEX.Projectiles.Pets
{
    public class RoverSpindlePet : ModWalkingPet
    {
        public override bool FacesLeft => false;

        public override float WalkingSpeed => 10f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("RoverdriveZ");
            Main.projFrames[projectile.type] = 13;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 28;
            projectile.height = 38;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            drawOriginOffsetY = 2;
        }

        public override void ModifyJumpHeight(ref float oneTileHigherAndNotTwoTilesHigher, ref float twoTilesHigher, ref float fourTilesHigher, ref float fiveTilesHigher, ref float anyOtherJump)
        {
            oneTileHigherAndNotTwoTilesHigher = -4f;
            twoTilesHigher = -6.5f;
            fiveTilesHigher = -8f;
            fourTilesHigher = -7f;
            anyOtherJump = -6.75f;
        }

        public override void Animation(int state)
        {
            switch (state)
            {
                case States.Walking:

                    if (projectile.velocity.X != 0f)
                    {
                        if (++projectile.frameCounter > 8)
                        {
                            projectile.frameCounter = 0;
                            projectile.frame++;

                            if (projectile.frame > 9 || projectile.frame < 2)
                                projectile.frame = 2;
                        }
                    }
                    else
                    {
                        projectile.frameCounter = 0;
                        projectile.frame = 0;
                    }

                    if (projectile.velocity.Y != 0f)
                    {
                        projectile.frame = 1;
                        projectile.frameCounter = 0;
                    }
                    break;

                case States.Flying:
                    if (++projectile.frameCounter > 10)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;

                        if (projectile.frame > 12 || projectile.frame < 10)
                            projectile.frame = 10;
                    }
                    break;
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.roverd = false;

            if (modPlayer.roverd)
                projectile.timeLeft = 2;
        }
    }
}