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

        public static bool rescuedjelly;

        public static bool jharim;

        public static bool orthofound;

        public static bool amogus;

        public static bool OneMonolith;

        public static bool TwoMonolith;

        public override void Initialize()
        {
            rescuedjelly = false;
            jharim = false;
            amogus = false;
            orthofound = false;
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
        }
        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                rescuedjelly = flags[0];
                jharim = flags[1];
                orthofound = flags[2];
                amogus = flags[3];
            }
            else
            {
                ErrorLogger.Log("CalValEX: Unknown loadVersion: " + loadVersion);
            }
        }
        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = rescuedjelly;
            flags[1] = jharim;
            flags[2] = orthofound;
            flags[3] = amogus;
            writer.Write(flags);
        }
        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            rescuedjelly = flags[0];
            jharim = flags[1];
            orthofound = flags[2];
            amogus = flags[3];
        }

        public override void ResetNearbyTileEffects()
        {
            astralTiles = 0;
            hellTiles = 0;
            labTiles = 0;
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            // Old Astral tiles
            astralTiles = tileCounts[TileType<AstralDirtPlaced>()] + tileCounts[TileType<AstralGrassPlaced>()] + tileCounts[TileType<XenostonePlaced>()] + tileCounts[TileType<AstralSandPlaced>()] + tileCounts[TileType<AstralHardenedSandPlaced>()] + tileCounts[TileType<AstralSandstonePlaced>()] + tileCounts[TileType<AstralClayPlaced>()] + tileCounts[TileType<AstralIcePlaced>()];
            // Hell Lab tiles
            hellTiles = tileCounts[calamityMod.TileType("Chaosplate")];
            // Lab tiles
            labTiles = tileCounts[calamityMod.TileType("LaboratoryPlating")] + tileCounts[calamityMod.TileType("LaboratoryPanels")] + tileCounts[calamityMod.TileType("RustedPlating")] + tileCounts[calamityMod.TileType("LaboratoryPipePlating")] + tileCounts[calamityMod.TileType("RustedPipes")];
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