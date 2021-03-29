using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Backgrounds
{
    public class AstralBG : ModSurfaceBgStyle
    {

        public override bool ChooseBgStyle() =>
            !Main.gameMenu && Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneAstral;

        public override void ModifyFarFades(float[] fades, float transitionSpeed)
        {
            for (int i = 0; i < fades.Length; i++)
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

        public override int ChooseFarTexture()
        {
            //b -= 510f;
            return mod.GetBackgroundSlot("Backgrounds/AstralBack");
        } 

        public override int ChooseMiddleTexture()
        {
            //b -= 200f;
           return mod.GetBackgroundSlot("Backgrounds/AstralMiddle");
        }

        public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
        {
            b -= 180f;
            return mod.GetBackgroundSlot("Backgrounds/AstralClose");
        }
    }
}