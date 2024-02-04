using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Reflection;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Dyes
{
    public class BlightedAstralPinkDye : ModItem
    {
        public override string Texture => "CalValEX/Items/Dyes/SulphuricDye";
        public sealed override void SetStaticDefaults()
        {
            if (!Main.dedServ)
            {
                GameShaders.Armor.BindShader(Type, new ArmorShaderData(new Ref<Effect>(Mod.Assets.Request<Effect>("Effects/BlightedPinkDye", AssetRequestMode.ImmediateLoad).Value), "DyePass").
            UseColor(new Color(180, 23, 180)).UseSecondaryColor(new Color(180, 23, 222)).SetShaderTextureArmor(ModContent.Request<Texture2D>("CalValEX/ExtraTextures/BlobbyNoise", AssetRequestMode.ImmediateLoad)));
            }
        }
        public sealed override void SetDefaults()
        {
            int dye = Item.dye;
            Item.CloneDefaults(ItemID.GelDye);
            Item.dye = dye;
        }
    }
    public static class ImDying
    {
        internal static readonly FieldInfo UImageFieldArmor = typeof(ArmorShaderData).GetField("_uImage", BindingFlags.NonPublic | BindingFlags.Instance);

        public static ArmorShaderData SetShaderTextureArmor(this ArmorShaderData shader, Asset<Texture2D> texture)
        {
            UImageFieldArmor.SetValue(shader, texture);
            return shader;
        }
    }
}