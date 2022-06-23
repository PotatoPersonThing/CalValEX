using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;

namespace CalValEX.Effects
{
    public class MultiTextureArmorShaderData : ArmorShaderData
    {
        private readonly Ref<Texture2D>[] secondaryTextures;

        public MultiTextureArmorShaderData(Ref<Effect> shader, string passName, params Texture2D[] secondaryTextures) : base(shader, passName)
        {
            this.secondaryTextures = new Ref<Texture2D>[secondaryTextures.Length];
            for (int i = 0; i < secondaryTextures.Length; i++)
                this.secondaryTextures[i] = new Ref<Texture2D>(secondaryTextures[i]);
        }

        public override void Apply(Entity entity, DrawData? drawData)
        {
            for (int i = 0; i < secondaryTextures.Length; i++)
            {
                Main.graphics.GraphicsDevice.Textures[i + 1] = secondaryTextures[i].Value;
                Shader.Parameters[$"uImageSize{i + 1}"].SetValue(secondaryTextures[i].Value.Size());
            }
            base.Apply(entity, drawData);
        }
    }
}
