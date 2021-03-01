using CalValEX.Items.Tiles;
using CalValEX.Items.Tiles.Astral;
using System.Collections.Generic;
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

        public override void Initialize()
        {
            rescuedjelly = false;
        }

        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (rescuedjelly) downed.Add("rescuedjelly");

            return new TagCompound
            {
                ["downed"] = downed
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            rescuedjelly = downed.Contains("rescuedjelly");
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
            astralTiles = tileCounts[TileType<Helplaced>()] + tileCounts[TileType<HesfinePlaced>()] + +tileCounts[TileType<AstralDirtPlaced>()];
            // Hell Lab tiles
            hellTiles = tileCounts[(calamityMod.TileType("Chaosplate"))];
        }

        public static void UpdateWorldBool() { if (Main.netMode == NetmodeID.Server) NetMessage.SendData(MessageID.WorldData); }
    }
}