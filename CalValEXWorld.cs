using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;
using CalValEX.Tiles.AstralBlocks;
using CalValEX.Items.Equips.Wings;
using CalValEX.Items.Pets;
using CalValEX.Items.Tiles;
using CalValEX.Items.Plushies;
using CalValEX.Items.Tiles.Plushies;
using System.IO;
using System;
using CalValEX.AprilFools;
using CalValEX.Tiles.Plants;
using CalValEX.NPCs.TownPets.Nuggets;
using Terraria.Chat;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.VisualBasic;

namespace CalValEX
{
    public class CalValEXWorld : ModSystem {
        public static bool CanNugsSpawn() {
            return !(nugget || draco || folly || godnug || mammoth || shadow);
        }

        public static int astralTiles;
        public static int hellTiles;
        public static int labTiles;
        public static int dungeontiles;
        public static bool rescuedjelly;
        public static bool jharim;
        public static bool orthofound;
        public static bool amogus;
        public static bool OneMonolith;
        public static bool TwoMonolith;
        public static bool Rockshrine;
        public static bool RockshrinEX;
        public static bool jharinter;
        public static bool downedMeldosaurus;
        public static bool masorev;

        // Chickens
        public static bool nugget;
        public static bool draco;
        public static bool folly;
        public static bool godnug;
        public static bool mammoth;
        public static bool shadow;
        private int nugCounter = 1;
        public static bool isThereAHouse;

        public override void OnWorldLoad()
        { 
            rescuedjelly = false;
            jharim = false;
            amogus = false;
            orthofound = false;
            Rockshrine = false;
            RockshrinEX = false;
            jharinter = false;
            downedMeldosaurus = false;

            nugget = draco = folly = godnug = mammoth = shadow = isThereAHouse = false;
        }

        public override void OnWorldUnload()
        {
            rescuedjelly = false;
            jharim = false;
            amogus = false;
            orthofound = false;
            Rockshrine = false;
            RockshrinEX = false;
            jharinter = false;
            downedMeldosaurus = false;

            nugget = draco = folly = godnug = mammoth = shadow = isThereAHouse = false;
        }

        #region //Flags
        public override void SaveWorldData(TagCompound tag) {
            if (rescuedjelly)
                tag["rescuedjelly"] = true;

            if (jharim)
                tag["jharim"] = true;

            if (orthofound)
                tag["orthofound"] = true;

            if (amogus)
                tag["amogus"] = true;

            if (Rockshrine)
                tag["Rockshrine"] = true;

            if (RockshrinEX)
                tag["RockshrinEX"] = true;

            if (jharinter)
                tag["jharinter"] = true;

            if (downedMeldosaurus)
                tag["downedMeldosaurus"] = true;

            // Chickens
            if (nugget)
                tag["nugget"] = true;
            if (draco)
                tag["draco"] = true;
            if (folly)
                tag["folly"] = true;
            if (godnug)
                tag["godnug"] = true;
            if (mammoth)
                tag["mammoth"] = true;
            if (shadow)
                tag["shadow"] = true;
        }

        public override void LoadWorldData(TagCompound tag) {
            rescuedjelly = tag.ContainsKey("rescuedjelly");
            jharim = tag.ContainsKey("jharim");
            orthofound = tag.ContainsKey("orthofound");
            amogus = tag.ContainsKey("amogus");
            Rockshrine = tag.ContainsKey("Rockshrine");
            RockshrinEX = tag.ContainsKey("RockshrinEX");
            jharinter = tag.ContainsKey("jharinter");
            downedMeldosaurus = tag.ContainsKey("downedMeldosaurus");

            nugget = tag.ContainsKey("nugget");
            draco = tag.ContainsKey("draco");
            folly = tag.ContainsKey("folly");
            godnug = tag.ContainsKey("godnug");
            mammoth = tag.ContainsKey("mammoth");
            shadow = tag.ContainsKey("shadow");
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = rescuedjelly;
            flags[1] = jharim;
            flags[2] = orthofound;
            flags[3] = amogus;
            flags[4] = Rockshrine;
            flags[5] = RockshrinEX;
            flags[6] = jharinter;

            BitsByte flags2 = new BitsByte();
            flags2[0] = downedMeldosaurus;

            BitsByte flags3 = new BitsByte();
            flags3[0] = nugget;
            flags3[1] = draco;
            flags3[2] = folly;
            flags3[3] = godnug;
            flags3[4] = mammoth;
            flags3[5] = shadow;

            writer.Write(flags);
            writer.Write(flags2);
            writer.Write(flags3);
        }
        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            rescuedjelly = flags[0];
            jharim = flags[1];
            orthofound = flags[2];
            amogus = flags[3];
            Rockshrine = flags[4];
            RockshrinEX = flags[5];
            jharinter = flags[6];

            BitsByte flags2 = reader.ReadByte();
            downedMeldosaurus = flags2[0];

