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
    public class XerocodileSwim : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Xerocodile");
            Main.npcFrameCount[NPC.type] = 6;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Hide = true
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            NPC.noGravity = true;
            NPC.width = 20;
            NPC.height = 24;
            NPC.aiStyle = 16;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.lifeMax = 666;
            NPC.HitSound = SoundID.NPCHit50;
            NPC.DeathSound = SoundID.NPCDeath54;
            NPC.npcSlots = 0.25f;
            NPC.catchItem = (short)ItemType<XerocodileItem>();
            NPC.lavaImmune = false;
            //NPC.friendly = true; // We have to add this and CanBeHitByItem/CanBeHitByProjectile because of reasons.
            Banner = NPCType<Xerocodile>();
            BannerItem = ItemType<Items.Tiles.Banners.XerocodileBanner>();
            AIType = NPCID.Goldfish;
            AnimationType = NPCID.Goldfish;
            NPC.chaseable = false;
        }
        [JITWhenModsEnabled("CalamityMod")]
        public override void AI()
        {
            if (!NPC.wet)
            {
                NPC.Transform(ModContent.NPCType<Xerocodile>());
            }
            if (!Main.bloodMoon)
            {
                Item.NewItem(NPC.GetSource_FromAI(), NPC.position, NPC.width, NPC.height, CalValEX.CalamityItem("Gorecodile"), 1, false, 0, false, false);
                NPC.active = false;
            }
        }
        public override bool? CanBeHitByItem(Player player, Item item) => null;

        public override bool? CanBeHitByProjectile(Projectile projectile) => null;

        [JITWhenModsEnabled("CalamityMod")]
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (CalValEX.CalamityActive)
            {
                if (CalamityMod.DownedBossSystem.downedProvidence && Main.bloodMoon && !CalValEXConfig.Instance.CritterSpawns)
                {
                    if (spawnInfo.PlayerSafe)
                    {
                        return Terraria.ModLoader.Utilities.SpawnCondition.WaterCritter.Chance * 0.01f;
                    }
                    else if (!Main.eclipse && !Main.pumpkinMoon && !Main.snowMoon)
                    {
                        return Terraria.ModLoader.Utilities.SpawnCondition.OceanMonster.Chance * 0.0015f;
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