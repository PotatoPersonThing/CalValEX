using CalValEX.Items.Tiles.Banners;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;

namespace CalValEX.NPCs.Critters
{
    public class SandTurtle : ModNPC
    {
        int heal = 0;
        private bool shellin;
        private bool shellout;

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Sand Turtle");
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
            NPC.catchItem = (short)ItemType<SandTurtleItem>();
            NPC.lavaImmune = false;
            //NPC.aiStyle = 0;
            //NPC.friendly = true; // We have to add this and CanBeHitByItem/CanBeHitByProjectile because of reasons.
            AIType = NPCID.Squirrel;
            AnimationType = -1;
            NPC.npcSlots = 0.25f;
            NPC.lifeMax = 300;
            NPC.GivenName = Main.rand.NextFloat() < 0.00014f ? "Debrina" : "Sand Turtle";
            Banner = NPC.type;
            BannerItem = ItemType<Items.Tiles.Banners.SandTurtleBanner>();
            NPC.HitSound = SoundID.NPCHit50;
            NPC.DeathSound = SoundID.NPCDeath54;
        }
        float valax = 0;

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                Terraria.GameContent.Bestiary.BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundDesert,
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("A horrific and violent testudine with high defensive capabilities. They are too dangerous to be left alive."),
            });
        }

        public override void AI()
        { 
            NPC.spriteDirection = NPC.direction;
            if (NPC.localAI[0] != 4)
            {
                valax = Math.Abs(NPC.velocity.X);
                NPC.defense = 0;
                NPC.dontTakeDamageFromHostiles = false;
                if (NPC.velocity.X != 0 && (NPC.velocity.X > 1 || NPC.velocity.X < -1))
                {
                    NPC.velocity.X = (NPC.velocity.X / valax) * 1;
                }
                //shellout = false;
                //shellin = false;
            }
            //Mod clamMod = ModLoader.GetMod("CalamityMod");
            if (NPC.life <= NPC.lifeMax * 0.5f && NPC.localAI[0] != 4)
            {
                NPC.localAI[0] = 4;
            }
            if (NPC.localAI[0] == 4)
            {
                heal++;
                /*shellin = true;
                if (shellin == true && heal == 5)
                {
                    shellin = false;
                }
                if (NPC.life == NPC.lifeMax * 0.9f)
                {
                    shellout = true;
                }*/
                NPC.velocity.X = 0;
                NPC.defense = 99;
                NPC.dontTakeDamageFromHostiles = true;
                if (heal == 8)
                {
                    NPC.life += 1;
                    heal = 0;
                }

                if (NPC.life >= NPC.lifeMax)
                {
                    NPC.localAI[0] = 1;
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode && !CalValEXConfig.Instance.CritterSpawns && spawnInfo.Player.ZoneUndergroundDesert)
            {
                if (spawnInfo.PlayerSafe)
                {
                    return Terraria.ModLoader.Utilities.SpawnCondition.DesertCave.Chance * 0.025f;
                }
                else
                {
                    return Terraria.ModLoader.Utilities.SpawnCondition.DesertCave.Chance * 0.05f;
                }
            }
            return 0f;
        }
        public override void FindFrame(int frameHeight) //9 total frames
        {
            NPC.frameCounter += 1.0;
            /*if (shellin || shellout)
            {
                NPC.frame.Y = 4 * frameHeight;
            }
            else */
            if (NPC.localAI[0] == 4)
            {
                NPC.frame.Y = 5 * frameHeight;
            }
            else if (NPC.velocity.X == 0)
            {
                NPC.frame.Y = 0 * frameHeight;
            }
            else
            {
                if (NPC.frameCounter > 4.0)
                {
                    NPC.frame.Y = NPC.frame.Y + frameHeight;
                    NPC.frameCounter = 0.0;
                }
                if (NPC.frame.Y >= frameHeight * 4)
                {
                    NPC.frame.Y = 1;
                }
            }
            /*NPC.frameCounter += 1.0;
            if (shellin || shellout)
            {
                NPC.frameCounter = 4.0;
                NPC.frame.Y = NPC.frame.Y + frameHeight;
            }
            else if (NPC.localAI[0] == 4 && !shellout && !shellin)
            {
                NPC.frameCounter = 5.0;
                NPC.frame.Y = NPC.frame.Y + frameHeight;
            }
            else if (NPC.velocity.X != 0)
            {
                if (NPC.frameCounter > 2.0)
                {
                    NPC.frameCounter = 1.0;
                    NPC.frame.Y = NPC.frame.Y + frameHeight;
                }
            }
            else
            {
                if (NPC.frameCounter > 0)
                {
                    NPC.frameCounter = 0;
                    NPC.frame.Y = NPC.frame.Y + frameHeight;
                }
            }*/
        }

        public override void OnCatchNPC(Player player, Item item)
        {
            item.stack = 1;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SandTurtle").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SandTurtle2").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SandTurtle3").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SandTurtle4").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SandTurtle5").Type, 1f);
            }
        }
    }
}