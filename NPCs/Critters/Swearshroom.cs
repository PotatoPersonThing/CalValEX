using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;

namespace CalValEX.NPCs.Critters
{
    public class Swearshroom : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Swearshroom");
            Main.npcFrameCount[NPC.type] = 5;
            Main.npcCatchable[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            NPC.width = 22;
            NPC.height = 22;
            NPC.aiStyle = 7;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.lifeMax = 100;
            NPC.HitSound = SoundID.NPCHit26;
            NPC.DeathSound = SoundID.NPCDeath1;

            NPC.catchItem = (short)ItemType<SwearshroomItem>();
            NPC.lavaImmune = false;
            NPC.friendly = true; // We have to add this and CanBeHitByItem/CanBeHitByProjectile because of reasons.
            AIType = NPCID.Mouse;
            AnimationType = NPCID.Grubby;
            NPC.npcSlots = 0.25f;
            NPC.dontTakeDamage = true;
        }

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                Terraria.GameContent.Bestiary.BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundMushroom,
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("The great crustacean's spores are not happy that their host has been destroyed. These wicked fungi have psychopathic tendencies, but are completely harmless."),
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

        public override void OnCatchNPC(Player player, Item item)
        {
            item.stack = 1;
        }

        private int nohurt = 120;

        public override void AI()
        {
            if (--nohurt == 0)
            {
                NPC.dontTakeDamage = false;
                NPC.netUpdate = true;
            }
        }
    }
}