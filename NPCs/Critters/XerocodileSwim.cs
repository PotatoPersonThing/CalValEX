using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;
using CalValEX.Items;

namespace CalValEX.NPCs.Critters
{
    public class XerocodileSwim : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Xerocodile");
            Main.npcFrameCount[NPC.type] = 6;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.NPCBestiaryDrawModifiers bestiaryData = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Hide = true // Hides this NPC from the bestiary
            };
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
            NPC.friendly = true; // We have to add this and CanBeHitByItem/CanBeHitByProjectile because of reasons.
            Banner = NPCType<Xerocodile>();
            BannerItem = ItemType<Items.Tiles.Banners.XerocodileBanner>();
            AIType = NPCID.Goldfish;
            AnimationType = NPCID.Goldfish;
        }
        public override void AI()
        {
            if (!NPC.wet)
            {
                NPC.Transform(ModContent.NPCType<Xerocodile>());
            }
            if (!Main.bloodMoon)
            {
                //Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, clamMod.ItemType("Xerocodile"), 1, false, 0, false, false);
                NPC.active = false;
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
            //Mod clamMod = ModLoader.GetMod("CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
            //if (clamMod != null)
            {
                if (/*(bool)clamMod.Call("CalValEX/GetBossDowned", "providence")*/ NPC.downedEmpressOfLight && Main.bloodMoon && !CalValEXConfig.Instance.CritterSpawns)
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

        public override void OnCatchNPC(Player player, Item item)
        {
            item.stack = 1;
        }

        /*public override void NPCLoot()
        {
            Mod clamMod = ModLoader.GetMod("CalamityMod");
            if ((bool)clamMod.Call("CalValEX/GetBossDowned", "yharon"))
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<Termipebbles>(), 1, false, 0, false, false);
            }
        }*/
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