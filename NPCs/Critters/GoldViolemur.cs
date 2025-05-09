using CalValEX.Items.Tiles.Banners;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;
//using CalamityMod.CalPlayer;

namespace CalValEX.NPCs.Critters
{
    public class GoldViolemur : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Gold Violemur");
            Main.npcFrameCount[NPC.type] = 7;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.NormalGoldCritterBestiaryPriority.Add(Type);
            NPCID.Sets.GoldCrittersCollection.Add(Type);
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Squirrel);
            NPC.catchItem = (short)ItemType<GoldViolemurItem>();
            NPC.lavaImmune = false;
            AIType = NPCID.Squirrel;
            AnimationType = NPCID.Squirrel;
            NPC.npcSlots = 0.25f;
            NPC.lifeMax = 20;
            NPC.rarity = 3;
            NPC.chaseable = false;
            Banner = NPCType<Violemur>();
            BannerItem = ItemType<ViolemurBanner>();
            NPC.HitSound = new Terraria.Audio.SoundStyle("CalValEX/Sounds/ViolemurHit");
            NPC.DeathSound = new Terraria.Audio.SoundStyle("CalValEX/Sounds/ViolemurDeath");
            if (CalValEX.CalamityActive)
            {
                SpawnModBiomes = [CalValEX.CalamityBiome("AstralInfectionBiome").Type];
                NPC.buffImmune[CalValEX.CalamityBuff("AstralInfectionDebuff")] = true;
            }
        }

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement($"Mods.CalValEX.Bestiary.{Name}")
                //("A rare critter variant. The Gold Violemur is said to be a leader of sorts to the infection's other Violemurs."),
            });
        }

        public override void AI()
        {
            CVUtils.CritterBestiary(NPC, Type);
            if (Main.rand.NextFloat() < 0.1f)
            {
                Dust dust;
                Vector2 positionLeft = new(NPC.position.X, NPC.position.Y - 8);
                Vector2 positionRight = new(NPC.position.X, NPC.position.Y - 8);
                if (NPC.direction == -1)
                {
                    dust = Main.dust[Dust.NewDust(positionLeft, 3, 3, DustID.GoldCoin, 0.4f, 1f, 0, new Color(255, 249, 57), 0.5f)];
                    dust.noGravity = true;
                }
                else if (NPC.direction != 0)
                {
                    dust = Main.dust[Dust.NewDust(positionRight, 3, 3, DustID.GoldCoin, 0.4f, 1f, 0, new Color(255, 249, 57), 0.5f)];
                    dust.noGravity = true;
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (CalValEX.CalamityActive)
            {
                if (CalValEX.InCalamityBiome(spawnInfo.Player, "AstralInfectionBiome") && !CalValEXConfig.Instance.CritterSpawns)
                {
                    if (spawnInfo.PlayerSafe)
                    {
                        return Terraria.ModLoader.Utilities.SpawnCondition.TownCritter.Chance * 0.02f;
                    }
                    else if (
                        !Main.eclipse &
                        !Main.snowMoon &
                        !Main.pumpkinMoon &
                        Main.invasionType == InvasionID.None)
                    {
                        return 0.02f;
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
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("GoldViolemur").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("GoldViolemur2").Type, 1f);
            }
        }
    }
}