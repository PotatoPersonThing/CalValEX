using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;

namespace CalValEX.NPCs.Critters {
    public class PerfoGrub : ModNPC {
        public override void SetStaticDefaults() {
            Main.npcFrameCount[NPC.type] = 4;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
        }

        public override void SetDefaults() {
            NPC.CloneDefaults(NPCID.Snail);
            NPC.width = 22;
            NPC.height = 18;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.npcSlots = 0.5f;
            NPC.catchItem = ItemType<PerfoGrubItem>();
            NPC.lavaImmune = false;
            NPC.chaseable = false;
            NPC.friendly = true;
            AIType = NPCID.Snail;
            AnimationType = NPCID.GlowingSnail;
            NPC.lifeMax = 5;
            NPC.value = 0;
        }

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry) {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                Terraria.GameContent.Bestiary.BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky,
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("A small grub-like parasite, the vile offspring of the Perforators."),
            });
        }

        public override bool? CanBeHitByItem(Player player, Item item) {
            return true;
        }

        public override bool? CanBeHitByProjectile(Projectile projectile) {
            return true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (spawnInfo.Player.ZoneCrimson && !CalValEXConfig.Instance.CritterSpawns) {
                return 0.35f;
            }
            return 0f;
        }

        public override void AI() {
            NPC.spriteDirection = -NPC.direction;
            NPC.TargetClosest(false);
        }

        public override void OnCaughtBy(Player player, Item item, bool failed) => item.stack = 1;

    }
}