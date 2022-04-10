using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace CalValEX
{
    public class ClassSpecificMapPlayerLayer : PlayerHeadLayer
    {
        public ClassSpecificMapPlayerLayer(string vanityPath, string vanityName) : base("CalValEX", vanityName + "MapLayer", Armor, delegate(PlayerHeadDrawInfo drawInfo)
        {
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

            float drawX = (int)(drawPlayer.position.X - Main.screenPosition.X - drawPlayer.bodyFrame.Width / 2f + drawPlayer.width / 2f);
            
            float drawY = (int)(drawPlayer.position.Y - Main.screenPosition.Y + drawPlayer.height -
                drawPlayer.bodyFrame.Height + 4);

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.headPosition + drawInfo.drawOrigin;
            
            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            float scale = drawInfo.scale;

            DrawData drawData = new DrawData(texture, position, drawPlayer.bodyFrame, Color.White * alpha,
                drawPlayer.headRotation, drawInfo.drawOrigin, scale, drawInfo.spriteEffects, 0);

            GameShaders.Armor.Apply(drawInfo.armorShader, drawPlayer, drawData);

            drawData.Draw(Main.spriteBatch);

            Main.pixelShader.CurrentTechnique.Passes[0].Apply();
        })
        {
        }
    }
}
