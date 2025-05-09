using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;

namespace CalValEX.NPCs.Critters
{
    public class Blinker : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 8;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.LightningBug);
            NPC.width = 14;
            NPC.height = 14;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.npcSlots = 0.5f;
            NPC.catchItem = (short)ItemType<BlinkerItem>();
            NPC.lavaImmune = false;
            AIType = NPCID.LightningBug;
            AnimationType = NPCID.Firefly;
            NPC.lifeMax = 100;
            NPC.Opacity = 255;
            NPC.value = 0;
            NPC.chaseable = false;
            SpawnModBiomes = [GetInstance<Biomes.AstralBlight>().Type];
            if (CalValEX.CalamityActive)
            {
                NPC.buffImmune[CalValEX.CalamityBuff("AstralInfectionDebuff")] = true;
            }
        }

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement($"Mods.CalValEX.Bestiary.{Name}")
                //("A Twinkler that has adapted to the Astral Blight's unique environment. They are a popular food source for its inhabitants."),
            });
        }

        public override void AI()
        { 
            if (Main.rand.NextFloat() < 0.3421053f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 positionLeft = new(NPC.position.X + 9, NPC.position.Y);
                Vector2 positionRight = new(NPC.position.X - 9, NPC.position.Y);
                if (NPC.direction == -1)
                {
                    dust = Main.dust[Dust.NewDust(positionLeft, 0, 0, DustID.VilePowder, 1f, 1f, 0, new Color(255, 255, 255), 0.5f)];
                    dust.noGravity = true;
                }
                else if (NPC.direction != 0)
                {
                    dust = Main.dust[Dust.NewDust(positionRight, 0, 0, DustID.VilePowder, 1f, 1f, 0, new Color(255, 255, 255), 0.5f)];
                    dust.noGravity = true;
                }
            }
            NPC.TargetClosest(false);
            CVUtils.CritterBestiary(NPC, Type);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome(GetInstance<Biomes.AstralBlight>()) && !CalValEXConfig.Instance.CritterSpawns)
            {
                if (spawnInfo.PlayerSafe)
                {
                    return Terraria.ModLoader.Utilities.SpawnCondition.TownCritter.Chance * 0.2f;
                }
                else if (!Main.eclipse && !Main.bloodMoon && !Main.pumpkinMoon && !Main.snowMoon)
                {
                    return 0.15f;
                }
            }
            return 0f;
        }
    }
}