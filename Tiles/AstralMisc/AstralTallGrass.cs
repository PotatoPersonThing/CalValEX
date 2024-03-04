using Terraria;
using CalValEX.Dusts;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.GameContent.Metadata;

namespace CalValEX.Tiles.AstralMisc
{
    public class AstralTallGrass : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileCut[Type] = true;
            DustType = ModContent.DustType<AstralSolutionDust>();
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.CoordinateHeights = new int[1]
            {
            20
            };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.RandomStyleRange = 21;
            TileObjectData.addTile(Type);
            HitSound = SoundID.Grass;
            TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Plant"]);
        }
    }
}
