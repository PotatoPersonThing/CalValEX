using CalValEX.Items.Tiles.Banners;
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
    public class Xerocodile : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Xerocodile");
            Main.npcFrameCount[NPC.type] = 6;
            Main.npcCatchable[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            //NPC.width = 56;
            //NPC.height = 26;
            //NPC.aiStyle = 67;
            //NPC.damage = 0;
            //NPC.defense = 0;
            //NPC.lifeMax = 2000;

            //NPC.noGravity = true;
            //NPC.catchItem = 2007;

            NPC.CloneDefaults(NPCID.Squirrel);
            NPC.catchItem = (short)ItemType<XerocodileItem>();
            NPC.lavaImmune = false;
            //NPC.aiStyle = 0;
            NPC.friendly = true; // We have to add this and CanBeHitByItem/CanBeHitByProjectile because of reasons.
            AIType = NPCID.Squirrel;
            AnimationType = NPCID.Squirrel;
            NPC.npcSlots = 0.25f;
            NPC.lifeMax = 666;
            Banner = NPC.type;
            BannerItem = ItemType<Items.Tiles.Banners.XerocodileBanner>();
            NPC.HitSound = SoundID.NPCHit50;
            NPC.DeathSound = SoundID.NPCDeath54;
        }

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                Terraria.GameContent.Bestiary.BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.BloodMoon,
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("An ancient species of reptile that only comes out during Blood Moons. They are otherwise too frail to linger, and any sunlight exposure is lethal."),
            });
        }

        public override void AI()
        {
            //Mod clamMod = ModLoader.GetMod("CalamityMod");
            if (NPC.wet)
            {
                NPC.Transform(ModContent.NPCType<XerocodileSwim>());
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
                    if (spawnInfo.playerSafe)
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
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Xerocodile").Type, 1f);
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Xerocodile2").Type, 1f);
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Xerocodile3").Type, 1f);
            }
        }
    }
}