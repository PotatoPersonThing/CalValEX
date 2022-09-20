using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;

namespace CalValEX.NPCs.Critters {
    public class NeuroFly : ModNPC {
        public override void SetStaticDefaults() {
            Main.npcFrameCount[NPC.type] = 4;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
        }

        public override void SetDefaults() {
            NPC.CloneDefaults(NPCID.BlackDragonfly);
            NPC.width = 26;
            NPC.height = 22;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.npcSlots = 0.5f;
            NPC.catchItem = ItemType<NeuroFlyItem>();
            NPC.lavaImmune = true;
            AIType = NPCID.BlackDragonfly;
            AnimationType = NPCID.BlackDragonfly;
            NPC.lifeMax = 20;
            NPC.value = 0;
            NPC.chaseable = false;
        }

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry) {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("One of the many creatures assisting the Hive Mind, although not physically connected, they share a psychic connection. Its sole purpose is to spread the virus."),
            });
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (spawnInfo.Player.ZoneCorrupt && !CalValEXConfig.Instance.CritterSpawns) {
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