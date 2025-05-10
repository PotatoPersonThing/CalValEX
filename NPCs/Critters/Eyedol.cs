using CalValEX.Items.Tiles.Banners;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;
//using CalamityMod.CalPlayer;

namespace CalValEX.NPCs.Critters
{
    public class Eyedol : ModNPC
    {

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 4;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
        }

        public override void SetDefaults()
        {
            NPC.width = 28;
            NPC.height = 24;
            NPC.aiStyle = -1;
            AIType = -1;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.lifeMax = 100;
            NPC.HitSound = SoundID.NPCHit33;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.catchItem = (short)ItemType<EyedolItem>();
            NPC.lavaImmune = true;
            NPC.chaseable = false;
            NPC.npcSlots = 0.25f;
            Banner = NPC.type;
            BannerItem = ItemType<EyedolBanner>();
            NPC.buffImmune[BuffID.OnFire] = true;
            if (CalValEX.CalamityActive)
            {
                SpawnModBiomes = [CalValEX.CalamityBiome("BrimstoneCragsBiome").Type];
                NPC.buffImmune[CalValEX.CalamityBuff("BrimstoneFlames")] = true;
            }
        }

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement($"Mods.CalValEX.Bestiary.{Name}")
                //("Back in the prime of the capital, some would make small idols to worship the goddess at home. The destruction of the capital infused some of these with magic, giving them sentience."),
            });
        }


        private const int Frame_Up = 0;
        private const int Frame_Rightup = 1;
        private const int Frame_Rightdown = 2;
        private const int Frame_Down = 3;

        public override void FindFrame(int frameHeight)
        {
            NPC.spriteDirection = NPC.direction;
            NPC.TargetClosest(true);
            Vector2 targetPosition = Main.player[NPC.target].position;

            if (targetPosition.Y - NPC.position.Y <= 0f)
            {
                NPC.frame.Y = Frame_Rightup * frameHeight;

                if (targetPosition.X - NPC.position.X < 25 && targetPosition.X - NPC.position.X > -25)
                {
                    NPC.frame.Y = Frame_Up * frameHeight;
                }
            }
            if (targetPosition.Y - NPC.position.Y > 0f)
            {
                NPC.frame.Y = Frame_Rightdown * frameHeight;

                if (targetPosition.X - NPC.position.X < 25 && targetPosition.X - NPC.position.X > -25)
                {
                    NPC.frame.Y = Frame_Down * frameHeight;
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (CalValEX.CalamityActive)
            {
                if (spawnInfo.Player.InModBiome(CalValEX.CalamityBiome("BrimstoneCragsBiome")) && !CalValEXConfig.Instance.CritterSpawns)
                {
                    return 0.35f;
                }
            }
            return 0f;
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void AI()
        {
            CVUtils.CritterBestiary(NPC, Type);
            if (CalValEX.CalamityActive)
            {
                if (CalamityMod.DownedBossSystem.downedProvidence)
                {
                    NPC.lifeMax = 500;
                    if (NPC.ai[0] == 0)
                    {
                        NPC.life = 500;
                        NPC.ai[0]++;
                    }
                }
            }
        }
    }
}