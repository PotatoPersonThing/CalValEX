using CalValEX.Buffs.LightPets;
using CalValEX.Buffs.Pets;
using CalValEX.Items;
using CalValEX.Items.Equips.Balloons;
using CalValEX.Items.Equips.Hats;
using CalValEX.Items.Equips.Legs;
using CalValEX.Items.Equips.Scarves;
using CalValEX.Items.Equips.Shields;
using CalValEX.Items.Equips.Shirts;
using CalValEX.Items.Equips.Wings;
using CalValEX.Items.Hooks;
using CalValEX.Items.LightPets;
using CalValEX.Items.Mounts;
using CalValEX.Items.Pets;
using CalValEX.Items.Tiles;
using CalValEX.Items.Tiles.Blocks;
using CalValEX.Items.Tiles.FurnitureSets.Bloodstone;
using CalValEX.Items.Tiles.FurnitureSets.Necrotic;
using CalValEX.Items.Tiles.FurnitureSets.Phantowax;
using CalValEX.Items.Tiles.Monoliths;
using CalValEX.Items.Tiles.Paintings;
using CalValEX.Items.Tiles.Plants;
using CalValEX.Items.Tiles.Statues;
using CalValEX.AprilFools;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX
{
    public class CalValEXGlobalitem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;

        public override void SetDefaults(Item item)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (item.type == calamityMod.ItemType("Bloodstone"))
            {
                item.useTurn = true;
                item.autoReuse = true;
                item.useAnimation = 15;
                item.useTime = 10;
                item.useStyle = ItemUseStyleID.SwingThrow;
                item.consumable = true;
                item.createTile = ModContent.TileType<BloodstonePlaced>();
            }
        }

        public override void RightClick(Item item, Player player)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (!CalValEXConfig.Instance.DisableVanityDrops)
            {
                if (item.type == calamityMod.ItemType("StarterBag"))
                {
                    if (player.whoAmI == Main.myPlayer)
                    {
                        if (CalValEX.month == 4 && (CalValEX.day == 1 || CalValEX.day == 2 || CalValEX.day == 3 || CalValEX.day == 4 || CalValEX.day == 5 || CalValEX.day == 6 || CalValEX.day == 7))
                        {
                        NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<Jharim>(), 0, 0f, 0f, 0f, 0f, 255);	
                        }
                        player.QuickSpawnItem(ModContent.ItemType<C>());
                        switch (player.name)
                        {
                            case "Jared":
                                player.QuickSpawnItem(ModContent.ItemType<EWail>());
                                player.QuickSpawnItem(ModContent.ItemType<SoulShard>());
                                break;

                            case "RamG":
                            case "Ramgear":
                                player.QuickSpawnItem(ModContent.ItemType<ToyScythe>());
                                break;

                            case "Bumbledoge":
                            case "BumbleDoge":
                            case "Bojangles":
                            case "Bojeangles":
                                player.QuickSpawnItem(ModContent.ItemType<AeroPebble>());
                                player.QuickSpawnItem(ModContent.ItemType<FluffyFur>());
                                break;

                            case "William":
                                player.QuickSpawnItem(ModContent.ItemType<EurosBandage>());
                                break;

                            case "Kiwabug":
                                player.QuickSpawnItem(ModContent.ItemType<UglyTentacle>());
                                break;

                            case "YuH":
                                player.QuickSpawnItem(ModContent.ItemType<Eidolistthingy>());
                                break;

                            case "Hypera":
                                player.QuickSpawnItem(ModContent.ItemType<SolarBun>());
                                break;

                            case "Drakudragonx":
                                player.QuickSpawnItem(ModContent.ItemType<BambooStick>());
                                break;

                            case "Lucca":
                                player.QuickSpawnItem(ModContent.ItemType<JunkoHat>());
                                player.QuickSpawnItem(ModContent.ItemType<ToyScythe>());
                                break;

                            case "Junko":
                                player.QuickSpawnItem(ModContent.ItemType<JunkoHat>());
                                player.QuickSpawnItem(ModContent.ItemType<ToyScythe>());
                                player.QuickSpawnItem(ModContent.ItemType<ProfanedBalloon>());
                                break;

                            case "Lil Junko":
                                player.QuickSpawnItem(ModContent.ItemType<JunkoHat>());
                                break;

                            case "Mathew Maple":
                                player.QuickSpawnItem(ModContent.ItemType<SwearingShroom>());
                                break;

                            case "Cooper":
                                player.QuickSpawnItem(ModContent.ItemType<coopershortsword>());
                                break;

                            case "Enreden":
                                player.QuickSpawnItem(ModContent.ItemType<Enredenitem>());
                                break;

                            case "Emerald":
                            case "EmeraldXLapis":
                                player.QuickSpawnItem(ModContent.ItemType<FogG>());
                                break;

                            case "Yharex87":
                            case "Yharex":
                                player.QuickSpawnItem(ModContent.ItemType<JellyBottle>());
                                player.QuickSpawnItem(ModContent.ItemType<YharexsLetter>());
                                break;

                            case "Scarfy":
                            case "Krysmun":
                            case "DodoNation":
                            case "Dodo":
                                player.QuickSpawnItem(ModContent.ItemType<FluffyFeather>());
                                break;

                            case "Willow":
                            case "willowmaine":
                            case "bean long":
                                player.QuickSpawnItem(ModContent.ItemType<PerennialFlower>());
                                player.QuickSpawnItem(ModContent.ItemType<VVanities>());
                                break;

                            case "Potato Person":
                                player.QuickSpawnItem(ModContent.ItemType<MissingFang>());
                                break;
                        }
                    }
                }

                if (item.type == calamityMod.ItemType("AbyssalCrate"))
                {
                    if (Main.rand.NextFloat() < 0.035f)
                    {
                        player.QuickSpawnItem(ModContent.ItemType<AcidGun>());
                    }

                    if (Main.rand.NextFloat() < 0.02f)
                    {
                        player.QuickSpawnItem(ModContent.ItemType<CursedLockpick>());
                    }

                    if (Main.rand.NextFloat() < 0.05f)
                    {
                        player.QuickSpawnItem(ModContent.ItemType<SulphurColumn>(), Main.rand.Next(5, 7));
                    }

                    if (Main.rand.NextFloat() < 0.05f)
                    {
                        player.QuickSpawnItem(ModContent.ItemType<SulphurGeyser>(), Main.rand.Next(2, 3));
                    }

                    if ((bool) calamityMod.Call("GetBossDowned", "calamitas") & (Main.rand.NextFloat() < 0.02f))
                    {
                        player.QuickSpawnItem(ModContent.ItemType<Pollution>());
                    }

                    if ((bool) calamityMod.Call("GetBossDowned", "polterghast") & (Main.rand.NextFloat() < 0.025f))
                    {
                        player.QuickSpawnItem(ModContent.ItemType<EidolonTree>());
                    }

                    if ((bool) calamityMod.Call("GetBossDowned", "oldduke") & (Main.rand.NextFloat() < 0.1f))
                    {
                        player.QuickSpawnItem(ModContent.ItemType<NuclearFumes>(), Main.rand.Next(2, 11));
                    }

                    if ((bool) calamityMod.Call("GetBossDowned", "aquaticscourge") & (Main.rand.NextFloat() < 0.05f))
                    {
                        player.QuickSpawnItem(ModContent.ItemType<BelchingCoral>());
                    }
                }

                if (item.type == calamityMod.ItemType("AstralCrate"))
                {
                    if (Main.rand.NextFloat() < 0.03f)
                    {
                        player.QuickSpawnItem(ModContent.ItemType<MonolithPot>());
                    }

                    if (Main.rand.NextFloat() < 0.005f)
                    {
                        player.QuickSpawnItem(ModContent.ItemType<AstralOldPurple>());
                    }

                    if (Main.rand.NextFloat() < 0.02f)
                    {
                        player.QuickSpawnItem(ModContent.ItemType<AstralOldYellow>());
                    }

                    if ((bool) calamityMod.Call("GetBossDowned", "signus") & (Main.rand.NextFloat() < 0.05f))
                    {
                        player.QuickSpawnItem(ModContent.ItemType<NetherTree>());
                    }
                }

                if (item.type == calamityMod.ItemType("SunkenCrate"))
                {
                    if (Main.rand.NextFloat() < 0.03f)
                    {
                        player.QuickSpawnItem(ModContent.ItemType<SSCoral>());
                    }

                    if (Main.rand.NextFloat() < 0.03f)
                    {
                        player.QuickSpawnItem(ModContent.ItemType<Anemone>());
                    }

                    if (Main.rand.NextFloat() < 0.03f)
                    {
                        player.QuickSpawnItem(ModContent.ItemType<TableCoral>());
                    }

                    if (Main.rand.NextFloat() < 0.03f)
                    {
                        player.QuickSpawnItem(ModContent.ItemType<FanCoral>());
                    }

                    if (Main.rand.NextFloat() < 0.03f)
                    {
                        player.QuickSpawnItem(ModContent.ItemType<BrainCoral>());
                    }

                    if (Main.rand.NextFloat() < 0.01f)
                    {
                        player.QuickSpawnItem(ModContent.ItemType<SeaCrown>());
                    }

                    if (Main.rand.NextFloat() < 0.025f)
                    {
                        player.QuickSpawnItem(ModContent.ItemType<SunkenLamp>());
                    }
                }
            }
        }

        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");

            if (context == "bossBag")
            {
                if (calamityMod != null)
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

                        if (arg == calamityMod.ItemType("StarterBag"))
                        {
                            player.QuickSpawnItem(ModContent.ItemType<C>());
                        }

                        if (arg == calamityMod.ItemType("DesertScourgeBag"))
                        {
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<DesertMedallion>());
                            }

                            if (Main.rand.NextFloat() < 0.2f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<DriedMandible>());
                            }
                        }

                        if (arg == calamityMod.ItemType("CrabulonBag"))
                        {
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<ClawShroom>());
                            }
                        }

                        if (arg == calamityMod.ItemType("HiveMindBag"))
                        {
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<MissingFang>());
                            }
                        }

                        if (arg == calamityMod.ItemType("PerforatorBag"))
                        {
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<DigestedWormFood>());
                            }
                        }

                        if (arg == calamityMod.ItemType("SlimeGodBag"))
                        {
                            if (!CalValEXConfig.Instance.ConfigBossBlocks)
                            {
                                player.QuickSpawnItem(ModLoader.GetMod("CalamityMod").ItemType("StatigelBlock"),
                                    Main.rand.Next(205, 335));
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<ImpureStick>());
                            }
                        }

                        if (arg == calamityMod.ItemType("CryogenBag"))
                        {
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<CryoStick>());
                            }
                        }

                        if (arg == calamityMod.ItemType("AquaticScourgeBag"))
                        {
                            if (Main.rand.NextFloat() < 0.2f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<AquaticHide>());
                            }
                        }

                        if (arg == calamityMod.ItemType("BrimstoneWaifuBag"))
                        {
                            if (!CalValEXConfig.Instance.ConfigBossBlocks)
                            {
                                player.QuickSpawnItem(ModLoader.GetMod("CalamityMod").ItemType("BrimstoneSlag"),
                                    Main.rand.Next(205, 335));
                            }

                            if (Main.rand.NextFloat() < 0.2f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<BrimmyBody>());
                            }

                            if (Main.rand.NextFloat() < 0.2f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<BrimmySpirit>());
                            }

                            if (Main.rand.NextFloat() < 0.2f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<brimtulip>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<FoilSpoon>());
                            }
                        }

                        if (arg == calamityMod.ItemType("CalamitasBag"))
                        {
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<Calacirclet>());
                            }

                            if (Main.rand.NextFloat() < 0.001f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<AncientAuricTeslaHelm>());
                            }
                        }

                        if (arg == calamityMod.ItemType("LeviathanBag"))
                        {
                            if (Main.rand.NextFloat() < 0.15f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<AquaticMonolith>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<LeviWings>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<FoilAtlantis>());
                            }

                            if (Main.rand.NextFloat() < 0.01f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<WetBubble>());
                            }
                        }

                        if (arg == calamityMod.ItemType("AstrageldonBag"))
                        {
                            if (Main.rand.NextFloat() < 0.2f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<AstDie>());
                            }

                            if (Main.rand.NextFloat() < 0.2f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<AureusShield>());
                            }

                            if (Main.rand.NextFloat() < 0.001f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<AncientAuricTeslaHelm>());
                            }
                        }

                        if (arg == calamityMod.ItemType("PlaguebringerGoliathBag"))
                        {
                            if (!CalValEXConfig.Instance.ConfigBossBlocks)
                            {
                                player.QuickSpawnItem(ModLoader.GetMod("CalamityMod").ItemType("PlaguedPlate"),
                                    Main.rand.Next(205, 335));
                            }

                            if (Main.rand.NextFloat() < 0.004f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<AncientAuricTeslaHelm>());
                            }

                            if (Main.rand.NextFloat() < 0.2f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<InfectedController>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<PlaguePack>());
                            }

                            if (Main.rand.NextFloat() < 0.33f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<PlagueHiveWand>());
                            }
                        }

                        if (arg == calamityMod.ItemType("RavagerBag"))
                        {
                            if (!CalValEXConfig.Instance.ConfigBossBlocks)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<Necrostone>(), Main.rand.Next(205, 335));
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<AncientChoker>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<RavaHook>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<SkullBalloon>());
                            }
                        }

                        if (arg == calamityMod.ItemType("AstrumDeusBag"))
                        {
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<AstralStar>());
                            }

                            if (Main.rand.NextFloat() < 0.2f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<AstBandana>());
                            }
                        }

                        if (arg == calamityMod.ItemType("BumblebirbBag"))
                        {
                            if ((bool) calamityMod.Call("GetBossDowned", "yharon") &&
                                !CalValEXConfig.Instance.ConfigBossBlocks)
                            {
                                player.QuickSpawnItem(ModLoader.GetMod("CalamityMod").ItemType("SilvaCrystal"),
                                    Main.rand.Next(205, 335));
                            }

                            int choice = Main.rand.Next(4);
                            if (choice == 0)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<FollyWings>());
                            }
                            else if (choice == 1)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<OrbSummon>());
                            }
                            else if (choice == 2)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<Birbhat>());
                            }
                            else
                            {
                                player.QuickSpawnItem(ModContent.ItemType<FollyWing>());
                            }

                            if (Main.rand.NextFloat() < 0.005f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<AncientAuricTeslaHelm>());
                            }
                        }

                        if (arg == calamityMod.ItemType("ProvidenceBag"))
                        {
                            if (!CalValEXConfig.Instance.ConfigBossBlocks)
                            {
                                player.QuickSpawnItem(ModLoader.GetMod("CalamityMod").ItemType("ProfanedRock"),
                                    Main.rand.Next(205, 335));
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<ProShard>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<ProviCrystal>());
                            }
                        }

                        if (arg == calamityMod.ItemType("PolterghastBag"))
                        {
                            if (!CalValEXConfig.Instance.ConfigBossBlocks)
                            {
                                if (Main.rand.NextFloat() < 0.5f)
                                {
                                    player.QuickSpawnItem(ModLoader.GetMod("CalamityMod").ItemType("StratusBricks"),
                                        Main.rand.Next(205, 335));
                                }
                                else
                                {
                                    player.QuickSpawnItem(ModContent.ItemType<PhantowaxBlock>(),
                                        Main.rand.Next(205, 335));
                                }
                            }

                            if (Main.rand.NextFloat() < 0.1f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<Polterhook>());
                            }
                        }

                        if (arg == calamityMod.ItemType("OldDukeBag"))
                        {
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<OldWings>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<CorrodedCleaver>());
                            }
                        }

                        if (arg == calamityMod.ItemType("DevourerofGodsBag"))
                        {
                            if (Main.rand.NextFloat() < 0.1f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<CosmicWormScarf>());
                            }

                            if (Main.rand.NextFloat() < 0.07f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<RapturedWormScarf>());
                            }

                            if (Main.rand.NextFloat() < 0.01f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<AncientAuricTeslaHelm>());
                            }
                        }

                        if (arg == calamityMod.ItemType("YharonBag"))
                        {
                            player.QuickSpawnItem(ModContent.ItemType<Termipebbles>(), Main.rand.Next(5, 8));
                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<JunglePhoenixWings>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<NuggetBiscuit>());
                            }

                            if (Main.rand.NextFloat() < 0.3f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<YharonShackle>());
                            }

                            if (Main.rand.NextFloat() < 0.05f)
                            {
                                player.QuickSpawnItem(ModContent.ItemType<AncientAuricTeslaHelm>());
                            }
                        }
                    }
                }
            }
        }

        public void DeleteRecipes(int item)
        {
            RecipeFinder val = new RecipeFinder();
            val.SetResult(item);
            foreach (Recipe item2 in val.SearchRecipes()) new RecipeEditor(item2).DeleteRecipe();
        }

        public override void AddRecipes()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            DeleteRecipes(calamityMod.ItemType("AuricToilet"));
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CosmiliteChairEX>());
            recipe.AddIngredient(ModContent.ItemType<BloodstoneChairItem>());
            recipe.AddIngredient(calamityMod.ItemType("BotanicChair"));
            recipe.AddIngredient(calamityMod.ItemType("SilvaChair"));
            recipe.AddIngredient(calamityMod.ItemType("AuricBar"), 4);
            recipe.AddTile(calamityMod.TileType("DraedonsForge"));
            recipe.SetResult(calamityMod.ItemType("AuricToilet"));
            recipe.AddRecipe();
        }

        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if ((head.type == calamityMod.ItemType("WulfrumHelmet") ||
                 head.type == calamityMod.ItemType("WulfrumHelm") ||
                 head.type == calamityMod.ItemType("WulfrumHeadgear") ||
                 head.type == calamityMod.ItemType("WulfrumHood") ||
                 head.type == calamityMod.ItemType("WulfrumMask")) &&
                body.type == calamityMod.ItemType("WulfrumArmor") &&
                legs.type == calamityMod.ItemType("WulfrumLeggings"))
            {
                return "Wulfrumset";
            }

            return "";
        }

        public override void UpdateArmorSet(Player player, string set)
        {
            if (player.HasBuff(ModContent.BuffType<PylonBuff>()) &&
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