using CalamityMod.World;
using CalValEX.Items;
using CalValEX.Items.Critters;
using CalValEX.Items.Equips.Balloons;
using CalValEX.Items.Equips.Capes;
using CalValEX.Items.Equips.Hats;
using CalValEX.Items.Equips.Legs;
using CalValEX.Items.Equips.Scarves;
using CalValEX.Items.Equips.Shields;
using CalValEX.Items.Equips.Shirts;
using CalValEX.Items.Equips.Wings;
using CalValEX.Items.Hooks;
using CalValEX.Items.LightPets;
using CalValEX.Items.Mounts;
using CalValEX.Items.Mounts.Morshu;
using CalValEX.Items.Pets;
using CalValEX.Items.Tiles;
using CalValEX.Items.Tiles.Astral;
using CalValEX.Items.Tiles.Balloons;
using CalValEX.Items.Tiles.Blocks;
using CalValEX.Items.Tiles.FurnitureSets.Necrotic;
using CalValEX.Items.Tiles.FurnitureSets.Phantowax;
using CalValEX.Items.Tiles.Monoliths;
using CalValEX.Items.Tiles.Paintings;
using CalValEX.Items.Tiles.Plants;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CalValEX
{
    public class Drops : GlobalNPC
    {
        public readonly float bossHookChance = 0.1f; //10%
        public readonly float bossPetChance = 0.2f; //20%
        public readonly float minibossChance = 0.1f; //10%
        public readonly float normalEnemyChance = 0.05f; //5%
        public readonly float rareEnemyChance = 0.1f; //10%
        public readonly float RIVChance = 0.075f; //7.5%
        public readonly float vanityMaxChance = 0.15f; //15%

        public readonly float vanityMinChance = 0.05f; //5%
        public readonly float vanityNormalChance = 0.1f; //10%
        private bool bdogeMount;

        private bool geldonSummon;
        private bool junkoReference;

        public override bool InstancePerEntity => true;

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            Mod clamMod =
                ModLoader.GetMod(
                    "CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
            if (clamMod != null)
            {
                if (type == clamMod.NPCType("SEAHOE"))
                {
                    if ((bool)clamMod.Call("GetInZone", Main.player[Main.myPlayer], "sunkensea"))
                    {
                        if (Main.hardMode)
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<VVanities>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 3);
                            ++nextSlot;
                        }

                        if ((bool)clamMod.Call("GetBossDowned", "oldduke"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<BloodwormScarf>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 50);
                            ++nextSlot;
                        }

                        if ((bool)clamMod.Call("GetBossDowned", "buffedeclipse"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<CalamityFriends>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1);
                            ++nextSlot;
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<WilliamPainting>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1);
                            ++nextSlot;
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<CalamiteaTime>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1);
                            ++nextSlot;
                        }

                        if ((bool)clamMod.Call("GetBossDowned", "supremecalamitas"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Yharlamitas>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(42);
                            ++nextSlot;
                        }
                    }

                    if (!(bool)clamMod.Call("GetInZone", Main.player[Main.myPlayer], "sunkensea"))
                    {
                        if (Main.hardMode)
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<VVanities>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5);
                            ++nextSlot;
                        }

                        if ((bool)clamMod.Call("GetBossDowned", "oldduke"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<BloodwormScarf>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(15);
                            ++nextSlot;
                        }

                        if ((bool)clamMod.Call("GetBossDowned", "buffedeclipse"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<CalamityFriends>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(10);
                            ++nextSlot;
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<WilliamPainting>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(10);
                            ++nextSlot;
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<CalamiteaTime>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(10);
                            ++nextSlot;
                        }

                        if ((bool)clamMod.Call("GetBossDowned", "supremecalamitas"))
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Yharlamitas>());
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(420);
                            ++nextSlot;
                        }
                    }
                }

                if (type == clamMod.NPCType("DILF"))
                {
                    if ((bool)clamMod.Call("GetBossDowned", "cryogen"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<FrostflakeBrick>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 10);
                        ++nextSlot;
                    }
                    if ((bool)clamMod.Call("GetBossDowned", "signus"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Signut>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(15);
                        ++nextSlot;
                    }
                }

                if (type == clamMod.NPCType("THIEF"))
                {
                    if ((bool)clamMod.Call("GetBossDowned", "astrumaureus"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<AureicFedora>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 20);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstrachnidTentacles>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstrachnidThorax>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5);
                        ++nextSlot;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstrachnidCranium>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5);
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
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 3);
                        ++nextSlot;
                    }

                    if (archmage != -1)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Permascarf>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 3);
                        ++nextSlot;
                    }

                    if (Main.LocalPlayer.ZoneDungeon)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<PolterMask>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 3);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Polterskirt>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 3);
                        ++nextSlot;

                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<PolterStockings>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 3);
                        ++nextSlot;
                    }
                }

                if (type == NPCID.Dryad && Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<AstralGrass>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 0, 50);
                    ++nextSlot;
                }

                if (type == NPCID.Truffle)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<SwearshroomItem>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 2);
                    ++nextSlot;
                }

                if (type == NPCID.Steampunker)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<XenoSolution>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 5);
                    ++nextSlot;
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<StarstruckSynthesizer>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5);
                    ++nextSlot;
                }

                if (type == NPCID.PartyGirl)
                {
                    if (Main.LocalPlayer.HasItem(ModContent.ItemType<Mirballoon>()) ||
                        Main.LocalPlayer.HasItem(ModContent.ItemType<BoB2>()))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<TiedMirageBalloon>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 5);
                        ++nextSlot;
                    }

                    if (Main.LocalPlayer.HasItem(ModContent.ItemType<BoxBalloon>()) ||
                        Main.LocalPlayer.HasItem(ModContent.ItemType<BoB2>()))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<TiedBoxBalloon>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 5);
                        ++nextSlot;
                    }

                    if (Main.LocalPlayer.HasItem(ModContent.ItemType<ChaosBalloon>()) ||
                        Main.LocalPlayer.HasItem(ModContent.ItemType<BoB2>()))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<TiedChaosBalloon>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 5);
                        ++nextSlot;
                    }

                    if (Main.LocalPlayer.HasItem(ModContent.ItemType<BoB2>()))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<TiedBoB2>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 5);
                        ++nextSlot;
                    }

                    if ((bool)clamMod.Call("GetBossDowned", "calamitas"))
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<CalamitasFumo>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 0, 20);
                        ++nextSlot;
                    }
                }
            }
        }

        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback,
            ref bool crit, ref int hitDirection)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (npc.type == calamityMod.NPCType("AstrumAureus"))
            {
                if (projectile.type != calamityMod.ProjectileType("AstrageldonSummon"))
                {
                    geldonSummon = false;
                }
                else if (projectile.type == calamityMod.ProjectileType("AstrageldonSummon"))
                {
                    geldonSummon = true;
                }
            }
            else if (npc.type == calamityMod.NPCType("Bumblefuck"))
            {
                if (projectile.type == calamityMod.ProjectileType("Minibirb") && !projectile.ranged)
                {
                    bdogeMount = true;
                }
                else
                {
                    bdogeMount = false;
                }
            }
            else if (npc.type == calamityMod.NPCType("Signus"))
            {
                if (projectile.type == calamityMod.ProjectileType("PristineFire") ||
                    projectile.type == calamityMod.ProjectileType("PristineSecondary"))
                {
                    junkoReference = true;
                }
                else
                {
                    junkoReference = false;
                }
            }
        }

        public override void NPCLoot(NPC npc)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            int droppedMoney = 0;
            for (int i = 0; i < Main.maxPlayers; i++)
            {
                Player player = Main.player[i];
                if (player.active && !player.dead)
                {
                    if (player.HasBuff(ModContent.BuffType<MorshuBuff>()))
                    {
                        float value = npc.value;
                        value /= 5;
                        if (value < 0)
                        {
                            value = 1;
                        }

                        if (droppedMoney == 0)
                        {
                            while (value > 0)
                            {
                                if (value > 1000000f)
                                {
                                    int platCoins = (int)(value / 1000000f);
                                    if (platCoins > 50 && Main.rand.Next(5) == 0)
                                    {
                                        platCoins /= Main.rand.Next(3) + 1;
                                    }

                                    if (Main.rand.Next(5) == 0)
                                    {
                                        platCoins /= Main.rand.Next(3) + 1;
                                    }

                                    value -= 1000000f * platCoins;
                                    Item.NewItem(npc.Hitbox, ItemID.PlatinumCoin, platCoins);
                                    continue;
                                }

                                if (value > 10000f)
                                {
                                    int goldCoins = (int)(value / 10000f);
                                    if (goldCoins > 50 && Main.rand.Next(5) == 0)
                                    {
                                        goldCoins /= Main.rand.Next(3) + 1;
                                    }

                                    if (Main.rand.Next(5) == 0)
                                    {
                                        goldCoins /= Main.rand.Next(3) + 1;
                                    }

                                    value -= 10000f * goldCoins;
                                    Item.NewItem(npc.Hitbox, ItemID.GoldCoin, goldCoins);
                                    continue;
                                }

                                if (value > 100f)
                                {
                                    int silverCoins = (int)(value / 100f);
                                    if (silverCoins > 50 && Main.rand.Next(5) == 0)
                                    {
                                        silverCoins /= Main.rand.Next(3) + 1;
                                    }

                                    if (Main.rand.Next(5) == 0)
                                    {
                                        silverCoins /= Main.rand.Next(3) + 1;
                                    }

                                    value -= 100f * silverCoins;
                                    Item.NewItem(npc.Hitbox, ItemID.SilverCoin, silverCoins);
                                    continue;
                                }

                                int copperCoins = (int)value;
                                if (copperCoins > 50 && Main.rand.Next(5) == 0)
                                {
                                    copperCoins /= Main.rand.Next(3) + 1;
                                }

                                if (Main.rand.Next(5) == 0)
                                {
                                    copperCoins /= Main.rand.Next(4) + 1;
                                }

                                if (copperCoins < 1)
                                {
                                    copperCoins = 1;
                                }

                                value -= copperCoins;
                                Item.NewItem(npc.Hitbox, ItemID.CopperCoin, copperCoins);
                            }

                            droppedMoney++;
                        }
                    }
                }
            }

            //5%
            float normalChance = normalEnemyChance;
            //10%
            float rareChance = rareEnemyChance;
            //1%
            float mountChance = 0.01f;
            if (!CalValEXConfig.Instance.DisableVanityDrops)
            {
                if (npc.type == calamityMod.NPCType("DILF"))
                {
                    DropItem(npc, ModContent.ItemType<Permascarf>()); //garanteed
                }

                if (npc.type == calamityMod.NPCType("THIEF"))
                {
                    DropItem(npc, ModContent.ItemType<BanditHat>()); //garanteed
                }

                // Swearshrooms
                if (npc.type == calamityMod.NPCType("CrabShroom"))
                {
                    if (!NPC.AnyNPCs(calamityMod.NPCType("CrabulonIdle")))
                    {
                        if (Main.LocalPlayer.HasItem(calamityMod.ItemType("KnowledgeCrabulon")))
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Swearshroom>());
                        }
                    }
                }

                //Prehm
                if (npc.type == calamityMod.NPCType("AngryDog"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<TundraBall>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("Pitbull"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<OldTennisBall>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("BoxJellyfish"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<BoxBalloon>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("Catfish"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<DiscardedCollar>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("Scryllar"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ScryllianWings>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("ScryllarRage"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ScryllianWings>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("DespairStone"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<Drock>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("WulfrumRover"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<WulfrumKeys>(), Main.expertMode, mountChance);
                    ChanceDropItem(npc, ModContent.ItemType<WulfrumController>(), 0.04f);
                }

                if (npc.type == calamityMod.NPCType("WulfrumDrone"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<WulfrumController>(), 0.04f);
                }

                if (npc.type == calamityMod.NPCType("WulfrumHovercraft"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<WulfrumController>(), 0.04f);
                }

                if (npc.type == calamityMod.NPCType("WulfrumGyrator"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<WulfrumController>(), 0.04f);
                }

                if (npc.type == calamityMod.NPCType("WulfrumSlime")) //Lol
                {
                    ChanceDropItem(npc, ModContent.ItemType<WulfrumController>(), 0.04f);
                }

                if (npc.type == calamityMod.NPCType("WulfrumPylon"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<PylonRemote>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CosmicElemental"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<CosmicCone>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("Sunskater"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<SkeetCrest>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("ShockstormShuttle"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ShuttleBalloon>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("AeroSlime"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AeroWings>(), Main.expertMode, normalChance);
                }

                if (npc.type == calamityMod.NPCType("SeaFloaty"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<FloatyCarpetItem>(), Main.expertMode,
                        normalChance);
                }

                if (npc.type == calamityMod.NPCType("SuperDummyNPC"))
                {
                    ConditionalDropItem(npc, ModContent.ItemType<DummyMask>(),
                        Main.LocalPlayer.HeldItem.type != calamityMod.ItemType("SuperDummy"));
                }

                //Crawlers
                if (npc.type == calamityMod.NPCType("CrawlerAmethyst"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<AmethystStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerTopaz"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<TopazStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerSapphire"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<SapphireStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerEmerald"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<EmeraldStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerRuby"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<RubyStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerDiamond"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<DiamondStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerCrystal"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<CrystalStone>(), rareChance);
                }

                if (npc.type == calamityMod.NPCType("CrawlerAmber"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<AmberStone>(), rareChance);
                }

                //end of crawler drops and prehm
                //Acid rain set tier 2
                if (npc.type == calamityMod.NPCType("SulfurousSkater"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<SkaterEgg>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("Orthocera"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<Help>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("FlakCrab"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<FlakHeadCrab>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("Trilobite"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<TrilobiteShield>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("GammaSlime"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<GammaHelmet>(), vanityMinChance);
                    ChanceDropItem(npc, ModContent.ItemType<NuclearFumes>(), 0.3f); //30%
                }

                //Hardmode drops
                if (npc.type == calamityMod.NPCType("PerennialSlime"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<PerennialFlower>(), vanityNormalChance);
                    ChanceDropItem(npc, ModContent.ItemType<PerennialDress>(), vanityNormalChance);
                    ChanceDropItem(npc, ModContent.ItemType<PerennialFlower>(), RIVChance);
                }

                if (npc.type == calamityMod.NPCType("Bohldohr"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<BoldEgg>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("BelchingCoral"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<CoralMask>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("IceClasper"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<AntarcticEssence>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("Cryon"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<Cryocap>(), vanityNormalChance);
                    ChanceDropItem(npc, ModContent.ItemType<Cryocoat>(), vanityNormalChance);
                }

                if (npc.type == calamityMod.NPCType("SmallSightseer"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<Binoculars>(),
                        (bool)calamityMod.Call("GetBossDowned", "astrumaureus"), 0.05f); //5%
                }

                if (npc.type == calamityMod.NPCType("BigSightseer"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<Binoculars>(),
                        (bool)calamityMod.Call("GetBossDowned", "astrumaureus"), 0.1f); //10%
                }

                if (npc.type == calamityMod.NPCType("CultistAssassin"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<CultistRobe>(), normalChance);
                    ChanceDropItem(npc, ModContent.ItemType<CultistHood>(), normalChance);
                    ChanceDropItem(npc, ModContent.ItemType<CultistLegs>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("HeatSpirit"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ChaosEssence>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("OverloadedSoldier"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<UnloadedHelm>(), vanityMaxChance);
                    ChanceDropItem(npc, ModContent.ItemType<HauntedPebble>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("PhantomDebris"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<HauntedPebble>(), normalChance);
                }

                if (npc.type == calamityMod.NPCType("DevilFishAlt"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<DevilfishMask1>(), vanityNormalChance);
                }

                if (npc.type == calamityMod.NPCType("DevilFish"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<DevilfishMask2>(), vanityNormalChance);
                }

                if (npc.type == calamityMod.NPCType("MirageJelly"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<Mirballoon>(), vanityNormalChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<OldMirage>(), NPC.downedGolemBoss, 0.01f); //1%
                }

                if (npc.type == calamityMod.NPCType("Hadarian"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<HadarianTail>(),
                        (bool)calamityMod.Call("GetBossDowned", "astrumaureus"), 0.05f); //5%
                }

                if (npc.type == calamityMod.NPCType("Eidolist"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<EidoMask>(), vanityNormalChance);
                    ChanceDropItem(npc, ModContent.ItemType<Eidcape>(), vanityNormalChance);
                }

                //Profaned enemies
                if (npc.type == calamityMod.NPCType("ProfanedEnergyBody") && Main.expertMode)
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ProfanedEnergyHook>(), Main.expertMode,
                        bossHookChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ProfanedBalloon>(), Main.expertMode,
                        normalChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ChewyToy>(),
                        (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.01f); //1%
                }

                if (npc.type == calamityMod.NPCType("ScornEater"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ScornEaterMask>(), normalChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ChewyToy>(),
                        (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.01f); //1%
                }

                if (npc.type == calamityMod.NPCType("ImpiousImmolator"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<HolyTorch>(), 0.05f); //10%
                    ChanceDropItem(npc, ModContent.ItemType<ProfanedBalloon>(), normalChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ChewyToy>(),
                        (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.01f); //1%
                }

                //Post-ml misc
                /*if (npc.type == mod.NPCType("ShockstormShuttle"))
                {
                if (Main.rand.NextFloat() < 0.075f && NPC.downedMoonlord)

                 {
                Item.NewItem(npc.getRect(),
                     ModContent.ItemType<ExodiumMoon>());
                }
                 }*/
                if (npc.type == calamityMod.NPCType("ChaoticPuffer"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ChaosBalloon>(), vanityNormalChance);
                }

                //Minibosses
                if (npc.type == calamityMod.NPCType("NuclearTerror"))
                {
                    DropItem(npc, ModContent.ItemType<NuclearFumes>(), 3, 5); //garanteed 3 to 5
                    ConditionalDropItem(npc, ModContent.ItemType<NuclearFumes>(), Main.expertMode, 1,
                        3); //when expert mode you get 1 to 3
                    ChanceDropItem(npc, ModContent.ItemType<NuclearFumes>(), 0.5f); //50% chance to get 1 extra
                    ChanceDropItem(npc, ModContent.ItemType<NuclearFumes>(), 0.3f); //30% chance to get 1 extra
                }

                if (npc.type == calamityMod.NPCType("Cnidrion"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<DryShrimp>(), minibossChance);
                }

                if (npc.type == calamityMod.NPCType("Bumblefolly"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<OrbSummon>(), minibossChance);
                }

                if (npc.type == calamityMod.NPCType("Reaper"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<ReaperSharkArms>(), minibossChance);
                    ChanceDropItem(npc, ModContent.ItemType<OmegaBlue>(), 0.05f);
                }

                if (npc.type == calamityMod.NPCType("ColossalSquid"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<SquidHat>(), minibossChance);
                    ChanceDropItem(npc, ModContent.ItemType<OmegaBlue>(), 0.05f);
                }

                if (npc.type == calamityMod.NPCType("EidolonWyrmHead"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<EWail>(), minibossChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<SoulShard>(),
                        !(bool)calamityMod.Call("GetBossDowned", "cryogen") && !NPC.downedGolemBoss &&
                        !NPC.downedPlantBoss && !NPC.downedAncientCultist, 1.0f);
                    ChanceDropItem(npc, ModContent.ItemType<OmegaBlue>(), 0.05f);
                }

                if (npc.type == calamityMod.NPCType("EidolonWyrmHeadHuge"))
                {
                    DropItem(npc, ModContent.ItemType<SoulShard>());
                    DropItem(npc, ModContent.ItemType<OmegaBlue>());
                }

                if (npc.type == calamityMod.NPCType("Horse"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<EarthShield>(), minibossChance);
                }

                if (npc.type == calamityMod.NPCType("GiantClam") && Main.expertMode)
                {
                    ChanceDropItem(npc, ModContent.ItemType<ClamHermitMedallion>(), minibossChance);
                    ChanceDropItem(npc, ModContent.ItemType<ClamMask>(), vanityMaxChance);
                }

                if (npc.type == NPCID.SandElemental)
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<SandBottle>(), Main.expertMode, normalChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<SandPlush>(), Main.expertMode, normalChance);
                }

                if (npc.type == calamityMod.NPCType("PlaguebringerShade"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<BeeCan>(), 0.1f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<PlaugeWings>(), Main.expertMode, 0.1f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AncientAuricTeslaHelm>(), Main.expertMode,
                        0.0012f);
                }

                if (npc.type == calamityMod.NPCType("ArmoredDiggerHead"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AncientAuricTeslaHelm>(), Main.expertMode,
                        0.0012f);
                }

                if (npc.type == calamityMod.NPCType("CragmawMire"))
                {
                    if (Main.expertMode)
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<MawHook>(),
                            (bool)calamityMod.Call("GetBossDowned", "polterghast"), 0.1f); //10%
                        ConditionalChanceDropItem(npc, ModContent.ItemType<MawHook>(),
                            !(bool)calamityMod.Call("GetBossDowned", "polterghast"),
                            0.5f); //50% ?? why more?? :Polterc
                    }
                    ConditionalChanceDropItem(npc, ModContent.ItemType<NuclearFumes>(),
                            (bool)calamityMod.Call("GetBossDowned", "polterghast"), 0.3f, 1, 3);
                }

                //if (npc.type == mod.NPCType("NuclearTerror"))
                //{
                //if (Main.rand.NextFloat() < 0.1f && Main.expertMode)
                //{
                //Item.NewItem(npc.getRect(),
                //ModContent.ItemType<RadJuice>());
                //}
                //}
                if (npc.type == calamityMod.NPCType("ThiccWaifu"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<cloudcandy>(), 0.1f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<FogG>(), (bool)calamityMod.Call("GetBossDowned", "supremecalamitas"), 0.0001f);
                }

                if (npc.type == calamityMod.NPCType("Mauler"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<MaulerMask>(), vanityNormalChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<OmegaBlue>(), Main.expertMode, 0.05f);
                }

                //Bosses
                if (npc.type == calamityMod.NPCType("DesertScourgeHead"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<SandTooth>(), Main.expertMode, RIVChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<DesertMedallion>(), !Main.expertMode, 0.2f);
                }

                if (npc.type == calamityMod.NPCType("SlimeGodCore"))
                {
                    if (!CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("StatigelBlock"),
                            !Main.expertMode, 155, 265);
                    }

                    ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(),
                        (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.01f);
                }

                if (npc.type == calamityMod.NPCType("BrimstoneElemental") && !CalValEXConfig.Instance.ConfigBossBlocks)
                {
                    ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("BrimstoneSlag"),
                        !Main.expertMode, 155, 265);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<BrimmySpirit>(), !Main.expertMode, 0.15f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<BrimmyBody>(), !Main.expertMode, 0.15f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<FoilSpoon>(), !Main.expertMode, 0.035f);
                }

                if (npc.type == calamityMod.NPCType("Leviathan") && !NPC.AnyNPCs(calamityMod.NPCType("Siren")) &&
                    !Main.expertMode)
                {
                    ChanceDropItem(npc, ModContent.ItemType<AquaticMonolith>(), 0.15f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<FoilAtlantis>(), !Main.expertMode, 0.2f);
                }

                if (npc.type == calamityMod.NPCType("Siren") && !NPC.AnyNPCs(calamityMod.NPCType("Leviathan")) &&
                    !Main.expertMode)
                {
                    ChanceDropItem(npc, ModContent.ItemType<AquaticMonolith>(), 0.15f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<FoilAtlantis>(), !Main.expertMode, 0.2f);
                }

                if (npc.type == calamityMod.NPCType("PlaguebringerGoliath") &&
                    !CalValEXConfig.Instance.ConfigBossBlocks)
                {
                    ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("PlaguedPlate"), !Main.expertMode,
                        155, 265);
                }

                if (npc.type == calamityMod.NPCType("AstrumDeusHeadSpectral") && !NPC.AnyNPCs(calamityMod.NPCType("AstrumDeusHeadSpectral")))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AstBandana>(), !Main.expertMode, 0.2f);
                    if (Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneAstral || Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().Blok)
                    {
                        DropItem(npc, ModContent.ItemType<AstrumDeusMask>());
                    }
                }

                if (npc.type == calamityMod.NPCType("Providence") && !CalValEXConfig.Instance.ConfigBossBlocks)
                {
                    ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("ProfanedRock"), !Main.expertMode,
                        155, 265);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ProviCrystal>(), !Main.expertMode, 0.2f);
                }

                if (npc.type == calamityMod.NPCType("Polterghast"))
                {
                    if (!CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        if (Main.rand.NextFloat() < 0.5f)
                        {
                            ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("StratusBricks"),
                                !Main.expertMode, 155, 265);
                        }
                        else
                        {
                            ConditionalDropItem(npc, ModContent.ItemType<PhantowaxBlock>(), !Main.expertMode, 155, 265);
                        }
                    }

                    ConditionalChanceDropItem(npc, ModContent.ItemType<ToyScythe>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);

                    if (Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().poltermask && Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().polterchest && Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().polterthigh)
                    {
                        DropItem(npc, ModContent.ItemType<ToyScythe>());
                    }
                }

                if (npc.type == calamityMod.NPCType("StormWeaverHeadNaked") &&
                    CalamityWorld.DoGSecondStageCountdown <= 0)
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AncientAuricTeslaHelm>(), Main.expertMode, 0.007f); //0.7%
                    ChanceDropItem(npc, ModContent.ItemType<StormBandana>(), vanityNormalChance);
                    ConditionalChanceDropItem(npc,
                        Main.rand.NextBool() ? ModContent.ItemType<ShellScrap>() : ModContent.ItemType<WeaverFlesh>(), Main.expertMode,
                        bossPetChance);
                    if (!Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("OccultStone"),
                            (bool)calamityMod.Call("GetBossDowned", "devourerofgods"), 155, 265);
                    }

                    if (Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("OccultStone"),
                            (bool)calamityMod.Call("GetBossDowned", "devourerofgods"), 205, 335);
                    }
                }

                if (npc.type == calamityMod.NPCType("Bumblefuck"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<Birbhat>(), !Main.expertMode, 0.2f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<FluffyFeather>(),
                        (bool)calamityMod.Call("DifficultyActive", "revengeance"), bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<SparrowMeat>(),
                        (bool)calamityMod.Call("DifficultyActive", "armageddon"), bossPetChance);
                    if (!Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("SilvaCrystal"),
                            (bool)calamityMod.Call("GetBossDowned", "yharon"), 155, 265);
                    }

                    if (bdogeMount)
                    {
                        ChanceDropItem(npc, ModContent.ItemType<FluffyFur>(), 1.0f);
                    }
                    else
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<FluffyFur>(),
                            (bool)calamityMod.Call("DifficultyActive", "death"), 0.001f);
                    }
                }

                if (npc.type == calamityMod.NPCType("AstrumAureus"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AureusShield>(), !Main.expertMode, 0.2f);
                    if (geldonSummon)
                    {
                        ChanceDropItem(npc, ModContent.ItemType<JellyBottle>(), 1.0f);
                    }
                    else
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<JellyBottle>(),
                            (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.1f);
                    }
                }

                if (npc.type == calamityMod.NPCType("RavagerBody"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<SkullBalloon>(), !Main.expertMode, 0.2f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<StonePile>(), !Main.expertMode, 0.2f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<ScavaHook>(), Main.expertMode, RIVChance);
                    ConditionalDropItem(npc, ModContent.ItemType<Necrostone>(), !Main.expertMode, 155, 265);
                }

                if (npc.type == calamityMod.NPCType("Signus") && CalamityWorld.DoGSecondStageCountdown <= 0)
                {
                    if (Main.expertMode)
                    {
                        ChanceDropItem(npc, ModContent.ItemType<SigCloth>(), bossPetChance);
                    }
                    ChanceDropItem(npc, ModContent.ItemType<SigCape>(), vanityNormalChance);
                    ChanceDropItem(npc, ModContent.ItemType<SignusNether>(), vanityNormalChance);
                    ChanceDropItem(npc, ModContent.ItemType<SignusEmblem>(), vanityNormalChance);
                    if (junkoReference)
                    {
                        ChanceDropItem(npc, ModContent.ItemType<JunkoHat>(), 1.0f);
                    }
                    else
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<JunkoHat>(),
                            (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.01f);
                    }

                    ConditionalChanceDropItem(npc, ModContent.ItemType<AncientAuricTeslaHelm>(), Main.expertMode,
                        0.007f); //0.7%
                    if (!Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("OccultStone"),
                            (bool)calamityMod.Call("GetBossDowned", "devourerofgods"), 155, 265);
                    }

                    if (Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("OccultStone"),
                            (bool)calamityMod.Call("GetBossDowned", "devourerofgods"), 205, 335);
                    }
                }

                if (npc.type == calamityMod.NPCType("CeaselessVoid") && CalamityWorld.DoGSecondStageCountdown <= 0)
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<VoidShard>(), Main.expertMode, bossPetChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<VoidWings>(), Main.expertMode,
                        vanityNormalChance);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<OldVoidWings>(), Main.expertMode, 0.05f); //5%
                    ConditionalChanceDropItem(npc, ModContent.ItemType<AncientAuricTeslaHelm>(), Main.expertMode,
                        0.007f); //0.7%
                    if (!Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("OccultStone"),
                            (bool)calamityMod.Call("GetBossDowned", "devourerofgods"), 155, 265);
                    }

                    if (Main.expertMode && !CalValEXConfig.Instance.ConfigBossBlocks)
                    {
                        ConditionalDropItem(npc, ModLoader.GetMod("CalamityMod").ItemType("OccultStone"),
                            (bool)calamityMod.Call("GetBossDowned", "devourerofgods"), 205, 335);
                    }
                }

                if (npc.type == calamityMod.NPCType("OldDuke") && Main.expertMode)
                {
                    ChanceDropItem(npc, ModContent.ItemType<CharredChopper>(), RIVChance);
                }

                if (npc.type == calamityMod.NPCType("DevourerofGodsHeadS") && Main.expertMode)
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<CosmicWormScarf>(), !Main.expertMode, 0.2f);
                    if ((bool)calamityMod.Call("DifficultyActive", "death"))
                    {
                        ChanceDropItem(npc, ModContent.ItemType<DogPetItem>(), 0.5f);
                    }
                    else if ((bool)calamityMod.Call("DifficultyActive", "revengeance") &&
                             !(bool)calamityMod.Call("DifficultyActive", "death"))
                    {
                        ChanceDropItem(npc, ModContent.ItemType<DogPetItem>(), 0.05f);
                    }
                    else
                    {
                        return;
                    }
                }

                if (npc.type == calamityMod.NPCType("Yharon"))
                {
                    ConditionalChanceDropItem(npc, ModContent.ItemType<YharonsAnklet>(), (bool)calamityMod.Call("DifficultyActive", "revengeance"), 0.1f);
                    ConditionalChanceDropItem(npc, ModContent.ItemType<YharonShackle>(), !Main.expertMode, 0.2f);
                    if (!Main.expertMode)
                    {
                        ConditionalDropItem(npc, ModContent.ItemType<Termipebbles>(),
                            (bool)calamityMod.Call("GetBossDowned", "buffedeclipse"), 2, 8);
                    }
                }

                if (npc.type == calamityMod.NPCType("SupremeCalamitas"))
                {
                    ChanceDropItem(npc, ModContent.ItemType<AncientAuricTeslaHelm>(), 0.2f); //20%
                }

                //Profaned bike
                if (npc.type == calamityMod.NPCType("ProfanedGuardianBoss3") && Main.expertMode)
                {
                    ChanceDropItem(npc, ModContent.ItemType<ProfanedBattery>(), 0.1f); //10%
                }

                if (npc.type == calamityMod.NPCType("ProfanedGuardianBoss2") && Main.expertMode)
                {
                    ChanceDropItem(npc, ModContent.ItemType<ProfanedWheels>(), 0.1f); //10%
                }

                if (npc.type == calamityMod.NPCType("ProfanedGuardianBoss") && Main.expertMode)
                {
                    ChanceDropItem(npc, ModContent.ItemType<ProfanedFrame>(), 0.1f); //10%
                }

                //Goozma slimes
                if ((bool)calamityMod.Call("DifficultyActive", "revengeance"))
                {
                    if (npc.type == calamityMod.NPCType("AeroSlime") || npc.type == calamityMod.NPCType("CryoSlime") ||
                        npc.type == calamityMod.NPCType("PerennialSlime") ||
                        npc.type == calamityMod.NPCType("WulfrumSlime") ||
                        npc.type == calamityMod.NPCType("PlaguedJungleSlime") ||
                        npc.type == calamityMod.NPCType("BloomSlime"))
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(), Main.expertMode, 0.001f);
                    }

                    if (npc.type == calamityMod.NPCType("IrradiatedSlime") ||
                        npc.type == calamityMod.NPCType("GammaSlime") ||
                        npc.type == calamityMod.NPCType("EbonianBlightSlime") ||
                        npc.type == calamityMod.NPCType("CrimulanBlightSlime") ||
                        npc.type == calamityMod.NPCType("AstralSlime"))
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(), Main.expertMode, 0.002f);
                    }

                    /*if ((npc.type == calamityMod.NPCType("AstrageldonSlime"))
                    {
                        ConditionalChanceDropItem(npc, ModContent.ItemType<GoozmaPetItem>(), Main.expertMode, 0.0375f);
                    }      lol   */
                }
            }

            //Yharexs' Dev Pet (Calamity BABY)
            if ((bool)calamityMod.Call("DifficultyActive", "death"))
            {
                if (npc.type == calamityMod.NPCType("AstralSlime") && Main.rand.Next(870000) == 0)
                {
                    DropItem(npc, ModContent.ItemType<YharexsLetter>());
                }

                if (npc.type == calamityMod.NPCType("SupremeCalamitas"))
                {
                    bool didIGetHit = false;
                    for (int i = 0; i < Main.maxPlayers; i++)
                    {
                        Player player = Main.player[i];
                        if (player.active && !player.dead)
                        {
                            if (player.GetModPlayer<CalValEXPlayer>().SCalHits > 0)
                            {
                                didIGetHit = true;
                            }
                        }
                    }

                    if (!didIGetHit)
                    {
                        DropItem(npc, ModContent.ItemType<YharexsLetter>());
                    }
                    else
                    {
                        if (Main.rand.Next(1000) == 0)
                        {
                            DropItem(npc, ModContent.ItemType<YharexsLetter>());
                        }
                    }
                }
            }
        }

        private static int DropItem(NPC npc, int itemID, bool dropPerPlayer, int min = 1, int max = 0)
        {
            int numberOfItems;
            if (max <= min)
            {
                numberOfItems = min;
            }
            else
            {
                numberOfItems = Main.rand.Next(min, max + 1);
            }

            if (numberOfItems <= 0)
            {
                return 0;
            }

            if (dropPerPlayer)
            {
                npc.DropItemInstanced(npc.position, npc.Size, itemID, numberOfItems);
            }
            else
            {
                Item.NewItem(npc.Hitbox, itemID, numberOfItems);
            }

            return numberOfItems;
        }

        private static int DropItem(NPC npc, int itemID, int min = 1, int max = 0) =>
            DropItem(npc, itemID, false, min, max);

        public static int ChanceDropItem(NPC npc, int itemID, float chance, bool dropPerPlayer, int min = 1,
            int max = 0)
        {
            if (Main.rand.NextFloat() < chance)
            {
                return DropItem(npc, itemID, dropPerPlayer, min, max);
            }

            return 0;
        }

        public static int ChanceDropItem(NPC npc, int itemID, float chance, int min = 1, int max = 0) =>
            ChanceDropItem(npc, itemID, chance, false, min, max);

        public static int ConditionalDropItem(NPC npc, int itemID, bool condition, bool dropPerPlayer, int min = 1,
            int max = 0)
        {
            if (condition)
            {
                return DropItem(npc, itemID, dropPerPlayer, min, max);
            }

            return 0;
        }

        public static int ConditionalDropItem(NPC npc, int itemID, bool condition, int min = 1, int max = 0) =>
            ConditionalDropItem(npc, itemID, condition, false, min, max);

        public static int ConditionalChanceDropItem(NPC npc, int itemID, bool condition, float chance,
            bool dropPerPlayer, int min = 1, int max = 0)
        {
            if (condition)
            {
                return ChanceDropItem(npc, itemID, chance, dropPerPlayer, min, max);
            }

            return 0;
        }

        public static int ConditionalChanceDropItem(NPC npc, int itemID, bool condition, float chance, int min = 1,
            int max = 0) =>
            ConditionalChanceDropItem(npc, itemID, condition, chance, false, min, max);
        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
        {
            if (Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneAstral || Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().Blok)
            {
                //DEUS HEAD
                if (npc.type == ModLoader.GetMod("CalamityMod").NPCType("AstrumDeusHeadSpectral"))
                {
                    Texture2D deusheadsprite = (ModContent.GetTexture("CalValEX/Items/Tiles/Astral/DeusHeadOld"));

                    float deusheadframe = 1f / (float)Main.npcFrameCount[npc.type];
                    int deusheadheight = (int)((float)(npc.frame.Y / npc.frame.Height) * deusheadframe) * (deusheadsprite.Height / 1);

                    Rectangle deusheadsquare = new Rectangle(0, deusheadheight, deusheadsprite.Width, deusheadsprite.Height / 1);
                    Color deusheadalpha = npc.GetAlpha(drawColor);
                    spriteBatch.Draw(deusheadsprite, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusheadsquare, deusheadalpha, npc.rotation, Utils.Size(deusheadsquare) / 2f, npc.scale, SpriteEffects.None, 0f);
                    return false;
                }

                //DEUS BODY
                else if (npc.type == ModLoader.GetMod("CalamityMod").NPCType("AstrumDeusBodySpectral"))
                {
                    Texture2D deusbodsprite = npc.localAI[3] == 1f ? ModContent.GetTexture("CalValEX/Items/Tiles/Astral/DeusBodyAltOld") : ModContent.GetTexture("CalValEX/Items/Tiles/Astral/DeusBodyOld");

                    float deusbodframe = 1f / (float)Main.npcFrameCount[npc.type];
                    int deusbodheight = (int)((float)(npc.frame.Y / npc.frame.Height) * deusbodframe) * (deusbodsprite.Height / 1);

                    Rectangle deusbodsquare = new Rectangle(0, deusbodheight, deusbodsprite.Width, deusbodsprite.Height / 1);
                    Color deusbodalpha = npc.GetAlpha(drawColor);
                    spriteBatch.Draw(deusbodsprite, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusbodsquare, deusbodalpha, npc.rotation, Utils.Size(deusbodsquare) / 2f, npc.scale, SpriteEffects.None, 0f);
                    return false;
                }

                //DEUS TAIL
                else if (npc.type == ModLoader.GetMod("CalamityMod").NPCType("AstrumDeusTailSpectral"))
                {
                    Texture2D deustailsprite = (ModContent.GetTexture("CalValEX/Items/Tiles/Astral/DeusTailOld"));

                    float deustailframe = 1f / (float)Main.npcFrameCount[npc.type];
                    int deustailheight = (int)((float)(npc.frame.Y / npc.frame.Height) * deustailframe) * (deustailsprite.Height / 1);

                    Rectangle deustailsquare = new Rectangle(0, deustailheight, deustailsprite.Width, deustailsprite.Height / 1);
                    Color deustailalpha = npc.GetAlpha(drawColor);
                    spriteBatch.Draw(deustailsprite, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deustailsquare, deustailalpha, npc.rotation, Utils.Size(deustailsquare) / 2f, npc.scale, SpriteEffects.None, 0f);
                    return false;
                }
            }
            return true;

        }

        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Color lightColor)
        {
            if (Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneAstral || Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().Blok)
            {
                //DEUS HEAD
                if (npc.type == ModLoader.GetMod("CalamityMod").NPCType("AstrumDeusHeadSpectral"))
                {
                    Texture2D deusheadsprite2 = (ModContent.GetTexture("CalValEX/Items/Tiles/Astral/DeusHeadOld_Glow"));

                    float deusheadframe2 = 1f / (float)Main.npcFrameCount[npc.type];
                    int deusheadheight2 = (int)((float)(npc.frame.Y / npc.frame.Height) * deusheadframe2) * (deusheadsprite2.Height / 1);

                    Rectangle deusheadsquare2 = new Rectangle(0, deusheadheight2, deusheadsprite2.Width, deusheadsprite2.Height / 1);
                    spriteBatch.Draw(deusheadsprite2, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusheadsquare2, Color.White, npc.rotation, Utils.Size(deusheadsquare2) / 2f, npc.scale, SpriteEffects.None, 0f);
                }

                //DEUS BODY
                else if (npc.type == ModLoader.GetMod("CalamityMod").NPCType("AstrumDeusBodySpectral"))
                {
                    Texture2D deusbodsprite2 = npc.localAI[3] == 1f ? ModContent.GetTexture("CalValEX/Items/Tiles/Astral/DeusBodyAltOld_Glow") : ModContent.GetTexture("CalValEX/Items/Tiles/Astral/DeusBodyOld_Glow");

                    float deusbodframe2 = 1f / (float)Main.npcFrameCount[npc.type];
                    int deusbodheight2 = (int)((float)(npc.frame.Y / npc.frame.Height) * deusbodframe2) * (deusbodsprite2.Height / 1);

                    Rectangle deusbodsquare2 = new Rectangle(0, deusbodheight2, deusbodsprite2.Width, deusbodsprite2.Height / 1);
                    spriteBatch.Draw(deusbodsprite2, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deusbodsquare2, Color.White, npc.rotation, Utils.Size(deusbodsquare2) / 2f, npc.scale, SpriteEffects.None, 0f);
                }

                //DEUS TAIL
                else if (npc.type == ModLoader.GetMod("CalamityMod").NPCType("AstrumDeusTailSpectral"))
                {
                    Texture2D deustailsprite2 = (ModContent.GetTexture("CalValEX/Items/Tiles/Astral/DeusTailOld_Glow"));

                    float deustailframe2 = 1f / (float)Main.npcFrameCount[npc.type];
                    int deustailheight2 = (int)((float)(npc.frame.Y / npc.frame.Height) * deustailframe2) * (deustailsprite2.Height / 1);

                    Rectangle deustailsquare2 = new Rectangle(0, deustailheight2, deustailsprite2.Width, deustailsprite2.Height / 1);
                    spriteBatch.Draw(deustailsprite2, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), deustailsquare2, Color.White, npc.rotation, Utils.Size(deustailsquare2) / 2f, npc.scale, SpriteEffects.None, 0f);
                }
            }
        }
    }
}