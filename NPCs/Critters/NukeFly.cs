using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;
//using CalamityMod.CalPlayer;

namespace CalValEX.NPCs.Critters
{
    public class NukeFly : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Vaporofly");
            Main.npcFrameCount[NPC.type] = 8;
            Main.npcCatchable[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            NPC.width = 20;
            NPC.height = 20;
            NPC.CloneDefaults(NPCID.Firefly);
            NPC.catchItem = (short)ItemType<NukeFlyItem>();
            NPC.lavaImmune = false;
            //NPC.aiStyle = 0;
            //NPC.friendly = true; // We have to add this and CanBeHitByItem/CanBeHitByProjectile because of reasons.
            AIType = NPCID.Firefly;
            AnimationType = NPCID.Firefly;
            NPC.lifeMax = 20;
            for (int i = 0; i < NPC.buffImmune.Length; i++)
            {
                //NPC.buffImmune[(ModLoader.GetMod("CalamityMod").BuffType("SulphuricPoisoning"))] = false;
            }
        }

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.UIInfoProvider = new Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type], quickUnlock: true);
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                Terraria.GameContent.Bestiary.BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("An ancient insect species that was revitalized by the radioactive waters."),
            });
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            //Mod clamMod = ModLoader.GetMod("CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
            //if (clamMod != null)
            {
                if (spawnInfo.Player.ZoneBeach/*GetModPlayer<CalamityPlayer>().ZoneSulphur*/ && !CalValEXConfig.Instance.CritterSpawns)
                {
                    if (spawnInfo.Player.ZoneOverworldHeight)
                    {
                        return Terraria.ModLoader.Utilities.SpawnCondition.OverworldNight.Chance * 0.5f;
                    }
                }
                return 0f;
            }
            return 0f;
        }

        public override void OnCatchNPC(Player player, Item item)
        {
            item.stack = 1;
        }

        public void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale)
        {
            Vector2 origin = new Vector2(NPC.width * .5f, NPC.height * .5f);
            SpriteEffects effect = NPC.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            spriteBatch.Draw(ModContent.Request<Texture2D>("Items/Critters/NukeFly_Glow").Value, NPC.Center - Main.screenPosition, new Rectangle?(), Color.White, rotation, origin, scale, effect, 0f);
        }

        public override void AI()
        {
            if (Main.rand.NextFloat() < 0.3421053f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 positionLeft = new Vector2(NPC.position.X + 9, NPC.position.Y);
                Vector2 positionRight = new Vector2(NPC.position.X - 9, NPC.position.Y);
                if (NPC.direction == -1)
                {
                    dust = Main.dust[Terraria.Dust.NewDust(positionLeft, 0, 0, 6, 1f, 1f, 0, new Color(109, 255, 0), 0.5f)];
                    dust.noGravity = true;
                }
                else if (NPC.direction != 0)
                {
                    dust = Main.dust[Terraria.Dust.NewDust(positionRight, 0, 0, 6, 1f, 1f, 0, new Color(109, 255, 0), 0.5f)];
                    dust.noGravity = true;
                }
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {

            Texture2D texture = ModContent.Request<Texture2D>("CalValEX/NPCs/Critters/NukeFly_Glow").Value;
            float vapeframe = 8f / (float)Main.npcFrameCount[NPC.type];
            int vapeheight = (int)((float)(NPC.frame.Y / NPC.frame.Height) * vapeframe) * (texture.Height / 8);

            Rectangle vapesquare = new Rectangle(0, vapeheight, texture.Width, texture.Height / 8);

            SpriteEffects rainbowy = SpriteEffects.None;
            if (NPC.spriteDirection == 1)
            {
                rainbowy = SpriteEffects.FlipHorizontally;
            }
            spriteBatch.Draw(texture, NPC.Center - Main.screenPosition, vapesquare, NPC.color, NPC.rotation, Utils.Size(vapesquare) / 2f, NPC.scale, rainbowy, 0f);
        }
    }
}