using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;

namespace CalValEX.Biomes
{
    public class AstralSky : CustomSky
    {
        private bool Active;
        private float intensity;

        public override void Deactivate(params object[] args)
        {
            Active = false;
        }

        public override void Reset()
        {
            Active = false;
        }

        public override bool IsActive()
        {
            return Active || intensity > 0f;
        }

        public override void Activate(Vector2 position, params object[] args)
        {
            Active = true;
        }

        public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
        {
            if (maxDepth >= 3.40282347E+38f && minDepth < 3.40282347E+38f)
            {
                spriteBatch.Draw(CalValEX.AstralSky, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Main.ColorOfTheSkies * intensity);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (!Main.LocalPlayer.InModBiome(ModContent.GetInstance<AstralBlight>()))
                Active = false;

            if (Active && intensity < 1f)
            {
                intensity += 0.02f;
            }
            else if (!Active && intensity > 0f)
            {
                intensity -= 0.02f;
            }
        }

        public override float GetCloudAlpha()
        {
            return (1f - intensity) * 0.97f + 0.03f;
        }
    }
}