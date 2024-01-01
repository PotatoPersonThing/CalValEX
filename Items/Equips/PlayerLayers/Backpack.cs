using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.PlayerLayers
{
    public class Backpack : PlayerDrawLayer
    {
        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            bool hastallhat = false;
            for (int n = 13; n < 18 + drawInfo.drawPlayer.extraAccessorySlots; n++)
            {
                Item item = drawInfo.drawPlayer.armor[n];
                if (item.type == ModContent.ItemType<Items.Equips.Backs.PrismShell>())
                {
                    hastallhat = true;
                }
            }
            return hastallhat || drawInfo.drawPlayer.GetModPlayer<CalValEXPlayer>().prismshell;
        }
        public override Position GetDefaultPosition() => new BeforeParent(PlayerDrawLayers.BackAcc);
        protected override void Draw(ref PlayerDrawSet drawInfo) {
            if (drawInfo.shadow != 0f)
                return;

            Player drawPlayer = drawInfo.drawPlayer;
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();
            float alb = (255 - drawPlayer.immuneAlpha) / 255f;
            int dyeShader = drawPlayer.dye?[1].dye ?? 0;
            
            for (int n = 0; n < 18 + drawInfo.drawPlayer.extraAccessorySlots; n++) {
                Item item = drawInfo.drawPlayer.armor[n];
                if (item.type == ModContent.ItemType<Items.Equips.Backs.PrismShell>()) {
                    if (n > 9)
                        dyeShader = drawPlayer.dye?[n - 10].dye ?? 0;
                    else
                        dyeShader = drawPlayer.dye?[n].dye ?? 0;
                }
            }

            int secondyoffset;
            var bodFrame = drawPlayer.bodyFrame;
            if (bodFrame.Y == bodFrame.Height * 7 || bodFrame.Y == bodFrame.Height * 8 || bodFrame.Y == bodFrame.Height * 9
                || bodFrame.Y == bodFrame.Height * 14 || bodFrame.Y == bodFrame.Height * 15 || bodFrame.Y == bodFrame.Height * 16)
                secondyoffset = 2;
            else
                secondyoffset = 0;

            if (modPlayer.prismshell) {
                int gnuflip = -drawPlayer.direction;
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Equips/Backs/PrismShell").Value;
                
                int drawX = (int)(drawInfo.Position.X + drawPlayer.width / 2f - Main.screenPosition.X - gnuflip + (15 * gnuflip));
                int drawY = (int)(drawInfo.Position.Y + drawInfo.drawPlayer.height - Main.screenPosition.Y - 4 - secondyoffset);

                DrawData dat = new(texture, new Vector2(drawX, drawY), null, Color.White * alb, 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, 
                    drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                dat.shader = dyeShader;
                drawInfo.DrawDataCache.Add(dat);
            }
        }
    }
}