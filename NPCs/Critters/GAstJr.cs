using Microsoft.Xna.Framework;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;
using CalValEX.Items.Tiles.Banners;

namespace CalValEX.NPCs.Critters
{
    public class GAstJR : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Gold Astragelly Slime");
            Main.npcFrameCount[NPC.type] = 2;
            Main.npcCatchable[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.BabySlime);
            NPC.width = 26;
            NPC.height = 22;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.npcSlots = 0.5f;
            NPC.catchItem = (short)ItemType<GAstJRItem>();
            NPC.lavaImmune = false;
            NPC.friendly = true; // We have to add this and CanBeHitByItem/CanBeHitByProjectile because of reasons.
            AIType = NPCID.Pinky;
            AnimationType = NPCID.BlueSlime;
            NPC.lifeMax = 100;
            NPC.Opacity = 255;
            NPC.value = 0;
            for (int i = 0; i < NPC.buffImmune.Length; i++)
            {
                //NPC.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("AstralInfection")] = false;
            }
            Banner = NPCType<AstJR>();
            BannerItem = ItemType<AstragellySlimeBanner>();
            SpawnModBiomes = new int[1] { ModContent.GetInstance<Biomes.AstralBlight>().Type };
        }
        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("A sentient glob from the alien environment. Unlike other slimes, it possesses no offensive capabilities."),
            });
        }

        public override bool? CanBeHitByItem(Player player, Item item)
        {
            return true;
        }

        public override bool? CanBeHitByProjectile(Projectile projectile)
        {
            return true;
        }

        public override void AI()
        {
            NPC.TargetClosest(false);

            if (Main.rand.NextFloat() < 0.1f)
            {
                Dust dust;
                Vector2 positionLeft = new Vector2(NPC.position.X, NPC.position.Y - 8);
                Vector2 positionRight = new Vector2(NPC.position.X, NPC.position.Y - 8);
                if (NPC.direction == -1)
                {
                    dust = Main.dust[Terraria.Dust.NewDust(positionLeft, 13, 11, 246, 0.4f, 1f, 0, new Color(255, 249, 57), 0.5f)];
                    dust.noGravity = true;
                }
                else if (NPC.direction != 0)
                {
                    dust = Main.dust[Terraria.Dust.NewDust(positionRight, 13, 11, 246, 0.4f, 1f, 0, new Color(255, 249, 57), 0.5f)];
                    dust.noGravity = true;
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            //Mod clamMod = ModLoader.GetMod("CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
            //if (clamMod != null)
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
            }
            return 0f;
        }

        public override void OnCatchNPC(Player player, Item item)
        {
            item.stack = 1;
        }
    }
}