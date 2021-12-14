using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Items.Tiles.Blocks;

namespace CalValEX.Tiles.AstralBlocks
{
    public class AstralBrickPlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlendAll[this.Type] = true;
            drop = ModContent.ItemType<AstralBrick>();
            AddMapEntry(new Color(171, 103, 171));
            animationFrameHeight = 198;
            soundType = SoundID.Tink;
        }

        private readonly int animationFrameWidth = 450;

        public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
        {
            int uniqueAnimationFrameX = Main.tileFrame[Type] + i;
            int uniqueAnimationFrameY = Main.tileFrame[Type] + j;
            int xPos = i % 2;
            int yPos = j % 2;
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