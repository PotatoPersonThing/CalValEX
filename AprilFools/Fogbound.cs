using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX;
//using Terraria.World.Generation;

namespace CalValEX.AprilFools
{
	[AutoloadBossHead]
	public class Fogbound : ModNPC
	
	{
		private bool prov1;
		private bool prov2;
		private bool prov3;
		private bool dog1;
		private bool dog2;
		private bool dog3;
		private bool yharon1;
		private bool yharon2;
		private bool yharon3;
		private bool scal1;
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hyper Ultra Omega Fogbound GOD EX: Prepare to Stygian Edition");
		}
		public override void SetDefaults()
		{
			NPC.damage = 69420666; 
			NPC.width = 100; 
			NPC.height = 100; 
			NPC.defense = 10;
			NPC.lifeMax = 100000000;
			NPC.boss = true;
			NPC.aiStyle = 11; 
			Main.npcFrameCount[NPC.type] = 1; 
            AIType = 11; 
			NPC.knockBackResist = 0f;
			NPC.value = Item.buyPrice(0, 10, 0, 0);
			NPC.alpha = 1;
			NPC.lavaImmune = true;
			NPC.behindTiles = true;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit23;
			NPC.DeathSound = SoundID.NPCDeath3;
			Music = MusicID.LunarBoss;
			NPC.netAlways = true;
			NPCID.Sets.NPCBestiaryDrawModifiers bestiaryData = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				Hide = true // Hides this NPC from the bestiary
			};
		}
		public override void AI()
		{
			Main.dayTime = false;
			//Mod orthoceraDLC = ModLoader.GetMod("CalValPlus");
            if (CalValEX.month != 4 && !Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().Blok/*&& orthoceraDLC == null*/)
            {
            NPC.active = false;
            }
            int num2 = (int)((double)NPC.lifeMax * 0.1);
			if (NPC.ai[3] == 0f && NPC.life > 0)
		{
			NPC.ai[3] = NPC.lifeMax;
		}
		if (NPC.life <= 0 || Main.netMode == 1)
		{
			return;
		}
		if ((float)(NPC.life + num2) < NPC.ai[3])
		{
			NPC.ai[3] = NPC.life;
			int num1 = (NPCID.HallowBoss);
			if (!prov1)
			{
				prov1 = true;
			}
			else if (!prov2)
			{
				prov2 = true;
				num1 = (NPCID.HallowBoss);
			}
			else if (!prov3)
			{
				prov3 = true;
				num1 = (NPCID.TheDestroyer);
			}
			else if (!dog1)
			{
				dog1 = true;
				num1 = (NPCID.TheDestroyer);
			}
			else if (!dog2)
			{
				dog2 = true;
				num1 = (NPCID.DukeFishron);
			}
			else if (!dog3)
			{
				dog3 = true;
				num1 = (NPCID.DukeFishron);
			}
			else if (!yharon1)
			{
				yharon1 = true;
				num1 = (NPCID.SkeletronPrime);
			}
			else if (!yharon2)
			{
				yharon2 = true;
				num1 = (NPCID.SkeletronPrime);
			}
			else if (!yharon3)
			{
				yharon3 = true;
				num1 = (NPCID.MoonLordCore);
			}
			else if (!scal1)
			{
				scal1 = true;
				num1 = (NPCID.MoonLordCore);
			}
			NPC.SpawnOnPlayer(NPC.FindClosestPlayer(), num1);
			NPC.SpawnOnPlayer(NPC.FindClosestPlayer(), NPCID.Retinazer);
			NPC.SpawnOnPlayer(NPC.FindClosestPlayer(), NPCID.Spazmatism);
			}
	}

    /*public override void NPCLoot()
	{
		Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, mod.ItemType("FogG") , Main.rand.Next(1, 1), false, 0, false, false);	
			if (!NPC.AnyNPCs(ModContent.NPCType<Jharim.Jharim>()))
		NPC.SpawnOnPlayer(Main.player[Main.myPlayer].whoAmI, mod.NPCType("Jharim"));	
	}*/
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			NPC.lifeMax = (int)(NPC.lifeMax * 0.55f * bossLifeScale);
			NPC.damage = (int)(NPC.damage * 0.65f);
		}
	}
}