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
    /// This file shows off a critter npc. The unique thing about critters is how you can catch them with a bug net.
    /// The important bits are: Main.npcCatchable, npc.catchItem, and item.makeNPC
    /// We will also show off adding an item to an existing RecipeGroup (see ExampleMod.AddRecipeGroups)
    /// </summary>
    internal class Blinker : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blinker");
            Main.npcFrameCount[npc.type] = 8;
            Main.npcCatchable[npc.type] = true;
        }

        public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.LightningBug);
            npc.width = 14;
            npc.height = 14;
            npc.damage = 0;
            npc.defense = 0;
            npc.npcSlots = 0.5f;
            npc.catchItem = (short)ItemType<BlinkerItem>();
            npc.lavaImmune = false;
            npc.friendly = true; // We have to add this and CanBeHitByItem/CanBeHitByProjectile because of reasons.
            aiType = NPCID.LightningBug;
            animationType = NPCID.Firefly;
            npc.lifeMax = 100;
            npc.Opacity = 255;
            npc.value = 0;
            for (int i = 0; i < npc.buffImmune.Length; i++)
            {
                npc.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("AstralInfection")] = false;
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

        public override void AI()
        { 
            if (Main.rand.NextFloat() < 0.3421053f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 positionLeft = new Vector2(npc.position.X + 9, npc.position.Y);
                Vector2 positionRight = new Vector2(npc.position.X - 9, npc.position.Y);
                if (npc.direction == -1)
                {
                    dust = Main.dust[Terraria.Dust.NewDust(positionLeft, 0, 0, 21, 1f, 1f, 0, new Color(255, 255, 255), 0.5f)];
                    dust.noGravity = true;
                }
                else if (npc.direction != 0)
                {
                    dust = Main.dust[Terraria.Dust.NewDust(positionRight, 0, 0, 21, 1f, 1f, 0, new Color(255, 255, 255), 0.5f)];
                    dust.noGravity = true;
                }
            }
            npc.TargetClosest(false);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Mod clamMod = ModLoader.GetMod("CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
            if (clamMod != null)
            {
                if (spawnInfo.player.GetModPlayer<CalValEXPlayer>().ZoneAstral && !CalValEXConfig.Instance.CritterSpawns)
                {
                    if (spawnInfo.playerSafe)
                    {
                        return SpawnCondition.TownCritter.Chance * 0.2f;
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