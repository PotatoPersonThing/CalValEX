using CalValEX.Items.Tiles.Banners;
using Microsoft.Xna.Framework;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;
//using CalamityMod.CalPlayer;
using Terraria.DataStructures;

namespace CalValEX.NPCs.Critters
{
    public class GoldenIsopod : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 8;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
            NPCID.Sets.NormalGoldCritterBestiaryPriority.Add(Type);
            NPCID.Sets.GoldCrittersCollection.Add(Type);
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void SetDefaults()
        {
            NPC.width = 56;
            NPC.height = 26;
            NPC.CloneDefaults(NPCID.GlowingSnail);
            NPC.catchItem = (short)ItemType<GoldenIsopodItem>();
            NPC.lavaImmune = false;
            AIType = NPCID.GlowingSnail;
            AnimationType = NPCID.GlowingSnail;
            NPC.HitSound = SoundID.NPCHit38;
            NPC.rarity = 5;
            NPC.lifeMax = 20000;
            NPC.chaseable = false;
            Banner = NPCType<Isopod>();
            BannerItem = ItemType<IsopodBanner>();
        }

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("Even in the darkest of places, gilded entities such as the Gold Isopod can be found."),
            });
        }
        public override bool? CanBeHitByItem(Player player, Item item) => null;

        public override bool? CanBeHitByProjectile(Projectile projectile) => null;

        [JITWhenModsEnabled("CalamityMod")]
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (CalValEX.CalamityActive)
            {
                if ((bool)ModLoader.GetMod("CalamityMod").Call("GetZone", spawnInfo.Player, "layer4") && !CalValEXConfig.Instance.CritterSpawns)
                {
                    if (spawnInfo.Water)
                    {
                        return Terraria.ModLoader.Utilities.SpawnCondition.CaveJellyfish.Chance * 0.02f;
                    }
                }
            }
            return 0f;
        }

        public override void OnCaughtBy(Player player, Item item, bool failed)
        {
            Item.NewItem(new EntitySource_CatchEntity(player, NPC), new Vector2(player.position.X, player.position.Y), ItemType<GoldenIsopodItem>());
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("GoldIsopod").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("GoldIsopod2").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("GoldIsopod3").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("GoldIsopod4").Type, 1f);
            }
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void AI()
        {
            if (Main.rand.NextFloat() < 0.1f)
            {
                Dust dust;
                Vector2 positionLeft = new Vector2(NPC.position.X, NPC.position.Y - 8);
                Vector2 positionRight = new Vector2(NPC.position.X, NPC.position.Y - 8);
                if (NPC.direction == -1)
                {
                    dust = Main.dust[Terraria.Dust.NewDust(positionLeft, 3, 3, DustID.GoldCoin, 0.4f, 1f, 0, new Color(255, 249, 57), 0.5f)];
                    dust.noGravity = true;
                }
                else if (NPC.direction != 0)
                {
                    dust = Main.dust[Terraria.Dust.NewDust(positionRight, 3, 3, DustID.GoldCoin, 0.4f, 1f, 0, new Color(255, 249, 57), 0.5f)];
                    dust.noGravity = true;
                }
            }
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