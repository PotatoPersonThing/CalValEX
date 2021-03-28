using Microsoft.Xna.Framework;
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
    internal class GAstJR : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astrageldon Senior");
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
            npc.catchItem = (short)ItemType<GAstJRItem>();
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

        public override void AI()
        {
            npc.TargetClosest(false);

            if (Main.rand.NextFloat() < 0.1f)
            {
                Dust dust;
                Vector2 positionLeft = new Vector2(npc.position.X, npc.position.Y - 8);
                Vector2 positionRight = new Vector2(npc.position.X, npc.position.Y - 8);
                if (npc.direction == -1)
                {
                    dust = Main.dust[Terraria.Dust.NewDust(positionLeft, 13, 11, 246, 0.4f, 1f, 0, new Color(255, 249, 57), 0.5f)];
                    dust.noGravity = true;
                }
                else if (npc.direction != 0)
                {
                    dust = Main.dust[Terraria.Dust.NewDust(positionRight, 13, 11, 246, 0.4f, 1f, 0, new Color(255, 249, 57), 0.5f)];
                    dust.noGravity = true;
                }
            }
        }

        public override void OnCatchNPC(Player player, Item item)
        {
            item.stack = 1;
        }
    }
}