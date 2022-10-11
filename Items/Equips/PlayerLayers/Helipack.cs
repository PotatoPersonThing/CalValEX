using CalValEX.Items.Equips.Wings;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.PlayerLayers {
    public class Helipack : PlayerDrawLayer {
        private int frame = 0;
        private int frameCounter = 0;
        public override Position GetDefaultPosition() => new BeforeParent(PlayerDrawLayers.Wings);

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo) {
            bool heli = false;
            if (drawInfo.drawPlayer.GetModPlayer<CalValEXPlayer>().helipack)
                heli = true;

            return heli;
        }

        protected override void Draw(ref PlayerDrawSet drawInfo) {
            if (drawInfo.shadow != 0f)
                return;

            Player player = Main.LocalPlayer;
            Player drawPlayer = drawInfo.drawPlayer;
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();
            int dyeShader = drawPlayer.dye?[1].dye ?? 0;

            Vector2 packPos =
                new Vector2(
                    (int)(drawInfo.Position.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2)),
                    (int)(drawInfo.Position.Y + drawInfo.drawPlayer.height - drawInfo.drawPlayer.bodyFrame.Height) + 50f)
                + drawInfo.drawPlayer.headPosition + drawInfo.headVect;

            packPos -= Main.screenPosition;

            if (player.wingTime != 0) { 
                frameCounter++;
                if (frameCounter > 4) {
                    frameCounter = 0;
                    frame++;
                    if (frame > 10) {
                        frame = 1;
                    }
                }
            } else {
                frame = 0;
                frameCounter = 0;
            }

            if (modPlayer.helipack) {
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Equips/Wings/WulfrumHelipackEquipped").Value;
                Vector2 origin = new Vector2(texture.Width / 2f, texture.Height);
                Rectangle yFrame = texture.Frame(1, 11, 0, frame);
                DrawData dat = new DrawData(texture, new Vector2(packPos.X, packPos.Y), yFrame, drawInfo.colorArmorHead, 0f, origin, 1, 
                    drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                dat.shader = dyeShader;
                drawInfo.DrawDataCache.Add(dat);
            }
        }
    }
}