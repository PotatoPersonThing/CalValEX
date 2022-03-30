using CalValEX.Items.Tiles.Banners;
using MonoMod.Cil;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;

namespace CalValEX.NPCs.Critters
{
    /// <summary>
    /// This file shows off a critter NPC. The unique thing about critters is how you can catch them with a bug net.
    /// The important bits are: Main.npcCatchable, NPC.catchItem, and item.makeNPC
    /// We will also show off adding an item to an existing RecipeGroup (see ExampleMod.AddRecipeGroups)
    /// </summary>
    public class Blinker : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blinker");
            Main.npcFrameCount[NPC.type] = 8;
            Main.npcCatchable[NPC.type] = true;
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
            NPC.friendly = true; // We have to add this and CanBeHitByItem/CanBeHitByProjectile because of reasons.
            AIType = NPCID.LightningBug;
            AnimationType = NPCID.Firefly;
            NPC.lifeMax = 100;
            NPC.Opacity = 255;
            NPC.value = 0;
            for (int i = 0; i < NPC.buffImmune.Length; i++)
            {
                //NPC.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("AstralInfection")] = false;
            }
        }

        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                Terraria.GameContent.Bestiary.BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Meteor,
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("A Twinkler that has adapted to the Astral Blight's unique environment. They are a popular food source for its inhabitants."),
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
            if (Main.rand.NextFloat() < 0.3421053f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 positionLeft = new Vector2(NPC.position.X + 9, NPC.position.Y);
                Vector2 positionRight = new Vector2(NPC.position.X - 9, NPC.position.Y);
                if (NPC.direction == -1)
                {
                    dust = Main.dust[Terraria.Dust.NewDust(positionLeft, 0, 0, 21, 1f, 1f, 0, new Color(255, 255, 255), 0.5f)];
                    dust.noGravity = true;
                }
                else if (NPC.direction != 0)
                {
                    dust = Main.dust[Terraria.Dust.NewDust(positionRight, 0, 0, 21, 1f, 1f, 0, new Color(255, 255, 255), 0.5f)];
                    dust.noGravity = true;
                }
            }
            NPC.TargetClosest(false);
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
                        return Terraria.ModLoader.Utilities.SpawnCondition.TownCritter.Chance * 0.2f;
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
    }
}