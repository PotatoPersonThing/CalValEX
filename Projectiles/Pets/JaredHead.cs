using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

// If you don't know what to change this to, don't mess with this code.
// You will fail
namespace CalValEX.Projectiles.Pets
{
    public class JaredHead : ModProjectile
    {
        private static readonly int Size = 86;
        private static readonly int SegmentCount = 20;
        private bool SpawnedSegments = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jared Head");
            ProjectileID.Sets.NeedsUUID[projectile.type] = true;
			Main.projPet[projectile.type] = true;
		}

        public override void SetDefaults()
        {
            projectile.width = 126;
            projectile.height = Size;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.netImportant = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 300;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            if (!SpawnedSegments)
            {
                int tail = Projectile.NewProjectile(projectile.Center, Vector2.Zero, ModContent.ProjectileType<JaredTail>(),
                    projectile.damage, projectile.knockBack, 0, projectile.whoAmI);
                // The minus one is because this segment and the tail are incorporated in the worm as well
                for (int i = 0; i < 18; i++)
                {
                    float uuid = (float)Projectile.GetByUUID(Main.myPlayer, Main.projectile[tail].ai[0]);
					int body = Projectile.NewProjectile(projectile.Center, Vector2.Zero,
					ModContent.ProjectileType<JaredBody>(), projectile.damage, 1f,
					0, uuid);
					int back = Projectile.NewProjectile(projectile.Center, Vector2.Zero,
					ModContent.ProjectileType<JaredBody>(), projectile.damage, 1f,
					0, (float)body);
					if (i % 2 == 0)
					{
						Main.projectile[body].knockBack = 2f;
					}
					Main.projectile[body].ai[1] = 1f;
					Main.projectile[body].netUpdate = true;
                    Main.projectile[body].identity = projectile.whoAmI;

                    Main.projectile[back].netUpdate = true;
                    Main.projectile[back].ai[1] = 1f;
                    Main.projectile[body].identity = projectile.whoAmI;

                    Main.projectile[tail].ai[0] = Main.projectile[body].projUUID;
                    Main.projectile[tail].netUpdate = true;
                    Main.projectile[tail].ai[1] = 1f;
                }
                SpawnedSegments = true;
            }
            // Consistently update the worm
            if ((int)Main.time % 120 == 0)
            {
                projectile.netUpdate = true;
            }

            // Custom AI here
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (player.dead)
            {
                modPlayer.jared = false;
            }
            if (modPlayer.jared)
            {
                projectile.timeLeft = 2;
            }
			//Offensive worm code
			/*for (int num544 = 0; num544 < 1000; num544++)
			{
				if (num544 != projectile.whoAmI && Main.projectile[num544].active && Main.projectile[num544].owner == projectile.owner && Main.projectile[num544].type == projectile.type && Math.Abs(projectile.position.X - Main.projectile[num544].position.X) + Math.Abs(projectile.position.Y - Main.projectile[num544].position.Y) < projectile.width)
				{
					if (projectile.position.X < Main.projectile[num544].position.X)
					{
						projectile.velocity.X -= 0.05f;
					}
					else
					{
						projectile.velocity.X += 0.05f;
					}
					if (projectile.position.Y < Main.projectile[num544].position.Y)
					{
						projectile.velocity.Y -= 0.05f;
					}
					else
					{
						projectile.velocity.Y += 0.05f;
					}
				}
			}
			float num545 = projectile.position.X;
			float num546 = projectile.position.Y;
			float num547 = 900f;
			bool flag19 = false;
			int num548 = 500;
			if (projectile.ai[1] != 0f || projectile.friendly)
			{
				num548 = 1400;
			}
			if (Math.Abs(projectile.Center.X - Main.player[projectile.owner].Center.X) + Math.Abs(projectile.Center.Y - Main.player[projectile.owner].Center.Y) > (float)num548)
			{
				projectile.ai[0] = 1f;
			}
			if (projectile.ai[0] == 0f)
			{
				projectile.tileCollide = true;
				NPC ownerMinionAttackTargetNPC2 = projectile.OwnerMinionAttackTargetNPC;
				if (ownerMinionAttackTargetNPC2 != null && ownerMinionAttackTargetNPC2.CanBeChasedBy(this))
				{
					float num549 = ownerMinionAttackTargetNPC2.position.X + (float)(ownerMinionAttackTargetNPC2.width / 2);
					float num550 = ownerMinionAttackTargetNPC2.position.Y + (float)(ownerMinionAttackTargetNPC2.height / 2);
					float num551 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num549) + Math.Abs(projectile.position.Y + (float)( projectile.height / 2) - num550);
					if (num551 < num547 && Collision.CanHit(projectile.position, projectile.width,  projectile.height, ownerMinionAttackTargetNPC2.position, ownerMinionAttackTargetNPC2.width, ownerMinionAttackTargetNPC2.height))
					{
						num547 = num551;
						num545 = num549;
						num546 = num550;
						flag19 = true;
					}
				}
				if (!flag19)
				{
					for (int num552 = 0; num552 < 200; num552++)
					{
						if (Main.npc[num552].CanBeChasedBy(this))
						{
							float num553 = Main.npc[num552].position.X + (float)(Main.npc[num552].width / 2);
							float num554 = Main.npc[num552].position.Y + (float)(Main.npc[num552].height / 2);
							float num555 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num553) + Math.Abs(projectile.position.Y + (float)( projectile.height / 2) - num554);
							if (num555 < num547 && Collision.CanHit(projectile.position, projectile.width,  projectile.height, Main.npc[num552].position, Main.npc[num552].width, Main.npc[num552].height))
							{
								num547 = num555;
								num545 = num553;
								num546 = num554;
								flag19 = true;
							}
						}
					}
				}
			}
			else
			{
				projectile.tileCollide = false;
			}
			if (!flag19)
			{
				projectile.friendly = true;
				float num556 = 8f;
				if (projectile.ai[0] == 1f)
				{
					num556 = 12f;
				}
				Vector2 vector35 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + (float) projectile.height * 0.5f);
				float num557 = Main.player[projectile.owner].Center.X - vector35.X;
				float num558 = Main.player[projectile.owner].Center.Y - vector35.Y - 60f;
				float num559 = (float)Math.Sqrt(num557 * num557 + num558 * num558);
				float num560 = num559;
				if (num559 < 100f && projectile.ai[0] == 1f && !Collision.SolidCollision(projectile.position, projectile.width,  projectile.height))
				{
					projectile.ai[0] = 0f;
				}
				if (num559 > 2000f)
				{
					projectile.position.X = Main.player[projectile.owner].Center.X - (float)(projectile.width / 2);
					projectile.position.Y = Main.player[projectile.owner].Center.Y - (float)(projectile.width / 2);
				}
				if (num559 > 70f)
				{
					num559 = num556 / num559;
					num557 *= num559;
					num558 *= num559;
					projectile.velocity.X = (projectile.velocity.X * 20f + num557) / 21f;
					projectile.velocity.Y = (projectile.velocity.Y * 20f + num558) / 21f;
				}
				else
				{
					if (projectile.velocity.X == 0f && projectile.velocity.Y == 0f)
					{
						projectile.velocity.X = -0.15f;
						projectile.velocity.Y = -0.05f;
					}
					projectile.velocity *= 1.01f;
				}
				projectile.friendly = false;
				projectile.rotation = projectile.velocity.X * 0.05f;
				return;
			}
			if (projectile.ai[1] == -1f)
			{
				projectile.ai[1] = 17f;
			}
			if (projectile.ai[1] > 0f)
			{
				projectile.ai[1] -= 1f;
			}
			if (projectile.ai[1] == 0f)
			{
				projectile.friendly = true;
				float num561 = 8f;
				Vector2 vector36 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + (float) projectile.height * 0.5f);
				float num562 = num545 - vector36.X;
				float num563 = num546 - vector36.Y;
				float num564 = (float)Math.Sqrt(num562 * num562 + num563 * num563);
				float num565 = num564;
				if (num564 < 100f)
				{
					num561 = 10f;
				}
				num564 = num561 / num564;
				num562 *= num564;
				num563 *= num564;
				projectile.velocity.X = (projectile.velocity.X * 14f + num562) / 15f;
				projectile.velocity.Y = (projectile.velocity.Y * 14f + num563) / 15f;
			}
			else
			{
				projectile.friendly = false;
				if (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) < 10f)
				{
					projectile.velocity *= 1.05f;
				}
			}
			projectile.rotation = projectile.velocity.X * 0.05f;*/
		
		Vector2 PlayerCenter = player.Center;
		float MinVel = 0.36f;
		Vector2 ProjDistance = PlayerCenter - projectile.Center;
		if (ProjDistance.Length() < 100f)
		{
			MinVel = 0.22f;
		}
		if (ProjDistance.Length() < 80f)
		{
			MinVel = 0.1f;
		}
		if (ProjDistance.Length() > 50f)
		{
			if (Math.Abs(PlayerCenter.X - projectile.Center.X) > 10f)
			{
				projectile.velocity.X = projectile.velocity.X + MinVel * (float)Math.Sign(PlayerCenter.X - projectile.Center.X);
			}
			if (Math.Abs(PlayerCenter.Y - projectile.Center.Y) > 5f)
			{
				projectile.velocity.Y = projectile.velocity.Y + MinVel * (float)Math.Sign(PlayerCenter.Y - projectile.Center.Y);
			}
		}
		else if (projectile.velocity.Length() > 1.6f)
		{
			projectile.velocity *= 0.96f;
		}
		float MaxVel = 15f;
		if (ProjDistance.Length() > 800f)
		{
			MaxVel = 25;
		}
		else if (ProjDistance.Length() > 500f)
		{
			MaxVel = 22f;
		}
		else if (ProjDistance.Length() > 300f)
		{
			MaxVel = 18.5f;
		}
		else
		{
			MaxVel = 15;
		}

		if (projectile.velocity.Length() > MaxVel)
		{
			projectile.velocity = Vector2.Normalize(projectile.velocity) * MaxVel;
		}
		if (ProjDistance.Length() > 2000f)
		{
			projectile.Center = PlayerCenter;
		}
		if (Math.Abs(projectile.velocity.Y) < 1f)
		{
			projectile.velocity.Y = projectile.velocity.Y - 0.1f;
		}
		// NOTE: If you wish for this worm to travel at very high speeds, the
		// Body and tail segments will gain gaps. You would have to change the position adjusting
		// In the body and tail's code to mitigate this problem.

			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;

            int oldDirection = projectile.direction;
			projectile.direction = projectile.spriteDirection = (projectile.velocity.X > 0f).ToDirectionInt();

            // Update the projectile in multiplayer if the determined direction is not the true direction.
            // It will do weird things in multiplayer because of a lack of syncing among the directions
            if (oldDirection != projectile.direction)
            {
                projectile.netUpdate = true;
            }

			projectile.position = projectile.Center;
            projectile.width = 126;
            projectile.height = Size;
            projectile.Center = projectile.position;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = ModContent.GetTexture("CalValEX/Projectiles/Pets/JaredHead_Glow");
			int frameHeight = texture.Height / Main.projFrames[projectile.type];
			int hei = frameHeight * projectile.frame;
			spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * projectile.frame, texture.Width, frameHeight)), Color.White, projectile.rotation, projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
        }
    }
}