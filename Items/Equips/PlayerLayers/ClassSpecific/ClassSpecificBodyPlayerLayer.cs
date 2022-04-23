using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.PlayerLayers.ClassSpecific
{
    public class ClassSpecificBodyPlayerLayer : PlayerDrawLayer
    {
        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            return drawInfo.drawPlayer.GetModPlayer<ClassSpecificLayerUtil>().HasClassSpecificBodyVanity();
        }

        public override Position GetDefaultPosition()
        {
            return new AfterParent(PlayerDrawLayers.Torso);
        }

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;

            ClassSpecificLayerUtil utils = drawPlayer.GetModPlayer<ClassSpecificLayerUtil>();

            (string bodyName, string texturePath) = utils.GetCurrentBodyData();

            Vector2 drawPosition = new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (float)(drawInfo.drawPlayer.bodyFrame.Width / 2) + (float)(drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + (float)drawInfo.drawPlayer.height - (float)drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2);
            Vector2 addedOffset = Main.OffsetsPlayerHeadgear[drawInfo.drawPlayer.bodyFrame.Y / drawInfo.drawPlayer.bodyFrame.Height];
            addedOffset.Y -= 2f;
            drawPosition += addedOffset * -drawInfo.playerEffect.HasFlag(SpriteEffects.FlipVertically).ToDirectionInt();
            float bodyRotation = drawInfo.drawPlayer.bodyRotation;

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

            Texture2D texture = ModContent.Request<Texture2D>(texturePath + bodyName + "_Body_" + currentDamageType).Value;
            DrawData drawData = new(texture, drawPosition, drawInfo.compTorsoFrame, drawInfo.colorArmorBody, bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0)
            {
                shader = drawInfo.cBody
            };

            PlayerDrawLayers.DrawCompositeArmorPiece(ref drawInfo, CompositePlayerDrawContext.Torso, drawData);
        }
    }
}
