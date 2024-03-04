using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Metadata;
using Terraria.ModLoader;

namespace CalValEX.Tiles.AstralBlocks
{
    public class AstralTreeWoodPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            //ItemDrop = ModContent.ItemType<AstralTreeWood>();
            AddMapEntry(new Color(78, 45, 91));
            AnimationFrameHeight = 90;
            TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Wood"]);
        }

        private readonly int AnimationFrameWidth = 234;

        public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
        {
            int uniqueAnimationFrameX = Main.tileFrame[Type] + i;
            int uniqueAnimationFrameY = Main.tileFrame[Type] + j;
            int xPos = i % 4;
            int yPos = j % 4;
            switch (xPos)
            {
                case 0:
                    switch (yPos)
                    {
                        case 0:
                            uniqueAnimationFrameX = 0;
                            uniqueAnimationFrameY = 0;
                            break;

                        case 1:
                            uniqueAnimationFrameX = 0;
                            uniqueAnimationFrameY = 1;
                            break;

                        case 2:
                            uniqueAnimationFrameX = 0;
                            uniqueAnimationFrameY = 2;
                            break;

                        case 3:
                            uniqueAnimationFrameX = 0;
                            uniqueAnimationFrameY = 3;
                            break;

                        default:
                            uniqueAnimationFrameX = 0;
                            uniqueAnimationFrameY = 0;
                            break;
                    }
                    break;

                case 1:
                    switch (yPos)
                    {
                        case 0:
                            uniqueAnimationFrameX = 1;
                            uniqueAnimationFrameY = 0;
                            break;

                        case 1:
                            uniqueAnimationFrameX = 1;
                            uniqueAnimationFrameY = 1;
                            break;

                        case 2:
                            uniqueAnimationFrameX = 1;
                            uniqueAnimationFrameY = 2;
                            break;

                        case 3:
                            uniqueAnimationFrameX = 1;
                            uniqueAnimationFrameY = 3;
                            break;

                        default:
                            uniqueAnimationFrameX = 0;
                            uniqueAnimationFrameY = 0;
                            break;
                    }
                    break;

                case 2:
                    switch (yPos)
                    {
                        case 0:
                            uniqueAnimationFrameX = 2;
                            uniqueAnimationFrameY = 0;
                            break;

                        case 1:
                            uniqueAnimationFrameX = 2;
                            uniqueAnimationFrameY = 1;
                            break;

                        case 2:
                            uniqueAnimationFrameX = 2;
                            uniqueAnimationFrameY = 2;
                            break;

                        case 3:
                            uniqueAnimationFrameX = 2;
                            uniqueAnimationFrameY = 3;
                            break;

                        default:
                            uniqueAnimationFrameX = 0;
                            uniqueAnimationFrameY = 0;
                            break;
                    }
                    break;

                case 3:
                    switch (yPos)
                    {
                        case 0:
                            uniqueAnimationFrameX = 3;
                            uniqueAnimationFrameY = 0;
                            break;

                        case 1:
                            uniqueAnimationFrameX = 3;
                            uniqueAnimationFrameY = 1;
                            break;

                        case 2:
                            uniqueAnimationFrameX = 3;
                            uniqueAnimationFrameY = 2;
                            break;

                        case 3:
                            uniqueAnimationFrameX = 3;
                            uniqueAnimationFrameY = 3;
                            break;

                        default:
                            uniqueAnimationFrameX = 0;
                            uniqueAnimationFrameY = 0;
                            break;
                    }
                    break;
            }
            frameXOffset = uniqueAnimationFrameX * AnimationFrameWidth;
            frameYOffset = uniqueAnimationFrameY * AnimationFrameHeight;
        }
    }
}