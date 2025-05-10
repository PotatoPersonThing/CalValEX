using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.PlayerLayers.ClassSpecific
{
    public class ClassSpecificHeadPlayerLayer : PlayerDrawLayer
    {
        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            return drawInfo.drawPlayer.GetModPlayer<ClassSpecificLayerUtil>().HasClassSpecificHeadVanity();
        }

        public override Position GetDefaultPosition()
        {
            return new BeforeParent(PlayerDrawLayers.Head);
        }

        public override bool IsHeadLayer => true;

        // why is the map always 2 pixels HIGHER????? (in grav flip) -- resorted to just not drawing the original head (and making the original head invisible!)
        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;

            ClassSpecificLayerUtil utils = drawPlayer.GetModPlayer<ClassSpecificLayerUtil>();

            (string headName, string texturePath) = utils.GetCurrentHeadData();

            Vector2 headPosition = drawInfo.helmetOffset +
                new Vector2(
                    (int)(drawInfo.Position.X - (float)(drawInfo.drawPlayer.bodyFrame.Width / 2) + (float)(drawInfo.drawPlayer.width / 2)),
                    (int)(drawInfo.Position.Y + (float)drawInfo.drawPlayer.height - (float)drawInfo.drawPlayer.bodyFrame.Height + 4f))
                + drawInfo.drawPlayer.headPosition
                + drawInfo.headVect;

            headPosition -= Main.screenPosition;

            Vector2 origin = drawInfo.headVect;

            Rectangle headFrame = drawPlayer.bodyFrame;

            string currentDamageType = "Typeless";

            int heldDamageType = drawPlayer.HeldItem.DamageType.Type;

            if (heldDamageType == DamageClass.Magic.Type)
            {
                currentDamageType = "Magic";
            }

            if (heldDamageType == DamageClass.Melee.Type)
            {
                currentDamageType = "Melee";
            }

            if (heldDamageType == DamageClass.Ranged.Type)
            {
                currentDamageType = "Ranged";
            }

            if (heldDamageType == DamageClass.Throwing.Type) //change this to rogue once calamity exists on 1.4!
            {
                currentDamageType = "Rogue";
            }

            if (heldDamageType == DamageClass.Summon.Type)
            {
                currentDamageType = "Summoner";
            }

            Texture2D texture = ModContent.Request<Texture2D>(texturePath + headName + "_Head_" + currentDamageType).Value;

            DrawData drawData = new(texture, headPosition, headFrame, drawInfo.colorArmorHead, drawInfo.drawPlayer.headRotation, origin, 1f, drawInfo.playerEffect, 0)
            {
                shader = drawInfo.cHead
            };

            drawInfo.DrawDataCache.Add(drawData);
        }
    }
}
