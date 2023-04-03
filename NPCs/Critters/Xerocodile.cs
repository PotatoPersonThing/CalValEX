using CalValEX.Items.Tiles.Banners;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;
using CalValEX.Items;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace CalValEX.NPCs.Critters
{
    public class Xerocodile : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Xerocodile");
            Main.npcFrameCount[NPC.type] = 6;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Squirrel);
            NPC.catchItem = (short)ItemType<XerocodileItem>();
            NPC.lavaImmune = false;
            AIType = NPCID.Squirrel;
            AnimationType = NPCID.Squirrel;
            NPC.npcSlots = 0.25f;
            NPC.lifeMax = 666;
            Banner = NPC.type;
            BannerItem = ItemType<Items.Tiles.Banners.XerocodileBanner>();
            NPC.HitSound = SoundID.NPCHit50;
            NPC.DeathSound = SoundID.NPCDeath54;
            NPC.chaseable = false;
        }

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                Terraria.GameContent.Bestiary.BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon,
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("An ancient species of reptile that only comes out during Blood Moons. They are otherwise too frail to linger, and any sunlight exposure is lethal."),
            });
        }
        public override bool? CanBeHitByItem(Player player, Item item) => null;

        public override bool? CanBeHitByProjectile(Projectile projectile) => null;

        [JITWhenModsEnabled("CalamityMod")]
        public override void AI()
        {
            if (NPC.wet)
            {
                NPC.Transform(ModContent.NPCType<XerocodileSwim>());
            }
            if (!Main.bloodMoon)
            {
                if (CalValEX.CalamityActive)
                Item.NewItem(NPC.GetSource_FromAI(), NPC.position, NPC.width, NPC.height, CalValEX.CalamityItem("Gorecodile"), 1, false, 0, false, false);
                NPC.active = false;
            }
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (CalValEX.CalamityActive)
            {
                if ((bool)CalValEX.Calamity.Call("GetBossDowned", "providence") && Main.bloodMoon && !CalValEXConfig.Instance.CritterSpawns)
                {
                    if (spawnInfo.PlayerSafe)
                    {
                        return Terraria.ModLoader.Utilities.SpawnCondition.TownCritter.Chance * 0.01f;
                    }
                    else if (!Main.eclipse && !Main.pumpkinMoon && !Main.snowMoon)
                    {
                        return 0.0015f;
                    }
                }
            }
            return 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Xerocodile").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Xerocodile2").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Xerocodile3").Type, 1f);
            }
        }
    }
}