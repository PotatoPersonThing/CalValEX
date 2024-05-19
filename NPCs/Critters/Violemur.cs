using CalValEX.Items.Tiles.Banners;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;
//using CalamityMod.CalPlayer;

namespace CalValEX.NPCs.Critters
{
    public class Violemur : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Violemur");
            Main.npcFrameCount[NPC.type] = 7;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Squirrel);
            NPC.catchItem = (short)ItemType<ViolemurItem>();
            NPC.lavaImmune = false;
            AIType = NPCID.Squirrel;
            AnimationType = NPCID.Squirrel;
            NPC.npcSlots = 0.25f;
            NPC.lifeMax = 20;
            NPC.chaseable = false;
            Banner = NPC.type;
            BannerItem = ItemType<ViolemurBanner>();
            NPC.HitSound = new Terraria.Audio.SoundStyle("CalValEX/Sounds/ViolemurHit");
            NPC.DeathSound = new Terraria.Audio.SoundStyle("CalValEX/Sounds/ViolemurDeath");
        }

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement($"Mods.CalValEX.Bestiary.{Name}")
                //("Curious little mammals that have fallen victim to the extraterrestrial virus. Violemurs still hold some degree of independence in contrast to the infection's other lifeforms."),
            });
        }
        public override bool? CanBeHitByItem(Player player, Item item) => null;

        public override bool? CanBeHitByProjectile(Projectile projectile) => null;

        [JITWhenModsEnabled("CalamityMod")]
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (CalValEX.CalamityActive)
            {
                if (CalValEX.InCalamityBiome(spawnInfo.Player, "AstralInfectionBiome") && !CalValEXConfig.Instance.CritterSpawns)
                {
                    if (spawnInfo.PlayerSafe)
                    {
                        return Terraria.ModLoader.Utilities.SpawnCondition.TownCritter.Chance;
                    }
                    else if (
                        !Main.eclipse &
                        !Main.snowMoon &
                        !Main.pumpkinMoon &
                        Main.invasionType == InvasionID.None)
                    {
                        return 0.15f;
                    }
                }
            }
            return 0f;
        }

        public override void HitEffect(NPC.HitInfo hit) {
            if (Main.netMode == NetmodeID.Server)
                return;

            if (NPC.life <= 0) {
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Violemur").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Violemur2").Type, 1f);
            }
        }


        [JITWhenModsEnabled("CalamityMod")]
        public override void AI()
        {
            if (CalValEX.CalamityActive)
            {
                for (int i = 0; i < NPC.buffImmune.Length; i++)
                {
                    NPC.buffImmune[CalValEX.CalamityBuff("AstralInfectionDebuff")] = false;
                }
                //SpawnModBiomes = new int[1] { ModContent.GetInstance<CalamityMod.BiomeManagers.AbovegroundAstralBiome>().Type };
            }
        }
    }
}