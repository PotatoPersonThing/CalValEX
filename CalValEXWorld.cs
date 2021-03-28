using System.Collections.Generic;
using CalValEX.Items.Tiles;
using CalValEX.Items.Tiles.Astral;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace CalValEX
{
    public class CalValEXWorld : ModWorld
    {
        public static int astralTiles;

        public static int hellTiles;

        public static bool rescuedjelly;

        public static bool jharim;

        public static bool OneMonolith;

        public static bool TwoMonolith;

        public override void Initialize()
        {
            rescuedjelly = false;
            jharim = false;
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

            return new TagCompound
            {
                ["downed"] = downed
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            rescuedjelly = downed.Contains("rescuedjelly");
            rescuedjelly = downed.Contains("jharim");
        }

        public override void ResetNearbyTileEffects()
        {
            astralTiles = 0;
            hellTiles = 0;
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            // Old Astral tiles
            astralTiles = tileCounts[TileType<AstralDirtPlaced>()] + tileCounts[TileType<AstralGrassPlaced>()] + tileCounts[TileType<XenostonePlaced>()] + tileCounts[TileType<AstralSandPlaced>()] + tileCounts[TileType<AstralHardenedSandPlaced>()] + tileCounts[TileType<AstralSandstonePlaced>()] + tileCounts[TileType<AstralClayPlaced>()] + tileCounts[TileType<AstralIcePlaced>()];
            // Hell Lab tiles
            hellTiles = tileCounts[calamityMod.TileType("Chaosplate")];
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