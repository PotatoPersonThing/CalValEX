using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Tiles.Blocks
{
    public class BloodstoneBrickPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            //ItemDrop = ModContent.ItemType<BloodstoneBrick>();
            AddMapEntry(new Color(126, 94, 87));
            AnimationFrameHeight = 90;
        }

        private readonly int AnimationFrameWidth = 234;

        public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
        {
            int uniqueAnimationFrameX = Main.tileFrame[Type] + i;
            int uniqueAnimationFrameY = Main.tileFrame[Type] + j;
            int xPos = i % 2;
            int yPos = j % 3;
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