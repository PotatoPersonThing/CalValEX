using Terraria;
using Microsoft.Xna.Framework;

namespace CalValEX.Projectiles.Pets
{
    public class Catfish : ModWalkingPet
    {
        public override bool FacesLeft => false;

        public override float WalkingSpeed => 10f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Catfish");
            Main.projFrames[projectile.type] = 8;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 40;
            projectile.height = 48;
            drawOriginOffsetY = 1;
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
                    if (projectile.velocity.X != 0f)
                    {
                        if (++projectile.frameCounter > 8)
                        {
                            projectile.frameCounter = 0;
                            projectile.frame++;

                            if (projectile.frame < 1 || projectile.frame > 3)
                                projectile.frame = 1;
                        }
                    }
                    else
                    {
                        projectile.frameCounter = 0;
                        projectile.frame = 0;
                    }
                    break;

                case States.Flying:
                    if (++projectile.frameCounter > 7)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;

                        if (projectile.frame < 4 || projectile.frame > 7)
                            projectile.frame = 4;
                    }
                    break;
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.catfish = false;

            if (modPlayer.catfish)
                projectile.timeLeft = 2;
        }

        public override bool ModifyDustSpawn(ref int dustType)
        {
            if (state == States.Flying)
            {
                Dust.NewDust(projectile.Center, 30, 30, 15, 0f, 3.684211f, 0, new Color(255, 255, 255), 0.7894737f);
            }

            return false;
        }
    }
}