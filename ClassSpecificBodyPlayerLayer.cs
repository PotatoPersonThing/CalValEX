using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalValEX
{
    public class ClassSpecificBodyPlayerLayer : PlayerDrawLayer
    {
        internal bool visible;

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            return true;
        }
        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            if (!visible)
            {
                Hide();
            }
        }
        public override Position GetDefaultPosition() => new Between(PlayerDrawLayers.Head, PlayerDrawLayers.Leggings);
        public ClassSpecificBodyPlayerLayer(string vanityPath, string vanityName) : base("CalValEX", vanityName + "BodyLayer", Body, delegate(PlayerDrawSet drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
                return;

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CalValEX");

            if (drawPlayer.body != mod.GetEquipSlot(vanityName, EquipType.Body))
                return;

            string Path = vanityPath + vanityName + "_Body";

            Texture2D texture = drawPlayer.HeldItem.magic ? ModContent.GetTexture($"{Path}_Magic")
                : drawPlayer.HeldItem.summon ? ModContent.GetTexture($"{Path}_Summoner")
                : drawPlayer.HeldItem.ranged ? ModContent.GetTexture($"{Path}_Ranger")
                : drawPlayer.HeldItem.thrown ? ModContent.GetTexture($"{Path}_Rogue")
                : drawPlayer.HeldItem.melee ? ModContent.GetTexture($"{Path}_Melee")
                : ModContent.GetTexture(Path);

            if (texture == ModContent.GetTexture(Path))
                return;

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 + 4f;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.bodyPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Lighting.GetColor(
                (int)(drawInfo.position.X + drawPlayer.width * 0.5) / 16,
                (int)(drawInfo.position.Y + drawPlayer.height * 0.5) / 16,
                Color.White);

            DrawData drawData = new DrawData(texture, position, drawPlayer.bodyFrame, color * alpha, drawPlayer.bodyRotation, drawInfo.bodyOrigin, 1f, drawInfo.spriteEffects, 0)
            {
                shader = drawInfo.bodyArmorShader
            };

            Main.playerDrawData.Add(drawData);
        })
        {
        }
    }
}
