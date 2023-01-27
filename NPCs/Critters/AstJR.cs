using CalValEX.Items.Tiles.Banners;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace CalValEX.NPCs.Critters
{
    public class AstJR : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Astragelly Slime");
            Main.npcFrameCount[NPC.type] = 2;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
        }
        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("A sentient glob from the alien environment. Unlike other slimes, it possesses no offensive capabilities."),
            });
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.BabySlime);
            NPC.width = 26;
            NPC.height = 22;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.npcSlots = 0.5f;
            NPC.catchItem = (short)ItemType<AstJRItem>();
            NPC.lavaImmune = false;
            AIType = NPCID.Pinky;
            AnimationType = NPCID.BlueSlime;
            NPC.lifeMax = 100;
            NPC.Opacity = 255;
            NPC.value = 0;
            NPC.chaseable = false;
            Banner = NPC.type;
            BannerItem = ItemType<AstragellySlimeBanner>();
            //SpawnModBiomes = new int[1] { ModContent.GetInstance<Biomes.AstralBlight>().Type };
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void AI()
        {
            NPC.spriteDirection = -NPC.direction;
            NPC.TargetClosest(false);
            if (CalValEX.CalamityActive)
            {
                for (int i = 0; i < NPC.buffImmune.Length; i++)
                {
                    NPC.buffImmune[CalValEX.CalamityBuff("AstralInfectionDebuff")] = false;
                }
            }
        }
        public override bool? CanBeHitByItem(Player player, Item item) => null;

        public override bool? CanBeHitByProjectile(Projectile projectile) => null;

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome(ModContent.GetInstance<Biomes.AstralBlight>()) && !CalValEXConfig.Instance.CritterSpawns)
            {
                if (spawnInfo.PlayerSafe)
                {
                    return Terraria.ModLoader.Utilities.SpawnCondition.TownCritter.Chance * 0.5f;
                }
                else if (!Main.eclipse && !Main.bloodMoon && !Main.pumpkinMoon && !Main.snowMoon)
                {
                    return 0.15f;
                }
            }
            return 0f;
        }
    }
}