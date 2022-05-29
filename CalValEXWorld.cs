using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;
using CalValEX.Tiles.AstralBlocks;
using System.IO;

namespace CalValEX
{
    public class CalValEXWorld : ModWorld
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

        public override void Initialize()
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

        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (rescuedjelly)
            {
                downed.Add("rescuedjelly");
            }

            if (jharim)
            {
                downed.Add("jharim");
            }

            if (orthofound)
            {
                downed.Add("orthofound");
            }

            if (amogus)
            {
                downed.Add("amogus");
            }

            if (Rockshrine)
            {
                downed.Add("Rockshrine");
            }

            if (RockshrinEX)
            {
                downed.Add("RockshrinEX");
            }

            if (jharinter)
            {
                downed.Add("jharinter");
            }

            if (downedMeldosaurus)
            {
                downed.Add("downedMeldosaurus");
            }

            return new TagCompound
            {
                {
                    "downed", downed
                }
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            rescuedjelly = downed.Contains("rescuedjelly");
            jharim = downed.Contains("jharim");
            orthofound = downed.Contains("orthofound");
            amogus = downed.Contains("amogus");
            Rockshrine = downed.Contains("Rockshrine");
            RockshrinEX = downed.Contains("RockshrinEX");
            jharinter = downed.Contains("jharinter");
            jharinter = downed.Contains("downedMeldosaurus");
        }
        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            int loadVersion2 = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                rescuedjelly = flags[0];
                jharim = flags[1];
                orthofound = flags[2];
                amogus = flags[3];
                Rockshrine = flags[4];
                RockshrinEX = flags[5];
                jharinter = flags[6];
            }
            if (loadVersion2 == 0)
            {
                BitsByte flags2 = reader.ReadByte();
                downedMeldosaurus = flags2[0];
            }
            else
            {
                ErrorLogger.Log("CalValEX: Unknown loadVersion: " + loadVersion);
                ErrorLogger.Log("CalValEX: Unknown loadVersion: " + loadVersion2);
            }
        }
        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            BitsByte flags2 = new BitsByte();
            flags[0] = rescuedjelly;
            flags[1] = jharim;
            flags[2] = orthofound;
            flags[3] = amogus;
            flags[4] = Rockshrine;
            flags[5] = RockshrinEX;
            flags[6] = jharinter;
            flags2[0] = downedMeldosaurus;
            writer.Write(flags);
        }
        public override void NetReceive(BinaryReader reader)
        {
            if (reader.BaseStream.Length < 1) 
                return;
            BitsByte flags = reader.ReadByte();
            BitsByte flags2 = reader.ReadByte();
            rescuedjelly = flags[0];
            jharim = flags[1];
            orthofound = flags[2];
            amogus = flags[3];
            Rockshrine = flags[4];
            RockshrinEX = flags[5];
            jharinter = flags[6];
            downedMeldosaurus = flags[0];
        }

        public override void ResetNearbyTileEffects()
        {
            astralTiles = 0;
            hellTiles = 0;
            labTiles = 0;
            dungeontiles = 0;
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            // Old Astral tiles
            astralTiles = tileCounts[TileType<AstralDirtPlaced>()] + tileCounts[TileType<AstralGrassPlaced>()] + tileCounts[TileType<XenostonePlaced>()] + tileCounts[TileType<AstralSandPlaced>()] + tileCounts[TileType<AstralHardenedSandPlaced>()] + tileCounts[TileType<AstralSandstonePlaced>()] + tileCounts[TileType<AstralClayPlaced>()] + tileCounts[TileType<AstralIcePlaced>()] + tileCounts[TileType<AstralSnowPlaced>()];
            // Hell Lab tiles
            hellTiles = tileCounts[calamityMod.TileType("Chaosplate")];
            // Lab tiles
            labTiles = tileCounts[calamityMod.TileType("LaboratoryPlating")] + tileCounts[calamityMod.TileType("LaboratoryPanels")] + tileCounts[calamityMod.TileType("RustedPlating")] + tileCounts[calamityMod.TileType("LaboratoryPipePlating")] + tileCounts[calamityMod.TileType("RustedPipes")];
            //Dungeon tiles
            dungeontiles = tileCounts[TileID.BlueDungeonBrick] + tileCounts[TileID.PinkDungeonBrick] + tileCounts[TileID.GreenDungeonBrick];
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
