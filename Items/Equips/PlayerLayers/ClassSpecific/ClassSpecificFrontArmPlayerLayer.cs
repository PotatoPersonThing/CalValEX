using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.PlayerLayers.ClassSpecific
{
    public class ClassSpecificFrontArmPlayerLayer : PlayerDrawLayer
    {
        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            return drawInfo.drawPlayer.GetModPlayer<ClassSpecificLayerUtil>().HasClassSpecificBodyVanity();
        }

        public override Position GetDefaultPosition()
        {
            return new BeforeParent(PlayerDrawLayers.ArmOverItem);
        }

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;

            ClassSpecificLayerUtil utils = drawPlayer.GetModPlayer<ClassSpecificLayerUtil>();

            (string bodyName, string texturePath) = utils.GetCurrentBodyData();

            Vector2 drawPosition = new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (float)(drawInfo.drawPlayer.bodyFrame.Width / 2) + (float)(drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + (float)drawInfo.drawPlayer.height - (float)drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2);
            Vector2 value = Main.OffsetsPlayerHeadgear[drawInfo.drawPlayer.bodyFrame.Y / drawInfo.drawPlayer.bodyFrame.Height];
            value.Y -= 2f;
            drawPosition += value * -drawInfo.playerEffect.HasFlag(SpriteEffects.FlipVertically).ToDirectionInt();
            float armRotation = drawInfo.drawPlayer.bodyRotation + drawInfo.compositeFrontArmRotation;
            Vector2 bodyVect = drawInfo.bodyVect;
            Vector2 compositeOffset_FrontArm = new(-5 * ((!drawInfo.playerEffect.HasFlag(SpriteEffects.FlipHorizontally)) ? 1 : (-1)), 0f);
            bodyVect += compositeOffset_FrontArm;
            drawPosition += compositeOffset_FrontArm;
            if (drawInfo.compFrontArmFrame.X / drawInfo.compFrontArmFrame.Width >= 7)
                drawPosition += new Vector2((!drawInfo.playerEffect.HasFlag(SpriteEffects.FlipHorizontally)) ? 1 : (-1), (!drawInfo.playerEffect.HasFlag(SpriteEffects.FlipVertically)) ? 1 : (-1));

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
            DrawData drawData = new(texture, drawPosition, drawInfo.compFrontShoulderFrame, drawInfo.colorArmorBody, armRotation, bodyVect, 1f, drawInfo.playerEffect, 0)
            {
                shader = drawInfo.cBody
            };
            
            PlayerDrawLayers.DrawCompositeArmorPiece(ref drawInfo, CompositePlayerDrawContext.FrontShoulder, drawData);
            drawData.sourceRect = drawInfo.compFrontArmFrame;
            PlayerDrawLayers.DrawCompositeArmorPiece(ref drawInfo, CompositePlayerDrawContext.FrontArm, drawData);
        }
    }
}
