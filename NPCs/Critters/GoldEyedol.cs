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
    public class GoldEyedol : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Gold Eyedol");
            Main.npcFrameCount[NPC.type] = 4;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.NormalGoldCritterBestiaryPriority.Add(Type);
            NPCID.Sets.GoldCrittersCollection.Add(Type);
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
        }

        [JITWhenModsEnabled("CalamityMod")]
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
            NPC.catchItem = (short)ItemType<GoldEyedolItem>();
            NPC.lavaImmune = true;
            NPC.rarity = 3;
            NPC.chaseable = false;
            NPC.npcSlots = 0.25f;
            Banner = NPCType<Eyedol>();
            BannerItem = ItemType<EyedolBanner>();
        }

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("A specially crafted idol possessed by a spirit. The construct was previously used by the ruler of the capital themself."),
            });
        }
        public override bool? CanBeHitByItem(Player player, Item item) => null;

        public override bool? CanBeHitByProjectile(Projectile projectile) => null;

        public override void OnCaughtBy(Player player, Item item, bool failed)
        {
            Item.NewItem(new EntitySource_CatchEntity(player, NPC), new Vector2(player.position.X, player.position.Y), ItemType<GoldEyedolItem>());
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

        [JITWhenModsEnabled("CalamityMod")]
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (CalValEX.CalamityActive)
            {
                if (CalValEX.InCalamityBiome(spawnInfo.Player, "BrimstoneCragsBiome") && !CalValEXConfig.Instance.CritterSpawns)
                {
                    return 0.02f;
                }
            }
            return 0f;
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void AI()
        {
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
                for (int i = 0; i < NPC.buffImmune.Length; i++)
                {
                    NPC.buffImmune[CalValEX.CalamityBuff("BrimstoneFlames")] = false;
                    NPC.buffImmune[BuffID.OnFire] = false;
                }
                //SpawnModBiomes = new int[1] { GetInstance<CalamityMod.BiomeManagers.BrimstoneCragsBiome>().Type };
            }
            if (Main.rand.NextFloat() < 0.1f)
            {
                Dust dust;
                Vector2 position = new Vector2(NPC.position.X + 9, NPC.position.Y + 5);
                if (NPC.direction == -1)
                {
                    dust = Main.dust[Terraria.Dust.NewDust(position, 3, 3, DustID.GoldCoin, 0.4f, 1f, 0, new Color(255, 249, 57), 0.5f)];
                    dust.noGravity = true;
                }
                else if (NPC.direction != 0)
                {
                    dust = Main.dust[Terraria.Dust.NewDust(position, 3, 3, DustID.GoldCoin, 0.4f, 1f, 0, new Color(255, 249, 57), 0.5f)];
                    dust.noGravity = true;
                }
            }
        }
    }
}