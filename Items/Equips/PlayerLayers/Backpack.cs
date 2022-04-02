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
        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            float alb = (255 - drawPlayer.immuneAlpha) / 255f;
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();
            int dyeShader = drawPlayer.dye?[1].dye ?? 0;
            for (int n = 0; n < 18 + drawInfo.drawPlayer.extraAccessorySlots; n++)
            {
                Item item = drawInfo.drawPlayer.armor[n];
                if (item.type == ModContent.ItemType<Items.Equips.Backs.PrismShell>())
                {
                    if (n > 9)
                    dyeShader = drawPlayer.dye?[n - 10].dye ?? 0;
                    else
                    dyeShader = drawPlayer.dye?[n].dye ?? 0;
                }
            }
            int secondyoffset = 0;
            if (drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 8 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 9 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 15 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 16 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 17)
            {
                secondyoffset = 2;
            }
            else
            {
                secondyoffset = 0;
            }
            if (modPlayer.prismshell)
            {
                int gnuflip = -drawPlayer.direction;
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Equips/Backs/PrismShell").Value;
                int drawX = (int)(drawPlayer.position.X + drawPlayer.width / 2f - Main.screenPosition.X - gnuflip + (15 * gnuflip));
                int drawY = (int)(drawPlayer.position.Y + drawPlayer.height - Main.screenPosition.Y - 4 - secondyoffset);
                if (drawPlayer.mount.Active)
                    drawY += drawPlayer.mount.HeightBoost;
                DrawData dat = new DrawData(texture, new Vector2(drawX, drawY), null, Color.White * alb, 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                dat.shader = dyeShader;
                drawInfo.DrawDataCache.Add(dat);
            }
        }
    }
}