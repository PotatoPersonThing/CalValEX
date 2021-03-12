using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Backgrounds;

namespace CalValEX.Items.Tiles.Astral
{
	public class AstralWaterStyle : ModWaterStyle
	{
		public override bool ChooseWaterStyle()
			=> Main.bgStyle == mod.GetSurfaceBgStyleSlot("AstralBG");

		public override int ChooseWaterfallStyle() 
			=> mod.GetWaterfallStyleSlot("AstralWaterfallStyle");

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