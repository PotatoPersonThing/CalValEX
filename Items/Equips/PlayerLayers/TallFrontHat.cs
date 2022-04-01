using Microsoft.Xna.Framework;
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
            bool hastallhat = (drawInfo.drawPlayer.GetModPlayer<CalValEXPlayer>().specan);
            Item item = drawInfo.drawPlayer.armor[10];
            if (item.type == ModContent.ItemType<Items.Equips.Hats.SpectralstormHat>())
            {
                hastallhat = true;
            }
            return hastallhat;
        }
        public override Position GetDefaultPosition() => new BeforeParent(PlayerDrawLayers.Head);
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
            if (drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 8 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 9 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 15 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 16 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 17)
            {
                secondyoffset = 2;
            }
            else
            {
                secondyoffset = 0;
            }
            if (modPlayer.specan)
            {
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Equips/Hats/SpectralstormHat").Value;
                int drawX = (int)(drawPlayer.position.X + drawPlayer.width / 2f - Main.screenPosition.X);
                int drawY = (int)(drawPlayer.position.Y + drawPlayer.height - 32 - Main.screenPosition.Y - secondyoffset);
                drawInfo.DrawDataCache.Add(new DrawData(texture, new Vector2(drawX, drawY), null, Color.White * alb, 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0));
            }
        }
    }
}