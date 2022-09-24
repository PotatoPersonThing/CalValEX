using CalValEX.Items.Equips.Wings;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.PlayerLayers {
    public class Helipack : PlayerDrawLayer {
        private int frameCounter = 0;
        private int frame = 0;
        public override Position GetDefaultPosition() => new BeforeParent(PlayerDrawLayers.Wings);

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo) {
            bool heli = false;
            for (int n = 13; n < 18 + drawInfo.drawPlayer.extraAccessorySlots; n++) {
                Item item = drawInfo.drawPlayer.armor[n];
                if (item.type == ModContent.ItemType<WulfrumHelipack>())
                    heli= true;
            }
            return heli || drawInfo.drawPlayer.GetModPlayer<CalValEXPlayer>().helipack;
        }

        protected override void Draw(ref PlayerDrawSet drawInfo) {
            if (drawInfo.shadow != 0f)
                return;

            Player drawPlayer = drawInfo.drawPlayer;
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();
            float alb = (255 - drawPlayer.immuneAlpha) / 255f;
            int dyeShader = drawPlayer.dye?[1].dye ?? 0;
            int secondyoffset;

            for (int n = 0; n < 18 + drawInfo.drawPlayer.extraAccessorySlots; n++) {
                Item item = drawInfo.drawPlayer.armor[n];
                if (item.type == ModContent.ItemType<WulfrumHelipack>()) {
                    if (n > 9)
                        dyeShader = drawPlayer.dye?[n - 10].dye ?? 0;
                    else
                        dyeShader = drawPlayer.dye?[n].dye ?? 0;
                }
            }

            if (drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 8 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 9 || 
                drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 15 || drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 16 ||
                drawPlayer.bodyFrame.Y == drawPlayer.bodyFrame.Height * 17)
                secondyoffset = 2;
            else
                secondyoffset = 0;

            frameCounter++;
            if (frameCounter > 6) {
                frameCounter = 0;
                frame++;
                if (frame > 10)
                    frame = 0;
            }

            if (modPlayer.helipack) {
                int gnuflip = -drawPlayer.direction;
                int drawX = (int)(drawPlayer.position.X + drawPlayer.width / 2f - Main.screenPosition.X - gnuflip + (15 * gnuflip));
                int drawY = (int)(drawPlayer.position.Y + drawPlayer.height - Main.screenPosition.Y - 4 - secondyoffset);
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Equips/Wings/WulfrumHelipack_Wings").Value;

                Rectangle texFrame = texture.Frame(1, 11, 0, frame);
                Rectangle frameY = new Rectangle(0, 26 * frame, texture.Width, 26);

                if (drawPlayer.mount.Active)
                    drawY += drawPlayer.mount.HeightBoost;

                DrawData dat = new DrawData(texture, new Vector2(drawX, drawY), frameY, Color.White * alb, 0f, new Vector2(texture.Width / 2f,
                    texture.Height), 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                dat.shader = dyeShader;
                drawInfo.DrawDataCache.Add(dat);
            }
        }
    }
}