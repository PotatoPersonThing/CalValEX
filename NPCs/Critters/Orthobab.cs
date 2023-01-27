using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
//using CalamityMod.CalPlayer;

namespace CalValEX.NPCs.Critters
{
    public class Orthobab : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Orthocera Hatchling");
            Main.npcFrameCount[NPC.type] = 6;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void SetDefaults()
        {
            NPC.noGravity = true;
            NPC.width = 20;
            NPC.height = 24;
            NPC.aiStyle = 16;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.lifeMax = 5;
            NPC.HitSound = SoundID.NPCHit38;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.npcSlots = 0.25f;
            NPC.catchItem = (short)ItemType<OrthobabItem>();
            NPC.lavaImmune = false;
            //NPC.friendly = true; // We have to add this and CanBeHitByItem/CanBeHitByProjectile because of reasons.
            AIType = NPCID.Goldfish;
            AnimationType = NPCID.Goldfish;
            NPC.lifeMax = 5;
            NPC.chaseable = false;
        }

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("Newer offspring of The Shelled. Despite their bumbling appearance, any one of these may very well grow into something horrific."),
            });
        }
        public override bool? CanBeHitByItem(Player player, Item item) => null;

        public override bool? CanBeHitByProjectile(Projectile projectile) => null;

        [JITWhenModsEnabled("CalamityMod")]
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (CalValEX.CalamityActive)
            {
                if ((bool)ModLoader.GetMod("CalamityMod").Call("GetInZone", spawnInfo.Player, "sulphursea") && !CalValEXConfig.Instance.CritterSpawns)
                {
                    return 0.15f;
                }
            }
            return 0f;
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void AI()
        {
            if (CalValEX.CalamityActive)
            {
                for (int i = 0; i < NPC.buffImmune.Length; i++)
                {
                    NPC.buffImmune[CalValEX.CalamityBuff("SulphuricPoisoning")] = false;
                }

                //SpawnModBiomes = new int[1] { ModContent.GetInstance<CalamityMod.BiomeManagers.SulphurousSeaBiome>().Type };
            }
        }
        // TODO: Hooks for Collision_MoveSnailOnSlopes and NPC.aiStyle = 67 problem
    }
}