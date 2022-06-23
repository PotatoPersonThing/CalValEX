using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX;
using Terraria.World.Generation;

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
			npc.damage = 69420666; 
			npc.width = 100; 
			npc.height = 100; 
			npc.defense = 10;
			npc.lifeMax = 100000000;
			npc.boss = true;
			npc.aiStyle = 11; 
			Main.npcFrameCount[npc.type] = 1; 
            aiType = 11; 
			npc.knockBackResist = 0f;
			npc.value = Item.buyPrice(0, 10, 0, 0);
			npc.alpha = 1;
			npc.lavaImmune = true;
			npc.behindTiles = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit23;
			npc.DeathSound = SoundID.NPCDeath3;
			music = MusicID.LunarBoss;
			npc.netAlways = true;
		}
		public override void AI()
		{
			Mod orthoceraDLC = ModLoader.GetMod("CalValPlus");
            if (CalValEX.month != 4 && orthoceraDLC == null)
            {
            npc.active = false;
            }
            int num2 = (int)((double)npc.lifeMax * 0.1);
			if (npc.ai[3] == 0f && npc.life > 0)
		{
			npc.ai[3] = npc.lifeMax;
		}
		if (npc.life <= 0 || Main.netMode == 1)
		{
			return;
		}
		if ((float)(npc.life + num2) < npc.ai[3])
		{
			npc.ai[3] = npc.life;
			int num1 = (ModLoader.GetMod("CalamityMod").NPCType("Providence"));
			if (!prov1)
			{
				prov1 = true;
			}
			else if (!prov2)
			{
				prov2 = true;
				num1 = (ModLoader.GetMod("CalamityMod").NPCType("Providence"));
			}
			else if (!prov3)
			{
				prov3 = true;
				num1 = (ModLoader.GetMod("CalamityMod").NPCType("Providence"));
			}
			else if (!dog1)
			{
				dog1 = true;
				num1 = (ModLoader.GetMod("CalamityMod").NPCType("DevourerofGodsHead"));
			}
			else if (!dog2)
			{
				dog2 = true;
				num1 = (ModLoader.GetMod("CalamityMod").NPCType("DevourerofGodsHead"));
			}
			else if (!dog3)
			{
				dog3 = true;
				num1 = (ModLoader.GetMod("CalamityMod").NPCType("DevourerofGodsHead"));
			}
			else if (!yharon1)
			{
				yharon1 = true;
				num1 = (ModLoader.GetMod("CalamityMod").NPCType("Yharon"));
			}
			else if (!yharon2)
			{
				yharon2 = true;
				num1 = (ModLoader.GetMod("CalamityMod").NPCType("Yharon"));
			}
			else if (!yharon3)
			{
				yharon3 = true;
				num1 = (ModLoader.GetMod("CalamityMod").NPCType("Yharon"));
			}
			else if (!scal1)
			{
				scal1 = true;
				num1 = (ModLoader.GetMod("CalamityMod").NPCType("Yharon"));
			}
			NPC.SpawnOnPlayer(npc.FindClosestPlayer(), num1);
			NPC.SpawnOnPlayer(npc.FindClosestPlayer(), (ModLoader.GetMod("CalamityMod").NPCType("Polterghast")));
		}
	}

    public override void NPCLoot()
	{
		Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FogG") , Main.rand.Next(1, 1), false, 0, false, false);	
		NPC.SpawnOnPlayer(Main.player[Main.myPlayer].whoAmI, mod.NPCType("Jharim"));	
	}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.55f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.65f);
		}
	}
}