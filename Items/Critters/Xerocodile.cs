/*using CalValEX.Items.Tiles.Banners;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.Critters
{
    /// <summary>
    /// This file shows off a critter npc. The unique thing about critters is how you can catch them with a bug net.
    /// The important bits are: Main.npcCatchable, npc.catchItem, and item.makeNPC
    /// We will also show off adding an item to an existing RecipeGroup (see ExampleMod.AddRecipeGroups)
    /// </summary>
    internal class Xerocodile : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xerocodile THIS CRITTER IS CURRENTLY UNFINISHED AND CAN CRASH YOUR GAME");
            Main.npcFrameCount[npc.type] = 7;
            Main.npcCatchable[npc.type] = true;
        }

        public override void SetDefaults()
        {
            npc.width = 26;
            npc.height = 22;
            npc.damage = 0;
            npc.defense = 0;
            npc.npcSlots = 0.5f;
            npc.catchItem = (short)ItemType<AstJRItem>();
            npc.lavaImmune = false;
            npc.friendly = true; // We have to add this and CanBeHitByItem/CanBeHitByProjectile because of reasons.
            npc.dontTakeDamage = true;
            aiType = -1;
            npc.lifeMax = 100;
            npc.Opacity = 255;
            npc.value = 0;
            npc.noTileCollide = false;
            for (int i = 0; i < npc.buffImmune.Length; i++)
            {
                npc.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("AstralInfection")] = false;
            }
            //banner = npc.type;
            //bannerItem = ItemType<AstJRBanner>();
        }

        public override bool? CanBeHitByItem(Player player, Item item)
        {
            return true;
        }

        public override bool? CanBeHitByProjectile(Projectile projectile)
        {
            return true;
        }

        int movementcounter = 0;
        public override void AI()
        {
            movementcounter++;
            if (!npc.wet)
            {
                npc.velocity.Y = 3;

                if ((movementcounter <= 180) || (movementcounter > 600 && movementcounter <= 840 && npc.velocity.X < 2))
                {
                    npc.velocity.X = 3;
                }
                else if (movementcounter > 180 && movementcounter <= 420)
                {
                    npc.velocity.X = 0;
                }
                else if ((movementcounter > 420 && movementcounter <= 600) || (movementcounter <= 180 && npc.velocity.X < 2))
                {
                    npc.velocity.X = -3;
                }
                else if (movementcounter > 600 && movementcounter <= 840)
                {
                    npc.velocity.X = 0;
                }
                else if (movementcounter > 840)
                {
                    movementcounter = 0;
                }
            }
            if (npc.wet)
            {
                npc.velocity.Y = 0;

                if ((movementcounter <= 180) || (movementcounter > 180 && npc.velocity.X < 2))
                {
                    npc.velocity.X = 3;
                }
                else if ((movementcounter > 180) || (movementcounter <= 180 && npc.velocity.X < 2))
                {
                    npc.velocity.X = -3;
                }
                else if (movementcounter >= 360)
                {
                    movementcounter = 0;
                }
                if (movementcounter >= 240)
                {
                    npc.velocity.Y = -1;
                }
                if (movementcounter <= 240 && movementcounter >=120)
                {
                    npc.velocity.Y = 1;
                }
            }
            npc.TargetClosest(false);
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
            if (npc.frameCounter >= 12)
            {
                npc.frameCounter = 0;
                npc.frame.Y += frameHeight;
                if (npc.frame.Y >= Main.npcFrameCount[npc.type] * frameHeight)
                {
                    npc.frame.Y = 0;
                }
            }
        }*/

        /*public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Mod clamMod = ModLoader.GetMod("CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
            if (clamMod != null)
            {
                if (Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneAstral && !CalValEXConfig.Instance.CritterSpawns)
                {
                    if (spawnInfo.playerSafe)
                    {
                        return SpawnCondition.TownCritter.Chance * 0.5f;
                    }
                    else if (!Main.eclipse && !Main.bloodMoon && !Main.pumpkinMoon && !Main.snowMoon)
                    {
                        return 0.15f;
                    }
                }
            }
            return 0f;
        }*/

        /*public override void OnCatchNPC(Player player, Item item)
        {
            item.stack = 1;
        }
    }
}*/