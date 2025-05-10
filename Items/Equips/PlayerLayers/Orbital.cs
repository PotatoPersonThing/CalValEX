using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.PlayerLayers
{
    public class Orbital : PlayerDrawLayer
    {
        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            bool hastallhat = false;
            for (int n = 13; n < 18 + drawInfo.drawPlayer.extraAccessorySlots; n++)
            {
                Item item = drawInfo.drawPlayer.armor[n];
                if (item.type == ModContent.ItemType<ExodiumMoon>())
                {
                    hastallhat = true;
                }
            }
            return hastallhat || drawInfo.drawPlayer.GetModPlayer<CalValEXPlayer>().exorb;
        }
        public override Position GetDefaultPosition() => new BeforeParent(PlayerDrawLayers.Wings);
        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            float alb = (255 - drawPlayer.immuneAlpha) / 255f;
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.exorb)
            {
                int dyeShader = drawPlayer.dye?[1].dye ?? 0;
                for (int n = 0; n < 18 + drawInfo.drawPlayer.extraAccessorySlots; n++)
                {
                    Item item = drawInfo.drawPlayer.armor[n];
                    if (item.type == ModContent.ItemType<ExodiumMoon>())
                    {
                        if (n > 9)
                            dyeShader = drawPlayer.dye?[n - 10].dye ?? 0;
                        else
                            dyeShader = drawPlayer.dye?[n].dye ?? 0;
                    }
                }
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Equips/ExodiumMoon").Value;
                Vector2 Circle = drawPlayer.Center + new Vector2(0, 300).RotatedBy(modPlayer.rotcounter);
                Vector2 draw = Circle - Main.screenPosition;
                DrawData data = new(texture, draw, null, drawInfo.colorArmorBody * alb, (float)modPlayer.rotsin, new Vector2(texture.Width / 2f, texture.Height), 1f, SpriteEffects.None, 0)
                ;
                data.shader = dyeShader;
                drawInfo.DrawDataCache.Add(data);
                //drawInfo.DrawDataCache.Add(data);
            }
        }
    }
}