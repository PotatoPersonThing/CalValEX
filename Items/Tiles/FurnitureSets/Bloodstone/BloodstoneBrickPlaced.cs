using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.FurnitureSets.Bloodstone
{
    public class BloodstoneBrickPlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            drop = ModContent.ItemType<BloodstoneBrick>();
            AddMapEntry(new Color(126, 94, 87));
            animationFrameHeight = 90;
            minPick = 275;
        }
        readonly int animationFrameWidth = 234;

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
            frameXOffset = uniqueAnimationFrameX * animationFrameWidth;
            frameYOffset = uniqueAnimationFrameY * animationFrameHeight;
        }
    }
}
