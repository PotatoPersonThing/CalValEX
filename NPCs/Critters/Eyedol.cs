using CalValEX.Items.Tiles.Banners;
using Microsoft.Xna.Framework;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;
using CalamityMod.CalPlayer;

namespace CalValEX.NPCs.Critters
{
    /// <summary>
    /// This file shows off a critter npc. The unique thing about critters is how you can catch them with a bug net.
    /// The important bits are: Main.npcCatchable, npc.catchItem, and item.makeNPC
    /// We will also show off adding an item to an existing RecipeGroup (see ExampleMod.AddRecipeGroups)
    /// </summary>
    public class Eyedol : ModNPC
    {
        public override bool Autoload(ref string name)
        {
            IL.Terraria.Wiring.HitWireSingle += HookStatue;
            return base.Autoload(ref name);
        }

        /// <summary>
        /// Change the following code sequence in Wiring.HitWireSingle
        /// num12 = Utils.SelectRandom(Main.rand, new short[5]
        /// {
        /// 	359,
        /// 	359,
        /// 	359,
        /// 	359,
        /// 	360,
        /// });
        ///
        /// to
        ///
        /// var arr = new short[5]
        /// {
        /// 	359,
        /// 	359,
        /// 	359,
        /// 	359,
        /// 	360,
        /// }
        /// arr = arr.ToList().Add(id).ToArray();
        /// num12 = Utils.SelectRandom(Main.rand, arr);
        ///
        /// </summary>
        /// <param name="il"></param>
        private void HookStatue(ILContext il)
        {
            // obtain a cursor positioned before the first instruction of the method
            // the cursor is used for navigating and modifying the il
            var c = new ILCursor(il);

            // the exact location for this hook is very complex to search for due to the hook instructions not being unique, and buried deep in control flow
            // switch statements are sometimes compiled to if-else chains, and debug builds litter the code with no-ops and redundant locals

            // in general you want to search using structure and function rather than numerical constants which may change across different versions or compile settings
            // using local variable indices is almost always a bad idea

            // we can search for
            // switch (*)
            //   case 56:
            //     Utils.SelectRandom *

            // in general you'd want to look for a specific switch variable, or perhaps the containing switch (type) { case 105:
            // but the generated IL is really variable and hard to match in this case

            // we'll just use the fact that there are no other switch statements with case 56, followed by a SelectRandom

            ILLabel[] targets = null;
            while (c.TryGotoNext(i => i.MatchSwitch(out targets)))
            {
                // some optimising compilers generate a sub so that all the switch cases start at 0
                // ldc.i4.s 51
                // sub
                // switch
                int offset = 0;
                if (c.Prev.MatchSub() && c.Prev.Previous.MatchLdcI4(out offset))
                {
                    ;
                }

                // get the label for case 56: if it exists
                int case56Index = 56 - offset;
                if (case56Index < 0 || case56Index >= targets.Length || !(targets[case56Index] is ILLabel target))
                {
                    continue;
                }

                // move the cursor to case 56:
                c.GotoLabel(target);
                // there's lots of extra checks we could add here to make sure we're at the right spot, such as not encountering any branching instructions
                c.GotoNext(i => i.MatchCall(typeof(Utils), nameof(Utils.SelectRandom)));

                // goto next positions us before the instruction we searched for, so we can insert our array modifying code right here
                c.EmitDelegate<Func<short[], short[]>>(arr =>
                {
                    // resize the array and add our custom snail
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length - 1] = (short)npc.type;
                    return arr;
                });

                // hook applied successfully
                return;
            }

            // couldn't find the right place to insert
            throw new Exception("Hook location not found, switch(*) { case 56: ...");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eyedol");
            Main.npcFrameCount[npc.type] = 4;
            Main.npcCatchable[npc.type] = true;
        }

        public override void SetDefaults()
        {
            npc.width = 28;
            npc.height = 24;
            npc.aiStyle = -1;
            aiType = -1;
            npc.damage = 0;
            npc.defense = 0;
            npc.lifeMax = 100;
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if ((bool)calamityMod.Call("GetBossDowned", "providence"))
            {
                npc.lifeMax = 500;
            }
            npc.HitSound = SoundID.NPCHit33;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.catchItem = (short)ItemType<EyedolItem>();
            npc.lavaImmune = true;
            npc.friendly = true; // We have to add this and CanBeHitByItem/CanBeHitByProjectile because of reasons.
            npc.npcSlots = 0.25f;
            banner = npc.type;
            bannerItem = ItemType<EyedolBanner>();
        }

        public override bool? CanBeHitByItem(Player player, Item item)
        {
            return true;
        }

        public override bool? CanBeHitByProjectile(Projectile projectile)
        {
            return true;
        }

        public override void OnCatchNPC(Player player, Item item)
        {
            item.stack = 1;
        }

        private const int Frame_Up = 0;
        private const int Frame_Rightup = 1;
        private const int Frame_Rightdown = 2;
        private const int Frame_Down = 3;

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            npc.TargetClosest(true);
            Vector2 targetPosition = Main.player[npc.target].position;

            if (targetPosition.Y - npc.position.Y <= 0f)
            {
                npc.frame.Y = Frame_Rightup * frameHeight;

                if (targetPosition.X - npc.position.X < 25 && targetPosition.X - npc.position.X > -25)
                {
                    npc.frame.Y = Frame_Up * frameHeight;
                }
            }
            if (targetPosition.Y - npc.position.Y > 0f)
            {
                npc.frame.Y = Frame_Rightdown * frameHeight;

                if (targetPosition.X - npc.position.X < 25 && targetPosition.X - npc.position.X > -25)
                {
                    npc.frame.Y = Frame_Down * frameHeight;
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Mod clamMod = ModLoader.GetMod("CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
            if (clamMod != null)
            {
                if (spawnInfo.player.GetModPlayer<CalamityPlayer>().ZoneCalamity && !CalValEXConfig.Instance.CritterSpawns)
                {
                    return 0.35f;
                }
            }
            return 0f;
        }
    }
}