            BitsByte flags3 = reader.ReadByte();
            nugget = flags3[0];
            draco = flags3[1];
            folly = flags3[2];
            godnug  = flags3[3];
            mammoth = flags3[4];
            shadow = flags3[5];
        }
        #endregion

        #region //Tiles
        public override void ResetNearbyTileEffects()
        {
            astralTiles = 0;
            hellTiles = 0;
            labTiles = 0;
            dungeontiles = 0;
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            // Old Astral tiles
            astralTiles = tileCounts[TileType<AstralDirtPlaced>()] + tileCounts[TileType<AstralGrassPlaced>()] + tileCounts[TileType<XenostonePlaced>()] + tileCounts[TileType<AstralSandPlaced>()] + tileCounts[TileType<AstralHardenedSandPlaced>()] + tileCounts[TileType<AstralSandstonePlaced>()] + tileCounts[TileType<AstralClayPlaced>()] + tileCounts[TileType<AstralIcePlaced>()] + tileCounts[TileType<AstralSnowPlaced>()];
            if (CalValEX.CalamityActive)
            {
                // Hell Lab tiles
                hellTiles = tileCounts[CalValEX.CalamityTile("Chaosplate")];
                // Lab tiles
                labTiles = tileCounts[CalValEX.CalamityTile("LaboratoryPlating")] + tileCounts[CalValEX.CalamityTile("LaboratoryPanels")] + tileCounts[CalValEX.CalamityTile("RustedPlating")] + tileCounts[CalValEX.CalamityTile("LaboratoryPipePlating")] + tileCounts[CalValEX.CalamityTile("RustedPipes")];
            }
            //Dungeon tiles
            dungeontiles = tileCounts[TileID.BlueDungeonBrick] + tileCounts[TileID.PinkDungeonBrick] + tileCounts[TileID.GreenDungeonBrick];
        }
        #endregion

        [JITWhenModsEnabled("CalamityMod")]
        public override void PreUpdateNPCs()
        {
            /*if (CalValEX.CalamityActive)
            {
                if (CalamityMod.World.CalamityWorld.revenge || Main.masterMode)
                {
                    masorev = true;
                }
                else
                {
                    masorev = false;
                }
            }
            else
            {
                masorev = false;
            }*/
            if (Main.drunkWorld)
            {
                CalValEX.AprilFoolDay = true;
                CalValEX.AprilFoolWeek = true;
                CalValEX.AprilFoolMonth = true;
            }

            // Call the spawning method
            if (nugget)
                SpawnBitches<NuggetNugget>(nugget);
            if (draco)
                SpawnBitches<DracoNugget>(draco);
            if (folly)
                SpawnBitches<FollyNugget>(folly);
            if (godnug)
                SpawnBitches<GODNugget>(godnug);
            if (mammoth)
                SpawnBitches<MammothNugget>(mammoth);
            if (shadow)
                SpawnBitches<ShadowNugget>(shadow);
        }

