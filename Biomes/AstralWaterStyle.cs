using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Biomes
{
    public class AstralWaterStyle : ModWaterStyle
	{
        public override int ChooseWaterfallStyle() => Find<ModWaterfallStyle>("CalValEX/AstralWaterfallStyle").Slot;

        public override int GetSplashDust()
        {
            return 33;
        }

        public override int GetDropletGore()
        {
            return 713;
        }

		public override Color BiomeHairColor() 
			=> Color.Purple;
	}
}