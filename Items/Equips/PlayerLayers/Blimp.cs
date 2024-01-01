using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.PlayerLayers
{
    public class Blimp: PlayerDrawLayer
    {
        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            bool hastallhat = false;
            if (drawInfo.drawPlayer.GetModPlayer<CalValEXPlayer>().twinballoon || drawInfo.drawPlayer.GetModPlayer<CalValEXPlayer>().apballoon || drawInfo.drawPlayer.GetModPlayer<CalValEXPlayer>().artballoon)
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
            Mod mod = ModLoader.GetMod("CalValEX");
            Player player = Main.LocalPlayer;
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();
            int secondyoffset = 0;
            float alb = (255 - drawPlayer.immuneAlpha) / 255f;
            if (modPlayer.apballoon || modPlayer.twinballoon)
            {
                int dyeShader = drawPlayer.dye?[1].dye ?? 0;
                for (int n = 0; n < 18 + drawInfo.drawPlayer.extraAccessorySlots; n++)
                {
                    Item item = drawInfo.drawPlayer.armor[n];
                    if (item.type == ModContent.ItemType<Items.Equips.Balloons.ArtemisBalloon>() || item.type == ModContent.ItemType<Items.Equips.Balloons.ExoTwinsBalloon>())
                    {
                        if (n > 9)
                            dyeShader = drawPlayer.dye?[n - 10].dye ?? 0;
                        else
                            dyeShader = drawPlayer.dye?[n].dye ?? 0;
                    }
                }
                int winflip = 1 * -drawPlayer.direction;
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Equips/Balloons/ApolloBalloonEquipped").Value;
                Vector2 wtf = drawPlayer.Center - Main.screenPosition + new Vector2(0f * drawPlayer.direction + (40 * drawPlayer.direction), drawPlayer.gfxOffY - 170 - secondyoffset);
                Vector2 origin = new(texture.Width / 2f, texture.Height / 2f / 6f);
                Rectangle conesquare = texture.Frame(1, 5, 0, modPlayer.twinframe);
                DrawData data = new(texture, wtf, conesquare, drawInfo.colorArmorBody, 0f, origin, 1, drawPlayer.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0
                );
                data.shader = dyeShader;
                drawInfo.DrawDataCache.Add(data);
            }
            if ((modPlayer.artballoon && !modPlayer.apballoon) || modPlayer.twinballoon)
            {
                int dyeShader = drawPlayer.dye?[1].dye ?? 0;
                for (int n = 0; n < 18 + drawInfo.drawPlayer.extraAccessorySlots; n++)
                {
                    Item item = drawInfo.drawPlayer.armor[n];
                    if (item.type == ModContent.ItemType<Items.Equips.Balloons.ApolloBalloon>() || item.type == ModContent.ItemType<Items.Equips.Balloons.ExoTwinsBalloon>())
                    {
                        if (n > 9)
                            dyeShader = drawPlayer.dye?[n - 10].dye ?? 0;
                        else
                            dyeShader = drawPlayer.dye?[n].dye ?? 0;
                    }
                }
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Equips/Balloons/ArtemisBalloonEquipped").Value;
                Vector2 wtf = drawPlayer.Center - Main.screenPosition + new Vector2(0f * drawPlayer.direction - (140 * drawPlayer.direction), drawPlayer.gfxOffY - 170 - secondyoffset);
                Vector2 origin = new(texture.Width / 2f, texture.Height / 2f / 6f);
                Rectangle conesquare = texture.Frame(1, 5, 0, modPlayer.twinframe);
                DrawData data = new(texture, wtf, conesquare, drawInfo.colorArmorBody, 0f, origin, 1, drawPlayer.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0
                );
                data.shader = dyeShader;
                drawInfo.DrawDataCache.Add(data);
            }
        }
    }
}