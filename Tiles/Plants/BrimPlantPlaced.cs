using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Pets;
using ReLogic.Content;

namespace CalValEX.Tiles.Plants {
    public class BrimPlantPlaced : ModTile {
        public override void SetStaticDefaults() {
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileSpelunker[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true;
            TileID.Sets.ReplaceTileBreakUp[Type] = true;
            TileID.Sets.IgnoredInHouseScore[Type] = true;
            TileID.Sets.IgnoredByGrowingSaplings[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.AnchorValidTiles = new int[] {
                TileType<CalamityMod.Tiles.Crags.BrimstoneSlag>(),
                TileID.Ash,
            };
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            
            name.SetDefault("Brimberry Plant");
            AddMapEntry(new Color(201, 30, 12), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY) {
            if (Main.rand.NextFloat() < .25f)
                Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ItemType<BrimberryItem>());
        }
    }
}