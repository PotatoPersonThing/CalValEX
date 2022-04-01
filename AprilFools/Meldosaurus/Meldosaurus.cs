using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.World;
using CalamityMod;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace CalValEX.AprilFools.Meldosaurus
{
	[AutoloadBossHead]
	public class Meldosaurus : ModNPC

	{
		public bool ischarginng;
		public bool fate;
		public int chargecount;
		public int framebuffer = 0;
		public int framecounter = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meldosaurus");
			NPCID.Sets.TrailingMode[npc.type] = 2;
			NPCID.Sets.TrailCacheLength[npc.type] = 21;
		}
		public override void SetDefaults()
		{
			npc.damage = 110;
			npc.width = 118;
			npc.height = 84;
			npc.defense = 10;
			npc.lifeMax = CalamityWorld.revenge ? 140000 : 100000;
			npc.boss = true;
			npc.aiStyle = -1;
			Main.npcFrameCount[npc.type] = 7;
			npc.knockBackResist = 0f;
			npc.value = Item.buyPrice(0, 10, 0, 0);
			npc.lavaImmune = true;
			npc.behindTiles = false;
			npc.noTileCollide = false;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1; 
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Meldosaurus");
			npc.netAlways = true;
			npc.Calamity().canBreakPlayerDefense = true;
			npc.Calamity().DR = 0.1f;
			bossBag = ModContent.ItemType<MeldosaurusBag>();
		}
		public override void AI()
		{
			CalValEXGlobalNPC.meldodon = npc.whoAmI;
			//Die if it isnt april
			Mod orthoceraDLC = ModLoader.GetMod("CalValPlus");
			if (CalValEX.month != 4 && orthoceraDLC == null)
			{
				npc.active = false;
			}	
			if (CalamityMod.World.CalamityWorld.malice && npc.ai[0] != 5 && npc.ai[0] != 6) //This is fine
            {
				npc.ai[1]++;
            }
			if (CalamityMod.World.CalamityWorld.malice)
            {
				npc.ai[2]++;
            }
			//Under 5% health become desperate
			if (npc.life <= npc.lifeMax * 0.05f)
            {
				npc.ai[0] = 10;
            }
			//It begins
			if (npc.ai[0] == 0)
            {
				npc.ai[1]++;
				if (npc.ai[1] >= 60)
				{
					if (CalValEXWorld.amogus && !Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().amogus)
					{
						Projectile.NewProjectile(npc.Center, new Vector2(0, 0), ModContent.ProjectileType<Amogus>(), 0, 0, Main.myPlayer);
					}
					npc.velocity.Y = -4f;
					NewPhase(1);
                }
            }
			//Hop while vomitting 
			if (npc.ai[0] == 1)
            {
				npc.rotation = 0;
				npc.noGravity = false;
				npc.noTileCollide = false;
				npc.ai[1]++;
				npc.ai[2]++;
				if (npc.velocity.Y >= 19)
                {
					npc.ai[3]++;
				}
				if (npc.velocity.Y == 0)
                {
					npc.velocity.Y = -12;
				}
				if (npc.ai[3] >= 10)
                {
					npc.velocity.Y = 0;
					npc.ai[3] = 0;
                }
				//If very slow, switch directions
				else if (npc.ai[2] >= 30)
				{
					Main.PlaySound(SoundID.NPCKilled, (int)npc.Center.X, (int)npc.Center.Y, 13);
					for (int x = 0; x < 12; x++)
                    {
						Projectile.NewProjectile(npc.position.X, npc.position.Y, Main.rand.Next(-30, 30), Main.rand.Next(-20, -12), ModContent.ProjectileType<EntropicVomit>(), Main.expertMode ? 25 : 30, 0f, Main.myPlayer, Main.rand.Next(1,4));
                    }
					npc.ai[2] = 0;
                }
				if (npc.ai[1] >= 300)
                {
					NewPhase(2);
                }
            }
			//Speen
			if (npc.ai[0] == 2)
            {
				npc.ai[1]++;
				npc.noGravity = true;
				npc.noTileCollide = true;
				npc.rotation += Main.rand.Next((int)0.20f, (int)0.30f);
				npc.velocity.Y = 0;
				npc.velocity.X = 0;
				if (npc.ai[1] >= 60)
                {
					NewPhase(3);
                }
            }
			//God Belows jet 
			if (npc.ai[0] == 3)
			{
				ischarginng = false;
				npc.TargetClosest();
				npc.noGravity = true;
				npc.noTileCollide = true;
				npc.ai[1]++;
				npc.ai[2]++;
				int direcX = npc.direction *-1;
				int direcY = npc.directionY *-1;
				if (npc.ai[2] >= 5)
				{
					Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 20);
					Projectile.NewProjectile(npc.position.X, npc.position.Y, npc.velocity.X *-0.1f, npc.velocity.Y *-0.1f, ModContent.ProjectileType<GodsFire>(), Main.expertMode ? 25 : 30, 0f);
					npc.ai[2] = 0;
				}
				if (npc.ai[1] <= 90)
				{
					npc.velocity.X = direcX * 8;
					npc.velocity.Y = direcY * 8;
				}
				else if (npc.ai[1] == 31 | npc.ai[1] == 91 || npc.ai[1] == 131 || npc.ai[1] == 181 || npc.ai[1] == 231 || npc.ai[1] == 281 || npc.ai[1] == 331)
				{
					int chargespeed = CalamityMod.World.CalamityWorld.revenge ? 22 : 18;
					npc.rotation = npc.velocity.ToRotation();
					Main.PlaySound(SoundID.Item111, (int)npc.Center.X, (int)npc.Center.Y);
					Vector2 position = npc.Center;
					position.X = npc.Center.X + (30f * npc.direction);
					Vector2 targetPosition = Main.player[npc.target].Center;
					Vector2 direction = targetPosition - position;
					direction.Normalize();
					npc.velocity = direction * chargespeed;
					int dmg = Main.expertMode ? 25 : 30;
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 10, 10, ModContent.ProjectileType<EntropicVomit>(), dmg, 0, Main.myPlayer, Main.rand.Next(1, 4));
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 10, -10, ModContent.ProjectileType<EntropicVomit>(), dmg, 0, Main.myPlayer, Main.rand.Next(1, 4));
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -10, 10, ModContent.ProjectileType<EntropicVomit>(), dmg, 0, Main.myPlayer, Main.rand.Next(1, 4));
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -10, -10, ModContent.ProjectileType<EntropicVomit>(), dmg, 0, Main.myPlayer, Main.rand.Next(1, 4));
				}
				if (npc.ai[1] >= 381)
                {
					if (!fate)
						NewPhase(4);
					else
					{
						if (Main.rand.Next(2) == 0)
							NewPhase(5);
						else
							NewPhase(6);
					}

				}
            }
			//Tome of fates. Only happens once in the fight
			if (npc.ai[0] == 4)
			{

				ischarginng = false;
				fate = true;
				npc.rotation = 0;
				npc.TargetClosest();
				npc.noGravity = true;
				npc.noTileCollide = true;
				npc.velocity.X = 0;
				npc.velocity.Y = 0;
				if (npc.ai[1] == 0)
				{
					for (int x = 0; x < 20; x++)
					{
						Dust.NewDust(npc.Center, npc.width, npc.height, 27, 0, 0);
					}
				}
				npc.ai[1]++;
				npc.ai[3]++;
				if (npc.ai[1] == 1)
                {
					for (int x = 0; x < 20; x++)
                    {
						Dust.NewDust(npc.Center, npc.width, npc.height, 27, 0, 0);
                    }
					npc.position.X = Main.player[npc.target].Center.X + 400;
					npc.position.Y = Main.player[npc.target].Center.Y - 280;
				}
				if (npc.ai[1] == 30)
				{
					Main.PlaySound(SoundID.Zombie, (int)npc.Center.X, (int)npc.Center.Y, 5);
					Vector2 position = npc.Center;
					position.X = npc.Center.X + (10f * npc.direction);
					Vector2 targetPosition = Main.player[npc.target].Center;
					Vector2 direction = targetPosition - position;
					direction.Normalize();
					float speed = 10f;
					int type = ModContent.ProjectileType<TomeoFates>();
					int damage = Main.expertMode ? 5 : 10;
					Projectile.NewProjectile(position, direction * speed, type, damage, 0f, Main.myPlayer);
				}
				if (npc.ai[1] >= 60)
                {
					var thisRect = npc.getRect();

					for (int i = 0; i < Main.maxProjectiles; i++)
					{
						var proj = Main.projectile[i];

						if (proj != null && proj.active && proj.getRect().Intersects(thisRect) && proj.type == ModContent.ProjectileType<TomeoFates>())
						{
							framebuffer = 0;
							framecounter = 0;
							npc.ai[3] = 2;
							npc.StrikeNPC(40, 0, (int)proj.velocity.X, true);
							proj.active = false;
						}
					}
				}
				if (npc.ai[3] >= 5)
                {
					Projectile.NewProjectile(npc.Center.X - 1400, npc.Center.Y - 200, 0, 80, ModContent.ProjectileType<GodsFire>(), Main.expertMode ? 25 : 30, 20, 0);
					Projectile.NewProjectile(npc.Center.X + 600, npc.Center.Y - 200, 0, 80, ModContent.ProjectileType<GodsFire>(), Main.expertMode ? 25 : 30, 20, 0);
					npc.ai[3] = 0;
                }
				if (npc.ai[1] >= 140)
                {
					NewPhase(5);
                }
            }
			//Top charge
			if (npc.ai[0] == 5)
			{
				npc.TargetClosest();
				npc.noGravity = true;
				npc.noTileCollide = true;
				npc.ai[1]++;
				if (ischarginng)
				{
					npc.rotation += 0.25f;
					npc.ai[2]++;
				}
				npc.position.Y = Main.player[npc.target].Center.Y - 250;
				if (npc.ai[1] < 60)
				{
					npc.position.X = Main.player[npc.target].Center.X - 600;
				}
				if (npc.ai[1] == 60)
				{
					npc.velocity.X = 20;
					ischarginng = true;
				}
				if (npc.ai[2] >= 3)
				{
					Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 61);
					Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 0, ModContent.ProjectileType<ShardofAntumbra>(), Main.expertMode ? 30 : 40, 0f, npc.target);
					npc.ai[2] = 0;
                }
				if (npc.ai[1] >= 100)
                {
					chargecount += 1;
					ischarginng = false;
					if (Main.expertMode && chargecount < 2)
						NewPhase(6);
					else
					NewPhase(7);
                }
			}
			//Bottom charge
			if (npc.ai[0] == 6)
			{
				npc.TargetClosest();
				npc.noGravity = true;
				npc.noTileCollide = true;
				npc.ai[1]++;
				if (ischarginng)
				{
					npc.rotation -= 0.25f;
					npc.ai[2]++;
				}
				npc.position.Y = Main.player[npc.target].Center.Y + 250;
				if (npc.ai[1] < 60)
				{
					npc.position.X = Main.player[npc.target].Center.X + 600;
				}
				if (npc.ai[1] == 60)
				{
					npc.velocity.X = -20;
					ischarginng = true;
				}
				if (npc.ai[2] >= 3)
				{
					Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 61);
					Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 0, ModContent.ProjectileType<ShardofAntumbra>(), Main.expertMode ? 30 : 40, 0f, Main.myPlayer, npc.target);
					npc.ai[2] = 0;
				}
				if (npc.ai[1] >= 100)
				{
					chargecount += 1;
					ischarginng = false;
					if (Main.expertMode && chargecount < 2)
						NewPhase(5);
					else
						NewPhase(7);
				}
			}
			//Weird tp phase
			if (npc.ai[0] == 7)
            {
				chargecount = 0;
				//npc.alpha = 255;
				npc.noGravity = true;
				npc.noTileCollide = true;
				npc.ai[1]++;
				if (npc.ai[1] >= 60)
				{
					Main.PlaySound(SoundID.Zombie, (int)npc.Center.X, (int)npc.Center.Y, 5, 1.5f);
					Main.PlaySound(SoundID.NPCKilled, (int)npc.Center.X, (int)npc.Center.Y, 13);
					//npc.alpha = 0;
					NewPhase(8);
                }
            }
			//Clone ram
			if (npc.ai[0] == 8)
			{
				if (!Main.expertMode)
                {
					npc.alpha = 80;
                }
				int distance = 300;
				int dmg = Main.expertMode ? 33 : 55;
				if (npc.ai[1] == 0)
				{
					Projectile.NewProjectile(Main.player[npc.target].position.X - distance, Main.player[npc.target].position.Y + distance, 0, 0, ModContent.ProjectileType<MeldosaurusClone>(), dmg, 0, Main.myPlayer, npc.target, 1);
					Projectile.NewProjectile(Main.player[npc.target].position.X + distance, Main.player[npc.target].position.Y - distance, 0, 0, ModContent.ProjectileType<MeldosaurusClone>(), dmg, 0, Main.myPlayer, npc.target, 2);
					Projectile.NewProjectile(Main.player[npc.target].position.X - distance, Main.player[npc.target].position.Y - distance, 0, 0, ModContent.ProjectileType<MeldosaurusClone>(), dmg, 0, Main.myPlayer, npc.target, 3);
				}
				npc.alpha = 0;
				npc.ai[1]++;
				npc.noGravity = true;
				npc.noTileCollide = true;
				if (npc.ai[1] <= 30)
				{
					npc.rotation = npc.AngleTo(Main.player[npc.target].Center);
					npc.position.X = Main.player[npc.target].position.X + distance;
					npc.position.Y = Main.player[npc.target].position.Y + distance;
				}
				if (npc.ai[1] == 31)
				{
					Main.PlaySound(SoundID.Zombie, (int)npc.Center.X, (int)npc.Center.Y, 5, 2);
					Vector2 position = npc.Center;
					position.X = npc.Center.X + (30f * npc.direction);
					Vector2 targetPosition = Main.player[npc.target].Center;
					Vector2 direction = targetPosition - position;
					direction.Normalize();
					npc.velocity = direction * 16;
				}
				if (npc.ai[1] >= 90)
                {
					npc.alpha = 0;
					npc.velocity.X = npc.velocity.Y = 0;
					NewPhase(1);
                }
			}
			//Obligatory final desperation
			if (npc.ai[0] == 10)
            {
				npc.scale += 0.001f;
				npc.velocity.X = 0;
				npc.velocity.Y = 0;
				npc.rotation += 1.2f;
				npc.noGravity = true;
				npc.noTileCollide = true;
				npc.ai[1]++;
				if (npc.ai[1] >= 10)
				{
					Main.PlaySound(SoundID.NPCKilled, (int)npc.Center.X, (int)npc.Center.Y, 13);
					for (int x = 0; x <= Main.rand.Next(4,6); x++)
                    {
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Main.rand.Next(-30, 30), Main.rand.Next(-40, 30), ModContent.ProjectileType<EntropicVomit>(), 30, 0f, Main.myPlayer, Main.rand.Next(1, 4));
                    }
					npc.ai[1] = 0;
                }
            }
		}

		public void NewPhase(int phase)
        {
			npc.alpha = 0;
			npc.ai[1] = 0;
			npc.ai[2] = 0;
			npc.ai[3] = 0;
			npc.ai[0] = phase;
		}

		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 1.0;
			if (npc.frameCounter > 6.0)
			{
				npc.frame.Y += frameHeight;
				npc.frameCounter = 0.0;
			}
			if (npc.frame.Y > frameHeight * 6)
			{
				npc.frame.Y = 0;
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			if (npc.ai[0] == 1)
			{
				framebuffer++;
				if (framebuffer >= 6)
				{
					framecounter++;
					framebuffer = 0;
				}
				if (framecounter > 3)
				{
					framecounter = 0;
				}

				Texture2D deusheadsprite = (ModContent.GetTexture("CalValEX/AprilFools/Meldosaurus/MeldosaurusVomit"));

				int deusheadheight = framecounter * (deusheadsprite.Height / 4);

				Rectangle deusheadsquare = new Rectangle(0, deusheadheight, deusheadsprite.Width, deusheadsprite.Height / 4);
				Color deusheadalpha = npc.GetAlpha(drawColor);
				spriteBatch.Draw(deusheadsprite, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusheadsquare, deusheadalpha, npc.rotation, Utils.Size(deusheadsquare) / 2f, npc.scale, SpriteEffects.None, 0f);
				return false;
			}
			else if (npc.ai[0] == 4)
			{
				if (framecounter <= 12)
				framebuffer++;
				if (framebuffer >= 6 && framecounter <= 12)
				{
					framecounter++;
					framebuffer = 0;
				}
				if (framecounter >= 12)
                {
					framecounter = 12;
                }

				Texture2D deusheadsprite = (ModContent.GetTexture("CalValEX/AprilFools/Meldosaurus/MeldosaurusThrow"));

				int deusheadheight = framecounter * (deusheadsprite.Height / 13);

				Rectangle deusheadsquare = new Rectangle(0, deusheadheight, deusheadsprite.Width, deusheadsprite.Height / 13);
				Color deusheadalpha = npc.GetAlpha(drawColor);
				spriteBatch.Draw(deusheadsprite, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusheadsquare, deusheadalpha, npc.rotation, Utils.Size(deusheadsquare) / 2f, npc.scale, SpriteEffects.None, 0f);
				return false;
			}
			else if (npc.ai[0] == 4 && npc.ai[3] == 2)
			{
				framebuffer++;
				if (framebuffer >= 6 && framecounter <= 8)
				{
					framecounter++;
					framebuffer = 0;
				}

				Texture2D deusheadsprite = (ModContent.GetTexture("CalValEX/AprilFools/Meldosaurus/MeldosaurusHit"));

				int deusheadheight = framecounter * (deusheadsprite.Height / 9);

				Rectangle deusheadsquare = new Rectangle(0, deusheadheight, deusheadsprite.Width, deusheadsprite.Height / 9);
				Color deusheadalpha = npc.GetAlpha(drawColor);
				spriteBatch.Draw(deusheadsprite, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusheadsquare, deusheadalpha, npc.rotation, Utils.Size(deusheadsquare) / 2f, npc.scale, SpriteEffects.None, 0f);
				return false;
			}
			else

            {
				return true;
            }
		}

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            if (npc.ai[0] == 8 && CalamityMod.World.CalamityWorld.death)
            {
				return false;
            }
			else
            {
				return true;
            }
        }

        public override bool PreNPCLoot()
		{
			DropHelper.DropItemCondition(npc, ModContent.ItemType<KnowledgeMeldosaurus>(), !CalValEXWorld.downedMeldosaurus);
			if (!NPC.AnyNPCs(ModContent.NPCType<AprilFools.Jharim.Jharim>()))
			{
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<AprilFools.Jharim.Jharim>());
			}
			return true;
		}

        public override void NPCLoot()
		{
			DropHelper.DropBags(npc);
			DropHelper.DropItemChance(npc, ModContent.ItemType<MeldosaurusTrophy>(), 10);
			if (!Main.expertMode)
			{
				DropHelper.DropItemChance(npc, ModContent.ItemType<MeldosaurusMask>(), 7);
				DropHelper.DropItemSpray(npc, ModContent.ItemType<CalamityMod.Items.Materials.MeldBlob>(), 1, 2);
				float dropChance = DropHelper.NormalWeaponDropRateFloat;
				DropHelper.DropItemChance(npc, ModContent.ItemType<ShadesBane>(), dropChance);
				DropHelper.DropItemChance(npc, ModContent.ItemType<Nyanthrop>(), dropChance);
			}
			CalValEXWorld.downedMeldosaurus = true;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.7f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.7f);
		}

		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write(ischarginng);
			writer.Write(fate);
			writer.Write(chargecount);
			writer.Write(framebuffer);
			writer.Write(framecounter);
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			chargecount = reader.ReadInt32();
			framebuffer = reader.ReadInt32();
			framecounter = reader.ReadInt32();
			ischarginng = reader.ReadBoolean();
			fate = reader.ReadBoolean();
		}

	}
}