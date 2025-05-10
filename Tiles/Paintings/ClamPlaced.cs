using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CalValEX.Tiles.Paintings
{
    public class ClamPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.Width = 5;
            TileObjectData.newTile.Height = 5;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16 }; //
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Gyate Gyate");
            AddMapEntry(new Color(139, 0, 0), name);
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            CalValEXPlayer player = Main.LocalPlayer.GetModPlayer<CalValEXPlayer>();
            if (!player.hasOhiod)
            {
                if (player.ohio)
                {
                    for (int x = i -5; x < i + 5; x++)
                    {
                        for (int y = j-5; y < j+5; y++)
                        {
                            if (Main.tile[x, y] != null)
                            {
                                if (Main.tile[x, y].TileType == Type)
                                {
                                    Main.tile[x, y].TileType = (ushort)ModContent.TileType<OhioPlaced>();
                                }
                            }
                        }
                    }
                    player.hasOhiod = true;
                    player.ohio = false;
                }
                if (Main.rand.NextBool(222222))
                {
                    SoundEngine.PlaySound(SoundID.BloodZombie);
                    player.ohio = true;
                }
            }
        }
    }
}