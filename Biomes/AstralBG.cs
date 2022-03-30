using Terraria.ModLoader;

namespace CalValEX.Biomes
{
	public class AstralBG : ModSurfaceBackgroundStyle
	{
		// Use this to keep far Backgrounds like the mountains.
		public override void ModifyFarFades(float[] fades, float transitionSpeed)
		{
			for (int i = 0; i < fades.Length; i++)
			{
				if (i == Slot)
				{
					fades[i] += transitionSpeed;
					if (fades[i] > 1f)
					{
						fades[i] = 1f;
					}
				}
				else
				{
					fades[i] -= transitionSpeed;
					if (fades[i] < 0f)
					{
						fades[i] = 0f;
					}
				}
			}
		}

		public override int ChooseFarTexture()
		{
			return BackgroundTextureLoader.GetBackgroundSlot("CalValEX/Backgrounds/AstralBack");
		}
		public override int ChooseMiddleTexture()
		{
			return BackgroundTextureLoader.GetBackgroundSlot("CalValEX/Backgrounds/AstralMiddle");
		}

		public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
		{
			return BackgroundTextureLoader.GetBackgroundSlot("CalValEX/Backgrounds/AstralClose");
		}
	}
}