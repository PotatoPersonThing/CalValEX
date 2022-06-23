using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Biomes
{
	public class AstralUndergroundBG : ModUndergroundBackgroundStyle
	{
		public override void FillTextureArray(int[] textureSlots)
		{
			textureSlots[0] = BackgroundTextureLoader.GetBackgroundSlot("CalValEX/Backgrounds/AstralUndergroundTop");
			textureSlots[1] = BackgroundTextureLoader.GetBackgroundSlot("CalValEX/Backgrounds/AstralUndergroundMain");
			textureSlots[2] = BackgroundTextureLoader.GetBackgroundSlot("CalValEX/Backgrounds/AstralCavernTop");
			textureSlots[3] = BackgroundTextureLoader.GetBackgroundSlot("CalValEX/Backgrounds/AstralCavernMain");
		}
	}
}