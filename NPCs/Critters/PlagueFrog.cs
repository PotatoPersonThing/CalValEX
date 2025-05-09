using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;

namespace CalValEX.NPCs.Critters
{
    public class PlagueFrog : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 13;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Frog);
            NPC.catchItem = (short)ItemType<PlagueFrogItem>();
            NPC.lavaImmune = false;
            AIType = NPCID.Frog;
            AnimationType = NPCID.Frog;
            NPC.lifeMax = 20;
            NPC.chaseable = false;
            if (CalValEX.CalamityActive)
            {
                NPC.buffImmune[CalValEX.CalamityBuff("Plague")] = true;
            }
        }
        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                Terraria.GameContent.Bestiary.BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement($"Mods.CalValEX.Bestiary.{Name}")
                //("The plague unleashed by the scientist didn't just infect the already hostile creatures. Peaceful lifeforms such as frogs were also unfortunate enough to fall victim to it."),
            });
        }

        public override void AI()
        {
            CVUtils.CritterBestiary(NPC, Type);
            var thisRect = NPC.getRect();

            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                var proj = Main.projectile[i];

                if (proj != null && proj.active && proj.getRect().Intersects(thisRect) & proj.type == ProjectileID.PurificationPowder)
                {
                    NPC.Transform(NPCID.Frog);
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.PlayerSafe || !NPC.downedGolemBoss || CalValEXConfig.Instance.CritterSpawns)
            {
                return 0f;
            }
            return Terraria.ModLoader.Utilities.SpawnCondition.HardmodeJungle.Chance * 0.4f;
        }


        public override void HitEffect(NPC.HitInfo hit) {
            if (Main.netMode == NetmodeID.Server)
                return;

            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PlagueFrog").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PlagueFrog2").Type, 1f);
            }
        }
    }
}