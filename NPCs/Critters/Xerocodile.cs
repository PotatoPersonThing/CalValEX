using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;

namespace CalValEX.NPCs.Critters
{
    public class Xerocodile : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Xerocodile");
            Main.npcFrameCount[NPC.type] = 6;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Squirrel);
            NPC.catchItem = (short)ItemType<XerocodileItem>();
            NPC.lavaImmune = false;
            AIType = NPCID.Squirrel;
            AnimationType = NPCID.Squirrel;
            NPC.npcSlots = 0.25f;
            NPC.lifeMax = 666;
            Banner = NPC.type;
            BannerItem = ItemType<Items.Tiles.Banners.XerocodileBanner>();
            NPC.HitSound = SoundID.NPCHit50;
            NPC.DeathSound = SoundID.NPCDeath54;
            NPC.chaseable = false;
        }

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                Terraria.GameContent.Bestiary.BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon,
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement($"Mods.CalValEX.Bestiary.{Name}")
                //("An ancient species of reptile that only comes out during Blood Moons. They are otherwise too frail to linger, and any sunlight exposure is lethal."),
            });
        }
        public override bool? CanBeHitByItem(Player player, Item item) => null;

        public override bool? CanBeHitByProjectile(Projectile projectile) => null;

        public override void AI()
        {
            CVUtils.CritterBestiary(NPC, Type);
            if (NPC.wet)
            {
                NPC.Transform(NPCType<XerocodileSwim>());
            }
            bool inGarden = false;
            if (CalValEX.instance.wotg != null)
            {
                if ((bool)ModLoader.GetMod("SubworldLibrary").Call("AnyActive", CalValEX.instance.wotg))
                {
                    inGarden = true;
                }
            }
            if (!Main.bloodMoon && !inGarden)
            {
                if (CalValEX.CalamityActive)
                    Item.NewItem(NPC.GetSource_FromAI(), NPC.position, NPC.width, NPC.height, CalValEX.CalamityItem("Gorecodile"), 1, false, 0, false, false);
                NPC.active = false;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (!CalValEXConfig.Instance.CritterSpawns)
            {
                if (CalValEX.CalamityActive)
                {
                    if ((bool)CalValEX.Calamity.Call("GetBossDowned", "providence") && Main.bloodMoon)
                    {
                        if (spawnInfo.PlayerSafe)
                        {
                            return Terraria.ModLoader.Utilities.SpawnCondition.TownCritter.Chance * 0.01f;
                        }
                        else if (!Main.eclipse && !Main.pumpkinMoon && !Main.snowMoon)
                        {
                            return 0.015f;
                        }
                    }
                }
                if (CalValEX.instance.wotg != null)
                {
                    if (spawnInfo.Player.InModBiome(CalValEX.instance.wotg.Find<ModBiome>("EternalGardenBiome")))
                    {
                        return 0.2f;
                    }
                }
            }
            return 0f;
        }
        public override void HitEffect(NPC.HitInfo hit) {
            if (Main.netMode == NetmodeID.Server)
                return;

            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Xerocodile").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Xerocodile2").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Xerocodile3").Type, 1f);
            }
        }
    }
}