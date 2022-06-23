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
    public class Eyedol : ModNPC
    {

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Eyedol");
            Main.npcFrameCount[NPC.type] = 4;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
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
            if (CalamityMod.DownedBossSystem.downedProvidence)
            {
                NPC.lifeMax = 500;
            }
            NPC.HitSound = SoundID.NPCHit33;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.catchItem = (short)ItemType<EyedolItem>();
            NPC.lavaImmune = true;
            //NPC.friendly = true; // We have to add this and CanBeHitByItem/CanBeHitByProjectile because of reasons.
            NPC.npcSlots = 0.25f;
            Banner = NPC.type;
            BannerItem = ItemType<EyedolBanner>();
            SpawnModBiomes = new int[1] { ModContent.GetInstance<CalamityMod.BiomeManagers.BrimstoneCragsBiome>().Type };
        }

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("Back in the prime of the capital, some would make small idols to worship the goddess at home. The destruction of the capital infused some of these with magic, giving them sentience."),
            });
        }
        public override bool? CanBeHitByItem(Player player, Item item) => null;

        public override bool? CanBeHitByProjectile(Projectile projectile) => null;

        public override void OnCaughtBy(Player player, Item item, bool failed)
        {
            Item.NewItem(new EntitySource_CatchEntity(player, NPC), new Vector2(player.position.X, player.position.Y), ItemType<EyedolItem>());
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
            //Mod clamMod = ModLoader.GetMod("CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
            //if (clamMod != null)
            {
                if (spawnInfo.Player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>().ZoneCalamity && !CalValEXConfig.Instance.CritterSpawns)
                {
                    return 0.35f;
                }
            }
            return 0f;
        }
    }
}