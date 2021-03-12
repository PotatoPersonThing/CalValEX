using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CalValEX.ExtraTextures.ChristmasPets;
using CalValEX.Items;
using CalValEX.Items.Dyes;
using CalValEX.Items.Equips.Balloons;
using CalValEX.Items.Equips.Capes;
using CalValEX.Items.Equips.Hats;
using CalValEX.Items.Equips.Hats.Draedon;
using CalValEX.Items.Equips.Legs;
using CalValEX.Items.Equips.Scarves;
using CalValEX.Items.Equips.Shields;
using CalValEX.Items.Equips.Shirts;
using CalValEX.Items.Equips.Shirts.Draedon;
using CalValEX.Items.Equips.Wings;
using CalValEX.Items.Hooks;
using CalValEX.Items.LightPets;
using CalValEX.Items.Mounts;
using CalValEX.Items.Pets;
using CalValEX.Items.Tiles;
using CalValEX.Items.Tiles.Astral;
using CalValEX.Items.Tiles.Astral.Furniture;
using CalValEX.Items.Tiles.Blocks;
using CalValEX.Items.Tiles.FurnitureSets.Bloodstone;
using CalValEX.Items.Tiles.FurnitureSets.Necrotic;
using CalValEX.Items.Tiles.FurnitureSets.Phantowax;
using CalValEX.JellyPriest;
using CalValEX.Oracle;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalValEX
{
    public class CalValEX : Mod
    {
        public enum MessageType
        {
            SyncOraclePlayer = 0,
            PlayerBagChanged,
            SyncCalValEXPlayer,
            SyncSCalHits
        }

        public static bool Bumble;
        public static bool Wulfrumset;
        public static bool WulfrumsetReal;
        public static string currentDate;
        public static int day;
        public static int month;

        public static MethodInfo compactFraming;

        public override void Load()
        {
            DateTime dateTime = DateTime.Now;
            currentDate = dateTime.ToString("dd/MM/yyyy");
            day = dateTime.Day;
            month = dateTime.Month;
            if (!Main.dedServ)
            {
                AddEquipTexture(null, EquipType.Head, "SandElemental_Head",
                    "CalValEX/Items/Equips/Transformations/SandElemental_Head");
                AddEquipTexture(null, EquipType.Head, "SandElemental_Body",
                    "CalValEX/Items/Equips/Transformations/SandElemental_Body",
                    "CalValEX/Items/Equips/Transformations/SandElemental_Arms");
                AddEquipTexture(null, EquipType.Head, "SandElemental_Legs",
                    "CalValEX/Items/Equips/Transformations/SandElemental_Legs");
                GameShaders.Armor.BindShader(ModContent.ItemType<DraedonHologramDye>(),
                    new ArmorShaderData(new Ref<Effect>(GetEffect("Effects/DraedonHologramDye")),
                        "DraedonHologramDyePass"));
            }

            DraedonHelmetTextureCache.Load(this);
            DraedonChestplateCache.Load(this);
        }

        public override void Unload()
        {
            currentDate = null;
            Bumble = false;
            Wulfrumset = false;
            day = -1;
            month = -1;
            compactFraming = null;
            ChristmasTextureChange.Unload();
            DraedonHelmetTextureCache.Unload(this);
            DraedonChestplateCache.Unload(this);
        }

        public override void PostSetupContent()
        {
            //Tooltip changes
            Mod cal = ModLoader.GetMod("CalamityMod");
            cal.GetItem("KnowledgeCrabulon").Tooltip.AddTranslation(GameCulture.English,
                "A crab and its mushrooms, a love story.\nIt's interesting how creatures can adapt given certain circumstances.\nFavorite this item to gain the Mushy buff while underground or in the mushroom biome.\nHowever, your movement speed will be decreased while in these areas due to you being covered in fungi.\nThe great crustacean's mushrooms may also grow angry when attacked, though they will also become harmless.");
            cal.GetItem("LaboratoryConsoleItem").Tooltip
                .AddTranslation(GameCulture.English, "Can be used to print blueprints");

            //Census support
            Mod censusMod = ModLoader.GetMod("Census");
            if (censusMod != null)
            {
                censusMod.Call("TownNPCCondition", ModContent.NPCType<OracleNPC>(), "Equip a Pet or Light Pet");
                censusMod.Call("TownNPCCondition", ModContent.NPCType<JellyPriestNPC>(),
                    "Find at the Sulphurous Sea after defeating Acid Rain tier 1");
            }

            //Compact tile framing support
            Type tileFraming = cal.Code.GetType("CalamityMod.TileFraming");

            compactFraming = tileFraming.GetMethod("CompactFraming", BindingFlags.Static | BindingFlags.NonPublic);

            //Christmas textures
            ChristmasTextureChange.Load();

            //Boss log support
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Desert Scourge",
                    new List<int>
                    {
                        ModContent.ItemType<DesertMedallion>(), ModContent.ItemType<DriedMandible>(),
                        ModContent.ItemType<SandTooth>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Giant Clam",
                    new List<int> { ModContent.ItemType<ClamMask>(), ModContent.ItemType<ClamHermitMedallion>() });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Crabulon",
                    new List<int> { ModContent.ItemType<ClawShroom>() });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Hive Mind",
                    new List<int> { ModContent.ItemType<MissingFang>() });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "The Perforators",
                    new List<int> { ModContent.ItemType<DigestedWormFood>() });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Slime God",
                    new List<int>
                    {
                        ModLoader.GetMod("CalamityMod").ItemType("StatigelBlock"), ModContent.ItemType<ImpureStick>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Cryogen",
                    new List<int> { ModContent.ItemType<CryoStick>() });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Aquatic Scourge",
                    new List<int> { ModContent.ItemType<AquaticHide>() });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Brimstone Elemental",
                    new List<int>
                    {
                        ModLoader.GetMod("CalamityMod").ItemType("BrimstoneSlag"), ModContent.ItemType<BrimmyBody>(),
                        ModContent.ItemType<BrimmySpirit>(), ModContent.ItemType<FoilSpoon>(),
                        ModContent.ItemType<brimtulip>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Calamitas",
                    new List<int> { ModContent.ItemType<Calacirclet>(), ModContent.ItemType<AncientAuricTeslaHelm>() });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Leviathan",
                    new List<int>
                    {
                        ModContent.ItemType<LeviWings>(), ModContent.ItemType<FoilAtlantis>(),
                        ModContent.ItemType<WetBubble>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Astrum Aureus",
                    new List<int>
                    {
                        ModContent.ItemType<AureusShield>(), ModContent.ItemType<AstDie>(),
                        ModContent.ItemType<JellyBottle>(), ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Plaguebringer Goliath",
                    new List<int>
                    {
                        ModLoader.GetMod("CalamityMod").ItemType("PlaguedPlate"), ModContent.ItemType<PlaguePack>(),
                        ModContent.ItemType<InfectedController>(), ModContent.ItemType<PlagueHiveWand>(),
                        ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Ravager",
                    new List<int>
                    {
                        ModContent.ItemType<Necrostone>(), ModContent.ItemType<SkullBalloon>(),
                        ModContent.ItemType<RavaHook>(), ModContent.ItemType<ScavaHook>(),
                        ModContent.ItemType<AncientChoker>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Astrum Deus",
                    new List<int> { ModContent.ItemType<AstBandana>(), ModContent.ItemType<AstralStar>() });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Profaned Guardians",
                    new List<int>
                    {
                        ModContent.ItemType<ProfanedFrame>(), ModContent.ItemType<ProfanedBattery>(),
                        ModContent.ItemType<ProfanedWheels>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Dragonfolly",
                    new List<int>
                    {
                        ModLoader.GetMod("CalamityMod").ItemType("SilvaCrystal"), ModContent.ItemType<FollyWings>(),
                        ModContent.ItemType<Birbhat>(), ModContent.ItemType<FollyWing>(),
                        ModContent.ItemType<OrbSummon>(), ModContent.ItemType<FluffyFeather>(),
                        ModContent.ItemType<SparrowMeat>(), ModContent.ItemType<FluffyFur>(),
                        ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Providence",
                    new List<int>
                    {
                        ModLoader.GetMod("CalamityMod").ItemType("ProfanedRock"), ModContent.ItemType<ProviCrystal>(),
                        ModContent.ItemType<ProShard>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Ceaseless Void",
                    new List<int>
                    {
                        ModLoader.GetMod("CalamityMod").ItemType("OccultStone"), ModContent.ItemType<VoidWings>(),
                        ModContent.ItemType<OldVoidWings>(), ModContent.ItemType<VoidShard>(),
                        ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Storm Weaver",
                    new List<int>
                    {
                        ModLoader.GetMod("CalamityMod").ItemType("OccultStone"), ModContent.ItemType<StormBandana>(),
                        ModContent.ItemType<ShellScrap>(), ModContent.ItemType<WeaverFlesh>(),
                        ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Signus",
                    new List<int>
                    {
                        ModLoader.GetMod("CalamityMod").ItemType("OccultStone"), ModContent.ItemType<SignusEmblem>(),
                        ModContent.ItemType<SigCape>(), ModContent.ItemType<SignusNether>(),
                        ModContent.ItemType<SigCloth>(), ModContent.ItemType<JunkoHat>(),
                        ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Polterghast",
                    new List<int>
                    {
                        ModLoader.GetMod("CalamityMod").ItemType("StratusBricks"),
                        ModContent.ItemType<PhantowaxBlock>(), ModContent.ItemType<Polterhook>(),
                        ModContent.ItemType<ToyScythe>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Old Duke",
                    new List<int>
                    {
                        ModContent.ItemType<OldWings>(), ModContent.ItemType<CorrodedCleaver>(),
                        ModContent.ItemType<CharredChopper>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Devourer of Gods",
                    new List<int>
                    {
                        ModContent.ItemType<CosmicWormScarf>(), ModContent.ItemType<RapturedWormScarf>(),
                        ModContent.ItemType<DogPetItem>(), ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Yharon",
                    new List<int>
                    {
                        ModContent.ItemType<Termipebbles>(), ModContent.ItemType<JunglePhoenixWings>(),
                        ModContent.ItemType<YharonShackle>(), ModContent.ItemType<NuggetBiscuit>(),
                        ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Supreme Calamitas",
                    new List<int> { ModContent.ItemType<AncientAuricTeslaHelm>() });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Acid Rain (Post-AS)",
                    new List<int>
                    {
                        ModContent.ItemType<MawHook>(), ModContent.ItemType<FlakHeadCrab>(),
                        ModContent.ItemType<SkaterEgg>(), ModContent.ItemType<Help>(),
                        ModContent.ItemType<TrilobiteShield>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Acid Rain (Post-Polter)",
                    new List<int>
                    {
                        ModContent.ItemType<MawHook>(), ModContent.ItemType<FlakHeadCrab>(),
                        ModContent.ItemType<SkaterEgg>(), ModContent.ItemType<Help>(),
                        ModContent.ItemType<TrilobiteShield>(), ModContent.ItemType<NuclearFumes>(),
                        ModContent.ItemType<GammaHelmet>()
                    });
            }
        }

        public static void MountNerf(Player player, float reduceDamageBy, float reduceHealthBy)
        {
            bool bossIsAlive = false;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && npc.boss)
                {
                    bossIsAlive = true;
                }
            }

            if (bossIsAlive && !CalValEXConfig.Instance.GroundMountLol)
            {
                int calculateLife = (int) (player.statLifeMax2 * reduceHealthBy);
                player.statLifeMax2 -= calculateLife;
                player.allDamage -= reduceDamageBy;
            }
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            MessageType msgType = (MessageType) reader.ReadByte();
            byte playerNumber;
            OraclePlayer oraclePlayer;
            CalValEXPlayer calValEXPlayer;
            int SCalHits;
            switch (msgType)
            {
                case MessageType.SyncOraclePlayer:
                    playerNumber = reader.ReadByte();
                    oraclePlayer = Main.player[playerNumber].GetModPlayer<OraclePlayer>();
                    oraclePlayer.playerHasGottenBag = reader.ReadBoolean();
                    break;

                case MessageType.PlayerBagChanged:
                    playerNumber = reader.ReadByte();
                    oraclePlayer = Main.player[playerNumber].GetModPlayer<OraclePlayer>();
                    oraclePlayer.playerHasGottenBag = reader.ReadBoolean();
                    if (Main.netMode == NetmodeID.Server)
                    {
                        var packet = GetPacket();
                        packet.Write((byte) MessageType.PlayerBagChanged);
                        packet.Write(playerNumber);
                        packet.Write(oraclePlayer.playerHasGottenBag);
                        packet.Send(-1, playerNumber);
                    }

                    break;

                case MessageType.SyncCalValEXPlayer:
                    playerNumber = reader.ReadByte();
                    calValEXPlayer = Main.player[playerNumber].GetModPlayer<CalValEXPlayer>();
                    SCalHits = reader.ReadInt32();
                    calValEXPlayer.SCalHits = SCalHits;
                    break;

                case MessageType.SyncSCalHits:
                    playerNumber = reader.ReadByte();
                    calValEXPlayer = Main.player[playerNumber].GetModPlayer<CalValEXPlayer>();
                    SCalHits = reader.ReadInt32();
                    calValEXPlayer.SCalHits = SCalHits;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        var packet = GetPacket();
                        packet.Write((byte) MessageType.SyncSCalHits);
                        packet.Write(playerNumber);
                        packet.Write(calValEXPlayer.SCalHits);
                        packet.Send(-1, playerNumber);
                    }

                    break;

                default:
                    Logger.WarnFormat("CalValEX: Unknown Message type: {0}", msgType);
                    break;
            }
        }

        public override void AddRecipeGroups()
        {
            if (RecipeGroup.recipeGroupIDs.ContainsKey("WingsGroup"))
            {
                int index = RecipeGroup.recipeGroupIDs["WingsGroup"];
                RecipeGroup group = RecipeGroup.recipeGroups[index];
                group.ValidItems.Add(ModContent.ItemType<AeroWings>()); //modded item
                group.ValidItems.Add(ModContent.ItemType<GodspeedBoosters>());
                group.ValidItems.Add(ModContent.ItemType<FollyWings>());
                group.ValidItems.Add(ModContent.ItemType<JunglePhoenixWings>());
                group.ValidItems.Add(ModContent.ItemType<LeviWings>());
                group.ValidItems.Add(ModContent.ItemType<OldVoidWings>());
                group.ValidItems.Add(ModContent.ItemType<VoidWings>());
                group.ValidItems.Add(ModContent.ItemType<PlaugeWings>());
                group.ValidItems.Add(ModContent.ItemType<ScryllianWings>());
                group.ValidItems.Add(ModContent.ItemType<TerminalWings>());
            }
        }

        public override void AddRecipes()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            //Wulfrum
            ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(calamityMod.ItemType("EnergyCore"), 50);
            recipe.AddIngredient(ItemID.SlimeBanner);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(calamityMod.ItemType("WulfrumSlimeBanner"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(calamityMod.ItemType("EnergyCore"), 50);
            recipe.AddIngredient(ItemID.SlimeBanner);
            recipe.AddTile(calamityMod.TileType("StaticRefiner"));
            recipe.SetResult(calamityMod.ItemType("WulfrumSlimeBanner"));
            recipe.AddRecipe();
            //Irradiated
            recipe = new ModRecipe(this);
            recipe.AddIngredient(calamityMod.ItemType("GammaSlimeBanner"));
            recipe.AddIngredient(ModContent.ItemType<NuclearFumes>(), 50);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(calamityMod.ItemType("IrradiatedSlimeBanner"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(calamityMod.ItemType("GammaSlimeBanner"));
            recipe.AddIngredient(ModContent.ItemType<NuclearFumes>(), 50);
            recipe.AddTile(calamityMod.TileType("StaticRefiner"));
            recipe.SetResult(calamityMod.ItemType("IrradiatedSlimeBanner"));
            recipe.AddRecipe();
            //Bloodstone wall to Bloodstone
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<BloodstoneWall>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(calamityMod.ItemType("Bloodstone"));
            recipe.AddRecipe();
            //Astral blocks
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<AstralTreeWood>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("AstralMonolith"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<AstralSand>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("AstralSand"));
            recipe.AddRecipe();
            recipe.AddIngredient(ModContent.ItemType<AstralSandstone>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("AstralSandstone"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<AstralClay>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("AstralClay"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<Xenostone>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("AstralStone"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<AstralDirt>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("AstralDirt"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<AstralHardenedSand>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("HardenedAstralSand"));
            recipe.AddRecipe();
            //Astral Furniture
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<OldAstralBathtubItem>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("MonolithBathtub"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<OldAstralBedItem>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("MonolithBed"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<OldAstralCandelabraItem>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("MonolithCandelabra"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<OldAstralCandleItem>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("MonolithCandle"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<OldAstralLanternItem>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("MonolithLantern"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<OldAstralLampItem>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("MonolithLamp"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<OldAstralClockItem>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("MonolithClock"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<OldAstralSofaItem>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("MonolithBench"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<OldAstralSinkItem>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("MonolithSink"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<OldAstralTableItem>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("MonolithTable"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<OldAstralWorkbenchItem>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("MonolithWorkBench"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<OldAstralDoorItem>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("MonolithDoor"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<OldAstralBookshelfItem>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("MonolithBookcase"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<OldAstralChestItem>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("MonolithChest"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<OldAstralChandelierItem>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("MonolithChandelier"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<OldAstralPianoItem>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("MonolithPiano"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<OldAstralDresserItem>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("MonolithDresser"));
            recipe.AddRecipe();
        }
    }
}