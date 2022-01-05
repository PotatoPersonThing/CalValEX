using CalValEX.Items.Tiles.Banners;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;
using CalValEX.Items.Tiles.Banners;

namespace CalValEX.NPCs.Critters
{
    /// <summary>
    /// This file shows off a critter npc. The unique thing about critters is how you can catch them with a bug net.
    /// The important bits are: Main.npcCatchable, npc.catchItem, and item.makeNPC
    /// We will also show off adding an item to an existing RecipeGroup (see ExampleMod.AddRecipeGroups)
    /// </summary>
    public class AstJR : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astragelly Slime");
            Main.npcFrameCount[npc.type] = 2;
            Main.npcCatchable[npc.type] = true;
        }

        public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.BabySlime);
            npc.width = 26;
            npc.height = 22;
            npc.damage = 0;
            npc.defense = 0;
            npc.npcSlots = 0.5f;
            npc.catchItem = (short)ItemType<AstJRItem>();
            npc.lavaImmune = false;
            npc.friendly = true; // We have to add this and CanBeHitByItem/CanBeHitByProjectile because of reasons.
            aiType = NPCID.Pinky;
            animationType = NPCID.BlueSlime;
            npc.lifeMax = 100;
            npc.Opacity = 255;
            npc.value = 0;
            for (int i = 0; i < npc.buffImmune.Length; i++)
            {
                npc.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("AstralInfection")] = false;
            }
            banner = npc.type;
            bannerItem = ItemType<AstragellySlimeBanner>();
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
                        return SpawnCondition.TownCritter.Chance * 0.5f;
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