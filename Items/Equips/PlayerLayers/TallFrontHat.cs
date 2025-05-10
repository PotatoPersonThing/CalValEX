using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.PlayerLayers
{
    public class TallFrontHat : PlayerDrawLayer
    {
        public override bool IsHeadLayer => true;

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            bool hastallhat = false;
            if (drawInfo.drawPlayer.GetModPlayer<CalValEXPlayer>().specan)
            {
                hastallhat = true;
            }
            return hastallhat;
        }
        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Head);
        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            Player player = Main.LocalPlayer;
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();
            int secondyoffset = 0;
            float alb = (255 - drawPlayer.immuneAlpha) / 255f;
            int dyeShader = drawPlayer.dye?[0].dye ?? 0;
            /*if (drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 8 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 9 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 15 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 16 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 17)
            {
                secondyoffset = 2;
            }
            else
            {
                secondyoffset = 0;
            }*/



            Vector2 headPosition = drawInfo.helmetOffset +
                new Vector2(
                    (int)(drawInfo.Position.X - (float)(drawInfo.drawPlayer.bodyFrame.Width / 2) + (float)(drawInfo.drawPlayer.width / 2)),
                    (int)(drawInfo.Position.Y + (float)drawInfo.drawPlayer.height - (float)drawInfo.drawPlayer.bodyFrame.Height))
                + drawInfo.drawPlayer.headPosition
                + drawInfo.headVect;

            headPosition -= Main.screenPosition;




            if (modPlayer.specan)
            {
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Equips/Hats/SpectralstormHat").Value;
                int drawX = (int)(drawPlayer.position.X + drawPlayer.width / 2f - Main.screenPosition.X - (2 * drawPlayer.direction));
                int drawY = (int)(drawPlayer.position.Y + drawPlayer.height - 20 - Main.screenPosition.Y - secondyoffset);
                if (drawPlayer.mount.Active)
                    drawY += drawPlayer.mount.HeightBoost; 
                DrawData dat = new(texture, new Vector2(headPosition.X - (2 * drawPlayer.direction), headPosition.Y), null, drawInfo.colorArmorHead, 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                dat.shader = dyeShader;
                drawInfo.DrawDataCache.Add(dat);
            }
        }
    }
}