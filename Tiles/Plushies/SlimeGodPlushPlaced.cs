using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Tiles.Plushies;

namespace CalValEX.Tiles.Plushies
{
    public class SlimeGodPlushPlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Slime God Plush");
            AddMapEntry(new Color(144, 148, 144), name);
            dustType = 11;
            disableSmartCursor = true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 32, ItemType<SlimeGodPlush>());
        }
    }
}