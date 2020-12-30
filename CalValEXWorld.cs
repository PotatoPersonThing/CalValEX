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
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            // Here we count various tiles towards ZoneAstral
            astralTiles = tileCounts[TileType<Helplaced>()] + tileCounts[TileType<HesfinePlaced>()] + +tileCounts[TileType<AstralDirtPlaced>()];
        }

        public static void UpdateWorldBool() { if (Main.netMode == NetmodeID.Server) NetMessage.SendData(MessageID.WorldData); }
    }
}