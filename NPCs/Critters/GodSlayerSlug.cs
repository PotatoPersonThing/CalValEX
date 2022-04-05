using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;

namespace CalValEX.NPCs.Critters
{
    public class GodSlayerSlug : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("God Slayer Slug");
            Main.npcFrameCount[NPC.type] = 4;
            Main.npcCatchable[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            NPC.width = 22;
            NPC.height = 18;
            //NPC.aiStyle = 67;
            //NPC.damage = 0;
            //NPC.defense = 0;
            //NPC.lifeMax = 2000;
            //NPC.HitSound = SoundID.NPCHit38;
            //NPC.DeathSound = SoundID.NPCDeath1;
            //NPC.npcSlots = 0.5f;
            //NPC.noGravity = true;
            //NPC.catchItem = 2007;

            NPC.CloneDefaults(NPCID.GlowingSnail);
            NPC.catchItem = (short)ItemType<GodSlayerSlugItem>();
            NPC.lavaImmune = false;
            //NPC.aiStyle = 0;
            NPC.friendly = true; // We have to add this and CanBeHitByItem/CanBeHitByProjectile because of reasons.
            AIType = NPCID.GlowingSnail;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.lifeMax = 5000;
            Banner = NPC.type;
            BannerItem = ItemType<Items.Tiles.Banners.GodSlayerSlugBanner>();
        }
        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                Terraria.GameContent.Bestiary.BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("Mimicking the purple worm-like appearance of the cosmic worms, this little bug peacefully wanders the upper atmosphere."),
            });
        }

        public override void AI()
        {
            if (NPC.position.Y > Main.worldSurface * 7.0)
            {
                NPC.life = 0;
                NPC.HitEffect();
                NPC.active = false;
                NPC.netUpdate = true;
                Projectile.NewProjectile(NPC.GetSpawnSourceForProjectileNPC(), NPC.position.X, NPC.position.Y, 0f, 7f, 12, 0, 0f, Main.myPlayer);
            }
            else
            {
                return;
            }
        }

        public override bool? CanBeHitByItem(Player player, Item item)
        {
            return true;
        }

        public override bool? CanBeHitByProjectile(Projectile projectile)
        {
            return true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            //Mod calamityMod = ModLoader.GetMod("CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
            if (/*(bool)calamityMod.Call("CalValEX/GetBossDowned", "devourerofgods")*/ NPC.downedMoonlord && !CalValEXConfig.Instance.CritterSpawns && spawnInfo.player.ZoneSkyHeight)
            {
                if (Main.raining)
                {
                    return 0.4f;
                }
                else
                {
                    return 0.05f;
                }
            }
            else
            {
                return 0f;
            }
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter += 0.1f;
            NPC.frameCounter %= Main.npcFrameCount[NPC.type];
            int frame = (int)NPC.frameCounter;
            NPC.frame.Y = frame * frameHeight;
        }

        public override void OnCatchNPC(Player player, Item item)
        {
            item.stack = 1;
        }

        // TODO: Hooks for Collision_MoveSnailOnSlopes and NPC.aiStyle = 67 problem
    }
}