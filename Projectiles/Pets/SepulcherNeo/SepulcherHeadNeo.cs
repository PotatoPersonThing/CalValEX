using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

// If you don't know what to change this to, don't mess with this code.
// You will fail
namespace CalValEX.Projectiles.Pets.SepulcherNeo
{
    public class SepulcherHeadNeo : ModProjectile
	{
		private static readonly int Size = 60;
		private static readonly int SegmentCount = 6;
		private bool SpawnedSegments = false;

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Sepulcher");
			ProjectileID.Sets.NeedsUUID[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.width = 140;
			Projectile.height = Size;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.ignoreWater = true;
			Projectile.netImportant = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 300;
			Projectile.tileCollide = false;
		}

		public override void AI()
		{
			if (!SpawnedSegments)
			{
				int tail = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<SepulcherTailNeo>(),
					Projectile.damage, Projectile.knockBack, 0, Projectile.whoAmI);
				// The minus one is because this segment and the tail are incorporated in the worm as well
				for (int i = 0; i < 13; i++)
				{
					float uuid = (float)Projectile.GetByUUID(Main.myPlayer, Main.projectile[tail].ai[0]);
					int body = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero,
					ModContent.ProjectileType<SepulcherBody1Neo>(), Projectile.damage, 1f,
					0, uuid);
					int back = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero,
					ModContent.ProjectileType<SepulcherBody1Neo>(), Projectile.damage, 1f,
					0, (float)body);
					//1f = normal seg. 2f = skull seg. 3f = orb
					//Individual i's were done due to the math being a pain to work with before I realized the issue with the hook segments. Too lazy to optimize now.
					if (i == 1 || i == 5 || i == 9 || i == 13) //Armed segs
					{
						Main.projectile[body].knockBack = 1f;
					}
					else if (i == 3 || i == 7 || i == 11 || i == 15) //Body segs
					{
						Main.projectile[body].knockBack = 2f;
					}
					else if (i == 0 || i == 2 || i == 4 || i == 6 || i == 8 || i == 10 || i == 12 || i == 14) //Orbs
					{
						Main.projectile[body].knockBack = 3f;
					}
					Main.projectile[back].knockBack = 4f; //Disable the stupid hook segments

					Main.projectile[body].ai[1] = 1f;
					Main.projectile[body].netUpdate = true;
					Main.projectile[body].identity = Projectile.whoAmI;

					Main.projectile[back].netUpdate = true;
					Main.projectile[back].ai[1] = 1f;
					Main.projectile[back].identity = Projectile.whoAmI;

