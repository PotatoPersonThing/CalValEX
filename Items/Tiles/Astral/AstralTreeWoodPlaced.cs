using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Astral
{
    public class AstralTreeWoodPlaced : ModTile
    {
        private static int sheetWidth = 216;
        private static int sheetHeight = 72;

        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            drop = ModContent.ItemType<AstralTreeWood>();
            AddMapEntry(new Color(79, 49, 76));
            animationFrameHeight = 72;
            minPick = 1;
        }

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
                            uniqueAnimationFrameX = 2;
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
                            uniqueAnimationFrameX = 3;
                            uniqueAnimationFrameY = 0;
                            break;
                    }
                    break;
            }
            frameXOffset = xPos * sheetWidth;
            frameYOffset = yPos * sheetHeight;
        }
    }
}