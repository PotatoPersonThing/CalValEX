using System;
using System.Collections.Generic;
using CalValEX;
using CalValEX.Items.Equips;
using CalValEX.Items.Hooks;
using CalValEX.Items.Pets;
using CalValEX.Items.Tiles;
using CalValEX.Items.Mounts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items;
using CalValEX.Items.Critters;

namespace CalValEX
{
    public class Drops : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            Mod clamMod = ModLoader.GetMod("CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
            if (clamMod != null)
            {
 		if (type == clamMod.NPCType("SEAHOE"))
                {
                    if ((bool)clamMod.Call("GetInZone", Main.player[Main.myPlayer], "sunkensea"))
                    {
                        if ((bool) clamMod.Call("GetBossDowned", "giantclam"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<SSCoral>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 20, 0);
                            ++nextSlot;
                        }
			{
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Anemone>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 20, 0);
                            ++nextSlot;
                        }
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<BrainCoral>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 20, 0);
                            ++nextSlot;
                        }
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<TableCoral>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 20, 0);
                            ++nextSlot;
                        }
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<FanCoral>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 20, 0);
                            ++nextSlot;
                        }
                        if ((bool) clamMod.Call("GetBossDowned", "acidrainscourge"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<BelchingCoral>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 30, 0);
                            ++nextSlot;
                        }
                        if ((bool) clamMod.Call("GetBossDowned", "providence"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<BlazingConflict>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 50, 0, 0);
                            ++nextSlot;
                        }
                        if ((bool) clamMod.Call("GetBossDowned", "oldduke"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<BloodwormScarf>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 50, 0, 0);
                            ++nextSlot;
                        }
                        if ((bool) clamMod.Call("GetBossDowned", "buffedeclipse"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<TheYhar>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 80, 0, 0);
                            ++nextSlot;
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<CalamityFriends>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 0, 0, 0);
                            ++nextSlot;
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<WilliamPainting>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 0, 0, 0);
                            ++nextSlot;
                        }
                        if ((bool) clamMod.Call("GetBossDowned", "supremecalamitas"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Clam>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(2, 0, 0, 0);
                            ++nextSlot;
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Yharlamitas>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(42, 0, 0, 0);
                            ++nextSlot;
                        }
                    }
                    if (!(bool)clamMod.Call("GetInZone", Main.player[Main.myPlayer], "sunkensea"))
                    {
                        if ((bool) clamMod.Call("GetBossDowned", "giantclam"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<SSCoral>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 25, 0);
                            ++nextSlot;
                        }
			{
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Anemone>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 25, 0);
                            ++nextSlot;
                        }
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<BrainCoral>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 25, 0);
                            ++nextSlot;
                        }
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<TableCoral>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 25, 0);
                            ++nextSlot;
                        }
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<FanCoral>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 25, 0);
                            ++nextSlot;
                        }
                        if ((bool) clamMod.Call("GetBossDowned", "acidrainscourge"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<BelchingCoral>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 35, 0);
                            ++nextSlot;
                        }
                        if ((bool) clamMod.Call("GetBossDowned", "providence"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<BlazingConflict>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(5, 0, 0, 0);
                            ++nextSlot;
                        }
                        if ((bool) clamMod.Call("GetBossDowned", "oldduke"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<BloodwormScarf>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(15, 0, 0, 0);
                            ++nextSlot;
                        }
                        if ((bool) clamMod.Call("GetBossDowned", "buffedeclipse"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<TheYhar>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(18, 0, 0, 0);
                            ++nextSlot;
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<CalamityFriends>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(10, 0, 0, 0);
                            ++nextSlot;
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<WilliamPainting>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(10, 0, 0, 0);
                            ++nextSlot;
                        }
                        if ((bool) clamMod.Call("GetBossDowned", "supremecalamitas"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Clam>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(20, 0, 0, 0);
                            ++nextSlot;
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Yharlamitas>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(420, 0, 0, 0);
                            ++nextSlot;
                        }
                    }
                }
                if (type == clamMod.NPCType("DILF"))
                {
                    if ((bool)clamMod.Call("GetBossDowned", "signus"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Signut>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(15, 0, 0, 0);
                        ++nextSlot;
                    }
                }
                if (type == NPCID.Clothier)
                {
                    int bandit = NPC.FindFirstNPC(clamMod.NPCType("THIEF"));
                    int archmage = NPC.FindFirstNPC(clamMod.NPCType("DILF"));
                    if (bandit != -1)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<BanditHat>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 3, 0, 0);
                        ++nextSlot;
                    }
                    if (archmage != -1)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Permascarf>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 3, 0, 0);
                        ++nextSlot;
                    }
                }
                if (type == NPCID.Truffle)
                {
                       shop.item[nextSlot].SetDefaults(ModContent.ItemType<SwearshroomItem>());
                       shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 2, 0);
                       ++nextSlot;
                }
                if (type == NPCID.PartyGirl)
                {
                    if (Main.LocalPlayer.HasItem(ModContent.ItemType<Mirballoon>()))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<TiedMirageBalloon>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 5, 0);
                        ++nextSlot;
                    }
                    if (Main.LocalPlayer.HasItem(ModContent.ItemType<BoxBalloon>()))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<TiedBoxBalloon>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 5, 0);
                        ++nextSlot;
                    }
                    if (Main.LocalPlayer.HasItem(ModContent.ItemType<ChaosBalloon>()))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<TiedChaosBalloon>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 5, 0);
                        ++nextSlot;
                    }
                    if (Main.LocalPlayer.HasItem(ModContent.ItemType<BoB2>()))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<TiedBoB2>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 5, 0);
                        ++nextSlot;
                    }
                }
            }
        }
        public override void NPCLoot(NPC npc)
        {
            Mod mod = ModLoader.GetMod("CalamityMod");
            if (mod == null)
            {
                return;
            }
            //Town NPCs
            if (npc.type == mod.NPCType("DILF"))
            {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<Permascarf>());
            }
            if (npc.type == mod.NPCType("THIEF"))
            {
                Item
                    .NewItem(npc.getRect(),
                    ModContent.ItemType<BanditHat>());
            }
            // Swearshrooms
            if (npc.type == mod.NPCType("CrabShroom"))
            {
	            if (!NPC.AnyNPCs(mod.NPCType("CrabulonIdle")))
        	    {
                    	if (Main.LocalPlayer.HasItem(mod.ItemType("KnowledgeCrabulon")))
                    	{
                    		NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Swearshroom>(), 0, 0f, 0f, 0f, 0f, 255);
                    }
        	}
	    }
            //Prehm
            if (npc.type == mod.NPCType("AngryDog"))
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<TundraBall>());
                }
            }
            if (npc.type == mod.NPCType("BoxJellyfish"))
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<BoxBalloon>());
                }
            }
            if (npc.type == mod.NPCType("Catfish"))
            {
                if (((bool)mod.Call("DifficultyActive", "defiled")) && Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<DiscardedCollar>());
                }
                else if (Utils.NextFloat(Main.rand) < 0.05f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<DiscardedCollar>());
                }
            }
            if (npc.type == mod.NPCType("DespairStone"))
            {
                if (((bool)mod.Call("DifficultyActive", "defiled")) && Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<Drock>());
                }
                else if (Utils.NextFloat(Main.rand) < 0.05f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<Drock>());
                }
            }
            if (npc.type == mod.NPCType("WulfrumDrone") && Main.expertMode)
            {
                if (Utils.NextFloat(Main.rand) < 0.0001f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<AncientAuricTeslaHelm>());
                }
                if (((bool)mod.Call("DifficultyActive", "defiled")) && Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<WulfrumKeys>());
                }
                else if (Utils.NextFloat(Main.rand) < 0.01f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<WulfrumKeys>());
                }
            }
            if (npc.type == mod.NPCType("CosmicElemental"))
            {
                if (Main.rand.NextFloat() < 0.05f)

                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<CosmicCone>());
                }

                else if (((bool)mod.Call("DifficultyActive", "defiled")) && Main.rand.NextFloat() < 0.1f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<CosmicCone>());
                }
            }
            if (npc.type == mod.NPCType("Sunskater"))
            {
                if (Main.rand.NextFloat() < 0.05f)

                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<SkeetCrest>());
                }

                else if (((bool)mod.Call("DifficultyActive", "defiled")) && Main.rand.NextFloat() < 0.1f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<SkeetCrest>());
                }
            }
            if (npc.type == mod.NPCType("AeroSlime") && Main.expertMode)
            {
                if (Main.rand.NextFloat() < 0.05f)

                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<AeroWings>());
                }

                else if (((bool)mod.Call("DifficultyActive", "defiled")) && Main.rand.NextFloat() < 0.1f && Main.expertMode)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<AeroWings>());
                }
            }
            if (npc.type == mod.NPCType("SeaFloaty"))
            {
                if (Main.rand.NextFloat() < 0.05f && Main.expertMode)

                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<FloatyCarpetItem>());
                }

                else if (((bool)mod.Call("DifficultyActive", "defiled")) && Main.rand.NextFloat() < 0.1f && Main.expertMode)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<FloatyCarpetItem>());
                }
            }
             if (npc.type == mod.NPCType("SuperDummyNPC") && Main.LocalPlayer.HeldItem.type != mod.ItemType("SuperDummy"))
            {
                Item.NewItem(npc.getRect(),
                    ModContent.ItemType<DummyMask>());
            }
            //Crawlers
            if (npc.type == mod.NPCType("CrawlerAmethyst"))
            {
                if (Main.rand.NextFloat() < 0.1f)

                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<AmethystStone>());
                }

                else if (((bool)mod.Call("DifficultyActive", "defiled")) && Main.rand.NextFloat() < 0.2f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<AmethystStone>());
                }
            }
            if (npc.type == mod.NPCType("CrawlerTopaz"))
            {
                if (Main.rand.NextFloat() < 0.1f)

                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<TopazStone>());
                }

                else if (((bool)mod.Call("DifficultyActive", "defiled")) && Main.rand.NextFloat() < 0.2f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<TopazStone>());
                }
            }
            if (npc.type == mod.NPCType("CrawlerSapphire"))
            {
                if (Main.rand.NextFloat() < 0.1f)

                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<SapphireStone>());
                }

                else if (((bool)mod.Call("DifficultyActive", "defiled")) && Main.rand.NextFloat() < 0.2f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<SapphireStone>());
                }
            }
            if (npc.type == mod.NPCType("CrawlerEmerald"))
            {
                if (Main.rand.NextFloat() < 0.1f)

                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<EmeraldStone>());
                }

                else if (((bool)mod.Call("DifficultyActive", "defiled")) && Main.rand.NextFloat() < 0.2f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<EmeraldStone>());
                }
            }
            if (npc.type == mod.NPCType("CrawlerRuby"))
            {
                if (Main.rand.NextFloat() < 0.1f)

                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<RubyStone>());
                }

                else if (((bool)mod.Call("DifficultyActive", "defiled")) && Main.rand.NextFloat() < 0.2f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<RubyStone>());
                }
            }
            if (npc.type == mod.NPCType("CrawlerDiamond"))
            {
                if (Main.rand.NextFloat() < 0.1f)

                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<DiamondStone>());
                }

                else if (((bool)mod.Call("DifficultyActive", "defiled")) && Main.rand.NextFloat() < 0.2f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<DiamondStone>());
                }
            }
            if (npc.type == mod.NPCType("CrawlerCrystal"))
            {
                if (Main.rand.NextFloat() < 0.1f)

                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<CrystalStone>());
                }

                else if (((bool)mod.Call("DifficultyActive", "defiled")) && Main.rand.NextFloat() < 0.2f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<CrystalStone>());
                }
            }
            if (npc.type == mod.NPCType("CrawlerAmber"))
            {
                if (Main.rand.NextFloat() < 0.1f)

                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<AmberStone>());
                }

                else if (((bool)mod.Call("DifficultyActive", "defiled")) && Main.rand.NextFloat() < 0.2f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<AmberStone>());
                }
            }
            //end of crawler drops and prehm
            //Acid rain set tier 2
            if (npc.type == mod.NPCType("SulfurousSkater"))
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<SkaterEgg>());
                }
            }
            if (npc.type == mod.NPCType("Orthocera"))
            {
                if (Utils.NextFloat(Main.rand) < 0.05f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<Help>());
                }
                else if (((bool)mod.Call("DifficultyActive", "defiled")) && Main.rand.NextFloat() < 0.1f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<Help>());
                }
            }
            if (npc.type == mod.NPCType("FlakCrab"))
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<FlakHeadCrab>());
                }
            }
            if (npc.type == mod.NPCType("Trilobite"))
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<TrilobiteShield>());
                }
            }
            if (npc.type == mod.NPCType("GammaSlime"))
            {
                if (Utils.NextFloat(Main.rand) < 0.03f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<GammaHelmet>());
                }
            }
            //Astral tree drops all
            if (npc.type == mod.NPCType("AstralProbe"))
            {
                if (Utils.NextFloat(Main.rand) < 0.002f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AstralOldPurple>());
                }
                if (Utils.NextFloat(Main.rand) < 0.001f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AstralOldYellow>());
                }
            }
            if (npc.type == mod.NPCType("SmallSightseer"))
            {
                if (Utils.NextFloat(Main.rand) < 0.001f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AstralOldPurple>());
                }
                if (Utils.NextFloat(Main.rand) < 0.001f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AstralOldYellow>());
                }
            }
            if (npc.type == mod.NPCType("BigSightseer"))
            {
                if (Utils.NextFloat(Main.rand) < 0.001f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AstralOldPurple>());
                }
                if (Utils.NextFloat(Main.rand) < 0.001f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AstralOldYellow>());
                }
            }
            //Astral tree drops surface
            if (npc.type == mod.NPCType("Aries"))
            {
                if (Utils.NextFloat(Main.rand) < 0.001f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AstralOldPurple>());
                }
            }
            if (npc.type == mod.NPCType("AstralSlime"))
            {
                if (Utils.NextFloat(Main.rand) < 0.01f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AstralOldPurple>());
                }
            }
            if (npc.type == mod.NPCType("Atlas"))
            {
                if (Utils.NextFloat(Main.rand) < 0.005f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AstralOldPurple>());
                }
            }
            if (npc.type == mod.NPCType("Nova"))
            {
                if (Utils.NextFloat(Main.rand) < 0.001f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AstralOldPurple>());
                }
            }
            if (npc.type == mod.NPCType("Mantis"))
            {
                if (Utils.NextFloat(Main.rand) < 0.001f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AstralOldPurple>());
                }
            }
            if (npc.type == mod.NPCType("FusionFeeder"))
            {
                if (Utils.NextFloat(Main.rand) < 0.002f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AstralOldPurple>());
                }
            }
            if (npc.type == mod.NPCType("Hadarian"))
            {
                if (Utils.NextFloat(Main.rand) < 0.002f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AstralOldPurple>());
                }
            }
            //Astral tree drops underground
            if (npc.type == mod.NPCType("Hive"))
            {
                if (Utils.NextFloat(Main.rand) < 0.002f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AstralOldYellow>());
                }
            }
            if (npc.type == mod.NPCType("Astralachnea"))
            {
                if (Utils.NextFloat(Main.rand) < 0.001f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AstralOldYellow>());
                }
            }
            if (npc.type == mod.NPCType("StellarCulex"))
            {
                if (Utils.NextFloat(Main.rand) < 0.001f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AstralOldPurple>());
                }
            }
            if (npc.type == mod.NPCType("Hiveling"))
            {
                if (Utils.NextFloat(Main.rand) < 0.0001f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AstralOldPurple>());
                }
            }
            //Hardmode drops
            if (npc.type == mod.NPCType("PerennialSlime"))
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<PerennialFlower>());
                }
                if (Utils.NextFloat(Main.rand) < 0.05f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AncientPerennialFlower>());
                }
                if (Utils.NextFloat(Main.rand) < 0.075f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<PerennialDress>());
                }
            }
            if (npc.type == mod.NPCType("Bohldohr"))
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<BoldEgg>());
                }
            }
            if (npc.type == mod.NPCType("BelchingCoral"))
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<CoralMask>());
                }
            }
            if (npc.type == mod.NPCType("Cryon"))
            {
                if (Utils.NextFloat(Main.rand) < 0.15f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<Cryocap>());
                }
                if (Utils.NextFloat(Main.rand) < 0.15f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<Cryocoat>());
                }
            }
            if (npc.type == mod.NPCType("CultistAssassin"))
            {
                if (Utils.NextFloat(Main.rand) < 0.15f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<CultistRobe>());
                }
                if (Utils.NextFloat(Main.rand) < 0.15f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<CultistHood>());
                }
                if (Utils.NextFloat(Main.rand) < 0.15f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<CultistLegs>());
                }
            }
            if (npc.type == mod.NPCType("HeatSpirit"))
            {
                if (Main.rand.NextFloat() < 0.05f)

                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<ChaosEssence>());
                }

                else if (((bool)mod.Call("DifficultyActive", "defiled")) && Main.rand.NextFloat() < 0.1f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<ChaosEssence>());
                }
            }
            if (npc.type == mod.NPCType("OverloadedSoldier"))
            {
                if (Utils.NextFloat(Main.rand) < 0.15f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<UnloadedHelm>());
                }
            }
            if (npc.type == mod.NPCType("PhantomDebris"))
            {
                if (Main.rand.NextFloat() < 0.05f)

                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<HauntedPebble>());
                }

                else if (((bool)mod.Call("DifficultyActive", "defiled")) && Main.rand.NextFloat() < 0.1f && Main.expertMode)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<HauntedPebble>());
                }
            }
            if (npc.type == mod.NPCType("DevilFishAlt"))
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<DevilfishMask1>());
                }
            }
            if (npc.type == mod.NPCType("DevilFish"))
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<DevilfishMask2>());
                }
            }
            if (npc.type == mod.NPCType("MirageJelly"))
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<Mirballoon>());
                }
            }
            if (npc.type == mod.NPCType("Hadarian"))
            {
                if (((bool)mod.Call("GetBossDowned", "astrumaureus")) && Main.expertMode)

                {
                    if (Main.rand.NextFloat() < 0.05f)
                    {
                        Item.NewItem(npc.getRect(),
                            ModContent.ItemType<HadarianTail>());
                    }
                }
            }
            if (npc.type == mod.NPCType("Eidolist"))
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<EidoMask>());
                }
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<Eidcape>());
                }
            }
            //Profaned enemies
            if (npc.type == mod.NPCType("ProfanedEnergyBody") && Main.expertMode
            )
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<ProfanedEnergyHook>());
                }
                if (((bool)mod.Call("DifficultyActive", "revengeance")) && Utils.NextFloat(Main.rand) < 0.01f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<ChewyToy>());
                }
            }
            if (npc.type == mod.NPCType("ScornEater"))
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<ScornEaterMask>());
                }
                if (((bool)mod.Call("DifficultyActive", "revengeance")) && Utils.NextFloat(Main.rand) < 0.01f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<ChewyToy>());
                }
            }
            if (npc.type == mod.NPCType("ImpiousImmolator"))
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<HolyTorch>());
                }
                if (((bool)mod.Call("DifficultyActive", "revengeance")) && Utils.NextFloat(Main.rand) < 0.01f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<ChewyToy>());
                }
            }
            //Phantoms
            if (npc.type == mod.NPCType("PhantomSpirit"))
            {
                if (Utils.NextFloat(Main.rand) < 0.01f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<PhantomJar>());
                }
            }
            if (npc.type == mod.NPCType("PhantomSpiritS"))
            {
                if (Utils.NextFloat(Main.rand) < 0.02f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<PhantomJar>());
                }
            }
            if (npc.type == mod.NPCType("PhantomSpiritM"))
            {
                if (Utils.NextFloat(Main.rand) < 0.05f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<PhantomJar>());
                }
            }
            if (npc.type == mod.NPCType("PhantomSpiritL"))
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<PhantomJar>());
                }
            }
            //Post-ml misc
            //if (npc.type == mod.NPCType("ShockstormShuttle"))
            //{
            //if (Main.rand.NextFloat() < 0.075f && NPC.downedMoonlord)

            // {
            //Item.NewItem(npc.getRect(), 
            //     ModContent.ItemType<ExodiumMoon>());
            //}

            //else if (((bool) mod.Call("DifficultyActive", "defiled")) && Main.rand.NextFloat() < 0.2f && NPC.downedMoonlord)
            //{
            // Item.NewItem(npc.getRect(),
            //  ModContent.ItemType<ExodiumMoon>());
            //}
            //  }
            if (npc.type == mod.NPCType("ChaoticPuffer"))
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<ChaosBalloon>());
                }
            }
            //Minibosses
            if (npc.type == mod.NPCType("NuclearTerror"))
            {
                if (Utils.NextFloat(Main.rand) < 1.0f)
                {
                    Item.NewItem(npc.getRect(), ModContent.ItemType<NuclearFumes>());
                    Item.NewItem(npc.getRect(), ModContent.ItemType<NuclearFumes>());
                    Item.NewItem(npc.getRect(), ModContent.ItemType<NuclearFumes>());
                    Item.NewItem(npc.getRect(), ModContent.ItemType<NuclearFumes>());
                }
                if (Utils.NextFloat(Main.rand) < 0.5f)
                {
                    Item.NewItem(npc.getRect(), ModContent.ItemType<NuclearFumes>());
                }
                if (Utils.NextFloat(Main.rand) < 0.3f)
                {
                    Item.NewItem(npc.getRect(), ModContent.ItemType<NuclearFumes>());
                }
            }
            if (npc.type == mod.NPCType("Cnidrion"))
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<DryShrimp>());
                }
            }
            if (npc.type == mod.NPCType("Reaper"))
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<ReaperSharkArms>());
                }
            }
            if (npc.type == mod.NPCType("ColossalSquid"))
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<SquidHat>());
                }
            }
            if (npc.type == mod.NPCType("EidolonWyrmHead") && Main.expertMode)
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<EWail>());
                }
            }
            if (npc.type == mod.NPCType("EidolonWyrmHeadHuge"))
            {
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<SoulShard>());
                }
            }
            if (npc.type == mod.NPCType("GreatSandShark") && Main.expertMode)
            {
                if (Utils.NextFloat(Main.rand) < 0.2f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<CrushedCore>());
                }
            }
            if (npc.type == mod.NPCType("Horse"))
            {
                if (Utils.NextFloat(Main.rand) < 0.2f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<EarthShield>());
                }
            }
            if (npc.type == mod.NPCType("GiantClam") && Main.expertMode)
            {
                if (Utils.NextFloat(Main.rand) < 0.3f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<ClamHermitMedallion>());
                }
                if (Utils.NextFloat(Main.rand) < 0.3f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<ClamMask>());
                }
            }
            if (npc.type == 541)
            {
                if (Utils.NextFloat(Main.rand) < 0.1f && Main.expertMode)
                {
                    Item.NewItem(npc.getRect(),
                            ModContent.ItemType<SandBottle>());
                }
                if (Utils.NextFloat(Main.rand) < 0.05f && Main.expertMode)
                {
                    Item.NewItem(npc.getRect(),
                            ModContent.ItemType<SandPlush>());
                }
                else if (((bool)mod.Call("DifficultyActive", "defiled")) && Main.rand.NextFloat() < 0.1f && Main.expertMode)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<SandPlush>());
                }
            }
            if (npc.type == mod.NPCType("PlaguebringerShade") && Main.expertMode)
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<BeeCan>());
                }
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<PlaugeWings>());
                }
                if (Utils.NextFloat(Main.rand) < 0.0012f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AncientAuricTeslaHelm>());
                }
            }
            if (npc.type == mod.NPCType("ArmoredDiggerHead") && Main.expertMode)
            {
                if (Utils.NextFloat(Main.rand) < 0.0012f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AncientAuricTeslaHelm>());
                }
            }
            if (npc.type == mod.NPCType("CragmawMire"))
            {
                if (((bool)mod.Call("GetBossDowned", "polterghast")) && Main.expertMode)

                {
                    if (Main.rand.NextFloat() < 0.1f)
                    {
                        Item.NewItem(npc.getRect(),
                            ModContent.ItemType<MawHook>());
                    }
                }

                else if (!((bool)mod.Call("GetBossDowned", "polterghast")) && Main.rand.NextFloat() < 0.5f && Main.expertMode)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<MawHook>());
                }
            }
            //if (npc.type == mod.NPCType("NuclearTerror"))
            //{
            //if (Main.rand.NextFloat() < 0.1f && Main.expertMode)
            //{
            //Item.NewItem(npc.getRect(),
            //ModContent.ItemType<RadJuice>());
            //}
            //}
            if (npc.type == mod.NPCType("ThiccWaifu"))
            {
                if (((bool)mod.Call("GetBossDowned", "supremecalamitas")) && Main.rand.NextFloat() < 0.0001f && Main.expertMode)

                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<FogG>());
                }
                if (Main.rand.NextFloat() < 0.1f && Main.expertMode)

                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<cloudcandy>());
                }
            }
            if (npc.type == mod.NPCType("Mauler"))
            {
                if (Main.rand.NextFloat() < 0.2f)

                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<MaulerMask>());
                }
            }
            //Bosses
            if (npc.type == mod.NPCType("Polterghast"))
            {
                if (((bool)mod.Call("DifficultyActive", "revengeance")) && Main.rand.NextFloat() < 0.1f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<ToyScythe>());
                }
                else if (((bool)mod.Call("DifficultyActive", "defiled")) && Main.rand.NextFloat() < 1.0f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<ToyScythe>());
                }
            }
            if (npc.type == mod.NPCType("StormWeaverHeadNaked") && Main.expertMode)
            {
                if (Utils.NextFloat(Main.rand) < 0.007f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AncientAuricTeslaHelm>());
                }
                if (Utils.NextFloat(Main.rand) < 0.15f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<ShellScrap>());
                }
                else if (Utils.NextFloat(Main.rand) < 0.15f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<WeaverFlesh>());
                }
            }
           if (npc.type == mod.NPCType("Bumblefuck"))
			{
				if (((bool) mod.Call("DifficultyActive", "revengeance")) && Main.rand.NextFloat() < 0.1f)
            
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<FluffyFeather>());
                }

				else if (((bool) mod.Call("DifficultyActive", "defiled")) && Main.rand.NextFloat() < 1.0f)
				{
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<FluffyFeather>());
                }
                if (((bool) mod.Call("DifficultyActive", "armageddon")) && Main.rand.NextFloat() < 0.1f)
            
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<SparrowMeat>());
                }
				if (((bool) mod.Call("DifficultyActive", "death")) && Main.rand.NextFloat() < 0.001f)
            
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<FluffyFur>());
                }
			}
            if (npc.type == mod.NPCType("AstrumAureus"))
            {
                if (((bool)mod.Call("DifficultyActive", "revengeance")) && Main.rand.NextFloat() < 0.1f)

                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<JellyBottle>());
                }

                else if (((bool)mod.Call("DifficultyActive", "defiled")) && Main.rand.NextFloat() < 1.0f)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<JellyBottle>());
                }
            }
            if (npc.type == mod.NPCType("RavagerBody") && Main.expertMode)
            {
                if (((bool)mod.Call("DifficultyActive", "revengeance")) && Main.rand.NextFloat() < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<ScavaHook>());
                }
            }
            if (npc.type == mod.NPCType("Signus"))
            {
                if (Utils.NextFloat(Main.rand) < 0.3f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<SigCloth>());
                }
                if (Utils.NextFloat(Main.rand) < 0.2f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<SigCape>());
                }
                if (Utils.NextFloat(Main.rand) < 0.2f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<SignusNether>());
                }
                if (Utils.NextFloat(Main.rand) < 0.3f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<SignusEmblem>());
                }
                if (((bool)mod.Call("DifficultyActive", "revengeance")) && Main.rand.NextFloat() < 0.2f && Main.expertMode)
                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<JunkoHat>());
                }
                if (Utils.NextFloat(Main.rand) < 0.007f && Main.expertMode)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AncientAuricTeslaHelm>());
                }
            }
            if (npc.type == mod.NPCType("CeaselessVoid"))
            {
                if (Utils.NextFloat(Main.rand) < 0.3f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<VoidShard>());
                }
                if (Utils.NextFloat(Main.rand) < 0.3f && Main.expertMode)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<VoidWings>());
                }
                if (Utils.NextFloat(Main.rand) < 0.007f && Main.expertMode)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<AncientAuricTeslaHelm>());
                }
            }
            if (npc.type == mod.NPCType("SupremeCalamitas"))
            {
                if (Main.rand.NextFloat() < 0.2f)

                {
                    Item.NewItem(npc.getRect(),
                        ModContent.ItemType<AncientAuricTeslaHelm>());
                }
            }
            //Profaned bike
            if (npc.type == mod.NPCType("ProfanedGuardianBoss3") && Main.expertMode)
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<ProfanedBattery>());
                }
            }
            if (npc.type == mod.NPCType("ProfanedGuardianBoss2") && Main.expertMode)
            {
                if (Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<ProfanedWheels>());
                }
            }
            if (npc.type == mod.NPCType("ProfanedGuardianBoss") && Main.expertMode)
            {
                if (Utils.NextFloat(Main.rand) < 0.2f)
                {
                    Item
                        .NewItem(npc.getRect(),
                        ModContent.ItemType<ProfanedFrame>());
                }
            }
        }
    }
}
