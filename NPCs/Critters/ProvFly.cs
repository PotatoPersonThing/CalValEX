using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace CalValEX.NPCs.Critters
{
    public class ProvFly : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Profaned Butterfly");
            Main.npcFrameCount[NPC.type] = 3;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
        }

        public override void SetDefaults()
        {
            NPC.width = 48;
            NPC.height = 40;
            NPC.aiStyle = 65;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.lifeMax = 5;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.npcSlots = 0.25f;
            NPC.noGravity = true;

            NPC.catchItem = (short)ItemType<ProvFlyItem>();
            NPC.lavaImmune = true;
            //NPC.friendly = true; // We have to add this and CanBeHitByItem/CanBeHitByProjectile because of reasons.
            AIType = NPCID.GoldButterfly;
            AnimationType = NPCID.GoldButterfly;
            NPC.chaseable = false;
            for (int i = 0; i < NPC.buffImmune.Length; i++)
            {
                NPC.buffImmune[(ModContent.BuffType<CalamityMod.Buffs.DamageOverTime.HolyFlames>())] = false;
            }
        }
        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                Terraria.GameContent.Bestiary.BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("A butterfly possessing energy from one of two halves of a fiery goddess' power."),
            });
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.PlayerSafe || !NPC.downedMoonlord || CalValEXConfig.Instance.CritterSpawns)
            {
                return 0f;
            }
            return Terraria.ModLoader.Utilities.SpawnCondition.Underworld.Chance * 0.7f;
        }

    }
}