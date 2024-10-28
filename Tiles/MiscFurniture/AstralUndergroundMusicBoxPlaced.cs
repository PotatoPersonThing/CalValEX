using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using CalValEX.Items.Tiles;

namespace CalValEX.Tiles.MiscFurniture
{
    public class AstralUndergroundMusicBoxPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.LavaDeath = false;
            Terraria.ID.TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Music Box");
            AddMapEntry(new Color(200, 200, 200), name);
            RegisterItemDrop(ModContent.ItemType<AstralUndergroundMusicBox>());
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<AstralUndergroundMusicBox>();
        }
    }
}