using CalValEX.Items.Tiles.Banners;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CalValEX.NPCs.Critters
{
    internal class OrthoceraApparition : ModNPC
    {
        public override string Texture => "CalamityMod/NPCs/AcidRain/Orthocera";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orthocera?");
            Main.npcFrameCount[npc.type] = 5;
        }

        public override void SetDefaults()
        {
            npc.width = 62;
            npc.height = 34;
            npc.aiStyle = -1;
            npc.damage = 0;
            npc.defense = 62821;
            npc.lifeMax = 62821;
            npc.noGravity = true;
            npc.lavaImmune = false;
            npc.noTileCollide = true;
            npc.dontTakeDamage = true;
            npc.chaseable = false;
            aiType = -1;
            npc.npcSlots = 0.25f;
            for (int i = 0; i < npc.buffImmune.Length; i++)
            {
                npc.buffImmune[(ModLoader.GetMod("CalamityMod").BuffType("SulphuricPoisoning"))] = false;
            }
        }

        public override bool? CanBeHitByItem(Player player, Item item)
        {
            return false;
        }

        public override bool? CanBeHitByProjectile(Projectile projectile)
        {
            return false;
        }

        bool soundplayed = false;
        bool orthogod = false;
        int orthocount = 0;
        public override void AI()
        {
            npc.spriteDirection = -npc.direction;

            Player player = Main.LocalPlayer;

            float xDist = npc.position.X - player.position.X;
            float yDist = npc.position.Y - player.position.Y;

            int DungeonDirection = 1;
            if (Main.dungeonX < Main.spawnTileX)
            {
                DungeonDirection = -1;
            }

            if ((yDist <= 120) && (xDist <= 120))
            {
                orthogod = true;
            }
            if (orthogod)
            {
                if (!soundplayed)
                {
                    Vector2 orthopos = new Vector2(player.position.X + 500 * DungeonDirection, player.position.Y);
                    npc.position = orthopos;
                    Main.PlaySound(SoundID.NPCDeath13, (int)npc.position.X, (int)npc.position.Y);
                    soundplayed = true;
                    npc.direction = 1;
                    for (int x = 0; x < 60; x++)
                    {
                        Dust dust;
                        dust = Main.dust[Terraria.Dust.NewDust(npc.Center, 63, 63, 57, 0f, 0f, 0, new Color(8, 255, 0), 0.9210526f)];
                    }
                }
                orthocount++;

                if (orthocount == 120)
                {
                    npc.velocity.X = 20 * DungeonDirection;
                    npc.direction = -1 * DungeonDirection;
                }

                if (orthocount == 210)
                {
                    soundplayed = false;
                    orthocount = 0;
                    orthogod = false;
                    npc.active = false;
                    for (int x = 0; x < 60; x++)
                    {
                        Dust dust;
                        dust = Main.dust[Terraria.Dust.NewDust(npc.Center, 63, 63, 57, 0f, 0f, 0, new Color(8, 255, 0), 0.9210526f)];
                    }
                    CalValEXWorld.orthofound = true;
                    CalValEXWorld.UpdateWorldBool();
                }
            }
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
            if (npc.frameCounter >= 6)
            {
                npc.frameCounter = 0;
                npc.frame.Y += frameHeight;
                if (npc.frame.Y >= Main.npcFrameCount[npc.type] * frameHeight)
                {
                    npc.frame.Y = 0;
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Mod orthoceraDLC = ModLoader.GetMod("CalValPlus");
            Mod clamMod = ModLoader.GetMod("CalamityMod"); 
            if (clamMod != null)
            {
                if ((bool)clamMod.Call("GetInZone", Main.player[Main.myPlayer], "sulphursea") && (bool)clamMod.Call("GetBossDowned", "supremecalamitas") && !NPC.AnyNPCs(ModContent.NPCType<OrthoceraApparition>()) && (!CalValEXWorld.orthofound || orthoceraDLC != null))
                {
                    return 5f;
                }
            }
            return 0f;
        }
    }
}