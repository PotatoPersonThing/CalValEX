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
//using CalamityMod.CalPlayer;

namespace CalValEX.NPCs.Critters
{
    public class Isopod : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Abyssal Isopod");
            Main.npcFrameCount[NPC.type] = 8;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void SetDefaults()
        {
            NPC.width = 56;
            NPC.height = 26;
            NPC.CloneDefaults(NPCID.GlowingSnail);
            NPC.catchItem = (short)ItemType<IsopodItem>();
            NPC.lavaImmune = false;
            AIType = NPCID.GlowingSnail;
            AnimationType = NPCID.GlowingSnail;
            NPC.HitSound = SoundID.NPCHit38;
            NPC.lifeMax = 2000;
            NPC.chaseable = false;
            Banner = NPC.type;
            BannerItem = ItemType<IsopodBanner>();
        }
        public override bool? CanBeHitByItem(Player player, Item item) => null;

        public override bool? CanBeHitByProjectile(Projectile projectile) => null;

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("A docile scavenger that makes itself at home at the bottom of the Abyss. They are known to clean up the remains of any victims to the Abyss' other fauna."),
            });
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (CalValEX.CalamityActive)
            {
                if (CalValEX.InCalamityBiome(spawnInfo.Player, "AbyssLayer4Biome") && !CalValEXConfig.Instance.CritterSpawns)
                {
                    if (spawnInfo.Water)
                    {
                        return Terraria.ModLoader.Utilities.SpawnCondition.CaveJellyfish.Chance * 1.2f;
                    }
                }
            }
            return 0f;
        }



        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Isopod").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Isopod2").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Isopod3").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Isopod4").Type, 1f);
            }
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void AI()
        {
            if (CalValEX.CalamityActive)
            {
                for (int i = 0; i < NPC.buffImmune.Length; i++)
                {
                    NPC.buffImmune[CalValEX.CalamityBuff("CrushDepth")] = false;
                }
                //SpawnModBiomes = new int[1] { ModContent.GetInstance<CalamityMod.BiomeManagers.AbyssLayer4Biome>().Type };
            }
        }
    }
}