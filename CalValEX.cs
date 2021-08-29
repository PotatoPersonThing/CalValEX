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
using CalValEX.Items.Equips.Transformations;
using CalValEX.Items.Equips.Wings;
using CalValEX.Items.Equips.Blanks;
using CalValEX.Items.Hooks;
using CalValEX.Items.LightPets;
using CalValEX.Items.Mounts;
using CalValEX.Walls;
using CalValEX.Items.Walls.Astral;
using CalValEX.Items.Walls;
using CalValEX.Items.Pets;
using CalValEX.Items.Pets.Elementals;
using CalValEX.Items.Tiles;
using CalValEX.Items.Tiles.Blocks;
using CalValEX.Items.Tiles.FurnitureSets.Bloodstone;
using CalValEX.NPCs.Oracle;
using CalValEX.NPCs.JellyPriest;
using CalValEX.Items.Tiles.Blocks.Astral;
using CalValEX.Tiles.MiscFurniture;
using CalValEX.Items.Tiles.FurnitureSets.Astral;
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

        public static CalValEX instance;
        public Mod herosmod;
        public const string heropermission = "CalValEX";
        public const string heropermissiondisplayname = "Calamity's Vanities";
        public bool hasPermission;

        public static bool Bumble;
        public static bool Wulfrumset;
        public static bool WulfrumsetReal;
        public static string currentDate;
        public static int day;
        public static int month;

        public static MethodInfo compactFraming;

        public override void Load()
        {
            instance = this;
            herosmod = ModLoader.GetMod("HEROsMod");

            DateTime dateTime = DateTime.Now;
            currentDate = dateTime.ToString("dd/MM/yyyy");
            day = dateTime.Day;
            month = dateTime.Month;

            if (Main.dedServ)
                return;
            //Signus transformation
            AddEquipTexture(new SignusHead(), null, EquipType.Head, "SignusHead", "CalValEX/Items/Equips/Transformations/SignusTrans_Head");
            AddEquipTexture(new SignusBody(), null, EquipType.Body, "SignusBody", "CalValEX/Items/Equips/Transformations/SignusTrans_Body", "CalValEX/Items/Equips/Transformations/SignusTrans_Arms");
            AddEquipTexture(new SignusLegs(), null, EquipType.Legs, "SignusLegs", "CalValEX/Items/Equips/Transformations/SignusTrans_Legs");
            //TinyIbanRobotofDoom
            AddEquipTexture(new TinyIbanRobotOfDoomHead(), null, EquipType.Head, "TinyIbanRobotOfDoomHead", "CalValEX/Items/Equips/Transformations/TinyIbanRobotOfDoom_Head");
            AddEquipTexture(new TinyIbanRobotOfDoomBody(), null, EquipType.Body, "TinyIbanRobotOfDoomBody", "CalValEX/Items/Equips/Transformations/TinyIbanRobotOfDoom_Body", "CalValEX/Items/Equips/Transformations/TinyIbanRobotOfDoom_Arms");
            AddEquipTexture(new TinyIbanRobotOfDoomLegs(), null, EquipType.Legs, "TinyIbanRobotOfDoomLegs", "CalValEX/Items/Equips/Transformations/TinyIbanRobotOfDoom_Legs");
            //Classic Brimmy
            AddEquipTexture(new ClassicBrimmyHead(), null, EquipType.Head, "ClassicBrimmyHead", "CalValEX/Items/Equips/Transformations/ClassicBrimmy_Head");
            AddEquipTexture(new ClassicBrimmyBody(), null, EquipType.Body, "ClassicBrimmyBody", "CalValEX/Items/Equips/Transformations/ClassicBrimmy_Body", "CalValEX/Items/Equips/Transformations/ClassicBrimmy_Arms");
            AddEquipTexture(new ClassicBrimmyLegs(), null, EquipType.Legs, "ClassicBrimmyLegs", "CalValEX/Items/Equips/Transformations/ClassicBrimmy_Legs");
            //Cloud transformation
            AddEquipTexture(new CloudHead(), null, EquipType.Head, "CloudHead", "CalValEX/Items/Equips/Transformations/Cloud_Head");
            AddEquipTexture(new CloudBody(), null, EquipType.Body, "CloudBody", "CalValEX/Items/Equips/Transformations/Cloud_Body", "CalValEX/Items/Equips/Transformations/Cloud_Arms");
            AddEquipTexture(new CloudLegs(), null, EquipType.Legs, "CloudLegs", "CalValEX/Items/Equips/Transformations/Cloud_Legs");
            //Sand transformation
            AddEquipTexture(new SandHead(), null, EquipType.Head, "SandHead", "CalValEX/Items/Equips/Transformations/Sand_Head");
            AddEquipTexture(new SandBody(), null, EquipType.Body, "SandBody", "CalValEX/Items/Equips/Transformations/Sand_Body", "CalValEX/Items/Equips/Transformations/Sand_Arms");
            AddEquipTexture(new SandLegs(), null, EquipType.Legs, "SandLegs", "CalValEX/Items/Equips/Transformations/Sand_Legs");
            //Blanks
            AddEquipTexture(new BlankWings(), null, EquipType.Wings, "BlankWings", "CalValEX/Items/Equips/Shields/Invishield_Shield");

            GameShaders.Armor.BindShader(ModContent.ItemType<DraedonHologramDye>(),
                new ArmorShaderData(new Ref<Effect>(GetEffect("Effects/DraedonHologramDye")),
                    "DraedonHologramDyePass"));

            DraedonHelmetTextureCache.Load();
            DraedonChestplateCache.Load();

            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/AstralBlight"), ItemType("AstralMusicBox"), TileType("AstralMusicBoxPlaced"));
        }

        public override void Unload()
        {
            instance = null;
            herosmod = null;
            hasPermission = false;

            currentDate = null;
            Bumble = false;
            Wulfrumset = false;
            day = -1;
            month = -1;
            compactFraming = null;

            if (Main.dedServ)
                return;

            //ChristmasTextureChange.Unload();
            DraedonHelmetTextureCache.Unload();
            DraedonChestplateCache.Unload();
        }
        public override void PostSetupContent()
        {
            //Tooltip changes
            Mod cal = ModLoader.GetMod("CalamityMod");
            cal.GetItem("KnowledgeCrabulon").Tooltip.AddTranslation(GameCulture.English,
                "A crab and its mushrooms, a love story.\nIt's interesting how creatures can adapt given certain circumstances.\nFavorite this item to gain the Mushy buff while underground or in the mushroom biome.\nHowever, your movement speed will be decreased while in these areas due to you being covered in fungi.\nThe great crustacean's mushrooms may also grow angry when attacked, though they will also become harmless.");
            cal.GetItem("LaboratoryConsoleItem").Tooltip
                .AddTranslation(GameCulture.English, "Can be used to print blueprints");
            cal.GetItem("HeartoftheElements").Tooltip.AddTranslation(GameCulture.English, "The heart of the world\n" +
                "Increases max life by 20, life regen by 1, and all damage by 5%\n" +
                "Increases movement speed by 10% and jump speed by 20%\n" +
                "Increases damage reduction by 5%\n" +
                "Increases max mana by 50 and reduces mana usage by 5%\n" +
                "You grow flowers on the grass beneath you, chance to grow very random dye plants on grassless dirt\n" +
                "Summons all elementals to protect you\n" +
                "Toggling the visibility of this accessory also toggles the elementals on and off\n" +
                "Stat increases are slightly higher if the elementals are turned off\n" + "Equipping this item in a vanity slot summons passive versions of the Elementals");

            //Census support
            Mod censusMod = ModLoader.GetMod("Census");
            if (censusMod != null)
            {
                censusMod.Call("TownNPCCondition", ModContent.NPCType<OracleNPC>(), "Equip a Pet or Light Pet");
                censusMod.Call("TownNPCCondition", ModContent.NPCType<JellyPriestNPC>(),
                    "Find at the Sulphurous Sea after defeating Acid Rain tier 1 or defeat Acid Rain tier 2");
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
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Desert Scourge",
                    new List<int>
                    {
                        ModContent.ItemType<DesertMedallion>(), ModContent.ItemType<DriedMandible>(),
                        ModContent.ItemType<SandTooth>()
                    });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Giant Clam",
                    new List<int> { ModContent.ItemType<ClamMask>(), ModContent.ItemType<ClamHermitMedallion>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Crabulon",
                    new List<int> { ModContent.ItemType<ClawShroom>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Hive Mind",
                    new List<int> { ModContent.ItemType<MissingFang>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "The Perforators",
                    new List<int> { ModContent.ItemType<DigestedWormFood>() });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Slime God",
                    new List<int> { ModLoader.GetMod("CalamityMod").ItemType("StatigelBlock") });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Slime God",
                    new List<int> { ModContent.ItemType<ImpureStick>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Cryogen",
                    new List<int> { ModContent.ItemType<CryoStick>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Aquatic Scourge",
                    new List<int> { ModContent.ItemType<AquaticHide>() });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Brimstone Elemental",
                    new List<int> { ModLoader.GetMod("CalamityMod").ItemType("BrimstoneSlag") });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Brimstone Elemental",
                    new List<int>
                    {
                        ModContent.ItemType<BrimmyBody>(),
                        ModContent.ItemType<BrimmySpirit>(), ModContent.ItemType<FoilSpoon>(),
                        ModContent.ItemType<brimtulip>()
                    });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Calamitas",
                    new List<int> { ModContent.ItemType<Calacirclet>(), ModContent.ItemType<AncientAuricTeslaHelm>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Leviathan",
                    new List<int>
                    {
                        ModContent.ItemType<LeviWings>(), ModContent.ItemType<FoilAtlantis>(), ModContent.ItemType<LeviathanEgg>(),
                        ModContent.ItemType<WetBubble>()
                    });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Astrum Aureus",
                    new List<int>
                    {
                        ModContent.ItemType<AureusShield>(), ModContent.ItemType<AstDie>(),
                        ModContent.ItemType<JellyBottle>(), ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Plaguebringer Goliath",
                    new List<int> { ModLoader.GetMod("CalamityMod").ItemType("PlaguedPlate"), ModContent.ItemType<PlagueHiveWand>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Plaguebringer Goliath",
                    new List<int>
                    {
                        ModContent.ItemType<PlaguePack>(),
                        ModContent.ItemType<InfectedController>(), ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Ravager",
                    new List<int> { ModContent.ItemType<Necrostone>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Ravager",
                    new List<int>
                    {
                        ModContent.ItemType<SkullBalloon>(),
                        ModContent.ItemType<RavaHook>(), ModContent.ItemType<ScavaHook>(),
                        ModContent.ItemType<AncientChoker>()
                    });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Astrum Deus",
                    new List<int> { ModContent.ItemType<AstBandana>(), ModContent.ItemType<AstralStar>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Profaned Guardians",
                    new List<int>
                    {
                        ModContent.ItemType<ProfanedFrame>(), ModContent.ItemType<ProfanedBattery>(),
                        ModContent.ItemType<ProfanedWheels>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Dragonfolly",
                    new List<int> { ModLoader.GetMod("CalamityMod").ItemType("SilvaCrystal") });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Dragonfolly",
                    new List<int>
                    {
                        ModContent.ItemType<FollyWings>(),
                        ModContent.ItemType<Birbhat>(), ModContent.ItemType<FollyWing>(),
                        ModContent.ItemType<OrbSummon>(), ModContent.ItemType<FluffyFeather>(),
                        ModContent.ItemType<SparrowMeat>(), ModContent.ItemType<FluffyFur>(),
                        ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Providence",
                    new List<int> { ModLoader.GetMod("CalamityMod").ItemType("ProfanedRock") });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Providence",
                    new List<int>
                    {
                        ModContent.ItemType<ProviCrystal>(),
                        ModContent.ItemType<ProShard>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Ceaseless Void",
                    new List<int> { ModLoader.GetMod("CalamityMod").ItemType("OccultStone") });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Ceaseless Void",
                    new List<int>
                    {
                        ModContent.ItemType<VoidWings>(),
                        ModContent.ItemType<OldVoidWings>(), ModContent.ItemType<VoidShard>(),
                        ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Storm Weaver",
                    new List<int> { ModLoader.GetMod("CalamityMod").ItemType("OccultStone") });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Storm Weaver",
                    new List<int>
                    {
                        ModContent.ItemType<StormBandana>(),
                        ModContent.ItemType<ShellScrap>(), ModContent.ItemType<WeaverFlesh>(),
                        ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Signus",
                    new List<int> { ModLoader.GetMod("CalamityMod").ItemType("OccultStone") });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Signus",
                    new List<int>
                    {
                        ModContent.ItemType<SignusEmblem>(),
                        ModContent.ItemType<SigCape>(), ModContent.ItemType<SignusNether>(),
                        ModContent.ItemType<SigCloth>(), ModContent.ItemType<SignusBalloon>(), ModContent.ItemType<JunkoHat>(),
                        ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Polterghast",
                    new List<int> { ModLoader.GetMod("CalamityMod").ItemType("StratusBricks"), ModContent.ItemType<PhantowaxBlock>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Polterghast",
                    new List<int> { ModContent.ItemType<Polterhook>(), ModContent.ItemType<ToyScythe>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Old Duke",
                    new List<int>
                    {
                        ModContent.ItemType<OldWings>(), ModContent.ItemType<CorrodedCleaver>(),
                        ModContent.ItemType<CharredChopper>()
                    });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Devourer of Gods",
                    new List<int>
                    {
                        ModContent.ItemType<CosmicWormScarf>(), ModContent.ItemType<RapturedWormScarf>(),
                        ModContent.ItemType<DogPetItem>(), ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Yharon",
                    new List<int> { ModContent.ItemType<Termipebbles>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Yharon",
                    new List<int>
                    {
                        ModContent.ItemType<JunglePhoenixWings>(),
                        ModContent.ItemType<YharonShackle>(), ModContent.ItemType<NuggetBiscuit>(), ModContent.ItemType<YharonsAnklet>(),
                        ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Supreme Calamitas",
                    new List<int> { ModContent.ItemType<AncientAuricTeslaHelm>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Acid Rain (Post-AS)",
                    new List<int>
                    {
                        ModContent.ItemType<MawHook>(), ModContent.ItemType<FlakHeadCrab>(),
                        ModContent.ItemType<SkaterEgg>(), ModContent.ItemType<Help>(),
                        ModContent.ItemType<TrilobiteShield>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Acid Rain (Post-Polter)",
                    new List<int> { ModContent.ItemType<NuclearFumes>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Acid Rain (Post-Polter)",
                    new List<int>
                    {
                        ModContent.ItemType<MawHook>(), ModContent.ItemType<FlakHeadCrab>(),
                        ModContent.ItemType<SkaterEgg>(), ModContent.ItemType<Help>(),
                        ModContent.ItemType<TrilobiteShield>(),
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

        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
            {
                return;
            }
            if (Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneAstral)
            {
                music = GetSoundSlot(SoundType.Music, "Sounds/Music/AstralBlight");
                priority = MusicPriority.Environment;
            }

        }

        public override void AddRecipeGroups()
        {
            if (RecipeGroup.recipeGroupIDs.ContainsKey("WingsGroup"))
            {
                int index = RecipeGroup.recipeGroupIDs["WingsGroup"];
                RecipeGroup group = RecipeGroup.recipeGroups[index];
                group.ValidItems.Add(ModContent.ItemType<WulfrumHelipack>());
                group.ValidItems.Add(ModContent.ItemType<AeroWings>());
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
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<AstralIce>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("AstralIce"));
            recipe.AddRecipe();
            //Astral Walls
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<AstralDirtWall>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("AstralDirtWall"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<XenostoneWall>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("AstralStoneWall"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<AstralHardenedSandWall>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("HardenedAstralSandWall"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<AstralSandstoneWall>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("AstralSandstoneWall"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<AstralGrassWall>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("AstralGrassWall"));
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ModContent.ItemType<AstralIceWall>());
            recipe.AddTile(ModContent.TileType<StarstruckSynthesizerPlaced>());
            recipe.SetResult(calamityMod.ItemType("AstralIceWall"));
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

        public void SetupHerosMod()
        {
            if (herosmod != null)
            {
                herosmod.Call(
                    // Special string
                    "AddPermission",
                    // Permission Name
                    heropermission,
                    // Permission Display Name
                    heropermissiondisplayname);
            }
        }

        public override void PostAddRecipes()
        {
            SetupHerosMod();
        }

        public bool getPermission()
        {
            return hasPermission;
        }
    }
}