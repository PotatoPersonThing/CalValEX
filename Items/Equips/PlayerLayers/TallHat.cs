using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.PlayerLayers
{
    public class TallHat : PlayerDrawLayer
	{
		public override bool IsHeadLayer => true;

		public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
		{
            bool hastallhat = false;
            if (drawInfo.drawPlayer.GetModPlayer<CalValEXPlayer>().aesthetic
				|| drawInfo.drawPlayer.GetModPlayer<CalValEXPlayer>().rockhat
				|| drawInfo.drawPlayer.GetModPlayer<CalValEXPlayer>().conejo)
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
            int secondyoffset;
            
            var bodFrame = drawPlayer.bodyFrame;
            if (bodFrame.Y == bodFrame.Height * 7 || bodFrame.Y == bodFrame.Height * 8 || bodFrame.Y == bodFrame.Height * 9
                || bodFrame.Y == bodFrame.Height * 14 || bodFrame.Y == bodFrame.Height * 15 || bodFrame.Y == bodFrame.Height * 16)
                secondyoffset = 2;
            else
                secondyoffset = 0;

            float alb = (255 - drawPlayer.immuneAlpha) / 255f;
            int dyeShader = drawPlayer.dye?[0].dye ?? 0;

            Vector2 headPosition = drawInfo.helmetOffset +
                new Vector2(
                    (int)(drawInfo.Position.X - (float)(drawInfo.drawPlayer.bodyFrame.Width / 2) + (float)(drawInfo.drawPlayer.width / 2)),
                    (int)(drawInfo.Position.Y + (float)drawInfo.drawPlayer.height - (float)drawInfo.drawPlayer.bodyFrame.Height) - secondyoffset)
                + drawInfo.drawPlayer.headPosition
                + drawInfo.headVect;

            headPosition -= Main.screenPosition;

            if (modPlayer.aesthetic)
            {
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Equips/Hats/AestheticrownEquipped").Value;
                DrawData dat = new(texture, new Vector2(headPosition.X + (1 * drawPlayer.direction), headPosition.Y - 1), null, drawInfo.colorArmorHead, 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                dat.shader = dyeShader;
                drawInfo.DrawDataCache.Add(dat);
            }
            if (modPlayer.rockhat)
            {
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Equips/Hats/StonePileEquipped").Value;
                DrawData dat = new(texture, new Vector2(headPosition.X, headPosition.Y), null, drawInfo.colorArmorHead, 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                dat.shader = dyeShader;
                drawInfo.DrawDataCache.Add(dat);
            }
            if (modPlayer.conejo)
            {
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Equips/Hats/TrueCosmicConeEquipped").Value;
                Vector2 origin = new(texture.Width / 2f, texture.Height / 2f / 6f);
                Rectangle conesquare = texture.Frame(1, 6, 0, modPlayer.coneframe);
                DrawData dat = new(texture, new Vector2(headPosition.X, headPosition.Y - 75), conesquare, drawInfo.colorArmorHead, 0f, origin, 1, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0
                );
                dat.shader = dyeShader;
                drawInfo.DrawDataCache.Add(dat);
            }
        }
	}
}