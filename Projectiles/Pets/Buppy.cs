using Terraria;
using Terraria.ID;
using System.IO;

namespace CalValEX.Projectiles.Pets
{
    public class Buppy : ModWalkingPet
    {
        public override float TeleportThreshold => 1200f;

        public override float BackToFlyingThreshold => 448f;

        public override float BackToWalkingThreshold => 140f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Buppy");
            Main.projFrames[projectile.type] = 8;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 40;
            projectile.height = 26;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            drawOriginOffsetY = 2;
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
                case States.Flying:
                    if (++projectile.frameCounter > 7)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;

                        if (projectile.frame < 2 || projectile.frame > 5)
                            projectile.frame = 2;
                    }
                    break;

                case States.Walking:
                    if (yapcount < 300)
                    {
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
                    }

                    if (yapcount == 300) //this won't run the animation code since it checks only one value
                    {
                        Main.PlaySound(SoundID.NPCHit46);
                        if (projectile.frame != 7 && projectile.frame != 6)
                        {
                            projectile.frame = 6;
                        }
                        if (projectile.frameCounter++ > 8)
                        {
                            projectile.frameCounter = 0;
                            projectile.frame++;
                            if (projectile.frame >= 7)
                                projectile.frame = 6;
                        }
                    }
                    if (yapcount >= 330) //this won't run the animation code since it resets instantly
                    {
                        Main.PlaySound(SoundID.NPCHit46);
                        yapcount = 0; //<---
                        if (projectile.frame != 7 && projectile.frame != 6)
                        {
                            projectile.frame = 6;
                        }
                        if (projectile.frameCounter++ > 8)
                        {
                            projectile.frameCounter = 0;
                            projectile.frame++;
                            if (projectile.frame >= 7)
                                projectile.frame = 6;
                        }
                    }
                    break;
            }
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
                modPlayer.buppy = false;

            if (modPlayer.buppy)
                projectile.timeLeft = 2;
        }

        int yapcount;
        public override void CustomBehaviour(Player player, ref int state, float walkingSpeed, float walkingInertia, float flyingSpeed, float flyingInertia)
        {
            for (int x = 0; x < Main.maxNPCs; x++)
            {
                NPC npc = Main.npc[x];
                if (npc.rarity > 1 && npc.active)
                {
                    yapcount++; //careful as it will break when theres more than 1 rare enemy, the code that checks if it barked or not checks values, not over or under.
                }
            }
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(yapcount);
            base.SendExtraAI(writer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            yapcount = reader.ReadInt32();
            base.ReceiveExtraAI(reader);
        }
    }
}