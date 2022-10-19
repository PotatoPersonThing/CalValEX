using CalValEX.Items.Equips.Wings;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.PlayerLayers {
    public class Helipack : PlayerDrawLayer {
        private int frame;
        private int frameCounter;
        private int maxFrames;
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
            float alb = (255 - drawPlayer.immuneAlpha) / 255f;
            
            for (int n = 0; n < 18 + drawInfo.drawPlayer.extraAccessorySlots; n++) {
                Item item = drawInfo.drawPlayer.armor[n];
                if (item.type == ModContent.ItemType<WulfrumHelipack>()) {
                    if (n > 9)
                        dyeShader = drawPlayer.dye?[n - 10].dye ?? 0;
                    else
                        dyeShader = drawPlayer.dye?[n].dye ?? 0;
                }
            }

            Vector2 packPos =
                new Vector2(
                    (int)(drawInfo.Position.X - (drawInfo.drawPlayer.bodyFrame.Width / 2) + (drawInfo.drawPlayer.width / 2) - (16f * drawPlayer.direction)),
                    (int)(drawInfo.Position.Y + drawInfo.drawPlayer.height) - 55f)
                + drawInfo.drawPlayer.headPosition + drawInfo.headVect;

            packPos -= Main.screenPosition;

            if (player.wingTime != player.wingTimeMax) {
                frameCounter++;
                if (frameCounter > 4) {
                    frameCounter = 0;
                    frame++;
                    if (frame == maxFrames) {
                        frame = player.wingTime != 0 ? 1 : 0;
                    }
                }
            } else {
                frame = 0;
                frameCounter = 0;
            }

            Texture2D texture;
            if (player.wingTime != 0) { 
                texture = ModContent.Request<Texture2D>("CalValEX/Items/Equips/Wings/WulfrumHelipackEquipped").Value;
                maxFrames = 11;
            } else { 
                texture = ModContent.Request<Texture2D>("CalValEX/Items/Equips/Wings/WulfrumHelipackMalfunction").Value;
                maxFrames = 10;
            }

            if (modPlayer.helipack) {
                Vector2 origin = new Vector2(texture.Width / 2f, texture.Height / 2f / maxFrames);
                Rectangle yFrame = texture.Frame(1, maxFrames, 0, frame);
                DrawData dat = new DrawData(texture, packPos, yFrame, drawInfo.colorArmorHead * alb, 0f, origin, 1, 
                    drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
                dat.shader = dyeShader;
                drawInfo.DrawDataCache.Add(dat);
            }
        }
    }
}