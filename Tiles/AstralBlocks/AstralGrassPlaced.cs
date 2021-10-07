using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Tiles.Blocks.Astral;
using CalValEX.Dusts;
using CalValEX.Tiles.AstralMisc;

namespace CalValEX.Tiles.AstralBlocks
{
    public class AstralGrassPlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = true;
            drop = ModContent.ItemType<AstralDirt>();
            dustType = ModContent.DustType<AstralSolutionDust>();
            AddMapEntry(new Color(252, 88, 252));
            TileID.Sets.Grass[Type] = true;
            TileID.Sets.Conversion.Grass[Type] = true;
            TileID.Sets.NeedsGrassFraming[Type] = true;
            TileID.Sets.NeedsGrassFramingDirt[Type] = mod.TileType("AstralDirtPlaced");
            SetModTree(new AstralTree());
            Main.tileBlendAll[this.Type] = true;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (fail && !effectOnly)
            {
                Main.tile[i, j].type = (ushort)ModContent.TileType<AstralDirtPlaced>();
            }
        }

        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<AstralSapling>();
        }

        public override void RandomUpdate(int i, int j)
        {
            if (Main.rand.Next(7) == 0)
            {
                int grassspawned;
                int choice = Main.rand.Next(2);
                if (choice == 0)
                {
                    grassspawned = mod.TileType("AstralTallGrass");
                }
                else
                {
                    grassspawned = mod.TileType("AstralShortGrass");
                }

                if (!Main.tile[i, j - 1].active() && Main.tileSolid[Main.tile[i, j + 1].type] && Main.tile[i, j].slope() == 0 && !Main.tile[i, j].halfBrick())
                {
                    WorldGen.PlaceTile(i, j - 1, grassspawned, true, false, -1, Main.rand.Next(18));
                }

                int LocationX = i;
                int LocationY = j;
                for (int x = LocationX - 4; x <= LocationX + 4; x++)
                {
                    for (int y = LocationY - 4; y <= LocationY + 4; y++)
                    {
                        if (Vector2.Distance(new Vector2(LocationX, LocationY), new Vector2(x, y)) <= 4)
                        {
                            if (Main.tile[x, y].type == mod.TileType("AstralDirtPlaced"))
                            {
                                if (Main.tile[x + 1, y].active() && Main.tile[x, y - 1].active() && Main.tile[x - 1, y].active() && Main.tile[x, y + 1].active() && Main.tile[x + 1, y + 1].active() && Main.tile[x - 1, y - 1].active() && Main.tile[x - 1, y + 1].active() && Main.tile[x + 1, y - 1].active())
                                {
                                }
                                else
                                {
                                    if (Main.rand.Next(1) == 0)
                                    {
                                        Main.tile[x, y].type = (ushort)mod.TileType("AstralGrassPlaced"); ;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
