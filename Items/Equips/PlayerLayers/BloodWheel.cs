using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.PlayerLayers
{
    public class BloodWheel : PlayerDrawLayer
    {
        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            bool hastallhat = (drawInfo.drawPlayer.GetModPlayer<CalValEXPlayer>().carriage || drawInfo.drawPlayer.GetModPlayer<CalValEXPlayer>().silvajeep);
            return hastallhat;
        }
        public override Position GetDefaultPosition() => new BeforeParent(PlayerDrawLayers.MountBack);
        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();
            int dyeShader = drawPlayer.miscDyes?[3].dye ?? 0;
            if (modPlayer.carriage)
            {
                int gnuflip = 56 * -drawPlayer.direction;
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Mounts/Ground/BloodstoneCarriageWheel").Value;
                int drawX = (int)(drawPlayer.position.X + drawPlayer.width / 2f - Main.screenPosition.X + gnuflip);
                int drawX2 = (int)(drawPlayer.position.X + drawPlayer.width / 2f - Main.screenPosition.X - gnuflip);
                int drawY = (int)(drawPlayer.position.Y + drawPlayer.height - Main.screenPosition.Y - 16);
                DrawData data = new(texture, new Vector2(drawX + (drawPlayer.direction == 1 ? 6 : -8), drawY), null, Lighting.GetColor((int)((drawPlayer.position.X + drawPlayer.width / 2f) / 16f), (int)((drawPlayer.position.Y - texture.Height / 2f) / 16f)), modPlayer.bcarriagewheel / 15.0f, new Vector2(texture.Width / 2f, texture.Height / 2f), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                DrawData data2 = new(texture, new Vector2(drawX2 + (drawPlayer.direction == -1 ? -8 : 6), drawY), null, Lighting.GetColor((int)((drawPlayer.position.X + drawPlayer.width / 2f) / 16f), (int)((drawPlayer.position.Y - texture.Height / 2f) / 16f)), modPlayer.bcarriagewheel / 15.0f, new Vector2(texture.Width / 2f, texture.Height / 2f), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                data.shader = dyeShader;
                data2.shader = dyeShader;
                drawInfo.DrawDataCache.Add(data);
                drawInfo.DrawDataCache.Add(data2);
            }
            if (modPlayer.silvajeep)
            {
                int gnuflip = 56 * -drawPlayer.direction;
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Mounts/Ground/SilvaJeepWheel").Value;
                int drawX = (int)(drawPlayer.position.X + drawPlayer.width / 2f - Main.screenPosition.X + gnuflip);
                int drawX2 = (int)(drawPlayer.position.X + drawPlayer.width / 2f - Main.screenPosition.X - gnuflip);
                int drawY = (int)(drawPlayer.position.Y + drawPlayer.height - Main.screenPosition.Y - 16) + (int)drawPlayer.gfxOffY + 2;
                DrawData data = new(texture, new Vector2(drawX + (drawPlayer.direction == 1 ? 20 : -20), drawY), null, Lighting.GetColor((int)((drawPlayer.position.X + drawPlayer.width / 2f) / 16f), (int)((drawPlayer.position.Y - texture.Height / 2f) / 16f)), modPlayer.bcarriagewheel / 15.0f, new Vector2(texture.Width / 2f, texture.Height / 2f), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                DrawData data2 = new(texture, new Vector2(drawX2 + (drawPlayer.direction == -1 ? 22 : -22), drawY), null, Lighting.GetColor((int)((drawPlayer.position.X + drawPlayer.width / 2f) / 16f), (int)((drawPlayer.position.Y - texture.Height / 2f) / 16f)), modPlayer.bcarriagewheel / 15.0f, new Vector2(texture.Width / 2f, texture.Height / 2f), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                data.shader = dyeShader;
                data2.shader = dyeShader;
                drawInfo.DrawDataCache.Add(data);
                drawInfo.DrawDataCache.Add(data2);
            }
        }
    }
}