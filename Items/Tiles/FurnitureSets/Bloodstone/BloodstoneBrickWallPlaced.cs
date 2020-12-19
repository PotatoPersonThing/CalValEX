/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CalValEX.Items.Tiles.FurnitureSets.Bloodstone;

namespace CalValEX.Items.Tiles.FurnitureSets.Bloodstone
{
	public class BloodstoneBrickWallPlaced : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[Type] = true;
			drop = ModContent.ItemType<BloodstoneBrickWall>();
			AddMapEntry(new Color(108, 59, 16));
            animationFrameHeight = 90;
            minPick = 275;
        }

        readonly int animationFrameWidth = 234;

        public override void AnimateIndividualWall(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
        {
            int uniqueAnimationFrameX = Main.wallFrame[Type] + i;
            int uniqueAnimationFrameY = Main.wallFrame[Type] + j;
            int xPos = i % 1;
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
                    }
                    break;
            }
            frameXOffset = uniqueAnimationFrameX * animationFrameWidth;
            frameYOffset = uniqueAnimationFrameY * animationFrameHeight;
        }
    }
}
*/