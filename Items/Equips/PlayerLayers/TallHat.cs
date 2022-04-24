using Microsoft.Xna.Framework;
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
            int secondyoffset = 0;
            float alb = (255 - drawPlayer.immuneAlpha) / 255f;
            int dyeShader = drawPlayer.dye?[0].dye ?? 0;
            if (drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 8 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 9 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 15 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 16 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 17)
            {
                secondyoffset = 2;
            }
            else
            {
                secondyoffset = 0;
            }
            if (modPlayer.aesthetic)
            {
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Equips/Hats/AestheticrownEquipped").Value;
                int drawX = (int)(drawPlayer.position.X + drawPlayer.width / 2f - Main.screenPosition.X);
                int drawY = (int)(drawPlayer.position.Y + drawPlayer.height - 32 - Main.screenPosition.Y - secondyoffset);
                if (drawPlayer.mount.Active)
                    drawY += drawPlayer.mount.HeightBoost;
                DrawData dat = new DrawData(texture, new Vector2(drawX, drawY), null, drawInfo.colorArmorHead, 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                dat.shader = dyeShader;
                drawInfo.DrawDataCache.Add(dat);
            }
            if (modPlayer.rockhat)
            {
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Equips/Hats/StonePileEquipped").Value;
                int drawX = (int)(drawPlayer.position.X + drawPlayer.width / 2f - Main.screenPosition.X);
                int drawY = (int)(drawPlayer.position.Y + drawPlayer.height - 32 - Main.screenPosition.Y - secondyoffset);
                if (drawPlayer.mount.Active)
                    drawY += drawPlayer.mount.HeightBoost;
                DrawData dat = new DrawData(texture, new Vector2(drawX, drawY), null, drawInfo.colorArmorHead, 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                dat.shader = dyeShader;
                drawInfo.DrawDataCache.Add(dat);
            }
            if (modPlayer.conejo)
            {
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Equips/Hats/TrueCosmicConeEquipped").Value;
                Vector2 wtf = drawPlayer.Center - Main.screenPosition + new Vector2(0f * drawPlayer.direction, drawPlayer.gfxOffY - 85 - secondyoffset);
                if (drawPlayer.mount.Active)
                    wtf.Y += drawPlayer.mount.HeightBoost;
                Vector2 origin = new Vector2(texture.Width / 2f, texture.Height / 2f / 6f);
                Rectangle conesquare = texture.Frame(1, 6, 0, modPlayer.coneframe);
                DrawData dat = new DrawData(texture, wtf, conesquare, drawInfo.colorArmorHead, 0f, origin, 1, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0
                );
                dat.shader = dyeShader;
                drawInfo.DrawDataCache.Add(dat);
            }
        }
	}
}