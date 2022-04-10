using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalValEX
{
    public class ClassSpecificHeadPlayerLayer : PlayerLayer
    {
        public ClassSpecificHeadPlayerLayer(string vanityPath, string vanityName) : base("CalValEX", vanityName + "HeadLayer", Head, delegate(PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
                return;

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("CalValEX");

            if (drawPlayer.head != mod.GetEquipSlot(vanityName, EquipType.Head))
                return;

            string Path = vanityPath + vanityName + "_Head";

            Texture2D texture = drawPlayer.HeldItem.magic ? ModContent.GetTexture($"{Path}_Magic")
                : drawPlayer.HeldItem.summon ? ModContent.GetTexture($"{Path}_Summoner")
                : drawPlayer.HeldItem.ranged ? ModContent.GetTexture($"{Path}_Ranger")
                : drawPlayer.HeldItem.thrown ? ModContent.GetTexture($"{Path}_Rogue")
                : drawPlayer.HeldItem.melee ? ModContent.GetTexture($"{Path}_Melee")
                : ModContent.GetTexture(Path);

            if (texture == ModContent.GetTexture(Path))
                return;

            float drawX = (int)(drawInfo.position.X - Main.screenPosition.X -
                drawPlayer.bodyFrame.Width / 2f + drawPlayer.width / 2f);

            float drawY = (int)(drawInfo.position.Y - Main.screenPosition.Y + drawPlayer.height -
                drawPlayer.bodyFrame.Height + 4);

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.headPosition + drawInfo.headOrigin;
            
            Color color = Lighting.GetColor(
                (int)(drawInfo.position.X + drawPlayer.width * 0.5) / 16,
                (int)(drawInfo.position.Y + drawPlayer.height * 0.25) / 16,
                Color.White);

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Vector2 origin = drawInfo.headOrigin;

            DrawData drawData = new DrawData(texture, position, drawPlayer.bodyFrame, color * alpha, drawPlayer.headRotation, origin, 1f, drawInfo.spriteEffects, 0)
            {
                shader = drawInfo.headArmorShader
            };

            Main.playerDrawData.Add(drawData);
        })
        {
        }
    }
}
