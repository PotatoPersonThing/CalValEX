using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ReLogic.Content;
using Terraria.Graphics.Shaders;
using Terraria.GameContent.Creative;

namespace CalValEX.Items.Dyes
{
    public class SulphuricDye : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 3;
            if (!Main.dedServ)
            {
                GameShaders.Armor.BindShader(
                    Item.type,
                    new ArmorShaderData(new Ref<Effect>(Mod.Assets.Request<Effect>("Effects/SulphuricDye", AssetRequestMode.ImmediateLoad).Value), "SulphuricDyePass").UseColor(0.9882f, 0.7804f, 0.9686f).UseSecondaryColor(0.9098f, 0.5294f, 0.9764f) // Be sure to update the effect path and pass name here.
                );
            }

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            int  dye = Item.dye;
            Item.CloneDefaults(ItemID.GelDye);
            Item.width = 22;
            Item.height = 26;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.dye = dye;
        }
    }
}