					Main.projectile[tail].ai[0] = Main.projectile[body].projUUID;
					Main.projectile[tail].netUpdate = true;
					Main.projectile[tail].ai[1] = 1f;
				}
				SpawnedSegments = true;
			}
			// Consistently update the worm
			if ((int)Main.time % 120 == 0)
			{
				Projectile.netUpdate = true;
			}

			// Custom AI here
			Player player = Main.player[Projectile.owner];
			CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
			if (player.dead)
			{
				modPlayer.sepneo = false;
			}
			if (modPlayer.sepneo)
			{
				Projectile.timeLeft = 2;
			}
			//Offensive worm code
			/*for (int num544 = 0; num544 < 1000; num544++)
			{
				if (num544 != Projectile.whoAmI && Main.projectile[num544].active && Main.projectile[num544].owner == Projectile.owner && Main.projectile[num544].type == Projectile.type && Math.Abs(Projectile.position.X - Main.projectile[num544].position.X) + Math.Abs(Projectile.position.Y - Main.projectile[num544].position.Y) < Projectile.width)
				{
					if (Projectile.position.X < Main.projectile[num544].position.X)
					{
						Projectile.velocity.X -= 0.05f;
					}
					else
					{
						Projectile.velocity.X += 0.05f;
					}
					if (Projectile.position.Y < Main.projectile[num544].position.Y)
					{
						Projectile.velocity.Y -= 0.05f;
					}
					else
					{
						Projectile.velocity.Y += 0.05f;
					}
				}
			}
			float num545 = Projectile.position.X;
			float num546 = Projectile.position.Y;
			float num547 = 900f;
			bool flag19 = false;
			int num548 = 500;
			if (Projectile.ai[1] != 0f || Projectile.friendly)
			{
				num548 = 1400;
			}
			if (Math.Abs(Projectile.Center.X - Main.player[Projectile.owner].Center.X) + Math.Abs(Projectile.Center.Y - Main.player[Projectile.owner].Center.Y) > (float)num548)
			{
				Projectile.ai[0] = 1f;
			}
			if (Projectile.ai[0] == 0f)
			{
				Projectile.tileCollide = true;
				NPC ownerMinionAttackTargetNPC2 = Projectile.OwnerMinionAttackTargetNPC;
				if (ownerMinionAttackTargetNPC2 != null && ownerMinionAttackTargetNPC2.CanBeChasedBy(this))
				{
					float num549 = ownerMinionAttackTargetNPC2.position.X + (float)(ownerMinionAttackTargetNPC2.width / 2);
					float num550 = ownerMinionAttackTargetNPC2.position.Y + (float)(ownerMinionAttackTargetNPC2.height / 2);
					float num551 = Math.Abs(Projectile.position.X + (float)(Projectile.width / 2) - num549) + Math.Abs(Projectile.position.Y + (float)( Projectile.height / 2) - num550);
					if (num551 < num547 && Collision.CanHit(Projectile.position, Projectile.width,  Projectile.height, ownerMinionAttackTargetNPC2.position, ownerMinionAttackTargetNPC2.width, ownerMinionAttackTargetNPC2.height))
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
							float num555 = Math.Abs(Projectile.position.X + (float)(Projectile.width / 2) - num553) + Math.Abs(Projectile.position.Y + (float)( Projectile.height / 2) - num554);
							if (num555 < num547 && Collision.CanHit(Projectile.position, Projectile.width,  Projectile.height, Main.npc[num552].position, Main.npc[num552].width, Main.npc[num552].height))
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
				Projectile.tileCollide = false;
			}
			if (!flag19)
			{
				Projectile.friendly = true;
				float num556 = 8f;
				if (Projectile.ai[0] == 1f)
				{
					num556 = 12f;
				}
				Vector2 vector35 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + (float) Projectile.height * 0.5f);
				float num557 = Main.player[Projectile.owner].Center.X - vector35.X;
				float num558 = Main.player[Projectile.owner].Center.Y - vector35.Y - 60f;
				float num559 = (float)Math.Sqrt(num557 * num557 + num558 * num558);
				float num560 = num559;
				if (num559 < 100f && Projectile.ai[0] == 1f && !Collision.SolidCollision(Projectile.position, Projectile.width,  Projectile.height))
				{
					Projectile.ai[0] = 0f;
				}
				if (num559 > 2000f)
				{
					Projectile.position.X = Main.player[Projectile.owner].Center.X - (float)(Projectile.width / 2);
					Projectile.position.Y = Main.player[Projectile.owner].Center.Y - (float)(Projectile.width / 2);
				}
				if (num559 > 70f)
				{
					num559 = num556 / num559;
					num557 *= num559;
					num558 *= num559;
					Projectile.velocity.X = (Projectile.velocity.X * 20f + num557) / 21f;
					Projectile.velocity.Y = (Projectile.velocity.Y * 20f + num558) / 21f;
				}
				else
				{
					if (Projectile.velocity.X == 0f && Projectile.velocity.Y == 0f)
					{
						Projectile.velocity.X = -0.15f;
						Projectile.velocity.Y = -0.05f;
					}
					Projectile.velocity *= 1.01f;
				}
				Projectile.friendly = false;
				Projectile.rotation = Projectile.velocity.X * 0.05f;
				return;
			}
			if (Projectile.ai[1] == -1f)
			{
				Projectile.ai[1] = 17f;
			}
			if (Projectile.ai[1] > 0f)
			{
				Projectile.ai[1] -= 1f;
			}
			if (Projectile.ai[1] == 0f)
			{
				Projectile.friendly = true;
				float num561 = 8f;
				Vector2 vector36 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + (float) Projectile.height * 0.5f);
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
				Projectile.velocity.X = (Projectile.velocity.X * 14f + num562) / 15f;
				Projectile.velocity.Y = (Projectile.velocity.Y * 14f + num563) / 15f;
			}
			else
			{
				Projectile.friendly = false;
				if (Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y) < 10f)
				{
					Projectile.velocity *= 1.05f;
				}
			}
			Projectile.rotation = Projectile.velocity.X * 0.05f;*/

			Vector2 PlayerCenter = player.Center;
			float MinVel = 0.36f;
			Vector2 ProjDistance = PlayerCenter - Projectile.Center;
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
				if (Math.Abs(PlayerCenter.X - Projectile.Center.X) > 10f)
				{
					Projectile.velocity.X = Projectile.velocity.X + MinVel * (float)Math.Sign(PlayerCenter.X - Projectile.Center.X);
				}
				if (Math.Abs(PlayerCenter.Y - Projectile.Center.Y) > 5f)
				{
					Projectile.velocity.Y = Projectile.velocity.Y + MinVel * (float)Math.Sign(PlayerCenter.Y - Projectile.Center.Y);
				}
			}
			else if (Projectile.velocity.Length() > 1.6f)
			{
				Projectile.velocity *= 0.96f;
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

			if (Projectile.velocity.Length() > MaxVel)
			{
				Projectile.velocity = Vector2.Normalize(Projectile.velocity) * MaxVel;
			}
			if (ProjDistance.Length() > 2000f)
			{
				Projectile.Center = PlayerCenter;
			}
			if (Math.Abs(Projectile.velocity.Y) < 1f)
			{
				Projectile.velocity.Y = Projectile.velocity.Y - 0.1f;
			}
			// NOTE: If you wish for this worm to travel at very high speeds, the
			// Body and tail segments will gain gaps. You would have to change the position adjusting
			// In the body and tail's code to mitigate this problem.

			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

			int oldDirection = Projectile.direction;
			Projectile.direction = Projectile.spriteDirection = (Projectile.velocity.X > 0f).ToDirectionInt();

			// Update the projectile in multiplayer if the determined direction is not the true direction.
			// It will do weird things in multiplayer because of a lack of syncing among the directions
			if (oldDirection != Projectile.direction)
			{
				Projectile.netUpdate = true;
			}

			Projectile.position = Projectile.Center;
			Projectile.width = 140;
			Projectile.height = Size;
			Projectile.Center = Projectile.position;
		}
		/*public override void PostDraw(Color lightColor)
		{
			Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/JaredHead_Glow");
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int hei = frameHeight * Projectile.frame;
			Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * Projectile.frame, texture.Width, frameHeight)), Color.White, Projectile.rotation, Projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
		}*/
	}
}