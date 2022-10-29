using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;
using CalValEX.Tiles.AstralBlocks;
using CalamityMod.Tiles.DraedonStructures;
using CalamityMod.Tiles.Astral;
using CalamityMod.Tiles.AstralDesert;
using CalamityMod.Tiles.AstralSnow;
using System.IO;
using System;
using CalamityMod.Items.Materials;
using CalValEX.AprilFools;
using CalValEX.Tiles.Plants;

namespace CalValEX
{
    public class CalValEXWorld : ModSystem
    {
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
        public static bool nugget = false;
        public static bool draco = false;
        public static bool folly = false;
        public static bool godnug = false;
        public static bool mammoth = false;
        public static bool shadow = false;

        public static bool AnyChickensAround() {
            return !(nugget && draco && folly && godnug && mammoth && shadow);
        }

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
        }

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
            writer.Write(flags);
            writer.Write(flags2);
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
        }

        public override void ResetNearbyTileEffects()
        {
            astralTiles = 0;
            hellTiles = 0;
            labTiles = 0;
            dungeontiles = 0;
        }
        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            // Old Astral tiles
            astralTiles = tileCounts[TileType<AstralDirtPlaced>()] + tileCounts[TileType<AstralGrassPlaced>()] + tileCounts[TileType<XenostonePlaced>()] + tileCounts[TileType<AstralSandPlaced>()] + tileCounts[TileType<AstralHardenedSandPlaced>()] + tileCounts[TileType<AstralSandstonePlaced>()] + tileCounts[TileType<AstralClayPlaced>()] + tileCounts[TileType<AstralIcePlaced>()] + tileCounts[TileType<AstralSnowPlaced>()];
            // Hell Lab tiles
            hellTiles = tileCounts[TileType<CalamityMod.Tiles.Plates.Chaosplate>()];
            // Lab tiles
            labTiles = tileCounts[TileType<LaboratoryPlating>()] + tileCounts[TileType < LaboratoryPanels>()] + tileCounts[TileType < RustedPlating>()] + tileCounts[TileType < LaboratoryPipePlating>()] + tileCounts[TileType < RustedPipes>()];
            //Dungeon tiles
            dungeontiles = tileCounts[TileID.BlueDungeonBrick] + tileCounts[TileID.PinkDungeonBrick] + tileCounts[TileID.GreenDungeonBrick];
        }

        public override void PreUpdateNPCs()
        {
            if (CalamityMod.World.CalamityWorld.revenge || Main.masterMode)
            {
                masorev = true;
            }
            else
            {
                masorev = false;
            }
            if (Main.drunkWorld)
            {
                CalValEX.AprilFoolDay = true;
                CalValEX.AprilFoolWeek = true;
                CalValEX.AprilFoolMonth = true;
            }
        }

        public static void UpdateWorldBool()
        {
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.WorldData);
            }
        }
    }
}