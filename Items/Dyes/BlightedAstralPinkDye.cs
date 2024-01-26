using CalamityMod;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
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
}