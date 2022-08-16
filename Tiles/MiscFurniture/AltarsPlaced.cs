using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Tiles;
using Terraria.ID;

namespace CalValEX.Tiles.MiscFurniture {
    public class MoulderingAltarPlaced : ModTile {
        //public override string Texture => "CalValEX/Tiles/MiscFurniture/MoulderingAltarPlaced";

        public override void SetStaticDefaults() {
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addTile(Type);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Mouldering Altar");
            AddMapEntry(new Color(94, 67, 72), name);

            AdjTiles = new int[] { TileID.DemonAltar };
        }

        public override void KillMultiTile(int i, int j, int TileFrameX, int TileFrameY) {
            Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ItemType<MoulderingAltarItem>());
        }
    }
    public class VisceralAltarPlaced : ModTile {
        //public override string Texture => "CalValEX/Tiles/MiscFurniture/VisceralAltarPlaced";

        public override void SetStaticDefaults() {
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addTile(Type);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Visceral Altar");
            AddMapEntry(new Color(153, 54, 63), name);

            AdjTiles = new int[] { TileID.DemonAltar };
        }

        public override void KillMultiTile(int i, int j, int TileFrameX, int TileFrameY) {
            Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ItemType<VisceralAltarItem>());
        }

    }
}