        // We use a generic method here so we can pass the ModNPC type as a paremeter, basically saving me from having to wrie this shit 6 times
        public void SpawnBitches<T>(bool nugSpawn) where T : ModNPC {
            Player player = Main.LocalPlayer;

            // Random delay between death/reroll and spawn, measured in frames divided by 100
            var maxCount = Main.rand.Next(9, 108);
            
            nugCounter++;
            // Multiplied by 100 so there's not as many numbers to choose from, it's still a lot but it's better than 900-10800
            if (nugCounter > (maxCount * 100))
                nugCounter = 0;

            if (CanSpawnNow() && !NPC.AnyNPCs(NPCType<T>()) && nugSpawn && isThereAHouse && nugCounter == 0) {
                // We spawn the nug near the player facing them
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    int newNug = NPC.NewNPC(Entity.GetSource_TownSpawn(), (int)(player.position.X + (96 * Main.LocalPlayer.direction)), (int)(player.position.Y - 16), NPCType<T>(), 1);
                    NPC nug = Main.npc[newNug];
                    nug.direction = -Main.LocalPlayer.direction;
                    nug.netUpdate = true;

                    if (nug.position.X < 10 || nug.position.X > Main.maxTilesX - 10)
                    {
                        nug.position.X = player.position.X;
                    }

                    if (Main.netMode == NetmodeID.SinglePlayer)
                        Main.NewText(Language.GetTextValue(nug.FullName + " has risen from") + ($" {Main.worldName}'s ashes!"), 50, 125, 255);
                    else
                        ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(Language.GetTextValue(nug.FullName + "has risen from") + $" {Main.worldName}'s ashes!"), new Color(50, 125, 255));
                }
            }
        }

        public static void UpdateWorldBool() {
            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.WorldData);
        }

        private static bool CanSpawnNow() {
            if (Main.eclipse || Main.invasionType > 0 && Main.invasionDelay == 0 && Main.invasionSize > 0)
                return false;

            if (Main.fastForwardTime)
                return false;

            return Main.dayTime;
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void AddRecipeGroups()/* tModPorter Note: Removed. Use ModSystem.AddRecipeGroups */
        {
            if (CalValEX.CalamityActive)
            {
                RecipeGroup sand = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["Sand"]];
                sand.ValidItems.Add(ModContent.ItemType<Items.Tiles.Blocks.Astral.AstralSand>());
                RecipeGroup fieref = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["Fireflies"]];
                fieref.ValidItems.Add(ModContent.ItemType<Items.Critters.VaporoflyItem>());
                fieref.ValidItems.Add(ModContent.ItemType<Items.Critters.BlinkerItem>());
                RecipeGroup bf = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["Butterflies"]];
                bf.ValidItems.Add(ModContent.ItemType<Items.Critters.ProvFlyItem>());
                bf.ValidItems.Add(ModContent.ItemType<Items.Critters.CrystalFlyItem>());
                if (RecipeGroup.recipeGroupIDs.ContainsKey("WingsGroup"))
                {
                    int index = RecipeGroup.recipeGroupIDs["WingsGroup"];
                    RecipeGroup groupe = RecipeGroup.recipeGroups[index];
                    groupe.ValidItems.Add(ModContent.ItemType<WulfrumHelipack>());
                    groupe.ValidItems.Add(ModContent.ItemType<AeroWings>());
                    groupe.ValidItems.Add(ModContent.ItemType<GodspeedBoosters>());
                    groupe.ValidItems.Add(ModContent.ItemType<FollyWings>());
                    groupe.ValidItems.Add(ModContent.ItemType<JunglePhoenixWings>());
                    groupe.ValidItems.Add(ModContent.ItemType<LeviWings>());
                    groupe.ValidItems.Add(ModContent.ItemType<OldVoidWings>());
                    groupe.ValidItems.Add(ModContent.ItemType<VoidWings>());
                    groupe.ValidItems.Add(ModContent.ItemType<PlaugeWings>());
                    groupe.ValidItems.Add(ModContent.ItemType<ScryllianWings>());
                    groupe.ValidItems.Add(ModContent.ItemType<TerminalWings>());
                }
                if (RecipeGroup.recipeGroupIDs.ContainsKey("AnyIceBlock"))
                {
                    int index = RecipeGroup.recipeGroupIDs["AnyIceBlock"];
                    RecipeGroup groupe = RecipeGroup.recipeGroups[index];
                    groupe.ValidItems.Add(ModContent.ItemType<Items.Tiles.Blocks.Astral.AstralIce>());
                }
                RecipeGroup group = new RecipeGroup(() => "Any Plate", new int[]
                {
                CalValEX.CalamityItem("Plagueplate"),
                CalValEX.CalamityItem("Cinderplate"),
                CalValEX.CalamityItem("Chaosplate"),
                CalValEX.CalamityItem("Navyplate"),
                CalValEX.CalamityItem("Elumplate")
                });
                RecipeGroup.RegisterGroup("AnyPlate", group);

                /*RecipeGroup group2 = new RecipeGroup(() => "Any Hardmode Drill", new int[]
                {
                    ItemID.CobaltDrill,
                    ItemID.PalladiumDrill,
                    ItemID.MythrilDrill,
                    ItemID.OrichalcumDrill,
                    ItemID.AdamantiteDrill,
                    ItemID.TitaniumDrill,
                });
                RecipeGroup.RegisterGroup("AnyHardmodeDrill", group2);*/
            }
        }
        public override void AddRecipes()/* tModPorter Note: Removed. Use ModSystem.AddRecipes */
        {
            if (CalValEX.instance.cata != null)
            {
                CalValEX.instance.cata.Call("itemset_superbossrarity", ModContent.ItemType<AstrageldonPlush>(), true);
                CalValEX.instance.cata.Call("itemset_superbossrarity", ModContent.ItemType<AstrageldonPlushThrowable>(), true);
                CalValEX.instance.cata.Call("itemset_superbossrarity", ModContent.ItemType<SpaceJunk>(), true);
                CalValEX.instance.cata.Call("itemset_superbossrarity", ModContent.ItemType<JaredPlush>(), true);
                CalValEX.instance.cata.Call("itemset_superbossrarity", ModContent.ItemType<JaredPlushThrowable>(), true);
                CalValEX.instance.cata.Call("itemset_superbossrarity", ModContent.ItemType<RespirationShrine>(), true);
                CalValEX.instance.cata.Call("itemset_superbossrarity", ModContent.ItemType<SoulShard>(), true);
            }
        }

        public override void PostAddRecipes()/* tModPorter Note: Removed. Use ModSystem.PostAddRecipes */
        {
            CalValEX.instance.SetupHerosMod();
        }
    }
}