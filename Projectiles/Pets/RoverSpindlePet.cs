using Terraria;
//using CalamityMod.Particles;
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
            Main.projFrames[Projectile.type] = 13;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 28;
            Projectile.height = 38;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            DrawOriginOffsetY = 2;
            Projectile.GetGlobalProjectile<CalValEXGlobalProjectile>().isCalValPet = true;
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

                    if (Projectile.velocity.X != 0f)
                    {
                        if (++Projectile.frameCounter > 8)
                        {
                            Projectile.frameCounter = 0;
                            Projectile.frame++;

                            if (Projectile.frame > 9 || Projectile.frame < 2)
                                Projectile.frame = 2;
                        }
                    }
                    else
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame = 0;
                    }

                    if (Projectile.velocity.Y != 0f)
                    {
                        Projectile.frame = 1;
                        Projectile.frameCounter = 0;
                    }
                    break;

                case States.Flying:
                    if (++Projectile.frameCounter > 10)
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame++;

                        if (Projectile.frame > 12 || Projectile.frame < 10)
                            Projectile.frame = 10;
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
                Projectile.timeLeft = 2;
        }
    }
}