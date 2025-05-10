using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.PlayerLayers
{
    public class Balloon : PlayerDrawLayer
    {
        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            bool hastallhat = false;
            if (drawInfo.drawPlayer.GetModPlayer<CalValEXPlayer>().sapballoon || drawInfo.drawPlayer.GetModPlayer<CalValEXPlayer>().sartballoon)
            {
                hastallhat = true;
            }
            return hastallhat;
        }
        public override Position GetDefaultPosition() => new BeforeParent(PlayerDrawLayers.BalloonAcc);
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
            int xflip = 0;
            xflip = (drawPlayer.direction == -1 ? -40 : 0);
            float alb = (255 - drawPlayer.immuneAlpha) / 255f;
            if (modPlayer.sartballoon)
            {
                int dyeShader = drawPlayer.dye?[1].dye ?? 0;
                for (int n = 0; n < 18 + drawInfo.drawPlayer.extraAccessorySlots; n++)
                {
                    Item item = drawInfo.drawPlayer.armor[n];
                    if (item.type == ModContent.ItemType<Balloons.ArtemisBalloonSmall>())
                    {
                        if (n > 9)
                            dyeShader = drawPlayer.dye?[n - 10].dye ?? 0;
                        else
                            dyeShader = drawPlayer.dye?[n].dye ?? 0;
                    }
                }
                int winflip = 1 * -drawPlayer.direction;
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Equips/Balloons/ArtemisBalloonSmallEquipped").Value;
                Vector2 wtf = drawPlayer.Center - Main.screenPosition + new Vector2(0f * drawPlayer.direction + 20 + xflip, drawPlayer.gfxOffY + 8 - secondyoffset);
                Vector2 origin = new(texture.Width / 2f, texture.Height / 2f / 6f);
                Rectangle conesquare = texture.Frame(1, 12, 0, modPlayer.stwinframe);
                DrawData data = new(texture, wtf, conesquare, drawInfo.colorArmorBody, 0f, origin, 1, drawPlayer.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0
                );
                data.shader = dyeShader;
                drawInfo.DrawDataCache.Add(data);
            }
            else if (modPlayer.sapballoon)
            {
                int dyeShader = drawPlayer.dye?[1].dye ?? 0;
                for (int n = 0; n < 18 + drawInfo.drawPlayer.extraAccessorySlots; n++)
                {
                    Item item = drawInfo.drawPlayer.armor[n];
                    if (item.type == ModContent.ItemType<Balloons.ApolloBalloonSmall>())
                    {
                        if (n > 9)
                            dyeShader = drawPlayer.dye?[n - 10].dye ?? 0;
                        else
                            dyeShader = drawPlayer.dye?[n].dye ?? 0;
                    }
                }
                int winflip = 1 * -drawPlayer.direction;
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Equips/Balloons/ApolloBalloonSmallEquipped").Value;
                Vector2 wtf = drawPlayer.Center - Main.screenPosition + new Vector2(0f * drawPlayer.direction + 20 + xflip, drawPlayer.gfxOffY + 8 - secondyoffset);
                Vector2 origin = new(texture.Width / 2f, texture.Height / 2f / 6f);
                Rectangle conesquare = texture.Frame(1, 12, 0, modPlayer.stwinframe);
                DrawData data = new(texture, wtf, conesquare, drawInfo.colorArmorBody, 0f, origin, 1, drawPlayer.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0
                );
                data.shader = dyeShader;
                drawInfo.DrawDataCache.Add(data);
            }
        }
    }
}