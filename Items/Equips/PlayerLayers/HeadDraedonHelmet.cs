using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using CalValEX.Items.Equips.Hats.Draedon;
using CalValEX;

namespace CalValEX.Items.Equips.PlayerLayers
{
    public class HeadDraedonHelmet : PlayerDrawLayer
    {
        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            return (drawInfo.drawPlayer.armor[0].type == ModContent.ItemType<Items.Equips.Hats.Draedon.DraedonHelmet>() || drawInfo.drawPlayer.armor[10].type == ModContent.ItemType<Items.Equips.Hats.Draedon.DraedonHelmet>());
        }
        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Head);
        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Player player = Main.LocalPlayer;
            Texture2D texture = drawPlayer.HeldItem.DamageType == DamageClass.Magic ? ModContent.Request<Texture2D>("CalValEX/Items/Equips/Hats/Draedon/DraedonHelmet_Head_Magic").Value
                : drawPlayer.HeldItem.DamageType == DamageClass.Summon ? ModContent.Request<Texture2D>("CalValEX/Items/Equips/Hats/Draedon/DraedonHelmet_Head_Summoner").Value
                : drawPlayer.HeldItem.DamageType == DamageClass.Ranged ? ModContent.Request<Texture2D>("CalValEX/Items/Equips/Hats/Draedon/DraedonHelmet_Head_Ranger").Value
                : drawPlayer.HeldItem.DamageType == DamageClass.Throwing ? ModContent.Request<Texture2D>("CalValEX/Items/Equips/Hats/Draedon/DraedonHelmet_Head_Rogue").Value
                : drawPlayer.HeldItem.DamageType == DamageClass.Melee ? ModContent.Request<Texture2D>("CalValEX/Items/Equips/Hats/Draedon/DraedonHelmet_Head_Melee").Value
                : ModContent.Request<Texture2D>("CalValEX/Items/Equips/Hats/Draedon/DraedonHelmet_Head_Typeless").Value;

            if (texture == DraedonHelmetTextureCache.DraedonDefaultHelm)
                return;

            if (drawInfo.shadow != 0f)
            {
                return;
            }
            CalValEXPlayer modPlayer = drawPlayer.GetModPlayer<CalValEXPlayer>();
            int dyeShader = drawPlayer.dye?[0].dye ?? 0;
            //int drawX = (int)(drawPlayer.position.X + drawPlayer.width / 2f - Main.screenPosition.X);
            Vector2 wtf = drawPlayer.Center - Main.screenPosition + new Vector2(0f * drawPlayer.direction, drawPlayer.gfxOffY);
            //int drawY = (int)(drawPlayer.position.Y + drawPlayer.height - 32 - Main.screenPosition.Y);
            if (drawPlayer.mount.Active)
                wtf.Y += drawPlayer.mount.HeightBoost;
            Vector2 origin = new Vector2(texture.Width / 2f, texture.Height / 2f / 20f);
            Rectangle conesquare = texture.Frame(1, 20, 0, 1);
            float drawX = (int)drawPlayer.position.X + drawPlayer.width / 2;
            float drawY = (int)drawPlayer.position.Y + drawPlayer.height -
                drawPlayer.bodyFrame.Height / 2 + 4f;
            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.headPosition -
                                                     Main.screenPosition;
            DrawData dat = new DrawData(texture, position, conesquare, drawInfo.colorArmorHead, 0f, origin, 1f, drawPlayer.direction != -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
            dat.shader = dyeShader;
            drawInfo.DrawDataCache.Add(dat);
        }
    }
}