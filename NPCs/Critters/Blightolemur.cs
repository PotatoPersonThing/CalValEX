using CalValEX.Items.Tiles.Banners;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CalValEX.Items.Critters;
using Terraria.GameContent.Bestiary;
using Terraria.DataStructures;

namespace CalValEX.NPCs.Critters
{
    public class Blightolemur : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 5;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
        }

        public override void SetDefaults()
        {
            NPC.width = 38;
            NPC.height = 38;
            NPC.CloneDefaults(NPCID.Squirrel);
            NPC.catchItem = (short)ItemType<BlightolemurItem>();
            NPC.lavaImmune = false;
            AIType = NPCID.Squirrel;
            AnimationType = NPCID.Squirrel;
            NPC.npcSlots = 0.25f;
            NPC.lifeMax = 20;
            NPC.chaseable = false;
            Banner = NPC.type;
            BannerItem = ItemType<BleamurBanner>();
            NPC.HitSound = new Terraria.Audio.SoundStyle("CalValEX/Sounds/ViolemurHit");
            NPC.DeathSound = new Terraria.Audio.SoundStyle("CalValEX/Sounds/ViolemurDeath");
            SpawnModBiomes = new int[1] { ModContent.GetInstance<Biomes.AstralBlight>().Type };
        }
        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("On another fractal of the light spectrum from the Violemurs, the Bleamurs frollic peacefully in the Astral Blight, while using their tail patterns to attract prey."),
            });
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
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
            return 0f;
        }
        public override bool? CanBeHitByItem(Player player, Item item) => null;

        public override bool? CanBeHitByProjectile(Projectile projectile) => null;

        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Bleamur").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Bleamur2").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Bleamur3").Type, 1f);
                Gore.NewGore(NPC.GetSource_FromAI(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Bleamur4").Type, 1f);
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D minibirbsprite = (ModContent.Request<Texture2D>("CalValEX/NPCs/Critters/Blightolemur_Glow").Value);

            float minibirbframe = 5f / (float)Main.npcFrameCount[NPC.type];
            int minibirbheight = (int)(float)((NPC.frame.Y / NPC.frame.Height) * minibirbframe) * (minibirbsprite.Height / 5);

            Rectangle minibirbsquare = new Rectangle(0, minibirbheight + 5, minibirbsprite.Width, minibirbsprite.Height / 5);
            SpriteEffects minibirbeffects = (NPC.direction != -1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            spriteBatch.Draw(minibirbsprite, NPC.Center - Main.screenPosition + new Vector2(0f, NPC.gfxOffY), minibirbsquare, Color.White, NPC.rotation, Utils.Size(minibirbsquare) / 2f, NPC.scale, minibirbeffects, 0f);
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void AI()
        {
            if (CalValEX.CalamityActive)
            {
                for (int i = 0; i < NPC.buffImmune.Length; i++)
                {
                    NPC.buffImmune[CalValEX.CalamityBuff("AstralInfectionDebuff")] = false;
                }
            }
        }
    }
}