using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CalValEX.Items.Dyes
{
    public class DraedonHologramDye : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 3;
            if (!Main.dedServ) 
            {
                GameShaders.Armor.BindShader(
                    Item.type,
                    new ArmorShaderData(new Ref<Effect>(Mod.Assets.Request<Effect>("Effects/DraedonHologramDye", AssetRequestMode.ImmediateLoad).Value), "DraedonHologramDyePass") // Be sure to update the effect path and pass name here.
                );
            }

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            int dye = Item.dye;
            Item.CloneDefaults(ItemID.GelDye);
            Item.width = 22;
            Item.height = 28;
            Item.value = Item.sellPrice(0, 0, 0, 5);
            Item.dye = dye;
        }

        private int frameCounter;
        private int frame;

        internal Rectangle GetCurrentFrame(bool frameCounterUp = true)
        {
            int frames = 16;
            if (frameCounter % 5 == 0)
            {
                frame = ((frame == frames - 1) ? 0 : frame + 1);
            }
            if (frameCounterUp)
                frameCounter++;
            return new Rectangle(0, Item.height * frame, Item.width, Item.height);
        }

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Dyes/DraedonHologramDye_Animated").Value;
            spriteBatch.Draw(texture, position, new Rectangle?(GetCurrentFrame(true)), Color.White, 0f, origin, scale, SpriteEffects.None, 0f);
            return false;
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Dyes/DraedonHologramDye_Animated").Value;
            spriteBatch.Draw(texture, Item.position - Main.screenPosition, new Rectangle?(GetCurrentFrame(true)), lightColor, rotation, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            return false;
        }
    }
}