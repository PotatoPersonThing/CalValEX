using CalValEX.Items.Tiles.Banners;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CalValEX.Items.Critters;

namespace CalValEX.NPCs.Critters
{
    public class Blightolemur : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bleamur");
            Main.npcFrameCount[NPC.type] = 5;
            Main.npcCatchable[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            NPC.width = 38;
            NPC.height = 38;
            //NPC.aiStyle = 67;
            //NPC.damage = 0;
            //NPC.defense = 0;
            //NPC.lifeMax = 2000;

            //NPC.noGravity = true;
            //NPC.catchItem = 2007;

            NPC.CloneDefaults(NPCID.Squirrel);
            NPC.catchItem = (short)ItemType<BlightolemurItem>();
            NPC.lavaImmune = false;
            //NPC.aiStyle = 0;
            NPC.friendly = true; // We have to add this and CanBeHitByItem/CanBeHitByProjectile because of reasons.
            AIType = NPCID.Squirrel;
            AnimationType = NPCID.Squirrel;
            NPC.npcSlots = 0.25f;
            NPC.lifeMax = 20;
            for (int i = 0; i < NPC.buffImmune.Length; i++)
            {
                //NPC.buffImmune[(ModLoader.GetMod("CalamityMod").BuffType("AstralInfectionDebuff"))] = false;
            }
            Banner = NPC.type;
            BannerItem = ItemType<BleamurBanner>();
            NPC.HitSound = SoundLoader.GetLegacySoundSlot(Mod, "Sounds/ViolemurHit");
            NPC.DeathSound = SoundLoader.GetLegacySoundSlot(Mod, "Sounds/ViolemurDeath");
        }
        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                Terraria.GameContent.Bestiary.BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Meteor,
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("On another fractal of the light spectrum from the Violemurs, the Bleamurs frollic peacefully in the Astral Blight, while using their tail patterns to attract prey."),
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
            if (!CalValEXConfig.Instance.ViolemurDefense)
            {
                NPC.dontTakeDamageFromHostiles = true;
                NPC.netUpdate = true;
            }
            else
            {
                NPC.dontTakeDamageFromHostiles = false;
                NPC.netUpdate = true;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            //Mod clamMod = ModLoader.GetMod("CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
            //if (clamMod != null)
            {
                if (spawnInfo.player.GetModPlayer<CalValEXPlayer>().ZoneAstral && !CalValEXConfig.Instance.CritterSpawns)
                {
                    if (spawnInfo.playerSafe)
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
        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Bleamur").Type, 1f);
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Bleamur2").Type, 1f);
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Bleamur3").Type, 1f);
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("Bleamur4").Type, 1f);
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
    }
}