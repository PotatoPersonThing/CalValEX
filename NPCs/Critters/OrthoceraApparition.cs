using CalValEX.Items.Tiles.Banners;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//using CalamityMod.CalPlayer;

namespace CalValEX.NPCs.Critters
{
    public class OrthoceraApparition : ModNPC
    {
        public override void SetStaticDefaults()
        {
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
            Main.npcFrameCount[NPC.type] = 5;
        }
        [JITWhenModsEnabled("CalamityMod")]
        public override void SetDefaults()
        {
            NPC.width = 62;
            NPC.height = 34;
            NPC.aiStyle = -1;
            NPC.damage = 0;
            NPC.defense = 62821;
            NPC.lifeMax = 62821;
            NPC.noGravity = true;
            NPC.lavaImmune = false;
            NPC.noTileCollide = true;
            NPC.dontTakeDamage = true;
            NPC.chaseable = false;
            AIType = -1;
            NPC.npcSlots = 0.25f;
        }

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("A harbinger of an apocalypse to come. Do not take its warning lightly."),
            });
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
        [JITWhenModsEnabled("CalamityMod")]
        public override void AI()
        {
            if (CalValEX.CalamityActive)
            {
                //SpawnModBiomes = new int[1] { ModContent.GetInstance<CalamityMod.BiomeManagers.SulphurousSeaBiome>().Type };
            }

            NPC.spriteDirection = -NPC.direction;

            Player player = Main.LocalPlayer;

            float xDist = NPC.position.X - player.position.X;
            float yDist = NPC.position.Y - player.position.Y;

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
                    NPC.position = orthopos;
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.NPCDeath13, NPC.position);
                    soundplayed = true;
                    NPC.direction = 1;
                    for (int x = 0; x < 60; x++)
                    {
                        Dust dust;
                        dust = Main.dust[Terraria.Dust.NewDust(NPC.Center, 63, 63, DustID.Enchanted_Gold, 0f, 0f, 0, new Color(8, 255, 0), 0.9210526f)];
                    }
                }
                orthocount++;

                if (orthocount == 120)
                {
                    NPC.velocity.X = 20 * DungeonDirection;
                    NPC.direction = -1 * DungeonDirection;
                }

                if (orthocount == 210)
                {
                    soundplayed = false;
                    orthocount = 0;
                    orthogod = false;
                    Main.BestiaryTracker.Kills.RegisterKill(NPC);
                    NPC.active = false;
                    for (int x = 0; x < 60; x++)
                    {
                        Dust dust;
                        dust = Main.dust[Terraria.Dust.NewDust(NPC.Center, 63, 63, DustID.Enchanted_Gold, 0f, 0f, 0, new Color(8, 255, 0), 0.9210526f)];
                    }
                    CalValEXWorld.orthofound = true;
                    CalValEXWorld.UpdateWorldBool();
                }
            }
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            if (NPC.frameCounter >= 6)
            {
                NPC.frameCounter = 0;
                NPC.frame.Y += frameHeight;
                if (NPC.frame.Y >= Main.npcFrameCount[NPC.type] * frameHeight)
                {
                    NPC.frame.Y = 0;
                }
            }
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (CalValEX.CalamityActive)
            {
                Mod cal = ModLoader.GetMod("CalamityMod");
                if ((bool)cal.Call("getbossdowned", "scal") && (bool)cal.Call("getbossdowned", "exomechs") && !NPC.AnyNPCs(ModContent.NPCType<OrthoceraApparition>()) && !CalValEXWorld.orthofound)
                {
                    if (CalValEX.InCalamityBiome(spawnInfo.Player, "SulphurousSeaBiome"));
                    {
                        return 5f;
                    }
                }
            }
            return 0f;
        }
    }
}