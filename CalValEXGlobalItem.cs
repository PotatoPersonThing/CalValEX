//using CalValEX.Buffs.LightPets;
using CalValEX.Buffs.Pets;
using CalValEX.Items;
using CalValEX.Items.Critters;
using CalValEX.Items.Equips.Balloons;
using CalValEX.Items.Equips.Hats;
using CalValEX.Items.Equips.Legs;
using CalValEX.Items.Equips.Scarves;
using CalValEX.Items.Equips.Shields;
using CalValEX.Items.Equips.Shirts;
using CalValEX.Items.Equips.Transformations;
using CalValEX.Items.Equips.Wings;
using CalValEX.Items.Hooks;
using CalValEX.Items.LightPets;
using CalValEX.Buffs.Mounts;
using CalValEX.Items.Mounts.InfiniteFlight;
using CalValEX.Items.Mounts.Ground;
using CalValEX.Items.Mounts.LimitedFlight;
using CalValEX.Items.Pets;
using CalValEX.Items.Pets.Elementals;
using CalValEX.Items.Tiles;
using CalValEX.Items.Tiles.Blocks;
using CalValEX.Items.Tiles.FurnitureSets.Bloodstone;
using CalValEX.Tiles.Blocks;
using CalValEX.Tiles;
using CalValEX.Tiles.MiscFurniture;
using CalValEX.Items.Tiles.Monoliths;
using CalValEX.Items.Tiles.Paintings;
using CalValEX.Items.Tiles.Plants;
using CalValEX.Items.Tiles.Statues;
using CalamityMod.World;
using CalamityMod.Items.TreasureBags;
using CalamityMod.Items;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Armor.Wulfrum;
using CalValEX.AprilFools;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CalValEX
{
    public class CalValEXGlobalitem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        //public override bool CloneNewInstances => true;

        public override void SetDefaults(Item item)
        {
            if (item.type == ModContent.ItemType<CalamityMod.Items.Materials.Bloodstone>())
            {
                item.useTurn = true;
                item.autoReuse = true;
                item.useAnimation = 15;
                item.useTime = 10;
                item.useStyle = ItemUseStyleID.Swing;
                item.consumable = true;
                item.createTile = ModContent.TileType<BloodstonePlaced>();
            }
            if (item.type == ModContent.ItemType<CalamityMod.Items.Materials.MeldConstruct>())
            {
                item.useTurn = true;
                item.autoReuse = true;
                item.useAnimation = 15;
                item.useTime = 10;
                item.useStyle = ItemUseStyleID.Swing;
                item.consumable = true;
                item.createTile = ModContent.TileType<MeldConstructPlaced>();
            }
            if (item.type == ModContent.ItemType<CalamityMod.Items.SummonItems.CeremonialUrn>())
            {
                item.useTurn = true;
                item.autoReuse = true;
                item.useAnimation = 15;
                item.useTime = 10;
                item.useStyle = ItemUseStyleID.Swing;
                item.consumable = true;
                item.createTile = ModContent.TileType<CeremonialUrnPlaced>();
            }
            if (item.type == ModContent.ItemType<SupremeCalamitasCoffer>())
            {
                item.useTurn = true;
                item.autoReuse = true;
                item.useAnimation = 15;
                item.useTime = 10;
                item.useStyle = ItemUseStyleID.Swing;
                item.consumable = true;
                item.createTile = ModContent.TileType<CalamitasCofferPlaced>();
            }
            if (item.type == ModContent.ItemType<DraedonBag>())
            {
                item.useTurn = true;
                item.autoReuse = true;
                item.useAnimation = 15;
                item.useTime = 10;
                item.useStyle = ItemUseStyleID.Swing;
                item.consumable = true;
                item.createTile = ModContent.TileType<DraedonQuoteonQuoteBagPlaced>();
            }
        }

        /*public override void ModifyWeaponDamage(Item item, Player player, ref float add, ref float mult)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            Mod orthoceraDLC = ModLoader.GetMod("CalValPlus");
            bool april = (CalValEX.month == 4 && (CalValEX.day == 1 || CalValEX.day == 2 || CalValEX.day == 3 || CalValEX.day == 4 || CalValEX.day == 5 || CalValEX.day == 6 || CalValEX.day == 7));
            if (orthoceraDLC != null || april)
            {
                if (item.type == calamityMod.ItemType("CosmicDischarge"))
                {
                    item.damage = item.damage + ((bool)calamityMod.Call("GetBossDowned", "yharon") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "supremecalamitas") ? 1 : 0);
                }
                else if (item.type == calamityMod.ItemType("SHPC"))
                {
                    item.damage = item.damage + (NPC.downedMechBoss1 ? 0 : 1)
                        + (NPC.downedMechBoss2 ? 0 : 1) + (NPC.downedMechBoss3 ? 0 : 1)
                        + (NPC.downedPlantBoss ? 0 : 1) + (NPC.downedGolemBoss ? 0 : 1)
                        + (NPC.downedMoonlord ? 0 : 1)
                        + ((bool)calamityMod.Call("GetBossDowned", "providence") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "devourerofgods") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "yharon") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "supremecalamitas") ? 1 : 0);
                }
                else if (item.type == calamityMod.ItemType("BlossomFlux"))
                {
                    item.damage = item.damage + (NPC.downedGolemBoss ? 0 : 1)
                        + (NPC.downedMoonlord ? 0 : 1)
                        + ((bool)calamityMod.Call("GetBossDowned", "providence") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "devourerofgods") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "yharon") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "supremecalamitas") ? 1 : 0);
                }
                else if (item.type == calamityMod.ItemType("Malachite"))
                {
                    item.damage = item.damage + (NPC.downedMoonlord ? 0 : 1)
                        + ((bool)calamityMod.Call("GetBossDowned", "providence") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "devourerofgods") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "yharon") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "supremecalamitas") ? 1 : 0);
                }
                else if (item.type == calamityMod.ItemType("AegisBlade"))
                {
                    item.damage = item.damage + (NPC.downedMoonlord ? 0 : 1)
                        + ((bool)calamityMod.Call("GetBossDowned", "providence") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "devourerofgods") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "yharon") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "supremecalamitas") ? 1 : 0);
                }
                else if (item.type == calamityMod.ItemType("BrinyBaron"))
                {
                    item.damage = item.damage + (NPC.downedMoonlord ? 0 : 1)
                        + ((bool)calamityMod.Call("GetBossDowned", "providence") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "devourerofgods") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "yharon") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "supremecalamitas") ? 1 : 0);
                }
                else if (item.type == calamityMod.ItemType("Vesuvius"))
                {
                    item.damage = item.damage + (NPC.downedMoonlord ? 0 : 1)
                        + ((bool)calamityMod.Call("GetBossDowned", "providence") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "devourerofgods") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "yharon") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "supremecalamitas") ? 1 : 0);
                }
                else if (item.type == calamityMod.ItemType("ElementalBlaster"))
                {
                    item.damage = item.damage + 1;
                }
            }
        }*/

        public override void ArmorSetShadows(Player player, string set)
        {
            if (player.GetModPlayer<CalValEXPlayer>().cassette)
            {
                player.armorEffectDrawShadow = true;
                player.armorEffectDrawOutlines = true;
            }
        }
		public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
		{
			base.ModifyItemLoot(item, itemLoot);
		}
		public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (context == "bossBag")
            {
                    if (!CalValEXConfig.Instance.DisableVanityDrops)
                    {
                        //Here is a list of all Calamity Bags:
                        //Aquatic Scourge = AquaticScourgeBag
                        //Astrum Aureus = AstrageldonBag
                        //Astrum Deus = AstrumDeusBag
                        //Brimstone Elemental = BrimstoneWaifuBag
                        //Dragonfolly = BumblebirbBag
                        //Calamitas = CalamitasBag
                        //Crabulon = CrabulonBag
                        //Cryogen = CryogenBag
                        //Desert Scourge = DesertScourgeBag
                        //Devourer of Gods = DevourerofGodsBag
                        //Hive Mind = HiveMindBag
                        //Leviathan and Siren = LeviathanBag
                        //Old Duke = OldDukeBag
                        //Perforators = PerforatorBag
                        //Plaguebringer Goliath = PlaguebringerGoliathBag
                        //Polterghast = PolterghastBag
                        //Providence = ProvidenceBag
                        //Ravager = RavagerBag
                        //Slime God = SlimeGodBag
                        //Starter Bag = StarterBag
                        //Yharon = YharonBag

                        if (arg == ModContent.ItemType<StarterBag>())
                        {
                            player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<C>());
                        }

                        if (arg == ModContent.ItemType<DesertScourgeBag>())
                        {
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<DesertMedallion>());
                            }

                            if (Main.rand.NextFloat() < 0.2f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<DriedLocket>());
                            }

                            if (Main.rand.NextFloat() < 0.07f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SlightlyMoistbutalsoSlightlyDryLocket>());
                            }
                        }

                        if (arg == ModContent.ItemType<CrabulonBag>())
                        {
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<ClawShroom>());
                            }
                        }

                        if (arg == ModContent.ItemType<HiveMindBag>())
                        {
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<RottenKey>());
                            }
                        }

                        if (arg == ModContent.ItemType<PerforatorBag>())
                        {
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<MeatyWormTumor>());
                            }

                            if (Main.rand.NextFloat() < 0.4f)
                            {
                                int choice = Main.rand.Next(3);
                                if (choice == 0)
                                {
                                    player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SmallWorm>());
                                }
                                if (choice == 1)
                                {
                                    player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<MidWorm>());
                                }
                                else
                                {
                                    player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<BigWorm>());
                                }
                            }
                        }

                        if (arg == ModContent.ItemType<SlimeGodBag>())
                        {
                            if (!CalValEXConfig.Instance.ConfigBossBlocks)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureStatigel.StatigelBlock>(),
                                    Main.rand.Next(205, 335));
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SlimeDeitysSoul>());
                            }
                        }

                        if (arg == ModContent.ItemType<CryogenBag>())
                        {
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CoolShades>());
                            }
                        }

                        if (arg == ModContent.ItemType<AquaticScourgeBag>())
                        {
                            if (Main.rand.NextFloat() < 0.2f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<MoistLocket>());
                            }
                        }

                        if (arg == ModContent.ItemType<BrimstoneWaifuBag>())
                        {
                            if (!CalValEXConfig.Instance.ConfigBossBlocks)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CalamityMod.Items.Placeables.BrimstoneSlag>(),
                                    Main.rand.Next(205, 335));
                            }

                            if (Main.rand.NextFloat() < 0.2f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<BrimmyBody>());
                            }

                            if (Main.rand.NextFloat() < 0.2f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<BrimmySpirit>());
                            }

                            if (Main.rand.NextFloat() < 0.2f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<RareBrimtulip>());
                            }

                            if (Main.rand.NextFloat() < 0.05f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<FoilSpoon>());
                            }
                        }

                        if (arg == ModContent.ItemType<CalamitasBag>())
                        {
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<Calacirclet>());
                            }

                            if (Main.rand.NextFloat() < 0.001f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<AncientAuricTeslaHelm>());
                            }

                            if (CalamityMod.DownedBossSystem.downedProvidence && Main.rand.NextFloat() < 0.2f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<DemonshadeHood>(), 1);
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<DemonshadeRobe>(), 1);
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<DemonshadePants>(), 1);
                            }
                        }

                        if (arg == ModContent.ItemType<LeviathanBag>())
                        {
                            if (Main.rand.NextFloat() < 0.15f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<AquaticMonolith>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<LeviWings>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<LeviathanEgg>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<FoilAtlantis>());
                            }

                            if (Main.rand.NextFloat() < 0.01f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<StrangeMusicNote>());
                            }
                        }

                        if (arg == ModContent.ItemType<AstrumAureusBag>())
                        {
                            if (Main.rand.NextFloat() < 0.2f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<AstralInfectedIcosahedron>());
                            }

                            if (Main.rand.NextFloat() < 0.2f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<AureusShield>());
                            }

                            if (Main.rand.NextFloat() < 0.001f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<AncientAuricTeslaHelm>());
                            }
                        }

                        if (arg == ModContent.ItemType<PlaguebringerGoliathBag>())
                        {
                            if (!CalValEXConfig.Instance.ConfigBossBlocks)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CalamityMod.Items.Placeables.FurniturePlagued.PlaguedContainmentBrick>(),
                                    Main.rand.Next(205, 335));
                            }

                            if (Main.rand.NextFloat() < 0.004f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<AncientAuricTeslaHelm>());
                            }

                            if (Main.rand.NextFloat() < 0.2f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<InfectedController>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<PlaguePack>());
                            }

                            if (Main.rand.NextFloat() < 0.33f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<PlagueHiveWand>());
                            }
                        }

                        if (arg == ModContent.ItemType<RavagerBag>())
                        {
                            if (!CalValEXConfig.Instance.ConfigBossBlocks)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<Necrostone>(), Main.rand.Next(205, 335));
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SkullCluster>());
                            }

                            if (Main.rand.NextFloat() < 0.07f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<ScavaHook>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<RavaHook>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SkullBalloon>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<StonePile>());
                            }
                        }

                        if (arg == ModContent.ItemType<AstrumDeusBag>())
                        {
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<Geminga>());
                            }

                            if (Main.rand.NextFloat() < 0.2f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<AstBandana>());
                            }
                        }

                        if (arg == ModContent.ItemType<DragonfollyBag>())
                        {
                            if (CalamityMod.DownedBossSystem.downedYharon &&
                                !CalValEXConfig.Instance.ConfigBossBlocks)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureSilva.SilvaCrystal>(),
                                    Main.rand.Next(205, 335));
                            }

                            int choice = Main.rand.Next(3);
                            if (choice == 0)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<FollyWings>());
                            }
                            else if (choice == 1)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<Birbhat>());
                            }
                            else
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<DocilePheromones>());
                            }

                            if (Main.rand.NextFloat() < 0.005f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<AncientAuricTeslaHelm>());
                            }
                        }

                        if (arg == ModContent.ItemType<ProvidenceBag>())
                        {
                            if (!CalValEXConfig.Instance.ConfigBossBlocks)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureProfaned.ProfanedRock>(),
                                    Main.rand.Next(205, 335));
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<ProfanedHeart>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<ProviCrystal>());
                            }
                        }

                        if (arg == ModContent.ItemType<StormWeaverBag>())
                        {
                            if (!CalValEXConfig.Instance.ConfigBossBlocks && CalamityMod.DownedBossSystem.downedDoG)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureOtherworldly.OtherworldlyStone>(),
                                    Main.rand.Next(205, 335));
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                if (Main.rand.NextFloat() < 0.5f)
                                {
                                    player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<StormMedal>());
                                }
                                else
                                {
                                    player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<ArmoredScrap>());
                                }
                            }
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<StormBandana>());
                            }
                            if (Main.rand.NextFloat() < 0.007f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<AncientAuricTeslaHelm>());
                            }
                        }

                        if (arg == ModContent.ItemType<CeaselessVoidBag>())
                        {
                            if (!CalValEXConfig.Instance.ConfigBossBlocks && CalamityMod.DownedBossSystem.downedDoG)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureOtherworldly.OtherworldlyStone>(),
                                    Main.rand.Next(205, 335));
                            }
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<MirrorMatter>());
                            }
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<VoidWings>());
                            }
                            if (Main.rand.NextFloat() < 0.05f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<OldVoidWings>());
                            }
                            if (Main.rand.NextFloat() < 0.007f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<AncientAuricTeslaHelm>());
                            }
                        }

                        if (arg == ModContent.ItemType<SignusBag>())
                        {
                            if (!CalValEXConfig.Instance.ConfigBossBlocks && CalamityMod.DownedBossSystem.downedDoG)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureOtherworldly.OtherworldlyStone>(),
                                    Main.rand.Next(205, 335));
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<ShadowCloth>());
                            }

                            int choice = Main.rand.Next(4);
                            if (choice == 0)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SignusEmblem>());
                            }
                            else if (choice == 1)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SignusNether>());
                            }
                            else if (choice == 2)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SignusBalloon>());
                            }
                            else
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<Items.Equips.Capes.SigCape>());
                            }
                            if (Main.rand.NextFloat() < 0.007f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<AncientAuricTeslaHelm>());
                            }
                        }

                            if (arg == ModContent.ItemType<PolterghastBag>())
                        {
                            if (!CalValEXConfig.Instance.ConfigBossBlocks)
                            {
                                if (Main.rand.NextFloat() < 0.5f)
                                {
                                    player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureStratus.StratusBricks>(),
                                        Main.rand.Next(205, 335));
                                }
                                else
                                {
                                    player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<PhantowaxBlock>(),
                                        Main.rand.Next(205, 335));
                                }
                            }

                            if (Main.rand.NextFloat() < 0.1f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<Polterhook>());
                            }
                        }

                        if (arg == ModContent.ItemType<OldDukeBag>())
                        {
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<OldWings>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CorrodedCleaver>());
                            }

                            if (Main.rand.NextFloat() < 0.07f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CharredChopper>());
                            }
                        }

                        if (arg == ModContent.ItemType<DevourerofGodsBag>())
                        {
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CosmicWormScarf>());
                            }

                            if (Main.rand.NextFloat() < 0.2f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CosmicRapture>());
                            }

                            if (Main.rand.NextFloat() < 0.07f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<RapturedWormScarf>());
                            }

                            if (Main.rand.NextFloat() < 0.01f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<AncientAuricTeslaHelm>());
                            }
                        }

                        if (arg == ModContent.ItemType<YharonBag>())
                        {
                            player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<Termipebbles>(), Main.rand.Next(5, 8));
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<JunglePhoenixWings>());
                            }

                            if (Main.rand.NextFloat() < 0.3f && !(CalValEX.month == 6 && CalValEX.day == 1))
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<YharonsAnklet>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<NuggetinaBiscuit>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<YharonShackle>());
                            }

                            if (Main.rand.NextFloat() < 0.05f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<AncientAuricTeslaHelm>());
                            }

                            if (Main.rand.NextFloat() < 0.1f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<DemonshadeHood>());
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<DemonshadeRobe>());
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<DemonshadePants>());
                            }
                        }

                        if (arg == ModContent.ItemType<DraedonBag>())
                    {
                        if (!CalValEXConfig.Instance.ConfigBossBlocks)
                        {
                            player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureExo.ExoPlating>(),
                                Main.rand.Next(205, 335));
                        }
                        if (CalamityMod.DownedBossSystem.downedThanatos)
                            {
                                if (Main.rand.NextFloat() < 0.5f)
                                {
                                    player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<XMLightningHook>());
                                }
                                if (Main.rand.NextFloat() < 0.5f)
                                {
                                    player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<Items.Pets.ExoMechs.GunmetalRemote>());
                                }
                            }
                            if (CalamityMod.DownedBossSystem.downedArtemisAndApollo)
                            {
                                if (Main.rand.NextFloat() < 0.5f)
                                {
                                    player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<ApolloBalloonSmall>());
                                    player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<ArtemisBalloonSmall>());
                                }
                                if (Main.rand.NextFloat() < 0.5f)
                                {
                                    player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<Items.Pets.ExoMechs.GeminiMarkImplants>());
                                }
                            }
                            if (CalamityMod.DownedBossSystem.downedAres)
                            {
                                if (Main.rand.NextFloat() < 0.5f)
                                {
                                    player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<Items.Equips.Shirts.AresChestplate.AresChestplate>());
                                }
                                if (Main.rand.NextFloat() < 0.5f)
                                {
                                    player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<Items.Pets.ExoMechs.OminousCore>());
                                }
                            }
                            if (Main.rand.NextFloat() < 0.1f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<AncientAuricTeslaHelm>());
                            }
                            if (Main.rand.NextFloat() < 0.14f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<DraedonBody>());
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<DraedonLegs>());
                            }
                        }

                        if (arg == ModContent.ItemType<SupremeCalamitasCoffer>())
                        {
                            if (Main.rand.NextFloat() < 0.1f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<AncientAuricTeslaHelm>());
                            }
                            if (Main.rand.NextFloat() < 0.33f)
                            {
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<GruelingMask>());
                            }
                        }
                    }
                Mod catalyst;
                ModLoader.TryGetMod("CatalystMod", out catalyst);
                if (catalyst != null)
                {
                    if (arg == catalyst.Find<ModItem>("AstrageldonBag").Type)
                    {
                        if (Main.rand.NextFloat() < 0.3f)
                        {
                            player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SpaceJunk>());
                        }
                    }
                }
            }
            //I'm too lazy to merge these two properly so here's some spaghetti
            if (!CalValEXConfig.Instance.DisableVanityDrops)
            {
                if (arg == ModContent.ItemType<StarterBag>())
                {
                    if (player.whoAmI == Main.myPlayer)
                    {
                        if (CalValEX.AprilFoolWeek)
                        {
                            NPC.NewNPC(player.GetSource_ReleaseEntity(), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<AprilFools.Jharim.Jharim>(), 0, 0f, 0f, 0f, 0f, 255);
                        }
                        player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<C>());
                        switch (player.name)
                        {
                            case "Jared":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CanofWyrms>());
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SoulShard>());
                                break;

                            case "RamG":
                            case "Ramgear":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<ToyScythe>());
                                break;

                            case "Bumbledoge":
                            case "BumbleDoge":
                            case "Bojangles":
                            case "Bojeangles":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<AerialiteBubble>());
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<ExtraFluffyFeatherClump>());
                                break;

                            case "William":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<RuinedBandage>());
                                break;

                            case "Kiwabug":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<UglyTentacle>());
                                break;

                            case "YuH":
                            case "Yuh":
                            case "yuh":
                            case "Lilsigtum":
                            case "GinYuH":
                            case "Lil Sigtum":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<FlareRune>());
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SmolEldritchHoodie>());
                                break;

                            case "Hypera":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SunBun>());
                                break;

                            case "Drakudragonx":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<BambooStick>());
                                break;

                            case "Spider":
                            case "spider":
                            case "Spooktacular":
                            case "spooktacular":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<IsopodItem>(), 5);
                                break;

                            case "Fabsol":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CosmicRapture>());
                                break;

                            case "Lucca":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SuspiciousLookingChineseCrown>());
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<ToyScythe>());
                                break;

                            case "Junko":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SuspiciousLookingChineseCrown>());
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<ToyScythe>());
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<ProfanedBalloon>());
                                break;

                            case "Lil Junko":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SuspiciousLookingChineseCrown>());
                                break;

                            case "Cooper":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CooperShortsword>());
                                break;

                            case "Tess":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<Geminga>());
                                break;

                            case "Enreden":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CosmicBubble>());
                                break;

                            case "Iban":
                            case "IbanPlay":
                            case "IBlockaroz":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<ProtoRing>());
                                break;

                            case "Mathew":
                            case "Mathew Maple":
                            case "Maple":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<DeepseaLantern>());
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SwearingShroom>());
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<FleshThing>());
                                break;

                            case "Emerald":
                            case "EmeraldXLapis":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<PurifiedFog>());
                                break;

                            case "Yharex87":
                            case "Yharex":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SpaceJunk>());
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<AstraEGGeldon>());
                                break;

                            case "Scarfy":
                            case "ScarfyScout":
                            case "Krysmun":
                            case "DodoNation":
                            case "Dodo":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<ExtraFluffyFeather>());
                                break;

                            case "caligulasAquarium":
                            case "caligulas":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<BleuBlob>());
                                break;

                            case "Willow":
                            case "willowmaine":
                            case "bean long":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<OldMirage>());
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<PerennialFlower>());
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<VVanities>());
                                break;

                            case "Potato Person":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<RottenKey>());
                                break;

                            case "Dorira":
                            case "Marco":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CharredChopper>());
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<RapturedWormScarf>());
                                break;

                            case "Hat Enthusiast":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<InkyArtifact>());
                                break;

                            case "Triangle":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<BubbledFin>());
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<IonizedJellyCrystal>());
                                break;

                            case "Brimmy":
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<BurningEye>());
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<FoilSpoon>());
                                player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<RareBrimtulip>());
                                break;
                        }
                    }
                }

                if (arg == ModContent.ItemType<CalamityMod.Items.Fishing.SulphurCatches.AbyssalCrate>())
                {
                    if (Main.rand.NextFloat() < 0.01f)
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<Items.Tiles.Plants.AcidGun>());
                    }

                    if (Main.rand.NextFloat() < 0.02f)
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<CursedLockpick>());
                    }

                    if (Main.rand.NextFloat() < 0.05f)
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SulphurColumn>(), Main.rand.Next(5, 7));
                    }

                    if (Main.rand.NextFloat() < 0.05f)
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SulphurGeyser>(), Main.rand.Next(2, 3));
                    }

                    if (Main.rand.NextFloat() < 0.05f)
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SulphurousCactus>(), Main.rand.Next(1, 3));
                    }

                    if (Main.rand.NextFloat() < 0.04f)
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SulphurousPlanter>(), 1);
                    }

                    if (NPC.downedPlantBoss & (Main.rand.NextFloat() < 0.02f))
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<InkyPollution>());
                    }

                    if (NPC.downedAncientCultist & (Main.rand.NextFloat() < 0.025f))
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<EidolonTree>());
                    }

                    if (NPC.downedAncientCultist & (Main.rand.NextFloat() < 0.1f))
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<NuclearFumes>(), Main.rand.Next(2, 11));
                    }

                    if (NPC.downedMechBossAny & (Main.rand.NextFloat() < 0.05f))
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<BelchingCoral>());
                    }
                }

                if (arg == ModContent.ItemType<CalamityMod.Items.Fishing.AstralCatches.AstralCrate>())
                {
                    if (Main.rand.NextFloat() < 0.03f)
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<MonolithPot>());
                    }

                    if (NPC.downedAncientCultist & (Main.rand.NextFloat() < 0.05f))
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<NetherTree>());
                    }
                }

                if (arg == ModContent.ItemType<CalamityMod.Items.Fishing.SunkenSeaCatches.SunkenCrate>())
                {
                    if (Main.rand.NextFloat() < 0.03f)
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SSCoral>());
                    }

                    if (Main.rand.NextFloat() < 0.03f)
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<Anemone>());
                    }

                    if (Main.rand.NextFloat() < 0.03f)
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<TableCoral>());
                    }

                    if (Main.rand.NextFloat() < 0.03f)
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<FanCoral>());
                    }

                    if (Main.rand.NextFloat() < 0.03f)
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<BrainCoral>());
                    }

                    if (Main.rand.NextFloat() < 0.01f)
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SeaCrown>());
                    }

                    if (Main.rand.NextFloat() < 0.025f)
                    {
                        player.QuickSpawnItem(player.GetSource_OpenItem(arg), ModContent.ItemType<SunkenLamp>());
                    }
                }
            }
        }
        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if (head.type == ModContent.ItemType<WulfrumHat>() &&
                body.type == ModContent.ItemType<WulfrumJacket>() &&
                legs.type == ModContent.ItemType<WulfrumOveralls>())
            {
                return "Wulfrumset";
            }

            return "";
        }

        public override void UpdateArmorSet(Player player, string set)
        {
            if (player.HasBuff(ModContent.BuffType<Buffs.LightPets.PylonBuff>()) &&
                player.HasBuff(ModContent.BuffType<WulfrumArmy>()) &&
                player.HasBuff(ModContent.BuffType<TractorMount>()) && set == "Wulfrumset")
            {
                CalValEX.WulfrumsetReal = true;
            }
            else
            {
                CalValEX.WulfrumsetReal = false;
            }
        }
    }
}
